
namespace Models.Dto
{
    public class StandarResponseDto
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string ProcessDate { get; set; }
        public object Data { get; set; }
    }
}
