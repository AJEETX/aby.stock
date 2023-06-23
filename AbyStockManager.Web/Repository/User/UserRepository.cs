using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aby.StockManager.Core.Repository;
using Aby.StockManager.Data.Context;
using Aby.StockManager.Repository.Base;

namespace Aby.StockManager.Repository.User
{
    public class UserRepository : Repository<Aby.StockManager.Data.Entity.User>, IUserRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }

        public UserRepository(DbContext context) : base(context)
        {
        }

        public async Task<bool> EmailValidationCreateUser(string email)
        {
            return await dbContext.User.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> EmailValidationUpdateUser(string email, int Id)
        {
            return await dbContext.User.AnyAsync(x => x.Email == email && x.Id != Id);
        }

        public async Task<bool> Login(string email, string password)
        {
            return await dbContext.User.AnyAsync(x => x.Email == email && x.Password == password);
        }

        public async Task DeleteProductImage(int id)
        {
            Aby.StockManager.Data.Entity.User user = await dbContext.User.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                user.Image = null;
                dbContext.Entry(user).Property(f => f.Image).IsModified = true;
            }
        }
    }
}