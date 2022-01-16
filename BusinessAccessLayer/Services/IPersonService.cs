using AareonTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public interface IPersonService
    {
        Person GetPersonById(int userId);
        IEnumerable<Person> GetAllPersons();
        Task<Person> AddPerson(Person person);
    }
}
