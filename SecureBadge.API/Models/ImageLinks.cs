using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace SecureBadge.API.Models
{
    public static class ImageLinks
    {
        public const string ImageUrl1 =
            "https://imagedelivery.net/k29iTJbNMSP-ufIO1H7_Zg/e720d04e-8d23-4015-b9cd-32cfd9133300/public";
        public const string ImageUrl2 =
            "https://imagedelivery.net/k29iTJbNMSP-ufIO1H7_Zg/a8dab530-595c-49e3-6b3c-dfe381f03600/public";

        public const string ImageUrl3 =
            "https://imagedelivery.net/k29iTJbNMSP-ufIO1H7_Zg/478c92d1-f678-4e3f-be85-fd982a9cf400/public";


        public static string RandomImageFile(int number)
        {
            switch (number)
            {
                case 0:return ImageUrl1;
                case 1:return ImageUrl2;
                case 2:return ImageUrl3;
                
            }
            return ImageUrl1;
        }
    }
}
