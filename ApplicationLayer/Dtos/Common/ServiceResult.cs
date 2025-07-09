 

namespace ApplicationLayer.Dtos.Common
{
    public class ServiceResult<T>
    { 
        public bool SuccessOrNot { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }

        public static ServiceResult<T> Success(string message = "", T data = default)
            => new ServiceResult<T> { SuccessOrNot = true, Message = message, Data = data };

        public static ServiceResult<T> Failure(string message, T data = default)
            => new ServiceResult<T> { SuccessOrNot = false, Message = message, Data = data };
    }
}
