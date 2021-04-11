///*
// *  Point of this project is to explain class coupling. 
// */

//using System;

//namespace DependencyInjectionCourse
//{
//    class ProgramWithHighCoupling
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//        }
//    }

//    public class UserInterface
//    {
//        public void GetData()
//        {
//            Console.WriteLine("Please enter your username");
//            var userName = Console.ReadLine();

//            Console.WriteLine("Please enter your password");
//            var password = Console.ReadLine();

//            var business = new Business();
//            business.signup(userName, password);
//        }
//    }

//    public class Business
//    {
//        public void signup(string username, string password)
//        {
//            //  Validation
//            var dal = new DataAccess();
//            dal.store(username, password);
//        }
//    }

//    public class DataAccess
//    {
//        public void store(string username, string password)
//        {
//            //  Writes to DB
//        }
//    }
//}
