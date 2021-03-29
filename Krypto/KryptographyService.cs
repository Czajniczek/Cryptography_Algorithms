using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Krypto
{
    public class KryptographyService
    {
        public string DecodeRail(string input, int key)
        {
            char[,] matrix = new char[key, input.Length];

            int row = 0, col = 0;
            bool move_down = true;

            for(int i = 0; i < input.Length; i++)
            {
                if(row == 0)
                {
                    move_down = true;
                }
                if(row == key - 1)
                {
                    move_down = false;
                }

                matrix[row, col] = '*';
                col++;

                if (move_down)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }

            int index = 0;
            for(int i = 0; i < key; i++)
            {
                for(int j = 0; j < input.Length; j++)
                {
                    if(matrix[i,j] == '*' && index < input.Length)
                    {
                        matrix[i, j] = input[index];
                        index++;
                    }
                }
            }

            string output = "";
            row = 0;
            col = 0;
            for(int i = 0; i < input.Length; i++)
            {
                if (row == 0)
                {
                    move_down = true;
                }
                if (row == key - 1)
                {
                    move_down = false;
                }

                if(matrix[row,col] != '*')
                {
                    output += matrix[row, col];
                }
                col++;
                if (move_down)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }

            return output;
        } 
        public string EncodeRail(string input, int key)
        {
            char[,] matrix = new char[key, input.Length];

            int row = 0;
            int col = 0;
            bool move_down = true;
            while (col < input.Length)
            {
                matrix[row, col] = input[col];

                if (row == key - 1)
                {
                    move_down = false;
                }
                if(row == 0)
                {
                    move_down = true;
                }

                if (move_down)
                {
                    row++;
                }
                else
                {
                    row--;
                }

                col++;
            }

            string output = string.Empty;

            
            for(int i = 0; i < key; i++)
            {
                for (int j = 0; j < input.Length; j ++)
                {
                    if(matrix[i,j] != '\0')
                    output += matrix[i, j];
                }
            }

            return output;
        }         
        public string EncodeMatrixShift(string input)
        {
            int[] keyValues = { 2, 3, 0, 4, 1 };
            int rows = input.Length / keyValues.Length;
            
            if (input.Length % keyValues.Length != 0)
            {
                rows++;
            }

            char[,] arr = new char[rows, keyValues.Length];
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < keyValues.Length; j++)
                {
                    if (index < input.Length)
                    {
                        arr[i, j] = input[index];
                        index++;
                    }
                    else
                    {
                        arr[i, j] = '#';
                    }
                }
            }
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                foreach (int col in keyValues)
                {

                    if (arr[i, col] != '#')
                        str.Append(arr[i, col]);
                }
            }

            return str.ToString();
        }         
        public string DecodeMatrixShift(string input)
        {
            int[] keyValues = { 2, 3, 0, 4, 1 };
            int rows = input.Length / keyValues.Length;
            
            if (input.Length % keyValues.Length != 0)
            {
                rows++;
            }

            char[,] arr = new char[rows, keyValues.Length];

            int emptyCells = rows * keyValues.Length - input.Length;
            int inputIndex = keyValues.Length - 1;

            for (int i = 0; i < emptyCells; i++)
            {
                arr[rows - 1, inputIndex] = '#';
                inputIndex--;
            }

            inputIndex = 0;
            for (int i = 0; i < rows; i++)
            {
                foreach (var col in keyValues)
                {
                    if (arr[i, col] != '#')
                        arr[i, col] = input[inputIndex++];
                }
            }

            StringBuilder str = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < keyValues.Length; j++)
                {
                    if (arr[i, j] != '#')
                        str.Append(arr[i, j]);
                }
            }
            return str.ToString();
        }         
        public string Encode2b(string input, string key)
        {
            int rows = input.Length / key.Length;
            if(input.Length % key.Length != 0)
            {
                rows++;
            }

            char[,] arr = new char[rows, key.Length];
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));

            key = key.ToLower();

            int index = 0;
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < key.Length; j++)
                {
                    if(input.Length - 1 >= index)
                    {
                        arr[i, j] = input[index];
                        index++;
                    }
                    else
                    {
                        arr[i, j] = '#';
                    }
                }
            }

            StringBuilder stringBuilder = new StringBuilder();
            
            for(int i = 97; i <= 122; i++)
            {
                for(int j = 0; j < key.Length; j++)
                {
                    if(key[j] == i)
                    {
                        for(int k = 0; k < rows; k++)
                        {
                            if(arr[k,j] != '#')
                            {
                                stringBuilder.Append(arr[k, j]);
                            }
                        }
                    }
                }
            }

            return stringBuilder.ToString();
        } 
        public string Decode2b(string input, string key)
        {
            int rows = input.Length / key.Length;
            if (input.Length % key.Length != 0)
            {
                rows++;
            }

            char[,] arr = new char[rows, key.Length];
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));

            key = key.ToLower();

            int cells = rows * key.Length - input.Length;

            int index = key.Length - 1;
            for (int i = 0; i < cells; i++)
            {
                arr[rows - 1, index--] = '*';
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
                            if(arr[k, j] != '*')
                            {
                                arr[k, j] = input[index];
                                index++;
                            }
                        }
                    }
                }
            }

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (arr[i, j] != '*')
                    {
                        stringBuilder.Append(arr[i, j]);
                    }
                }
            }


            return stringBuilder.ToString();
        } 
        public string Encode2c(string input, string key)
        {

            char[,] arr = new char[input.Length, key.Length];
            int[] numberKey = new int[key.Length];
            int newKeyCounter = 0;

            for (int i = 65; i < 91; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (i == key[j])
                    {
                        numberKey[j] = newKeyCounter++;
                    }
                }
            }
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));

            int passwordCounter = 0;
            bool fullRow = false;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (passwordCounter < input.Length && !fullRow)
                    {
                        arr[i, j] = input[passwordCounter++];

                        if (i % numberKey.Length == numberKey[j])
                        {
                            fullRow = true;
                        }
                    }
                    else
                    {
                        arr[i, j] = '*';
                    }
                }
                fullRow = false;
            }

            passwordCounter = 0;
            StringBuilder str = new StringBuilder();
            for (int i = 65; i < 91; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (key[j] == i)
                    {
                        for (int k = 0; k < input.Length; k++)
                        {
                            if (arr[k, j] != '*')
                            {
                                str.Append(arr[k, j]);
                            }
                        }
                    }
                }
            }

            return str.ToString();
        } 
        public string Decode2c(string input, string key)
        {
            char[,] arr = new char[input.Length, key.Length];
            int[] numberKey = new int[key.Length];
            int newKeyCounter = 0;

            for (int i = 65; i < 91; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (i == key[j])
                    {
                        numberKey[j] = newKeyCounter++;
                    }
                }
            }
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));

            int passwordCounter = 0;
            bool fullRow = false;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (passwordCounter < input.Length && !fullRow)
                    {
                        passwordCounter++;

                        if (i % numberKey.Length == numberKey[j])
                        {
                            fullRow = true;
                        }
                    }
                    else
                    {
                        arr[i, j] = '*';
                    }
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
                            if (arr[m, j] != '*')
                            {
                                arr[m, j] = input[passwordCounter++];
                            }


                        }
                    }
                }
            }

            StringBuilder str = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (arr[i, j] != '*')
                        str.Append(arr[i, j]);
                }
            }

            return str.ToString();
        } 
        public string EncodeCaesar(string input, int k1, int k0)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int n = alphabet.Length;

            StringBuilder str = new StringBuilder();
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));

            for (int i = 0; i < input.Length; i++)
            {
                char znak = alphabet[((alphabet.IndexOf(input[i]) * k1) + k0) % n];

                str.Append(znak);
            }
            return str.ToString();
        }
        public string DecodeCaesar(string input, int k1, int k0)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int n = 52;
            int euler = 24;

            StringBuilder str = new StringBuilder();
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));

            for (int i = 0; i < input.Length; i++)
            {
                char znak = alphabet[(int)((alphabet.IndexOf(input[i]) + (n - k0)) * BigInteger.Pow(k1, euler - 1) % n)];
                str.Append(znak);
            }
            return str.ToString();
        }
        public string EncodeVigenere(string input, string key)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            char[,] arr = new char[26, 26];

            int index = 0;

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    arr[i, j] = alphabet[index];
                    index = (index + 1) % 26;
                }
                index = (index + 1) % 26;
            }

            StringBuilder str = new StringBuilder();

            for (int i = 0, j = 0; i < input.Length; i++, j++)
            {
                int col = alphabet.IndexOf(input[i], StringComparison.CurrentCultureIgnoreCase);
                int row = alphabet.IndexOf(key[i % key.Length], StringComparison.CurrentCultureIgnoreCase);

                if(input[i] < 'a')
                {
                    str.Append(arr[row, col].ToString().ToUpper());
                }
                else
                {
                    str.Append(arr[row, col]);
                }
            }
            return str.ToString();
        }
        public string DecodeVigenere(string input, string key)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            char[,] arr = new char[26, 26];

            int index = 0;

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    arr[i, j] = alphabet[index];
                    index = (index + 1) % 26;
                }
                index = (index + 1) % 26;
            }

            StringBuilder str = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                int col = 0;
                int row = alphabet.IndexOf(key[i % key.Length], StringComparison.CurrentCultureIgnoreCase);
                while (!arr[row, col].ToString().Equals(input[i].ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    col++;
                }
                if (input[i] < 'a')
                {
                    str.Append(arr[0, col].ToString().ToUpper());
                }
                else
                {
                    str.Append(arr[0, col]);
                }
            }

            return str.ToString();
        }
    }
}
