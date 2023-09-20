using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Reflection;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json.Serialization;

public static class AssetDatabase
{

    #region -- Observable Events --
    public static Action<string, Asset> AssetLoaded = (guid, asset) => { };
    public static Action<string> FolderLoaded = (path) => { };
    public static Action<string> AssetUnloaded = (guid) => { };
    public static Action<string> FolderUnloaded = (guid) => { };
    public static Action DatabaseCleared = () => { };

    #endregion

    #region -- Cached Settings --
    private static JsonSerializerOptions serializerOptions;
    private static JsonSerializerOptions SerializerOptions
    {
        get
        {
            if (serializerOptions == null)
            {
                serializerOptions = new JsonSerializerOptions()
                {
                    WriteIndented = true
                    
                };
            }
            return serializerOptions;
        }
    }
    #endregion
    #region -- The Data & Types --
    private static HashSet<string> folders;
    private static HashSet<string> Folders
    {
        get
        {
            if (folders == null)
            {
                folders = new HashSet<string>();
            }
            return folders;
        }
    }

    private static Dictionary<string, object> assets;
    private static Dictionary<string, object> Assets
    {
        get
        {
            if (assets == null)
            {
                assets = new Dictionary<string, object>();
            }
            return assets;
        }
    }

    private static Dictionary<string, Type> assetTypeLookup;
    private static Dictionary<string, Type> AssetTypeLookup{
        get
        {
            if (assetTypeLookup == null)
            {
                assetTypeLookup = new Dictionary<string, Type>();

                //populate the asset lookup if it hasn't been populated yet
                foreach (Type t in AssetTypes)
                {
                    assetTypeLookup.Add(t.Name, t);
                }
            }
            return assetTypeLookup;
        }
    }

    

    #endregion

    #region -- Loading --
    private static void LoadFolder(string path)
    {
        if (folders.Contains(path))
        {
            throw new Exception(string.Format("Folder was already previously loaded \"{0}\"", path));
        }

        string fileName = Path.GetFileName(path);
        if (fileName == "." || fileName == "..")
        {
            return;
        }
        if (!Directory.Exists(path))
        {
            throw new Exception("Path does not exist");
        }
        Folders.Add(path);
        FolderLoaded.Invoke(path);

        foreach (string directoryPath in Directory.EnumerateDirectories(path))
        {
            LoadFolder(directoryPath);
        }
        foreach (string filePath in Directory.EnumerateFiles(path, "*.json"))
        {
            LoadFile(filePath);
        }
    }
    private static void LoadFile(string path)
    {
        Asset assetTrunk = LoadAssetTrunk(path);
        assetTrunk.path = path;
        object newAsset = LoadAsset(path);
        if (newAsset == null)
        {
            return;
        }
        Assets[assetTrunk.guid] = newAsset;
        AssetLoaded.Invoke(assetTrunk.guid, assetTrunk);
    }
    #endregion

    #region -- Unloading -- 

    private static void UnloadAsset(string guid)
    {

        if (!Assets.ContainsKey(guid))
        {
            throw new Exception(string.Format("Asset with guid not previously loaded \"{0}\"", guid));
        }
        Assets.Remove(guid);
        AssetUnloaded.Invoke(guid);

    }
    private static void UnloadFolder(string path)
    {
        if (!Folders.Contains(path))
        {
            throw new Exception(string.Format("Folder with path not previously loaded \"{0}\"", path));
        }
        Folders.Remove(path);
        FolderUnloaded.Invoke(path);

    }
    private static void UnloadDatabase()
    {
        List<string> guidList = new List<string>(Assets.Keys);
        foreach (string guid in guidList)
        {
            UnloadAsset(guid);
        }
        List<string> pathList = new List<string>(Folders);
        foreach (string path in pathList)
        {
            UnloadFolder(path);
        }
        Assets.Clear();
        Folders.Clear();
        DatabaseCleared.Invoke();
    }

    #endregion

    #region -- Asset Deserialization -- 
    /// <summary>
    /// Load an Asset from JSON file
    /// </summary>
    /// <param name="path">JSON file path</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    private static Asset LoadAssetTrunk(string path)
    {
        if (!File.Exists(path))
        {
            throw new Exception(string.Format("File not found: \"{0}\"", path));
        }
        if (Directory.Exists(path))
        {
            throw new Exception(string.Format("Path specified is a directory: \"{0}\"", path));
        }
        string fileContent = File.ReadAllText(path);
        return JsonSerializer.Deserialize<Asset>(fileContent);
        


    }
    private static object LoadAsset(string typeName, string path)
    {
        if (!AssetTypeLookup.TryGetValue(typeName, out Type assetType))
        {
            throw new Exception(string.Format("Type \"{0}\" does not exist", typeName));
        }
        //JsonTypeInfo typeInfo = Asset.Get
        object newAsset = JsonSerializer.Deserialize<object>(File.ReadAllText(path));
        return newAsset;
    }
    private static object LoadAsset(string path)
    {
        Asset assetTrunk = LoadAssetTrunk(path);
        if (assetTrunk.type != "Asset")
        {
            return null;
        }
        if (string.IsNullOrEmpty(assetTrunk.guid))
        {
            throw new Exception("Asset does not have a valid GUID");
        }
        object newAsset = LoadAsset(assetTrunk.asset_type, path);
        Assets[assetTrunk.guid] = newAsset;

        return newAsset;
    }
    #endregion

    #region -- Public Interface -- 

    public static void OpenFolder(string path)
    {
        UnloadDatabase();
        LoadFolder(path);
    }

    public static object CreateAsset(Type t, string path)
    {
        //Create a new instance of something and validate that it's of type Asset
        object newAsset = System.Activator.CreateInstance(t);
        if (!(newAsset is Asset))
        {
            throw new Exception(string.Format("Type \"{0}\" is not of type Asset", t.Name));
        }

        //Set the asset's generic properties
        Asset assetTrunk = newAsset as Asset;
        assetTrunk.type = "Asset";
        assetTrunk.guid = Guid.NewGuid().ToString();
        assetTrunk.asset_type = t.Name;
        assetTrunk.path = path;

        //Write the file
        string newAssetJSON = JsonSerializer.Serialize(newAsset, t, SerializerOptions);
        string newAssetPath = UniquePathUtility.CreateUniqueName(path, t.Name);
        File.WriteAllText(newAssetPath, newAssetJSON);

        LoadFile(newAssetPath);
        return newAsset;

    }

    public static object CreateAsset(string typeName, string path)
    {
        if (!AssetTypeLookup.TryGetValue(typeName, out Type t)) {
            throw new Exception(string.Format("Asset type \"{0}\" was not registered and cannot be created", typeName));
        }
        return CreateAsset(t, path);
    }

    public static IEnumerable<Type> AssetTypes
    {
        get
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type t in assembly.GetTypes())
                {
                    if (t.GetCustomAttribute<AssetAttribute>() == null)
                    {
                        continue;
                    }
                    yield return t;
                }
            }
        }
    }
    #endregion



}