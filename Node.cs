using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psgoWurple
{
    public class Node
    {
        public Node ancestor = null;
        public List<Node> descendent = null;
        public string innards = null;
        public string familyTree = null;
        static int NodeKey = 0;

        public Node(string s, Node tata = null)//, List<Node> baby = null)
        {
            NodeKey++;
            ancestor = tata;
            descendent = new List<Node>();
            int upDownCount = 0;
            int startyBit = 0;
            int stoppyBit = 0;
            // Set Actual Text of this Node
            if (s.Contains("("))
                innards = s.Substring(0, s.IndexOf("("));
            else
                innards = s;
            familyTree = innards;
            // Hunt for internal Node
            if (s.Contains("(") && s.Contains(")"))
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s.Substring(i, 1).Equals("("))
                    {
                        upDownCount++;
                        if (upDownCount == 1)
                            startyBit = i;
                    }
                    if (s.Substring(i, 1).Equals(")"))
                    {
                        upDownCount--;
                        if (upDownCount == 0)
                        {
                            stoppyBit = i;
                            string guts = s.Substring(startyBit + 1, stoppyBit - startyBit - 1);
                            descendent.Add(new Node(guts, this));
                        }
                    }
                }
            }

//            Console.WriteLine("I am the {0} Node:{1}", NodeKey, s);
//            Console.WriteLine("familytree {0} ", familyTree.Replace("\n",""));

        }

        public bool HasImmediateDiagram()
        {
            if (innards.Contains("DIAGRAM_START") && innards.Contains("DIAGRAM_END"))
                return true;
            return false;
        }

        public int nDiagrams()
        {
            int dCount = 0;
            if (HasImmediateDiagram())
                dCount++;
            foreach (Node nunu in descendent)
            {
                dCount += nunu.nDiagrams();
            }
            return dCount;
        }

        public List<string> getDiagramTrees(List<string> dt)
        {
            if (ancestor != null)
                familyTree = ancestor.familyTree + innards;


            dt.Add(familyTree);
            foreach(Node n in descendent) 
            {
                List<string> hereItIs = n.getDiagramTrees(dt);
            }
            return dt;
        }

    }
}
 