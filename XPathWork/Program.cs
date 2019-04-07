using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace XPathWork
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.ExtractToDirectory("Current.zip", "CurrentUnpackaged");
        }
    }
}
