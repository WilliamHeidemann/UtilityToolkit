using System.Collections.Generic;
using UnityEditor;
using UtilityToolkit.Runtime;

namespace UtilityToolkit.Tests
{
    public class WeightedCollectionTests
    {
        [NUnit.Framework.Test]
        public void WeightedCollectionWithEqualProbabilityHasEvenSpread()
        {
            // Arrange
            var collection = new WeightedCollection<string>();
            for (int i = 0; i < 10; i++)
            {
                collection.Add("Item " + i, 1);
            }
            var counts = new Dictionary<string, int>();

            // Act
            for (int i = 0; i < 10000; i++)
            {
                string item = collection.GetRandomWeightedElement();
                if (!counts.ContainsKey(item))
                {
                    counts[item] = 0;
                }
                counts[item]++;
            }

            // Assert
            foreach (var kvp in counts)
            {
                UnityEngine.Debug.Log($"{kvp.Key}: {kvp.Value}");
                NUnit.Framework.Assert.IsTrue(kvp.Value is > 800 and < 1200, $"{kvp.Key} count {kvp.Value} is out of expected range.");
            }
        }
        
        [NUnit.Framework.Test]
        public void WeightedCollectionWithSkewedProbabilityRespectsWeights()
        {
            // Arrange
            var collection = new WeightedCollection<string>();
            collection.Add("Common Item", 9);
            collection.Add("Rare Item", 1);
            var counts = new Dictionary<string, int>();

            // Act
            for (int i = 0; i < 10000; i++)
            {
                string item = collection.GetRandomWeightedElement();
                if (!counts.ContainsKey(item))
                {
                    counts[item] = 0;
                }
                counts[item]++;
            }

            // Assert
            UnityEngine.Debug.Log($"Common Item: {counts.GetValueOrDefault("Common Item", 0)}");
            UnityEngine.Debug.Log($"Rare Item: {counts.GetValueOrDefault("Rare Item", 0)}");
            NUnit.Framework.Assert.IsTrue(counts.GetValueOrDefault("Common Item", 0) > counts.GetValueOrDefault("Rare Item", 0) * 5, "Common item was not selected significantly more often than rare item.");
        }
    }
}