using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsSpeak.Repositories.Interfaces
{
    internal interface ITermRepository
    {
        public List<KeyValuePair<string, string>> GetTerms(string term);

        public string GetTermMeaning(string term);

        public void AddTerm(string term, string meaning);
    }
}
