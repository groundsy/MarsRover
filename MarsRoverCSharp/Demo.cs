using System;
using System.Dynamic;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverCSharp.Core;
using MarsRoverCSharp.Core.Commander;
using MarsRoverCSharp.Core.LandingSurface;
using MarsRoverCSharp.Core.Rover;

/*  Eric Grounds
 *  Mars Rover Problem
 *  
 *  Demo
 *  
 *  Instructions to run the demo are included in the Documentation folder of the Project.
 */

namespace MarsRoverCSharp
{
    class Demo
    {
        public static void Main(string[] args)
        {
            // Just adding some color :)
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            bool fileExists = false;
            var filename = string.Empty;
            var command = string.Empty;
            var commandStringBuilder = new StringBuilder();

            // If the user passed in a filename through the command line
            if (args.Length != 0)
            {
                // Check if that file exists.
                filename = args[0];
                fileExists = CheckIfFileExists(filename);
                // If the passed in file doesn't exist, ask the user for a new file.
                if (!fileExists)
                {
                    do
                    {
                        Console.Write("\nPlease enter a file name. For example: 'test.txt' ");
                        filename = Console.ReadLine();
                        fileExists = CheckIfFileExists(filename);
                    } while (!fileExists); // Keep asking until a valid filename is given.
                }
            }
                // The user didn't pass in a filename through the command line.
            else
            {
                // Ask the user for a filename.
                do
                {
                    Console.Write("\nPlease enter a file name. For example: 'test.txt' ");
                    filename = Console.ReadLine();
                    fileExists = CheckIfFileExists(filename);
                } while (!fileExists); // Keep asking until a valid filename is given.
            }
            // Once we have a valid file to read from, start reading.
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    // Read each line of the file and append it to the commandStringBuilder.
                    while ((command = reader.ReadLine()) != null)
                    {
                        commandStringBuilder.AppendLine(command);
                    }
                    reader.Close();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nTest Input:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(commandStringBuilder);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nOutput:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                // Run the test given by the problem statement.
                RunTest(commandStringBuilder.ToString());
            }
            // If something bad happened while reading the file, let the user know.
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nThere was a problem with {0}", filename);
                Console.WriteLine(e.Message);
            }
            // Wait for the user before exiting.
            Console.ResetColor();
            Console.WriteLine("\nPress any key to continue");
            Console.ReadLine();
        } 
        
        /****************************************************************************  
         * Checks if a file exists given the file name.                             *
         *                                                                          *
         *  Returns true if the file exists, returns false otherwise.               *
         ***************************************************************************/
        private static bool CheckIfFileExists(string filename)
        {
            bool fileExists = false;
            if (!string.IsNullOrWhiteSpace(filename))
            {
                try
                {
                    using (FileStream fileStream = File.Open(filename, FileMode.Open))
                    {
                        fileExists = true;
                    }
                }
                catch (FileNotFoundException exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThere was a problem with {0}\n" + 
                                      exception.Message +
                                    "\nLet's try again.",
                        filename);
                    Console.ForegroundColor = ConsoleColor.Green;
                } 
            }
            return fileExists;
        }


        /****************************************************************************  
         * Runs the test specified by the problem statement                         *
         *                                                                          *
         ****************************************************************************/
        public static void RunTest(string testInput)
        {
            var inputCommands = testInput.Split(new [] {Environment.NewLine}, StringSplitOptions.None);

            LandingSurfaceCommander plateauCommander = new LandingSurfaceCommander(inputCommands[0]);
            
            // Create and initialize a new rover squad and pass in the landing surface that the rovers will be deployed on.
            RoverSquadCommander roverSquad = new RoverSquadCommander(plateauCommander.GetLandingSurface());

            // Deploy rover one to the squad with the given position and explore commands.
            roverSquad.DeployNewRover(inputCommands[1], inputCommands[2]);

            // Deploy rover two to the squad with the given position and explore commands.
            roverSquad.DeployNewRover(inputCommands[3], inputCommands[4]);

            // Get rover squad reports.
            var roverSquadReports = roverSquad.GetRoverSquadReport();

            // Write each report to the screen.
            foreach (var roverReport in roverSquadReports)
            {
                Console.WriteLine(roverReport);
            }
        }

        // The input specified in the problem statement.
        private static string BuildTestString()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");
            return commandStringBuilder.ToString();
        }
    }
}
