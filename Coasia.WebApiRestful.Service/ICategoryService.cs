using Coasia.WebApiRestful.Domain.Entitys;

namespace Coasia.WebApiRestful.Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Categories>> GetCategories();
        Task Insert(Categories categories);
    }
}