﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Crowd_knowledge_contribution.Models;

namespace Crowd_knowledge_contribution.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly PlatformDbContext _database = new PlatformDbContext();

        // GET: Articles
        [HttpGet]
        public ActionResult Index()
        {
            //pagina cu toate
            ViewBag.Articles = _database.Articles.Include("Domain");
            return View();
        }

        public ActionResult Show(int id)
        {
            Article article = _database.Articles.Where(i => i.ArticleId == id).FirstOrDefault();
            //Article article = _database.Articles.Find(id,1);
            return View(article);
        }

        //[HttpGet]
        public ActionResult New()
        {
            var article = new Article {Dom = GetAllDomains()};

            return View(article);
        }


        [HttpPost]
        public ActionResult New(Article article)
        {
            article.Dom = GetAllDomains();
            article.LastModified = DateTime.Now;
            article.VersionId = 1;
            try
            {
                if (ModelState.IsValid)
                {
                    _database.Articles.Add(article);
                    _database.SaveChanges();
                    TempData["message"] = "Operatiune adaugare articol: succes";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(article);
                }
            }
            catch (Exception )
            {
                return View(article);
            }   
        }

        public ActionResult Edit(int id)
        {
            Article article = _database.Articles.Where(i => i.ArticleId == id).FirstOrDefault();
            article.Dom = GetAllDomains();
            return View(article);
        }

        [HttpPut]
        public ActionResult Edit(int id, Article requestArticle)
        {
            requestArticle.Dom = GetAllDomains();

            try
            {
                if (ModelState.IsValid)
                {
                    Article article = _database.Articles.Where(i => i.ArticleId == id).FirstOrDefault();

                    if (TryUpdateModel(article))
                    {
                        article.Title = requestArticle.Title;
                        article.Content = requestArticle.Content;
                        article.DomainId = requestArticle.DomainId;
                        //article.VersionId ++ ;
                        _database.SaveChanges();
                        TempData["message"] = "Operatiune adaugare articol: succes";
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(requestArticle);
                }

            }
            catch (Exception )
            {
                return View(requestArticle);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Article article = _database.Articles.Where(i => i.ArticleId == id).FirstOrDefault();
            _database.Articles.Remove(article);
            _database.SaveChanges();
            TempData["message"] = "Articolul a fost sters";
            return RedirectToAction("Index");
        }

        [NonAction]
        private IEnumerable<SelectListItem> GetAllDomains()
        {
            var selectList = new List<SelectListItem>();

            var domains = from domain in _database.Domains
                select domain;

            foreach (var domain in domains)
            {
                selectList.Add(new SelectListItem
                {
                    Value = domain.DomainId.ToString(),
                    Text = domain.DomainName
                });
            }
            
            return selectList;
        }
    }
}