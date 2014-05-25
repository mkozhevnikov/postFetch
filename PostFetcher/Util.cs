using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;

namespace PostFetcher
{
    static class Util
    {
        public static Binary ToBinary(this System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                //TODO передавать правильный формат файла
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return new Binary(ms.ToArray());
            }
        }
        
        public static System.Drawing.Image ToImage(this Binary binary)
        {
            using (var ms = new MemoryStream(binary.ToArray()))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }
    }
}
