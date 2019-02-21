<%@ Page Language="C#" %>
<%@ import Namespace="System.Data" %> 
<%@ import Namespace="MySql.Data.MySqlClient" %> 


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
	protected void Button1_Click(object sender, EventArgs e)
		{
	//Ocultar resultados
        gvResultado.Visible = false;
        lblErro.Text = "";
 
        //Declarar e atribuir valores        
        string strQuery = txtQuery.Text;
 
        try
        {
            //Informe aqui os dados de acesso ao banco [IMPORTANTE]
            String HOST    = "mysql01.jcpvipexecutivo.hospedagemdesites.ws";
            String USUARIO = "jcpvipexecutivo";
            String SENHA   = "f212830cde";
            String BANCO   = "jcpvipexecutivo";
 
            //Monta a string de conexão utilizando os dados informados anteriormente
            String stringConexao = "Database="+BANCO+";Data Source="+HOST+";User Id="+USUARIO+";Password="+SENHA+"; pooling=false";
 
            //Criando objeto MySqlConnection
            MySqlConnection objConexao = new MySqlConnection(stringConexao);
 
            //Criando objeto MySqlDataAdapter
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
 
            //Efetuando conexão e executando Query no banco de dados
            objAdapter.SelectCommand = new MySqlCommand(strQuery, objConexao);
 
            //Criando objeto DataSet para trabalhar com os dados
            DataSet ds = new DataSet();
 
            //Preencher objeto Dataset
            objAdapter.Fill(ds);
 
            //Alocando referencia ao GridView
            gvResultado.DataSource = ds;
 
            //Preenchendo GridView
            gvResultado.DataBind();
 
            //Mostrando GridView
            gvResultado.Visible = true;
 
            //Encerramento dos Objetos
            ds.Dispose();
            objAdapter.Dispose();
            objConexao.Close();
            objConexao.Dispose();
        }
        catch (MySqlException err)
        {
	    //Em caso de erros, mostrar o erro no "label" indicado.
            lblErro.Text = err.Message;
        }
    }
</script>
 
<source lang="html4strict">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>Exemplo</title>
  </head>
    <body>
      <form id="form1" runat="server">
        <div>
          Digite a instrução MySQL a ser executada:<br/>
          <asp:TextBox ID="txtQuery" runat="server" Height="136px" TextMode="MultiLine" Width="255px">Show Tables;</asp:TextBox>
          <br/>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQuery"
            ErrorMessage="Por favor, digite uma Query acima."></asp:RequiredFieldValidator><br />
          <br/>
          <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enviar" /><br />
          <br/>
          <br/>
          <asp:GridView ID="gvResultado" runat="server" Visible="False"></asp:GridView>
          <br/>
          <br/>
          &nbsp;<asp:Label ID="lblErro" runat="server" ForeColor="Red"></asp:Label>
        </div>
      </form>
    </body>
</html>
