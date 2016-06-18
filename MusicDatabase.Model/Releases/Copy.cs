using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public class Copy : TaggedEntity
    {
        #region Properties
        public virtual Release Release { get; set; }
        public virtual ICollection<Element> Elements { get; set; }

        // Acquisition Details
        public virtual AcquisitionDetails AcquisitionDetails { get; set; }             

        // Copy Information
        public string Notes { get; set; }       // Copy specific information
        public string OldNotes { get; set; }    // Notes from the original database

        // Additional Descriptive Tags
        public bool IsSecondhand { get { return HasTag(Model.Constants.COPY_TAG_SECONDHAND); } }
        public bool IsPledgeItem { get { return HasTag(Model.Constants.COPY_TAG_PLEDGE_ITEM); } }
        public bool IsRecordStoreDayItem { get { return HasTag(Model.Constants.COPY_TAG_RECORD_STORE_DAY_ITEM); } }
                
        // Additional Payment Option Tags
        public bool IsGiftVoucherPurchase { get { return HasTag(Model.Constants.COPY_TAG_GIFT_VOUCHER_PURCHASE); } }
        public bool IsBirthdayMoneyPurchase { get { return HasTag(Model.Constants.COPY_TAG_BIRTHDAY_MONEY_PURCHASE); } }
        public bool IsXmasMoneyPurchase { get { return HasTag(Model.Constants.COPY_TAG_XMAS_MONEY_PURCHASE); } }

        // Item was removed from collection (Rare, but has happened!)
        public bool Removed { get; set; }
        public DateTime? RemovedDate { get; set; }
        public string RemovalNotes { get; set; }
        #endregion

        #region Constructors
        public Copy()
            : this("")
        {

        }

        public Copy(string notes)
            : this (null, notes)
        {

        }

        public Copy(AcquisitionDetails acquisitionDetails, string notes)
        {
            AcquisitionDetails = acquisitionDetails;
            Notes = notes;

            Tags = new List<Tag>();
            Elements = new List<Element>();
        }
        #endregion
    }
}
