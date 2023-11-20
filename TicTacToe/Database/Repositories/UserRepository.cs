using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Database.Model;

namespace TicTacToe.Database.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteItem(int id)
        {
            var item = _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (item!= null) 
            {
                _dbContext.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public Task<User> GetItem(int id)
        {
            return _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<User>> GetItems()
        {
            return _dbContext.Users.ToListAsync();
        }

        public Task<List<User>> GetItems(Expression<Func<User, bool>> predicate)
        {
            return _dbContext.Users.Where(predicate).ToListAsync();
        }

        public async Task<User> SaveItem(User item)
        {
            await _dbContext.Users.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task SaveItems(List<User> items)
        {
            await _dbContext.Users.AddRangeAsync(items);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> UpdateItem(User item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return item;
        }
    }
}
