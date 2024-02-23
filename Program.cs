/* Project Week 8 Project Todo List
 * Author        : Pedro Martinez
 * Start Date    : 19/02/2024
 * Finished Date : 
 */

// Vars 
using System.Text;
using System.Threading.Tasks;
using 
    static W8TodoList.Utils;

bool exitProgram = false;

// Create Task List 
List<Task> listTasks = new List<Task>();

MsgColor("Welcome to Todo List", "y");
//MsgColor("You have X Tasks to do and Y Tasks finished", "w");
exitProgram = ShowMenu(listTasks, true);

if (listTasks.Count > 0)
{
    while (!exitProgram)
    {
        exitProgram = ShowMenu(listTasks, true);
    }
}

// Internal Procs =============================================

// Shows the main Menu 
 static bool ShowMenu(List<Task> list, bool showList) 
{
    string sImput;
    string projSort = "";
    bool exit = false;
    showList = true;

    string[] menuRange = { "1", "2", "3", "4", "5","Q" };

    list = ReadFile();
    //Console.Clear();
    while (!exit)
    {   
        // show list if not empty
        if (list.Count > 0)
        {
            if (showList) // Flag To stop showing list twice  
            {
                ShowList(true);
                showList = false;
            }
        }
        
        Console.WriteLine("");
        
        MsgColor("(1) Show Task List ( sort by Project and Date)", "g");
        MsgColor("(2) Show Task List ( sort by Date)", "g");
        MsgColor("(3) Add New Task", "g");
        MsgColor("(4) Edit Task", "g");
        MsgColor("(5) Remove Task", "g");
        MsgColor("(Q) Save and Quit", "g");
        
        Console.WriteLine("");
        Console.Write("Choose an Option: ");

        sImput = CheckStr("", menuRange );

        switch (sImput)
        {
            case "1": 
                ShowList(true);
                break;
            case "2":
                ShowList(false);
                break;
            case "3":
                Add(); 
                ShowList(true);
                break;
            case "4": 
                Edit();
                ShowList(true);
                break;
            case "5": 
                Delete(list); 
                ShowList(true);
                break;
            case "Q": 
                exit = true;
                break;
        }
    }

    return exit;

}  // ShowMenu 

//static List<Task> Add() // Add new entry Done!
static void Add() // Add new entry Done!
{
    //int iId = 0;

    string sTaskName = "",
        sTaskDate = "",
        sStatus = "",
        sProj = "",
        sImput = "";

    bool exit = false,
         exitEntry = false,
         validData = false;

    string[] range = { "Y", "N", "Q" }; // Valid Entries 

    DateTime dt = DateTime.Now;

    List<Task> listTasks = new List<Task>();
    listTasks = ReadFile();
    
    while (!exitEntry)
    {
        validData = true;

        while (!exit) // TaskName
        {
            MsgColor(" Press \"Q\" anytime to quit!", "b");
            Console.Write("Task: ");
            sTaskName = CheckStr("");

            if (sTaskName == "Q")
            {
                exit = true;
                exitEntry = true;
                validData = false;
                break;
            }
            else
            {
                break;
            }
        }

        while (!exit) // TaskDate
        {
            try
            {
                Console.Write("Date Due DD/MM/YYYY: ");
                sTaskDate = Console.ReadLine().Trim().ToUpper();
                if (sTaskDate == "Q")
                {
                    exit = true;
                    exitEntry = true;
                    validData = false;
                    break;
                }
                dt = Convert.ToDateTime(sTaskDate);
                break;
            }
            catch 
            {
                MsgInvalidEntry();

            }
        }

        while (!exit) // Project
        {
            Console.Write("Project: ");
            sProj = CheckStr("");

            if (sProj == "Q")
            {
                exit = true;
                exitEntry = true;
                validData = false;
                break;
            }
            else
            {
                break;
            }
        }


        if (validData) // Add Task Objs in list
        {
            listTasks.Add(new Task(GetId(listTasks), sTaskName, false, dt, sProj));
            MsgColor("Task entry succesfull!", "y");
            Console.WriteLine("");
            validData = false;
            exit = false;
        }
    }   // while (!exitEntry)

    // Save changes to file
    //DeleteFile();
    WriteFile(listTasks);

} // Add() 

