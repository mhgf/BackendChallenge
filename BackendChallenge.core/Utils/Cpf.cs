using System.Linq;

namespace BackendChallenge.core.Utils
{
    public class Cpf
    {
        public static bool IsInvalid(string document) => !IsValid(document); 
        public static bool IsValid(string document)
        {
            document = new String(document.Where(x => char.IsDigit(x)).ToArray());

            if (document.Length != 11)
                return false;

            bool equal = true;

            for (int i = 1; i < 11 && equal; i++)
            {
                if (document[i] != document[0])
                    equal = false;
            }

            if (equal || document == "12345678909")
                return false;

            int[] numbers = new int[11];

            for (int i = 0; i < 11; i++)
                numbers[i] = int.Parse(
                  document[i].ToString());

            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += (10 - i) * numbers[i];

            int result = sum % 11;

            if (result == 1 || result == 0)
            {
                if (numbers[9] != 0)
                    return false;
            }
            else if (numbers[9] != 11 - result)
                return false;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (11 - i) * numbers[i];

            result = sum % 11;

            if (result == 1 || result == 0)
            {
                if (numbers[10] != 0)
                    return false;
            }

            else
                if (numbers[10] != 11 - result)
                return false;

            return true;
        }
    }
}
