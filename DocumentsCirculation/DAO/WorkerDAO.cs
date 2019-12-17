using DocumentsCirculation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DocumentsCirculation.DAO
{
    public class WorkerDAO:DAO
    {
        public List<Worker> GetAllWorkers()
        {
            Logger.InitLogger();
            Logger.Log.Info("Метод вызова всех рабочих");
            Connect();
            List<Worker> WList = new List<Worker>();
            try
            {
                SqlCommand command = new SqlCommand("select * from Worker", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Worker worker = new Worker();

                    worker.workerID = Convert.ToInt32(reader["workerID"]);
                    worker.fio = Convert.ToString(reader["fio"]);
                    worker.birthdate = Convert.ToDateTime(reader["birthdate"]);
                    worker.employdate = Convert.ToDateTime(reader["employdate"]);
                    worker.salary = Convert.ToDecimal(reader["salary"]);
                    worker.role = Convert.ToString(reader["role"]);
                    worker.email = Convert.ToString(reader["email"]);

                    WList.Add(worker);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Logger.Log.Error("ERROR: " + e.Message);
            }
            finally
            {
                Disconnect();
            }
            return WList;
        }

        public bool AddWorker(Worker worker)
        {
            bool result = true;
            Connect();

            try
            {
                SqlCommand add = new SqlCommand("insert into Worker (fio, birthdate, employdate, salary, role, email) "
                    + "VALUES (@fio, @birthdate, @employdate, @salary, @role @email)", Connection);

                add.Parameters.Add(new SqlParameter("@fio", worker.fio));
                add.Parameters.Add(new SqlParameter("@birthdate", worker.birthdate));
                add.Parameters.Add(new SqlParameter("@employdate", worker.employdate));
                add.Parameters.Add(new SqlParameter("@salary", worker.salary));
                add.Parameters.Add(new SqlParameter("@role", worker.role));
                add.Parameters.Add(new SqlParameter("@email", worker.email));

                add.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Logger.Log.Error("ERROR: " + e.Message);
                result = false;
            }
            finally { Disconnect(); }
            return result;
        }

        public bool DropWorker(int id)
        {
            bool result = true;
            Connect();

            try
            {
                string dropstring = string.Format("Delete from Worker where worklerID='{0}'", id);
                SqlCommand dropclient = new SqlCommand(dropstring, Connection);

                dropclient.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Logger.Log.Error("ERROR: " + e.Message);
                result = false;
            }
            finally { Disconnect(); }
            return result;
        }

        public bool ChangeWorker(int id, Worker worker)
        {
            bool result = true;
            Connect();

            try
            {
                string updatestring = string.Format("update Worker set fio=@fio, birthdate=@birthdate, employdate=@employdate, salary=@salary, role=@role, email=@email where workerID='{0}'", id);

                SqlCommand change = new SqlCommand(updatestring, Connection);

                change.Parameters.AddWithValue("@fio", worker.fio);
                change.Parameters.AddWithValue("@birthdate", worker.birthdate);
                change.Parameters.AddWithValue("@employdate", worker.employdate);
                change.Parameters.AddWithValue("@salary", worker.salary);
                change.Parameters.AddWithValue("@role", worker.role);
                change.Parameters.AddWithValue("@email", worker.email);
                change.ExecuteNonQuery();
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