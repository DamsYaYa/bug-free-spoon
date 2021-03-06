﻿using System;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using System.Linq;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]

    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allInfo;
        public string allPhones;
        public string allEmails;
        public string contactDetails;

        public ContactData()
        {
        }

        public ContactData(string lastname, string firstname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }


        [Column(Name = "firstname")]

        public string Firstname { get; set; }

        public string CleanUpFirstname(string firstName)
        {
            if (firstName == null || firstName == "")
            {
                return "";
            }
            return Regex.Replace(firstName, "[-() ]", "");
        }

        [Column(Name = "lastname")]

        public string Lastname { get; set; }

        public string CleanUpLastname(string lastName)
        {
            if (lastName == null || lastName == "")
            {
                return "";
            }
            return Regex.Replace(lastName, "[-() ]", "") + "\r\n";
        }

        [Column(Name = "middlename")]

        public string Middlename { get; set; }

        [Column(Name = "nickname")]

        public string Nickname { get; set; }

        [Column(Name = "title")]

        public string Title { get; set; }

        [Column(Name = "company")]

        public string Company { get; set; }

        [Column(Name = "address")]

        public string Address { get; set; }

        [Column(Name = "home")]

        public string HomePhone { get; set; }

        [Column(Name = "mobile")]

        public string MobilePhone { get; set; }

        [Column(Name = "work")]

        public string WorkPhone { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null || allPhones == "")
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)).Trim();
                }            
            }
            set
            {
                allPhones = value;
            }
        }

        public string ContactDetailsText { get; set; }
        public string ContactDetailsTextTrim { get; set; }

        public string AllInfo
        {
            get
            {
                if (allInfo != null)
                {
                    return allInfo;
                }
                else
                {
                    return $"{(Firstname)}"  +
                           $"{CleanUpContactDataDetails(Middlename)}" +
                           $"{CleanUpContactDataDetails(Lastname)}" + "\r\n" +
                           $"{CleanUpContactDataDetails(Nickname)}" +
                           $"{CleanUpContactDataDetails(Title)}" +
                           $"{CleanUpContactDataDetails(Company)}" +
                           $"{CleanUpContactDataDetails(Address)}" +
                           $"{CleanUpContactDataDetails(HomePhone)}" +
                           $"{CleanUpContactDataDetails(MobilePhone)}" +
                           $"{CleanUpContactDataDetails(WorkPhone)}" + "\r\n" +
                           $"{CleanUpContactDataDetails(Fax)}" +
                           $"{CleanUpContactDataDetails(Email)}" +
                           $"{CleanUpContactDataDetails(Email2)}" +
                           $"{CleanUpContactDataDetails(Email3)}" +
                           $"{CleanUpContactDataDetails(Homepage)}" +
                           $"{CleanUpContactDataDetails(Address2)}" +                          
                           $"{CleanUpContactDataDetails(Notes)}";
                }
            }
            set => allInfo = CleanUpContactDataDetails(value);
        }

        public string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";            
            }
            return Regex.Replace (phone, "[-() ]","") + "\r\n";
        }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null || allEmails == "")
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[-() ]", "") + "\r\n";
        }

        public string Homepage { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]

        public string Id { get; set; }


        public string ContactDetails
        {
            get
            {
                if (contactDetails != null)
                {
                    return contactDetails;
                }

                else
                {
                    return (CleanUpContactDataDetails(ContactDetails)).Trim();
                }
            }
            set
            {
                contactDetails = value;
            }
        }             
        
 
         private string CleanUpContactDataDetails(string dataPage)
         {
             if (dataPage == null || dataPage == "")
             {
                 return "";
             }
             else
             {
                 return Regex.Replace(dataPage,"[-() ]","") + "\r\n";
             }
         }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return (Lastname + Firstname).CompareTo(other.Lastname + other.Firstname);
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Lastname == other.Lastname && Firstname == other.Firstname;
        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode() + Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return "\nfirstname" + Firstname + "\nlastname" + Lastname;
        }

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
