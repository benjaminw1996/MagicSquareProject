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
            //User is asked to input the desired width of the magic square
            Console.Write("Please input width of desired magic square - ");
            m_size = Int16.Parse(Console.ReadLine());

            //The integer array to be filled is declared with the given size
            m_magicSquare = new int[m_size, m_size];

            //The number of squares inside the array is calculated from the width of the array
            m_numberOfSquares = m_size * m_size;
            
            //Integer array is looped through and filled with random integers
            for(int i = 0; i < m_size; i++) {
                Console.WriteLine("");
                for(int j = 0; j < m_size; j++) {
                    m_magicSquare[i, j] = random.Next(0, m_numberOfSquares + 1);
                    Console.Write(m_numberOfSquares + " ");
                }
            }
        }
    }
}
