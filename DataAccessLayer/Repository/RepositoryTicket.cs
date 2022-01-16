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
    public class RepositoryTicket : IRepository<Ticket>
    {
        ApplicationContext _dbContext;
        public RepositoryTicket(ApplicationContext applicationContext)
        {
            _dbContext = applicationContext;
        }

        public async Task<Ticket> CreateAsync(Ticket _object)
        {
            var obj = await _dbContext.Tickets.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Ticket _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Ticket> GetAll()
        {
            try
            {
                return _dbContext.Tickets.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Ticket GetById(int Id)
        {
            return _dbContext.Tickets.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(Ticket _object)
        {
            _dbContext.Tickets.Update(_object);
            _dbContext.SaveChanges();
        }

        public void Update(int id, Ticket _object)
        {
            // TODO add logic to only allow updates from admin users
            var result = GetById(id);
            if (result != null)
            {                
                result.PersonId = _object.PersonId;
                result.Content = _object.Content;
            }
            _dbContext.Tickets.Update(result);
            _dbContext.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
