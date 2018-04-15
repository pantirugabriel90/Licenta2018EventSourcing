using Domain.Views.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataLayer.Repositories
{
    public class TopicListRepository:IGenericRepository<TopicListElement>
    {
        private ApplicationContext _context;

        public TopicListRepository()
        {
            _context = new ApplicationContext();
        }

        public void Add(TopicListElement entity)
        {
            _context.TopicList.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var topicListElementToDelete = _context.TopicList.FirstOrDefault(t => t.Id == id);
            _context.TopicList.Remove(topicListElementToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<TopicListElement> Get(Expression<Func<TopicListElement, bool>> predicate)
        {
            return _context.TopicList.Where(predicate);
        }

        public IEnumerable<TopicListElement> GetAll()
        {
            return _context.TopicList;
        }

        public TopicListElement GetById(Guid id)
        {
            var topicListElement = _context.TopicList.FirstOrDefault(t => t.Id == id);
            return topicListElement;
        }

        public void Update(TopicListElement entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
