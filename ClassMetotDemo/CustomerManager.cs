using System;
using System.Collections.Generic;

namespace ClassMetotDemo
{
    class CustomerManager
    {
        private readonly List<Customer> _customers;
        public CustomerManager()
        {
            _customers = new List<Customer>();
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer findedCustomer = _customers.Find(p => p.Id.Equals(customer.Id));

            // AutoMapper must be used.
            findedCustomer.FirstName = customer.FirstName;
            findedCustomer.LastName = customer.LastName;

            Console.WriteLine($"{customer.Id} Id'li Müşteri Başarıyla Güncellendi!");
        }
        public void DeleteCustomer(Customer customer)
        {
            _customers.Remove(customer);

            Console.WriteLine($"{GetAppealText(customer)} Adlı Müşteri Başarıyla Silindi!");
        }
        public void DeleteCustomerById(int id)
        {
            Customer findedCustomer = _customers.Find(p => p.Id.Equals(id));

            if (findedCustomer != null)
                DeleteCustomer(findedCustomer);
            else
                Console.WriteLine("Verdiğiniz Id'ye Göre Bir Müşteri Bulunamadı!");
        }
        public void AddNewCustomer(CustomerCreateModel customerCreateModel)
        {
            Customer customer = new Customer()
            {
                Id = Helpers.CreateNewId(),
                FirstName = customerCreateModel.FirstName,
                LastName = customerCreateModel.LastName,
                CreatedDateTime = DateTime.Now
            };

            _customers.Add(customer);

            Console.WriteLine($"{GetAppealText(customer)} Adlı Müşteri Başarıyla Kayıt Edildi!");
        }
        public string GetAppealText(Customer customer)
        {
            return $"{customer.FirstName} {customer.LastName}";
        }

        public void GetCustomers()
        {
            if (_customers.Count == 0)
            {
                Console.WriteLine("Sistemde Kayıtlı Müşteri Bulunamadı!");
            }
            else
            {
                foreach (var item in _customers)
                {
                    Console.WriteLine($"Id: {item.Id}\nAd: {item.FirstName}\nSoyad: {item.LastName}\nKayıt Tarihi: {item.CreatedDateTime.ToShortDateString()}");
                    Console.WriteLine("------------------------------");
                }
            }
        }
    }
}
