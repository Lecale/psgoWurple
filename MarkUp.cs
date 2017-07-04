using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psgoWurple
{
    public class MarkUp
    {
        public string command = string.Empty;

        //TR SQ CR LB , AB AE AW , AR LN,    (M=? MA=X )
        public int X = -1;
        public int Y = -1;
        //AR LN
        public int X2 = -1;
        public int Y2 = -1;
        // -> Coords are also used for PART_BOARD 

        //LB
        public string Label = string.Empty;

        //C
        public string Instructions = string.Empty; //debug
        public int mv1 = 0; //this is the first move number in a diagram
        public int mvP = 0; //this is the number of prior moves to include in a diagram
        public int BdSize = 19;
        
        private string abet = " abcdefghijklmnopqrstu";
        private string P1 = "TR SQ CR LB AB AE AW AR LN MA M"; //1 point //L is only SGF-3
        private string P2 = "AR LN "; //2 points


        public MarkUp(string s, string _cmd="C")
        {
            Console.WriteLine("MarkUp init with {0}",s);
            string[] split = s.Split(new string[] { "[","]" },StringSplitOptions.None);
            if (split[0] == null || split[0].Equals(string.Empty))
            {
                Console.WriteLine("The MarkUp is updated with PRIOR {0}",_cmd);
                command = _cmd;
            }
            else {
                command = split[0];
                Console.WriteLine("The MarkUp is "+command);
                }

            if (P1.Contains(command+" "))
            {
                X = abet.IndexOf(split[1].Substring(0, 1));
                Y = abet.IndexOf(split[1].Substring(0, 1));
                Console.WriteLine("{0},{1}", X, Y);
            }

            if (P2.Contains(command + " "))
            {
                X = abet.IndexOf(split[2].Substring(0, 1));
                Y = abet.IndexOf(split[2].Substring(0, 1));
            }

            if (command.Equals("LB"))// || command.Equals("L"))
                Label = split[1].Substring(3, 1);

            if (command.Equals("C"))
            {
                string[] Wurple = split[1].Split(new char[] { ',' });
 //               foreach (string spl in split)
 //                   Console.WriteLine(":::" + spl);
                string[] sTmp;
                foreach (string w in Wurple)
                {
 //                   Console.WriteLine("w:{0}",w);
                    if (w.Contains("DIAGRAM_START") || w.Contains("DIAGRAM_END"))
                        ;//like why would i even begin to care about this man oh the angst in my brain
                    if (w.Contains("FULL_BOARD"))
                    {
                        sTmp = w.Trim().Split(new char[] { ' ' });
                        BdSize = int.Parse(sTmp[1].Trim());
                    }
                    if (w.Contains("PART_BOARD"))
                    {
                        sTmp = w.Trim().Split();
                        X = abet.IndexOf(sTmp[1].Trim().Substring(0, 1));
                        Y = abet.IndexOf(sTmp[1].Trim().Substring(1, 1));
                        X2 = abet.IndexOf(sTmp[2].Trim().Substring(0, 1));
                        Y2 = abet.IndexOf(sTmp[2].Trim().Substring(1, 1));

                    }
                    if (w.Contains("START_MOVE_NBR"))
                    {
 //                       Console.WriteLine("start:{0}",split[1]);
                        sTmp = w.Trim().Split(new char[] { ' ' });
                        mv1 = int.Parse(sTmp[1].Trim());
                    }
                    if (w.Contains("PREV_NBR_MOVE"))
                    {
//                        Console.WriteLine("prev:{0}", split[1]);
                        sTmp = w.Trim().Split(new char[] { ' ' });
                        mvP = int.Parse(sTmp[1].Trim());
                    }
                }
                Console.WriteLine("{0} {1} {2}",mv1,mvP,BdSize);
            
            }
//            Console.WriteLine(" ... end of markup");
        }
    }
}
