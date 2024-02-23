/* Project Week 8 Project Todo List
 * Author        : Pedro Martinez
 * File Name     : Utils.cs
 * Start Date    : 19/02/2024
 * Finished Date : 
 */

namespace W8TodoList
{
    internal class Utils
    {

        // Validate String Entry 
        public static string CheckStr(string s)
        {
            s = Console.ReadLine().Trim().ToUpper();
            if (s.Length == 0)
                { MsgInvalidEntry(); }
            return s; 
        }


        // Validate String Entry with valid range
        public static string CheckStr(string s, string[] range)
        {
            s = Console.ReadLine().Trim().ToUpper();
            if ( ! range.Contains(s) || (s.Length == 0))
            {
               MsgInvalidEntry(); 
            }
            return s;
        }

        // Validate String Entry Y ot N 
        public static bool PromptYN()
        {
            bool result = false;
            string[] range = {"Y", "N"}; 

            Console.Write("Are you sure (Y/N) ? :" );
            string s = Console.ReadLine().Trim().ToUpper();
            
            if (!range.Contains(s) || (s.Length == 0))
            {
                MsgInvalidEntry();
            }
            if (s == "Y") { result = true; }
            else if (s == "N")  { result = false; }
            return result;
        }            

        // Convert string to bool 
        public static bool GetBool(string s)
        {
            bool result = false;
            s.Trim().ToUpper();
            if (s == "N") 
                { result = false; }
            else if (s == "Y") 
                { result  = true; }
            return result;
        }   


        //  Show error messages  
        public static void MsgInvalidEntry()
        {
            MsgColor("Invalid Entry! Please try again: ", "r");
        }


        // Default Entry Error Messsage
        public static void MsgInvalidEntry( Exception e )
        {
            MsgColor("Invalid Entry! Please try again\n " + e.Data, "r");
        }


        // Color text in Prompt 
        public static void MsgColor(string msg, string color)
        {
            switch (color)
            {
                case "y":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "r":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "g":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "b":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "w":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
            
            Console.WriteLine(msg);
            Console.ResetColor();
        }


        // Return File Path with filename included 
        public static string GetFilePath()
        {
            string dir = System.IO.Directory.GetCurrentDirectory();
            return dir.Split("\\bin")[0] + "\\Tasks.txt";
        }

        // Delete File Tasks.txt 
        public static void DeleteFile()
        {
            File.Delete(GetFilePath());
        }

    } //class 

} //namespace
