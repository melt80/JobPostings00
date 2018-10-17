using JobPostings.Data;
using JobPostings.Models;
using JobPostings.Models.Posting;
using JobPostings.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPostings.Services
{
    public class PostingService
    {
        private readonly Guid _userId;

        public PostingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePosting(CreatePosting model)
        {
            var entity =
                new Posting()
                {
                    OwnerID = _userId,
                    Title = model.Title,
                    CreatedDateUtc = DateTimeOffset.Now,
                    ExpirationDateUtc = model.ExpirationDateUtc,
                    PostingStatus = model.PostingStatus,
                    PositionType = model.PositionType,
                    HiringManager = model.HiringManager,
                    Urgent = model.Urgent
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Postings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ListItemPosting> GetPostings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Postings
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new ListItemPosting
                                {
                                    PostingId = e.PostingID,
                                    Title = e.Title,
                                    CreatedDateUtc = e.CreatedDateUtc,
                                    PostingStatus = e.PostingStatus,
                                    Urgent = e.Urgent,
                                    HiringManager = e.HiringManager
                                }
                        );
                return query.ToArray();
            }

        }

        public DetailPosting GetPostingById(int postingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Postings
                        .Single(e => e.PostingID == postingId && e.OwnerID == _userId);
                return
                    new DetailPosting
                    {
                        PostingID = entity.PostingID,
                        Title = entity.Title,
                        CreatedDateUtc = entity.CreatedDateUtc,
                        ModifiedDateUtc = entity.ModifiedDateUtc,
                        PostingStatus = entity.PostingStatus,
                        PositionType = entity.PositionType,
                        HiringManager = entity.HiringManager,
                        Urgent = entity.Urgent
                    };
            }

        }

        public bool UpdatePosting(UpdatePosting model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Postings
                        .Single(e => e.PostingID == model.PostingID && e.OwnerID == _userId);

                entity.Title = model.Title;
                entity.ExpirationDateUtc = model.ExpirationDateUtc;
                entity.ModifiedDateUtc = DateTimeOffset.UtcNow;
                entity.PostingStatus = model.PostingStatus;
                entity.PositionType = model.PositionType;
                entity.HiringManager = model.HiringManager;
                entity.Urgent = model.Urgent;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeletePosting(int postingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Postings
                        .Single(e => e.PostingID == postingId && e.OwnerID == _userId);

                ctx.Postings.Remove(entity);

                return ctx.SaveChanges() == 1;

            }

        }
    }
}
