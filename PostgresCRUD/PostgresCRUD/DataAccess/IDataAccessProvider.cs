using PostgresCRUD.Models;
using System.Collections.Generic;

namespace PostgresCRUD.DataAccess
{
    public interface IDataAccessProvider
    {
        void AddCustomerRecord(Customer customer);
        void UpdateCustomerRecord(Customer customer);
        void DeleteCustomerRecord(int id);
        List <Customer> GetFilterCustomerRecord(char gender);
        Customer GetCustomerSingleRecord(int id);
        List<Customer> GetCustomerRecords();
        bool CustomerVarMi(string gmail);
    }
}
