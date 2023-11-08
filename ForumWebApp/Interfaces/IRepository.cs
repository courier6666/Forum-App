using System.Threading.Tasks;

namespace ForumWebApp.Interfaces
{
    public interface IRepository<TObject, TObjectId>
    {
        Task<TObject> GetByIdAsync(TObjectId id);
        Task<IEnumerable<TObject>> GetAllAsync();
        bool Add(TObject entity);
        bool Update(TObject entity);
        bool Delete(TObject entity);
        bool Save();
    }
}
