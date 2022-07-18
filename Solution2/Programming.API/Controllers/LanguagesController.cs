using Programming.API.Attributes;
using Programming.API.Security;
using ProgrammingDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Programming.API.Controllers
{
    
    public class LanguagesController : ApiController
    {
        LanguageDAL languageDAL = new LanguageDAL();


        public IHttpActionResult GetSearchByName(string name)
        {
            return Ok("name : " + User.Identity.Name );
        }
        public IHttpActionResult GetSearchBySurName(string Surname)
        {
            return Ok("Surname : " + Surname);
        }


        [ResponseType(typeof(IEnumerable<Languages>))]

        [APIAuthorize(Roles = "A")]
        public IHttpActionResult Get()
        { 
            var languages = languageDAL.GetAllLAnguages();
            return Ok(languages);       //Request.CreateResponse(HttpStatusCode.OK, languages);//(httpresponsemessage ile bu şekilde)
        }
        [ResponseType(typeof(Languages))]

        [APIAuthorize(Roles ="A,M")]
        public IHttpActionResult Get(int id)
        {
           
                var language = languageDAL.GetLanguagebyId(id);
                if (language == null)
                {
                    return NotFound();               //  Request.CreateResponse(HttpStatusCode.NotFound, language);

                }
                else
                {
                    return Ok(language);                      //Request.CreateResponse(HttpStatusCode.OK, language);
                }
            
            
        }
        [ResponseType(typeof(Languages))]
        public IHttpActionResult Post(Languages language)
        {
            

           
            if (ModelState.IsValid )
            {
                var clanguages = languageDAL.CreateLanguage(language);

                return CreatedAtRoute("DefaultApi", new { id = clanguages.ID },clanguages);              
                //2.yöntem => (hhttpresponsemessage ile = >  Request.CreateResponse(HttpStatusCode.Created, clanguages);


            }
            else
            {
                return BadRequest(ModelState);
                  //2.yöntem ==>  Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }

        public IHttpActionResult Put(int id , Languages language )
        {

            var planguages = languageDAL.IsthereanLanguage(id);
            
            // ID ye ait kayıt yoksa

              if (id != language.ID)
            {
                return BadRequest();
            }
            if (planguages == false)
            {
                return NotFound();      /* Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı");*/
            }
            // language modeli doğrulanmadıysa
            else if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState); /* Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);*/
            }
            // Güncellenmek istenen id eğer tabloda yoksa
           
            //OK
            else
            {

                return Ok(languageDAL.UpdateLanguages(id, language));  /*Request.CreateResponse(HttpStatusCode.OK , languageDAL.UpdateLanguages(id,language ));*/
                
            }
           
        }
        public IHttpActionResult Delete(int id)
        {
            
            var language = languageDAL.IsthereanLanguage(id);
            if(language == false)
            {
                return NotFound();

                //Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
            }
            else
            {
                return Ok();
                    
                    //Request.CreateResponse(HttpStatusCode.NoContent) ;
            }
        }


    }
}