// Menu Edit function
static void Edit()
{
    string
        sId = "",
        sTaskName = "",
        sTaskDate = "",
        sStatus = "",
        sProj = "",
        sImput = "";

    bool exit = false,
         exitEntry = false,
         validData = false;

    //int id = 0;
    string[] range = { "Y", "N", "Q" }; // Valid Entries 

    DateTime dt = DateTime.Now;

    List<Task> list = new List<Task>();
    list = ReadFile();

    while (!exit)
    {
        Console.WriteLine();
        Console.Write(" Enter a Task Id to Edit : ");
        sImput = CheckStr("");
        if (sImput == "Q")
        {
            exit = true;
            break;
        }
        
        if (list.Count > 0 )
        {
            //sId  = list.Where( list => list.Id == Convert.ToInt32(sImput)).ToString();
            IEnumerable<Task> query = from p in list
                                      where p.Id == Convert.ToInt32(sImput)
                                      select p;

            foreach (Task p in query)
            {
                sId = p.Id.ToString();
                sTaskName = p.Name;
                sTaskDate = p.TaskDate.ToLongDateString();
                sStatus = p.Status.ToString();
                sProj = p.ProjName;
            }

            // Check if Id exists
            if (query.Count() > 0) // edit data 
            {
                validData = true;

                while (!exit) // TaskName
                {
                    MsgColor(" Press \"Q\" anytime to quit!", "b");
                    Console.Write("Task: ");
                    sTaskName = CheckStr("");

                    if (sTaskName == "Q")
                    {
                        exit = true;
                        exitEntry = true;
                        validData = false;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }

                while (!exit) // TaskDate
                {
                    try
                    {
                        Console.Write("Date Due DD/MM/YYYY: ");
                        sTaskDate = Console.ReadLine().Trim().ToUpper();
                        if (sTaskDate == "Q")
                        {
                            exit = true;
                            exitEntry = true;
                            validData = false;
                            break;
                        }
                        dt = Convert.ToDateTime(sTaskDate);
                        break;
                    }
                    catch
                    {
                        MsgInvalidEntry();
                    }
                }

                while (!exit) // Status 
                {
                    MsgColor("Enter ( \"Y\" for Done || \"N\" for not finished.", "b");
                    Console.Write("Status: ");

                    sStatus = CheckStr("", range);
                    if (sStatus == "Q")
                    {
                        exit = true;
                        exitEntry = true;
                        validData = false;
                        break;
                    }
                    break;
                }

                // Add Task Objs in list
                if (validData)
                {
                    list = DeleteFromList(list, Convert.ToInt32(sId));

                    // Create new obj with data to edit 
                    list.Add(new Task(Convert.ToInt32(sId), sTaskName, GetBool(sStatus), dt, sProj));
                    WriteFile(list);

                    MsgColor("Task has been saved!", "y");
                    Console.WriteLine("");
                    exit = true;
                    break;
                }

            }
            else
            {
                MsgColor(" Id does not exist!", "r");
            } // Query count
        }
        else
        {
            MsgColor("There are no Tasks to edit!", "r");
            exit = true;
            break;
        }
    } //! exit
} // Edit()


// Set New id for Add() 
static int GetId(List<Task> list)
{
    list = ReadFile();
    return list.Count + 1;
}


// Menu ShowList () Done! 
static void ShowList(bool sortproject)    
{
    List<Task> list = new List<Task>();
    list = ReadFile();
    DateTime dt = DateTime.Now;
    dt = dt.AddDays(7);

    IEnumerable<Task> query;
    
    if (sortproject)
    {
        query = from p in list
                orderby p.ProjName, p.TaskDate
                select p;
    } 
    else
    {
        query = from p in list
                orderby p.TaskDate
                select p;
    }
    
    if (list.Count > 0)
    {
        Console.WriteLine("");
        MsgColor("Project ".PadRight(21) + "Id".PadRight(6) + "Task ".PadRight(26) + "Status ".PadRight(12) + "Date Due", "g");
        
        string scolor = "";
        string sStatus = "";

        foreach (var p in query)
        {
            if (p.Status == true)
            {
                sStatus = "[X}";
                scolor = "w";
            }
            else
            {
                sStatus = "[ ]";
                scolor = "y";
                if (p.TaskDate <= dt )
                {
                    scolor = "r";
                }
            }

            MsgColor(p.ProjName.PadRight(20) + " " +
                     p.Id.ToString().PadRight(5) + " " +
                     p.Name.PadRight(25) + " " +
                     sStatus.PadRight(11) + " " +
                     p.TaskDate.ToString("yyyy-MM-dd"), scolor);
        }
    } 
    else 
    {
        MsgColor("There are no entries in Task Program!", "y");
    }
}


// Write list to file - Done!
static void WriteFile ( List<Task> list )   
{
    DeleteFile();
    string listString = ConvertToCSV(list);
    string filePath = GetFilePath();

    try
    {
        FileStream fs;
        if (list.Count == 0)
        {
            fs = File.Open(filePath, FileMode.Create);
        }
        else
        {
            fs = File.Open(filePath, FileMode.Append);
        }
        using (StreamWriter sw = new StreamWriter(fs))
            sw.Write(listString);
        fs.Close();
    }
    catch (Exception e)
    {
        MsgColor( "File could not be opened!" + e.Data, "r");
    }
}

// Done!    
static List<Task> ReadFile()  
{
    string  lines = "",
            filePath = "";

    StringBuilder sb = new StringBuilder();
    List<Task> list = new List<Task>();

    filePath = GetFilePath();   

    if (File.Exists(filePath))
    {
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            { 
                while ((lines = sr.ReadLine()) != null)
                {
                    list = ConvertToList(list, lines);
                }
            }
        }
        catch (Exception e)
        { 
            MsgColor( "There are no tasks to Show - " + e.Data ,"r");
        }
    }
    return list;
}


