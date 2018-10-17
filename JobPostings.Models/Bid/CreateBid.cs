using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPostings.Models.Bid
{
    class CreateBid
    {
        public string BidTitle { get; set; }

        public string BidCompany { get; set; }

        public decimal BidPrice { get; set; }

        public int BidNumberResources { get; set; }

    }
}
