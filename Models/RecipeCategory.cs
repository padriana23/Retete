namespace Retete.Models
{
    public class RecipeCategory
    {
        public int ID { get; set; }
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
