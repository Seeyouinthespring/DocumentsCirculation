using DocumentsCirculation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DocumentsCirculation.DAO;

namespace DocumentsCirculation.DAO
{
    public class AdministrationDAO:DAO
    {
        public bool DropDoc(int id)
        {
            Logger.InitLogger();
            Logger.Log.Info("Метод удаления записи");

            bool result = true;
            Connect();
            Document doc = new Document();
            //string type;

            try
            {
                string forinside = string.Format("Delete from DocumentInside where documentID='{0}'", id);
                string forreport = string.Format("Delete from DocumentReport where documentID='{0}'", id);
                string forbuy = string.Format("Delete from DocumentBuy where documentID='{0}'", id);
                string forsale = string.Format("Delete from DocumentSale where documentID='{0}'", id);
                string forparent = string.Format("Delete from Document where documentID='{0}'", id);

                SqlCommand dropinside = new SqlCommand(forinside, Connection);
                SqlCommand dropreport = new SqlCommand(forreport, Connection);
                SqlCommand dropsale = new SqlCommand(forsale, Connection);
                SqlCommand dropbuy = new SqlCommand(forbuy, Connection);
                SqlCommand dropparent = new SqlCommand(forparent, Connection);

                //string type;
                string forgetting = string.Format("Select type from Document where documentID='{0}'", id);
                SqlCommand gettype = new SqlCommand(forgetting, Connection);
                SqlDataReader reader = gettype.ExecuteReader();
                while (reader.Read())
                {
                    doc.type = Convert.ToString(reader["type"]);
                    Logger.Log.Info("Значение переменной doc.type:"+doc.type);
                }
                reader.Close();
                Logger.Log.Info("Значение переменной doc.type после закрытия reader:" + doc.type);
                switch (doc.type)
                {
                    case "Продажи":
                        dropsale.ExecuteNonQuery();
                        dropparent.ExecuteNonQuery();
                        break;
                    case "Покупки":
                        dropbuy.ExecuteNonQuery();
                        dropparent.ExecuteNonQuery();
                        break;
                    case "Внутренний":
                        dropinside.ExecuteNonQuery();
                        dropparent.ExecuteNonQuery();
                        break;
                    case "Отчет":
                        dropreport.ExecuteNonQuery();
                        dropparent.ExecuteNonQuery();
                        break;
                    default:
                        //ошибка
                        break;
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error("ERROR: " + e.Message);
                result = false;
            }
            finally { Disconnect(); }
            return result;
        }

        public bool SendForSign(int id)
        {
            bool result = true;
            Connect();

            try
            {
                string forsend = string.Format("Update Document set status=@status where documentID='{0}'", id);
                SqlCommand sendforsign = new SqlCommand(forsend, Connection);
                sendforsign.Parameters.AddWithValue("@status", "Отправлен на подписание");
                sendforsign.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally { Disconnect(); }
            return result;
        }

        public bool Sign(int id)
        {
            bool result = true;
            Connect();

            try
            {
                string forsign = string.Format("Update Document set status=@status where documentID='{0}'", id);
                SqlCommand sign = new SqlCommand(forsign, Connection);
                sign.Parameters.AddWithValue("@status", "Подписан");
                sign.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally { Disconnect(); }
            return result;
        }

        public bool SendForChange(int id, string com)
        {
            bool result = true;
            Connect();

            try
            {
                string forchange = string.Format("Update Document set status=@status, comment=@comment where documentID='{0}'", id);

                SqlCommand sendforchange = new SqlCommand(forchange, Connection);
                sendforchange.Parameters.AddWithValue("@comment", com);
                sendforchange.Parameters.AddWithValue("@status", "Подлежит редактированию");
                sendforchange.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally { Disconnect(); }
            return result;
        }

        public bool SendForDrop(int id)
        {
            bool result = true;
            Connect();

            try
            {
                string forsend = string.Format("Update Document set status=@status where documentID='{0}'", id);
                SqlCommand sendforsign = new SqlCommand(forsend, Connection);
                sendforsign.Parameters.AddWithValue("@status", "Отправлен на удаление");
                sendforsign.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally { Disconnect(); }
            return result;
        }

        public List<Document> GetAll()
        {
            Connect();
            List<Document> DList = new List<Document>();
            try
            {
                SqlCommand command = new SqlCommand("select * from Document", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DocumentSale doc = new DocumentSale();

                    doc.documentID = Convert.ToInt32(reader["documentID"]);
                    doc.name = Convert.ToString(reader["name"]);
                    doc.creationdate = Convert.ToDateTime(reader["creationdate"]);
                    doc.authorID = Convert.ToInt32(reader["authorID"]);
                    doc.status = Convert.ToString(reader["status"]);
                    doc.comment = Convert.ToString(reader["comment"]);
                    doc.shelflife = Convert.ToDateTime(reader["shelflife"]);
                    doc.signerID = Convert.ToInt32(reader["signerID"]);
                    doc.type = Convert.ToString(reader["type"]);

                    DList.Add(doc);
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
    }
}