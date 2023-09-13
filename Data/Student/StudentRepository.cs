using System;
using Core.Common.Interfaces;
using Core.Common.Models;
using Core.StudentModule.Models;
using Core.StudentModule.Services;
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
        

        public async Task<SearchResult<Core.StudentModule.Models.Student>> upload(List<Core.StudentModule.Models.Student> students)
        {
            SearchResult<Core.StudentModule.Models.Student> res = new SearchResult<Core.StudentModule.Models.Student>();
            List<Core.StudentModule.Models.Student> success = new List<Core.StudentModule.Models.Student>();
            List<string> messages = new List<string>();

            foreach (var item in students)
            {
                var student = await _dataContext.Students.FirstOrDefaultAsync(s => s.Email == item.Email);
                try
                {
                    if (student != null)
                    {
                        student.FirstName = item.FirstName;
                        student.LastName = item.LastName;
                        student.DateOfBirth = item.DateOfBirth;
                        student.Gender = item.Gender;
                        student.Grade = item.Grade;
                        student.Section = item.Section;
                        await _dataContext.SaveChangesAsync();
                        success.Add(student);
                    }
                    else
                    {
                        _dataContext.Students.Add(item);
                        await _dataContext.SaveChangesAsync();
                        success.Add(item);
                    }
                }
                catch(Exception ex)
                {
                    messages.Add(ex.Message);
                }                
            }

            res.Items = success;
            res.ErrorMessages = messages;
            return res;
        }
    }
}

