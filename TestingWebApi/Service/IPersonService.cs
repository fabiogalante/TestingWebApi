using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingWebApi.Model;

namespace TestingWebApi.Service
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        Person Add(Person person);
        void Update(int id, Person person);
        void Delete(int id);
    }
}
