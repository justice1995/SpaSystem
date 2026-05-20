namespace Auth.Api.Common
{
    public class APISuccessReponse<T>
    {
        public bool Success => true;
        public T Data { get; }
        public APISuccessReponse(T data)
        {
            Data = data;
        }
    }
}
