namespace GoodHamburger.Domain.Shared
{
    public class Result
    {
        public bool IsSuccess { get; protected set; }
        public bool IsFailure => !IsSuccess;
        public string Message { get; protected set; } = string.Empty;

        protected Result() { }

        public static Result Success(string message = "")
        {
            return new Result { IsSuccess = true, Message = message };
        }

        public static Result Failure(string message)
        {
            return new Result { IsSuccess = false, Message = message };
        }
    }

    public class Result<T> : Result
    {
        public T? Value { get; private set; }

        private Result() { }

        public static Result<T> Success(T value, string message = "")
        {
            return new Result<T> { IsSuccess = true, Message = message, Value = value };
        }

        public static new Result<T> Failure(string message, T? value = default)
        {
            return new Result<T> { IsSuccess = false, Message = message, Value = value };
        }
    }
}
