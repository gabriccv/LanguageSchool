using SR39_2021_pop2022_2.Models;
using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Repositories
{
    interface ILanguageRepository
    {
        List<Language> GetAll();
        Language GetById(int id);
        int Add(Language language);
        void Update(int id, Language language);
        void Delete(int id);

    }
}
