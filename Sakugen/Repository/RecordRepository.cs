using Sakugen.Data;
using Sakugen.Dto;
using Sakugen.Interface;
using Sakugen.Models;
using Sakugen.Other;

namespace Sakugen.Repository
{
    public class RecordRepository : IRecordRepository
    {
        private readonly DataContext _context;
        private readonly IQRCodeRepositroy _codeRepositroy;

        public RecordRepository(DataContext context, IQRCodeRepositroy codeRepositroy)
        {
            _context = context;
            _codeRepositroy = codeRepositroy;
        }

        public async Task<RecordDto> CreateRecord(string url)
        {
            Record record = new Record();

            record.Url = url;
            record.Token = GenereteToken();

            try
            {
                _context.Records.Add(record);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }

            return new RecordDto()
            {
                Id = record.Id,
                Token = ApplicationConfig.Url + "//" + record.Token,
                Url = url,
                QrCode = _codeRepositroy.CreateQRCode(ApplicationConfig.Url + "//" + record.Token)
        };
        }

        private string GenereteToken()
        {
            return  Guid.NewGuid().ToString().Replace("+", string.Empty).Substring(0, 8);
        }
    }
}
