using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPostings.Models.Bid
{
    class ListItemBid
    {
        public int BidID { get; set; }
        public string BidTitle { get; set; }
        public string BidCompany { get; set; }
        public decimal BidPrice { get; set; }
        public int BidNumberResources { get; set; }
        public DateTimeOffset CreatedDateUtc { get; set; }
    }
}
