using TextRePG.Classes.GameStates;

namespace TextRePG.Lib
{
    public class GUI
    {
        /// <summary>
        /// Draws the current state.
        /// </summary>
        /// <param name="state">The current state.</param>
        public static void DrawState(State state)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"||{state.ToString()}||");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DrawOptions(int index, string option)
        {
            Console.WriteLine($"[{index}] {option}");
        }
    }
}