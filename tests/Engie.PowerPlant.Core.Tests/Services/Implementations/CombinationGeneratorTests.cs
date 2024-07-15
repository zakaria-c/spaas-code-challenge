using Engie.PowerPlant.Core.Services.Implementations;
using NUnit.Framework;

namespace Engie.PowerPlant.Application.Tests.Services.Implementations
{
    public class CombinationGeneratorTests
    {
        [Test]
        public void GenerateCombinations_Returns_All_Combinations()
        {
            // Arrange
            List<int> inputList = new List<int> { 1, 2, 3 };
            List<List<int>> expectedCombinations = new List<List<int>>
            {
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 3 },
                new List<int> { 1, 2 },
                new List<int> { 1, 3 },
                new List<int> { 2, 3 },
                new List<int> { 1, 2, 3 }
            };

            // Act
            List<List<int>> actualCombinations = new PowerPlanCombinationGenerator().GenerateWithoutRepetition(inputList);

            // Assert
            Assert.AreEqual(expectedCombinations.Count, actualCombinations.Count);

            for (int i = 0; i < expectedCombinations.Count; i++)
            {
                CollectionAssert.AreEqual(expectedCombinations[i], actualCombinations[i]);
            }
        }

        [Test]
        public void GenerateCombinations_With_Empty_List_Returns_Empty_List()
        {
            // Arrange
            List<int> inputList = new List<int>();

            // Act
            List<List<int>> actualCombinations = new PowerPlanCombinationGenerator().GenerateWithoutRepetition(inputList);

            // Assert
            Assert.IsEmpty(actualCombinations);
        }

        [Test]
        public void GenerateCombinations_With_Single_Element_List_Returns_Single_Combination()
        {
            // Arrange
            List<int> inputList = new List<int> { 1 };
            List<List<int>> expectedCombinations = new List<List<int>>
            {
                new List<int> { 1 }
            };

            // Act
            List<List<int>> actualCombinations = new PowerPlanCombinationGenerator().GenerateWithoutRepetition(inputList);

            // Assert
            Assert.AreEqual(expectedCombinations.Count, actualCombinations.Count);
            CollectionAssert.AreEqual(expectedCombinations[0], actualCombinations[0]);
        }
    }
}
