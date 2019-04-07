using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MachineTrainTicket.Controller;

/// <summary>
/// Namespace to represents all domain view entities
/// </summary>
namespace MachineTrainTicket.View
{
    /// <summary>
    /// This class is responsable to manager User Interface,
    /// show and positioning cursor and show messages from
    /// controller.
    /// </summary>
    class MyView
    {
        /// <summary>
        /// Represents a reference value to set row position cursor.
        /// </summary>
        public int OriginalRow { get; set; }

        /// <summary>
        /// Represents a reference value to set column positon cursor.
        /// </summary>
        public int OriginalColumn { get; set; }

        /// <summary>
        /// Represents last position row cursor that user typed.
        /// </summary>
        public int LastPositionUserTypedRow { get; set; }

        /// <summary>
        /// Represents last position column cursor that user typed.
        /// </summary>
        public int LastPositionUserTypedCol { get; set; }

        /// <summary>
        /// Represents string that will be used to search stations.
        /// </summary>
        private StringBuilder StringToFind;

        /// <summary>
        /// Controller instance.
        /// </summary>
        private MyController controller;

        /// <summary>
        /// Stations found list based on StringToFind
        /// </summary>
        private List<string> StationsFound;

        /// <summary>
        /// Next characters by avaliable stations
        /// </summary>
        ISet<char> NextChars;

        /// <summary>
        /// Construtor to inicialize class variables.
        /// </summary>
        public MyView()
        {
            Console.Clear();
            OriginalRow = Console.CursorTop;
            OriginalColumn = Console.CursorLeft;
            StringToFind = new StringBuilder();
            StringToFind.Clear();
            controller = new MyController();
            StationsFound = new List<string>();
            NextChars = new HashSet<char>();
        }

        /// <summary>
        /// Method responsable to mount main menu
        /// </summary>
        internal void MountMainMenu()
        {
            Console.WriteLine("Machine Train Ticket - Version 1.0.0.0");
            Console.WriteLine("======================================");
            Console.WriteLine();
            Console.WriteLine("Please, enter the station name: ");
            Console.WriteLine();
            Console.WriteLine("Stations: ");
            Console.WriteLine();
            Console.WriteLine("Next valid characters: ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press ENTER to clean search.");
            Console.WriteLine("Press ESC to stop application.");

            this.SetCursorToUserType();
        }

