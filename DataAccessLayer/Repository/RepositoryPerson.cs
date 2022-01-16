using AareonTechnicalTest;
using AareonTechnicalTest.Models;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class RepositoryPerson : IRepository<Person>
    {
        ApplicationContext _dbContext;
        public RepositoryPerson(ApplicationContext applicationContext)
        {
            _dbContext = applicationContext;
        }

        public async Task<Person> CreateAsync(Person _object)
        {
            var obj = await _dbContext.Persons.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Person _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Person> GetAll()
        {
            try
            {
                return _dbContext.Persons.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Person GetById(int id)
        {            
            return _dbContext.Persons.FirstOrDefault(x => x.Id == id);

        }

        public void Update(int id, Person _object)
        {
            var result = _dbContext.Persons.FirstOrDefault(x => x.Id == id);

            if (result != null)
            {
                result.Forename = _object.Forename;
                result.Surname = _object.Surname;
                result.IsAdmin = _object.IsAdmin;     
            }

            _dbContext.Persons.Update(result);
            _dbContext.SaveChanges();
           
        }
    }
}
