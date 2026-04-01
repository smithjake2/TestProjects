namespace PetStoreApiTest.ApiHelper
{
    public class ErrorResponseMessage : IApiResponse
    {
        public int? Code { get; set; }
        public string? Type { get; set; }
        public string? Message { get; set; }
    }
}
