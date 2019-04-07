/// \mainpage Machine Train Ticket Documentation
///
///\section intro_sec Introduction
///
///This documentations describes informations about the source code of Machine Train Ticket application.
///The Machine Train Ticket Solition have two projects.\n
///A application project and the unit tests project.
/// 
///\section install_sec Installation
///
///\subsection step1 Release Folder
///
///You can get the binary files of release version in the follow path: "..\MachineTrainTicket\MachineTrainTicket\bin\Release\MachineTrainTicket.exe"
///
///\subsection step2 Debug Folder
///
///You can get the binary files of debug version in the follow path: "..\MachineTrainTicket\MachineTrainTicket\bin\Release\MachineTrainTicket.exe"
///
///\section author_sec Author
///
/// Author: Emerson Parizoto\n
/// Email: eparizoto@gmail.com\n
/// Version: 1.0 - Date: 10-16-2016\n 
/// 

using MachineTrainTicket.View;

/// <summary>
/// Represents Machine Train Ticket namespace
/// </summary>
namespace MachineTrainTicket
{
    /// <summary>
    /// This class starts Machine Train Ticket application
    /// </summary>
    class MachineTrainTicket
    {
        /// <summary>
        /// Main method to start application
        /// </summary>
        /// <param name="args">Arguments to pass to start program. Always empty.</param>
        static void Main(string[] args)
        {
            MyView view = new MyView();

            view.MountMainMenu();
            view.MonitoringKeyPressed();
        }
    }
}
