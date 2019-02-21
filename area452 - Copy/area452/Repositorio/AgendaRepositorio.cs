using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using area452.Models;
using System.Data;

namespace area452.Repositorio
{

    public class AgendaRepositorio
    {
        // todas as funções de banco mysql
        private bool connection_open;
        private MySqlConnection connection;


        public int InsereLinhasClientes(ClienteLoc clienteLoc)
        {


            string createQuery = String.Format("Insert into tb_clientesLoc (nome, endereco , telefone, email) Values('"+ 
                 clienteLoc.Nome +"','" + clienteLoc.Endereco+ "','" + clienteLoc.Telefone + "','" + clienteLoc.Email +"')");

           
            //Create and open a connection to SQL Server 
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);
            connection.Open();

            //Create a Command object
            MySqlCommand command = null;

           command = new MySqlCommand(createQuery, connection);

            int savedclienteLocID = 0;
            try
            {
                //Execute the command to SQL Server and return the newly created ID
                var commandResult = command.ExecuteScalar();
                if (commandResult != null)
                {
                    savedclienteLocID = Convert.ToInt32(commandResult);
                }
                
            }
            catch 
            {
               
                throw  null;
                //there was a problem executing the script
            }

            //Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();

            return savedclienteLocID;

        }


        private void Get_Connection()
        {
            connection_open = false;

            connection = new MySqlConnection();
            //connection = DB_Connect.Make_Connnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            //            if (db_manage_connnection.DB_Connect.OpenTheConnection(connection))
            if (Open_Local_Connection())
            {
                connection_open = true;
            }
            else
            {
                //					MessageBox::Show("No database connection connection made...\n Exiting now", "Database Connection Error");
                //					 Application::Exit();
            }

        }

        private bool Open_Local_Connection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch 
            {
                return false;
            }
        }


        public int SaveAgenda(Agenda agenda)
        {

            //Create the SQL Query for inserting an agenda
            string createQuery = String.Format("Insert into tblagenda (Casa, Cliente ,DataEntrada, DataSaida,HoraEntrada,HoraSaida) Values('{0}', '{1}', '{2}', {3} );"
                + "Select @@Identity", agenda.Casa, agenda.Cliente, agenda.DataEntrada.ToString("yyyy-MM-dd"), agenda.DataSaida.ToString("yyyy-MM-dd"), agenda.HoraEntrada.ToString("yyyy-MM-dd"), agenda.HoraSaida.ToString("yyyy-MM-dd"));

            //Create the SQL Query for updating an agenda
            string updateQuery = String.Format("Update tblagenda SET Casa='{0}', Cliente = '{1}', DataEntrada ='{2}', DataSaida = {3}, HoraEntrada = {4}, HoraSaida={5} Where agendaID = {6};",
                agenda.Casa, agenda.Cliente, agenda.DataEntrada.ToString("yyyy-MM-dd"), agenda.DataSaida.ToString("yyyy-MM-dd"), agenda.HoraEntrada.ToString("hh-mm-ss"), agenda.HoraEntrada.ToString("hh-mm-ss"), agenda.AgendaID);

            //Create and open a connection to SQL Server 
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);
            connection.Open();

            //Create a Command object
            MySqlCommand command = null;

            if (agenda.AgendaID != 0)
                command = new MySqlCommand(updateQuery, connection);
            else
                command = new MySqlCommand(createQuery, connection);

            int savedagendaID = 0;
            try
            {
                //Execute the command to SQL Server and return the newly created ID
                var commandResult = command.ExecuteScalar();
                if (commandResult != null)
                {
                    savedagendaID = Convert.ToInt32(commandResult);
                }
                else
                {
                    //the update SQL query will not return the primary key but if doesn't throw exception 
                    //then we will take it from the already provided data
                    savedagendaID = agenda.AgendaID;
                }
            }
            catch 
            {
                //there was a problem executing the script
            }

            //Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();

            return savedagendaID;
        }

        /// <summary>
        /// Method created for deleting an article 
        /// </summary>
        /// <param name="ArticleID"></param>
        /// <returns></returns>
        public bool DeleteAgenda(int agendaID)
        {
            bool result = false;

            //Create the SQL Query for deleting an article
            string sqlQuery = String.Format("delete from tblagenda where agendaID = {0}", agendaID);

            //Create and open a connection to SQL Server 
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);
            connection.Open();

            //Create a Command object
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);

            // Execute the command
            int rowsDeletedCount = command.ExecuteNonQuery();
            if (rowsDeletedCount != 0)
                result = true;
            // Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();


            return result;
        }

        /// <summary>
        /// Method created for returning the articles
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public List<Agenda> GetAgendas()
        {

            List<Agenda> result = new List<Agenda>();

            //Create the SQL Query for returning all the articles
            string sqlQuery = String.Format("select * from tblagenda");


            // MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);

            MySqlConnection connection = new MySqlConnection("Server=179.188.16.30;User Id=jcpvipexecutivo;Database=jcpvipexecutivo;Pwd=f212830cde;includesecurityasserts=true;");

            connection.Open();

            MySqlCommand command = new MySqlCommand(sqlQuery, connection);

            //Create DataReader for storing the returning table into server memory
            MySqlDataReader dataReader = command.ExecuteReader();

            Agenda agenda = null;

            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    agenda = new Agenda();

                    agenda.AgendaID = Convert.ToInt32(dataReader["AgendaID"]);
                    agenda.Casa = dataReader["Casa"].ToString();
                    agenda.Cliente = dataReader["Cliente"].ToString();
                    agenda.DataEntrada = Convert.ToDateTime(dataReader["DataEntrada"]);
                    agenda.DataSaida = Convert.ToDateTime(dataReader["DataSaida"]);
                    // agenda.HoraEntrada = Convert.ToDateTime(dataReader["HoraEntrada"]);
                    // agenda.HoraSaida = Convert.ToDateTime(dataReader["HoraSaida"]);
                    result.Add(agenda);
                }
            }

            return result;

        }

        /// <summary>
        /// Method created for returing an article by Id
        /// </summary>
        /// <returns></returns>
        public Agenda GetAgendaById(int agendaID)
        {
            Agenda result = new Agenda();

            //Create the SQL Query for returning an article category based on its primary key
            string sqlQuery = String.Format("select * from tblagenda where AgendaID={0}", agendaID);

            //Create and open a connection to SQL Server 
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand(sqlQuery, connection);

            MySqlDataReader dataReader = command.ExecuteReader();

            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    result.AgendaID = Convert.ToInt32(dataReader["ArticleID"]);
                    result.Casa = dataReader["Casa"].ToString();
                    result.Cliente = dataReader["Cliente"].ToString();
                    result.DataEntrada = Convert.ToDateTime(dataReader["DataEntrada"]);
                    result.DataSaida = Convert.ToDateTime(dataReader["DataSaida"]);
                }
            }

            return result;
        }


        public bool TESTE()
        {
            using (var connection = new MySqlConnection("Server=179.188.16.30;User Id=jcpvipexecutivo;Database=jcpvipexecutivo;Pwd=f212830cde;includesecurityasserts=true;pooling=false;"))
            {

                connection.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from tblagenda";

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                string dado = (string.Format("Valor 1: {0} - Valor 2: {1}<br/>", dr["Casa"], dr["Cliente"]));

                            }
                        }
                    }
                }
            }

            return true;
        }


       


    }
}