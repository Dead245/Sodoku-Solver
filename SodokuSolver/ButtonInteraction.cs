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
        
        public string IterateButtonText(bool direction,string currentIteration) {
            //false for left, true for right

            int currentIndex = iterations.IndexOf(currentIteration);

            if (direction) {
                if (currentIndex == iterations.Count - 1)
                {
                    currentIndex = 0;
                }
                else {
                    currentIndex++;
                }
            } else {
                if (currentIndex == 0)
                {
                    currentIndex = iterations.Count - 1;
                }
                else
                {
                    currentIndex--;
                }
            }

            return iterations[currentIndex];
        }
    }
}
