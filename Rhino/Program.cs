using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading.Tasks;
using Rhino.Mocks;

namespace Rhino
{
    public interface IX
    {
        bool HasSomething { get; }
    }

    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var x1 = MockRepository.GenerateMock<IX>();
                x1.Stub(x => x.HasSomething).Return(true).Repeat.Once();
                x1.Stub(x => x.HasSomething).Return(false);

                Console.WriteLine(x1.HasSomething);
                Console.WriteLine(x1.HasSomething);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine($"{progname} Error: {ex.Message}");
            }

        }
    }
}
