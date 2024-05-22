using TextRePG.Classes;
using TextRePG.Classes.GameStates;

namespace TextRePG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game game = new Game();
            game.Run();
        }
    }
}