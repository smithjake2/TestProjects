using PetStoreApiTest.ApiHelper;

namespace PetStoreApiTest.Context
{
    public class PetContext
    {
        public PetContext()
        {
            PetsRetrieved = new List<Pet>();
        }

        public void AddPets(IEnumerable<Pet> pets)
        {
            foreach (var pet in pets)
            {
                PetsRetrieved.Add(pet);
            }
        }

        public void AddToPetsRetrieved(Pet pet)
        {
            PetsRetrieved.Add(pet);
        }

        public void ClearPetsRetrieved()
        {
            PetsRetrieved?.Clear();
        }

        public IList<Pet> PetsRetrieved { get; }

        public Pet PetToAdd { get; set; }

        public Pet PetAdded { get; set; }

        public Pet PetToUpdate { get; set; }

        public Pet PetUpdated { get; set; }
    }
}
