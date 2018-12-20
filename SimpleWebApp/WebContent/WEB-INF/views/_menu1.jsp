<%@ page language="java" contentType="text/html; charset=UTF-8"
   pageEncoding="UTF-8"%>
       <link rel="stylesheet" type="text/css" href="styles.css"/>
    
<div style="padding: 5px;">
 <div class="content">
   <a href="${pageContext.request.contextPath}/" >Home</a>
   |
   <a href="${pageContext.request.contextPath}/userInfo">My Account Info</a>
   |
   <a href="${pageContext.request.contextPath}/index.jsp?logout=true">LogOut</a>
    </div>
</div> 