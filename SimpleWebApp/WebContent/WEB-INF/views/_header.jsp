<%@ page language="java" contentType="text/html; charset=UTF-8"
  pageEncoding="UTF-8"%>
  
   <%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
 
    <jsp:useBean id="controller" class="org.o7planning.tutorial.keycloak.Controller" scope="request"/>
    
    <c:set var="idToken" value="<%=controller.getIDToken(request)%>"/>
<c:set var="tokenString" value="<%=controller.getTokenString(request)%>"/>
<c:set var="showToken" value="<%=controller.showToken(request)%>"/>


<div style="background: #fff; height: 55px; padding: 5px; " >
  <div style="float: left; padding: 15px; text-align: left;" >
     <b>My WebApp</b>
  </div>
 
  <div style="float: right; padding: 10px; text-align: right;">
 
     <!-- User store in session with attribute: loginedUser -->
     Hello <b>${idToken.preferredUsername}!</b>
   <br/>
    
 
  </div>
 
</div>