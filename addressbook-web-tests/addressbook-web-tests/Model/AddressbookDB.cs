﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace WebAddressbookTests

{
    public class AddressbookDB : LinqToDB.Data.DataConnection
    {
        public AddressbookDB() : base("Addressbook") { }

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }

        public ITable<ContactData> Contacts { get { return GetTable<ContactData>(); } }
    }
}