using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrjFlowersshoesAPI.DAO;
using PrjFlowersshoesAPI.Models;

namespace PrjFlowersshoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallaController : ControllerBase
    {
        private readonly TallasDAO talladao;

        public TallaController(TallasDAO talla)
        {
            talladao = talla;
        }

        [HttpGet("GetTallas")]
        public async Task<ActionResult<List<Tallas>>> GetTallas()
        {
            var listado = await Task.Run(() => talladao.GetTallas());

            return Ok(listado);
        }

        [HttpPost("GrabarTalla")]
        public async Task<ActionResult<string>> GrabarTalla([FromBody] Tallas obj)
        {
            string mensaje = await Task.Run(() => talladao.GrabarTalla(obj));
            return Ok(mensaje);
        }

        [HttpPut("ActualizarTalla")]
        public async Task<ActionResult<string>> ActualizarTalla([FromBody] Tallas obj)
        {
            string mensaje = await Task.Run(() => talladao.ActualizarTalla(obj));
            return Ok(mensaje);
        }

        [HttpDelete("EliminarTalla/{id}")]
        public async Task<ActionResult<string>> EliminarTalla(int id)
        {
            string mensaje = await Task.Run(() => talladao.EliminarTalla(id));
            return Ok(mensaje);
        }

        [HttpDelete("RestaurarTalla/{id}")]
        public async Task<ActionResult<string>> Resta(int id)
        {
            string mensaje = await Task.Run(() => talladao.RestaurarTalla(id));
            return Ok(mensaje);
        }



    }
}
