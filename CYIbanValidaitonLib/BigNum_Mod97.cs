using CYIbanValidaitonLib.Interfaces;
using System.Numerics;

namespace CYIbanValidaitonLib
{
    public class BigNum_Mod97 : IMod97
    {
        public int Mod97(string inputNum)
        {
            const int DIVISOR = 97;
            BigInteger num = BigInteger.Parse(inputNum);
            BigInteger divisor = new BigInteger(DIVISOR);
            BigInteger.DivRem(num, divisor, out BigInteger result);
            //note that mod 97 result will always fit in a byte, so the following is safe
            return (int)result.ToByteArray()[0];
        }
    }
}
