using Microsoft.AspNetCore.Mvc.Rendering;
using udemyBloggie.Web.Models.Domain;

namespace udemyBloggie.Web.Models.ViewModels
{
    public class AddBlogPostRequest
    {
        public string Heading { get; set; } //string? is a nullable string property | string? faz com que  a string possa ter valor nulo no campo.

        public string PageTitle { get; set; }

        public string Content { get; set; }

        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Author { get; set; }
        public bool Visible { get; set; }


        // Display tags
        public IEnumerable<SelectListItem> Tags { get; set; }

        // Collect Tag
        public string SelectedTag { get; set; }
    }
}
