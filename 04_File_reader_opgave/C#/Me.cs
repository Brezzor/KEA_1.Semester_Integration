using System.Text.Json.Serialization;

class Me
{
    public Me(string name, int age, List<string> hoppies)
    {
        Name = name;
        Age = age;
        Hoppies = hoppies;
    }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("age")]
    public int Age { get; set; }
    [JsonPropertyName("hobbies")]
    public List<string> Hoppies { get; set; }
}