using System.Net;
using System.Text.Json.Serialization;

namespace Tabibi.Domain.Shared.Results
{
    public sealed class Result<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string? Error { get; set; }
        public T? Data { get; set; }

        [JsonConstructor]
        internal Result()
        {

        }

        public static implicit operator Result<T>(T value)
            => Result.Success(value);

        // Add implicit operator to convert from (HttpStatusCode, string) tuple to Result<T>
        public static implicit operator Result<T>((HttpStatusCode code, string error) error)
            => Result.Custom<T>(default, error.code, false, error.code.ToString(), error.error);

        // Add implicit operator to convert from string (error message) to Result<T>
        public static implicit operator Result<T>(string error)
            => Result.BadRequest<T>(error);

    }

    public static class Result
    {
        public static (HttpStatusCode, string) NotFound(string? error = null)
            => (HttpStatusCode.NotFound, error ?? "NotFound");

        public static Result<T> Success<T>(T data)
        {
            return new Result<T>()
            {
                Data = data,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Successfully",
                Error = null
            };
        }
        public static Result<T> Created<T>(T data)
        {
            return new Result<T>()
            {
                Data = data,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created Successfully",
                Error = null
            };
        }

        public static Result<T> Deleted<T>()
        {
            return new Result<T>()
            {
                Data = default(T),
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Deleted Successfully",
                Error = null
            };
        }
        public static Result<T> Unauthorized<T>(string? error)
        {
            return new Result<T>()
            {
                Data = default(T),
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = "Unauthorized",
                Error = error
            };
        }
        public static Result<T> BadRequest<T>(string? error)
        {
            return new Result<T>()
            {
                Data = default(T),
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = "there is some problems",
                Error = error
            };
        }
        public static Result<T> UnprocessableEntity<T>(string? error)
        {
            return new Result<T>()
            {
                Data = default(T),
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = "UnprocessableEntity",
                Error = error
            };
        }

        public static Result<T> Custom<T>(T? data, HttpStatusCode statusCode, bool succeeded, string message, string? error)
        {
            return new Result<T>()
            {
                Data = data,
                StatusCode = statusCode,
                Succeeded = succeeded,
                Message = message,
                Error = error
            };
        }
    }
}
