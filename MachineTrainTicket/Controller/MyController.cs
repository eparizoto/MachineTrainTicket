using System;
using System.Collections.Generic;
using System.Linq;
using MachineTrainTicket.Model;

/// <summary>
/// Namespace to represents all domain controller entities
/// </summary>
namespace MachineTrainTicket.Controller
{
    /// <summary>
    /// Class that have all business methods
    /// </summary>
    public class MyController
    {
        /// <summary>
        /// Represents a instance from a data base
        /// </summary>
        private MyModel model = new MyModel();

        /// <summary>
        /// List that contains all avaliable stations
        /// </summary>
        private List<string> StationsAvaliable;

        /// <summary>
        /// Constructor class
        /// </summary>
        public MyController()
        {
            StationsAvaliable = model.Stations;
        }
        
        /// <summary>
        /// Method that execute a search inside model to have
        /// avaliable stations and the next avaliable chars
        /// from avaliable stations
        /// </summary>
        /// <param name="word">string that will find inside stations model</param>
        /// <param name="stations">stations avaliable based on word typed by user</param>
        /// <param name="nextCharacters">next first chars avaliable from stations </param>
        public void SearchString(string word, ref List<string> stations, ref ISet<char> nextCharacters)
        {
            stations.Clear();
            nextCharacters.Clear();

            stations = StationsAvaliable.FindAll(s => s.StartsWith(word));
            
            foreach (var item in stations)
            {
                char c = item.ElementAtOrDefault(word.Length);

                if (! char.IsControl(c))
                    nextCharacters.Add(c);               
            }
        }

    }
}
