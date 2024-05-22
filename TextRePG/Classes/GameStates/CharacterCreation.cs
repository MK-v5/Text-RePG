using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Classes.PlayerCharacter;
using TextRePG.Classes.PlayerCharacter.CharacterClasses;
using TextRePG.Classes.PlayerCharacter.CharacterRaces;
using TextRePG.Lib;

namespace TextRePG.Classes.GameStates
{
    public class CharacterCreation : State
    {

        public readonly string[] options = { "Create Character", "View Characters", "Main Menu" };

        public CharacterCreation(Stacker stateStack, Context context)
            : base(stateStack, context)
        { characterList = CharacterList; }

        public override void Draw()
        {
            Console.Clear();
            GUI.DrawState(this);
            GUI.DrawOptions(options);
        }

        public override void Update()
        {
            ProcessIntInput(InputManager.GetIntInput("-> "));
        }

        protected override void ProcessIntInput(int input)
        {
            switch (input)
            {
                case 1:
                    StateStack.PopState();
                    StateStack.PushState(State.ID.RaceSelect);
                    break;

                case 2:
                    ShowCharacters();
                    break;

                case 3:
                    StateStack.PopState();
                    StateStack.PushState(State.ID.MainMenu);
                    break;
            }
        }

        void ShowCharacters()
        {
            if(characterList.Count == 0)
            {
                Console.WriteLine("No characters to see here");
            }
            else
            {
                Console.WriteLine(CharacterList);
            }
        }

        protected Character CreateCharacter(Character playerCharacter)
        {
            Console.Clear();

            Console.WriteLine($"Race: {playerCharacter.characterRace}" +
                            $"\nClass: {playerCharacter.characterClass}");

            characterList.Add(playerCharacter);
            return playerCharacter;
            Console.ReadKey();
        }

        public override string ToString()
        {
            return "Character Creator";
        }
    }

    #region Selects

    public class RaceSelect : CharacterCreation
    {

        public readonly string[] raceOptions = { "Wolf", "Cat", "Fox", "Dragon" };

        public RaceSelect(Stacker stateStack, Context context) 
        : base (stateStack, context) 
        { characterList = CharacterList; }

        public override void Draw()
        {
            Console.Clear();
            GUI.DrawOptions(raceOptions);

            Console.WriteLine("\nPlease choose a race:\n");
            SelectRace(InputManager.GetIntInput("-> "));
        }

        void SelectRace(int input)
        {
            switch (input)
            {
                case 1:
                    characterList.Add(new Wolf());
                    StateStack.PopState();
                    StateStack.PushState(State.ID.ClassSelect);
                    break;

                case 2:
                    characterList.Add(new Cat());
                    StateStack.PopState();
                    StateStack.PushState(State.ID.ClassSelect);
                    break;

                case 3:
                    characterList.Add(new Fox());
                    StateStack.PopState();
                    StateStack.PushState(State.ID.ClassSelect);
                    break;

                case 4:
                    characterList.Add(new Dragon());
                    StateStack.PopState();
                    StateStack.PushState(State.ID.ClassSelect);
                    break;
            }
        }

        public override string ToString()
        {
            return "Race Select";
        }
    }

    public class ClassSelect : CharacterCreation
    {

        public readonly string[] classOptions = { "Knight", "Rogue", "Mage", "Berserker" };

        public ClassSelect (Stacker stateStack, Context context) : base (stateStack, context)
        { characterList = CharacterList; }

        public override void Draw()
        {
            Console.Clear();
            GUI.DrawOptions(classOptions);

            Console.WriteLine("\nPlease choose a class:\n");
            SelectClass(InputManager.GetIntInput("-> "));
        }

        void SelectClass(int input)
        {
            switch (input)
            {
                case 1:
                    CreateCharacter(new Knight());
                    StateStack.PopState();
                    StateStack.PushState(State.ID.CharacterCreator);
                    break;

                case 2:
                    CreateCharacter(new Rogue());
                    StateStack.PopState();
                    StateStack.PushState(State.ID.CharacterCreator);
                    break;

                case 3:
                    CreateCharacter(new Mage());
                    StateStack.PopState();
                    StateStack.PushState(State.ID.CharacterCreator);
                    break;

                case 4:
                    CreateCharacter(new Berserker());
                    StateStack.PopState();
                    StateStack.PushState(State.ID.CharacterCreator);
                    break;
            }
        }

        public override string ToString()
        {
            return "Class Select";
        }
    }

    #endregion end selects

}
