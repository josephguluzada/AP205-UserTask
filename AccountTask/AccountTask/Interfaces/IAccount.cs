using System;
using System.Collections.Generic;
using System.Text;

namespace AccountTask.Interfaces
{
    interface IAccount
    {
        bool PasswordChecker(string password);

        void ShowInfo();
    }
}
