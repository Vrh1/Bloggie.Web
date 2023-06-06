using Microsoft.AspNetCore.Mvc;
using udemyBloggie.Web.Repositories;

namespace udemyBloggie.Web.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogsController(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string urlHnadle)
        {
            var blogPost = await blogPostRepository.GetByUrlHandleAsync(urlHnadle);

            return View(blogPost);
        }
    }
}
