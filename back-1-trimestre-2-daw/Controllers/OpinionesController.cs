using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("MinimalCinema/[controller]")]
public class OpinionesController : ControllerBase
{

    private static List<Opiniones> opiniones = new List<Opiniones>();


    public OpinionesController()
    {
        if (opiniones.Count == 0)
        {
            InicializarOpiniones();
        }
    }


    [HttpGet]
    public ActionResult<IEnumerable<Opiniones>> GetAllOpiniones()
    {
        return Ok(opiniones);
    }


    [HttpGet("{id}")]
    public ActionResult<Opiniones> GetOpinionesById(int id)
    {
        var opinion = opiniones.FirstOrDefault(a => a.Id == id);
        if (opinion == null)
        {
            return NotFound($"Opinión con ID {id} no encontrada.");
        }

        return Ok(opinion);
    }


    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var opinion = opiniones.FirstOrDefault(b => b.Id == id);
        if (opinion == null)
        {
            return NotFound($"Opinión con ID {id} no encontrada.");
        }

        opiniones.Remove(opinion);
        return NoContent();
    }

        [HttpPut("{id}")]

    public ActionResult ActualizarComentario(int id, [FromBody] string comentario )
    {

        var opinion = opiniones.FirstOrDefault(b => b.Id == id);
        if (opinion == null)
        {
            return NotFound($"Opinión con ID {id} no encontrada.");
        }

        opinion.Comentario = comentario;
        return NoContent();

    }


    [HttpPost]
    public ActionResult CrearOpinion([FromBody] Opiniones nuevaOpinion)
    {
        opiniones.Add(nuevaOpinion);
        return Ok(nuevaOpinion);
    }


    private static void InicializarOpiniones()
    {

        opiniones.Add(new Opiniones(1, "Nicolas", "Comentario de Nicolás", 1));
        opiniones.Add(new Opiniones(2, "Nicolas2", "Comentario de Nicolás2", 2));
        opiniones.Add(new Opiniones(3, "Nicolas3", "Comentario de Nicolás3", 3));
        opiniones.Add(new Opiniones(4, "Nicolas4", "Comentario de Nicolás4", 4));
        opiniones.Add(new Opiniones(5, "Nicolas5", "Comentario de Nicolás5", 5));
    }

    public static List<Opiniones> GetOpiniones()
    {
        return opiniones;
    }
}
