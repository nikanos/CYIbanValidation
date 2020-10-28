using CYIbanValidaitonLib.Interfaces;
using System;

namespace CYIbanValidaitonLib
{
    public class Int32_Mod97 : IMod97
    {
        public int Mod97(string inputNum)
        {
            const int DIVISOR = 97;
            const int EXTRACT_LENGTH_START = 9;
            int currentIndex = 0;
            int currentMod = 0;
            while (currentIndex < inputNum.Length)
            {
                int extractLength = currentMod == 0 ? EXTRACT_LENGTH_START :
                                    currentMod < 10 ? EXTRACT_LENGTH_START - 1 : EXTRACT_LENGTH_START - 2;
                int divident = Convert.ToInt32(currentMod.ToString() + inputNum.SafeSubstring(currentIndex, extractLength));
                currentMod = divident % DIVISOR;
                currentIndex += extractLength;
            }
            return currentMod;
        }

    }
}
