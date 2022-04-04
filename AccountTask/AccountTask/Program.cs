using AccountTask.Models;
using System;

namespace AccountTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Email daxil edin:");
            string email = Console.ReadLine();

            TryAgain:
            Console.WriteLine("Password daxil edin:");
            string password = Console.ReadLine();
            if (!User.PassWordCheckerStatic(password)) goto TryAgain;

            User user = new User(email,password);
            user.PasswordChecker(password);

            int choice;

            do
            {
                Console.WriteLine("Secim edin: \n" +
                    "1: ShowInfo\n" +
                    "2: Create New Group");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("==============================================");
                        user.ShowInfo();
                        Console.WriteLine("==============================================");
                        break;
                    case 2:
                        string groupNo = "";
                        int studentLimit = -1;
                        InputGroup(ref groupNo, ref studentLimit);
                        Group group = new Group(groupNo,studentLimit);
                        break;
                    default:
                        break;
                }

            } while (choice != 0);



        }

        static void InputGroup(ref string groupNo,ref int studentLimit)
        {
            SetGroupNoEx:
                Console.WriteLine("Please enter group no:");
            try
            {
                groupNo = Console.ReadLine();
                groupNo.Trim();
                
                if (!String.IsNullOrEmpty(groupNo) && !String.IsNullOrWhiteSpace(groupNo) && groupNo.Length == 5)
                {
                    int upperLetterCount = 0;
                    int digitCount = 0;
                    bool isOk = false;
                    for (int i = 0; i < groupNo.Length; i++)
                    {
                        if (i < 2)
                        {
                            if (char.IsUpper(groupNo[i])) upperLetterCount++;
                        }
                        else if (upperLetterCount == 2 && i >= 2)
                        {
                            if (char.IsDigit(groupNo[i])) digitCount++;
                        }
                        if (upperLetterCount == 2 && digitCount == 3) isOk = true;
                    }
                    if (isOk == false) throw new Exception();

                }
                else throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter correctly");
                goto SetGroupNoEx;
            }
            StudentLimitEx:
            try
            {
                Console.WriteLine("Please enter student limit:");
                studentLimit = Convert.ToInt32(Console.ReadLine());
                if (studentLimit < 5 || studentLimit > 18) throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter correctly");
                goto StudentLimitEx;
            }
           

        }
    }
}
