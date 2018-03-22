using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    partial class Person
    {
        public override string ToString()
        {
            return FIO;
        }
    }
    partial class House
    {
        public override string ToString()
        {
            return Street + " " + Number;
        }
    }
    partial class Address
    {
        public override string ToString()
        {
            return House + " " + Flat;
        }
    }
    partial class City
    {
        public override string ToString()
        {
            return Name;
        }
    }
    partial class Company
    {
        public override string ToString()
        {
            return base.ToString() + " " + CompanyName + " " + INN;
        }
    }
    partial class Customer
    {
        public override string ToString()
        {
            return FIO + " " + Passport;
        }
    }
    partial class Meter
    {
        public override string ToString()
        {
            return MeterType + " " + Name; 
        }
    }
    partial class MeterType
    {
        public override string ToString()
        {
            return Name;
        }
    }
    partial class Order
    {
        public override string ToString()
        {
            return Id + " " + Customer + " " + Address + " " + OrderEntry.Count + " " + User;
        }
    }
    partial class OrderEntry
    {
        public override string ToString()
        {
            return Meter + " " + RegNumer + " " + Person + " " +Status + " " + StartTime + " " + EndTime; 
        }
    }
    partial class Status
    {
        public override string ToString()
        {
            return Name;
        }
    }
    partial class Stavka
    {
        public override string ToString()
        {
            return Person + " " + MeterType;
        }
    }
    partial class Street
    {
        public override string ToString()
        {
            return City + " " + Name;
        }
    }
    partial class User
    {
        public override string ToString()
        {
            return Login;
        }
    }
}

