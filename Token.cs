using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psgoWurple
{
    public class Token
    {
        public string cmd;
        public string cord;
        public string[] valid = new string[] { "B", "W" };
        //  "AB", "AE", "AW", 
        // "C", "CR","TR","SQ","LB","M","MA","CH", "LN","AR";
        public string sMarkUp = string.Empty;
        public List<MarkUp> Marking;

        public Token(string s)
        {
            Console.WriteLine("Token init with {0}",s);
            cmd = s.Substring(0, s.IndexOf('['));
            Console.WriteLine("cmd " + cmd);
            if (cmd.Equals("GM") == false)
            {
                cord = s.Substring(s.IndexOf('[') + 1, s.IndexOf(']') - s.IndexOf('[') - 1);
                Console.WriteLine("content " + cord);
                /* MarkUp can be _[][][] or _[]_[]_[]
                 */
                if (cmd.Equals("B") || cmd.Equals("W"))
                {
//                    Console.WriteLine("We are going to create MarkUp");
                    List<int> openB = new List<int>();
                    List<int> closeB = new List<int>();
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s.Substring(i, 1).Equals("["))
                            openB.Add(i);
                        if (s.Substring(i, 1).Equals("]"))
                            closeB.Add(i);
                    }
                    if (openB.Count > 1) //if there is more than 1 []
                    {
                        Marking = new List<MarkUp>();
                        MarkUp tmpMarkUp;
                        string last = "";
                        string tmp;
                        for (int i = 0; i < closeB.Count - 1; i++)
                        {
                            Marking.Add(new MarkUp(s.Substring(closeB[i] +1, closeB[i + 1] - closeB[i]), last));
                            last = Marking[i].command;
                        }
                    }
                }
            }

        }

        public bool Valid()
        {
   //         Console.WriteLine("Test validity");
            foreach(string v in valid)
                if(v.Equals(cmd))
                    return true;
            return false;
        }

        public bool ContainMarkUp()
        {
            if (Marking != null)
                return true;
            return false;
        }

        public MarkUp getComment()
        {
            for (int i = 0; i < Marking.Count; i++)
                if (Marking[i].command.Equals("C"))
                    return Marking[i];
            return null;
        }

        public override string ToString()
        {
            return "Token:" + cmd + ":" + cord;
        }


    }
}
