using System.Collections.Generic;

namespace MShop.Search
{
	public interface ISearchService
	{
		void AddNewIndex<T>(T entity) where T : class;
		List<T> GetAll<T>() where T : class;
		List<T> SearchInAllFields<T>(string condition, int from, int to) where T : class;
		List<T> SearchInSingleField<T>(string fieldName, string condition, int from, int to) where T : class;
	}
}