namespace ProgramCadeteria
{
    using System.Text.Json;

    public class DataAccessCadeteria 
    {
        public Cadeteria Obtener()
        {
            
            if (File.Exists("CadeteriaData.json"))
            {
                string json = File.ReadAllText("CadeteriaData.json");
                Cadeteria nueva = JsonSerializer.Deserialize<Cadeteria>(json);
                return nueva;
            }
            return new Cadeteria();
        }
    }  

    public class DataAccessCadetes
    {
        public List<Cadete> Obtener()
        {
            if (File.Exists("CadetesData.json"))
            {
                string json = File.ReadAllText("CadetesData.json");
                List<Cadete> cadetes = JsonSerializer.Deserialize<List<Cadete>>(json);
                return cadetes;
            }
            return new List<Cadete>();
        }

        public void Guardar(List<Cadete> cadetes)
        {
            if(File.Exists("CadetesData.json"))
            {
                using (File.Create("CadetesData.json")) {}
            }
            string json = JsonSerializer.Serialize(cadetes);
            File.WriteAllText("CadetesData.json", json);
        }
    }

    public class DataAccessPedidos
    {
        public List<Pedido> Obtener()
        {
            if (File.Exists("PedidosData.json"))
            {
                string json = File.ReadAllText("PedidosData.json");
                List<Pedido> pedidos = JsonSerializer.Deserialize<List<Pedido>>(json);
                return pedidos;
            }
            return new List<Pedido>();
        }

        public void Guardar(List<Pedido> pedidos)
        {
            if (!File.Exists("PedidosData.json"))
            {
                // Si el archivo no existe, se lo crea
                using (File.Create("PedidosData.json")) {}
            }
            string json = JsonSerializer.Serialize(pedidos);
            File.WriteAllText("PedidosData.json", json);
        }
    }
}

    // public override void saveInfoCadetes(string ruteCadetes, List<Cadete> cadetes)
    // {
    //     try
    //     {
    //         if (!File.Exists(ruteCadetes))
    //         {
    //             // Si el archivo no existe, lo creamos
    //             using (File.Create(ruteCadetes)) { }
    //         }
    //         string json = JsonSerializer.Serialize(cadetes); 
    //         File.WriteAllText(ruteCadetes, json);
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine($"Error al guardar el archivo JSON: {ex.Message}");
    //     }
    // }


    // public class dataAccessCSV : dataAccess
    // {
    //     public override Cadeteria getInfoCadeteria(string ruteCadeteria)
    //     {
    //         if (!File.Exists(ruteCadeteria))
    //         {
    //             return new Cadeteria();
    //         }

    //         string[] info = File.ReadAllText(ruteCadeteria).Split(',');

    //         if(info.Length >= 2)
    //         {
    //             return new Cadeteria(info[0], info[1]);
    //         }else{
    //             return new Cadeteria();
    //         }
    //     }

    //     public override List<Cadete> getInfoCadetes(string ruteCadetes)
    //     {
    //         if (!File.Exists(ruteCadetes))
    //         {
    //             return new List<Cadete>();
    //         }

    //         List<Cadete> cadetes = new List<Cadete>();
            
    //         foreach (string line in File.ReadLines(ruteCadetes))
    //         {
    //             string[] infoCadete = line.Split(',');
    //             if (infoCadete.Length >= 4)
    //             {
    //                 Cadete newC = new Cadete(int.Parse(infoCadete[0]), infoCadete[1], infoCadete[2], infoCadete[3]);
    //                 cadetes.Add(newC);
    //             }
    //         }
    //         return cadetes;
    //     }

    //     public override void saveInfoCadeteria(string ruteCadeteria, Cadeteria cadeteria)
    //     {
    //         try
    //         {
    //             if (!File.Exists(ruteCadeteria))
    //             {
    //                 // Si el archivo no existe, lo creamos
    //                 using (File.Create(ruteCadeteria)) { }
    //             }
    //             string content = $"{cadeteria.Nombre},{cadeteria.Tel}";
    //             File.WriteAllText(ruteCadeteria, content);
    //         }
    //         catch(Exception ex)
    //         {
    //             Console.WriteLine($"Error al guardar en el archivo CSV: {ex.Message}");
    //         }
    //     }

    //     public override void saveInfoCadetes(string ruteCadetes, List<Cadete> cadetes)
    //     {
    //         try
    //         {
    //             if (!File.Exists(ruteCadetes))
    //             {
    //                 // Si el archivo no existe, lo creamos
    //                 using (File.Create(ruteCadetes)) { }
    //             }
    //             var lines = cadetes.Select(c => $"{c.Id},{c.Nombre},{c.Dir},{c.Tel}").ToList();
    //             File.WriteAllLines(ruteCadetes, lines);
    //         }
    //         catch (Exception ex)
    //         {
    //             Console.WriteLine($"Error al guardar en el archivo CSV: {ex.Message}");
    //         }
    //     }
    // }  