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

PlayerClass P1 = new PlayerClass(1, false);
PlayerClass P2 = new PlayerClass(-1, true);

SingleGameTTT Test = new SingleGameTTT(GameLocation, true, 5, P1, P2);
Test.Run();

Tic_Tak_Toe.HomePage.HomePage Start = new Tic_Tak_Toe.HomePage.HomePage(GameLocation);


Start.ApplicationLoop();

Environment.Exit(0);


    


