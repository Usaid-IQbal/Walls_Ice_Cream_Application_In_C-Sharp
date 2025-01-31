using ModelLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLayer
{
    public class ice_creamsDB
    {
     static   MySqlConnection conn = new MySqlConnection("server=localhost; port=3306; username=root;password='';database=walls_ice_cream");

        public static void Addice_creamsDB(ice_creamsClass std)
        {
            try

            {
                using (conn)
                {



                    conn.Open();
                    //string query = "INSERT INTO ice_creams(id,company,type,size,price,flavour,color,expiredate) VALUES(@id,@company,@type,@size,@price,@flavour,@color,@expiredate)";

                    MySqlCommand cmd = new MySqlCommand("Addice_creams", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", std.id);
                    cmd.Parameters.AddWithValue("@company", std.company);
                    cmd.Parameters.AddWithValue("@type", std.type);
                    cmd.Parameters.AddWithValue("@size", std.size);
                    cmd.Parameters.AddWithValue("@price", std.price);
                    cmd.Parameters.AddWithValue("@flavour", std.flavour);
                    cmd.Parameters.AddWithValue("@color", std.color);
                    cmd.Parameters.AddWithValue("@expiredate", std.expiredate);
                    cmd.Parameters.AddWithValue("@picture", std.picture);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    //conn.Close();
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show("Error, ", ex.Message);



            }
        }

        public static void Deleteice_creamsDB(ice_creamsClass std)
        {
            try

            {
                using (conn)
                {
                    conn.Open();
                    //string query = "INSERT INTO ice_creams(id,company,type,size,price,flavour,color,expiredate) VALUES(@id,@company,@type,@size,@price,@flavour,@color,@expiredate)";

                    MySqlCommand cmd = new MySqlCommand("Deleteice_creams", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id1", std.id);
                    cmd.Parameters.AddWithValue("@company", std.company);
                    cmd.Parameters.AddWithValue("@type", std.type);
                    cmd.Parameters.AddWithValue("@size", std.size);
                    cmd.Parameters.AddWithValue("@price", std.price);
                    cmd.Parameters.AddWithValue("@flavour", std.flavour);
                    cmd.Parameters.AddWithValue("@color", std.color);
                    cmd.Parameters.AddWithValue("@expiredate", std.expiredate);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ice Cream Deleted Successfully ");
                    conn.Close();
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show("Error, ", ex.Message);



            }
        }

        public static DataTable SelectAllice_creams()
        {
            using (conn)
            {
                conn.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("SelectAll", conn);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            
        }
        public static void Updateice_creamsDB(ice_creamsClass std)
        {
            try

            {
                using (conn)
                {
                    conn.Open();
                    //string query = "INSERT INTO ice_creams(id,company,type,size,price,flavour,color,expiredate) VALUES(@id,@company,@type,@size,@price,@flavour,@color,@expiredate)";

                    MySqlCommand cmd = new MySqlCommand("Updateice_creams", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id1", std.id);
                    cmd.Parameters.AddWithValue("@company", std.company);
                    cmd.Parameters.AddWithValue("@type", std.type);
                    cmd.Parameters.AddWithValue("@size", std.size);
                    cmd.Parameters.AddWithValue("@price", std.price);
                    cmd.Parameters.AddWithValue("@flavour", std.flavour);
                    cmd.Parameters.AddWithValue("@color", std.color);
                    cmd.Parameters.AddWithValue("@expiredate", std.expiredate);
                    cmd.Parameters.AddWithValue("@picture", std.picture);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show("Error, ", ex.Message);



            }
        }

    }
}

