using TextRePG.Classes.GameStates;

namespace TextRePG.Classes
{
    public class Game
    {
        private Stack<State> stateStack;

        public Game()
        {
            Init();
        }

        private void Init()
        {
            stateStack = new Stack<State>();
            stateStack.Push(new MainMenu(stateStack));
        }

        public void Run()
        {
            while (stateStack.Count > 0)
            {
                stateStack.Peek().Update();

                if (stateStack.Peek().RequestEndState())
                    stateStack.Pop();
            }

            Console.WriteLine("Thank you for playing!");
        }
    }
}