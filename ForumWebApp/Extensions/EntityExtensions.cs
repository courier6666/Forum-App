using Microsoft.EntityFrameworkCore;

namespace ForumWebApp.Extensions
{
    public static class EntityExtensions
    {
        public static void ClearDbSet<T> (this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
