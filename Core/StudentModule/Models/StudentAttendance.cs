using System;
using Core.Common.Models;

namespace Core.StudentModule.Models
{
	public class StudentAttendance : BaseModel
	{
		public int StudentId { get; set; }
		public Student Student { get; set; }
		public DateTime OccuranceDate { get; set; }
		public string Subject { get; set; }
		public string Grade { get; set; }		
	}
}

