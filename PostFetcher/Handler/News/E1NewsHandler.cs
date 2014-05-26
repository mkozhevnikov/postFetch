using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using PostFetcher.HtmlAgent;
using PostFetcher.Model;

namespace PostFetcher.Handler.News
{
    public class E1NewsHandler : ModelHandler<Article> {
        private const string defaultUri = "http://www.e1.ru/news/";
        protected DOMAgent Agent = new DOMAgent();
        private string baseUri;

        public override void Process(string firstPage = defaultUri) {
            //обрабатываем входные параметры
            if (string.Empty.Equals(firstPage))
                firstPage = defaultUri;
            baseUri = new Uri(firstPage).GetLeftPart(UriPartial.Authority);
            
            var document = Agent.GetDOM(firstPage);
            var nodeCollection = document.DocumentNode.SelectNodes("//a[@class='news']");
            if (nodeCollection != null) {
                foreach (var node in nodeCollection) {
                    var href = GetURI(node.GetAttributeValue("href", ""));
                    var created = node.ParentNode.Element("span").InnerText;

                    var article = new Article() {
                        Created = DateTime.Parse(created),
                        Link = href,
                        Title = node.InnerText
                    };
                    if (IsProcessed(article)) continue;
                    Console.WriteLine(article.Title);
                    ProcessNewsPage(href, ref article);
                    Save(article);
                }
            }
        }

        private string GetURI(string href) {
            /*try {
                return baseUri + new Uri(href).LocalPath;
            }
            catch (Exception) {
                return href;
            }*/
            if (new Regex(@"\bhttps?://").IsMatch(href))
                return href;
            return baseUri + href;
        }

        public override bool IsProcessed(Article obj) {
            return db.Article.Any(art => art.Link == obj.Link);
        }

        private void ProcessNewsPage(string newsLink, ref Article article) {
            var document = Agent.GetDOM(newsLink);
            var textElement = document.DocumentNode.SelectSingleNode("//div[@id='newscontent']");
            if (textElement != null) {
                //обработка текста статьи
                article.Text = textElement.InnerText.Trim();
                
                //обработка Рубрики и Автора статьи
                var tdParentElement = textElement.Ancestors("td").First();
                if (tdParentElement != null) {
                    var sectionNode = tdParentElement.Element("a");
                    if (sectionNode != null) article.Section = sectionNode.InnerText;
                    
                    var authorNode = tdParentElement.SelectSingleNode("span[@class='small_black']");
                    if (authorNode != null) article.Author = authorNode.InnerText;
                }

                //обработка изображений
                var imageCollection = textElement.SelectNodes(".//img");
                if (imageCollection != null) {
                    foreach (var imageNode in imageCollection) {
                        ProcessImage(imageNode.GetAttributeValue("src", ""), article);
                    }
                }
            }
        }

        /// <summary>
        /// Загружает изображение и создает объект для базы данных
        /// </summary>
        /// <param name="imageSrc">ссылка на изображение</param>
        /// <param name="article">Статья, к которой привязывается изображение</param>
        private void ProcessImage(string imageSrc, Article article) {
            var image = Agent.LoadImage(GetURI(imageSrc));
            if (image == null) return;
            db.Image.InsertOnSubmit(new Image() {
                Article = article,
                File = image.ToBinary()
            });
        }
    }
}
