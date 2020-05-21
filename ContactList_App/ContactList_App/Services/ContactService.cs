using ContactList_App.Entities;
using ContactList_App.Interfaces;
using ContactList_App.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactList_App.Services
{
    public class ContactService : IContactService
    {
        IContactRepo _contactRepo = new ContactRepo();

        public void AddContact()
        {
            string name,
                   phone,
                   email;

            Console.WriteLine("Person name: ");
            name = Console.ReadLine();
            Console.WriteLine("Person phone: ");
            phone = Console.ReadLine();
            Console.WriteLine("Person email: ");
            email = Console.ReadLine();

            try
            {
                _contactRepo.Add(name, phone, email);
                Console.WriteLine("Contact added");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        public void DeleteContact()
        {
            string name;

            Console.WriteLine("Person name: ");
            name = Console.ReadLine();

            try
            {
                _contactRepo.Delete(name);
                Console.WriteLine("Contact deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        public void SearchRecord()
        {
            string name;
            Person contact;

            Console.WriteLine("Person name: ");
            name = Console.ReadLine();

            contact = _contactRepo.GetPerson(name);

            if (contact != null)
            {
                PrintRecord(contact);
            }
            else
            {
                Console.WriteLine("Contact not found");
            }            
        }

        public void ShowRecords()
        {
            IList<Person> contacts;
            contacts = _contactRepo.GetRecords();

            if (contacts.Count != 0)
            {
                foreach (Person contact in contacts)
                {
                    PrintRecord(contact);
                }
            }
            else
            {
                Console.WriteLine("Contact list is empty");
            }            
        }

        public void PrintRecord(Person person)
        {
            Console.WriteLine("Person name: {0} | Phone: {1} | Email: {2}", person.Name, person.Phone, person.Email);
        }
    }
}
