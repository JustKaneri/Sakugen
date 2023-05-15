using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sakugen.Dto
{
    public class RecordDto
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string? Url { get; set; }
        public byte[] QrCode { get; set; }
    }
}
