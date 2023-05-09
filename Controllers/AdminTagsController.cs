using Microsoft.AspNetCore.Mvc;
using udemyBloggie.Web.Models.ViewModels;

namespace udemyBloggie.Web.Controllers
{
    public class AdminTagsController : Controller
    {
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
            var name = addTagRequest.Name;
            var displayName = addTagRequest.DisplayName;

            return View("Add");
        }
    }
}
