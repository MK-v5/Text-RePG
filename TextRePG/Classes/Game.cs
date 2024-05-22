using TextRePG.Classes.GameStates;
using TextRePG.Classes.PlayerCharacter;

namespace TextRePG.Classes
{
    public class Game
    {

        private readonly Stacker stacker;

        public Game()
        {

            stacker = new Stacker(new State.Context());
            RegisterState();

            stacker.PushState(State.ID.MainMenu);

            stacker.ApplyQueuedChanges();
        }

        private void RegisterState()
        {
            stacker.RegisterState<Menus>(State.ID.MainMenu);
            stacker.RegisterState<CharacterCreation>(State.ID.CharacterCreator);
            stacker.RegisterState<RaceSelect>(State.ID.RaceSelect);
            stacker.RegisterState<ClassSelect>(State.ID.ClassSelect);
            stacker.RegisterState<Combat>(State.ID.Combat);
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