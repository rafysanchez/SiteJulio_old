<%
Dim AspEmail, nomeRemetente, emailRemetente, nomeDestinatario, emaildestino, assunto, mensagem, servidor
nomeDestinatario = "Julio Cesar"
emaildestino = "juliocesar@jcpvipexecutivo.com"
nomeRemetente = Request.Form("name")
emailRemetente = Request.Form("email")
assunto = "Contato do Site"
mensagem = Request.Form("message")
servidor = "smtp.jcpvipexecutivo.com"
user = "admin@jcpvipexecutivo.com"
password = "jcpl2015"
porta = 587
SET AspEmail = Server.CreateObject("Persits.MailSender")
AspEmail.Host = servidor
AspEmail.Username = user
AspEmail.Password = password
AspEmail.Port = porta
AspEmail.FromName = nomeRemetente
AspEmail.From = emailRemetente
AspEmail.MailFrom = "admin@jcpvipexecutivo.com"
AspEmail.AddAddress emaildestino, nomeDestinatario
AspEmail.Subject = assunto
AspEmail.IsHTML = True
AspEmail.Body = mensagem
AspEmail.Send
Response.Write "Mensagem enviada com sucesso!" 
%>


