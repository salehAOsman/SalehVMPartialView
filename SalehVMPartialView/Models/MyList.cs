using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalehVMPartialView.Models
{
    //3  efter create this static List we create ---> new controller 
    public class MyList
    {
        static public List<Person> myList = new List<Person>();
        //static constractor
        static MyList()
        {
            MyList.myList.Add(new Person { Id = 1, Name = "samer", City = "Lund" });
            MyList.myList.Add(new Person { Id = 2, Name = "sami", City = "Växjö" });
            MyList.myList.Add(new Person { Id = 3, Name = "maher", City = "Lund" });
            MyList.myList.Add(new Person { Id = 4, Name = "adel", City = "Jämjö" });
            MyList.myList.Add(new Person { Id = 5, Name = "abed", City = "Alvseta" });
            MyList.myList.Add(new Person { Id = 6, Name = "jamal", City = "Karlsham" });
            MyList.myList.Add(new Person { Id = 7, Name = "daimon", City = "Lund" });
            MyList.myList.Add(new Person { Id = 8, Name = "somer", City = "Jönshoping" });
        }
    }
}