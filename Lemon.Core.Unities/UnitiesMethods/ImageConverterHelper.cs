using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace ZilLion.Core.Infrastructure.Unities
{
    public static class ImageConverterHelper
    {
        public static byte[] GetPictureData(string imagepath)
        {
            byte[] byData = null;
            if (!File.Exists(imagepath)) return byData;
            try
            {
                using (var fs = new FileStream(imagepath, FileMode.Open))
                {
                    byData = new byte[fs.Length];
                    fs.Read(byData, 0, byData.Length);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return byData;
        }

        public static BitmapImage ByteArrayToBitmapImage(byte[] byteArray)
        {
            BitmapImage bmp = null;
            try
            {
                bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(byteArray);
                bmp.EndInit();
            }
            catch
            {
                bmp = null;
            }
            return bmp;
        }

        public static byte[] BitmapImageToByteArray(BitmapImage bmp)
        {
            byte[] byteArray = null;
            try
            {
                var sMarket = bmp.StreamSource;
                if (sMarket != null && sMarket.Length > 0)
                {
                    //很重要，因为Position经常位于Stream的末尾，导致下面读取到的长度为0。
                    sMarket.Position = 0;
                    using (var br = new BinaryReader(sMarket))
                    {
                        byteArray = br.ReadBytes((int) sMarket.Length);
                    }
                }
            }
            catch
            {
                //other exception handling
            }
            return byteArray;
        }


        public static Bitmap BitmapSourceToBitmap(BitmapSource image)
        {
            var encoder = new BmpBitmapEncoder();

            using (var memoryStream = new MemoryStream())
            {
               

                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(memoryStream);

                memoryStream.Position = 0;
                var bImg = new Bitmap(memoryStream);
                memoryStream.Close();
                return bImg;
            }
        }

     
      
        public static Icon BitmapToIcon(Bitmap bmp)
        {
            // Create a Bitmap object from an image file.
          
            // Get an Hicon for myBitmap. 
            IntPtr hicon = bmp.GetHicon();
            // Create a new icon from the handle. 
            Icon newIcon = Icon.FromHandle(hicon);

            return newIcon;
        }
    }
}