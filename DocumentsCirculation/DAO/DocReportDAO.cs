using DocumentsCirculation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DocumentsCirculation.DAO
{
    public class DocReportDAO:DAO
    {
        public List<DocumentReport> GetAllReports()
        {
            Connect();
            List<DocumentReport> DList = new List<DocumentReport>();
            try
            {
                SqlCommand command = new SqlCommand("select * from Document, DocumentReport where Document.documentID=DocumentReport.documentID", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DocumentReport report = new DocumentReport();

                    report.documentID = Convert.ToInt32(reader["documentID"]);
                    report.name = Convert.ToString(reader["name"]);
                    report.creationdate = Convert.ToDateTime(reader["creationdate"]);
                    report.authorID = Convert.ToInt32(reader["authorID"]);
                    report.status = Convert.ToString(reader["status"]);
                    report.comment = Convert.ToString(reader["comment"]);
                    report.shelflife = Convert.ToDateTime(reader["shelflife"]);
                    report.signerID = Convert.ToInt32(reader["signerID"]);
                    report.type = Convert.ToString(reader["type"]);

                    report.startdate = Convert.ToDateTime(reader["startdate"]);
                    report.enddate = Convert.ToDateTime(reader["enddate"]);
                    report.stats = Convert.ToString(reader["stats"]);

                    DList.Add(report);
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

        public bool AddReport(DocumentReport report)
        {
            bool result = true;
            Connect();

            try
            {
                SqlCommand addparent = new SqlCommand("insert into Document (name, creationdate, authorID, status, comment, shelflife, signerID, type) "
                    + "VALUES (@name, @creationdate, @authorID, @status, @comment, @shelflife, @signerID, @type)", Connection);
                SqlCommand addheir = new SqlCommand("insert into DocumentReport (startdate, enddate, stats, documentID)"
                    + "values (@startdate, @enddate, @stats, @documentID)");

                addparent.Parameters.Add(new SqlParameter("@name", report.name));
                addparent.Parameters.Add(new SqlParameter("@creationdate", report.creationdate));
                addparent.Parameters.Add(new SqlParameter("@authorID", report.authorID));
                addparent.Parameters.Add(new SqlParameter("@status", report.status));
                addparent.Parameters.Add(new SqlParameter("@comment", report.comment));
                addparent.Parameters.Add(new SqlParameter("@shelflife", report.shelflife));
                addparent.Parameters.Add(new SqlParameter("@signerID", report.signerID));
                addparent.Parameters.Add(new SqlParameter("@type", report.type));

                int id = Convert.ToInt32(addparent.ExecuteScalar());

                addheir.Parameters.Add(new SqlParameter("@startdate", report.startdate));
                addheir.Parameters.Add(new SqlParameter("@enddate", report.enddate));
                addheir.Parameters.Add(new SqlParameter("@stats", report.stats));
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

        public bool DropReport(int id)
        {
            bool result = true;
            Connect();

            try
            {
                string forheir = string.Format("Delete from DocumentReport where documentID='{0}'", id);
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

        public bool ChangeReport(int id, DocumentReport report)
        {
            bool result = true;
            Connect();

            try
            {
                string forheir = string.Format("update DocumentSale set startdate=@startdate, enddate=@enddate, stats=@stats where documentID='{0}'", id);
                string forparent = string.Format("update Document set name=@name, creationdate=@creationdate, authorID=@authorID," +
                    " status=@status, shelflife=@shelflife, signerID=@signerID, type=@type");
                SqlCommand changeheir = new SqlCommand(forheir, Connection);
                SqlCommand changeparent = new SqlCommand(forparent, Connection);

                changeheir.Parameters.AddWithValue("@startdate", report.startdate);
                changeheir.Parameters.AddWithValue("@enddate", report.enddate);
                changeheir.Parameters.AddWithValue("@stats", report.stats);

                changeparent.Parameters.AddWithValue("@name", report.name);
                changeparent.Parameters.AddWithValue("@creationdate", report.creationdate);
                changeparent.Parameters.AddWithValue("@authorID", report.authorID);
                changeparent.Parameters.AddWithValue("@status", report.status);
                changeparent.Parameters.AddWithValue("@shelflife", report.shelflife);
                changeparent.Parameters.AddWithValue("@signerID", report.signerID);
                changeparent.Parameters.AddWithValue("@type", report.type);

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