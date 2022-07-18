using ProgramminAPI.Attributes;
using ProgramminAPI.Security;
using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProgramminAPI.Controllers
{


    public class LanguagesController : ApiController
    {
        LanguagesDAL languageDAL = new LanguagesDAL();

        [ResponseType(typeof(IEnumerable<Languages>))]

        public IHttpActionResult GetSearchByName(string name)
        {
            return Ok("Name : " + User.Identity.Name);
        }
        public IHttpActionResult GetSearchBySurName(string surname)
        {
            return Ok("SurName : " + surname);
        }
        
   
        [ApiAuthorize(Roles = "A")]

        public IHttpActionResult Get()
        {

            var languages  = languageDAL.GetAllLanguages();

            return Ok(languages);
        }
        [ResponseType(typeof(Languages))]
        
      
        [ApiAuthorize(Roles ="A,M")]
        public IHttpActionResult Get(int id)
        {
           
               
                var language = languageDAL.getlanguagesbyID(id);
                if (language == null)
                {
                    return NotFound();
                }
                return Ok(language);
            
           

        }

        [ResponseType(typeof(Languages))]
        public IHttpActionResult Post(Languages language)
        {

            if (ModelState.IsValid)
            {
                var planguage = languageDAL.CreateLanguages(language);

                return CreatedAtRoute("DefaultApi", new { id = planguage.ID }, planguage);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [ResponseType(typeof(Languages))]
        public IHttpActionResult Put(int id , Languages language)
         {
            //ID ye ait kayıt yok ise
            var ulanguage = languageDAL.IsthereanyLanguage(id);
            if (ulanguage == false)
            {
                return NotFound();
            }

            //Language modeli doğrulanmadıysa
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            //OK
            else
            {
                return Ok(languageDAL.getlanguagesbyID(id));

            }
        }

        public IHttpActionResult Delete(int id)
        {
            if(languageDAL.IsthereanyLanguage(id) == false)
            {
                return NotFound();

            }
            else
            {
                languageDAL.Delete(id);
                return Ok();
            }

        }
    }
}
