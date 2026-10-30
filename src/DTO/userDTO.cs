public class LoginDTO{
    public string email { get; set; } 
    public string phone { get; set; } 
}
public class UserProfileDTO(){
    public string name { get; set; } 
    public string age { get; set; } 
    public string phone { get; set; } 
    


}
public class RegisterUserDTO{
    public string email { get; set; }
    public string name { get; set; }
    public int age {get; set;}
    public string phone { get; set; }
    
}


public class UserLoginDTOs{
    public string email { get; set; } 
    public string phone { get; set; } 

}

public class LeaveApplicationDTO{
    public int user_id { get; set; } 
    public string leave_type { get; set; } 
    public string start_date { get; set; } 
    public string end_date { get; set; } 
    public string status { get; set; } 
}