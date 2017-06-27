using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psgoWurple
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Work = false;
            Console.WriteLine("Welcome to psgoWurple");
            if (args[0].ToLower().Equals("ascii"))
            {
                Work = true;
                ascii a = new ascii(args[1], args[2]);
            }
            if (args[0].ToLower().Equals("sgf"))
            {
                Console.WriteLine("sgf time");
                Work = true;
                sgf a = new sgf(args[1], args[2]);
            }
            if (!Work)
                Console.WriteLine("usage: psGoWurple ascii|sgf input output");
        }
    }
}
