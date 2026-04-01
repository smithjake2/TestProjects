namespace PetStoreApiTest.ApiHelper
{
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Pet : IApiResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("category")]
        public Category? Category { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("photoUrls")]
        public string[]? PhotoUrls { get; set; }

        [JsonProperty("tags")]
        public Category[]? Tags { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Pet pet &&
                   Id == pet.Id &&
                   EqualityComparer<Category?>.Default.Equals(Category, pet.Category) &&
                   Name == pet.Name &&
                   EqualityComparer<string[]?>.Default.Equals(PhotoUrls, pet.PhotoUrls) &&
                   EqualityComparer<Category[]?>.Default.Equals(Tags, pet.Tags) &&
                   Status == pet.Status;
        }
    }

    public partial class Category
    {
        public Category()
        {
            
        }
        public Category(string semiColonDelimitedString)
        {
            var category = semiColonDelimitedString.Split(";").ToArray();

            long.TryParse(category[1], out long categoryId);

            this.Name = category[0];
            this.Id = categoryId;
        }
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }

    public partial class Pet
    {
        public static Pet FromJson(string json) => JsonConvert.DeserializeObject<Pet>(json, PetStoreApiTest.ApiHelper.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Pet self) => JsonConvert.SerializeObject(self, PetStoreApiTest.ApiHelper.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
