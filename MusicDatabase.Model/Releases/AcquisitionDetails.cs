using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    // A copy can be acquired by a whole bunch of ways, but there are two different types of acquisitions:
    
    // Purchases, which break down into:
    
    // - Bought in a store (StorePurchase)
    // - Bought online (OnlinePurchase)
    // - Bought a concert (EventPurchase)

    // Or stuff that was "Received"
    
    // - Gifts (GiftDetails)
    // - Stuff won in a competition (CompetitionItemDetails)

    // To that effect, there's a whole bunch of classes in this file to implement this kind of structure / detail.
    // Each of the classes adds a bit more properties

    // Of course, this whole thing is pretty ridiculous

    public abstract class AcquisitionDetails : Entity
    {
        #region Properties
        public DateTime? DateAdded { get; set; }
        public string Notes { get; set; }
        #endregion

        #region Constructors
        public AcquisitionDetails()
        {

        }

        public AcquisitionDetails(DateTime? dateAdded, string notes)
        {
            DateAdded = dateAdded;
            Notes = notes;
        }
        #endregion
    }

    public class GiftDetails : AcquisitionDetails
    {
        #region Properties
        public virtual ICollection<Person> From { get; set; }
        public string Occasion { get; set; }
        #endregion

        #region Constructors
        public GiftDetails()
            : base()
        {
            From = new List<Person>();
        }
        #endregion
    }

    public class CompetitionItemDetails : AcquisitionDetails
    {
        #region Properties
        public string Source { get; set; }
        #endregion

        #region Constructors
        public CompetitionItemDetails()
            : base()
        {

        }
        #endregion
    }

    public abstract class PurchaseDetails : AcquisitionDetails
    {
        #region Properties
        public decimal? GrandTotal { get; set; }
        public decimal? MarkedPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? Tax { get; set; }
        #endregion

        #region Constructors
        public PurchaseDetails()
            : base()
        {

        }
        #endregion
    }

    public class StorePurchase : PurchaseDetails
    {
        #region Properties
        public virtual Location PurchaseLocation { get; set; }
        #endregion

        #region Constructors
        public StorePurchase()
            : base()
        {

        }
        #endregion
    }

    public class OnlinePurchase : PurchaseDetails
    {
        #region Properties
        public virtual Website Website { get; set; }
        public decimal? Postage { get; set; }
        public DateTime? PurchaseDate { get; set; }
        #endregion

        #region Constructors
        public OnlinePurchase()
            : base()
        {

        }
        #endregion
    }

    public class EventPurchase : PurchaseDetails
    {
        #region Properties
        public virtual MusicalEvent Event { get; set; }
        #endregion

        #region Constructors
        public EventPurchase()
            : base()
        {

        }
        #endregion
    }
}
