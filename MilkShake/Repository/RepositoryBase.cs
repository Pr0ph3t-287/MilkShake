using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkShake.Data;
using MilkShake.Models;
using MilkShake.UnitOfWork;

namespace MilkShake.Repository
{
    public abstract class RepositoryBase<T> : ControllerBase, IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected DbSet<T> dbSet;
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            dbSet = _unitOfWork.Context.Set<T>();
        }

        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return Ok(await dbSet.ToListAsync());
        }

        public async Task<ActionResult<T>> GetById(int id)
        {
            return Ok(await dbSet.FindAsync(id));
        }

        public async Task<ActionResult<T>> Create(T entity)
        {
            dbSet.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IActionResult> Update(int id, T entity)
        {
            //if (id != entity.Id)
            //{
            //    return BadRequest();
            //}

            var existing = await dbSet.FindAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            _unitOfWork.Context.Entry(existing).CurrentValues.SetValues(entity);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await dbSet.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            dbSet.Remove(data);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
