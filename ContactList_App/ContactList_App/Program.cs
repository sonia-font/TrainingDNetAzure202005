using ContactList_App.Entities;
using ContactList_App.Interfaces;
using ContactList_App.Repo;
using ContactList_App.Services;
using System;
using System.Collections.Generic;

namespace ContactList_App
{
    class Program
    {
        static IContactService _contactService;

        static void Main(string[] args)
        {
            int option;

            ContactService contactService = new ContactService();
            _contactService = contactService;

            do
            {
                Console.WriteLine("Choose an option\n1. Add Record\n2. Delete Record\n3. Search Record\n4. Show Records\n5.Exit");
                option = Convert.ToInt32(Console.ReadLine());

                if (option != 5)
                {
                    switch (option)
                    {
                        case 1:
                            {
                                _contactService.AddContact();
                                break;
                            }
                        case 2:
                            {
                                _contactService.DeleteContact();
                                break;
                            }
                        case 3:
                            {
                                _contactService.SearchRecord();
                                break;
                            }
                        case 4:
                            {
                                _contactService.ShowRecords();
                                break;
                            }
                    }
                    Console.WriteLine("---------------------------------");
                }

            } while (option != 5); 
            
            Console.ReadKey();
        }        
    }
}
