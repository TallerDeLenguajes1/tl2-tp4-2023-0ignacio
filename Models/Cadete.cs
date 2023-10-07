namespace ProgramCadeteria
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string dir;
        private string tel;
        //private List<Pedido>? pedidos;
        private int cantPedEntregados;
        
        private static int autoNro = 0;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Dir { get => dir; set => dir = value; }
        public string Tel { get => tel; set => tel = value; }
        public int CantPedEntregados { get => cantPedEntregados; set => cantPedEntregados = value; }


        public Cadete(){}
        // public Cadete( string nombre, string dir, string tel)
        // {
        //     Id = autoNro++;
        //     Nombre = nombre;
        //     Dir = dir;
        //     Tel = tel;
        //     CantPedEntregados = 0;
        // }

        public Cadete(int id, string nombre, string dir, string tel)
        {
            Id = id;
            Nombre = nombre;
            Dir = dir;
            Tel = tel;
            CantPedEntregados = 0;
        }
        public int JornalACobrar()
        {
            return(500 * this.CantPedEntregados);
        }
    }
}
