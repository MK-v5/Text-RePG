using System;
using TextRePG.Classes.PlayerCharacter;

namespace TextRePG.Classes.GameStates
{
    public abstract class State
    {

        protected Stack<State> CurrentGameState; //CurrentGameState is current state of the application
        protected bool EndState; //EndState ends state of the application

        protected List<Character> characterList; //List of created characters
        protected List<Character> characterGraveYard; //List of dead characters

        private const int list_size = 7;

        public List<Character> CharacterList
        {
            get => characterList;
            protected set => characterList = value;
        }

        //Initializes a state
        protected State(Stack<State> state, List<Character> characterList, List<Character> characterGraveYard)
        {
            CurrentGameState = state;
            this.characterList = characterList;

            this.CharacterList = new List<Character>(list_size); //capping the size of the list
            this.characterGraveYard = characterGraveYard;
        }

        /// <summary>
        /// Update updates the state.
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Processes integer input.
        /// </summary>
        /// <param name="input">The input to process.</param>
        public virtual void ProcessIntInput(int input) { }

        /// <summary>
        /// Returns either True or False based upon <see cref="EndState"/>.
        /// </summary>
        /// <returns>Flag of <see cref="EndState"/>.</returns>
        public bool RequestEndState() => EndState;
    }
}