using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci {
    class FibonacciObject {

        // initializing variables
        private int maxNumber; // The maximum number choosed by the user
        private List<int> numbersList; // The list of Fibonnaci numbers

        
        /// <summary>
        /// Constructor of the object fibonacci
        /// </summary>
        /// <param name="maxNumber">The maximum number choosed by the user</param>
        public FibonacciObject(int maxNumber) {
            this.numbersList = new List<int>();
            this.numbersList.Add(1);
            this.numbersList.Add(1);
            this.maxNumber = maxNumber;
        }

        /// <summary>
        /// Method that get every fibonacci numbers
        /// </summary>
        /// <returns>List of numbers</returns>
        public List<int> GetList() {
            Boolean enough = false;
            int newNumber;

            // Could have used recursion but it isn't optimised for this kind of work
            while (!enough) {
                newNumber = numbersList[numbersList.Count - 1] + numbersList[numbersList.Count - 2]; // Sums the two last number of the list
                if (newNumber > maxNumber) { // If the new number is more than the number maximum then stop
                    enough = true;
                } else {
                    numbersList.Add(newNumber); // Add the number to the list
                }
            }

            return numbersList;
        }
    }
}
