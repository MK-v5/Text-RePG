using System;

namespace TextRePG.Classes.GameStates
{
    public abstract class State
    {

        protected Stack<State> CurrentGameState; //CurrentGameState is current state of the application
        protected bool EndState; //EndState ends state of the application

        //Initializes a state
        protected State(Stack<State> state)
        {
            CurrentGameState = state;
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
