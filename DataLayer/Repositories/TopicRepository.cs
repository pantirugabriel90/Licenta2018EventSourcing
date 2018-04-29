using Domain.ContextEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataLayer.Repositories
{
    public class TopicRepository:IGenericRepository<Topic>
    {
        private ApplicationContext _context;

        public TopicRepository()
        {
            _context = new ApplicationContext();
        }

        public void Add(Topic entity)
        {
            _context.Topics.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var topicToDelete = _context.Topics.FirstOrDefault(t => t.Id == id);
            _context.Topics.Remove(topicToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<Topic> Get(Expression<Func<Topic, bool>> predicate)
        {
            return _context.Topics.Where(predicate);
        }

        public IEnumerable<Topic> GetAll()
        {
            return _context.Topics;
        }

        public Topic GetById(Guid id)
        {
            var topic = _context.Topics.FirstOrDefault(t => t.Id == id);
            return topic;
        }

        public void Update(Topic entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
