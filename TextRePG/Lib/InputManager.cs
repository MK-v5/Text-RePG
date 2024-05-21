namespace TextRePG.Lib
{
    public static class InputManager
    {

        /// <summary>
        /// Receives integer input and returns it.
        /// </summary>
        /// <param name="prompt">Prompt stands for the prompt to enter integer.</param>
        /// <returns>int named input</returns>
        public static int GetIntInput(string prompt)
        {
            while(true)
            {
                Console.Write(prompt);
                
                if(int.TryParse(Console.ReadLine(), out int input))
                {
                    return input;
                }

                Console.WriteLine("Please Put in a valid input(e.g. integer)..");
            }
        }
    }
}
