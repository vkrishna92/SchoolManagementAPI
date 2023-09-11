using System;
using System.Linq.Expressions;
using Core.Common.Interfaces;
using Data.DataAccess;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Data.Common
{
	public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        //This method will return the specified record from the table
        //based on the ID which it received as an argument
        public async Task<T> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        //This method will Insert one object into the table
        //It will receive the object as an argument which needs to be inserted into the database
        public void Insert(T obj)
        {
            //It will mark the Entity state as Added State
            _dbSet.Add(obj);
        }

        //This method is going to update the record in the table
        //It will receive the object as an argument
        public void Update(T obj)
        {
            //First attach the object to the table
            _dbSet.Attach(obj);
            //Then set the state of the Entity as Modified
            _context.Entry(obj).State = EntityState.Modified;
        }

        //This method is going to remove the record from the table
        //It will receive the primary key value as an argument whose information needs to be removed from the table
        public void Delete(object id)
        {
            //First, fetch the record from the table
            T existing = _dbSet.Find(id);
            //This will mark the Entity State as Deleted
            _dbSet.Remove(existing);
        }

        //This method will make the changes permanent in the database
        //That means once we call Insert, Update, and Delete Methods, 
        //Then we need to call the Save method to make the changes permanent in the database
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

