using System.Collections.Generic;
using System.Diagnostics;

namespace GuyGame.DB
{
    public abstract class IApiDB
    {
        public static readonly List<string> listOfCategories;    // List of all the categorries of the api
        public static readonly Dictionary<string, string>  listOfDifficulties; // Lis of all the difficulties of the api
        public static readonly Dictionary<string, string>  listOfTypes;    // Lis of all the difficulties of api
    }
}