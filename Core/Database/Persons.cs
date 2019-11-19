using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class Persons : IPerson
    {
      
        private IConfiguration _config;

        public Persons(IConfiguration config)
        {
            _config = config;
          
        }
        public int GetEmp(string name)
        {
           
            
            SqlParameter pa = new SqlParameter();        
            string conn = _config.GetSection("AppSettings:ConnectionString").Value;
            //  SqlHelper.ExecuteProcedureReturnString(this._config.GetSection("AppSettings").Value,"rwe",pa);
            return 1;

        }

    }
}
