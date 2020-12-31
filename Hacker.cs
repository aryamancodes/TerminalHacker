using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hacker : MonoBehaviour
{

    //Game config data

    string[] Passwords1 = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] Passwords2 = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] Passwords3 = { "starfield", "telescope", "environment", "exploration", "astronauts" };
    const string menuHint = "You may type 'menu' at any time to go  back to the main menu";

    //Game State
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;
    

    // Use this for initialization
    void Start()
    {
        ShowMainMenu("Aryaman");
    }

    void ShowMainMenu(string name)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + name);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA!");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu(" ");
        }

        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }

        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }



    }

    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");

        if (isValidLevel)
        {
            level = int.Parse(input);
            StartGame();

        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level, Mr Bond");
        }

        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = Passwords1[Random.Range(0, Passwords1.Length)];
                break;
            case 2:
                password = Passwords2[Random.Range(0, Passwords2.Length)];
                break;

            case 3:
                password = Passwords3[Random.Range(0, Passwords3.Length)];
                break;

            default:
                Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            WinScreen();
        }

        else
        {
            StartGame();
        }
    }


    void WinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();

        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/           
"
                );
                break;

            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '         
"
                );
                break;

            case 3:
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___)\__,_|
"
                );
                Terminal.WriteLine("Welcome to NASA's internal system!");
                break;

            default:
                Debug.LogError("Invalid level reached");
                break;
        }

        Terminal.WriteLine(menuHint);

    }

   

}
