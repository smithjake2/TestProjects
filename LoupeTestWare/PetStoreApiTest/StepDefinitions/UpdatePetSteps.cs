using PetStoreApiTest.ApiHelper;
using PetStoreApiTest.Context;

namespace PetStoreApiTest.StepDefinitions
{
    [Binding]
    public class UpdatePetSteps
    {
        public UpdatePetSteps(ApiContext apiContext, PetContext petContext, ErrorResponseContext errorResponseContext, RequestBuilder builder)
        {
            ApiContext = apiContext;
            PetContext = petContext;
            ErrorResponseContext = errorResponseContext;
            Builder = builder;
        }

        public ApiContext ApiContext { get; }
        public PetContext PetContext { get; }
        public ErrorResponseContext ErrorResponseContext { get; }
        public RequestBuilder Builder { get; }

        [When(@"I call UpdatePetWithForm with the id ""(.*)"" and update name to ""(.*)"" and status to ""(.*)""")]
        public async Task WhenICallUpdatePetWithFormWithTheId(string id, string updatedName, string updatedStatus)
        {
            var response = await ApiContext.UpdatePetWithForm(id, updatedName, updatedStatus);

            ErrorResponseContext.ErrorResponseMessage = response;
        }

        [When(@"I call UpdatePet and update name to ""(.*)"" and status to ""(.*)""")]
        public async Task WhenICallUpdatePetAndUpdateNameToAndStatusTo(string updatedName, string updatedStatus)
        {
            var pet = PetContext.PetsRetrieved.First();

            pet.Name = updatedName;
            pet.Status = updatedStatus;

            var updatedPet = await ApiContext.UpdatePet(pet);
            PetContext.PetUpdated = updatedPet;
        }

        [When(@"I call the update pet endpoint with custom parameters")]
        public async Task WhenICallTheUpdatePetEndpointWithCustomParameters()
        {
            var pet = Builder.Build();
            PetContext.PetToUpdate = pet;

            var updatedPet = await ApiContext.UpdatePet(PetContext.PetToUpdate);
            PetContext.PetUpdated = updatedPet;
        }

    }
}
