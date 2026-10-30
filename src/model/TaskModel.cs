using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vertex.src.Models;

public class TaskModel
{
    [Key]
    public int Id { get; set; }

    public int user_id { get; set; } // Yeh batayega ke task kis employee ko mila hai

    [ForeignKey("user_id")]
    public UserModel UserModel { get; set; } = null!;

    public string title { get; set; } = string.Empty;       // Task ka naam (e.g., Fix Bug)
    public string description { get; set; } = string.Empty; // Task ki tafseel
    public string due_date { get; set; } = string.Empty;    // Kab tak mukammal karna hai
    public string status { get; set; } = "Pending";         // Pending, In Progress, Completed
}

public class TaskCreateDTO
{
    public int user_id { get; set; }
    public string title { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public string due_date { get; set; } = string.Empty;
}

public class TaskUpdateDTO
{
    public string title { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public string due_date { get; set; } = string.Empty;
    public string status { get; set; } = "Pending";
}