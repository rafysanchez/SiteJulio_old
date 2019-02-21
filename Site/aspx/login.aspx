<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="Transporte Executivo" />
    <meta name="author" content="portalsoftwares ltda- sao paulo-brasil-11999235591" />
    <meta property='busca:title' content='Transporte Executivo' />
    <meta name="keywords" content="tranfer, Trasnporte Executivo,Chevrolet,Ford,especial,carros, Van,Limosine,Viagens,Vip, sedã, Ferrari, Azera, segurança, portalsoftwares " />
    <meta name="application-name" content="Globo.com" />


    <link href="../CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="css/interno.css" rel="stylesheet" />
    <title>Login</title>

</head>
<body>

    <div class="container">
        <div class="row">
            <div class="col-md-8 divCenter" style="border:1px solid">
                <form class="form-horizontal">
                    <fieldset>
                       
                        <!-- Form Name -->
                          <legend>Login / Acesso</legend>

                        <!-- Text input-->
                        <div class="form-group">
                            <label class="col-md-4 control-label" for="textinput">Usuario:</label>
                            <div class="col-md-4">
                                <input id="textinput" name="textinput" type="text" placeholder="user / usuario" class="form-control input-md">
                               
                            </div>
                        </div>

                        <!-- Text input-->
                        <div class="form-group">
                            <label class="col-md-4 control-label" for="textinput">Senha:</label>
                            <div class="col-md-4">
                                <input id="text1" name="textinput" type="text" placeholder="senha / pass" class="form-control input-md">
                               
                            </div>
                        </div>

                        <!-- Button -->
                        <div class="form-group">
                           
                            <div class="col-md-4">
                            <span>   <button id="singlebutton" name="singlebutton" class="btn btn-primary">Enviar</button></span>  
                            </div>
                        </div>

                    </fieldset>
                </form>

            </div>

        </div>
    </div>
</body>
</html>
