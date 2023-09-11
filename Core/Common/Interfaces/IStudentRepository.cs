using System;
using Core.StudentModule.Models;

namespace Core.Common.Interfaces
{
	public interface IStudentRepository
	{
		Task<List<Student>> GetAll();
	}
}

