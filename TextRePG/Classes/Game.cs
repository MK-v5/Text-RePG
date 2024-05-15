using TextRePG.Classes.GameStates;
using TextRePG.Classes.PlayerCharacter;

namespace TextRePG.Classes
{
    public class Game
    {

        private Stack<State> stateStack; //created stack for the state class
        private List<Character>? characterList; //create an arrayList for the characters
        private List<Character>? characterGraveYard; // create a list of deceased characters


        public Game()
        {
            Init();
        }

        private void Init()
        {
            stateStack = new Stack<State>();//initialize the currentState
            characterList = new List<Character>(); //initalize the list of characters
            characterGraveYard = new(); //initalize deceased characters


            stateStack.Push(new MainMenu(stateStack, characterList, characterGraveYard));
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