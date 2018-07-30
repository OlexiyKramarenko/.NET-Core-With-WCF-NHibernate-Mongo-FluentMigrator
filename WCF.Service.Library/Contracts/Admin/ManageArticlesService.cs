using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using MShop.DataLayer.NHibernate.Providers.Articles;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using WCF.Service.Library.Models;

namespace WCF.Service.Library.Contracts.Admin
{
    [ServiceContract]
    [ValidationBehavior]
    public interface IManageArticlesService
	{
        //http://localhost:50841/ManageArticlesHost.svc/ManageArticles/1/20
        [WebInvoke(Method = "GET",
                   UriTemplate = "/ManageArticles/{pageIndex}/{pageSize}",
                   ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IList<ArticleProvider> ManageArticles(string pageIndex, string pageSize);


        //http://localhost:50841/ManageArticlesHost.svc/AddArticle
        [WebInvoke(Method = "POST",
                   UriTemplate = "/AddArticle",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void AddArticle(AddArticleViewModel model);


        //http://localhost:50841/ManageArticlesHost.svc/DeleteArticle/d101d20d-fd74-4a08-caa7-08d5eae4ce9b
        [WebInvoke(Method = "DELETE",
                   UriTemplate = "/DeleteArticle/{id}")]
        [OperationContract]
        void DeleteArticle(string id);


        //http://localhost:50841/ManageArticlesHost.svc/EditArticle/d101d20d-fd74-4a08-caa7-08d5eae4ce9b
        [WebInvoke(Method = "PUT",
                   UriTemplate = "/EditArticle/{id}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void EditArticle(string id, EditArticleViewModel model);
    }
}
