namespace ProgramCadeteria
{
    public class Cliente
    {
        private string nombre;
        private string dir;
        private string tel;
        private string refDir;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Dir { get => dir; set => dir = value; }
        public string Tel { get => tel; set => tel = value; }
        public string RefDir { get => refDir; set => refDir = value; }


        public Cliente(){}
        public Cliente(string nombre, string dir, string tel, string refDir)
        {
            Nombre = nombre;
            Dir = dir;
            Tel = tel;
            RefDir = refDir;
        }
    }
}