using System;
namespace Core.Common.Models
{
	public class SearchResult<T>
	{
		public List<T> Items { get; set; }
		public List<string> ErrorMessages { get; set; }

        public SearchResult()
        {
            Items = new List<T>(); // Initialize the list of items
            ErrorMessages = new List<string>(); // Initialize the error messages array with an empty array
        }
    }
}

