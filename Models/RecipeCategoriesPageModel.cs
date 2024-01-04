using Microsoft.AspNetCore.Mvc.RazorPages;
using Retete.Data;

namespace Retete.Models
{
    public class RecipeCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(ReteteContext context,
        Recipe recipe)
        {
            var allCategories = context.Category;
            var recipeCategories = new HashSet<int>(
            recipe.RecipeCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = recipeCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateBookCategories(ReteteContext context,
        string[] selectedCategories, Recipe recipeToUpdate)
        {
            if (selectedCategories == null)
            {
                recipeToUpdate.RecipeCategories = new List<RecipeCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (recipeToUpdate.RecipeCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        recipeToUpdate.RecipeCategories.Add(
                        new RecipeCategory
                        {
                            RecipeID = recipeToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        RecipeCategory courseToRemove
                        = recipeToUpdate
                        .RecipeCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
