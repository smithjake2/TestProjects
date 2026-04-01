using PetStoreApiTest.Context;

namespace PetStoreApiTest.StepDefinitions
{
    [Binding]
    public class DeletePetByIdSteps
    {
        public DeletePetByIdSteps(ApiContext apiContext, PetContext petContext, ErrorResponseContext errorResponseContext)
        {
            ApiContext = apiContext;
            PetContext = petContext;
            ErrorResponseContext = errorResponseContext;
        }

        public ApiContext ApiContext { get; }
        public PetContext PetContext { get; }
        public ErrorResponseContext ErrorResponseContext { get; }

        [Given(@"I call DeletePetById with the id ""(.*)""")]
        [When(@"I call DeletePetById with the id ""(.*)""")]
        public async Task WhenICallDeletePetByIdWithTheId(string id)
        {
            var response = await ApiContext.DeletePetById(id);

            ErrorResponseContext.ErrorResponseMessage = response;
        }

        [AfterScenario("DeletePet")]
        public async Task DeletePet()
        {
            if (PetContext.PetAdded != null)
            {
                await WhenICallDeletePetByIdWithTheId(PetContext.PetAdded.Id.ToString());
            }

            if(PetContext.PetUpdated != null)
            {
                await WhenICallDeletePetByIdWithTheId(PetContext.PetUpdated.Id.ToString());
            }
        }
    }
}
