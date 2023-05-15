namespace Sakugen.Interface
{
    public interface IRecordImageRepositroy
    {
        public Task<string> CreateImages(string url);

        public Task<byte[]> GetImages();

        public void Remove(string path);
    }
}
