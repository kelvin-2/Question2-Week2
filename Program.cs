using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Task2
{
    internal class Program
    {
        Stacklist stacklist;
        static void Main(string[] args)
        {
            new Program();
        }
        public Program()
        {
          stacklist=new Stacklist();
          ReadData();
          stacklist.WriteOutput();
        }
        public void ReadData()
        {
           
            StreamReader sr = new StreamReader("TestInputs.txt");
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                //extract the sign from the number 
                string sign =line.Substring(0, 1);
                
                WriteLine(sign);
                if (sign == "+")
                {
                    //push the element onto the stack 
                    stacklist.push(line.Substring(1));
                }
                else
                {
                    //remove the number  
                    stacklist.pop();
                }
            }
        }
    }
    class Stacklist
    {
        private int count = 0;
        private Node listHead;
        public Stacklist()
        {
            listHead = null;
        }
        public int Count()
        {
            return count;
        }
        /// <summary>
        /// removing elements from the stack, change the head to point to the next element 
        /// </summary>
        public void pop()
        { 
            
            if (listHead == null)
            {
                WriteLine("the stack is empty");
            }
            else
            {
                //update the head pointer
                listHead = listHead.Next;
            }

        }

        /// <summary>
        /// adding elements into the list 
        /// </summary>
        /// 
        public void push(string val)
        {
            //Creates a new Node and assigns it as the new head of the list
            count ++;
            Node newNode = new Node(val);
            if (listHead == null)
            {
                listHead = newNode;
            }
            else
            {
                newNode.Next = listHead;
                listHead = newNode;
            }
        }

        /// <summary>
        /// view the tail 
        /// </summary>
        public string peek()
        {
            return listHead.name;
        }
        public void WriteOutput()
        {
            StreamWriter wr = new StreamWriter("Output.txt");
            Node temp = listHead;
            while (temp != null)
            {
                wr.WriteLine(temp.name);
                temp = temp.Next;
            }
            wr.Close();
        }

    }
    class Node
    {
        public Node Next;
        public string name;
       

        public Node(string name)
        {
            this.Next = null;
            this.name = name;
        }
        public string Name()
        {
            return name;
        }
    }
}
