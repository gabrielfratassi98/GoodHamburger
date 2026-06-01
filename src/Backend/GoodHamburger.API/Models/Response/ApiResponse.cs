namespace GoodHamburger.API.Models.Response
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public static ApiResponse<T> Ok(string message = "Success", T? data = default)
            => new ApiResponse<T> { Success = true, Message = message, Data = data };

        public static ApiResponse<T> Error(string message = "Failure", T? data = default)
            => new ApiResponse<T> { Success = false, Message = message, Data = data };
    }
}
