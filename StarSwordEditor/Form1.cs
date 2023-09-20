using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace StarSwordEditor
{
    public partial class editor : Form
    {
        public editor()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        OpenFileDialog openDialog;
        OpenFileDialog OpenDialog
        {
            get
            {

                if (openDialog == null)
                {
                    openDialog = new OpenFileDialog();
                    openDialog.Multiselect = false;
                    openDialog.Title = "Open folder";
                    openDialog.DefaultExt = "JSON";
                    openDialog.CheckPathExists = true;                    

                }
                return openDialog;
            }
        }


        string currentFolder;
        string CurrentFolder
        {
            get
            {
                return Properties.Settings.Default.CurrentFolder;
            }
            set
            {
                if (value == currentFolder)
                {
                    return;
                }
                currentFolder = value;


                //Clear current tree view
                Folders.Clear();
                assetTreeView.Nodes.Clear();

                AssetDatabase.OpenFolder(currentFolder);

                Properties.Settings.Default.CurrentFolder = value;
                Properties.Settings.Default.Save();
            }
        }
        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Show a dialog
            DialogResult result = OpenDialog.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }

            //Open the folder with the asset database
            CurrentFolder = System.IO.Path.GetDirectoryName(OpenDialog.FileName);


        }

        private void fileExitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit(new CancelEventArgs(true));
        }

        private void editor_Load(object sender, EventArgs e)
        {            
            //Listen for asset database changes
            AssetDatabase.FolderLoaded += OnFolderAdded;
            AssetDatabase.AssetLoaded += OnAssetAdded;

            //Open the last opened folder
            if (!string.IsNullOrEmpty(CurrentFolder) && Directory.Exists(CurrentFolder))
            {
                AssetDatabase.OpenFolder(CurrentFolder);
            }

            PopulateCreateAssetMenu();


        }

        Dictionary<Type, ToolStripMenuItem> createAssetMenuItems;
        Dictionary<Type, ToolStripMenuItem> CreateAssetMenuItems
        {
            get
            {
                if (createAssetMenuItems == null)
                {
                    createAssetMenuItems = new Dictionary<Type, ToolStripMenuItem>();
                }
                return createAssetMenuItems;
            }
        }

        private void PopulateCreateAssetMenu()
        {

            foreach (Type t in AssetDatabase.AssetTypes)
            {
                if (CreateAssetMenuItems.ContainsKey(t))
                {
                    continue;
                }
                ToolStripMenuItem newMenuItem = new ToolStripMenuItem(string.Format("New {0}", t.Name), null, (sender, e) =>
                {
                    AssetDatabase.CreateAsset(t, CurrentFolder);
                });
                assetMenu.DropDownItems.Add(newMenuItem);
                CreateAssetMenuItems.Add(t, newMenuItem);

            }
        }
        private void OnAssetAdded(string guid, Asset asset)
        {
            string directory = Path.GetDirectoryName(asset.path);
            TreeNodeCollection nodeCollection = assetTreeView.Nodes;
            if (Folders.TryGetValue(directory, out TreeNode node))
            {
                if (!node.IsExpanded)
                {
                    node.ExpandAll();
                }
                nodeCollection = node.Nodes;
            }

            string fileName = Path.GetFileNameWithoutExtension(asset.path);
            nodeCollection.Add(guid, fileName,1);
        }

        private Dictionary<string, TreeNode> folders;
        private Dictionary<string, TreeNode> Folders
        {
            get
            {
                if (folders == null)
                {
                    folders = new Dictionary<string, TreeNode>();
                }
                return folders;
            }
        }
        private void OnFolderAdded(string path)
        {
            string directory = Path.GetDirectoryName(path);
            TreeNodeCollection nodeCollection = assetTreeView.Nodes;
            if (Folders.TryGetValue(directory, out TreeNode node)){
                nodeCollection = node.Nodes;
            }
            string folderName = Path.GetFileName(path);
            TreeNode newNode = nodeCollection.Add(path, folderName, 0);

            folders.Add(path, newNode);
            

        }

        private void assetTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

            e.Node.SelectedImageIndex = e.Node.ImageIndex;
        }

        private void assetCreateEmptyMenu_Click(object sender, EventArgs e)
        {
            //AssetFactory.CreateAsset<Asset>(CurrentFolder);
        }
    }
}
