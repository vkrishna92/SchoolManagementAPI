using System;
using Core.Common.Models;

namespace Core.StudentModule.Models
{
	public class Item : BaseModel
	{
		public string ItemType { get; set; }
		public string ItemValue { get; set; }
	}
}

