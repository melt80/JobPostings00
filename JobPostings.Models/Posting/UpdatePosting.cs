using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPostings.Models.Posting
{
    public class UpdatePosting
    {
        public int PostingID { get; set; }
        public string Title { get; set; }
        public DateTimeOffset ExpirationDateUtc { get; set; }
        //public int LowBidID { get; set; }
        public bool PostingStatus { get; set; }
        public string PositionType { get; set; }
        public string HiringManager { get; set; }
        public bool Urgent { get; set; }
    }
}
