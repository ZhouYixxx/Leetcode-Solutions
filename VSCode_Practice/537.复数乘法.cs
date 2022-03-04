/*
 * @lc app=leetcode.cn id=537 lang=csharp
 *
 * [537] 复数乘法
 */

// @lc code=start
public class Solution537 {
    public void Test(){
        var num1 = "78+-76i";
        var num2 = "-86+72i";
        var ans = ComplexNumberMultiply(num1, num2);
    }

    public string ComplexNumberMultiply(string num1, string num2) {
        var x = GetComplexNUmber(num1);
        var y = GetComplexNUmber(num2);
        var ans = Multiply(x,y);
        return $"{ans.RealPart}+{ans.ImaginaryPart}i";
    }

    private ComplexNUmber GetComplexNUmber(string num){
        int real = 0;
        int imag = 0;
        bool isReal = true;
        bool isRealNegtive = false;
        bool isImagNegtive = false;
        for (int i = 0; i < num.Length; i++)
        {
            var c = num[i];
            if (c == '+')
            {
                isReal = false;
            }
            if (c == '-')
            {
                if (isReal == true)
                {
                    isRealNegtive = true;
                }
                else
                {
                    isImagNegtive = true;   
                }
            }
            if (c >= '0' && c <= '9')
            {
                if (isReal)
                {
                    real = real*10 + c-'0';
                }
                else
                {
                    imag = imag*10 + c-'0';
                }
            }
        }
        if (isRealNegtive)
        {
            real *= -1;
        }
        if (isImagNegtive)
        {
            imag *= -1;
        }
        return new ComplexNUmber(real, imag);
    }

    private ComplexNUmber Multiply(ComplexNUmber x, ComplexNUmber y){
        var real = x.RealPart*y.RealPart - x.ImaginaryPart*y.ImaginaryPart;
        var imag = x.RealPart*y.ImaginaryPart + x.ImaginaryPart*y.RealPart;
        return new ComplexNUmber(real, imag);
    }

    public class ComplexNUmber
    {
        public ComplexNUmber(int real, int imag){
            RealPart = real;
            ImaginaryPart = imag;
        }
        public int RealPart;
        public int ImaginaryPart; 
    }
}
// @lc code=end

