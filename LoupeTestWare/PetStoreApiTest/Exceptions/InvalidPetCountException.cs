namespace PetStoreApiTest.Exceptions
{
    public class InvalidPetCountException : Exception
    {
        public InvalidPetCountException(string? message) : base(message)
        {

        }
    }
}
