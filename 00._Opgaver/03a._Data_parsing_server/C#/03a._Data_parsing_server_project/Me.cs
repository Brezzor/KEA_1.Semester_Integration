using System.Text.Json.Serialization;
using System.Xml.Serialization;

[XmlRoot(ElementName = "me")]
public class Me
{
    [XmlElement(ElementName = "name")]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [XmlElement(ElementName = "age")]
    [JsonPropertyName("age")]
    public int? Age { get; set; }

    [XmlArray(ElementName = "hobbies")]
    [XmlArrayItem(ElementName = "hobby")]
    [JsonPropertyName("hobbies")]
    public List<string>? Hobbies { get; set; }

    public void WriteToConsole()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Hobbies: {string.Join(", ", Hobbies!)}\n");
    }
}

public class MeResponse
{
    [JsonPropertyName("me")]
    public Me? Me { get; set; }
}