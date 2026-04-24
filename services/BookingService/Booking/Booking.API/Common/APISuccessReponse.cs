namespace BookingSystem.API.Common
{
    public class APISuccessReponse
    {
        public bool Success => true;
    }
    public class APISuccessReponse<T> : APISuccessReponse
    {
        public T Data { get; }
        public APISuccessReponse(T data)
        {
            Data = data;
        }

    }
}
