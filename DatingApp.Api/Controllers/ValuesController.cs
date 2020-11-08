using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DatingApp.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController:ControllerBase
    {

        private readonly DataContext _context;
        public ValuesController(DataContext dataContext){
            this._context=dataContext;
        }
        [AllowAnonymous]
        public async Task<IActionResult> GetValues(){
            var values=await _context.Values.ToListAsync();
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetValue(int id){
            var value=await _context.Values.FirstOrDefaultAsync(x=>x.Id==id);
            return Ok(value);
        }

        [HttpPost]
        public void Post([FromBody] string value){
            _context.SaveChanges();
        }

        [HttpPost]
        public void Put(int id,[FromBody] string value){

        }
    }
}