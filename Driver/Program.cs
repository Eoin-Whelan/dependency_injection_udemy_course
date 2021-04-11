/*
 * To dilineate which form of dependency injection you wish, please check Driver's references
 * list for which project it is to use. Because ConstructorInjection and ServiceCollectionInjection
 * both use Business/DataAccess/UserInterface classes, they cannot both be added as references and
 * function accordingly. You *must* specify which method you choose and work from there.
 */

using Microsoft.Extensions.DependencyInjection;
using DependencyInjectionCourse;
using ScopedVsTransientLib;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace DependencyInjectionCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            ////  ServiceCollection Dependency Injection Implementation

            ////  Creates a new ServiceCollection and adds scoped requirements.
            //var collection = new ServiceCollection();
            //collection.AddScoped<IDataAccess, DataAccess>();
            ////collection.AddScoped<IBusiness, Business>();

            ///*  This is possible also, as now if we wanted to migrate the
            // *  Functionality of our application from Business to BusinessV2,
            // *  We need only change that parameter in the AddScoped method.
            //*/
            //collection.AddScoped<IBusiness, BusinessV2>();

            //collection.AddScoped<IUserInterface, UserInterface>();

            ////  We create a ServiceProvider class
            //var provider = collection.BuildServiceProvider();

            ////  Inject the classes into our objects.
            ////IDataAccess dal = provider.GetService<IDataAccess>();

            ///*  With ServiceCollection, once we've mapped the scope of what we
            // *  need in our collection class, the provider is then able to generate
            // *  the necessary classes in order to build the final class, which in
            // *  this case, is the Business class. The DataAccess class is generated
            // *  upon the instantiation of the Business to be added in as a param in
            // *  the final class's construction.
            // */
            //var UI = provider.GetService<IUserInterface>();

            //UI.GetData();

            //////  Constructor Dependency Injection
            ////IDataAccess dal = new DataAccess();
            ////IBusiness bidness = new Business(dal);
            ////var userInterface = new UserInterface(bidness);

            ////  ScopedVsTransient Implementation

            /*
             * Here we've added the newly created classes to the service collection
             * scope. We've mapped the classes without an interface, which is possible.
             */
            var collection = new ServiceCollection();
            collection.AddScoped<ScopedClass>();
            collection.AddTransient<TransientClass>();

            var builder = collection.BuildServiceProvider();

            //  Mutex used to allow a clearer output to show subsequent IDs.
            System.Threading.Mutex mutex = new Mutex();

            
            Console.Clear();
            Parallel.For(1, 10, i => {
                mutex.WaitOne();
                //  We observe each of the scoped class hashcode ids are the same as the instance exists across each thread.
                Console.WriteLine($"Scoped ID = {builder.GetService<ScopedClass>().GetHashCode().ToString()}");
                //  However, across each transient class the hashcode will be different as they are newly generated upon each thread creation.
                Console.WriteLine($"Transient ID = {builder.GetService<TransientClass>().GetHashCode().ToString()}");
                mutex.ReleaseMutex();
            });

        }
    }
}
