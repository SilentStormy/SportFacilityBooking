using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class SportFacilityRepository
    {
        private readonly string _connectionstring;
        public SportFacilityRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }


    }
}
