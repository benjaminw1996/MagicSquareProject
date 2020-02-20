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
        //Random number generator initialised to use throughout the program
        static Random random = new Random();

        static void Main(string[] args){
            Console.WriteLine("Hello, here's to a new beginning...");

            //Local variables to be used in the following loop. runProgram is used to hold the program while the user inputs a valid size and userReply is used to store the users replies to questions.
            bool runProgram = false;
            string userReply = "";

            //This loop is used to get the user to input a valid size for the magic square, it is also used to warn the user if they are entering a number that is too big
            while (!runProgram) {
                //User is asked to input the desired width of the magic square
                Console.Write("\nPlease input a width of 3 or more of the desired magic square (please note that anything greater than 3 may take a while to complete) - ");

                //The users reply is attempted to be parsed as an integer, if this fails the user is prompted to enter a valid response.
                try {
                    m_size = Int16.Parse(Console.ReadLine());
                } catch {

                }

                //If the size the user enters is larger than 3 then they are warned that this may take a while to find a solution so they are prompted to confirm they want to continue.
                if(m_size > 3) {
                    Console.Write("\nAre you sure you wish to proceed with that size? The program may take a while to find a solution - (Y/N) - ");
                    userReply = Console.ReadLine();
                    //If they wish to continue with the larger reply then the program continues, if not they can enter a new size.
                    if(userReply.ToLower() == "y") {
                        runProgram = true;
                    } else {
                        runProgram = false;
                    }
                //If their size is smaller than 3 they are prompted to enter a valid size.    
                } else if (m_size < 3) {
                    Console.Write("\nPlease enter a valid size.");
                    runProgram = false;
                } else {
                    runProgram = true;
                }
            }
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
            bool foundMagicSquare = false;

            while (foundMagicSquare == false) {
                //FillIntegerArray function is called to fill the array, the DisplayArray function is then called to display the output
                FillIntegerArray();
                //DisplayArray();

                //RandomiseArray function is called to randomise the array that was just filled, the DisplayArray function is then called to display the output
                RandomiseArray();
                //DisplayArray();

                foundMagicSquare = CheckIfMagicSquare();
            }

            DisplayArray();
            Console.WriteLine("\nWe have found a magic square!!");
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
        /// Function to test if the generated integer array is a magic square. First it will loop through and check the rows, and then the columns
        /// and then finally the diagonals.
        /// </summary>
        /// <returns>Boolean that states if the statement "It is a magic square" is true or false.</returns>
        public static bool CheckIfMagicSquare() {
            //Boolean variable to return is declared.
            bool isMagic = false;
            //Integer variables to be used throughout the function are declared and initialised.
            int m_sum = 0;
            int tempRowSum;
            int tempColumnSum;
            int diagonalSum1 = 0;
            int diagonalSum2 = 0;

            //Integer array is looped through and the rows, columns and diagonals are added up and compared to each other.
            for (int i = 0; i < m_size; i++) {
                //The integer to store the sum of the current row is reset to 0 at the end of each loop through the rows.
                tempRowSum = 0;
                tempColumnSum = 0;
                
                for (int j = 0; j < m_size; j++) {
                    //The current value in the row  and column are added to the tempRowSum and tempColumnSum respectively.
                    tempRowSum += m_magicSquare[i, j];
                    tempColumnSum += m_magicSquare[j, i];

                    //If the index i and j are equal then we are currently looking at the square that is in one of the diagonals
                    //The value of this square is then added to the diagonalSum1 int
                    if (i == j) {
                        diagonalSum1 += m_magicSquare[i, j];
                    }

                    //If the index i and j added together are equal to the width of the 2d array -1 (this is because of the 0 indexing of arrays)
                    //Then we are looking at the square which is the other diagonal, the value of this square is then added to the diagonalSum2 int
                    if (i + j == m_size - 1) {
                        diagonalSum2 += m_magicSquare[i, j];
                    }
                }

                //The values of the sums of the current row and columns are checked against the first sum taken.
                //First the value of the sum of the first row is checked to see if it is still 0, if its not then the sums of the current row and column are compared to it. 
                //If it is 0 then the tempRowSum holds the sum of the first row and is then given to the m_sum variable.
                if ( m_sum != 0){
                    if (tempRowSum != m_sum || tempColumnSum != m_sum) {
                        //If the current row's sum does not equal the sum of the other rows then the boolean is set to false and is returned ending the rest of the loop
                        isMagic = false;
                        return isMagic;
                    } else {
                        //If the sums are equal then the bool is temporarily set to true and then the loop moves onto the next row to compare.
                        isMagic = true;
                    }
                } else if (tempRowSum == tempColumnSum){
                    m_sum = tempRowSum;
                } else {
                    isMagic = false;
                    return isMagic;
                }
            }

            //If the function reaches this point, it should mean that all the rows and columns are equal to each other.
            //The last check to perform is to compare the sums of the diagonals to the sum of the first row looked at. 
            //m_sum != 0 is added to make sure that the for loop above has done its job correctly, if it is 0 then something has gone wrong and false will be returned.
            if (m_sum != 0 && m_sum == diagonalSum1 && m_sum == diagonalSum2) {
                isMagic = true;

                return isMagic;
            } else {
                isMagic = false;

                return isMagic;
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