using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using udemyBloggie.Web.Data;
using udemyBloggie.Web.Models.Domain;
using udemyBloggie.Web.Models.ViewModels;

namespace udemyBloggie.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BloggieDbContext bloggieDbContext;

        public AdminTagsController(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            //var name = Request.Form["name"]; //Request para o input da view
            //var displayName = Request.Form["displayName"];

            // Model Binding:
            //var name = addTagRequest.Name;
            //var displayName = addTagRequest.DisplayName;


            //Mapping AddTagRequest to Tagdomain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };


            bloggieDbContext.Tags.Add(tag);
            bloggieDbContext.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public IActionResult List()
        {
            // use dbContext to read the tags.
            var tags = bloggieDbContext.Tags.ToList();


            return View(tags);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            // 1st method
            //var tag = bloggieDbContext.Tags.Find(id);
            
            // 2nd Method
            var tag = bloggieDbContext.Tags.FirstOrDefault(x => x.Id == id);

            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };

                return View(editTagRequest);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(EditTagRequest editTagRequest)
        {
            // Boa prática de verificação.
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName,
            };

            var existingTag = bloggieDbContext.Tags.Find(tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                // Save changes.
                bloggieDbContext.SaveChanges();

                // Show sucess notification.
                return RedirectToAction("List");
            }

            // Show error notification.
            return RedirectToAction("Edit", new { id = editTagRequest.Id });

        }

        [HttpPost]
        public ActionResult Delete(EditTagRequest editTagRequest)
        {
            var tag = bloggieDbContext.Tags.Find(editTagRequest.Id);

            if (tag != null)
            {
                bloggieDbContext.Tags.Remove(tag);
                bloggieDbContext.SaveChanges();

                // Show a succes notification
                return RedirectToAction("List");
            }

            // Show a failure notification
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

    }
}
