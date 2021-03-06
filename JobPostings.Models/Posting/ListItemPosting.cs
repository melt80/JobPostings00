﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPostings.Models.Posting
{
    public class ListItemPosting
    {
        public int PostingId { get; set; }
        public string Title { get; set; }
        public DateTimeOffset CreatedDateUtc { get; set; }
        public bool PostingStatus { get; set; }
        public bool Urgent { get; set; }
        public string HiringManager { get; set; }
    }
}
