using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

using MachineTrainTicket.Controller;

/// <summary>
/// Namespace to represents all domain unit tests. 
/// </summary>
namespace MachineTrainTicket.Tests
{
    /// <summary>
    /// This class is responsable to manager the unit tests method. 
    /// </summary>
    [TestClass()]
    public class MyControllerTests
    {
        /// <summary>
        /// This method run a test with the search word "DART" and expect as follow:\n
        /// The characterf of "F", "M"\n
        /// The found stations: "DARTFORD", "DARTMOUTH"
        /// </summary>
        [TestMethod()]
        public void SearchStringTestDART()
        {
            MyController target = new MyController();

            string word = "DART";
            List<string> expectedStations = new List<string>();
            List<char> expectedNextChars = new List<char>();
            List<string> stations = new List<string>();
            ISet<char> nextChars = new HashSet<char>();

            expectedStations.AddRange(new string[] { "DARTFORD", "DARTMOUTH" });
            expectedNextChars.AddRange(new char[] { 'F', 'M' });

            target.SearchString(word, ref stations, ref nextChars);

            CollectionAssert.AreEqual(expectedStations, stations);
            CollectionAssert.AreEqual(expectedNextChars, nextChars.ToList<char>());
        }

        /// <summary>
        /// This method run a test with the search word "LIVERPOOL" and expect as follow:\n
        /// The characterf of " " (nothing, or better, SPACE char)\n
        /// The found stations: "LIVERPOOL", "LIVERPOOL LIME STREET", "LIVERPOOL LIME AVENUE" 
        /// </summary>
        [TestMethod()]
        public void SearchStringTestLIVERPOOL()
        {
            MyController target = new MyController();

            string word = "LIVERPOOL";
            List<string> expectedStations = new List<string>();
            List<char> expectedNextChars = new List<char>();
            List<string> stations = new List<string>();
            ISet<char> nextChars = new HashSet<char>();

            expectedStations.AddRange(new string[] { "LIVERPOOL", "LIVERPOOL LIME STREET", "LIVERPOOL LIME AVENUE" });
            expectedNextChars.AddRange(new char[] { ' ' });

            target.SearchString(word, ref stations, ref nextChars);

            CollectionAssert.AreEqual(expectedStations, stations);
            CollectionAssert.AreEqual(expectedNextChars, nextChars.ToList<char>());
        }

        /// <summary>
        /// This method run a test with the search word "KINGS CROSS" and expect as follow:\n
        /// No next characters\n
        /// No stations
        /// </summary>
        [TestMethod()]
        public void SearchStringTestKINGS_CROSS()
        {
            MyController target = new MyController();

            string word = "KINGS CROSS";
            List<string> expectedStations = new List<string>();
            List<char> expectedNextChars = new List<char>();
            List<string> stations = new List<string>();
            ISet<char> nextChars = new HashSet<char>();

            target.SearchString(word, ref stations, ref nextChars);

            CollectionAssert.AreEqual(expectedStations, stations);
            CollectionAssert.AreEqual(expectedNextChars, nextChars.ToList<char>());
        }

        /// <summary>
        /// This method run a test with the search word "D" and expect as follow:\n
        /// The characterf of "A", "E"\n
        /// The found stations: "DARTFORD", "DARTMOUTH", "DERBY"
        /// </summary>
        [TestMethod()]
        public void SearchStringTestD()
        {
            MyController target = new MyController();

            string word = "D";
            List<string> expectedStations = new List<string>();
            List<char> expectedNextChars = new List<char>();
            List<string> stations = new List<string>();
            ISet<char> nextChars = new HashSet<char>();

            expectedStations.AddRange(new string[] { "DARTFORD", "DARTMOUTH", "DERBY"});
            expectedNextChars.AddRange(new char[] { 'A', 'E' });

            target.SearchString(word, ref stations, ref nextChars);

            CollectionAssert.AreEqual(expectedStations, stations);
            CollectionAssert.AreEqual(expectedNextChars, nextChars.ToList<char>());
        }

        /// <summary>
        /// This method run a test with the search word "LIVERPOOL " and expect as follow:\n
        /// The characterf of "L"\n
        /// The found stations: "LIVERPOOL LIME STREET", "LIVERPOOL LIME AVENUE"
        /// </summary>
        [TestMethod()]
        public void SearchStringTestLIVERPOOL_()
        {
            MyController target = new MyController();

            string word = "LIVERPOOL ";
            List<string> expectedStations = new List<string>();
            List<char> expectedNextChars = new List<char>();
            List<string> stations = new List<string>();
            ISet<char> nextChars = new HashSet<char>();

            expectedStations.AddRange(new string[] { "LIVERPOOL LIME STREET", "LIVERPOOL LIME AVENUE" });
            expectedNextChars.AddRange(new char[] { 'L' });

            target.SearchString(word, ref stations, ref nextChars);

            CollectionAssert.AreEqual(expectedStations, stations);
            CollectionAssert.AreEqual(expectedNextChars, nextChars.ToList<char>());
        }

        /// <summary>
        /// This method run a test with the search word "LO" and expect as follow:\n
        /// The characterf of "N"\n
        /// The found stations: "LONDON BRIDGE"
        /// </summary>
        [TestMethod()]
        public void SearchStringTestLO()
        {
            MyController target = new MyController();

            string word = "LO";
            List<string> expectedStations = new List<string>();
            List<char> expectedNextChars = new List<char>();
            List<string> stations = new List<string>();
            ISet<char> nextChars = new HashSet<char>();

            expectedStations.AddRange(new string[] { "LONDON BRIDGE" });
            expectedNextChars.AddRange(new char[] { 'N' });

            target.SearchString(word, ref stations, ref nextChars);

            CollectionAssert.AreEqual(expectedStations, stations);
            CollectionAssert.AreEqual(expectedNextChars, nextChars.ToList<char>());
        }

        /// <summary>
        /// This method run a test with the search word "SAINT PAUL" and expect as follow:\n
        /// No next characters\n
        /// No stations
        /// </summary>
        [TestMethod()]
        public void SearchStringTestSAINT_PAUL()
        {
            MyController target = new MyController();

            string word = "SAINT PAUL";
            List<string> expectedStations = new List<string>();
            List<char> expectedNextChars = new List<char>();
            List<string> stations = new List<string>();
            ISet<char> nextChars = new HashSet<char>();
            
            target.SearchString(word, ref stations, ref nextChars);

            CollectionAssert.AreEqual(expectedStations, stations);
            CollectionAssert.AreEqual(expectedNextChars, nextChars.ToList<char>());
        }
    }
}