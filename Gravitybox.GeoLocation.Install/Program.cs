using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gravitybox.GeoLocation.Install
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting Install...");
            var stateSaver = new Dictionary<object, object>();
            var installer = new DatabaseInstaller();
            installer.Install(stateSaver);
            System.Console.WriteLine("Install Complete");
        }
    }
}
