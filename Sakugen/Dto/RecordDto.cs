using System.ComponentModel.DataAnnotations;

namespace Sakugen.Dto
{
    public class RecordDto
    {
        public int Id { get; set; }
        public string Token { get; set; }

        [Url(ErrorMessage = "Некорректный адрес")]
        public string? Url { get; set; }
        public byte[] QrCode { get; set; }
    }
}
