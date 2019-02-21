using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;
using System.IO;
//using MySql.Data.MySqlClient;

public partial class aspx_testecon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
      ////  string strConn = "DRIVER={MySQL ODBC 3.51 Driver};Database=jcpvipexecutivo;Server=179.188.16.30;UID=jcpvipexecutivo;PWD=f212830cde;";

      //  string strConn = "Driver={MySQL ODBC 5.1 Driver}; Data Source=mysql01.jcpvipexecutivo.hospedagemdesites.ws;Port=3306;Database=jcpvipexecutivo;User=jcpvipexecutivo; Password=f212830cde;Option=3;";

      //  System.Data.Odbc.OdbcConnection con = new OdbcConnection(strConn);

      //  System.Data.Odbc.OdbcDataAdapter myDataAdapter = new OdbcDataAdapter(strConn, con); 
       
      //  string    strSQL = "SELECT * FROM usuarios";
      //  DataSet myDataSet    = new  DataSet();
        

      //  myDataAdapter.Fill(myDataSet, strSQL);


      //  MySQLDataGrid.DataSource = myDataSet;
      //  MySQLDataGrid.DataBind();


        string strConexao;
        strConexao = "DRIVER={MySQL ODBC 5.1 Driver};SERVER=mysql01.jcpvipexecutivo.hospedagemdesites.ws;";
        strConexao = strConexao + "DATABASE=jcpvipexecutivo;USER=jcpvipexecutivo;PASSWORD=f212830cde;OPTION=3;";

        //Cria a conexão com o banco de dados usando o método Connection
        OdbcConnection conexao = new OdbcConnection(strConexao);

        //Criae uma variável que contém a consulta a ser feita
        string strSQL = "SELECT * FROM usuarios;";
        
        /*
        Com o método "Command", executa-se a consulta do banco este comando recebe dois parâmetros
        A string de consulta e a conexão
        */
        OdbcCommand comando = new OdbcCommand(strSQL, conexao);

        //Abre a Conexão com o banco.
        conexao.Open();

        ////Com o Objeto "ExecuteReader", criamos um objeto do tipo "DataReader" que irá conter os dados da consulta
        //OdbcDataReader r = comando.ExecuteReader();

        ////Abre um bloco try, caso ocorra algum problema ele executa direto o que estiver no bloco finally, que

        ////no caso fecha a conexão com o banco, quando o que estiver dentro de try for finalizado o finally também é executado
        //try
        //{

        //    //Lêem-se todos os registros retornados e os imprime no browser
        //    while (r.Read())
        //    {
        //        Response.Write(r[0].ToString() + "<br>");
        //    }
        //}
        //finally
        //{

        //    //Fecha a conexão do DataReader e depois do banco
        //    r.Close();
        //    conexao.Close();
        //}

        Response.Write("Consulta feita com sucesso!!");


    }
}