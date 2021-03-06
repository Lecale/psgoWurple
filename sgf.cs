﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace psgoWurple
{
    public class sgf
    {
        public sgf(string input, string output)
        {
            int totalNodes = -1;

            using (StreamReader sr = new StreamReader(input))
            using (StreamWriter sw = new StreamWriter(output))
            {
                string everything = sr.ReadToEnd();
                
                // Create the nodes, a node needs a ancestor/decendant
                List<int> OpenBracket = new List<int>();
                List<int> CloseBracket = new List<int>();

                for (int i = 0; i < everything.Length; i++)
                {
                    if (everything.Substring(i, 1).Equals("("))
                        OpenBracket.Add(i);
                    if (everything.Substring(i, 1).Equals(")"))
                        CloseBracket.Add(i);
                    totalNodes = OpenBracket.Count;
                    }

                int distant = CloseBracket[totalNodes - 1] - OpenBracket[0];
                Node noddy = new Node(everything.Substring(OpenBracket[0]+1, distant-1), null);
                Console.WriteLine("Nodes " + totalNodes + "Diagrams " + noddy.nDiagrams());

                //Now that we have our nodes constructed, we need to identify the diagrams and build them!

                List<string> ft = noddy.getDiagramTrees(new List<string>());
                List<string> diagramList = new List<string>();
                foreach (string f in ft)
                {
                    if (f.Contains("DIAGRAM_START") && f.Contains("DIAGRAM_END")) //perhaps too lax? could lead to duplicate diagrams
                    {
                        diagramList.Add(f);
                        Console.WriteLine(f);
                        Console.WriteLine(" - - - - - ");
                    }
                }

                DiagramBasic db = new DiagramBasic(diagramList[0], 0);
            }


        }

        //It is necessary to create a series of game trees in order to create all the diagrams
        //We must not only know where the diagrams start and finish, but if stones are captured or not
        //To do so, we must implement some logic!

    }
}
