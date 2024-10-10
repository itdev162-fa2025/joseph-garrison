using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
 
namespace API.Controllers
{
 
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly DataContext _context;
 
        public PostsController(DataContext context)
        {
            _context = context;
        }
 
        [HttpGet(Name = "GetPosts")]
        public ActionResult<List<Post>> Get()
        {
            return this._context.Posts.ToList();
        }
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<Post> GetById(Guid id)
        {
            var post = this._context.Posts.Find(id);
            if (post is null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        ///<summary>
        ///POST api/post
        ///</summary>
        ///<param name= "request">JSON request containing post fields</param>
        ///<return>A new post</returns>
        [HttpPost(Name = "Create")]
        public ActionResult<Post> Create([FromBody]Post request)
        {
            var post = new Post
            {
                Id = request.Id,
                Title = request.Title,
                Body = request.Body,
                Date = request.Date
            };

            _context.Posts.Add(post);
            var success = _context.SaveChanges() > 0;

            if (success)
            {
                return Ok(post);
            }

            throw new Exception("Error creating post");
        }
    
    }

}