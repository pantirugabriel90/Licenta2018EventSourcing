using Domain.Views.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataLayer.Repositories
{
    public class TaskListRepository : IGenericRepository<TaskListElement>
    {
        private ApplicationContext _context;

        public TaskListRepository()
        {
            _context = new ApplicationContext();
        }

        public void Add(TaskListElement entity)
        {
            _context.TaskList.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var taskListToDelete = _context.TaskList.FirstOrDefault(t=>t.Id == id);
            _context.TaskList.Remove(taskListToDelete);
            _context.SaveChanges();

        }

        public IEnumerable<TaskListElement> Get(Expression<Func<TaskListElement, bool>> predicate)
        {
            return _context.TaskList.Where(predicate);
        }

        public IEnumerable<TaskListElement> GetAll()
        {
            return _context.TaskList;
        }

        public TaskListElement GetById(Guid id)
        {
            var taskListElement = _context.TaskList.FirstOrDefault(t => t.Id == id);
            return taskListElement;
        }

        public void Update(TaskListElement entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
