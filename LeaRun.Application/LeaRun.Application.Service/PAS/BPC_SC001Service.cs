using LeaRun.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.PAS
{
    public class BPC_SC001Service : RepositoryFactory
    {
        public DataTable GetPageList()
        {
            try
            {
                //var strSql = new StringBuilder();
                //strSql.Append(@"select * from BPMS.BPC_SC001");             
                //return this.BaseRepository("Server=192.168.1.149;Initial Catalog=HQPAS;User ID=sa;Password=sql").FindTable(strSql.ToString());
                return null;
            }
            catch
            {
                throw;
            }
        }
    }
}
