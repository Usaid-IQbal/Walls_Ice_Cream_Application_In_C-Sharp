using DataLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ice_creamsBusiness
    {
        public static void Addice_creamsBusiness(ice_creamsClass std)
        {
            ice_creamsDB.Addice_creamsDB(std);
        }

        public static void Updateice_creamBusiness(ice_creamsClass std)
        {
            ice_creamsDB.Updateice_creamsDB(std);
        }
        public static DataTable SelectAllice_creamsBusiness()
        {
            return ice_creamsDB.SelectAllice_creams();
        }

        public static void Deleteice_creamsBusiness(ice_creamsClass std)
        {
            ice_creamsDB.Deleteice_creamsDB(std);
        }
    }
}
