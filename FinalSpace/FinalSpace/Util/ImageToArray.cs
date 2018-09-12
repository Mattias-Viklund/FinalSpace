using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace FinalSpace.Util
{
    class ImageToArray
    {
        public static byte[] ImageToByteArray(Image imageIn)
        {
            ImageConverter converter = new ImageConverter();

            byte[] xbyte = (byte[])converter.ConvertTo(imageIn, typeof(byte[]));
            return xbyte;

        }
    }
}
