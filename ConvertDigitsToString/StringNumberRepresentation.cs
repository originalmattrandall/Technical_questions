public class StringNumberRepresentation
    {
        public static string ConvertNumberToString(int num)
        {
            var result = "";
            if (num < 0 || num > 999)
                return result;
            
            var numLength = num.ToString().Length;

            // single digit
            if (numLength <= 1)
                return GetNumberAsString(num);

            // double digit
            if (numLength == 2)
            {
                return GetDoubleDigitsString(num);
            }
            
            // triple digit
            if (numLength == 3)
            {
                var leftMostValue = char.GetNumericValue(num.ToString().ToCharArray()[0]);
                result = GetNumberAsString(leftMostValue) + " hundred " + 
                         GetDoubleDigitsString(Int32.Parse(num.ToString().Remove(1, 0)));
            }

            return result;
        }

        private static string GetDoubleDigitsString(double num)
        {
            var result = "";
            
            var leftMostValue = char.GetNumericValue(num.ToString().ToCharArray()[0]);
            var rightValue = char.GetNumericValue(num.ToString().ToCharArray()[1]);
            if (leftMostValue == 1)
            {
                return GetNumberAsString(num);
            }

            result += GetNumberAsString(Int32.Parse(leftMostValue + "0"));

            if (rightValue > 0)
                result += " " + GetNumberAsString(rightValue);

            return result;
        }

        private static string GetNumberAsString(double num)
        {
            var stringValues = new Dictionary<double, string>()
            {
                {0, "zero"},
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {4, "four"},
                {5, "five"},
                {6, "six"},
                {7, "seven"},
                {8, "eight"},
                {9, "nine"},
                {10, "ten"},
                {11, "eleven"},
                {12, "twelve"},
                {13, "thirteen"},
                {14, "fourteen"},
                {15, "fifteen"},
                {16, "sixteen"},
                {17, "seventeen"},
                {18, "eighteen"},
                {19, "nineteen"},
                {20, "twenty"},
                {30, "thirty"},
                {40, "fourty"},
                {50, "fifty"},
                {60, "sixty"},
                {70, "seventy"},
                {80, "eighty"},
                {90, "ninety"}
            };

            return stringValues[num];
        }
    }
