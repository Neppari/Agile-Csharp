using Homework_3.Controllers;
using Homework_3.Entities;
using Homework_3.UI;
using System;
using System.Collections.Generic;

namespace Homework_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUi ui = new ConsoleUi();
            ui.WelcomeText();

            ui.MainMenu();
        }
    }
}
