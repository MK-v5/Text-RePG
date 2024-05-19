using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Classes.PlayerCharacter;
using TextRePG.Classes.PlayerCharacter.CharacterRaces;
using TextRePG.Lib;

namespace TextRePG.Classes.GameStates
{
    public class CharacterCreation : State
    {

        public readonly string[] options = { "Create Character", "View Characters", "Main Menu" };

        public readonly string[] raceOptions = { "Wolf", "Cat", "Fox", "Dragon" };

        public readonly string[] classOptions = { "Knight", "Rogue", "Mage", "Berserker" };

        public CharacterCreation(Stacker stateStack, Context context, List<Character> characterList, List<Character> DeadCharacters) : base(stateStack, context, characterList, DeadCharacters)
        { this.characterList = CharacterList; }

        public override void Draw()
        {
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
                    break;

                case 2:
                    Console.WriteLine("nothing here right now");
                    Console.ReadKey();
                    break;

                case 3:
                    StateStack.ClearState();
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

        private Character CreateCharacter(Character playerCharacter)
        {

            characterList.Add(playerCharacter);

            return playerCharacter;
        }
    }
}
