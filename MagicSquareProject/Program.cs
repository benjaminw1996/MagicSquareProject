using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquareProject{
    class Program{
        //Public variables to use throughout the program
        static int m_size;
        static int[,] m_magicSquare;
        static int m_numberOfSquares;
        //Random number generator initialised to use throughout the program
        static Random random = new Random();

        static void Main(string[] args){
            Console.WriteLine("Hello, here's to a new beginning...");

            //User is asked to input the desired width of the magic square
            Console.Write("Please input width of desired magic square - ");
            m_size = Int16.Parse(Console.ReadLine());
            m_numberOfSquares = m_size * m_size;

            //Magic square generator function is called 
            MagicSquareGenerator();

            //Line to end program when required so console window doesn't close as soon as the program is finished
            Console.Write("\n\nPress any key to end program...");
            Console.ReadKey();
        }

        /// <summary>
        /// Function to generate a new random integer array to then be tested to see if it is a magic square
        /// </summary>
        public static void MagicSquareGenerator() {
            //FillIntegerArray function is called to fill the array, the DisplayArray function is then called to display the output
            FillIntegerArray();
            DisplayArray();

            //RandomiseArray function is called to randomise the array that was just filled, the DisplayArray function is then called to display the output
            RandomiseArray();
            DisplayArray();
        }

        /// <summary>
        /// Function to fill the integer array in order from smallest to largest
        /// </summary>
        public static void FillIntegerArray() {
            //Initialises the integer array with the size given by the user
            m_magicSquare = new int[m_size, m_size];
            //Initilises a new integer that will be incremented and used to copy into the integer array.
            int m_number = 1;

            //Looping through the array and inputing the numbers from the integer above.
            for (int i = 0; i < m_size; i++) {
                for (int j = 0; j < m_size; j++) {
                    m_magicSquare[i, j] = m_number;
                    m_number++;
                }
            }
        }

        /// <summary>
        /// Function to randomise the integer array by swapping around values based on a random index.
        /// </summary>
        public static void RandomiseArray() {
            //Declaring local variables to be used within this function. A temp int to hold the value being swapped, and two integers to hold the random index
            int temp = 0;
            int x_index = 0;
            int y_index = 0;

            //Looping through the array and swapping the numbers in sequence with a random index within the array. 
            for (int i = 0; i < m_size; i++) {
                for (int j = 0; j < m_size; j++) {
                    temp = m_magicSquare[i, j];

                    x_index = random.Next(0, m_size);
                    y_index = random.Next(0, m_size);

                    m_magicSquare[i, j] = m_magicSquare[x_index, y_index];
                    m_magicSquare[x_index, y_index] = temp;
                }
            }
        }

        /// <summary>
        /// Simple function to write out the array in the console app.
        /// This was written to save having to add Console.WriteLine and Console.Write all over the place whenever I wanted to display the array.
        /// </summary>
        public static void DisplayArray() {
            for (int i = 0; i < m_size; i++) {
                Console.WriteLine();
                for (int j = 0; j < m_size; j++) {
                    Console.Write(m_magicSquare[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
