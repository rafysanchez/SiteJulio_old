using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using TesteFramework.Models;



namespace JulioMVC.Repositorio
{
    public class UsuarioRepositorio
    {
        private bool connection_open;
        private MySqlConnection con;
       
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ToString();
            con = new MySqlConnection(constr);

        }
        //To Add Employee details
        public bool AddEmployee(EmpModel obj)
        {

            connection();
         MySqlCommand com = new MySqlCommand("AddNewEmpDetails", con);
         com.CommandType =  System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To view employee details with generic list 
        public List<EmpModel> GetAllEmployees()
        {
            connection();
            List<EmpModel> EmpList = new List<EmpModel>();
            MySqlCommand com = new MySqlCommand("GetEmployees", con);
            com.CommandType =System.Data.CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(com);
            System.Data.DataTable dt = new System.Data.DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Uncooment if convert Datatable to list using AsEnumerable
            //List<DataRow> list = dt.AsEnumerable().ToList();
            //foreach (var item in list)
            //{
            //    EmpList.Add(

            //       new EmpModel
            //       {
            //           Empid = Convert.ToInt32(item["Id"]),
            //           Name = Convert.ToString(item["Name"]),
            //           City = Convert.ToString(item["City"]),
            //           Address = Convert.ToString(item["Address"])

            //       });
            //}

            //Uncomment if you wants to Bind EmpModel generic list using LINQ 
            //EmpList = (from DataRow dr in dt.Rows

            //        select new EmpModel()
            //        {
            //            Empid = Convert.ToInt32(dr["Id"]),
            //            Name = Convert.ToString(dr["Name"]),
            //            City = Convert.ToString(dr["City"]),
            //            Address = Convert.ToString(dr["Address"])
            //        }).ToList();


            //  Bind EmpModel generic list using dataRow
            foreach ( System.Data.DataRow dr in dt.Rows)
            {

                EmpList.Add(

                    new EmpModel
                    {

                        Empid = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"])

                    }


                    );


            }

            return EmpList;


        }
        //To Update Employee details
        public bool UpdateEmployee(EmpModel obj)
        {

            connection();
            MySqlCommand com = new MySqlCommand("UpdateEmpDetails", con);

            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", obj.Empid);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To delete Employee details
        public bool DeleteEmployee(int Id)
        {

            connection();
            MySqlCommand com = new MySqlCommand("DeleteEmpById", con);

            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }



    }
}