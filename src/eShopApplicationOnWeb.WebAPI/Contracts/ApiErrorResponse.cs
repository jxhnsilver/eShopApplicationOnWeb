namespace eShopApplicationOnWeb.WebAPI.Contracts
{
    public class ApiErrorResponse
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
