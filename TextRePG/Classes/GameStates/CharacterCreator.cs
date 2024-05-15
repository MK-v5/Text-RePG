using TextRePG.Classes.PlayerCharacter;
using TextRePG.Classes.PlayerCharacter.CharacterRaces;
using TextRePG.Classes.PlayerCharacter.CharacterClasses;
using TextRePG.Lib;

namespace TextRePG.Classes.GameStates
{
    public class CharacterCreator : State
    {
        public CharacterCreator(Stack<State> state, List<Character> characterList, List<Character> characterGraveYard) 
            : base(state, characterList, characterGraveYard)
        {
            this.characterList = characterList;
        }

        public override void Update()
        {
            Console.Clear();
            GUI.DrawState(this);

            GUI.DrawOptions(1, "Create Character");
            GUI.DrawOptions(2, "View Character");
            GUI.DrawOptions(-1, "Back");

            ProcessIntInput(InputManager.GetIntInput("-> "));
        }

        public override void ProcessIntInput(int input)
        {
            if(characterList.Count != characterList.Capacity)
            {
                switch (input)
                {
                    case 1:
                        ShowRaces();
                        break;

                    case 2:
                        ShowCharacters();
                        break;

                    case -1:
                        EndState = true;
                        CurrentGameState.Push(new MainMenu(CurrentGameState, characterList, characterGraveYard));
                        break;
                }
            }
            else
            {
                Console.WriteLine("Limit met: You already have 7 characters");
            }
        }

        private void ShowCharacters()
        {
            if (characterList.Count == 0)
            {
                Console.WriteLine("No characters to see here");
            }
            else
            {
                int index = 0;
                foreach(var character in characterList)
                {
                    GUI.DrawOptions(index, character.Name + $" ] {character}");
                    index++;
                }
            }
        }

        private void ShowRaces()
        {
            GUI.DrawState(this);

            GUI.DrawOptions(1, "Wolf");
            GUI.DrawOptions(2, "Cat");
            GUI.DrawOptions(3, "Fox");
            GUI.DrawOptions(4, "Dragon");

            Console.Write("\nPlease select a Race:\n");
            SelectRaces(InputManager.GetIntInput("-> "));
        }

        private void ShowClasses()
        {
            GUI.DrawState(this);

            GUI.DrawOptions(1, "Knight");
            GUI.DrawOptions(2, "Rogue");
            GUI.DrawOptions(3, "Mage");
            GUI.DrawOptions(4, "Berserker");

            Console.Write("\nPlease select a Class:\n");
            SelectClasses(InputManager.GetIntInput("-> "));
        }

        #region Character create

        /// <summary>
        /// Function called upon when selecting classes.
        /// </summary>
        /// <param name="input">The Input to check which class you chose (switch statement specific).</param>
        public void SelectClasses(int input)
        {
            while (true)
            {
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        CreateCharacter(new Knight());
                        Update();
                        break;

                    case 2:
                        Console.Clear();
                        CreateCharacter(new Rogue());
                        Update();
                        break;

                    case 3:
                        Console.Clear();
                        CreateCharacter(new Mage());
                        Update();
                        break;

                    case 4:
                        Console.Clear();
                        CreateCharacter(new Berserker());
                        Update();
                        break;
                }
            }
        }

        /// <summary>
        /// Functions creates the characters race.
        /// called upon whenever a new character is made.
        /// </summary>
        /// <param name="input">The input to check which Race you chose.</param>
        public void SelectRaces(int input)
        {
            while (true)
            {
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        CreateCharacter(new Wolf());
                        ShowClasses();
                        break;

                    case 2:
                        Console.Clear();
                        CreateCharacter(new Cat());
                        ShowClasses();
                        break;

                    case 3:
                        Console.Clear();
                        CreateCharacter(new Fox());
                        ShowClasses();
                        break;

                    case 4:
                        Console.Clear();
                        CreateCharacter(new Dragon());
                        ShowClasses();
                        break;
                }
            }
        }
        
        /// <summary>
        /// CreateCharacter() creates a new character with a seperate race and class.
        /// Both race and class affect your attributes
        /// </summary>
        /// <param name="playerCharacter"></param>
        /// <returns>returns <see cref="playerCharacter">.</returns>
        private Character CreateCharacter(Character playerCharacter)
        {
            string? nameInput;

            do
            {
                GUI.DrawState(this);
                Console.WriteLine($"\n>>> Character" +
                                $"\n> Class{playerCharacter}");


                nameInput = Console.ReadLine();

            } while(nameInput?.Length < 2 || nameInput?.Length > 18);

            //if (nameInput == null) playerCharacter.characterName = nameInput;

            characterList.Add(playerCharacter);
            return playerCharacter;
        }

        #endregion Done creating

        public override string ToString()
        {
            return "CharacterCreator";
        }
    }
}