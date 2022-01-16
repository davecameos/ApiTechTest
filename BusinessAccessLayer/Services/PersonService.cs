using AareonTechnicalTest.Models;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _person;

        public PersonService(IRepository<Person> person)
        {
            _person = person;
        }

        //Get Person By Id
        public Person GetPersonById(int userId)
        {            
            return _person.GetById(userId);            
        }

        //GET All   
        public IEnumerable<Person> GetAllPersons()
        {
            try
            {
                return _person.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Add Person  
        public async Task<Person> AddPerson(Person Person)
        {
            return await _person.CreateAsync(Person);
        }

        public bool DeletePerson(Person person)
        {
            try
            {
                if (person == null)
                {
                    return false;
                }

                _person.Delete(person);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //Update Person
        public bool UpdatePerson(int userId, Person person)
        {
           try
            {             
                _person.Update(userId, person);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }        
    }
}
