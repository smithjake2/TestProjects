using PetStoreApiTest.ApiHelper;

namespace PetStoreApiTest.Conversions
{
    [Binding]
    public class PetConversion
    {

        [StepArgumentTransformation]
        public Pet GetPet(Table table)
        {
            var row = table.Rows.First();
            long.TryParse(row["Id"], out long petId);

            var pet = new Pet()
            {
                Id = petId,
                Name = row["Name"],
                PhotoUrls = new[] { row["PhotoUrls"] },
                Tags = new Category[] { new(row["Tags"]) },
                Status = row["Status"],
                Category = new Category(row["Category"])
            };

            return pet;
        }
    }
}
