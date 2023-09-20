using System.Text.Json.Serialization;

[Asset]
[System.Serializable]
public class RawList : Asset
{
    
    public int someData { get; set; }
    public RawList()
    {
        someData = 42069;
    }
}
