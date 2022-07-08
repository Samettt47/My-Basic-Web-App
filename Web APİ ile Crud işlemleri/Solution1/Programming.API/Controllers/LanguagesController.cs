using Programmin.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Programming.API.Controllers
{
   
    public class LanguagesController : ApiController
    {

        public IEnumerable<Languages> Get() {
            LanguagesDAL languagesDAL = new LanguagesDAL();

            return languagesDAL.GetAllLanguages();

        }
        public Languages Get(int id)
        {
            LanguagesDAL languagesDAL = new LanguagesDAL();

            return languagesDAL.GetLanguagesByID(id);
        }
        public Languages Post(Languages language)
        {
            LanguagesDAL languagesDAL = new LanguagesDAL();

            return languagesDAL.CreateLangueage(language);
        }
        public Languages Put(int id , Languages language)
        {
            LanguagesDAL languagesDAL = new LanguagesDAL();

            return languagesDAL.Updatelanguages(id, language);

        }
        public void Delete(int id)
        {
            LanguagesDAL languagesDAL = new LanguagesDAL();

            languagesDAL.DeleteLAnguage(id);

        }
    }
}
