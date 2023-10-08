using Microsoft.AspNetCore.Mvc;
using ProgramCadeteria;

namespace Tp4.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    private readonly ILogger<CadeteriaController> _logger;
    private Cadeteria Leno;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        Leno = Cadeteria.Instantiate();
    }

    [HttpGet("GetPedidos")]
    public ActionResult<List<Pedido>> GetPedidos()
    {
        if(Leno.Pedidos == null) return NotFound();
        return Ok(Leno.Pedidos);
    }

    [HttpGet("GetCadetes")]
    public ActionResult<List<Cadete>> GetCadetes()
    {
        if(Leno.Cadetes == null) return NotFound();
        return Ok(Leno.Cadetes);
    }

    [HttpPost("AgregarPedido")]
    public ActionResult<Pedido> AgregarPedido(Pedido pedido)
    {
        var nuevoPedido = Leno.TomarPedido(pedido);
        return Ok(nuevoPedido);
    }

    [HttpPut("AsignarPedido")]
    public ActionResult<Pedido> AsignarPedido(int nroPedido, int idCadete)
    {
        var nuevoPedido = Leno.AsignarPedido(idCadete, nroPedido);
        if(nuevoPedido == null) return BadRequest();
        return Ok(nuevoPedido);
    }
    
    [HttpPut("CambiarEstadoPedido")]
    public ActionResult<Pedido> CambiarEstadoPedido(int nroPedido)
    {
        var nuevoPedido = Leno.CambiarEstadoPedido(nroPedido);
        if(nuevoPedido == null) return BadRequest();
        return Ok(nuevoPedido);
    }

    [HttpPut("CambiarCadetePedido")]
    public ActionResult<Pedido> CambiarCadetePedido(int nroPedido, int idCadete)
    {
        var nuevoPedido = Leno.AsignarPedido(nroPedido, idCadete);
        if(nuevoPedido == null) return BadRequest();
        return Ok(nuevoPedido);
    }
}