using TextRePG.Classes.GameStates;
using TextRePG.Classes.PlayerCharacter;

namespace TextRePG.Classes
{
    public class Game
    {

        private readonly Stacker stacker;

        /*
        private Stack<State> stateStack; //created stack for the state class
        private List<Character>? characterList; //create an arrayList for the characters
        private List<Character>? characterGraveYard; // create a list of deceased characters
        */

        public Game()
        {

            stacker = new Stacker(new State.Context(10));
            RegisterState();

            stacker.PushState(State.ID.MainMenu);

            stacker.ApplyQueuedChanges();
        }

        private void RegisterState()
        {
            stacker.RegisterState<Menus>(State.ID.MainMenu);
            stacker.RegisterState<CharacterCreation>(State.ID.CharacterCreator);
        }

        public void Run()
        {
            while (stacker.stateStack.Count > 0)
            {
                Draw();
                Update();
            }
        }

        private void Update()
        {
            stacker.Update();
        }

        private void Draw()
        {
            stacker.Draw();
        }
    }
}