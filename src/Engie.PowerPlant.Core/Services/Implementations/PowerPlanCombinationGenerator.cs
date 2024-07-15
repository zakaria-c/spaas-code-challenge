using Engie.PowerPlant.Core.Services.Interfaces;

namespace Engie.PowerPlant.Core.Services.Implementations
{
    public class PowerPlanCombinationGenerator : IPowerPlanCombinationGenerator
    {
        public List<List<T>> GenerateWithoutRepetition<T>(List<T> list)
        {
            List<List<T>> allCombinations = new List<List<T>>();
            int n = list.Count;

            // Generate combinations of all lengths from 1 to n
            for (int length = 1; length <= n; length++)
            {
                List<T> combination = new List<T>();
                GenerateCombinationsRecursive(list, allCombinations, combination, n, length, 0);
            }

            return allCombinations;
        }

        private static void GenerateCombinationsRecursive<T>(List<T> list, List<List<T>> allCombinations, List<T> combination, int n, int length, int startIndex)
        {
            if (length == 0)
            {
                allCombinations.Add(new List<T>(combination));
                return;
            }

            for (int i = startIndex; i <= n - length; i++)
            {
                combination.Add(list[i]);
                GenerateCombinationsRecursive(list, allCombinations, combination, n, length - 1, i + 1);
                combination.RemoveAt(combination.Count - 1);
            }
        }
    }
}
