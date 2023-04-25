using FinanceManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagerAPI.Data {
    public class FinanceManagerDbContext : DbContext {

        public FinanceManagerDbContext(DbContextOptions<FinanceManagerDbContext> options): base(options) { }

        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
