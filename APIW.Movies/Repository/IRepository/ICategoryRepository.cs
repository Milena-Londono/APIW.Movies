using APIW.Movies.DAL.Models;

namespace APIW.Movies.Repository.IRepository
{
    public interface ICategoryRepository
    {

        Task<ICollection<Category>> GetCategoriesAsync();//Me retorna UNA LISTA DE CATEGORIAS
        Task<Category> GetCategoryAsync(int id);//Me retorna UNA CATEGORIA POR ID
        Task<bool> CategoryExistsByIdAsync(int id);//Me dice si existe UNA CATEGORIA POR ID
        Task<bool> CategoryExistsByNameAsync(string name);//Me dice si existe UNA CATEGORIA POR NOMBRE
        Task<bool> CreateCategoryAsync(Category category);//Me crea UNA CATEGORIA
        Task<bool> UpdateCategoryAsync(Category category);//Me crea UNA CATEGORIA -- puedo actualizar el nombre y la fecha de actualización
        Task<bool> DeleteCategoryAsync(int id);//Me elimina UNA CATEGORIA

    }
}
