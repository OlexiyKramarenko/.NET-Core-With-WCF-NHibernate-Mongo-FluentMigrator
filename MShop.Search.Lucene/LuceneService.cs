using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using MShop.DataLayer.Entities.Forums;
using System;
using System.Collections.Generic;

namespace MShop.Search.Lucene
{
	public class LuceneService : ISearchService
	{
		private readonly RAMDirectory ramDirectory = null;

		public LuceneService()
		{
			ramDirectory = new RAMDirectory();
		}

		public void AddDocumentToIndex(Document document)
		{
			using (var indexWriter = new IndexWriter(ramDirectory, new StandardAnalyzer(), new IndexWriter.MaxFieldLength(1000)))
			{
				indexWriter.AddDocument(document);
				indexWriter.Optimize();
				indexWriter.Flush(true, true, true);
			}
		}

		private List<IForum> ForumSearch(RAMDirectory ramDirectory, string textSearch)
		{
			List<IForum> resultUsers = new List<IForum>();

			//Это пользовательский метод
			//Directory directory = CreateIndex(users);

			using (var indexReader = IndexReader.Open(ramDirectory, true))//true - если предполагается только чтение документов, т.е. без записи или удаления
			using (var indexSearcher = new IndexSearcher(indexReader))
			using (Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
			{

				//Поиск будет по УКАЗАННЫМ полям
				MultiFieldQueryParser queryParser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_30, new string[] { "FirstName", "LastName", "UserName" }, analyzer);

				//Когда мы вводим слово, то поиск ищет все поля которые с него начинаются
				//Чтобы мы могли найти поле которое СОДЕРЖИТ это слово, то нужно cделать AllowLeadingWildcard = true
				//Тогда можно делать поиск например 
				//*96* - содержит 96                              
				queryParser.AllowLeadingWildcard = true;

				Query query = queryParser.Parse(textSearch);//перед поиском нужно входную строку(условие) распарсить/разбить

				//Создать коллекцию куда будут записываться совпадения (результат поиска)
				//Top - это верхушка. Это значит что не всё попадает в эту коллекцию.
				//Score - это значит, что сюда должны попасть расчетные данные.
				//Так как выше мы создали indexWriter длиной 1000 объектов, то и тут нам нужно 1000 вхождений/попаданий(hits)               
				TopScoreDocCollector collector = TopScoreDocCollector.Create(1000, true);

				indexSearcher.Search(query, collector); //поиск в коллекции searcher по запросу query и добавление найденных в collector

				//Объект указывает совпадения в результат выполнения метода Search
				TopDocs topDocs = collector.TopDocs();

				//Объект ScoreDoc содержит номер документа
				//Это совпадения по запросу, те некоторые которые входят в 1000
				ScoreDoc[] scoreDocs = topDocs.ScoreDocs;

				//Считывание из mathches в DataTable
				//Для каждого совпавшего ддокумента создает строку в DataTable
				foreach (ScoreDoc s in scoreDocs)
				{
					int numberOfDocument = s.Doc; //Номер документа, который совпадает с требованиями запроса

					//Считываем данные из документа
					Document doc = indexSearcher.Doc(numberOfDocument);


					//Запрет на выдачу результатов при совпадении на основе только имени или только фамилии
					//Результат должен содержать только пользователей, у которых совпадает одновременнно и имя, и фамилия
					#region Final filter
					string userId = doc.GetField("UserID").StringValue;
					string imageUrl = doc.GetField("ImageUrl").StringValue;
					string firstName = doc.GetField("FirstName").StringValue;
					string lastName = doc.GetField("LastName").StringValue;
					string userName = doc.GetField("UserName").StringValue;

					#endregion

					if (textSearch.Contains(" "))//если два слова в поиске
					{
						string pattern = textSearch.Replace(" ", "");

						string combination1 = (firstName + lastName).ToLower();
						string combination2 = (lastName + firstName).ToLower();

						if (pattern == combination1 || pattern == combination2)

							resultUsers.Add(new UserDTO
							{
								//ЧТЕНИЕ ДАННЫХ ИЗ ДОКУМЕНТА
								UserID = userId,
								ImageUrl = imageUrl,
								FirstName = firstName,
								LastName = lastName,
								UserName = userName
							});
					}
					else //если задано только имя или фамилия
					{
						resultUsers.Add(new UserDTO
						{
							//ЧТЕНИЕ ДАННЫХ ИЗ ДОКУМЕНТА
							UserID = userId,
							ImageUrl = imageUrl,
							FirstName = firstName,
							LastName = lastName,
							UserName = userName
						});
					}
				}
			}

			return resultUsers;
		}


		public void AddNewIndex<T>(T entity) where T : class
		{

			////using (Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version)

			////Объект IndexWriter СОЗДАЕТ индекс.  
			////В одном поле(колонке) может быть макс 1000 записей
			//using (var indexWriter = new IndexWriter(ramDirectory, new StandardAnalyzer(), new IndexWriter.MaxFieldLength(1000)))
			//{
			//	var document = new Document();

			//	//данные которые мы потом будем извлекать
			//	document.Add(new Field("UserID", user.UserID, Field.Store.YES, Field.Index.NOT_ANALYZED));
			//	document.Add(new Field("ImageUrl", user.ImageUrl, Field.Store.YES, Field.Index.NOT_ANALYZED));
			//	document.Add(new Field("FirstName", user.FirstName, Field.Store.YES, Field.Index.ANALYZED));
			//	document.Add(new Field("LastName", user.LastName, Field.Store.YES, Field.Index.ANALYZED));
			//	document.Add(new Field("UserName", user.UserName, Field.Store.YES, Field.Index.ANALYZED));

			//	indexWriter.AddDocument(document);

			//	indexWriter.Optimize();
			//	indexWriter.Flush(true, true, true);
			//}
		}

		public List<T> GetAll<T>() where T : class
		{
			throw new NotImplementedException();
		}

		public List<T> SearchInAllFields<T>(string condition, int from, int to) where T : class
		{
			throw new NotImplementedException();
		}

		public List<T> SearchInSingleField<T>(string fieldName, string condition, int from, int to) where T : class
		{
			throw new NotImplementedException();
		}
	}
}
