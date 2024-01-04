using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Retete.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        [Display(Name = "Retete")]
        public string Title { get; set; }

        public string Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public ICollection<RecipeCategory>? RecipeCategories { get; set; }

    }
}
