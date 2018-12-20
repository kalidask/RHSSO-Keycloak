<%@ page language="java" contentType="text/html; charset=UTF-8"
 pageEncoding="UTF-8"%>
 <%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
 
    <link rel="stylesheet" type="text/css" href="styles.css"/>
 
 
    <jsp:useBean id="controller" class="org.o7planning.tutorial.keycloak.Controller" scope="request"/>
    
    <c:set var="idToken" value="<%=controller.getIDToken(request)%>"/>
<c:set var="tokenString" value="<%=controller.getTokenString(request)%>"/>
<c:set var="showToken" value="<%=controller.showToken(request)%>"/>
    
 
<!DOCTYPE html>
<html>
 <head>
    <meta charset="UTF-8">
    <title>User Info</title>
 </head>
 <body>
 
    <jsp:include page="_header.jsp"></jsp:include>
    <jsp:include page="_menu1.jsp"></jsp:include>
 <br/>
 <br/>
 <br/>
 
 <div class="content">
            <div id="profile-content" class="message">
 
    First Name: <b>${idToken.givenName}</b>
    <br/>
    Last Name: <b>${idToken.familyName}</b>
    <br/>    
    User Name: <b>${idToken.preferredUsername}</b>
    <br />
     Email Address: <b>${idToken.email}</b>
     <br/>
     
     
     </div>
     </div>
     
      <br/>
 <br/>
 <br/>
 <br/>
 <br/>
 <br/>
 
    <jsp:include page="_footer.jsp"></jsp:include>
 
 </body>
</html>