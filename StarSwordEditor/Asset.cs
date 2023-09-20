using System;
using System.Text.Json.Serialization;

[System.Serializable]

public class Asset
{
    public string type { get; set; }
    public string asset_type { get; set; }
    public string guid { get; set; }
    public string file { get; set; }
    
    [NonSerialized]
    public string path;

}