        /// <summary>
        /// Method responsable to write at specific position cursor.
        /// </summary>
        /// <param name="wordToWrite">Word that will be writed on specific cursor position</param>
        /// <param name="col">cursor column position</param>
        /// <param name="row">cursor row positions</param>
        internal void WriteAt(string wordToWrite, int col, int row)
        {
            try
            {
                Console.SetCursorPosition(OriginalColumn + col, OriginalRow + row);
                Console.Write(wordToWrite);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Method to format in uppercase, filter all characters entries and record last
        /// position cursor.
        /// </summary>
        /// <param name="keyInfo">Typed key press by user</param>
        internal void WriteKeyTyped(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.KeyChar == '\0')
                return;

            Console.Write(keyInfo.KeyChar.ToString().ToUpper());
            LastPositionUserTypedCol = Console.CursorLeft;
            LastPositionUserTypedRow = Console.CursorTop;
        }

        /// <summary>
        /// Method to clean all fields from UI and put cursor
        /// in correct position.
        /// </summary>
        internal void CleanSearches()
        {
            CleanFoundCharacters();
            CleanFoundStations();
            SetCursorToUserType();
        }

        /// <summary>
        /// Method to clean search line and prepare cursor to 
        /// user type next search.
        /// </summary>
        internal void CleanLineToUserType()
        {
            SetCursorToUserType();
            WriteAt(new string(' ', Console.WindowWidth), 31, 3);
            SetCursorToUserType();
        }

        /// <summary>
        /// Method to clean last search stations found.
        /// </summary>
        private void CleanFoundStations()
        {
            WriteAt(new string(' ', Console.WindowWidth), 0, 5);
            WriteAt("Stations: ", 0, 5);
        }

        /// <summary>
        /// Method to clean last search next valid characters.
        /// </summary>
        private void CleanFoundCharacters()
        {
            WriteAt(new string(' ', Console.WindowWidth), 0, 7);
            WriteAt("Next valid characters: ", 0, 7);
        }

        /// <summary>
        /// Method to put cursor in previous position that it was 
        /// and do not permit user erase UI screen.
        /// </summary>
        internal void SetCursorToPreviousPosition()
        {
            if (Console.CursorLeft <= 30)
            {
                SetCursorToUserType();
                return;
            }

            Console.Write(new string(' ', 1));
            Console.SetCursorPosition(LastPositionUserTypedCol, LastPositionUserTypedRow);
            LastPositionUserTypedCol = Console.CursorLeft;
            LastPositionUserTypedRow = Console.CursorTop;

            if(StringToFind.Length != 0)
                StringToFind.Remove((StringToFind.Length - 1), 1);

            FindStations();
        }

        /// <summary>
        ///Method to put cursor in correct column and line in screen
        ///to user type a seach word.
        /// </summary>
        internal void SetCursorToUserType()
        {
            Console.SetCursorPosition(OriginalColumn + 31, OriginalRow + 3);
        }

        /// <summary>
        /// Method to issue an user warning that application is finishing.
        /// </summary>
        internal void SetCursorToExit()
        {
            WriteAt("Thanks for using Machine Train Ticket ! (Press any key to close this window ...)", 0, 13);
            Console.ReadKey();
        }

        /// <summary>
        /// Method to put cursor in last position that it was when
        /// backgspace key was pressed.
        /// </summary>
        internal void SetCursorToLastPosition()
        {
            Console.SetCursorPosition(LastPositionUserTypedCol - 1, LastPositionUserTypedRow);
        }

        /// <summary>
        /// Method that contains monitoring loop to catch pressed keys
        /// and filter command keys doing a correct search word,
        /// that will be used to find stations.
        /// </summary>
        internal void MonitoringKeyPressed()
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                WriteKeyTyped(keyInfo);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Backspace:
                        SetCursorToPreviousPosition();
                        break;

                    case ConsoleKey.Enter:
                        CleanLineToUserType();
                        CleanSearches();
                        StringToFind.Clear();
                        break;

                    case ConsoleKey.Escape:
                        CleanLineToUserType();
                        break;

                    default:
                        break;
                }

                if (!(char.IsLetterOrDigit(keyInfo.KeyChar) || char.IsWhiteSpace(keyInfo.KeyChar)) || keyInfo.Key == ConsoleKey.Enter)
                    continue;

                StringToFind.Append(keyInfo.KeyChar.ToString().ToUpper());
                FindStations();

            } while (keyInfo.Key != ConsoleKey.Escape);

            SetCursorToExit();
        }

        /// <summary>
        /// Method that call controller function to search stations
        /// based in a search word.
        /// </summary>
        private void FindStations()
        {
            StationsFound.Clear();
            NextChars.Clear();

            if (StringToFind.Length != 0)
                controller.SearchString(StringToFind.ToString(), ref StationsFound, ref NextChars);

            ShowStationsChars(ref StationsFound, ref NextChars);
        }

        /// <summary>
        /// Method to format to UI the searched stations and chars found
        /// by the controller search method.
        /// </summary>
        /// <param name="stationsFound">The stations that were found.</param>
        /// <param name="nextChars">The first character of the next available stations.</param>
        internal void ShowStationsChars(ref List<string> stationsFound, ref ISet<char> nextChars)
        {
            CleanFoundStations();

            foreach (var item in stationsFound)
            {
                Console.Write(item);

                if (!item.Equals(stationsFound.Last()))
                    Console.Write(", ");
            }

            CleanFoundCharacters();

            foreach (var item in nextChars)
            {
                Console.Write("'" + item + "'");

                if (!item.Equals(nextChars.Last()))
                    Console.Write(", ");
            }

            Console.SetCursorPosition(LastPositionUserTypedCol, LastPositionUserTypedRow);
        }

    }
}
