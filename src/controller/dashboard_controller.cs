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
    }




}
    


    
