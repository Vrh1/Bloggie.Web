using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using udemyBloggie.Web.Data;
using udemyBloggie.Web.Models.Domain;
using udemyBloggie.Web.Models.ViewModels;
using udemyBloggie.Web.Repositories;

namespace udemyBloggie.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository tagRepository;

        public AdminTagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest) //Ássincrona.
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

            await tagRepository.AddAsync(tag);

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            // use dbContext to read the tags.
            var tags = await tagRepository.GetAllAsync();


            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await tagRepository.GetAsync(id);

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
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            // Boa prática de verificação.
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName,
            };

            var updateTag = await tagRepository.UpdateAsync(tag);

            if (updateTag != null) 
            { 
                // Show sucess
            }
            else
            {
                //show error
            }

            // Show error notification.
            return RedirectToAction("Edit", new { id = editTagRequest.Id });

        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var deleteTag =  await tagRepository.DeleteAsync(editTagRequest.Id);

            if (deleteTag != null)
            {
                //Show sucess notification
                return RedirectToAction("List");
            }

            // Show a failure notification
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

    }
}
