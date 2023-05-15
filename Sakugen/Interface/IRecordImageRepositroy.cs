using System.Drawing;

namespace Sakugen.Interface
{
    public interface IQRCodeRepositroy
    {
        public byte[] CreateQRCode(string url);
    }
}
