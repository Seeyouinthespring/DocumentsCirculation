using DocumentsCirculation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DocumentsCirculation.DAO
{
    public class ClientDAO:DAO
    {
        public List<Client> GetAllClients()
        {
            Connect();
            List<Client> CList = new List<Client>();
            try
            {
                SqlCommand command = new SqlCommand("select * from Client", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Client client = new Client();

                    client.clientID = Convert.ToInt32(reader["clientID"]);
                    client.officialname = Convert.ToString(reader["officialname"]);
                    client.email = Convert.ToString(reader["email"]);

                    CList.Add(client);
                }
                reader.Close();
            }
            catch (Exception)
            {
                // Обработка исключения
            }
            finally
            {
                Disconnect();
            }
            return CList;
        }

        public bool AddClient(Client client)
        {
            bool result = true;
            Connect();

            try
            {
                SqlCommand addclient = new SqlCommand("insert into Client (officialname, email) "
                    + "VALUES (@officialname, @email)", Connection);

                addclient.Parameters.Add(new SqlParameter("@name", client.officialname));
                addclient.Parameters.Add(new SqlParameter("@creationdate", client.email));

                addclient.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally { Disconnect(); }
            return result;
        }

        public bool DropClient(int id)
        {
            bool result = true;
            Connect();

            try
            {
                string dropstring = string.Format("Delete from Client where documentID='{0}'", id);
                SqlCommand dropclient = new SqlCommand(dropstring, Connection);

                dropclient.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally { Disconnect(); }
            return result;
        }

        public bool ChangeClient(int id, Client client)
        {
            bool result = true;
            Connect();

            try
            {
                string updatestring = string.Format("update Client set officialname=@officialname, email=@email where clientID='{0}'", id);

                SqlCommand changeclient = new SqlCommand(updatestring, Connection);

                changeclient.Parameters.AddWithValue("@officialname", client.officialname);
                changeclient.Parameters.AddWithValue("@email", client.email);
                changeclient.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally { Disconnect(); }
            return result;
        }
    }
}