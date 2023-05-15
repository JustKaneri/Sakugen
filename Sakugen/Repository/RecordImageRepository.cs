using Sakugen.Interface;

namespace Sakugen.Repository
{
    public class RecordImageRepository : IRecordImageRepositroy
    {
        public Task<string> CreateImages(string url)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetImages()
        {
            throw new NotImplementedException();
        }

        public void Remove(string path)
        {
            string fullPatch = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path);

            if (File.Exists(fullPatch))
                File.Delete(fullPatch);
        }
    }
}
