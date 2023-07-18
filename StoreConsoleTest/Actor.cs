using System;
using System.Collections.Generic;
using System.Text;

namespace StoreConsoleTest
{
    //[MaxLength(5)]
    public class Actor
    {
       
       public string name { get; set; }
        [MaxLength(5)]
        public void setABC()
        {
            System.Console.WriteLine("sdfhksjdhf");
        }
    }
}
