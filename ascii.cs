using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace psgoWurple
{
    public class ascii
    {
        private string xcords = "ABCDEFGHJKLMNOPQRST";
        private string alphabet = "abcdefghijklmnopqrstuvwxyz";
        private string numeric = "012345678910";
        private bool Black = false;

        public ascii(string input, string output)
        {
            if (File.Exists(input))
            {
                string tmp;
                int bSize = 0;
                using (StreamReader sr = new StreamReader(input))
                using (StreamWriter sw = new StreamWriter(output))
                {
                    tmp = sr.ReadLine();
                    if (tmp.StartsWith("$$B"))
                    {
                        Black = true;
                    }
                    else
                        sw.WriteLine("\\pass*");
                    tmp = sr.ReadLine();
                    bSize = (tmp.Length - 3) / 2;
                    bSize--;
                    sw.WriteLine("\\setcounter{gomove}{0}");
                    sw.WriteLine("\\begin{psgoboard}["+bSize+"]");
//                    Console.WriteLine("Read line length {0} bSize {1}", tmp.Length, bSize);
                    int row = 0;
                    while (sr.EndOfStream == false)
                    {
                        row++;
                        tmp = sr.ReadLine();
                        for (int i = 1; i <  bSize + 1; i ++)
                        {
 /* White stone: O, marked with circle: W, marked with square: @ 
Black stone: X, marked with circle: B, marked with square: # 
Empty point: ., marked with circle: C, marked with square: S 
Use a-z (lowercase) for letters, use 1-9,0 for numbers on stones    */
                            int ii = 3 + (2 * i);
                            string tSymbol = tmp.Substring(ii, 1);
                            //Console.WriteLine("Row {0} i {1} char {2}", row,ii,tSymbol);
                            //Console.ReadKey();
                            switch (tSymbol)
                            {
                                case "O":
                                    sw.WriteLine("\\stone{white}{" + xcords.Substring(i-1,1) + "}{" + (20-row) + "}");
                                    break;
                                case "X":
                                    sw.WriteLine("\\stone{black}{" + xcords.Substring(i - 1, 1) + "}{" + (20 - row) + "}");
                                    break;
                                case "W":
                                    sw.WriteLine("\\stone[\\markcr]{white}{" + xcords.Substring(i - 1, 1) + "}{" + (20 - row) + "}");
                                    break;
                                case "@": //you might prefer marksq !
                                    sw.WriteLine("\\stone[\\marksl]{white}{" + xcords.Substring(i - 1, 1) + "}{" + (20 - row) + "}");
                                    break;
                                case "B":
                                    sw.WriteLine("\\stone[\\markcr]{black}{" + xcords.Substring(i - 1, 1) + "}{" + (20 - row) + "}");
                                    break;
                                case "#": //you might prefer marksq !
                                    sw.WriteLine("\\stone[\\marksl]{black}{" + xcords.Substring(i - 1, 1) + "}{" + (20 - row) + "}");
                                    break;
                                case "C":
                                    sw.WriteLine("\\markpos[\\markcr]{" + xcords.Substring(i - 1, 1) + "}{" + (20 - row) + "}");
                                    break;
                                case "S": //you might prefer marksq !
                                    sw.WriteLine("\\markpos[\\marksl]{" + xcords.Substring(i - 1, 1) + "}{" + (20 - row) + "}");
                                    break;
                            }
                            if (alphabet.Contains(tSymbol))
                            {
                                sw.WriteLine("\\markpos[\\marklb{" + tSymbol.ToUpper() + "}]{" + xcords.Substring(i - 1, 1) + "}{" + (20 - row) + "}");
                            }
                            if (numeric.Contains(tSymbol))
                            {
                                sw.WriteLine("\\move{" + tSymbol.ToUpper() + "}]{" + xcords.Substring(i - 1, 1) + "}{" + (20 - row) + "}");
                            }
                        }
                    }
                }
            }
            else
                Console.WriteLine("The input file {0} was not found", input);
        }
    }
}
