using PetStoreApiTest.Context;
using PetStoreApiTest.Exceptions;

namespace PetStoreApiTest.StepDefinitions
{
    [Binding]
    public class FindByStatusSteps
    {
        public FindByStatusSteps(ApiContext apiContext, PetContext petContext)
        {
            ApiContext = apiContext;
            PetContext = petContext;
        }

        public ApiContext ApiContext { get; }
        public PetContext PetContext { get; }

        [Given(@"I call FindByStatus with the status ""(.*)""")]
        public async Task GivenICallFindByStatusWithTheStatus(string status)
        {
            var pets = await ApiContext.FindByStatusAsync(status);
            PetContext.AddPets(pets);
        }

        [When(@"I get the newly created Pet via the Status and unique Name")]
        public async Task WhenIGetTheNewlyCreatedPetViaTheStatusAndUniqueName()
        {
            await GivenICallFindByStatusWithTheStatus(PetContext.PetToAdd.Status);

            var filteredPetsPulledFromServer = PetContext.PetsRetrieved.Where(p => p.Name == PetContext.PetToAdd.Name).ToList();

            if (filteredPetsPulledFromServer.Count !=1)
            {
                throw new InvalidPetCountException($"Found {filteredPetsPulledFromServer} instead of 1");
            }

            PetContext.ClearPetsRetrieved();

            PetContext.PetAdded = filteredPetsPulledFromServer.First();
        }


    }
}
