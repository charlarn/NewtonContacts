﻿using NewtonContactsApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonContactsApp.Controller
{
    class MainPageController : INotifyPropertyChanged
    {
        IContactsRepository repo;
        public IList<Contact> Contacts { get; set; }

        private Contact selectedContact;

        public event PropertyChangedEventHandler PropertyChanged;

        public Contact SelectedContact
        {
            get
            {
                return selectedContact;
            }
            set
            {
                selectedContact = value;
                OnPropertyChanged("SelectedContact");
            }
        }

        public MainPageController()
        {
            repo = new MockContactsRepo();
            Contacts = repo.GetAll();
            SelectedContact = Contacts.FirstOrDefault();
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
