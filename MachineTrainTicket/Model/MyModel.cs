using System.Collections.Generic;


/// <summary>
/// Namespace to represents all domain model entities
/// </summary>
namespace MachineTrainTicket.Model
{
    /// <summary>
    /// This class represents a model from data base
    /// </summary>
    class MyModel
    {
        /// <summary>
        /// Property that contain the avaliable stations
        /// </summary>
        private List<string> _stations = new List<string>();

        /// <summary>
        /// Model class constructor
        /// </summary>
        public MyModel()
        {
            _stations.AddRange(new string[] { "DARTFORD", "DARTMOUTH", "TOWER HILL",
                                             "DERBY", "LIVERPOOL", "LIVERPOOL LIME STREET",
                                             "PADDINGTON", "EUSTON", "LONDON BRIDGE", "VICTORIA",
                                             "LIVERPOOL LIME AVENUE"});            
        }

        /// <summary>
        /// Method that return a stations list 
        /// </summary>
        public List<string> Stations
        {
            get
            {
                return _stations;
            }            
        }
    }
}
