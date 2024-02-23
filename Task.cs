/* Project Week 8 Project Todo List
 * Author        : Pedro Martinez
 * File Name     : Task.cs 
 * Start Date    : 19/02/2024
 * Review Date   : 19/02/2024
 */

using
    static W8TodoList.Utils;

class Task : Project
{
    // Constructors 
    
    public Task( int id, string name, bool status, DateTime taskDate, string projName)
    {    
        Id = id;
        Name = name;
        Status = status;
        TaskDate = taskDate;
        ProjName = projName;
        
        OnCreate();
    }

    //
    //Properties
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public DateTime TaskDate { get; set; }
    
    
    // Methods

    public void OnCreate()
    {
        //GetStatus();
    }

    public void GetStatus( string s )
    {
        Status = GetBool(s);
    }

    
}


