using IronBarCode;
using Sakugen.Interface;

namespace Sakugen.Repository
{
    public class QrCodeRepository : IQRCodeRepositroy
    {
        public byte[] CreateQRCode(string url)
        {
            GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(url, 200);

            return  barcode.ToJpegBinaryData();

        }
    }
}
