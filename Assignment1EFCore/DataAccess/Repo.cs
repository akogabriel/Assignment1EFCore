using Assignment1EFCore;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.DataAccess
{
    public class Repo<T> : IRepo<T> where T : BaseEntity
    {
        private DataContext _context;
        
        public Repo() 
        {
            _context = new DataContext();         
        }

        public void Create(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.Set<T>().Where(x => x.Id == id).First();
            if (item != null) 
            {
                _context.Set<T>().Remove(item);
                _context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Read(int id)
        {
            var item = _context.Set<T>().Where(x =>x.Id == id).First();
            return item;
        }

        public void Update(T item)
        {
            var foundItem = _context.Set<T>().Where(x => x.Id == item.Id).First();
            if (foundItem != null) 
            {
                foreach(var property in foundItem.GetType().GetProperties()) 
                {
                    var value = property.GetValue(item);
                    property.SetValue(foundItem, value);
                }

                foundItem = item;
                _context.SaveChanges();
            }
        }
    }
}
