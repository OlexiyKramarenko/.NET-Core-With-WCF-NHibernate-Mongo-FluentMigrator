using AutoMapper;
using System;
using MShop.DataLayer.NHibernate;
using MShop.DataLayer.NHibernate.Providers.Articles;
using System.Collections.Generic;
using System.ServiceModel.Activation;
using WCF.Service.Library.Contracts.Admin;
using IArticlesRepository = MShop.DataLayer.Repositories.IArticlesRepository<
MShop.DataLayer.NHibernate.Entities.Articles.Article,
MShop.DataLayer.NHibernate.Entities.Articles.Category,
MShop.DataLayer.NHibernate.Entities.Articles.Comment,
MShop.DataLayer.NHibernate.Providers.Articles.ArticleProvider,
MShop.DataLayer.NHibernate.Providers.Articles.CommentProvider, System.Guid>;
using WCF.Service.Library.Models;
using MShop.DataLayer.NHibernate.Entities.Articles;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace WCF.Service.Library.Implementations.Admin
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ManageArticlesService : IManageArticlesService
    {
        private readonly IArticlesRepository _articlesRepository;
        private readonly NHUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ManageArticlesService(IArticlesRepository articlesRepository, NHUnitOfWork unitOfWork, IMapper mapper)
        {
            _articlesRepository = articlesRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IList<ArticleProvider> ManageArticles(string pageIndex, string pageSize)
        {
            int itemsCount = _articlesRepository.GetArticleCount();
            IList<ArticleProvider> articles = articles = _articlesRepository.GetArticles(Convert.ToInt32(pageIndex), Convert.ToInt32(pageSize));
            return articles;
        }

        public void DeleteArticle(string id)
        {
            Guid guid = Guid.Parse(id);
            _articlesRepository.DeleteArticle(guid);
            _unitOfWork.Commit();
        }

        public void EditArticle(string id, EditArticleViewModel model)
        {
            var validator = ValidationFactory.CreateValidator<EditArticleViewModel>("Group1");
            ValidationResults results = validator.Validate(model);

            if (results.IsValid)
            {
                var article = new Article
                {
                    Id = model.Id,
                    Abstract = model.Abstract,
                    AddedBy = model.AddedBy,
                    Body = model.Body
                };

                ArticleProvider articleProvider = _articlesRepository.GetArticleById(model.Id);
                _articlesRepository.UpdateArticle(articleProvider);
                _unitOfWork.Commit();
            }
        }

        public void AddArticle(AddArticleViewModel model)
        {
            var validator = ValidationFactory.CreateValidator<AddArticleViewModel>("Group1");
            ValidationResults results = validator.Validate(model);

            if (results.IsValid)
            {
                var article = new Article
                {
                    Abstract = model.Abstract,
                    AddedBy = model.AddedBy,
                    Body = model.Body
                };
                _articlesRepository.InsertArticle(article);
                _unitOfWork.Commit();
            }
        }
    }
}
