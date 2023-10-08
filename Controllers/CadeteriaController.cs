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
        return (Leno.Pedidos == null) ? NotFound() : Ok(Leno.Pedidos);
    }

    [HttpGet("GetPedidoNro")]
    public ActionResult<Pedido> GetPedidoNro(int nroPedido)
    {
        var pedidoABuscar = Leno.GetPedido(nroPedido);
        return (pedidoABuscar == null) ? NotFound(): Ok(pedidoABuscar);
    }

    [HttpGet("GetCadetes")]
    public ActionResult<List<Cadete>> GetCadetes()
    {
        return (Leno.Cadetes == null) ? NotFound() : Ok(Leno.Cadetes);
    }

    [HttpGet("GetCadeteId")]
    public ActionResult<Cadete> GetCadeteId(int idCadete)
    {
        var cadeteABuscar = Leno.GetCadete(idCadete);
        return (cadeteABuscar == null) ? NotFound() : Ok(cadeteABuscar);
    }

    [HttpPost("AgregarPedido")]
    public ActionResult<Pedido> AgregarPedido(Pedido pedido)
    {
        var nuevoPedido = Leno.TomarPedido(pedido);
        return Ok(nuevoPedido);
    }

    [HttpPost("AgregarCadete")]
    public ActionResult<Pedido> AgregarCadete(Cadete cadete)
    {
        var nuevoCadete = Leno.CrearCadete(cadete);
        return Ok(nuevoCadete);
    }

    [HttpPut("AsignarPedido")]
    public ActionResult<Pedido> AsignarPedido(int nroPedido, int idCadete)
    {
        var nuevoPedido = Leno.AsignarPedido(idCadete, nroPedido);
        return (nuevoPedido == null) ? BadRequest() : Ok(nuevoPedido);
    }
    
    [HttpPut("CambiarEstadoPedido")]
    public ActionResult<Pedido> CambiarEstadoPedido(int nroPedido)
    {
        var nuevoPedido = Leno.CambiarEstadoPedido(nroPedido);
        return (nuevoPedido == null) ? BadRequest() : Ok(nuevoPedido);
    }

    [HttpPut("CambiarCadetePedido")]
    public ActionResult<Pedido> CambiarCadetePedido(int nroPedido, int idCadete)
    {
        var nuevoPedido = Leno.AsignarPedido(nroPedido, idCadete);
        return (nuevoPedido == null) ? BadRequest() : Ok(nuevoPedido);
    }
}