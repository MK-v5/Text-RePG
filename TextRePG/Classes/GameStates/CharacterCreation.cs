using System;
using System.Collections.Generic;
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

        public readonly string[] raceOptions = { "Wolf", "Cat", "Fox", "Dragon" };

        public readonly string[] classOptions = { "Knight", "Rogue", "Mage", "Berserker" };



        public CharacterCreation(Stacker stateStack, Context context) : base(stateStack, context)
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
                    ChooseRace();
                    Console.Clear();
                    break;

                case 2:
                    Console.WriteLine("nothing here right now");
                    Console.ReadKey();
                    break;

                case 3:
                    StateStack.PopState();
                    StateStack.PushState(State.ID.MainMenu);
                    break;
            }
        }
        void ChooseRace()
        {
            GUI.DrawOptions(raceOptions);

            Console.WriteLine("\nPlease choose a race:\n");
            SelectRace(InputManager.GetIntInput("-> "));
        }

        void ChooseClass()
        {
            GUI.DrawOptions(classOptions);

            Console.WriteLine("\nPlease choose a class:\n");
            SelectClass(InputManager.GetIntInput("-> "));
        }

        void SelectRace(int input)
        {
            switch (input)
            {
                case 1:
                    Console.Clear();
                    CreateCharacter(new Wolf());
                    ChooseClass();
                    break;

                case 2:
                    Console.Clear();
                    CreateCharacter(new Cat());
                    ChooseClass();
                    break;

                case 3:
                    Console.Clear();
                    CreateCharacter(new Fox());
                    ChooseClass();
                    break;

                case 4:
                    Console.Clear();
                    CreateCharacter(new Dragon());
                    ChooseClass();
                    break;
            }
        }

        void SelectClass(int input)
        {
            switch (input)
            {
                case 1:
                    Console.Clear();
                    CreateCharacter(new Knight());
                    StateStack.PushState(State.ID.MainMenu);
                    break;

                case 2:
                    Console.Clear();
                    CreateCharacter(new Rogue());
                    StateStack.PushState(State.ID.MainMenu);
                    break;

                case 3:
                    Console.Clear();
                    CreateCharacter(new Mage());
                    StateStack.PushState(State.ID.MainMenu);
                    break;

                case 4:
                    Console.Clear();
                    CreateCharacter(new Berserker());
                    StateStack.PushState(State.ID.MainMenu);
                    break;
            }
        }

        private Character CreateCharacter(Character playerCharacter)
        {

            string? nameInput;

            do
            {
                Console.WriteLine(">>> Character: \n" +
                                    $"Race: {playerCharacter}");

                Console.WriteLine("Please enter a valid name(2 to 18 characters):");
                nameInput = Console.ReadLine();

            } while(nameInput?.Length < 2 || nameInput?.Length > 18);

            if (nameInput != null) playerCharacter.Name = nameInput;

            characterList.Add(playerCharacter);

            return playerCharacter;
        }

        public override string ToString()
        {
            return "Character Creator";
        }
    }
}
