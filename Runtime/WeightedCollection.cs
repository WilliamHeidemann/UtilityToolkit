using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace UtilityToolkit.Runtime
{
    public interface IWeightedCollection<T>
    {
        T GetRandomWeightedElement();
        void Add(T item, float weight);
    }

    public class WeightedCollection<T> : IWeightedCollection<T>
    {
        private readonly ICollection<(T, float)> _collection;
        private float SumOfWeights => _collection.Sum(tuple => tuple.Item2);

        public WeightedCollection() => _collection = new List<(T, float)>();
        public WeightedCollection(ICollection<(T, float)> collection) => _collection = collection;

        public void Add(T item, float weight) => _collection.Add((item, weight));

        public T GetRandomWeightedElement()
        {
            if (_collection.Count == 0)
            {
                throw new Exception("Cannot get item from empty weighted collection.");
            }

            float roll = Random.Range(0, SumOfWeights);

            var count = 0f;
            
            foreach ((T item, float weight) in _collection)
            {
                count += weight;
                if (roll < count) return item;
            }

            throw new Exception("Failed to get item from weighted collection.");
        }
    }
}