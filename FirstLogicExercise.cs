using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1 ; i <= n ; i++)
        {
            if(i % 3 == 0 && i % 5 == 0)
            {
                Console.Write("foobar, ");
            }
            else if(i % 3 == 0)
            {
                Console.Write("foo, ");
            }
            else if(i % 5 == 0)
            {
                Console.Write("bar, ");
            }
            else
            {
                Console.Write(i + ", ");
            }
        }
        
    }

    
}