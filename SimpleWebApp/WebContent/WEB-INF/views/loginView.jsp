<%@ page language="java" contentType="text/html; charset=UTF-8"
   pageEncoding="UTF-8"%>
  <%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
   <head>
   <link rel="stylesheet" type="text/css" href="styles.css"/>
   
      <meta charset="UTF-8">
      <title>Login</title>
      <script src='https://www.google.com/recaptcha/api.js?hl=en'></script>
   </head>
   <jsp:useBean id="controller" class="org.o7planning.tutorial.keycloak.Controller" scope="request"/>
       <c:set var="idToken" value="<%=controller.getIDToken(request)%>"/>
   
   
   <%
        String user_id = "";


        String authId = " " ;

                user_id = request.getUserPrincipal().getName();
                System.out.println("userid is:----------"+user_id);
            try {
                authId = user_id ;
            } catch (Exception ee) {
                authId = "No user";
            }
            
            
            %>
   <body>
    
      <jsp:include page="_header.jsp"></jsp:include>
    
 
      
<!--      <p style="color: red;">${errorString}</p> -->
 
 
      <form method="POST" action="${pageContext.request.contextPath}/login">
     
       <%
      if (authId != null && !authId.isEmpty()) {
      %>
      <input type="hidden" id="userName" name="userName" value= "<%=authId%>" />
      <input type="hidden" id="password" name="password" value= "tom001" />
      <input type="hidden" id="rememberMe" name="rememberMe" value= "Y" />
      
      <%
      } else {
      %>
      <h3>Login Page</h3>
        <jsp:include page="_menu.jsp"></jsp:include>
         <table border="0">
            <tr>
               <td>User Name</td>
               <td><input type="text" name="userName" value= "${user.userName}" /> </td>
            </tr>
            <tr>
               <td>Password</td>
               <td><input type="text" name="password" value= "${user.password}" /> </td>
            </tr>
            <tr>
               <td>Remember me</td>
               <td><input type="checkbox" name="rememberMe" value= "Y" /> </td>
            </tr>
            </table>
              <div class="g-recaptcha"
          data-sitekey="6LdKbHwUAAAAAJEsfpVc6houLaTKsl5fPCX26dMN"></div>
          
                  <%
      }         
                  %>
               
    <br/>
    <br/>
    
                 <div class="content">
                 
                 Hello <b>${idToken.preferredUsername}!</b>
                </div>     
    <div class="menu">             
                           <button name="submit" type="submit" >Continue to Proceed</button>
                 
                  
                  </div>
          
         
      </form>
 
 <br/>
 <br/>
 <br/>
 <br/>
 <br/>
 <br/>
 <br/>
 <br/>
 <br/>
 <br/>
 <br/>
 
      <jsp:include page="_footer.jsp"></jsp:include>
      
   </body>
</html>