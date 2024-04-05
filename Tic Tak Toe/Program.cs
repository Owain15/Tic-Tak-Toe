using Tic_Tak_Toe.HomePage;
using Tic_Tak_Toe.Resources;
using Tic_Tak_Toe.Game;
using Tic_Tak_Toe.Game.SuperTicTakToe;
using Tic_Tak_Toe.Games.TicTakToe;

Console.Title = "Tic Tak Toe.";
Console.CursorVisible = false;
Console.SetWindowSize(Console.LargestWindowWidth,Console.LargestWindowHeight);

//maxamise Screen request?


int[] GameLocation = { 51, 1 };//Defult 51,1
bool CloseApplication = false;

SingleGameTTT Test = new SingleGameTTT(GameLocation, true, 5);
Test.Run();

Tic_Tak_Toe.HomePage.HomePage Start = new Tic_Tak_Toe.HomePage.HomePage(GameLocation);


Start.ApplicationLoop();

Environment.Exit(0);


    


