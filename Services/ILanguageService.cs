using SR39_2021_pop2022_2.Models;
using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Services
{
    interface ILanguageService
    {
        List<Language> GetAll();
        List<Language> GetValidLanguage();
        void Add(Language language);

        void Update(int id, Language language);
        void Delete(int id);
        Language GetById(int id);
    }
}
