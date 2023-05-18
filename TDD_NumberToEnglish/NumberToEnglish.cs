using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_NumberToEnglish
{
    internal class NumberToEnglish
    {
        public string ToEnglish(double num)
        {
            /* Number lengths 00.00
             * 4 = single digit 0.00
             * 5 = tens 00.00
             * 6 = hundreds 000.00
             * 7 = thousands 0000.00
             * 8 = ten thousand 00000.00
             * 9 = hundred thousand 000000.00
             * 10 = million 0000000.00
             */
            string number = string.Format("{0:#.00}", num); // Make all numbers contain decimals (.XX) at the end so they can be parsed the same way
            int len = number.Length;
            string str = "";
            bool isDec = false, teens = false, thousandTeens = false, millionTeens = false;
            bool isThousand = false, isMillion = false;
            for (int i = 0; i < number.Length; i++, len--)
            {
                if (number[i] == '.')
                {
                    isDec = true;
                    if (number.Length >= 4)
                        str += " dollars";
                    continue;
                }
                if (isDec == true)
                {
                    if (number[number.Length - 2] == '1' && number[number.Length - 1] != '0') // Teens (11-19)
                    {
                        str += " " + ToWordTeens(number[i]) + " cents";
                        return str.Trim();
                    }
                    if (number[number.Length - 2] != '0') // $0.X0
                        str += " " + ToWordTens(number[i]);
                    if (number[number.Length - 1] != '0') // $0.0X
                    {
                        str += " " + ToWord(number[number.Length - 1]);
                    }
                    if (number[i] != '0' || number[number.Length - 1] != '0') // Don't append cents if it's .00
                        str += " cents";
                    return str.Trim();
                }

                switch (len)
                {
                    case 13: // Billion
                        str += " " + ToWord(number[i]) + " billion";
                        break;
                    case 12: // Hundreds million
                        if (number[i] != '0')
                        {
                            str += " " + ToWord(number[i]) + " hundred";
                            isMillion = true;
                        }
                        break;
                    case 11: // Tens million
                        if (number[i] == '1' && number[i + 1] != '0')
                        {
                            str += " " + ToWordTeens(number[i + 1]) + " million"; // Teens (11-19)
                            millionTeens = true;
                            isMillion = true;
                        }
                        else if (number[i] != '0')
                        {
                            str += " " + ToWordTens(number[i]); // Non-teens (10, 20, 30, etc.)
                            isMillion = true;
                        }
                        break;
                    case 10: // Million
                        if (millionTeens)
                            break;
                        if (number[i] != '0')
                            str += " " + ToWord(number[i]) + " million";
                        else if (isMillion)
                            str += " million";
                        break;
                    case 9: // Hundred thousand
                        if (number[i] != '0')
                        {
                            str += " " + ToWord(number[i]) + " hundred";
                            isThousand = true;
                        }
                        break;
                    case 8: // Tens thousand
                        if (number[i] == '1' && number[i + 1] != '0')
                        {
                            str += " " + ToWordTeens(number[i + 1]) + " thousand"; // Teens (11-19)
                            thousandTeens = true;
                            isThousand = true;
                        }
                        else if (number[i] != '0')
                        {
                            str += " " + ToWordTens(number[i]); // Non-teens (10, 20, 30, etc.)
                            isThousand = true;
                        }
                        break;
                    case 7: // Thousand
                        if (thousandTeens) // Teens (11,19)
                            break;
                        else if (isThousand && number[i] == '0') // Non-teens (10, 20, 30, etc.)
                        {
                            str += " thousand";
                            break;
                        }
                        else if (number[i] != '0')// 10, 20, 30, etc.
                            str += " " + ToWord(number[i]) + " thousand";
                        break;
                    case 6: // Hundred
                        if (number[i] != '0')
                            str += " " + ToWord(number[i]) + " hundred";
                        break;
                    case 5: // Tens
                        if (number[i] == '1' && number[i + 1] != '0') // Teens (11-19)
                        {
                            str += " " + ToWordTeens(number[i + 1]);
                            teens = true;
                        }
                        else if (number[i] != '0')
                        {
                            str += " " + ToWordTens(number[i]); // Non-teens (10, 20, 30, etc)
                        }
                        break;
                    case 4: // Singles
                        if (number.Length == 4 && number[i] != '0') // Single digit number i.e. 9.00
                        {
                            str += " " + ToWord(number[i]);
                            break;
                        }
                        else if (teens) // If it's a teens (11-19) don't add
                            break;
                        else if (number[i] == '0') // Ends in 0, (10, 20, 30, etc) so don't add 
                            break;
                        str += " " + ToWord(number[i]);
                        break;
                    default: // Decimals
                        break;
                }

            }
            return str.Trim();
        }

        private string ToWord(char ch)
        {
            switch (ch)
            {
                case '1':
                    return "one";
                case '2':
                    return "two";
                case '3':
                    return "three";
                case '4':
                    return "four";
                case '5':
                    return "five";
                case '6':
                    return "six";
                case '7':
                    return "seven";
                case '8':
                    return "eight";
                case '9':
                    return "nine";
                default:
                    return "null";
            }
        }
        private string ToWordTens(char ch)
        {
            switch (ch)
            {
                case '1':
                    return "ten";
                case '2':
                    return "twenty";
                case '3':
                    return "thirty";
                case '4':
                    return "forty";
                case '5':
                    return "fifty";
                case '6':
                    return "sixty";
                case '7':
                    return "seventy";
                case '8':
                    return "eighty";
                case '9':
                    return "ninety";
                default:
                    return "nullTens";
            }
        }
        private string ToWordTeens(char ch)
        {
            switch (ch)
            {
                case '1':
                    return "eleven";
                case '2':
                    return "twelve";
                case '3':
                    return "thirteen";
                case '4':
                    return "fourteen";
                case '5':
                    return "fifteen";
                case '6':
                    return "sixteen";
                case '7':
                    return "seventeen";
                case '8':
                    return "eighteen";
                case '9':
                    return "nineteen";
                default:
                    return "nullTeens";
            }
        }
    }
}
