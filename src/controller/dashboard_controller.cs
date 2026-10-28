using Microsoft.AspNetCore.Mvc;

namespace vertex.src.controller{

 [ApiController]
    [Route("api/dashboard")]
public class DashboardController:ControllerBase{
    

[HttpGet("stat")]
public IActionResult stat(){
     var datas=new{
        date="27-10-2026",
       trips=new{
        import=12,
        export=5,
        local=5,
        total=12+5+5,
        in_progress=8,
        completed=9,
        not_started=5,
        

       },
       vehicles=new{
        total=17,
        owned=15,
        out_sourced=2,
        avaliable=8,
        on_route=7,
        in_maintence=2,
       }
    
        
    };
    return Ok(new{sucess=true,data=datas });
}

    [HttpGet("in_progress")]
    public IActionResult inprogress([FromQuery] int id){
    var in_progress=new{
        trip_id="TRP_001",
        truck_number="LJR_LE_45",
        driver_name="Arslan Ahm",
       route= new{
            From="karachi",to ="lahore",
        },
        status="in_progress",
        started_at="26-03-07",to="8:30:00Z",
        trip_type="import",

    };

    

    if(id==9){
    
        return Ok(new{succes=true,data=in_progress});
    }
    
        return BadRequest(new{success=false, message="Id not found"});



    
}


[HttpPut("update-profile")]
public IActionResult updateprofile([FromQuery] int id,[FromBody] UserProfileDTO userpDTO)
{
    if(id!=1)
    {
        return BadRequest(new{sucess=false,message="id not found"});
    }
    var newData=new UserProfileDTO{
        name=userpDTO.name,
        age=userpDTO.age,
        phone=userpDTO.phone,
        
    };
    return Ok(new{sucess=true,message="profile update successfully",data=newData});
}

[HttpPost("login")]

public IActionResult login([FromBody]LoginnDTO loginnDTO){
    if(loginnDTO.email!="hamza@gmail.com" || loginnDTO.password!="hamza1234"){
        return BadRequest(new{sucess=false,message="email and password are required"});
    }
    var newlogin=new LoginnDTO{
        email=loginnDTO.email,
        password=loginnDTO.password,
    };
    return Ok(new{sucess=true,message="profile update successfully",data=newlogin});
}



[HttpPost("register")]
public IActionResult register([FromBody]UserRegisterDTO userRegisterDTO){
    if(userRegisterDTO==null){
        return BadRequest(new{sucess=false,message="Required all fields"});
    }

    return Ok(new{sucess=true,message="profile update successfully",data=new{
            name=userRegisterDTO.name,
            age=userRegisterDTO.age,
            phone=userRegisterDTO.phone,
            email=userRegisterDTO.email,
            password=userRegisterDTO.password,
            
    }});
    

  
      
    }
      [HttpGet("userprofile")]

    public IActionResult userprofile([FromQuery]int id){
          var usrprofile=new{
            name="hamza",
            age="26",
            phone="123456789",
          };
        if(id==1){
             return Ok(new{sucess=true,message="user profile",data=usrprofile});
        }
      return BadRequest(new{sucess=false,message="id not found"});
        }
    



    [HttpPut("profileupdate")]
    public IActionResult profileupdate([FromQuery] int id,[FromBody] updateProfileDTO updateprofile){
      if(id!=1)
      {
        return BadRequest(new{sucess=false,message="id not found"});
      }
      var newprofile=new updateProfileDTO{
        name=updateprofile.name,
        age=updateprofile.age,
        phone=updateprofile.phone,
        email=updateprofile.email,
        password=updateprofile.password,
        confirm_password=updateprofile.confirm_password,
      };
      return Ok(new{sucess=true,message="profile update successfully",data=newprofile});
      
    }
}

    }





    


    
