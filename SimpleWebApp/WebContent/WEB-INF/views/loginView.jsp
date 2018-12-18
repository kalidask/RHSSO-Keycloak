<%@ page language="java" contentType="text/html; charset=UTF-8"
   pageEncoding="UTF-8"%>
  <%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
   <head>
      <meta charset="UTF-8">
      <title>Login</title>
      <script src='https://www.google.com/recaptcha/api.js?hl=en'></script>
   </head>
   <jsp:useBean id="controller" class="org.o7planning.tutorial.keycloak.Controller" scope="request"/>
   
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
      <jsp:include page="_menu.jsp"></jsp:include>
 
      <h3>Login Page</h3>
      <p style="color: red;">${errorString}</p>
  <%
      if (authId != null && !authId.isEmpty()) {
      %>
 
      <form method="POST" action="${pageContext.request.contextPath}/login">
     
      
      <input type="hidden" id="userName" name="userName" value= "<%=authId%>" />
      <input type="hidden" id="password" name="password" value= "tom001" />
      <input type="hidden" id="rememberMe" name="rememberMe" value= "Y" />
      
      <%
      } else {
      %>
      
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
                  <input type="submit" value= "Submit" />
                  <a href="${pageContext.request.contextPath}/">Cancel</a>
                  <%
      }         
                  %>
         
      </form>
 
      <p style="color:blue;">User Name: tom, password: tom001 or jerry/jerry001</p>
 
      <jsp:include page="_footer.jsp"></jsp:include>
   </body>
</html>