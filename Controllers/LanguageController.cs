using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GTN_API.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GTN_API.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        //inject language repo
        private readonly ILanguageRepository _languageRepository;

        public LanguageController(
            ILanguageRepository languageRepository
            )
        {
            _languageRepository = languageRepository;
        }


        // GET: api/Language
        [HttpGet]
        public IEnumerable<Language> Get()
        {
            var languages = _languageRepository.AllLanguagesShortNotes;
            return languages;
        }

        // GET api/<LanguageController>/5
        [HttpGet("{id}")]
        public Language Get(int id)
        {
            return _languageRepository.GetLanguageById(id);
        }

        // POST api/<LanguageController>
        [HttpPost]
        public int Post([FromBody] Language value)
        {
            var newLang = value;
            List<Language> insertLangs = new List<Language>();
            insertLangs.Add(value);
            return _languageRepository.InsertLanguage(insertLangs);
        }

        // PUT api/<LanguageController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Language value)
        {
            int updateCount = 0;
            EntityState retVal = _languageRepository.UpdateLanguage(value);
            if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                updateCount = 1;
            }
            return updateCount;
        }

        // DELETE api/<LanguageController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _languageRepository.DeleteLanguage(new List<int> { id });
        }
    }
}
