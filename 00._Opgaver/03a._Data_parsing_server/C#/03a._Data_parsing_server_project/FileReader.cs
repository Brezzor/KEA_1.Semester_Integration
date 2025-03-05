using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

static class FileReader
{
    public static async Task<Me?> ReadJsonFile()
    {
        using (FileStream fileStream = File.OpenRead(@"./Text_files/me.json"))
        {
            Me? me = await JsonSerializer.DeserializeAsync<Me>(fileStream);

            if (me != null)
            {
                Console.WriteLine("From JSON:");
                me.WriteToConsole();
            }

            return me;
        }
    }

    public static Me? ReadXMLFile()
    {
        using (FileStream fileStream = File.OpenRead(@"./Text_files/me.xml"))
        {
            Me? me = (Me?)new XmlSerializer(typeof(Me)).Deserialize(fileStream);

            if (me != null)
            {
                Console.WriteLine("From XML:");
                me.WriteToConsole();
            }

            return me;
        }
    }

    public static async Task<Me?> ReadCSVFile()
    {
        using (FileStream fileStream = File.OpenRead(@"./Text_files/me.csv"))
        {
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                string? header = await streamReader.ReadLineAsync();

                Me? me = new Me();

                while (!streamReader.EndOfStream)
                {
                    string? line = await streamReader.ReadLineAsync();

                    if (line != null)
                    {
                        string[] values = line.Split(',');
                        string[] hobbies = values[2].Split("/");

                        me = new Me
                        {
                            Name = values[0],
                            Age = int.Parse(values[1]),
                            Hobbies = hobbies.ToList()
                        };
                    }
                }

                if (me != null)
                {
                    Console.WriteLine("From CSV:");
                    me.WriteToConsole();
                }

                return me;
            }
        }
    }

    public static Me? ReadYAMLFile()
    {
        Me me = new Me();

        string yamlContent = File.ReadAllText(@"./Text_files/me.yaml");

        var deserializerBuilder = new DeserializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance);

        var deserializer = deserializerBuilder.Build();

        me = deserializer.Deserialize<Me>(yamlContent);

        if (me != null)
        {
            Console.WriteLine("From YAML:");
            me.WriteToConsole();
        }

        return me;
    }

    public static Me? ReadTXTFile()
    {
        Me me = new Me();

        string[] lines = File.ReadAllLines(@"./Text_files/me.txt");

        Dictionary<string, string> keyValues = lines.ToDictionary(s => s.Split(": ")[0].Trim(), s => s.Split(": ")[1].Trim());

        me.Name = keyValues["name"];
        me.Age = int.Parse(keyValues["age"]);
        me.Hobbies = keyValues["hobbies"].Split(", ").ToList();

        if (me != null)
        {
            Console.WriteLine("From TXT:");
            me.WriteToConsole();
        }

        return me;
    }
}
