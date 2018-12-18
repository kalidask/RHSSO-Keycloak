<%@ page language="java" contentType="text/html; charset=UTF-8"
 pageEncoding="UTF-8"%>
    <jsp:useBean id="controller" class="org.o7planning.tutorial.keycloak.Controller" scope="request"/>
 
<!DOCTYPE html>
<html>
 <head>
    <meta charset="UTF-8">
    <title>User Info</title>
 </head>
 <body>
 
    <jsp:include page="_header.jsp"></jsp:include>
    <jsp:include page="_menu1.jsp"></jsp:include>
 
    <h3>Hello: <%=request.getUserPrincipal().getName()%></h3>
 
    User Name: <b><%=request.getUserPrincipal().getName()%></b>
    <br />
 
    <jsp:include page="_footer.jsp"></jsp:include>
 
 </body>
</html>