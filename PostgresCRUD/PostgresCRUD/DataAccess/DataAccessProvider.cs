using PostgresCRUD.Models;
using System.Collections.Generic;
using System.Linq;

namespace PostgresCRUD.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }
        public void AddCustomerRecord(Customer customer)
        {
            _context.customers.Add(customer);
            _context.SaveChanges();
        }
        public void UpdateCustomerRecord(Customer customer)
        {
            _context.customers.Update(customer);
            _context.SaveChanges();
        }
        public void DeleteCustomerRecord(int id)
        {
            var entity = _context.customers.FirstOrDefault(t => t.id == id);
            _context.customers.Remove(entity);
            _context.SaveChanges();

        }
        public Customer GetCustomerSingleRecord(int id)
        {
            return _context.customers.FirstOrDefault(t => t.id == id);
        }
        public List <Customer> GetFilterCustomerRecord(char gender)
        {
            return _context.customers.Where(t => t.gender == gender).ToList();
             
        }
        public List<Customer> GetCustomerRecords()
        {
            return _context.customers.ToList();
        }
        public bool  CustomerVarMi(string gmail)
        {
            var mail = _context.customers.Where( a=> a.gmail == gmail).ToList();
            if (mail.Count>0)
            {
                return true;
            }
            else
                return false;
       }

    }
}
