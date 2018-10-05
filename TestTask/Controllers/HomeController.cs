using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;
using TestTask.Util;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Sentence> sqlSR;
        public HomeController(IRepository<Sentence> rep)
        {
            sqlSR = rep;
        }
        
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public JsonResult Upload(string searchResalt)
        {
            var list = new List<Sentence>();
            HttpPostedFileBase upload = Request.Files[0];
            if (upload != null)
            {
                // получаем имя файла
                //string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                //upload.SaveAs(Server.MapPath("~/Files/" + "New3 " + fileName));

                System.IO.StreamReader reader = new System.IO.StreamReader(Request.Files[0].InputStream);

               StreamSentence streamSentence = new StreamSentence(reader);

                while (!streamSentence.isEnd)
                {
                    streamSentence.GetNextSentence();

                    int count = streamSentence.sentence.CountWord(searchResalt);

                    if (count > 0)
                    {
                        sqlSR.Create(new Sentence { Count = count, Text = streamSentence.sentence});
                        sqlSR.Save();

                        list.Add(new Sentence { Count = count, Text = streamSentence.sentence });
                    }

                    
                }

            }
            

            return Json(list, JsonRequestBehavior.AllowGet);
            
        }

        [HttpPost]
        public JsonResult UploadElements()
        {
            return Json(sqlSR.GetTextList().ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}