using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Krypto
{
    public class KryptographyService
    {
        #region ZADANIE 1
        public string RailFenceEncode(string input, int key)
        {
            char[,] matrix = new char[key, input.Length];
            int row = 0, column = 0;
            bool move_down = true;
            string output = "";

            while (column < input.Length)
            {
                matrix[row, column] = input[column];

                if (row == 0) move_down = true;
                else if (row == key - 1) move_down = false;

                if (move_down) row++;
                else row--;

                column++;
            }

            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (matrix[i, j] != '\0') output += matrix[i, j];
                }
            }

            return output;
        }

        public string RailFenceDecode(string input, int key)
        {
            char[,] matrix = new char[key, input.Length];
            int row = 0, column = 0;
            bool move_down = true;
            string output = "";

            while (column < input.Length)
            {
                matrix[row, column] = '*';

                if (row == 0) move_down = true;
                else if (row == key - 1) move_down = false;

                if (move_down) row++;
                else row--;

                column++;
            }

            column = 0;
            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (matrix[i, j] == '*')
                    {
                        matrix[i, j] = input[column];
                        column++;
                    }
                }
            }

            row = 0;
            column = 0;
            while (column < input.Length)
            {
                output += matrix[row, column];

                if (row == 0) move_down = true;
                else if (row == key - 1) move_down = false;

                if (move_down) row++;
                else row--;

                column++;
            }

            return output;
        }
        #endregion

        #region ZADANIE 2
        public string MatrixShift2AEncode(string input)
        {
            int[] key = { 2, 3, 0, 4, 1 };
            int rows = input.Length / key.Length;

            if (input.Length % key.Length != 0) rows++;

            char[,] matrix = new char[rows, key.Length];
            int index = 0;
            string output = "";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (index < input.Length)
                    {
                        matrix[i, j] = input[index];
                        index++;
                    }
                    else matrix[i, j] = '*';
                }
            }

            for (int i = 0; i < rows; i++)
            {
                foreach (int col in key)
                {
                    if (matrix[i, col] != '*') output += matrix[i, col];
                }
            }

            return output;
        }

        public string MatrixShift2ADecode(string input)
        {
            int[] key = { 2, 3, 0, 4, 1 };
            int rows = input.Length / key.Length;

            if (input.Length % key.Length != 0) rows++;

            char[,] matrix = new char[rows, key.Length];
            int emptyCells = rows * key.Length - input.Length;
            int inputIndex = key.Length - 1;
            string output = "";

            for (int i = 0; i < emptyCells; i++)
            {
                matrix[rows - 1, inputIndex] = '*';
                inputIndex--;
            }

            inputIndex = 0;
            for (int i = 0; i < rows; i++)
            {
                foreach (var col in key)
                {
                    if (matrix[i, col] != '*')
                    {
                        matrix[i, col] = input[inputIndex];
                        inputIndex++;
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (matrix[i, j] != '*') output += matrix[i, j];
                }
            }

            return output;
        }
        #endregion

        #region ZADANIE 3
        #region 2B
        public string MatrixShift2BEncode(string input, string key)
        {
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));
            key = key.ToLower();

            int rows = input.Length / key.Length;
            if (input.Length % key.Length != 0) rows++;

            char[,] matrix = new char[rows, key.Length];
            int index = 0;
            string output = "";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (index < input.Length)
                    {
                        matrix[i, j] = input[index];
                        index++;
                    }
                    else matrix[i, j] = '*';
                }
            }

            for (int i = 97; i <= 122; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (key[j] == i)
                    {
                        for (int k = 0; k < rows; k++)
                        {
                            if (matrix[k, j] != '*') output += matrix[k, j];
                        }
                    }
                }
            }

            return output;
        }

        public string MatrixShift2BDecode(string input, string key)
        {
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));
            key = key.ToLower();

            int rows = input.Length / key.Length;
            if (input.Length % key.Length != 0) rows++;

            char[,] matrix = new char[rows, key.Length];
            int cells = rows * key.Length - input.Length;
            int index = key.Length - 1;
            string output = "";

            for (int i = 0; i < cells; i++)
            {
                matrix[rows - 1, index] = '*';
                index--;
            }

            index = 0;
            for (int i = 97; i <= 122; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (key[j] == i)
                    {
                        for (int k = 0; k < rows; k++)
                        {
                            if (matrix[k, j] != '*')
                            {
                                matrix[k, j] = input[index];
                                index++;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (matrix[i, j] != '*') output += matrix[i, j];
                }
            }

            return output;
        }
        #endregion

        #region 2C
        public string MatrixShift2CEncode(string input, string key)
        {
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));
            key = key.ToUpper();

            char[,] matrix = new char[input.Length, key.Length];
            int[] numberKey = new int[key.Length];
            int newKeyCounter = 0;
            string output = "";

            for (int i = 65; i < 91; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (i == key[j]) numberKey[j] = newKeyCounter++;
                }
            }

            int passwordCounter = 0;
            bool fullRow = false;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (passwordCounter < input.Length && !fullRow)
                    {
                        matrix[i, j] = input[passwordCounter++];

                        if (i % numberKey.Length == numberKey[j]) fullRow = true;
                    }
                    else matrix[i, j] = '*';
                }

                fullRow = false;
            }

            for (int i = 65; i < 91; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (key[j] == i)
                    {
                        for (int k = 0; k < input.Length; k++)
                        {
                            if (matrix[k, j] != '*') output += matrix[k, j];
                        }
                    }
                }
            }

            return output;
        }

        public string MatrixShift2CDecode(string input, string key)
        {
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));
            key = key.ToUpper();

            char[,] matrix = new char[input.Length, key.Length];
            int[] numberKey = new int[key.Length];
            int newKeyCounter = 0;
            string output = "";

            for (int i = 65; i < 91; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (i == key[j]) numberKey[j] = newKeyCounter++;
                }
            }

            int passwordCounter = 0;
            bool fullRow = false;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (passwordCounter < input.Length && !fullRow)
                    {
                        passwordCounter++;

                        if (i % numberKey.Length == numberKey[j]) fullRow = true;
                    }
                    else matrix[i, j] = '*';
                }

                fullRow = false;
            }

            passwordCounter = 0;
            for (int i = 65; i < 91; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (key[j] == i)
                    {
                        for (int k = 0; k < input.Length; k++)
                        {
                            if (matrix[k, j] != '*') matrix[k, j] = input[passwordCounter++];
                        }
                    }
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (matrix[i, j] != '*') output += matrix[i, j];
                }
            }

            return output;
        }
        #endregion
        #endregion

        #region ZADANIE 4
        public string CaesarEncode(string input, int k1, int k0)
        {
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int n = alphabet.Length;
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                char sign = alphabet[((alphabet.IndexOf(input[i],
                    StringComparison.CurrentCultureIgnoreCase) * k1) + k0) % n];

                if (input[i] < 'a') output += sign.ToString().ToUpper();
                else output += sign;
            }

            return output;
        }

        public string CaesarDecode(string input, int k1, int k0)
        {
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int n = alphabet.Length, euler_number = 12;
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                char sign = alphabet[(int)((alphabet.IndexOf(input[i],
                    StringComparison.CurrentCultureIgnoreCase) + (n - k0)) *
                    BigInteger.Pow(k1, euler_number - 1) % n)];

                if (input[i] < 'a') output += sign.ToString().ToUpper();
                else output += sign;
            }

            return output;
        }
        #endregion

        #region ZADANIE 5
        public string VigenereEncode(string input, string key)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int n = alphabet.Length, index = 0;
            char[,] matrix = new char[n, n];
            string output = "";

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = alphabet[index];
                    index = (index + 1) % n;
                }

                index = (index + 1) % n;
            }

            for (int i = 0; i < input.Length; i++)
            {
                int col = alphabet.IndexOf(input[i], StringComparison.CurrentCultureIgnoreCase);
                int row = alphabet.IndexOf(key[i % key.Length], StringComparison.CurrentCultureIgnoreCase);

                if (input[i] < 'a') output += matrix[row, col].ToString().ToUpper();
                else output += matrix[row, col];
            }

            return output;
        }

        public string VigenereDecode(string input, string key)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int n = alphabet.Length, index = 0;
            char[,] matrix = new char[n, n];
            string output = "";

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = alphabet[index];
                    index = (index + 1) % n;
                }
                index = (index + 1) % n;
            }

            for (int i = 0; i < input.Length; i++)
            {
                int col = 0;
                int row = alphabet.IndexOf(key[i % key.Length], StringComparison.CurrentCultureIgnoreCase);
                
                while (!matrix[row, col].ToString().Equals(input[i].ToString(), 
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    col++;
                }

                if (input[i] < 'a') output += matrix[0, col].ToString().ToUpper();
                else output += matrix[0, col];
            }

            return output;
        }
        #endregion
    }
}
