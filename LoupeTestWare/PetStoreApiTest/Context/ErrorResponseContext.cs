using PetStoreApiTest.ApiHelper;

namespace PetStoreApiTest.Context
{
    public class ErrorResponseContext
    {
        public ErrorResponseContext(ErrorResponseMessage errorResponseMessage)
        {
            ErrorResponseMessage = errorResponseMessage;
        }

        public ErrorResponseMessage ErrorResponseMessage { get; set; }
    }
}
