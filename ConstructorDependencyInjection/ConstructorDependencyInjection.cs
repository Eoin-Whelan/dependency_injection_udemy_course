/*
 *  Point of this project is to explain class coupling.
 *  We can observe ProgramWithHighCoupling is commented out to allow
 *  a demonstration of efforts to reduce coupling by establishing interface
 *  classes with each of these "layers" (i.e. UI -> Business -> DataAccess
 *  
 *  By introducing these interfaces, we reduce the coupling of the concrete classes
 *  
 *  HOWEVER this does not implement dependency injection as of 10/04/2021 as it has not been
 *  covered yet.
 */

using System;

namespace DependencyInjectionCourse
{
    class ProgramWithHighCoupling
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class UserInterface
    {
        private readonly IBusiness _bidness;
        private readonly IDataAccess dal;

        public UserInterface(IBusiness bidness)
        {
            _bidness = bidness;
        }
        public void GetData()
        {
            Console.WriteLine("Please enter your username");
            var userName = Console.ReadLine();

            Console.WriteLine("Please enter your password");
            var password = Console.ReadLine();


            _bidness.SignUp(userName, password);
        }
    }

    public class Business : IBusiness
    {
        private readonly IDataAccess _dataAccess;
        public Business(IDataAccess DataAccess)
        {
            _dataAccess = DataAccess;
        }
        public void SignUp(string username, string password)
        {
            //  Validation
            _dataAccess.Store(username, password);
        }
    }

    //  By implementing the interface, we establish that even with a new
    //  Version of the business layer, we need only implement the interface
    //  to establish a class with all of the same method/signatures.
    public class BusinessV2 : IBusiness
    {
        public void SignUp(string username, string password)
        {

        }
    }

    public class DataAccess : IDataAccess
    {
        public void Store(string username, string password)
        {
            //  Writes to DB
        }
    }



    public interface IBusiness
    {
        void SignUp(string username, string password);
    }
    public interface IDataAccess
    {
        void Store(string username, string password);
    }

}
