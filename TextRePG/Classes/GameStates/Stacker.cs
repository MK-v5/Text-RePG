using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRePG.Classes.GameStates
{
    /// <summary>
    /// 
    /// </summary>
    public class Stacker
    {
        public enum Action
        {
            Push, // pushes in a new state.
            Pop, // pops the current state.
            Clear // clears out the states.
        }

        private struct ChangeQueue
        {
            public readonly Action Action;
            public readonly State.ID stateId;

            public ChangeQueue(Action rAction, State.ID rSiD)
            {
                Action = rAction;
                stateId = rSiD;
            }
        }


        #region Dictionairies

        private readonly Dictionary<State.ID, Func<State?>> factories = new();

        private readonly State.Context Context;

        private readonly List<ChangeQueue> queueList = new List<ChangeQueue>();

        public readonly Stack<State?> stateStack = new();

        public Stacker(State.Context context)
        {
            Context = context;
        }

        #endregion end Dictionaries

        /// <summary>
        /// Registers a state type with the state stack.
        /// </summary>
        /// <typeparam name="Type">The type of the state to register.</typeparam>
        /// <param name="iD">the ID of the state to register.</param>
        public void RegisterState<Type>(State.ID iD) where Type : State
        {
            factories[iD] = () => Activator.CreateInstance(typeof(Type), this, Context) as Type;
        }

        public void Update()
        {
            foreach(var state in stateStack)
            {
                state?.Update();
            }
            ApplyQueuedChanges();
        }

        public void Draw()
        {
            foreach(var state in stateStack)
            {
                state?.Draw();
            }
        }

        public void PushState(State.ID iD)
        {
            queueList.Add(new ChangeQueue(Action.Push, iD));
        }

        public void PopState()
        {
            queueList.Add(new ChangeQueue(Action.Pop, State.ID.None));
        }

        public void ClearState()
        {
            queueList.Add(new ChangeQueue(Action.Clear, State.ID.None));
        }

        public void ApplyQueuedChanges()
        {
            foreach(var change in queueList)
            {
                switch (change.Action)
                {
                    case Action.Push:
                        stateStack.Push(CreateState(change.stateId));
                        break;

                    case Action.Pop:
                        stateStack.Pop();
                        break;

                    case Action.Clear:
                        stateStack.Clear();
                        break;
                }
            }
            queueList.Clear();
        }

        private State? CreateState(State.ID iD)
        {
            if (factories.TryGetValue(iD, out var factory))
            {
                return factory.Invoke();
            }

            throw new ArgumentException($"State ID not regocnized: {iD}");
        }
    }
}
