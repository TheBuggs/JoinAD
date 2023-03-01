using System;
using System.Collections.Generic;

namespace Join2AD
{
    /* Mock Data for Directorate, Type and Location */
    static class Data
    {
        static public Dictionary<string, string> dictorates = CreateDirectoratesList();

        static public Dictionary<string, string> locations = CreateLocationsList();

        static public Dictionary<string, string> types = CreateTypesList();

        static public Dictionary<string, string> CreateOUList()
        {
            Dictionary<string, string> ous = new Dictionary<string, string>
            {

                { "OU0", "OU=OU1"+ Program.DomainOU },
                { "OU1", "OU=OU2"+ Program.DomainOU },
                { "OU2", "OU=OU3"+ Program.DomainOU },
                { "OU3", "OU=OU4"+ Program.DomainOU }

            };

            return ous;
        }

        static private Dictionary<string, string> CreateDirectoratesList()
        {
            Dictionary<string, string> directorates = new Dictionary<string, string>
            {
                { "0", "OU0" },
                { "1", "OU1" },
                { "2", "OU2" },
                { "3", "OU3" }
            };

            return directorates;
        }
        static private Dictionary<string, string> CreateLocationsList()
        {
            Dictionary<string, string> locations = new Dictionary<string, string>
            {
                { "0", "Location0" },
                { "1", "Location1" },
                { "2", "Location2" },
                { "3", "Location3" }
            };

            return locations;
        }
        static public Dictionary<string, string> CreateTypesList()
        {
            Dictionary<string, string> types = new Dictionary<string, string>
            {
                { "0", "Computer" },
                { "1", "Laptop" },
                { "2", "Tablet" },
                { "3", "Apple" },
                { "4", "VM" }
            };

            return types;
        }

        static public Dictionary<int, string> List2Location()
        {
            Dictionary<int, string> types = new Dictionary<int, string>
            {
                { 0, "A" },
                { 1, "B" },
                { 2, "C" },
                { 3, "D" }
            };

            return types;
        }

        static public Dictionary<int, string> List2Type()
        {
            Dictionary<int, string> types = new Dictionary<int, string>
            {
                { 0, "P" },
                { 1, "L" },
                { 2, "T" },
                { 3, "A" },
                { 4, "V" }
            };

            return types;
        }

        static public Dictionary<int, string> List2OU()
        {
            Dictionary<int, string> ous = new Dictionary<int, string>
            {
                { 0, "OU=Location0," + Program.DomainOU },
                { 1, "OU=Location1," + Program.DomainOU },
                { 2, "OU=Location2," + Program.DomainOU },
                { 3, "OU=Location3," + Program.DomainOU },

            };

            return ous;
        }

    }
}
