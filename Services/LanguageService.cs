using SR39_2021_POP2022_2.Models;
using SR39_2021_pop2022_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR39_2021_pop2022_2.Models;

namespace SR39_2021_pop2022_2.Services
{
    class LanguageService : ILanguageService
    {
        private ILanguageRepository languageRepository;

        public LanguageService()
        {
            languageRepository = new LanguageRepository();
        }
        public List<Language> GetValidLanguage()
        {
            return languageRepository.GetAll().Where(p => p.IsDeleted).ToList();
        }

        public List<Language> GetAll()
        {
            return languageRepository.GetAll();
        }

        public void Add(Language language)
        {
            languageRepository.Add(language);
        }

        public void Update(int id, Language language)
        {
            languageRepository.Update(id, language);
        }
        public void Delete(int id)
        {

            languageRepository.Delete(id);
        }
        public Language GetById(int id)
        {
            return languageRepository.GetById(id);
        }
    }
}
