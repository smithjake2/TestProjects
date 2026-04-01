using FluentAssertions;
using FluentAssertions.Execution;
using PetStoreApiTest.ApiHelper;
using PetStoreApiTest.Context;

namespace PetStoreApiTest.StepDefinitions
{
    [Binding]
    public class PetVerificationSteps
    {
        public PetVerificationSteps(PetContext petContext)
        {
            PetContext = petContext;
        }

        public PetContext PetContext { get; }



        [Then(@"The pets returned only have status ""(.*)""")]
        public void ThenThePetsReturnedOnlyHaveStatus(string expectedPetStatus)
        {
            using (new AssertionScope())
            {
                foreach (var pet in PetContext.PetsRetrieved)
                {
                    pet.Status.Should().Be(expectedPetStatus);
                }
            }
        }

        [Then(@"The updated pet returned only has Name ""(.*)""")]
        public void ThenTheUpdatedPetReturnedOnlyHasName(string updatedName)
        {
            var updatedPet = PetContext.PetsRetrieved.Last();

            updatedPet.Name.Should().Be(updatedName);
        }

        [Then(@"The updated pet returned only has status ""(.*)""")]
        public void ThenTheUpdatedPetReturnedOnlyHasStatus(string updatedStatus)
        {
            var updatedPet = PetContext.PetsRetrieved.Last();

            updatedPet.Status.Should().Be(updatedStatus);
        }


        [Then(@"There are exactly (.*) pets returned")]
        [Then(@"There is exactly (.*) pet returned")]
        public void ThenThereIsExactlyPetReturned(int expectedPetCount)
        {
            PetContext.PetsRetrieved.Count.Should().Be(expectedPetCount);
        }


        [Then(@"There are pets returned with (the multiple status options of "".*"")")]
        public void ThenThereArePetsReturnedWithTheMultipleStatusOptionsOf(List<string> expectedAcceptableStatuses)
        {
            using (new AssertionScope())
            {
                foreach (var pet in PetContext.PetsRetrieved)
                {
                    pet.Status.Should().ContainAny(expectedAcceptableStatuses);
                }
            }
        }

        [Then(@"There are no pets returned outside of (the multiple status options of "".*"")")]
        public void ThenThereAreNoPetsReturnedOutsideOfTheMultipleStatusOptionsOf(List<string> expectedAcceptableStatuses)
        {
            var unexpectedPets = PetContext.PetsRetrieved.Where(p => !expectedAcceptableStatuses.Contains(p.Status)).ToList();

            unexpectedPets.Should().BeEmpty();
        }

        [Then(@"The pets returned only have tag ""(.*)""")]
        public void ThenThePetsReturnedOnlyHaveTag(string expectedPetTag)
        {
            using (new AssertionScope())
            {
                foreach (var pet in PetContext.PetsRetrieved)
                {
                    pet.Tags?[0].Name.Should().Be(expectedPetTag);
                }
            }
        }

        [Then(@"There are pets returned with (the multiple tag options of "".*"")")]
        public void ThenThereArePetsReturnedWithTheMultipleTagOptionsOf(List<string> expectedAcceptableTags)
        {
            using (new AssertionScope())
            {
                foreach (var pet in PetContext.PetsRetrieved)
                {
                    pet.Tags[0].Name.Should().ContainAny(expectedAcceptableTags);
                }
            }
        }

        [Then(@"There are no pets returned outside of (the multiple tag options of "".*"")")]
        public void ThenThereAreNoPetsReturnedOutsideOfTheMultipleTagOptionsOf(string expectedAcceptableTags)
        {
            var unexpectedPets = PetContext.PetsRetrieved.Where(p => !expectedAcceptableTags.Contains(p.Tags?[0].Name)).ToList();

            unexpectedPets.Should().BeEmpty();
        }

        [Then(@"There are no pets returned")]
        public void ThenThereAreNoPetsReturned()
        {
            PetContext.PetsRetrieved.Should().BeEmpty();
        }

        [Then(@"The newly created Pet matches the request")]
        public void ThenTheNewlyCreatedPetMatchesTheRequest()
        {
            var actualNewlyCreatedPetFromServer = PetContext.PetAdded;
            var expectedPet = PetContext.PetToAdd;

            VerifyPetsAreSame(expectedPet, actualNewlyCreatedPetFromServer);
        }

        [Then(@"The updated Pet matches the request")]
        public void ThenTheUpdatedPetMatchesTheRequest()
        {
            var actualNewlyUpdatedPetFromServer = PetContext.PetUpdated;
            var expectedPet = PetContext.PetToUpdate;

            VerifyPetsAreSame(expectedPet, actualNewlyUpdatedPetFromServer);
        }


        [Then(@"The pets returned only have Name ""(.*)""")]
        public void ThenThePetsReturnedOnlyHaveName(string expectedPetName)
        {
            using (new AssertionScope())
            {
                foreach (var pet in PetContext.PetsRetrieved)
                {
                    pet.Name.Should().Be(expectedPetName);
                }
            }
        }

        private void VerifyPetsAreSame(Pet expected, Pet actual)
        {
            using (new AssertionScope())
            {
                expected.Id.Should().Be(actual.Id);
                expected.Name.Should().Be(actual.Name);


                foreach (var photoUrl in expected.PhotoUrls)
                {
                    actual.PhotoUrls.Should().Contain(photoUrl);
                }

                expected.Status.Should().Be(actual.Status);
                
                expected.Category.Id.Should().Be(actual.Category.Id);
                expected.Category.Name.Should().Be(actual.Category.Name);

                foreach (var tag in expected.Tags)
                {
                    actual.Tags.Should().Contain(f => f.Id == tag.Id && f.Name == tag.Name);
                }
            }
        }
    }
}
