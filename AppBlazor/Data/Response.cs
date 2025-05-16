namespace AppBlazor.Data
{
    public class Response<TEntity>
    {
        public string StatusCode { get; set; } = string.Empty;
        public bool Ok { get; set; }
        public string Message { get; set; } = string.Empty;
        public TEntity? Data { get; set; }
    }
}