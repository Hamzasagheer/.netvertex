using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vertex.src.Models;
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        
    }


    public class AttendanceModel{
        [Key]
        public int Id { get; set; }
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public UserModel UserModel { get; set; } = null!;
        
        public string check_in_time { get; set; } = string.Empty;
        public string check_out_time { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        
    }


