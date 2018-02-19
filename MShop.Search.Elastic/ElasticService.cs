using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MShop.Search.Elastic
{
	public class ElasticService : ISearchService
	{
		ElasticClient client = null;
		public ElasticService()
		{
			var uri = new Uri("http://localhost:9200");
			var settings = new ConnectionSettings(uri);
			client = new ElasticClient(settings);
			settings.DefaultIndex("city");
		}

		public void AddNewIndex<T>(T entity) where T : class
		{
			client.IndexAsync(entity, null);
		}

		public List<T> GetAll<T>() where T : class
		{
			string indexName = typeof(T).Name.ToLower();
			if (client.IndexExists(indexName).Exists)
			{
				ISearchResponse<T> response = client.Search<T>();
				return response.Documents.ToList();
			}
			return null;
		}

		public List<T> SearchInAllFields<T>(string condition, int from, int to) where T : class
		{
			string indexName = typeof(T).Name.ToLower();
			if (client.IndexExists(indexName).Exists)
			{
				return client.SearchAsync<T>(s => s
				.From(from)
				.Take(to - from)
				.Query(query => query
					.Bool(b => b
						.Must(m => m
							.QueryString(qs => qs
								.AllFields()
								.Query(condition)))))).Result.Documents.ToList();
			}
			return null;
		}

		public List<T> SearchInSingleField<T>(string fieldName, string condition, int from, int to) where T : class
		{
			string indexName = typeof(T).Name.ToLower();
			if (client.IndexExists(indexName).Exists)
			{
				return client.SearchAsync<T>(s => s
				.From(from)
				.Take(to - from)
				.Query(query => query
					.Bool(b => b
						.Must(m => m
							.QueryString(qs => qs
								.Fields(fieldName.ToLower())
								.Query(condition)))))).Result.Documents.ToList();
			}
			return null;
		}
	}
}
