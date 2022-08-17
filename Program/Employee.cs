using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Employee
    {
        private string _name;
        private string _phoneNumber;
        private string _passportData;
        private DateTime _dateOfChanged;
        private string _whoChanged;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string PassportData
        {
            get { return _passportData; }
            set { _passportData = value; }
        }
        public DateTime DateOfChanged
        {
            get { return _dateOfChanged; }
            set { _dateOfChanged = Convert.ToDateTime(value); }
        }
        public string WhoChanged
        {
            get { return _whoChanged; }
            set { _whoChanged = value; }
        }
        public Employee(string name, string phoneNumber, string passporData)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            PassportData = passporData;
        }
        public Employee(string name, string phoneNumber, string passportData, DateTime dateOfChanged, string whoChanged)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            PassportData = passportData;
            DateOfChanged = dateOfChanged;
            WhoChanged = whoChanged;
        }
    }
}
