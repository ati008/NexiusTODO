using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using TODOAPI.Adatbazis.Model;
using TODOAPI.Model;
using TODOAPI.Service;

namespace TODOAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TODOController : ControllerBase
  {

    private readonly ILogger<TODOController> _logger;
    private readonly ITODOService _todoService;

    public TODOController(ILogger<TODOController> logger, ITODOService TODOService)
    {
      _logger = logger;
      _todoService = TODOService;
    }

    [HttpGet(nameof(GetAll))]
    public async Task<IActionResult> GetAll([FromQuery] Szures szures)
    {
      var lapozottAdat = await _todoService.GetAll(szures);
      return Ok(new LapozottValasz<IEnumerable<TODO>>(lapozottAdat, szures.OldalSzam, szures.OldalMeret));
    }

    [HttpGet(nameof(Get))]
    public async Task<IActionResult> Get(Guid id)
    {
      try
      {
        TODO todo = await _todoService.Get(id);
        return Ok(new Valasz<TODO>(todo));
      }
      catch (Exception ex)
      {
        return BadRequest(new Valasz<TODO>(null, "Sikertelen lek�rdez�s!", new string[] { ex.Message }));
      }
    }


    [HttpDelete(nameof(Delete))]
    public async Task<IActionResult> Delete(Guid id)
    {
      try
      {
        await _todoService.Delete(id);
        return Ok(new Valasz<TODO>(null, "Sikeres t�rl�s!"));
      }
      catch (Exception ex)
      {
        return BadRequest(new Valasz<TODO>(null, "Sikertelen t�rl�s!", new string[] { ex.Message }));
      }
    }


    [HttpPost(nameof(Add))]
    public async Task<IActionResult> Add([FromBody] TODO todo)
    {
      try
      {
        await _todoService.Add(todo);
        return Ok(new Valasz<TODO>(null, "Sikeres l�trehoz�s!"));
      }
      catch (Exception ex)
      {
        return BadRequest(new Valasz<TODO>(null, "Sikertelen l�trehoz�s!", new string[] { ex.Message }));
      }
    }

    [HttpPut(nameof(UpdateLeiras))]
    public async Task<IActionResult> UpdateLeiras(Guid id, [FromBody] string leiras)
    {
      try
      {
        await _todoService.UpdateLeiras(id, leiras);
        return Ok(new Valasz<TODO>(null, "Sikeres le�r�s friss�t�s!"));
      }
      catch (Exception ex)
      {
        return BadRequest(new Valasz<TODO>(null, "Sikertelen st�tusz friss�t�s!", new string[] { ex.Message }));
      }
    }

    [HttpPut(nameof(UpdateStatusz))]
    public async Task<IActionResult> UpdateStatusz(Guid id, [FromBody] bool statusz)
    {
      try
      {
        await _todoService.UpdateStatusz(id, statusz);
        return Ok(new Valasz<TODO>(null, "Sikeres st�tusz friss�t�s!"));
      }
      catch (Exception ex)
      {
        return BadRequest(new Valasz<TODO>(null, "Sikertelen st�tusz friss�t�s!", new string[] { ex.Message }));
      }
    }
  }
}