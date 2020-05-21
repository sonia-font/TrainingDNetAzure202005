using ContactList_App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactList_App.Interfaces
{
    public interface IContactService
    {
        void AddContact();
        void DeleteContact();
        void SearchRecord();
        void ShowRecords();
        void PrintRecord(Person person);
    }
}
