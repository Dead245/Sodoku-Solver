using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver
{
    public class ButtonInteraction
    {
        List<string> iterations = new List<string> {"","1","2","3","4","5","6","7","8","9"};
        
        public string IterateButtonText(string currentIteration) {

            int currentIndex = iterations.IndexOf(currentIteration);

                if (currentIndex == iterations.Count - 1)
                {
                    currentIndex = 0;
                }
                else {
                    currentIndex++;
                }

            return iterations[currentIndex];
        }
    }
}
