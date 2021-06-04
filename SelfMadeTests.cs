using System.Collections.Generic;
using static Lesson7.Assert;
using static Lesson7.TestMessages;

namespace Lesson7
{
    internal sealed class SelfMadeTests
    {
        private static void StartTest()
        {
            List<int> num = new List<int>() {3, 4, 5, 3, 4, 3, 1};
            List<string> str = new List<string>() {"ad", "s", "ad", "pr", "pr"};
            
            Message(AssertEquals("this is test string".StringLenght(), 14));
            Message(AssertEquals("String contains \u0011".StringLenght(), 15));
            
            num.IdenticalElemCount().ShowUniqElem();
            str.IdenticalElemCount().ShowUniqElem();
        }
        
        private static void Main(string[] args)
        {
            StartTest();
        }
    }
}