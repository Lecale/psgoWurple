using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psgoWurple
{
    /*
     * 
DIAGRAM_START
DIAGRAM_END
FULL_BOARD N
PART_BOARD BL TR
START_MOVE_NBR N
PREV_NBR_MOVE N 
     */
    public class DiagramBasic
    {
        public List<string> latex;
        public string[] Tokens;
        public List<Token> theTokens;
        public bool GoodFormat;

        public int movesBefore = 0;
        public int moveStart = 0;
        public int bdSize = 19;
        

        public DiagramBasic(string sgf, int ID)
        {
            theTokens = new List<Token>();
            latex = new List<string>();
            Tokens = sgf.Split(new char[] { ';' }); // if the last Token is not a comment - the diagram is not well formatted
            foreach (string t in Tokens)
            {
                if (t.Trim().Length > 3 && t.Contains("["))
                {
                        Token tt = new Token(t);
                        if (tt.Valid())
                        {
                            theTokens.Add(tt);
                            Console.WriteLine("Valid Token:\t{0}", tt);
                        }
                }
                Console.WriteLine("Token count now {0}",theTokens.Count);
            }
            MarkUp theComment = theTokens[theTokens.Count - 1].getComment();
            movesBefore = theComment.mvP;
            moveStart = theComment.mv1;
            bdSize = theComment.BdSize;

            //Now we need to construct the board
            //Mark N moves on the board
            //Add additional mark up
        }
    }
}
