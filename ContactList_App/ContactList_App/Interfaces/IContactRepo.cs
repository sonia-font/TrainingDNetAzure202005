using ContactList_App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactList_App.Interfaces
{
    public interface IContactRepo
    {
        public void Add(string name, string phone, string email);
        public Person GetPerson(string name);
        public void Delete(string name);
        public IList<Person> GetRecords();
    }
}
