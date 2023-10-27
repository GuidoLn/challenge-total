namespace challenge_total.Utilities
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? MsjExito { get; set; }
        public string[]? MsjError { get; set; }
        public object? Data { get; set; }

        public ApiResponse(int statusCode, string? msjExito = null, string[]? msjError = null, object? data = null)
        {
            this.StatusCode = statusCode;
            this.MsjExito = msjExito;
            this.MsjError = msjError;
            this.Data = data;
        }
    }
}
