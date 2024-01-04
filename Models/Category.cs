namespace Retete.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<RecipeCategory>? RecipeCategories { get; set; }
    }
}