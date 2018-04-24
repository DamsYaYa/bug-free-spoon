using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base (manager)
        {
        }

        public ContactHelper AddNew()
        {
            manager.Navigator.OpenHomePage();

            //Добавление нового контакта
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();

            InitContactModification(0);
            
            var firstName = GetTextOfAttributeValue(By.Name("firstname"), "value").Trim();
            var lastName = GetTextOfAttributeValue(By.Name("lastname"), "value").Trim();
           
            var middleName = GetTextOfAttributeValue(By.Name("middlename"), "value").Trim();
            var nickName = GetTextOfAttributeValue(By.Name("nickname"), "value");
            var companyName = GetTextOfAttributeValue(By.Name("company"), "value");
            var title = GetTextOfAttributeValue(By.Name("title"), "value");
            var address = driver.FindElement(By.Name("address")).Text;

            var homePhone = GetTextOfAttributeValue(By.Name("home"), "value");
            if (!String.IsNullOrEmpty(homePhone))
            {
                homePhone = $"H:{homePhone}";
            }

            var mobilePhone = GetTextOfAttributeValue(By.Name("mobile"), "value");
            if (!String.IsNullOrEmpty(mobilePhone))
            {
                mobilePhone = $"M:{mobilePhone}";
            }

            var workPhone = GetTextOfAttributeValue(By.Name("work"), "value");
            
            if (!String.IsNullOrEmpty(workPhone))
            {
                workPhone = $"W:{workPhone}";
            }


            var fax = GetTextOfAttributeValue(By.Name("fax"), "value");
            
            if (!String.IsNullOrEmpty(fax))
            {
                fax = $"F:{fax}";
            }

            var email = GetTextOfAttributeValue(By.Name("email"), "value");
            var email2 = GetTextOfAttributeValue(By.Name("email2"), "value");
            var email3 = GetTextOfAttributeValue(By.Name("email3"), "value");

            var homepageValue = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            var homepage = SelectTheRightValue(homepageValue, "Homepage:");

            var address2 = driver.FindElement(By.Name("address2")).Text;

            var phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            
            if (!String.IsNullOrEmpty(phone2))
            {
                phone2 = $"P:{fax}";
            }

            var notes = driver.FindElement(By.Name("notes")).Text;

            return new ContactData
            {
                Firstname = firstName,
                Lastname = lastName,
                Middlename = middleName,
                Nickname = nickName,
                Company = companyName,
                Title = title,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homepage,
                Address2 = address2,
                Phone2 = phone2,
                Notes = notes
            };
        }


        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();

            ClearGroupFilter();
            selectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void selectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string Lastname = cells[1].Text;
            string Firstname = cells[2].Text;
            string Address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(Lastname, Firstname)
            {
                Address = Address,
                AllEmails = allEmails,
                AllPhones = allPhones,
            };

        }

        private List<ContactData> contactCashe = null;

        public List<ContactData> GetContactList()
        {
            if (contactCashe == null)
            {
                contactCashe = new List<ContactData>();
                List<ContactData> contacts = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> table = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in table)
                {
                    string Lastname = element.FindElement(By.XPath("./td[2]")).Text;
                    string Firstname = element.FindElement(By.XPath("./td[3]")).Text;
                    contactCashe.Add(new ContactData(Lastname, Firstname)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });

                }
            }

            return new List<ContactData>(contactCashe);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("selected[]")).Count;
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            driver.FindElement(By.LinkText("add new")).Click();
            FillForm(contact);
            SubmitAdding();
            return this;
        }

        public ContactHelper Modify(ContactData contact, ContactData newContactData)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(contact.Id);
            InitContactModification(0);
            FillForm(newContactData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper ContactModification(ContactData contact,ContactData toBeModified)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(contact.Id);
            InitContactModification(0);
            FillForm(toBeModified);
            SubmitContactModification();
            return this;
        }

        public ContactHelper RemoveContact(int v)
        {
            manager.Navigator.OpenHomePage();

            SelectContact(0);
            RemoveSelectedContact();
            SubmitRemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper RemoveContact(ContactData contact)
        {
            manager.Navigator.OpenHomePage();

            SelectContact(contact.Id);
            RemoveSelectedContact();
            SubmitRemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper FillForm(ContactData contact)
        {
            //Заполнение полей ввода
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper SubmitAdding()
        {
            // Подтверждаем создание нового контакта
            driver.FindElement(By.Name("submit")).Click();
            contactCashe = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            // Выбор контакта
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + " ]")).Click();
            return this;
        }


        public ContactHelper SelectContact(String contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
            return this;
        }

        public ContactHelper RemoveSelectedContact()
        {
            // Удалить выбранный контакт
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SubmitRemoveContact()
        {
            //Подтверждение удаления контакта
            driver.SwitchTo().Alert().Accept();
            contactCashe = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCashe = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public bool VerifyContactIsPresent(int ContactIndex, ContactData newContactData)
        {
            manager.Navigator.OpenHomePage();

            while (!IsElementPresent(By.XPath($"(//tr[@name='entry'])[{ContactIndex + 1}]")))
            {
                newContactData = new ContactData(null, "Morskaya_pipiska");
                CreateContact(newContactData);
                manager.Navigator.OpenHomePage();
            }
            
            return true;

        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public ContactHelper OpenContactDetails (int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                  .FindElements(By.TagName("td"))[6]
                  .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenContactDetails(0);

            var allInfo = driver.FindElement(By.CssSelector("#content")).Text;

            return new ContactData("", "")
            {
                AllInfo = allInfo

            };
        }

       // public void RemoveContactFromGroup(ContactData contact, GroupData group)
        //{
          //  manager.Navigator.OpenHomePage();
            //SelectGroupFromList(ContactData contact, GroupData group);
            //SelectContact(contact.Id);
            //CommitRemovingContactFromGroup();
            //new WebDriverWait(driver, TimeSpan.FromSeconds(10))
              //      .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);        
        //}

        public void SelectGroupFromList(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public void CommitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public string GetTextOfAttributeValue(By locator, string attributeValue)
        {
            return driver.FindElement(locator).GetAttribute(attributeValue);
        }

        public string SelectTheRightValue(string fieldValue, string additionalSymbol, bool fordetailsPage = false)
        {
            if (fieldValue != "" && fordetailsPage)
            {
                return additionalSymbol + fieldValue;
            }
            else if (fieldValue != "")
            {
                return fieldValue;
            }
            else
            {
                return "";
            }
        }
    }
}
