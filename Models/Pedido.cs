public enum EstadoPedido{
    Entregado,
    Pendiente
}

namespace ProgramCadeteria
{
    public class Pedido
    {
        private int nro;
        private string obs;
        private Cliente cliente;
        private EstadoPedido estado;
        private int idCadete;

        private static int autoNro = 0;

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public EstadoPedido Estado { get => estado; set => estado = value; }
        public int IdCadete { get => idCadete; set => idCadete = value; }


        public Pedido(){}
        public Pedido(string obs, string nombreCliente, string dirCliente, string telCliente, string refDirCliente){
            this.Nro = ++autoNro;
            this.Obs = obs;
            this.Estado = EstadoPedido.Pendiente;
            this.cliente = new Cliente(nombreCliente, dirCliente, telCliente, refDirCliente);
            this.IdCadete = -1;
        }
        // public void getInfoProducto()
        // {
        //     // Console.WriteLine("===Datos del Pedido===");

        //     // Console.WriteLine($"Nro: {this.Nro}");
        //     // Console.WriteLine($"Obs: {this.Obs}");
        //     // Console.WriteLine($"Estado: {this.Estado}");
        //     // if (this.IdCadete == -1)
        //     // {
        //     //     Console.WriteLine($"Sin asignar");
        //     // }else{            
        //     //     Console.WriteLine($"Id de cadete asignado: {this.IdCadete}");
        //     // }
        //     // VerDatosCliente();
        // }


        // public void VerDatosCliente()
        // {
        //     // Console.WriteLine("===Datos del cliente===");
        //     // Console.WriteLine($"Nombre: {cliente.Nombre}");
        //     // Console.WriteLine($"Direccion: {cliente.Dir}");
        //     // Console.WriteLine($"Tel: {cliente.Tel}");
        //     // Console.WriteLine($"Ref. Direccion: {cliente.RefDir}");
        // }

        public void Entregado()
        {
            Estado = EstadoPedido.Entregado;
        }
    }
}