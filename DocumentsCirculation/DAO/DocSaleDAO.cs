using DocumentsCirculation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DocumentsCirculation.DAO
{
    public class DocSaleDAO: DAO
    {

        public List<DocumentSale> GetAllSales()
        {
            Connect();
            List<DocumentSale> DList = new List<DocumentSale>();
            try
            {
                SqlCommand command = new SqlCommand("select * from Document, DocumentSale where Document.documentID=DocumentSale.documentID", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DocumentSale sale = new DocumentSale();

                    sale.documentID = Convert.ToInt32(reader["documentID"]);
                    sale.name = Convert.ToString(reader["name"]);
                    sale.creationdate = Convert.ToDateTime(reader["creationdate"]);
                    sale.authorID = Convert.ToInt32(reader["authorID"]);
                    sale.status = Convert.ToString(reader["status"]);
                    sale.comment = Convert.ToString(reader["comment"]);
                    sale.shelflife = Convert.ToDateTime(reader["shelflife"]);
                    sale.signerID = Convert.ToInt32(reader["signerID"]);
                    sale.type = Convert.ToString(reader["type"]);

                    sale.productname = Convert.ToString(reader["productname"]);
                    sale.productammount_num = Convert.ToInt32(reader["productammount_number"]);
                    sale.productprice_for_one = Convert.ToInt32(reader["productprice"]);
                    sale.buyerID = Convert.ToInt32(reader["buyerID"]);

                    DList.Add(sale);
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

        public bool AddSale(DocumentSale sale)
        {
            bool result = true;
            Connect();

            try
            {
                SqlCommand addparent = new SqlCommand("insert into Document (name, creationdate, authorID, status, comment, shelflife, signerID, type) "
                    + "VALUES (@name, @creationdate, @authorID, @status, @comment, @shelflife, @signerID, @type)", Connection);
                SqlCommand addheir = new SqlCommand("insert into DocumentSale (productname, productammount_number, productprice, buyerID, documentID)"
                    + "values (@productname, @productammount_number, @productprice, @buyerID, @documentID)");

                addparent.Parameters.Add(new SqlParameter("@name", sale.name));
                addparent.Parameters.Add(new SqlParameter("@creationdate", sale.creationdate));
                addparent.Parameters.Add(new SqlParameter("@authorID", sale.authorID));
                addparent.Parameters.Add(new SqlParameter("@status", sale.status));
                addparent.Parameters.Add(new SqlParameter("@comment", sale.comment));
                addparent.Parameters.Add(new SqlParameter("@shelflife", sale.shelflife));
                addparent.Parameters.Add(new SqlParameter("@signerID", sale.signerID));
                addparent.Parameters.Add(new SqlParameter("@type", sale.type));

                int id = Convert.ToInt32(addparent.ExecuteScalar());

                addheir.Parameters.Add(new SqlParameter("@productname", sale.productname));
                addheir.Parameters.Add(new SqlParameter("@productammount_number",sale.productammount_num));
                addheir.Parameters.Add(new SqlParameter("@productprice", sale.productprice_for_one));
                addheir.Parameters.Add(new SqlParameter("@buyerID", sale.buyerID));
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

        public bool DropSale(int id)
        {
            bool result = true;
            Connect();

            try
            {
                string forheir = string.Format("Delete from DocumentSale where documentID='{0}'", id);
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

        public bool ChangeSale(int id, DocumentSale sale)
        {
            bool result = true;
            Connect();

            try
            {
                string forheir = string.Format("update DocumentSale set productname=@productname, productammount_number=@productammount_number, " +
                    "productprice=@productprice, buyerID=@buyerID where documentID='{0}'", id);
                string forparent = string.Format("update Document set name=@name, creationdate=@creationdate, authorID=@authorID," +
                    " status=@status, shelflife=@shelflife, signerID=@signerID, type=@type");
                SqlCommand changeheir = new SqlCommand(forheir, Connection);
                SqlCommand changeparent = new SqlCommand(forparent, Connection);

                changeheir.Parameters.AddWithValue("@productname", sale.productname);
                changeheir.Parameters.AddWithValue("@productammount_number", sale.productammount_num);
                changeheir.Parameters.AddWithValue("@productprice", sale.productprice_for_one);
                changeheir.Parameters.AddWithValue("@buyerID", sale.buyerID);

                changeparent.Parameters.AddWithValue("@name", sale.name);
                changeparent.Parameters.AddWithValue("@creationdate", sale.creationdate);
                changeparent.Parameters.AddWithValue("@authorID", sale.authorID);
                changeparent.Parameters.AddWithValue("@status", sale.status);
                changeparent.Parameters.AddWithValue("@shelflife", sale.shelflife);
                changeparent.Parameters.AddWithValue("@signerID", sale.signerID);
                changeparent.Parameters.AddWithValue("@type", sale.type);

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