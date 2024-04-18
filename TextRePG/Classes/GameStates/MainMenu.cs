using System.Diagnostics;
using System.Net;
using TextRePG.Lib;

namespace TextRePG.Classes.GameStates
{
    public class MainMenu : State
    {
        public MainMenu(Stack<State> state) : base(state)
        { }

        /// <summary>
        /// Update updates the state, the state is set to "Main Menu"
        /// </summary>
        public override void Update()
        {
            Console.Clear();
            GUI.DrawState(this);
            GUI.DrawOptions(1, "Play");
            GUI.DrawOptions(-1, "Quit");

            ProcessIntInput(InputManager.GetIntInput("> "));
        }

        /// <summary>
        /// Processes integer input.
        /// </summary>
        /// <param name="input">The input to process (currently in switch statement).</param>
        public override void ProcessIntInput(int input)
        {
            switch (input)
            {
                case 1:
                    EndState = true; //Ends the state
                    CurrentGameState.Push(new GameState(CurrentGameState)); //Pushes a new GameState into the stack.
                    break;

                case -1:
                    EndState = true;
                    break;
            }
        }

        /// <summary>
        /// Overrides Tostring for Current state's title (Editable in GUI).
        /// </summary>
        /// <returns>returns a string.</returns>
        public override string ToString()
        {
            return "Main Menu"; //State's title
        }
    }
}