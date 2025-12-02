using APIW.Movies.DAL.Models;
using APIW.Movies.DAL.Models.Dtos;
using APIW.Movies.Repository.IRepository;
using APIW.Movies.Services.IServices;
using AutoMapper;

namespace APIW.Movies.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
         }

        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
             throw new NotImplementedException();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryDto)
        {
            throw new NotImplementedException();
    }

      public async Task<bool> DeleteCategoryAsync(int id)
      {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
{
            //Estoy llamando el metodo desde la capa repository
            var categories = await _categoryRepository.GetCategoriesAsync();

            //Mapeo la lista de categorias
            return _mapper.Map<ICollection<CategoryDto>>(categories);
        }


        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            //Obtener la categoria del repositorio
            var category = await _categoryRepository.GetCategoryAsync(id);

            //Mapear toda la colección de una vez
            return _mapper.Map<CategoryDto>(category); 
        }
        
        public Task<CategoryDto> UpdateCategoryAsync(int id, Category categoryDto)
  {
            throw new NotImplementedException();
        }

        
 }
}
