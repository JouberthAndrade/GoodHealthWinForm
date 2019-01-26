namespace GoodHealth.Connection
{
    public class ConexaoModel
    {
        protected string NomeServidor { private get; set; }
        protected string NomeUsuario { private get; set; }
        protected string SenhaUsuario { private get; set; }

        public string StringDeConexao
        {
            get
            {
                return string.Format("Server = tcp:jouberthandrade.database.windows.net,1433; Initial Catalog = BDGoodHealth; Persist Security Info = False; User ID = {0}; Password ={1}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;", NomeUsuario, SenhaUsuario);
            }
        }

        public string StringConexaoLocal => "Server = DESKTOP-ELUC6QF\\SQLEXPRESS;Initial Catalog=GoodHealth;Integrated Security=True;";
    }
}