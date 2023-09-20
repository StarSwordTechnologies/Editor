using System.Text.Json.Serialization;

[Asset]
[System.Serializable]
public class RawText : Asset
{
    public string someText { get; set; }
}