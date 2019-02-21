<%
 
' CONEXÃO ACCESS
 
Set conn=Server.CreateObject("ADODB.Connection")
drv= "DRIVER={Microsoft Access Driver (*.mdb)}; DBQ="& Server.MapPath("banco.mdb") & ";"
conn.Open drv
 
login=Request.QueryString("login") 'aqui recuperamos o login digitado, através da QueryString
senha=Request.QueryString("senha") 'aqui recuperamos a senha digitado, através da QueryString
 
'SQL QUE SELECIONA OS DADOS DO USUARIO CASO O LIGN E A SENHA ETEJAM CORRETOS
sql = "SELECT * FROM usuarios WHERE login = '" & login &"' AND senha = '" & senha & "' "
 
'SETAMOS A VARIAVEL rsLogar e ABRIMOS O COMANDO SQL
Set rsLogar = Server.CreateObject("ADODB.Recordset")
rsLogar.Open sql, conn
 
'A CONDIÇÃOˆ -  SE CHEGOU AO FIM "eof" DO BANCO DE DADOS, SIGNIFICA QUE
'NAO EXISTE NADA COM ESSE LOGIN E COM ESSA SENHA
'SENAO "Else" ELE ABRE A SESSAO 'Entrada' que é igual a "sim" E JUNTAMENTE PEGA OS DADOS DO USUARIO PARA USAR NAS PAGINAS SEGUINTES...
 
'Segue abaixo
 
if (rsLogar.eof) Then
 
Response.Write "ERRO - Login ou Senha incorretos"
 
Else
 
Session("entrada") = "sim"
Session("nome") = rsLogar("nome")
 
Response.redirect("pagina_restrita.asp")
 
 
End If
 
%>
