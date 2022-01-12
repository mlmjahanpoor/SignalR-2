namespace SignalR.Api.Model.Commons
{
    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }

    }

    public class ResultDto<T> : ResultDto
    {
        public T? Data { get; set; }
    }
}
