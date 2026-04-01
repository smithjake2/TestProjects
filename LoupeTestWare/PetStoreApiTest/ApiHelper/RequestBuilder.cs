namespace PetStoreApiTest.ApiHelper
{
    public class RequestBuilder
    {
        private Pet _pet;

        public RequestBuilder()
        {
            _pet = new Pet();
        }

        public RequestBuilder WithName(string? name)
        {
            _pet.Name = name;
            return this;
        }

        public RequestBuilder WithId(long id)
        {
            _pet.Id = id;
            return this;
        }

        public RequestBuilder WithPhotoUrls(string[]? photoUrls)
        {
            _pet.PhotoUrls = photoUrls;
            return this;
        }

        public RequestBuilder WithCategory(Category? category)
        {
            _pet.Category = category;
            return this;
        }

        public RequestBuilder WithCategory(long id, string? name)
        {
            return this.WithCategory(new Category { Id = id, Name = name });
        }

        public RequestBuilder WithStatus(string? status)
        {
            _pet.Status = status;
            return this;
        }

        public RequestBuilder WithTags(Category[]? tags)
        {
            _pet.Tags = tags;
            return this;
        }

        public RequestBuilder WithTags(long id, string? name)
        {
            return this.WithTags(new Category[] { new Category { Id = id, Name = name } });
        }

        public Pet Build()
        {
            return new Pet
            {
                Name = _pet.Name,
                Id = _pet.Id,
                PhotoUrls = _pet.PhotoUrls,
                Category = _pet.Category,
                Status = _pet.Status,
                Tags = _pet.Tags
            };
        }
    }
}
