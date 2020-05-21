using ContactList_App.Entities;
using ContactList_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactList_App.Repo
{
    public class ContactRepo : IContactRepo
    {
        Dictionary<string, Person> contacts = new Dictionary<string, Person>();

        public void Add(string name, string phone, string email)
        {
            if (GetPerson(name) == null)
            {
                Person newContact = new Person()
                {
                    Name = name,
                    Phone = phone,
                    Email = email
                };
                contacts.Add(newContact.Name, newContact);                
            }
            else
            {
                throw new Exception("Contact already exists");
            }
        }

        public void Delete(string name)
        {
            if (GetPerson(name) != null)
            {
                contacts.Remove(name);
            }
            else
            {
                throw new Exception("Contact doesn't exist");
            }
        }

        public Person GetPerson(string name)
        {
            Person foundPerson = null;

            if (contacts.ContainsKey(name))
            {
                foundPerson = contacts[name];                
            }

            return foundPerson;            
        }

        public IList<Person> GetRecords()
        {
            List<Person> contactList = new List<Person>();

            foreach (Person contact in contacts.Values)
            {
                contactList.Add(contact);                
            }

            return contactList;
        }
    }
}
