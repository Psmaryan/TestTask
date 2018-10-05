using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public interface IRepository<T>  where T: class
    {
        IEnumerable<T> GetTextList(); 
        void Create(T item); 
        void Save(); 
    }

    public class SQLSentenceRepository : IRepository<Sentence>
    {
        private SentenceContext db;

        public SQLSentenceRepository()
        {
            this.db = new SentenceContext();
        }

        public IEnumerable<Sentence> GetTextList()
        {
            var list = db.Sentences.ToList();
            foreach (var text in list)
            {
                text.Text = Reverse(text.Text);
            }

            return list;
        }

        public void Create(TestTask.Models.Sentence text)
        {
            text.Text = Reverse(text.Text);
            db.Sentences.Add(text);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}