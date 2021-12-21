using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieViewerTest.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Models
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MovieFoundByIMDbID> MoviesFoundByIMDbID { get; set; }
        public DbSet<MovieFoundByTitle> MoviesFoundByTitle { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<MovieSearchedByTitleResult> MovieSearchedByTitleResults { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }

    public interface IDataContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbSet<MovieFoundByIMDbID> MoviesFoundByIMDbID { get; set; }
        DbSet<MovieFoundByTitle> MoviesFoundByTitle { get; set; }
        DbSet<Query> Queries { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<MovieSearchedByTitleResult> MovieSearchedByTitleResults { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
