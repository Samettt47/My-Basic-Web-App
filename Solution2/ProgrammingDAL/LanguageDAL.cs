using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingDAL
{
    public class LanguageDAL : BaseDAL
    {

        public IEnumerable<Languages> GetAllLAnguages()
        {
            return db.Languages;

        }

        public Languages GetLanguagebyId(int id)
        {
             return db.Languages.Find(id);
        }
        public Languages CreateLanguage(Languages language)
        {

            db.Languages.Add(language);
            db.SaveChanges();
            return language;

        }
        public Languages UpdateLanguages(int id , Languages language)
        {

            db.Entry(language).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return language;
            
        }
        public void DeleteLanguage(int id)
        {
            db.Languages.Remove(db.Languages.Find(id));
            db.SaveChanges();
            
        }
        public bool IsthereanLanguage(int id)
        {
            return db.Languages.Any(x => x.ID == id);
        }
    }
    
}
