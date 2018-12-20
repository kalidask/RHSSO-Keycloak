<%@page contentType="text/html" pageEncoding="ISO-8859-1" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>

<!DOCTYPE html>
<html>
  <head>
     <meta charset="UTF-8">
     <title>Simple Web Application</title>
  </head>
  
  <body>
  
   <jsp:useBean id="controller" class="org.o7planning.tutorial.keycloak.Controller" scope="request"/>
 <% controller.handleLogout(request); %>
  
     <h2>Simple Login Web Application </h2>
      
     <ul>
        <li><a href="home">Home</a></li>
        <li><a href="login">Login</a></li>
     </ul>
      
  </body>
</html>