using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnummer
{
    class Datacontainer
    {
        public static string connectionString;
        public static string anvandarnamn;
        public static string losen;
        public static string connectsource;
        public static string personnummer;
        public static string Familyname;
        public static string fornamn;
        public static SqlConnection cnn;
        public static SqlCommand command, command2;
        public static int Index;
        public static int antal_reservnummer;
        public static int antal_samordningsnummer;
        public static int antal_vanliga_personnummer;
        public static int antal_totala_poster;
        public static int[] Indexarray = new int[1000000];
        public static string SQLSearch;
        public static SqlDataReader reader,reader2;
    }
}
