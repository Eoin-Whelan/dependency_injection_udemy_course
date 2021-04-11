using System;
using DependencyInjectionCourse;

namespace Coupling
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataAccess dal = new DataAccess();
            IBusiness bidness = new Business(dal);
            var userInterface = new UserInterface(bidness);
        }
    }
}
