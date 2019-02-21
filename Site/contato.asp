<%
Dim AspEmail, nomeRemetente, emailRemetente, nomeDestinatario, emaildestino, assunto, mensagem, servidor,resposta
if Request.Form("message") <> ""  then
	nomeDestinatario = "Julio Cesar"
	emaildestino = "juliocesarlemes@hotmail.com"
	nomeRemetente = Request.Form("name")
	emailRemetente = Request.Form("email")
	assunto = "Contato do Site"
	mensagem = Request.Form("message")	
	telefone = Request.Form("tel")
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
	AspEmail.Subject =  assunto
	AspEmail.IsHTML = True
	AspEmail.Body =  mensagem & " -- "  & telefone
	AspEmail.Send
	resposta = "ok"
	Response.Write "Mensagem enviada com sucesso!" 
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
 	<meta name="description" content="Transporte Executivo SP com segurança, tranfer, BLINDADOS, SP">
    <meta name="author" content="portalsoftwares ltda- sao paulo-brasil-11999235591">
    <meta property='busca:title' content='Transporte Executivo SP' />
   <meta name="keywords" content="Transporte Executivo SP, Carro de noivas,Carro para noivas,Transfer,Executivos,Placa para casamento,Motorista Particular,Viagens,
   Aluguel de carro para noivas,motorista para casamento,motorista,eventos, Transporte para executivos, Transporte,Executivo, Chevrolet,Ford, especial,carros, 
   Van, Limosine,Viagens,Vip, sedã, Ferrari, Azera, segurança, portalsoftwares, carro de aluguel, carro blindado, motorista, motorista executivo, 
   carro executivo, tranporte de executivos, aluguel de vans, locaçao de aans, locação carro blindado, aluguel carro blindado, aluguel blindado, 
   blindado com motorista, carro executivo, aluguel carro executivo, aluguel carro passeio, micro-onibus, microonibus, onibus, fretamento onibus, 
   eventos, onibus para eventos, vans para eventos,Aluguel de carros com motorista, Aluguel de carros com motorista SP, Executivo Transporte, 
   Motorista Executivo SP, Taxi Executivo, Taxi luxo SP, Transporte, Transporte Executivo SP, Transporte executivo, Traslado, Traslado SP, 
   Turismo, Turismo SP, transporte executivo, aluguel de vans, alugar van, empresa de vans, locadora de vans, carros executivos, van com motorista "/>
    
	<meta name="siteinfo" content="robots.txt" /> 
    <meta name="revisit-after" content="1 weeks" /> <
    <meta name="robots" content="index, follow" /> 
    <meta name="SKYPE_TOOLBAR" content="SKYPE_TOOLBAR_PARSER_COMPATIBLE" /> 
    <meta name="format-detection" content="telephone=no"> 
    <link rel="canonical" href="http://www.jcpvipexecutivo.com" /> 
    <link rel="index" title="Alugar carros para Transporte de Executivos | href="		   http://www.http://www.jcpvipexecutivo.com/" /> 
    <meta name="google-site-verification" content="TuE_dGrwSsw3gAZJhnRnCXkcjK09xHUHLP7CgjBmSQ0" />
    <meta name="application-name" content="www.jcpvipexecutivo.com"/>
	<link rel="alternate" href="http://www.jcpvipexecutivo.com" hreflang="pt-br" /> 

 
  <title>TRANSPORTE EXECUTIVO SP - TRANSPORTE VIP - BLINDADOS - JCPVIP</title>
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
                    <li ><a href="/index.html">Home</a></li>
                    <li><a href="servicos.html">Nossos Serviços</a></li>
                    <li ><a href="empresa.html">JCP - Empresa</a></li> 
                    <li class="active"><a href="#">Contato</a></li> 
                </ul>
                    

            </div>
        </div>
    </div>


</div> 


 <!-- Contacts -->
 <div id="contacts">
 <h1 style="text-align: center; color:white;">	TRANSPORTE EXECUTIVO EM SÃO PAULO </h1>
   <div class="row">	
     <!-- Alignment -->
	<div class="col-sm-offset-3 col-sm-6">
	   <!-- Form itself -->
          <form name="sentMessage" class="well" id="contactForm" method="post" action="" novalidate>
	       <legend>Contate-nos</legend>
		 <div class="control-group">
                    <div class="controls">
			<input type="text" class="form-control" 
			   	   placeholder="Nome Completo" id="name" name="name" required
			           data-validation-required-message="digite seu nome" />
			  <p class="help-block"></p>
		   </div>
	         </div> 
             
                    <div class="control-group">
                  <div class="controls">
			<input type="tel" class="form-control" placeholder="Telefone XX XXXXX XXXX" 
			   	            id="tel" name="tel" required
			   		   data-validation-required-message="Digite seu telefone com DDD" />
		<p class="help-block"></p></div>
	    </div> 
             	
                <div class="control-group">
                  <div class="controls">
			<input type="email" class="form-control" placeholder="Email" 
			   	            id="email" name="email" required
			   		   data-validation-required-message="Digite seu email" />
		<p class="help-block"></p></div>
	    </div> 
        
        
        	
			  
               <div class="control-group">
                 <div class="controls">
				 <textarea rows="10" cols="100" class="form-control" 
                       placeholder="Mensagem" id="message" name="message" required
		       data-validation-required-message="digite sua mensagem" minlength="5" 
                       data-validation-minlength-message="Min 5 characters" 
                        maxlength="999" style="resize:none"></textarea>
		</div>
               </div> 		 
	     <div id="success"><% if resposta <> "" then Response.Write "<b><< Mensagem enviada com sucesso!  >></b>" %>  </div> <!-- For success/fail messages -->
	    <button type="submit" class="btn btn-primary pull-right">Enviar</button><br />
          </form>
	</div>
      </div>
    </div>
	
<div class="clearfix"></div>	
 <!-- JS FILES -->
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script> 
 <script src="./js/bootstrap.min.js"></script>
 <script src="./js/jqBootstrapValidation.js"></script>
  <!--<script src="./js/contact_me.js"></script> -->
<footer style="margin-top:40px;">
<div class="container" style="text-align:center; color:#FFF; margin-top:50px;">
<a  href="/" style="font-size:16px; TEXT-ALIGN:CENTER">TRANSPORTE EXECUTIVO EM SÃO PAULO</a>
<H4>JULIO CESAR PAES LEME |   <span class="info">juliocesar@jcpvipexecutivo.com</span></h4>
<h4>Tel. 55 11 98148-4809 | 11 38624544 | Avenida Francisco Matarazzo,121 | Agua Branca, São Paulo -  SP - Brasil </H4>
<H4>CEP 05001-000 </H4>

</div>
  <h5 style="text-align:center; font-size:10px"> Site desenvolvido por Portalsoftwares ltda - 11 949678051 </h5>
</footer>
  </body>
</html>