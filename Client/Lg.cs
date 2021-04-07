using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Client
{
    class Lg
    {
        static void Main(string[] args)
        {
            Clients k = new Clients();
            Console.WriteLine(k.sing_Up("h1", "h1", "h1", "h1"));
            Console.WriteLine(k.geta());
        }
    }
}
