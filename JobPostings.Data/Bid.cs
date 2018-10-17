using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPostings.Data
{
    class Bid
    {
        [Key]
        public int BidID { get; set; }

        [Required]
        public string BidTitle { get; set; }

        [Required]
        public string BidCompany { get; set; }

        [Required]
        public decimal BidPrice { get; set; }

        [Required]
        public int BidNumberResources { get; set; }

        [Required]
        public DateTimeOffset CreatedDateUtc { get; set; }

        public DateTimeOffset? ModifiedDateUtc { get; set; }
    }
}
