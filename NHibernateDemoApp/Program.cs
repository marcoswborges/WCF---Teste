using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new Configuration();

            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            var sefact = cfg.BuildSessionFactory();

            using(var session = sefact.OpenSession())
            {
                using(var tx = session.BeginTransaction())
                {
                    //perform database logic
                    tx.Commit();
                }
                Console.ReadLine();
            }
        }
    }
}
        var cfg = OracleClientConfiguration.Oracle9
            .ConnectionString(c =>
                c.Is("DATA SOURCE=<<NAME>>;PERSIST SECURITY INFO=True;USER ID=<<USER_NAME>>;Password=<<PASSWORD>>"));

        return Fluently.Configure()
                .Database(cfg)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CLASS_NAME>().ExportTo(@".\"))
                .ExposeConfiguration(BuildSchema)
        .BuildSessionFactory();
