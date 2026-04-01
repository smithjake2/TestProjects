using PetStoreApiTest.Context;

namespace PetStoreApiTest.StepDefinitions
{
    [Binding]
    public class FindByTagsSteps
    {
        public FindByTagsSteps(ApiContext apiContext, PetContext petContext)
        {
            ApiContext = apiContext;
            PetContext = petContext;
        }

        public ApiContext ApiContext { get; }
        public PetContext PetContext { get; }

        [Given(@"I call FindByTags with the tag ""(.*)""")]
        public async Task GivenICallFindByTagsWithTheTag(string tag)
        {
            var pets = await ApiContext.FindByTagAsync(tag);
            PetContext.AddPets(pets);
        }

    }
}
