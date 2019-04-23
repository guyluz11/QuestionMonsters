using System.Collections;
using NUnit.Framework;

namespace GuyGame.Tests
{
    public class DBTestData
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(1, 1, "Easy", "Multiple Choice");
                yield return new TestCaseData(1, 1, "Easy", "True / False");
                
            }    
        }
        
    }
}