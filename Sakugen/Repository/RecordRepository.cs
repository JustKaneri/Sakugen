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
        private readonly IRecordImageRepositroy _imageRepositroy;

        public RecordRepository(DataContext context, IRecordImageRepositroy imageRepositroy)
        {
            _context = context;
            _imageRepositroy = imageRepositroy;
        }

        public async Task<RecordDto> CreateRecord(string url)
        {
            Record record = new Record();

            record.Url = url;
            record.Token = GenereteToken();
            record.CodePath = await _imageRepositroy.CreateImages(ApplicationConfig.Url + "//" + record.Token);

            try
            {
                _context.Records.Add(record);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _imageRepositroy.Remove(record.CodePath);
                return null;
            }

            return new RecordDto()
            {
                Id = record.Id,
                Token = record.Token,
                Url = url
            };
        }

        private string GenereteToken()
        {
            return  Guid.NewGuid().ToString().Replace("+", string.Empty).Substring(0, 8);
        }
    }
}
