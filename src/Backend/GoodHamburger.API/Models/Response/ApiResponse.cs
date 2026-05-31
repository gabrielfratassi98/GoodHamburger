namespace GoodHamburger.API.Models.Response
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; } = new();

        public static ApiResponse Ok(string message = "Success", object? data = null)
            => new ApiResponse { Success = true, Message = message, Data = data ?? new() };

        public static ApiResponse Error(string message = "Failure", object? data = null)
            => new ApiResponse { Success = false, Message = message, Data = data = new() };
    }
}
