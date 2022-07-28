using System;
using System.Collections.Generic;

namespace MapReduceApproach
{
    /// <summary>
    /// The class implements the calculation of the words frequency in source array by using MapReduce approach
    /// <see cref="https://en.wikipedia.org/wiki/MapReduce"/>.
    /// </summary>
    public sealed class MapReduceModel
    {
        /// <summary>
        /// Initialize instance of the class.
        /// </summary>
        /// <param name="words">Source words.</param>
        /// <param name="nodes">Count of the nodes for the words processing.</param>
        /// <exception cref="ArgumentNullException">Thrown if words is null.</exception>
        /// <exception cref="ArgumentException">Thrown if words is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if nodes less than 0 or more than count of words.</exception>
        public MapReduceModel(string[] words, int nodes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get or set counts of the nodes in MapReduce model.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if nodes less than 0 or more than count of words.</exception>
        public int Nodes
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Calculate the words frequency in source array.
        /// </summary>
        /// <returns>Information about of the word frequency in source array.</returns>
        /// <example>
        /// words: {"Serialize", "Json", ".NET", "open", "and", "deserialize", ".NET", "object", "with", "Json" }
        /// result: {("Serialize", 1), ("Json", 2), (".NET", 2), ("open", 1), ("and", 1), ("deserialize", 1), ("object", 1), ("with", 1)}
        /// </example>
        public IReadOnlyList<(string, int)> Process()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Mapping: create list of the pair (key, value) where key is word and value is 1 indicates that the word exists in the set of words.
        /// </summary>
        /// <param name="wordsInOneNode">The words in separated node.</param>
        /// <returns>Dictionary where key is word and value is word frequency in the nodes.</returns>
        /// <example> for a single node:
        /// words: {"Serialize", "Json", ".NET", "open", "and", "deserialize", ".NET", "object", "with", "Json" }
        /// result: {("Serialize", 1), ("Json", 1), (".NET", 1), ("open", 1), ("and", 1), ("deserialize", 1), (".NET", 1), ("object", 1), ("with", 1), ("Json", 1) }
        /// </example>
        private IList<(string Key, int Value)> Map(string[] wordsInOneNode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shuffling: Union all pairs on base a key (word) in dictionary.
        /// </summary>
        /// <param name="mapInput">Map result.</param>
        /// <param name="shuffleOutput">Shuffle result.</param>
        /// <example>
        /// mapInput: on base all nodes
        ///     {("Serialize", 1), ("Json", 1), (".NET", 1), ("deserialize", 1), }
        ///     {("Serialize", 1), ("Serialize", 1), ("Serialize", 1), ("Json", 1)}
        ///     {("Serialize", 1), (".NET", 1), ("deserialize", 1), ("object", 1)}
        /// shuffleOutput:
        ///     {("Serialize", { 1, 1, 1, 1, 1}), ("Json", {1, 1}), (".NET", {1, 1}), ("deserialize", {1, 1}), ("object", {1}) }
        /// </example>
        private void Shuffle(IList<(string Key, int Value)> mapInput, IDictionary<string, IList<int>> shuffleOutput)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculate frequency of the given word in the source array of the words.
        /// </summary>
        /// <param name="wordFrequencyList">List of frequency of the given word.</param>
        /// <returns>Sum of the list elements.</returns>
        /// <example> for a single word:
        /// wordFrequencyList: { 1, 1, 1, 1, 1}
        /// result: 5
        /// </example>
        private int Reduce(IList<int> wordFrequencyList)
        {
            throw new NotImplementedException();
        }
    }
}
