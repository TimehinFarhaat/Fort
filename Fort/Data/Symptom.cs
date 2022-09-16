using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fort.Data
{
    public class Sendsms
    {
       
    }
    public class Symptom
    {
        [JsonPropertyName("ID")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }
    }

    public class SymptomStore
    {
        public const string JsonLocation = "Data.symptoms.json";
        public Dictionary<string, List<int>> Symptoms { get; } = new Dictionary<string, List<int>>();

        public async Task SetupSymptoms()
        {
            var fileContents = await File.ReadAllTextAsync(JsonLocation);
            var symptoms = JsonSerializer.Deserialize<Symptom[]>(fileContents);
            if (symptoms == null)
            {
                throw new Exception("Invalid json file passed for symptoms");
            }

            foreach (var symptom in symptoms)
            {
                var words = symptom.Name.ToLowerInvariant().Split(' ');
                foreach (var word in words)
                {
                    if (Symptoms.ContainsKey(word))
                    {
                        Symptoms[word].Add(symptom.Id);
                    }
                    else
                    {
                        Symptoms.Add(word, new List<int> { symptom.Id });
                    }
                }
            }
        }

        public async Task<int[]> Search(string nameParts)
        {
            var words = nameParts.ToLowerInvariant().Split(" ");
            var result = new HashSet<int>();
            foreach (var word in words)
            {
                var symptomIds = Symptoms.GetValueOrDefault(word);
                if (symptomIds == null)
                {
                    continue;
                }

                foreach (var symptomId in symptomIds)
                {
                    result.Add(symptomId);
                }
            }
            return result.ToArray();
        }
    }
}
