using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;
        public string allEmails;

        public ContactData(string lastname, string firstname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Middlename { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

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

        public string CleanUpPhone(string phone)
        {
            if (phone == null)
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

        public string Id { get; set; }

        
       public string ContactDataDetails
       {
             get
             {
                 if (ContactDataDetails != null || ContactDataDetails == "")
                 {
                    return ContactDataDetails;
                 }
                 else
                 {
                     return (CleanUpContactDataDetails(ContactDataDetails)).Trim();
                 }
             }
             set
             {
                 ContactDataDetails = value;
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
                 return Regex.Replace(dataPage, "[ -()]", "") + "\r\n";
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
    }
}
