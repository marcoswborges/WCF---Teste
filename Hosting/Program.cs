using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Passagens;
using System.Configuration;

namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            string connstring = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            using (var conn = new Oracle.DataAccess.Client.OracleConnection(connstring))
            {
                conn.Open();

                // INSERT
                using (var comm = new Oracle.DataAccess.Client.OracleCommand())
                {
                    comm.Connection = conn;
                    comm.CommandText = "INSERT INTO dbahmv.tmo_doenca (SEQ_TMO_DOENCA, CD_CID, NOME_DOENCA, URGENCIA, CURABILIDADE, CONSTANTE, OBS, SN_ATIVO) VALUES (1, 'F606', 'Gripe', 10, 20, 10, 'Teste', 'S' )";
                    comm.ExecuteNonQuery();
                }
            }
        }

        public static void ExibeInformacoesServico(ServiceHost sh)
        {
            Console.WriteLine("{0} online", sh.Description.ServiceType);
            foreach(ServiceEndpoint se in sh.Description.Endpoints)
            {
                Console.WriteLine(se.Address);
            }
        }

        public void CreateAndCloseHosting()
        {
            ServiceHost host = new ServiceHost(typeof(ClienteService));
            Uri endereco = new Uri("http://localhost:8080/clientes");
            host.AddServiceEndpoint(typeof(IClienteService), new BasicHttpBinding(), endereco);

            try
            {
                host.Open();
                ExibeInformacoesServico(host);
                Console.ReadLine();
                host.Close();
            }
            catch (Exception ex)
            {
                host.Abort();
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
