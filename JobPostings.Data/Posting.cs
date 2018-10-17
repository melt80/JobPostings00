using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPostings.Data
{
    public class Posting
    {
        [Required]
        [Key]
        public int PostingID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTimeOffset CreatedDateUtc { get; set; }
        [Required]
        public DateTimeOffset ExpirationDateUtc { get; set; }
        //public int LowBidID { get; set; }
        public DateTimeOffset? ModifiedDateUtc { get; set; }
        [Required]
        public bool PostingStatus { get; set; }
        [Required]
        public string PositionType { get; set; }
        [Required]
        public string HiringManager { get; set; }
        [Required]
        public bool Urgent { get; set; }
     
    }
}
