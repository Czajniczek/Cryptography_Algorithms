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
            int row = 0, col = 0;
            bool move_down = true;
            string output = "";

            while (col < input.Length)
            {
                matrix[row, col] = input[col];

                if (row == key - 1) move_down = false;
                else if (row == 0) move_down = true;

                if (move_down) row++;
                else row--;

                col++;
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
            int row = 0, col = 0;
            bool move_down = true;
            string output = "";

            while (col < input.Length)
            {
                matrix[row, col] = '*';

                if (row == 0) move_down = true;
                else if (row == key - 1) move_down = false;

                if (move_down) row++;
                else row--;

                col++;
            }

            col = 0;
            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (matrix[i, j] == '*')
                    {
                        matrix[i, j] = input[col];
                        col++;
                    }
                }
            }

            row = 0;
            col = 0;
            while (col < input.Length)
            {
                output += matrix[row, col];

                if (row == 0) move_down = true;
                else if (row == key - 1) move_down = false;

                if (move_down) row++;
                else row--;

                col++;
            }

            return output;
        }
        #endregion

        #region ZADANIE 2
        public string MatrixShift2AEncode(string input)
        {
            int[] keyValues = { 2, 3, 0, 4, 1 };
            int rows = input.Length / keyValues.Length;

            if (input.Length % keyValues.Length != 0) rows++;

            char[,] matrix = new char[rows, keyValues.Length];
            string output = "";
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < keyValues.Length; j++)
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
                foreach (int col in keyValues)
                {
                    if (matrix[i, col] != '*') output += matrix[i, col];
                }
            }

            return output;
        }

        public string MatrixShift2ADecode(string input)
        {
            int[] keyValues = { 2, 3, 0, 4, 1 };
            int rows = input.Length / keyValues.Length;

            if (input.Length % keyValues.Length != 0) rows++;

            char[,] matrix = new char[rows, keyValues.Length];
            int emptyCells = rows * keyValues.Length - input.Length;
            string output = "";
            int inputIndex = keyValues.Length - 1;

            for (int i = 0; i < emptyCells; i++)
            {
                matrix[rows - 1, inputIndex] = '*';
                inputIndex--;
            }

            inputIndex = 0;
            for (int i = 0; i < rows; i++)
            {
                foreach (var col in keyValues)
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
                for (int j = 0; j < keyValues.Length; j++)
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
            string output = "";
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (input.Length - 1 >= index)
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
            string output = "";
            int index = key.Length - 1;

            for (int i = 0; i < cells; i++)
            {
                matrix[rows - 1, index--] = '*';
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
        public string Encode2c(string input, string key)
        {
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));
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

            passwordCounter = 0;
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

        public string Decode2c(string input, string key)
        {
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));
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
                        for (int m = 0; m < input.Length; m++)
                        {
                            if (matrix[m, j] != '*') matrix[m, j] = input[passwordCounter++];
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
                char znak = alphabet[((alphabet.IndexOf(input[i], StringComparison.CurrentCultureIgnoreCase) * k1) + k0) % n];
                if (input[i] < 'a') output += znak.ToString().ToUpper();
                else output += znak;
            }

            return output;
        }

        public string CaesarDecode(string input, int k1, int k0)
        {
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int n = alphabet.Length;
            int euler = 12;
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                char znak = alphabet[(int)((alphabet.IndexOf(input[i], StringComparison.CurrentCultureIgnoreCase) + (n - k0)) * BigInteger.Pow(k1, euler - 1) % n)];
                if (input[i] < 'a') output += znak.ToString().ToUpper();
                else output += znak;
            }

            return output;
        }
        #endregion

        #region ZADANIE 5
        public string EncodeVigenere(string input, string key)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            char[,] matrix = new char[26, 26];
            string output = "";
            int index = 0;

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    matrix[i, j] = alphabet[index];
                    index = (index + 1) % 26;
                }

                index = (index + 1) % 26;
            }

            for (int i = 0, j = 0; i < input.Length; i++, j++)
            {
                int col = alphabet.IndexOf(input[i], StringComparison.CurrentCultureIgnoreCase);
                int row = alphabet.IndexOf(key[i % key.Length], StringComparison.CurrentCultureIgnoreCase);

                if (input[i] < 'a') output += matrix[row, col].ToString().ToUpper();
                else output += matrix[row, col];
            }

            return output;
        }

        public string DecodeVigenere(string input, string key)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            char[,] matrix = new char[26, 26];
            string output = "";
            int index = 0;

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    matrix[i, j] = alphabet[index];
                    index = (index + 1) % 26;
                }
                index = (index + 1) % 26;
            }

            for (int i = 0; i < input.Length; i++)
            {
                int col = 0;
                int row = alphabet.IndexOf(key[i % key.Length], StringComparison.CurrentCultureIgnoreCase);
                while (!matrix[row, col].ToString().Equals(input[i].ToString(), StringComparison.CurrentCultureIgnoreCase))
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
