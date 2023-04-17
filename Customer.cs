using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Welch_Bank
{
    public class Customer : ICustomer
    {
        #region Fields
        private string _firstName;
        private string _lastName;

        //public string Firstname
        //{
        //    get { return _firstName; }
        //    set { _firstName = Sanitize(value); }
        //}

        //public string Lastname
        //{
        //    get { return _lastName; }
        //    set { _lastName = Sanitize(value); }
        //}
        

        private string _email;
        private string _mobile;
        #endregion


        #region Properties
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = Sanitize(value);
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = Sanitize(value);
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            { _email = value; }
        }
        public string Mobile
        {

            get
            {
                return _mobile;
            }

            set
            {
                try
                {
                    // Mobile Number must be 10-digit...
                    if (value.Length == 10)
                    {
                        _mobile = value;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(Mobile, e);
                }
            }
        }
        public string _fullname;
        #endregion
        public Customer(string firstname, string lastname, string email, string phone)
        {
            FirstName= firstname;
            LastName = lastname;

            Email = email;
            Mobile = phone;
            _fullname = _firstName + " " + _lastName;

        }

        public string Sanitize(string firstName)

        {
            //    //Remove any non-letter character and convert to lowercase
            string pattern = "[^a-zA-Z]+";
            firstName = Regex.Replace(firstName, pattern, "");


            // Capitalize the first letter of the first name
            firstName = firstName.Substring(0, 1).ToUpper() + firstName.Substring(1);


            // Join the sanitized first name and last name
            return firstName;
        }

    }
}








