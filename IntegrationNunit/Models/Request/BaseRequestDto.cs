namespace NunitTests.Models.Request
{
    public class BaseRequestDto
    {
        public string TestcaseName { get; set; }

        public dynamic Expected { get; set; }
    }
}