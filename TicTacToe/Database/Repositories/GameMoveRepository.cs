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
    public class GameMoveRepository : IBaseRepository<GameMove>
    {
        private readonly AppDbContext _dbContext;

        public GameMoveRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteItem(int id)
        {
            var item = _dbContext.GameMoves.FirstOrDefaultAsync(x => x.Id == id);
            if (item!= null)
            {
                _dbContext.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public Task<GameMove> GetItem(int id)
        {
            return _dbContext.GameMoves.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<GameMove>> GetItems()
        {
            return _dbContext.GameMoves.ToListAsync();
        }

        public Task<List<GameMove>> GetItems(Expression<Func<GameMove, bool>> predicate)
        {
            return _dbContext.GameMoves.Where(predicate).ToListAsync();
        }

        public async Task<GameMove> SaveItem(GameMove item)
        {
            await _dbContext.GameMoves.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task SaveItems(List<GameMove> items)
        {
            await _dbContext.GameMoves.AddRangeAsync(items);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<GameMove> UpdateItem(GameMove item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return item;
        }
    }
}
