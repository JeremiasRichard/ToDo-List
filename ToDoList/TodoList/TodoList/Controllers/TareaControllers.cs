using Microsoft.AspNetCore.Mvc;
using TodoList.Interface;
namespace TodoList.Controllers;
using TareasLibrary.Models;


[ApiController]
[Route("api/[controller]")]
public class TareaControllers : Controller
{
    private readonly ITarea _tarea;

    public TareaControllers(ITarea tarea)
    {
        _tarea = tarea;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Tarea>))]
    public IActionResult GetTareas()
    {   
        var tareas = _tarea.GetTareas();
        return Ok(tareas);
    }

    [HttpGet("{tareaId}")]
    [ProducesResponseType(200, Type = typeof(Tarea))]
    [ProducesResponseType(400)]
    public IActionResult GetTareaById(int tareaId)
    {
        if(!_tarea.ExistTarea(tareaId))
        {
            return NotFound();
        }

        var tarea = _tarea.GetTarea(tareaId);

        return Ok(tarea);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateTarea(Tarea tarea)
    {
        if (!_tarea.CreateTarea(tarea))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok(tarea);
    }

    [HttpPut("{tareaId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult UpdateTarea(int tareaId, Tarea tareaUpdate)
    {
        if (tareaUpdate == null)
        {
            return BadRequest(ModelState);
        }
        if (tareaId != tareaUpdate.Id)
        {
            return BadRequest(ModelState);
        }
        if (!_tarea.ExistTarea(tareaId))
        {
            return NotFound();
        }
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        if(!_tarea.UpdateTarea(tareaUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating tarea");
            return StatusCode(500, ModelState);
        }
        return NoContent();
    }

    [HttpDelete("{tareaId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult DeleteTarea(int tareaId)
    {
        if (!_tarea.ExistTarea(tareaId))
        {
            return NotFound();
        }
     
        var tareaToDelete = _tarea.GetTarea(tareaId);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!_tarea.DeleteTarea(tareaToDelete))
        {
            ModelState.AddModelError("", "Something went wrong when deleteting tarea");
        }

        return NoContent();
    }
}
