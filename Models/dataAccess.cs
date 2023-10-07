namespace ProgramCadeteria
{
    using System.Text.Json;

    public abstract class dataAccess
    {
        public abstract Cadeteria getInfoCadeteria(string ruteCadeteria);
        public abstract List<Cadete> getInfoCadetes(string ruteCadetes);
        public abstract void saveInfoCadeteria(string ruteCadeteria, Cadeteria cadeteria);
        public abstract void saveInfoCadetes(string ruteCadetes, List<Cadete> cadetes);

        public bool fileExist(string fileRute)
        {
            if (File.Exists(fileRute))
            {
                return true;
            }
            return false;
        }
    }

    public class dataAccessCSV : dataAccess
    {
        public override Cadeteria getInfoCadeteria(string ruteCadeteria)
        {
            if (!File.Exists(ruteCadeteria))
            {
                return new Cadeteria();
            }

            string[] info = File.ReadAllText(ruteCadeteria).Split(',');

            if(info.Length >= 2)
            {
                return new Cadeteria(info[0], info[1]);
            }else{
                return new Cadeteria();
            }
        }

        public override List<Cadete> getInfoCadetes(string ruteCadetes)
        {
            if (!File.Exists(ruteCadetes))
            {
                return new List<Cadete>();
            }

            List<Cadete> cadetes = new List<Cadete>();
            
            foreach (string line in File.ReadLines(ruteCadetes))
            {
                string[] infoCadete = line.Split(',');
                if (infoCadete.Length >= 4)
                {
                    Cadete newC = new Cadete(int.Parse(infoCadete[0]), infoCadete[1], infoCadete[2], infoCadete[3]);
                    cadetes.Add(newC);
                }
            }
            return cadetes;
        }

        public override void saveInfoCadeteria(string ruteCadeteria, Cadeteria cadeteria)
        {
            try
            {
                if (!File.Exists(ruteCadeteria))
                {
                    // Si el archivo no existe, lo creamos
                    using (File.Create(ruteCadeteria)) { }
                }
                string content = $"{cadeteria.Nombre},{cadeteria.Tel}";
                File.WriteAllText(ruteCadeteria, content);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error al guardar en el archivo CSV: {ex.Message}");
            }
        }

        public override void saveInfoCadetes(string ruteCadetes, List<Cadete> cadetes)
        {
            try
            {
                if (!File.Exists(ruteCadetes))
                {
                    // Si el archivo no existe, lo creamos
                    using (File.Create(ruteCadetes)) { }
                }
                var lines = cadetes.Select(c => $"{c.Id},{c.Nombre},{c.Dir},{c.Tel}").ToList();
                File.WriteAllLines(ruteCadetes, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar en el archivo CSV: {ex.Message}");
            }
        }
    }  

    public class dataAccessJSON : dataAccess
    {
        public override Cadeteria getInfoCadeteria(string ruteCadeteria)
        {
            
            if (File.Exists(ruteCadeteria))
            {
                string json = File.ReadAllText(ruteCadeteria);
                Cadeteria nueva = JsonSerializer.Deserialize<Cadeteria>(json);
                return nueva;
            }
            return new Cadeteria();
        }

        public override List<Cadete> getInfoCadetes(string ruteCadetes)
        {
            if (File.Exists(ruteCadetes))
            {
                string json = File.ReadAllText(ruteCadetes);
                List<Cadete> cadetes = JsonSerializer.Deserialize<List<Cadete>>(json);
                return cadetes;
            }
            return new List<Cadete>();
        }

        public override void saveInfoCadeteria(string ruteCadeteria, Cadeteria cadeteria)
        {
            try
            {
                if (!File.Exists(ruteCadeteria))
                {
                    // Si el archivo no existe, lo creamos
                    using (File.Create(ruteCadeteria)) { }
                }
                string json = JsonSerializer.Serialize(cadeteria); 
                File.WriteAllText(ruteCadeteria, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo JSON: {ex.Message}");
            }
        }
        
        public override void saveInfoCadetes(string ruteCadetes, List<Cadete> cadetes)
        {
            try
            {
                if (!File.Exists(ruteCadetes))
                {
                    // Si el archivo no existe, lo creamos
                    using (File.Create(ruteCadetes)) { }
                }
                string json = JsonSerializer.Serialize(cadetes); 
                File.WriteAllText(ruteCadetes, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo JSON: {ex.Message}");
            }
        }
    }  
}