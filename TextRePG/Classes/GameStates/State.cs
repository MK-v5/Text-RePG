using System;
using TextRePG.Classes.PlayerCharacter;

namespace TextRePG.Classes.GameStates
{
    public abstract class State
    {
        protected List<Character> characterList; //List of created characters

        private const int list_size = 7;

        /// <summary>
        /// ID's of the states you want to implement.
        /// </summary>
        public enum ID
        {
            MainMenu,
            CharacterCreator,
            ClassSelect,
            RaceSelect,
            Combat,
            Game,
            Pause,
            None
        }

        /// <summary>
        /// Context that each State has.
        /// Easily modified to include data you need. (keep this in mind)
        /// 
        /// include every common property you need, things like health
        /// </summary>
        public struct Context
        {

            /// <summary>
            /// Context constructor, Making sure i include the properties i want to 
            /// have intialized in the arguments.
            /// 
            /// 
            /// </summary>
            public Context(List<Character> characters)
            {
                Characters = characters;
            }

            public readonly List<Character> Characters;

        }

        protected Stacker StateStack;
        protected Context StateContext;

        public List<Character> CharacterList
        {
            get => characterList;
            protected set => characterList = value;
        }

        //Initializes a state
        protected State(Stacker stateStack, Context stateContext)
        {
            StateStack = stateStack;
            StateContext = stateContext;

            this.CharacterList = characterList;
            this.CharacterList = new List<Character>(list_size); //capping the size of the list
        }

        #region Voids

        /// <summary>
        /// Update updates the state.
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Draws out the state.
        /// </summary>
        public virtual void Draw() { }

        /// <summary>
        /// Processes integer input.
        /// </summary>
        /// <param name="input">The input to process.</param>
        protected virtual void ProcessIntInput(int input) { }

        #endregion end Voids

    }
}
