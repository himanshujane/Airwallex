namespace Tests.Models.Request
{
    public class BaseRequestDto
    {
        public string _TestName { get; set; }

        public dynamic Expected { get; set; }
    }
}