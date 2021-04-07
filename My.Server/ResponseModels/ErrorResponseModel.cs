namespace My.Server.ResponseModels
{
    public class ErrorResponseModel
    {       
        public int StatusCode { get; set; }       
        public string Message { get; set; }       
        public string Details { get; set; }
    }
}
