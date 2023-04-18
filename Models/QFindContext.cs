using Microsoft.EntityFrameworkCore;

namespace Qfind.Models
{
    public class QFindContext :DbContext
    {
        public QFindContext(DbContextOptions<QFindContext> options)
            : base(options)
        {

        }
        public DbSet<Tickets> TicketsEntity { get; set; } = null!;
    }
}
