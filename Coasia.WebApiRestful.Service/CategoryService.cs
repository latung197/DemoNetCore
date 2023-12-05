using Coasia.WebApiRestful.Data.Abstract;
using Coasia.WebApiRestful.Domain.Entitys;

namespace Coasia.WebApiRestful.Service
{
    public class CategoryService : ICategoryService

    {
        IRepository<Categories> _categoryRepository;
        public CategoryService(IRepository<Categories> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Categories>> GetCategories()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task Insert(Categories categories)
        {
             await _categoryRepository.InsertAsync(categories);
            await _categoryRepository.CommitAsync();
        }
    }
}