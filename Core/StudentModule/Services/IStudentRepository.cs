using System;
using Core.Common.Models;

namespace Core.StudentModule.Services
{
	public interface IStudentRepository
	{
        Task<SearchResult<Core.StudentModule.Models.Student>> upload(List<Core.StudentModule.Models.Student> students);
	}
}

