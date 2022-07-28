using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MapReduceApproach.Tests
{
    [TestFixture]
    public class MapReduceModelTests
    {
        private static IEnumerable<TestCaseData> TestDataForProcess
        {
            get
            {
                yield return new TestCaseData(
                    "Welcome to the first interactive tutorial! It will help you get started with the most " +
                    "important Rider code editor features. Please read the notes below before you start the tutorial.",
                    3,
                    new List<(string, int)>
                    {
                        ("Welcome", 1),
                        ("to", 1),
                        ("the", 4),
                        ("first", 1),
                        ("interactive", 1),
                        ("tutorial", 2),
                        ("It", 1),
                        ("will", 1),
                        ("help", 1),
                        ("you", 2),
                        ("get", 1),
                        ("started", 1),
                        ("with", 1),
                        ("most", 1),
                        ("important", 1),
                        ("Rider", 1),
                        ("code", 1),
                        ("editor", 1),
                        ("features", 1),
                        ("Please", 1),
                        ("read", 1),
                        ("notes", 1),
                        ("below", 1),
                        ("before", 1),
                        ("start", 1),
                    });
                yield return new TestCaseData(
                    "You can create a new project in a new solution using File | New... or " +
                    "add a new project to the existing solution by right-clicking the solution " +
                    "or solution folder node in the Solution Explorer, and choosing Add | New Project.",
                    4,
                    new List<(string, int)>
                    {
                        ("You", 1),
                        ("can", 1),
                        ("create", 1),
                        ("a", 3),
                        ("new", 3),
                        ("project", 2),
                        ("in", 2),
                        ("solution", 4),
                        ("using", 1),
                        ("File", 1),
                        ("New", 2),
                        ("or", 2),
                        ("add", 1),
                        ("to", 1),
                        ("the", 3),
                        ("existing", 1),
                        ("by", 1),
                        ("right-clicking", 1),
                        ("folder", 1),
                        ("node", 1),
                        ("Solution", 1),
                        ("Explorer", 1),
                        ("and", 1),
                        ("choosing", 1),
                        ("Add", 1),
                        ("Project", 1),
                    });
                yield return new TestCaseData(
                    "Three blind mice, Three blind mice, See how they run! See how they run! They all ran after the farmer's wife, " +
                    "Who cut off their tails, With a carving knife. Did you ever see such a thing in your life, As three blind mice.",
                    4,
                    new List<(string, int)>
                    {
                        ("Three", 2),
                        ("blind", 3),
                        ("mice", 3),
                        ("See", 2),
                        ("how", 2),
                        ("they", 2),
                        ("run", 2),
                        ("They", 1),
                        ("all", 1),
                        ("ran", 1),
                        ("after", 1),
                        ("the", 1),
                        ("farmer's", 1),
                        ("wife", 1),
                        ("Who", 1),
                        ("cut", 1),
                        ("off", 1),
                        ("their", 1),
                        ("tails", 1),
                        ("With", 1),
                        ("a", 2),
                        ("carving", 1),
                        ("knife", 1),
                        ("Did", 1),
                        ("you", 1),
                        ("ever", 1),
                        ("see", 1),
                        ("such", 1),
                        ("thing", 1),
                        ("in", 1),
                        ("your", 1),
                        ("life", 1),
                        ("As", 1),
                        ("three", 1),
                    });
                yield return new TestCaseData(
                    "Three blind mice, Three blind mice, See how they run! See how they run! They all ran after the farmer's wife, " +
                    "Who cut off their tails, With a carving knife. Did you ever see such a thing in your life, As three blind mice.",
                    5,
                    new List<(string, int)>
                    {
                        ("Three", 2),
                        ("blind", 3),
                        ("mice", 3),
                        ("See", 2),
                        ("how", 2),
                        ("they", 2),
                        ("run", 2),
                        ("They", 1),
                        ("all", 1),
                        ("ran", 1),
                        ("after", 1),
                        ("the", 1),
                        ("farmer's", 1),
                        ("wife", 1),
                        ("Who", 1),
                        ("cut", 1),
                        ("off", 1),
                        ("their", 1),
                        ("tails", 1),
                        ("With", 1),
                        ("a", 2),
                        ("carving", 1),
                        ("knife", 1),
                        ("Did", 1),
                        ("you", 1),
                        ("ever", 1),
                        ("see", 1),
                        ("such", 1),
                        ("thing", 1),
                        ("in", 1),
                        ("your", 1),
                        ("life", 1),
                        ("As", 1),
                        ("three", 1),
                    });
            }
        }

        [TestCaseSource(nameof(TestDataForProcess))]
        public void ProcessTests(string source, int nodes, List<(string, int)> expected)
        {
            var words = source.Split(new char[] { ' ', ',', '!', '|', '.' }, StringSplitOptions.RemoveEmptyEntries);
            MapReduceModel mapReduceModel = new(words, nodes);
            var actual = mapReduceModel.Process();
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestCase(2)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(10)]
        public void Process_WithTheSameWordsAndDifferentNodes_ReturnSameResult(int nodes)
        {
            var words = new string[]
            {
                "Serialize", "Json", ".NET", "open", "and", "deserialize", "any", ".NET", "object", "with", "Json",
                ".NET", "JSON", "serializer", "Json", ".NET", "open", "Serialize", "Json", "Json", "Json", "and",
                "Json", "object", "object", "serializer",
            };

            var expected = new List<(string, int)>
            {
                ("Serialize", 2),
                ("Json", 7),
                (".NET", 4),
                ("open", 2),
                ("and", 2),
                ("deserialize", 1),
                ("any", 1),
                ("object", 3),
                ("with", 1),
                ("JSON", 1),
                ("serializer", 2),
            };

            MapReduceModel mapReduceModel = new(words, nodes);
            var actual = mapReduceModel.Process();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(0)]
        [TestCase(-4)]
        [TestCase(14)]
        [TestCase(11)]
        public void Process_NodesValueOutOfRange_ThrownArgumentOutOfRangeException(int nodes)
        {
            var words = "Three blind mice, Three blind mice, See how they run!".Split(
                new char[] { ' ', ',', '!', '|', '.' }, StringSplitOptions.RemoveEmptyEntries);
            Assert.Throws<ArgumentOutOfRangeException>(() => new MapReduceModel(words, nodes),
                "Count of nodes cannot be less than 0 or more than count of the words.");
        }

        [Test]
        public void Process_WordsArrayIsNull_ThrownArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new MapReduceModel(null!, 4),
                "ArrayOf the words cannot be null.");
        }

        [Test]
        public void Process_WordsArrayIsEmpty_ThrownArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new MapReduceModel(Array.Empty<string>(), 4),
                "ArrayOf the words cannot be empty.");
        }
    }
}
