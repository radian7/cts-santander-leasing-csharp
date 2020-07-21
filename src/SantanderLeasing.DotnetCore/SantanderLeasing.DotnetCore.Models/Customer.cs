using System;
using System.Collections;

namespace SantanderLeasing.DotnetCore.Models
{

    public class Customer : BaseEntity
    {
        // snippet: prop + 2 x Tab

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public bool IsRemoved { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        // ctrl + K + D - formatowanie kodu

        public override void Print()
        {
            Console.WriteLine($"{FirstName} {LastName} {Gender}");
        }

        //public override void Send()
        //{
        //    throw new NotImplementedException();
        //}
        
        public override string ToString()
        {
            return Id + " " + FirstName + " " + LastName + " " + Gender;
        }
    }
}
