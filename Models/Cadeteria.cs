

namespace ProgramCadeteria
{
    public class Cadeteria
    {
        private string nombre;
        private string tel;
        private List<Cadete> cadetes;
        private List<Pedido> pedidos;

        static Cadeteria cad;
        
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
            if (cad == null)
            {
                dataAccess data = new dataAccessJSON();
                
                cad = data.getInfoCadeteria("CadeteriaData.json");
                cad.Cadetes = data.getInfoCadetes("CadetesData.json");
                

                cad.Pedidos.Add(new Pedido("Pedido 1", "Juan", "Direccion 1", "3811111111", "Ref dir 1"));
                cad.Pedidos.Add(new Pedido("Pedido 2", "Ignacio", "Direccion 2", "3811111112", "Ref dir 2"));
                cad.Pedidos.Add(new Pedido("Pedido 3", "Catalina", "Direccion 3", "3811111113", "Ref dir 3"));
            }
            return cad;
        }
        public void CadetesListCharge(List<Cadete> cadetes){
            this.Cadetes = cadetes;
        }

        public Pedido TomarPedido(Pedido pedido){
            this.Pedidos.Add(pedido);
            pedido.Nro = this.Pedidos.Count();
            return pedido;
        }

        public Pedido AsignarPedido(int idCadete, int nroPedido)
        {
            Cadete c = Cadetes.FirstOrDefault(c => c.Id == idCadete);
            Pedido p = Pedidos.FirstOrDefault(p => p.Nro == nroPedido);
            if (c != null && p != null)
            {
                p.IdCadete = c.Id;
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
                return p;
            }
            return null;
        }

        public Pedido GetPedido(int nroPedido)
        {
            Pedido aux = Pedidos.FirstOrDefault(p => p.Nro == nroPedido);
            if (aux != null)
            {
                return aux;
            }
            return null;
        }
        public int JornalACobrar(int idCadete)
        {
            // return(500 * pedidos.Count(p => p.Estado == EstadoPedido.Entregado && p.IdCadete == idCadete));
            return(500 * (cadetes.FirstOrDefault(c => c.Id == idCadete).CantPedEntregados));
        }
    }
}