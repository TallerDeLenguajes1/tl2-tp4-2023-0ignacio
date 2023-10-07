namespace ProgramCadeteria
{
    public class Informe
    {
        public static void mostrarInforme(List<Cadete> cadetes)
        {
            if (cadetes.Count > 0)
            {
                var informe =   from cadete in cadetes
                                select new
                                {
                                Id = cadete.Id,
                                Nombre = cadete.Nombre,
                                CantPedEntregados = cadete.CantPedEntregados,
                                MontoGanado = cadete.JornalACobrar()
                                };

                Console.WriteLine("=== Informe del dia ===");
                foreach (var cadete in informe)
                {
                    Console.WriteLine($"Id: {cadete.Id}\tNombre: {cadete.Nombre}\tPedidos Entregados: {cadete.CantPedEntregados}\tGanancias: {cadete.MontoGanado}");
                }
                int totalEnvios = cadetes.Sum(c => c.CantPedEntregados);
                Console.WriteLine($"Total de pedidos entregados en el dia: {totalEnvios}");
                Console.WriteLine($"Promedio de pedidos enviados por cadete: {totalEnvios / cadetes.Count}");
            }else{
                Console.WriteLine("Hoy los cadetes no trabajaron");
            }
        }
    }
}
