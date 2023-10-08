namespace ProgramCadeteria
{
    public class Cadeteria
    {
        private DataAccessCadetes dataAccessCadetes;
        private DataAccessPedidos dataAccessPedidos;
        private static Cadeteria Instance;

        private string nombre;
        private string tel;
        private List<Cadete> cadetes;
        private List<Pedido> pedidos;

        
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tel { get => tel; set => tel = value; }
        public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

        public Cadeteria()
        {
            Pedidos = new List<Pedido>();
            Cadetes = new List<Cadete>();
        }

        public Cadeteria(string nombre, string tel)
        {
            Nombre = nombre;
            Tel = tel;
            Pedidos = new List<Pedido>();
            Cadetes = new List<Cadete>();
        }

        public static Cadeteria Instantiate()
        {
            if (Instance == null)
            {
                DataAccessCadeteria dataCadeteria = new DataAccessCadeteria();
                Instance = dataCadeteria.Obtener();
                Instance.dataAccessCadetes = new DataAccessCadetes();
                Instance.dataAccessPedidos = new DataAccessPedidos();
                Instance.Cadetes = Instance.dataAccessCadetes.Obtener();
                Instance.Pedidos = Instance.dataAccessPedidos.Obtener();
            }
            return Instance;
        }

        public Pedido TomarPedido(Pedido pedido){
            Instance.Pedidos.Add(pedido);
            pedido.Nro = Instance.Pedidos.Count();
            dataAccessPedidos.Guardar(Instance.Pedidos);
            return pedido;
        }

        public Pedido AsignarPedido(int idCadete, int nroPedido)
        {
            Cadete c = Cadetes.FirstOrDefault(c => c.Id == idCadete);
            Pedido p = Pedidos.FirstOrDefault(p => p.Nro == nroPedido);
            if (c != null && p != null)
            {
                p.IdCadete = c.Id;
                dataAccessPedidos.Guardar(Instance.Pedidos);
                return p;
            }
            return null;
        }

        public Pedido CambiarEstadoPedido(int nro)
        {
            Pedido p = Pedidos.FirstOrDefault(p => p.Nro == nro);
            if (p != null)
            {
                p.Entregado();
                dataAccessPedidos.Guardar(Instance.Pedidos);
                return p;
            }
            return null;
        }

        public Pedido GetPedido(int nroPedido)
        {
            Pedido aux = Pedidos.FirstOrDefault(p => p.Nro == nroPedido);
            return (aux != null) ? aux : null;
        }

        public Cadete GetCadete(int idCadete)
        {
            Cadete aux = Cadetes.FirstOrDefault(p => p.Id == idCadete);
            return (aux != null) ? aux : null;
        }

        public Cadete CrearCadete(Cadete cadete)
        {
            Instance.Cadetes.Add(cadete);
            cadete.Id = Instance.Cadetes.Count();
            dataAccessCadetes.Guardar(Instance.Cadetes);
            return cadete;
        }

        public int JornalACobrar(int idCadete)
        {
            return(500 * (cadetes.FirstOrDefault(c => c.Id == idCadete).CantPedEntregados));
        }
    }
}