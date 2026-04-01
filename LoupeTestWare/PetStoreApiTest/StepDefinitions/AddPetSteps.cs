using PetStoreApiTest.ApiHelper;
using PetStoreApiTest.Context;

namespace PetStoreApiTest.StepDefinitions
{
    [Binding]
    public class AddPetSteps
    {
        public AddPetSteps(ApiContext apiContext, PetContext petContext, RequestBuilder builder)
        {
            ApiContext = apiContext;
            PetContext = petContext;
            Builder = builder;
        }

        public ApiContext ApiContext { get; }
        public PetContext PetContext { get; }
        public RequestBuilder Builder { get; }

        [Given(@"I have the add pet endpoint with the following parameters")]
        public void GivenIHaveTheAddPetEndpointWithTheFollowingParameters(Pet pet)
        {
            PetContext.PetToAdd = pet;
        }

        [Given(@"I give the Pet the Name ""(.*)""")]
        public void GivenIGiveThePetTheName(string name)
        {
            Builder.WithName(name);
        }

        [Given(@"I give the Pet the PhotoUrls ""(.*)""")]
        public void GivenIGiveThePetThePhotoUrls(string photoUrls)
        {
            Builder.WithPhotoUrls(new[] { photoUrls });
        }

        [Given(@"I give the Pet the Category ""(.*)""")]
        public void GivenIGiveThePetTheCategory(string categoryString)
        {
            Builder.WithCategory(new Category(categoryString));
        }

        [Given(@"I give the Pet the Tags ""(.*)""")]
        public void GivenIGiveThePetTheTags(string tagString)
        {
            Builder.WithTags(new Category[] { new(tagString) });
        }

        [Given(@"I give the Pet the Status ""(.*)""")]
        public void GivenIGiveThePetTheStatus(string petStatus)
        {
            Builder.WithStatus(petStatus);
        }

        [Given(@"I give the Pet a valid Guid as the Name")]
        public void GivenIGiveThePetAValidGuidAsTheName()
        {
            Builder.WithName(Guid.NewGuid().ToString());
        }

        [Given(@"I give the Pet the Id ""(.*)""")]
        public void GivenIGiveThePetTheId(long id)
        {
            Builder.WithId(id);
        }

        [Given(@"I call the add pet endpoint with custom parameters")]
        [When(@"I call the add pet endpoint with custom parameters")]
        public async Task WhenICallTheAddPetEndpointWithCustomParameters()
        {
            var pet = Builder.Build();
            PetContext.PetToAdd = pet;

            await WhenICallTheAddPetEndpoint();
        }

        [Given(@"I call the add pet endpoint")]
        [When(@"I call the add pet endpoint")]
        public async Task WhenICallTheAddPetEndpoint()
        {
            var addedPet = await ApiContext.AddPet(PetContext.PetToAdd);
            PetContext.PetAdded = addedPet;
        }
    }
}
