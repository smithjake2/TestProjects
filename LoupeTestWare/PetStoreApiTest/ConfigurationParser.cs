using Newtonsoft.Json.Linq;
using PetStoreApiTest.Context;

namespace PetStoreApiTest
{
    [Binding]
    public class ConfigurationParser
    {
        public ConfigurationParser(EnvironmentContext environmentContext)
        {
            EnvironmentContext = environmentContext;
        }
        public EnvironmentContext EnvironmentContext { get; }

        [BeforeScenario]
        public void GetEnvironmentDomain()
        {

            var jArray = GetJArray("Configuration\\Configuration.json");
            EnvironmentContext.Environment = jArray[0].ToObject<EnvironmentContext>().Environment;


            var serverJArray = GetJArray($"Configuration\\Configuration.{EnvironmentContext.Environment}.json");

            EnvironmentContext.Server = serverJArray[0].ToObject<EnvironmentContext>().Server;
        }

        public JArray GetJArray(string fileLocation)
        {
            using StreamReader reader = new(fileLocation);
            var json = reader.ReadToEnd();
            var jArray = JArray.Parse(json);

            return jArray;
        }
    }
}