// convert To List Done! 
static List<Task> ConvertToList(List<Task> list, string input)  
{
    string[] listString = input.TrimEnd(',').Split(',').ToArray();

    list.Add(new Task( Convert.ToInt32(listString[0]),    // Id
                       Convert.ToString(listString[1]).Trim(),   // Name  
                       Convert.ToBoolean(listString[2]),  // Status 
                       Convert.ToDateTime(listString[3]), // Date 
                       Convert.ToString(listString[4]).Trim()) );// Project 
    return list;
}


// TaskList to CSV  Done!
static string ConvertToCSV( List<Task> list) // Done
{
    StringBuilder sb = new StringBuilder();
    foreach (Task p in list)
    {
        sb.AppendLine($"{p.Id},{p.Name}, {p.Status.ToString()}, {p.TaskDate.ToString("yyyy-MM-dd")},{p.ProjName}, ");
    }
    return sb.ToString();
}


// Delete entry in text Done! 
static List<Task> DeleteFromList(List<Task> alist, int id) // Done !
{
    alist = ReadFile();
    int pos = alist.FindIndex(p => p.Id == id);
    if (pos == -1)
    {
        MsgColor(" Id does not exist!", "r");
        return alist;
    }
    else
    {
        alist.RemoveAt(pos);
        pos++;
        return alist;
    }
}

// Menu Delete function Done! 
static void Delete(List<Task> list)
{ 
    string sImput = "";
    string sId = ""; 
    string[] range = { "Y", "N", "Q" };
    bool exit = false;
    
    MsgColor(" Press \"Q\" anytime to quit!", "b");

    while (!exit)
    {
        Console.Write("Enter Task Id to remove: ");
        sId = Console.ReadLine().Trim().ToUpper();
        if (sId == "Q")
        {
            exit = true;
            break;
        }
        Console.Write("Are you sure (Y/N) ?  ");
        sImput = CheckStr("", range);
        if (sImput == "Q" || sImput == "N")
        {
            exit = true;
            break;
        }

        else if (sImput == "Y")
        {
            if (list.Count > 0)
            {
                list = DeleteFromList(list, Convert.ToInt32(sId));
                WriteFile(list);
                exit = true;
                break;
            }
        }
    }
}