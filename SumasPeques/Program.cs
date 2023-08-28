using System;

class Program
{
    static int CountSumCombinations(int v, int[] numbers)
    {
        return numbers
            .SelectMany((x, i) => numbers.Skip(i + 1).SelectMany((y, j) => numbers.Skip(i + j + 2).Select(z => x + y + z)))
            .Count(sum => sum < v);
        //Version 2
        /*int count = 0;
        int n = numbers.Length;

        Array.Sort(numbers); //Ordena Arreglo

        for (int i = 0; i < n - 2; i++)
        {
            int left = i + 1;
            int right = n - 1;

            while (left < right)
            {
                int sum = numbers[i] + numbers[left] + numbers[right];
                if (sum < v)
                {
                    count += right - left;
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }*/


        //Priemer version pero no me gustan tantos for
        /*int count = 0;
        int n = numbers.Length;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    if (numbers[i] + numbers[j] + numbers[k] < v)
                    {
                        count++;
                    }
                }
            }
        }*/

        //return count;
    }

    static void Main()
    {
        // Ejemplo de input 1
        string input1 = "15\n5\n12 2 5 14 1";
        (int v1, int[] numbers1) = ParseInput(input1);
        int output1 = CountSumCombinations(v1, numbers1);
        Console.WriteLine(output1); // Output: 4

        // Ejemplo de input 2
        string input2 = "6\n3\n1 2 3";
        (int v2, int[] numbers2) = ParseInput(input2);
        int output2 = CountSumCombinations(v2, numbers2);
        Console.WriteLine(output2); // Output: 3

        // Ejemplo de input 3
        string input3 = "100\n3\n33 34 35";
        (int v3, int[] numbers3) = ParseInput(input3);
        int output3 = CountSumCombinations(v3, numbers3);
        Console.WriteLine(output3); // Output: 0
    }

    static (int, int[]) ParseInput(string input)
    {
        string[] lines = input.Trim().Split('\n');
        int v = int.Parse(lines[0]);
        string[] numStrings = lines[2].Split(' ');
        int[] numbers = Array.ConvertAll(numStrings, int.Parse);
        return (v, numbers);
    }
}
