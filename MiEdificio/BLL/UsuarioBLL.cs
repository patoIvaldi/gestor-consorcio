namespace BLL
{
    public class UsuarioBLL
    {

        public UsuarioBLL()
        {
        
        }

        private static UsuarioBLL _instance;

        //singleton para la instancia del usuario
        public static UsuarioBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UsuarioBLL();
                }
                return _instance;
            }
        }



    }
}