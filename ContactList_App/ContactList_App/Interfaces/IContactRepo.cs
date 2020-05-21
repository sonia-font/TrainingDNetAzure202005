using ContactList_App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactList_App.Interfaces
{
    public interface IContactRepo
    {
        void Add(string name, string phone, string email);
        Person GetPerson(string name);
        void Delete(string name);
        IList<Person> GetRecords();
    }
}
