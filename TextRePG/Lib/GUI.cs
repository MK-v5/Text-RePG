﻿using TextRePG.Classes.GameStates;

namespace TextRePG.Lib
{
    public class GUI
    {
        /// <summary>
        /// Draws the current state.
        /// </summary>
        /// <param name="state">The current state.</param>
        public static void DrawState(State state)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"||{state}||");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Draws the options in a state.
        /// </summary>
        /// <param name="options">The available options.</param>
        public static void DrawOptions(string[] options)
        {
            for(int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {options[i]}"); //goes through i to display the options.
            }
        }
    }
}