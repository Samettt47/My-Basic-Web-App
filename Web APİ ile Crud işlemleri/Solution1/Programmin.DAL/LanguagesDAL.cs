 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmin.DAL
{

    public class LanguagesDAL
    {
        ProgrammingDbEntities db = new ProgrammingDbEntities();

        public IEnumerable<Languages> GetAllLanguages()
        {
            return db.Languages;

        }
        public Languages GetLanguagesByID(int id)
        {
            return db.Languages.Find(id);

        }
        
        public Languages CreateLangueage(Languages language)
        {
            db.Languages.Add(language);
            db.SaveChanges();
            return language;
        }
        public Languages Updatelanguages(int id , Languages language)
        {
            db.Entry(language).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return language;


        }
        public void DeleteLAnguage(int id)
        {
            db.Languages.Remove(db.Languages.Find(id));
            db.SaveChanges();

        }
        

        }


    }


