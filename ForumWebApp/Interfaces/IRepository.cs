using System.Threading.Tasks;

namespace ForumWebApp.Interfaces
{
    public interface IRepository<TObject>
    {
        Task<IEnumerable<TObject>> GetAllAsync();
        bool Add(TObject entity);
        bool Update(TObject entity);
        bool Delete(TObject entity);
        bool Save();
    }
    public interface IRepository<TObject, TObjectId> : IRepository<TObject>
    {
        Task<TObject> GetByIdAsync(TObjectId id);

    }
}
