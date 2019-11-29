using DocumentsCirculation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DocumentsCirculation.DAO
{
    public class DocBuyDAO: DAO
    {
        public List<DocumentBuy> GetAllBuys()
        {
            Connect();
            List<DocumentBuy> DList = new List<DocumentBuy>();
            try
            {
                SqlCommand command = new SqlCommand("select * from Document, DocumentBuy where Document.documentID=DocumentBuy.documentID", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DocumentBuy buy = new DocumentBuy();

                    buy.documentID = Convert.ToInt32(reader["documentID"]);
                    buy.name = Convert.ToString(reader["name"]);
                    buy.creationdate = Convert.ToDateTime(reader["creationdate"]);
                    buy.authorID = Convert.ToInt32(reader["authorID"]);
                    buy.status = Convert.ToString(reader["status"]);
                    buy.comment = Convert.ToString(reader["comment"]);
                    buy.shelflife = Convert.ToDateTime(reader["shelflife"]);
                    buy.signerID = Convert.ToInt32(reader["signerID"]);
                    buy.type = Convert.ToString(reader["type"]);

                    buy.productname = Convert.ToString(reader["productname"]);
                    buy.productammount_killo = Convert.ToInt32(reader["productammount_killo"]);
                    buy.productprice_for_killo = Convert.ToInt32(reader["productprice"]);
                    buy.sellerID = Convert.ToInt32(reader["sellerID"]);

                    DList.Add(buy);
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

        public bool AddBuy(DocumentBuy buy)
        {
            bool result = true;
            Connect();

            try
            {
                SqlCommand addparent = new SqlCommand("insert into Document (name, creationdate, authorID, status, comment, shelflife, signerID, type) "
                    + "VALUES (@name, @creationdate, @authorID, @status, @comment, @shelflife, @signerID, @type)", Connection);
                SqlCommand addheir = new SqlCommand("insert into DocumentSale (productname, productammount_killo, productprice, sellerID, documentID)"
                    + "values (@productname, @productammount_killo, @productprice, @sellerID, @documentID)", Connection);

                addparent.Parameters.Add(new SqlParameter("@name", buy.name));
                addparent.Parameters.Add(new SqlParameter("@creationdate", buy.creationdate));
                addparent.Parameters.Add(new SqlParameter("@authorID", buy.authorID));
                addparent.Parameters.Add(new SqlParameter("@status", "Создан"));
                addparent.Parameters.Add(new SqlParameter("@comment", buy.comment));
                addparent.Parameters.Add(new SqlParameter("@shelflife", buy.shelflife));
                addparent.Parameters.Add(new SqlParameter("@signerID", buy.signerID));
                addparent.Parameters.Add(new SqlParameter("@type", buy.type));

                int id = Convert.ToInt32(addparent.ExecuteScalar());

                addheir.Parameters.Add(new SqlParameter("@productname", buy.productname));
                addheir.Parameters.Add(new SqlParameter("@productammount_number", buy.productammount_killo));
                addheir.Parameters.Add(new SqlParameter("@productprice", buy.productprice_for_killo));
                addheir.Parameters.Add(new SqlParameter("@buyerID", buy.sellerID));
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

        //public bool DropBuy(int id)
        //{
        //    bool result = true;
        //    Connect();

        //    try
        //    {
        //        string forheir = string.Format("Delete from DocumentBuy where documentID='{0}'", id);
        //        string forparent = string.Format("Delete from Document where documentID='{0}'", id);
        //        SqlCommand dropheir = new SqlCommand(forheir, Connection);
        //        SqlCommand dropparent = new SqlCommand(forparent, Connection);

        //        dropheir.ExecuteNonQuery();
        //        dropparent.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        result = false;
        //    }
        //    finally { Disconnect(); }
        //    return result;
        //}

        public bool ChangeBuy(int id, DocumentBuy buy)
        {
            bool result = true;
            Connect();

            try
            {
                string forheir = string.Format("update DocumentSale set productname=@productname, productammount_killo=@productammount_killo, " +
                    "productprice=@productprice, sellerID=@sellerID where documentID='{0}'", id);
                string forparent = string.Format("update Document set name=@name, creationdate=@creationdate, authorID=@authorID," +
                    " status=@status, shelflife=@shelflife, signerID=@signerID, type=@type where documentID='{0}'", id);
                SqlCommand changeheir = new SqlCommand(forheir, Connection);
                SqlCommand changeparent = new SqlCommand(forparent, Connection);

                changeheir.Parameters.AddWithValue("@productname", buy.productname);
                changeheir.Parameters.AddWithValue("@productammount_killo", buy.productammount_killo);
                changeheir.Parameters.AddWithValue("@productprice", buy.productprice_for_killo);
                changeheir.Parameters.AddWithValue("@buyerID", buy.sellerID);

                changeparent.Parameters.AddWithValue("@name", buy.name);
                changeparent.Parameters.AddWithValue("@creationdate", buy.creationdate);
                changeparent.Parameters.AddWithValue("@authorID", buy.authorID);
                changeparent.Parameters.AddWithValue("@status", "Создан");
                changeparent.Parameters.AddWithValue("@shelflife", buy.shelflife);
                changeparent.Parameters.AddWithValue("@signerID", buy.signerID);
                changeparent.Parameters.AddWithValue("@type", buy.type);

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