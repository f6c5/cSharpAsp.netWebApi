using Microsoft.AspNetCore.Mvc;
using PostgresCRUD.DataAccess;
using PostgresCRUD.Models;
using System;
using System.Collections.Generic;

namespace PostgresCRUD.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {

        private readonly IDataAccessProvider _dataAccessProvider;

        public CustomersController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _dataAccessProvider.GetCustomerRecords();
        }

        [HttpGet("GetByGender/{gender}")]
        public IEnumerable <Customer> Filter(char gender)
        {
            if (gender =='h')
            {
                return _dataAccessProvider.GetCustomerRecords();
            }
            else
            return _dataAccessProvider.GetFilterCustomerRecord(gender);
        }

        [HttpGet("GetById/{id}")]
        public Customer Details(int id)
        {
            return _dataAccessProvider.GetCustomerSingleRecord(id);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                //customer.id = obj.ToString();

                if (!_dataAccessProvider.CustomerVarMi(customer.gmail))
                {
                    _dataAccessProvider.AddCustomerRecord(customer);
                    return Ok("Başarılı");
                }
                else
                {
                    return BadRequest("Bu mail adresi kayıtlı");
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                
                    _dataAccessProvider.UpdateCustomerRecord(customer);
                    return Ok("Değiştirildi");
               
               
                   
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _dataAccessProvider.GetCustomerSingleRecord(id);
            if (data == null)
            {
                return NotFound("Böyle bir kayıt yok");
            }
            _dataAccessProvider.DeleteCustomerRecord(id);
            return Ok("Silindi");
        }

    }

}

