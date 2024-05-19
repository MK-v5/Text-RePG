﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TextRePG.Classes.PlayerCharacter;
using TextRePG.Lib;

namespace TextRePG.Classes.GameStates
{
    public class Menus : State
    {
        private readonly string[] options = { "Start", "Characters", "Quit" };

        public Menus(Stacker stateStack, Context context) : base(stateStack, context)
        { }

        public override void Update()
        {
            ProcessIntInput(InputManager.GetIntInput("-> "));
        }

        public override void Draw()
        {
            GUI.DrawState(this);
            GUI.DrawOptions(options);
        }

        protected override void ProcessIntInput(int input)
        {
            switch (input)
            {
                case 1:
                    StateStack.PopState();
                    break;

                case 2:
                    StateStack.PushState(State.ID.CharacterCreator);
                    Console.Clear();
                    break;

                case 3:
                    StateStack.ClearState();
                    break;
            }
        }
        public override string ToString()
        {
            return "Main Menu";
        }
    }
}
