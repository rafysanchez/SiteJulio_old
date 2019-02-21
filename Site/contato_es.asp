<%
Dim AspEmail, nomeRemetente, emailRemetente, nomeDestinatario, emaildestino, assunto, mensagem, servidor,resposta
if Request.Form("message") <> ""  then
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
	resposta = "ok"
	Response.Write "" 
end if
%>




<!DOCTYPE html>
<html lang="eng">
 <head> 
 <!--[if lt IE 9]>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/html5shiv/3.7.2/html5shiv.js"></script>
  <![endif]-->
  <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Transporte Executivo">
    <meta name="author" content="portalsoftwares ltda">
 
  <title>JCP - Contacto</title>
  <!-- Bootstrap CSS -->
  <link href="./css/bootstrap.min.css" rel="stylesheet" media="screen">
  <link rel="stylesheet" type="text/css" href="CSS/style.css">
  
 </head>
 <body style=" background-color:#000">

<div class="container">

 <div class="navbar navbar-default">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="/" style="font-size:15px">TRANSPORTE EXECUTIVO</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li ><a href="/xindex_es.html">Home</a></li>
                    <li><a href="servicos_es.html">Nuestros Servicios</a></li>
                    <li ><a href="empresa_es.html">JCP - Empresa</a></li> 
                    <li class="active"><a href="contato_es.html">Contacto</a></li> 
                </ul>
                    

            </div>
        </div>
    </div>


</div> 


 <!-- Contacts -->
 <div id="contacts">
   <div class="row">	
     <!-- Alignment -->
	<div class="col-sm-offset-3 col-sm-6">
	   <!-- Form itself -->
          <form name="sentMessage" class="well" id="contactForm" method="post" action="" novalidate>
	       <legend>Contáctame</legend>
		 <div class="control-group">
                    <div class="controls">
			<input type="text" class="form-control" 
			   	   placeholder="Nombre Completo" id="name" name="name" required
			           data-validation-required-message="introduzca su nombre" />
			  <p class="help-block"></p>
		   </div>
	         </div> 	
                <div class="control-group">
                  <div class="controls">
			<input type="email" class="form-control" placeholder="Correo electrónico" 
			   	            id="email" name="email" required
			   		   data-validation-required-message="Introduce tu correo electrónico" />
		</div>
	    </div> 	
			  
               <div class="control-group">
                 <div class="controls">
				 <textarea rows="10" cols="100" class="form-control" 
                       placeholder="Mensaje" id="message" name="message" required
		       data-validation-required-message="escribe tu mensaje" minlength="5" 
                       data-validation-minlength-message="Min 5 characters" 
                        maxlength="999" style="resize:none"></textarea>
		</div>
               </div> 		 
	     <div id="success"><% if resposta <> "" then Response.Write "<b><< Mensaje enviado exitosamente!  >></b>" %>  </div> <!-- For success/fail messages -->
	    <button type="submit" class="btn btn-primary pull-right">Enviar</button><br />
          </form>
	</div>
      </div>
    </div>
	
	
 <!-- JS FILES -->
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script> 
 <script src="./js/bootstrap.min.js"></script>
 <script src="./js/jqBootstrapValidation.js"></script>
  <!--<script src="./js/contact_me.js"></script> -->

  </body>
</html>