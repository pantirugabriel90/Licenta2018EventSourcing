using Domain.ContextEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataLayer.Repositories
{
    public class TaskRepository:IGenericRepository<Task>
    {
        private ApplicationContext _context;

        public TaskRepository()
        {
            _context = new ApplicationContext();
        }

        public void Add(Task entity)
        {
            _context.Tasks.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var taskToDelete = _context.Tasks.FirstOrDefault(t => t.Id == id);
            _context.Tasks.Remove(taskToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<Task> Get(Expression<Func<Task, bool>> predicate)
        {
            return _context.Tasks.Where(predicate);
        }

        public IEnumerable<Task> GetAll()
        {
            return _context.Tasks;
        }

        public Task GetById(Guid id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            return task;
        }

        public void Update(Task entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
