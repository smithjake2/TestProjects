using PetStoreApiTest.ApiHelper;
using PetStoreApiTest.Context;

namespace PetStoreApiTest.StepDefinitions
{
    [Binding]
    public class GetPetByIdSteps
    {
        public GetPetByIdSteps(ApiContext apiContext, PetContext petContext, ErrorResponseContext errorResponseContext)
        {
            ApiContext = apiContext;
            PetContext = petContext;
            ErrorResponseContext = errorResponseContext;
        }

        public ApiContext ApiContext { get; }
        public PetContext PetContext { get; }
        public ErrorResponseContext ErrorResponseContext { get; }

        [Given(@"I call GetPetById with the id ""(.*)"" with success")]
        [When(@"I call GetPetById with the id ""(.*)"" with success")]
        public async Task GivenICallGetPetByIdWithTheIdWithSuccess(string id)
        {
            var response = await ApiContext.GetPetById(id);

            var pet = (Pet)response;

            PetContext.AddToPetsRetrieved(pet);
        }

        [Given(@"I call GetPetById with the id ""(.*)"" with failure")]
        public async Task GivenICallGetPetByIdWithTheIdWithFailure(string id)
        {
            var response = await ApiContext.GetPetById(id);

            var errorResponseMessage = (ErrorResponseMessage)response;

            ErrorResponseContext.ErrorResponseMessage = errorResponseMessage;
        }
    }
}
