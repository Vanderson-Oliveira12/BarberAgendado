namespace BarberAgendado.Domain.Models
{
    public class ApiResponse
    {
        public int StatusCode { get; set; } = 0;
        public string Message { get; set; }
        public dynamic Data { get; set; } = null;
        public bool IsSuccess { get; set; }

        public static ApiResponse Success(dynamic data, string message = "Operação efetuada com sucesso", int statusCode = 200, bool IsSuccess = true)
        {
            return new ApiResponse
            {
                Data = data,
                StatusCode = statusCode,
                Message = message,
                IsSuccess = IsSuccess
            };
        }

        public static ApiResponse Error(string message = "Houve um erro na operação", int statusCode = 400)
        {
            return new ApiResponse
            {
                Data = default,
                StatusCode = statusCode,
                Message = message,
                IsSuccess = false
            };
        }
    }
}
