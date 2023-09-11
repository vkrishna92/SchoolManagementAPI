using System;
using Core.Common.Interfaces;
using Core.StudentModule.Models;
using Data.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Data.Student
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _dataContext;

        public StudentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Core.StudentModule.Models.Student>> GetAll()
        {
            return await _dataContext.Students.ToListAsync();
        }
    }
}

