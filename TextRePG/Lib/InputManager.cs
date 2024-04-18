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
            int input = -10;

            while(input == -10)
            {
                Console.Write(prompt);
                
                try 
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException) 
                {
                    Console.WriteLine("Invalid Input: Please enter integer input.");
                }
            }

            return input;
        }
    }
}
