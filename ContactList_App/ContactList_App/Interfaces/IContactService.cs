using ContactList_App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactList_App.Interfaces
{
    public interface IContactService
    {
        public void AddContact();
        public void DeleteContact();
        public void SearchRecord();
        public void ShowRecords();
        public void PrintRecord(Person person);
    }
}
