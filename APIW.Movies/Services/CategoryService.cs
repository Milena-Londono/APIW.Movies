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

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateUpdateDto categoryCreateDto)
        {
            //Validar si la categoria ya existe
            var categoryExists = await _categoryRepository.CategoryExistsByNameAsync(categoryCreateDto.Name);

            if (categoryExists)
            {
                throw new InvalidOperationException ($"Ya existe una categoria con el nombre de ''{categoryCreateDto.Name}'");
            }

            //Mapear el DTO a la entidad
            var category = _mapper.Map<Category>(categoryCreateDto);

            //Crear la categoria en el repositorio
            var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new Exception("Ocurrió un error al crear la categoria.");
            }

            //Mapear la entidad creada a un DTO
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            //Verificar si la categoría existe
            var categoryExists = await _categoryRepository.GetCategoryAsync(id);

            if (categoryExists == null)
            {
                throw new InvalidOperationException($"No se encontró la categoría con ID: '{id}'");
            }

            //Eliminar la categoría del repositorio
            var categoryDeleted = await _categoryRepository.DeleteCategoryAsync(id);

            if (!categoryDeleted) 
            {
                throw new Exception("Ocurrió un error al eliminar la categoría.");
            }

            return categoryDeleted;
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

          if (category == null)
            {
                throw new InvalidOperationException($"No se encontró la categoría con ID: '{id}'");
            }

            //Mapear toda la colección de una vez
            return _mapper.Map<CategoryDto>(category); 
        }

        public async Task<CategoryDto> UpdateCategoryAsync(CategoryCreateUpdateDto dto, int id)
        {
            //Validar si la categoria ya existe
            var categoryExists = await _categoryRepository.GetCategoryAsync(id);

            if (categoryExists == null)
            {
                throw new InvalidOperationException($"No se encontró la categoría con ID: '{id}'");
            }

            var nameExists = await _categoryRepository.CategoryExistsByNameAsync(dto.Name);

            if (nameExists)
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre de ''{dto.Name}'");
            }

            //Mapear el DTO a la entidad
            _mapper.Map(dto, categoryExists);

           //Actualizar la categoria en el repositorio
            var categoryUpdated = await _categoryRepository.UpdateCategoryAsync(categoryExists);
            if (!categoryUpdated)
            {
                throw new Exception("Ocurrió un error al actualizar la categoria.");
            }
            //Retornar el DTO actualizado
            return _mapper.Map<CategoryDto>(categoryExists);
        }


    }
}
