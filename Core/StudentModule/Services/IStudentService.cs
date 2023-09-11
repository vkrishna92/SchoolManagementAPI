using System;
using Core.StudentModule.Models;

namespace Core.StudentModule.Services
{
	public interface IStudentService
	{
		public Task<IEnumerable<Student>> GetAll();
        public Task<Student> Get(int id);
        public Task<Student> Insert(Student obj);
        public Task Update(Student obj);
        public Task Delete(int id);
    }
}

