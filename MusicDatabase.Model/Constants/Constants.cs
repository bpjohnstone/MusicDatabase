using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public class Constants
    {
        // Release - Type Tags
        public static string RELEASE_TAG_COMPILATION { get { return "Compilation"; } }
        public static string RELEASE_TAG_LIVE { get { return "Live"; } }
        public static string RELEASE_TAG_REMIXES { get { return "Remixes"; } }
        public static string RELEASE_TAG_SOUNDTRACK { get { return "Soundtrack"; } }

        // Copy - Type Tags
        public static string COPY_TAG_SECONDHAND { get { return "Secondhand"; } }
        public static string COPY_TAG_PLEDGE_ITEM { get { return "Pledge Item"; } }
        public static string COPY_TAG_RECORD_STORE_DAY_ITEM { get { return "Record Store Day Item"; } }

        // Copy - Purchase Tags
        public static string COPY_TAG_GIFT_VOUCHER_PURCHASE { get { return "Gift Voucher"; } }
        public static string COPY_TAG_BIRTHDAY_MONEY_PURCHASE { get { return "Birthday Money"; } }
        public static string COPY_TAG_XMAS_MONEY_PURCHASE { get { return "Xmas Money"; } }

        // Onsale
        // ...maybe?

        // Currency 
        // ...maybe?
    }
}
