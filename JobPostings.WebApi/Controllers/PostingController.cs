using JobPostings.Models;
using JobPostings.Models.Posting;
using JobPostings.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobPostings.WebApi.Controllers
{
    [Authorize]
    public class PostingController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            PostingService postingService = CreatePostingService();
            var postings = postingService.GetPostings();
            return Ok(postings);
        }

        public IHttpActionResult Get(int id)
        {
            PostingService postingService = CreatePostingService();
            var posting = postingService.GetPostingById(id);
            return Ok(posting);
        }

        public IHttpActionResult Post(CreatePosting posting)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostingService();

            if (!service.CreatePosting(posting))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(UpdatePosting posting)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostingService();

            if (!service.UpdatePosting(posting))
                return InternalServerError();

            return Ok();

        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostingService();

            if (!service.DeletePosting(id))
                return InternalServerError();

            return Ok();

        }

        private PostingService CreatePostingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postingService = new PostingService(userId);
            return postingService;
        }

    }
}
