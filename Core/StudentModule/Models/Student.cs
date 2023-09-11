using System;
using Core.Common.Models;

namespace Core.StudentModule.Models
{
	public class Student : BaseModel
	{        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
    }
}