using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ReservationRepository
    {
        private readonly string _connectionstring;

        public ReservationRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");

        }

        public void MakeReservation(int userid, int sportfacilityid, int timeslotid)
        {
            using MySqlConnection conn=new MySqlConnection(_connectionstring);
            conn.Open();
            using MySqlCommand cmd = conn.CreateCommand();  
            cmd.CommandText ="INSERT INTO Reservation(UserId,SportfacilityId,TimeSlotId) Values(@UserId,@SportFacilityId,@TimeSlotId)";
            cmd.Parameters.AddWithValue("@UserId", userid);
            cmd.Parameters.AddWithValue("@SportfacilityId", sportfacilityid);
            cmd.Parameters.AddWithValue("@TimeSlotId", timeslotid);
            cmd.ExecuteNonQuery();
        }
    }
}
