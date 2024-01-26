using Tic_Tak_Toe;

Console.Title = "Two Player Tic Tak Toe.";
Console.CursorVisible = false;

GridClass TestGrid = new GridClass();
PlayerClass TestPlayer = new PlayerClass(-1);
PageClass TestPage = new PageClass();

Render Refesh = new Render(TestGrid,TestPlayer,TestPage);

Refesh.RenderScreen();

Console.Read();

GameClass TicTakToe = new GameClass();
TicTakToe.Game();
    


