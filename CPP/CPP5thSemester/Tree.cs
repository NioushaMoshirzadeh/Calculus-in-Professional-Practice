using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class Tree
    {
        Node top;

        public Tree()
        {
            top = null;
        }
        public Tree(int initial)
        {
            top = new Node(initial);
        }

        public void Add(int value)
        {
            //non-recurse add(to add the value to the binary tree)
            if (top == null)
            {
                // add the item as the base node so we need a new node
                Node newnode = new Node(value);
                top = newnode;
                return;
            }
            Node currentNode = top;
            bool added = false; //end my loop
            do
            {
                //traverse tree
                if (value < currentNode.value)
                {
                    //go left 
                    if (currentNode.left == null)
                    {
                        //add the item
                        Node newNode = new Node(value);
                        currentNode.left = newNode;
                        added = true;
                    }
                    else
                    {
                        currentNode = currentNode.left;
                    }
                
                }
                if (value >= currentNode.value)
                {
                    if (currentNode.right == null)
                    {
                        Node newnode = new Node(value);
                        currentNode.right = newnode;
                        added = true;
                    }
                    else
                    {
                        //go right 
                        currentNode = currentNode.right;
                    }

                }

            } while (!added);

        }
        public void AddRc(int value)
        {
            //recurse add
            AddR(ref top, value);
        }
        private void AddR(ref Node N, int value)
        {
            //private recursive search for where to add the new node
            if (N == null)
            {
                //Node does not exist add it here
                Node newnode = new Node(value);
                N = newnode; // set the old Node reference to the newly created node thus attaching it to the tree
                return;//end the function calll and fall back
            }
            if (value < N.value)
            {
                AddR(ref N.left, value);
                return;
            }
            if (value >= N.value)
            {
                AddR(ref N.right, value);
                return;
            }
        }
        public void Print(Node N,ref string s)
        {
            //write out the tree in stored order to the string newstring
            //implement using recursion
            if (N == null) { N = top; }
            if (N.left != null)
            {
                Print(N.left, ref s);
                s = s + N.value.ToString().PadLeft(3);

            }
            else
            {
                s = s + N.value.ToString().PadLeft(3);
            }
            if (N.right != null)
            {
                Print(N.right, ref s);
            } 
        }
    }
}
