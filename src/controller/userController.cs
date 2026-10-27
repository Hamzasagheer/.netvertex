using Microsoft.AspNetCore.Mvc;

namespace vertex.src.controller{
    
    [ApiController]
    [Route("api/user_controller")]
    public class usercontroller : ControllerBase {
        
        [HttpGet("user_profile")]
        public IActionResult GetUser()
        {
            return Ok(new{sucess=true ,message="Hamza Profile fetch successfully.",
                            data=new {
                            first_name="Hamza",
                            last_name="Sagheer",
                            age=26+20,
                            email="Hamza@gmail.com",}
                            
                        
        });
        }

 
        [HttpGet("salary")]
        public IActionResult salary(){
            return Ok(new{succes=true,message="salaries fetch.",
            data=new{
                       naeem_salary=20000,
                       usama_salary=18000,
                       noman_salary=20000+18000,
                       sami_salary=20000+18000+2200
            }
            }
          );
        
        
        }



[HttpPost("Login")]
public IActionResult Login([FromBody] LoginDTO loginDTO)
{
    if (loginDTO.email != "hamza@gmail.com" ||
        loginDTO.password != "pak@12345")
    {
        return BadRequest(new
        {
            success = false,
            message = "Email or password does not exist"
        });
    }

    return Ok(new
    {
        success = true,
        message = "Login successful",
        data = new
        {
            email = loginDTO.email,
            token = "demo-token"
        }
    });
}




        [HttpGet("expense")]
        public IActionResult expense(){
            return Ok(new{succes=true,message="expense fetch.",
            data=new{
                       naeem_expense=20000,
                       usama_expense=18000,
                       noman_expense=20000+18000,
                       sami_expense=20000+18000+2200
            }
            }
          );
        
        
        }


        [HttpGet("home")]
        public IActionResult home(){
            return Ok(new{succes=true,message="Home page.",
            data=new{
                naeem_home="bahwal pur",
                hamza_home="sadiqabad",
                            }});
        }


        [HttpGet("buses")]
        public IActionResult buses(){
            return Ok(new{succes=true,message="bus",
            data=new{
                warraich=123,
                sabit=456,
                noman=789
               
            }});
        }


        [HttpGet("cars")]
        public IActionResult cars(){
            return Ok(new{succes=true,message="cars",
            data=new{
                naeem="kia corolla",
                usama="honda corolla",
                noman="toyota corolla",
                sami="prado"
            }
            });
        }
        [HttpPost("vichels")]
        public IActionResult vichels([FromBody] VichelsRegisterDTO RegistorDTO){
            if(RegistorDTO==null){
                return BadRequest(new{succes=false,message="Requiresd all fields"});
            }
            return Ok(new{succes=true,message="succesful register ",data=new{
                name=RegistorDTO.name,
                model=RegistorDTO.model,
                year=RegistorDTO.year,
                plate_no=RegistorDTO.plate_no,
                type=RegistorDTO.type
            }});
        }
    }

    

}
