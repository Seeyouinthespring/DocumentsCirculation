using DocumentsCirculation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DocumentsCirculation.DAO
{
    public class DocInsideDAO: DAO
    {
        public List<DocumentInside> GetAllInsides()
        {
            Connect();
            List<DocumentInside> DList = new List<DocumentInside>();
            try
            {
                SqlCommand command = new SqlCommand("select * from Document, DocumentInside where Document.documentID=DocumentInside.documentID", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DocumentInside inside = new DocumentInside();

                    inside.documentID = Convert.ToInt32(reader["documentID"]);
                    inside.name = Convert.ToString(reader["name"]);
                    inside.creationdate = Convert.ToDateTime(reader["creationdate"]);
                    inside.authorID = Convert.ToInt32(reader["authorID"]);
                    inside.status = Convert.ToString(reader["status"]);
                    inside.comment = Convert.ToString(reader["comment"]);
                    inside.shelflife = Convert.ToDateTime(reader["shelflife"]);
                    inside.signerID = Convert.ToInt32(reader["signerID"]);
                    inside.type = Convert.ToString(reader["type"]);

                    inside.moneydifference = Convert.ToDecimal(reader["moneydifference"]);
                    inside.targetID = Convert.ToInt32(reader["targetID"]);
                    inside.documentID = Convert.ToInt32(reader["documentID"]);

                    DList.Add(inside);
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
            return DList;
        }

        public bool AddInside(DocumentInside inside)
        {
            bool result = true;
            Connect();

            try
            {
                SqlCommand addparent = new SqlCommand("insert into Document (name, creationdate, authorID, status, comment, shelflife, signerID, type) "
                    + "VALUES (@name, @creationdate, @authorID, @status, @comment, @shelflife, @signerID, @type)", Connection);
                SqlCommand addheir = new SqlCommand("insert into DocumentSale (moneydifference, targetID, documentID)"
                    + "values (@moneydifference, @targetID, @documentID)");

                addparent.Parameters.Add(new SqlParameter("@name", inside.name));
                addparent.Parameters.Add(new SqlParameter("@creationdate", inside.creationdate));
                addparent.Parameters.Add(new SqlParameter("@authorID", inside.authorID));
                addparent.Parameters.Add(new SqlParameter("@status", inside.status));
                addparent.Parameters.Add(new SqlParameter("@comment", inside.comment));
                addparent.Parameters.Add(new SqlParameter("@shelflife", inside.shelflife));
                addparent.Parameters.Add(new SqlParameter("@signerID", inside.signerID));
                addparent.Parameters.Add(new SqlParameter("@type", inside.type));

                int id = Convert.ToInt32(addparent.ExecuteScalar());

                addheir.Parameters.Add(new SqlParameter("@moneydifference", inside.moneydifference));
                addheir.Parameters.Add(new SqlParameter("@targetID", inside.targetID));
                addheir.Parameters.Add(new SqlParameter("@documentID", id));

                addheir.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally { Disconnect(); }
            return result;
        }

        public bool DropInside(int id)
        {
            bool result = true;
            Connect();

            try
            {
                string forheir = string.Format("Delete from DocumentInside where documentID='{0}'", id);
                string forparent = string.Format("Delete from Document where documentID='{0}'", id);
                SqlCommand dropheir = new SqlCommand(forheir, Connection);
                SqlCommand dropparent = new SqlCommand(forparent, Connection);

                dropheir.ExecuteNonQuery();
                dropparent.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally { Disconnect(); }
            return result;
        }

        public bool ChangeInside(int id, DocumentInside inside)
        {
            bool result = true;
            Connect();

            try
            {
                string forheir = string.Format("update DocumentInside set moneydifference=@moneydifference, targetID=@targetID, " +
                    "where documentID='{0}'", id);
                string forparent = string.Format("update Document set name=@name, creationdate=@creationdate, authorID=@authorID," +
                    " status=@status, shelflife=@shelflife, signerID=@signerID");
                SqlCommand changeheir = new SqlCommand(forheir, Connection);
                SqlCommand changeparent = new SqlCommand(forparent, Connection);

                changeheir.Parameters.AddWithValue("@productname", inside.moneydifference);
                changeheir.Parameters.AddWithValue("@productammount_killo", inside.targetID);

                changeparent.Parameters.AddWithValue("@name", inside.name);
                changeparent.Parameters.AddWithValue("@creationdate", inside.creationdate);
                changeparent.Parameters.AddWithValue("@authorID", inside.authorID);
                changeparent.Parameters.AddWithValue("@status", inside.status);
                changeparent.Parameters.AddWithValue("@shelflife", inside.shelflife);
                changeparent.Parameters.AddWithValue("@signerID", inside.signerID);
                changeparent.Parameters.AddWithValue("@type", inside.type);

                changeheir.ExecuteNonQuery();
                changeparent.ExecuteNonQuery();
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