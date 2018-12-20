package org.o7planning.simplewebapp.servlet;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;  
import javax.servlet.http.HttpServletRequest;  
import javax.servlet.http.HttpServletResponse;  
import javax.servlet.http.HttpSession;  

@SuppressWarnings("serial")
@WebServlet(urlPatterns = { "/logout" })
public class LogoutServlet extends HttpServlet {
	
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException
    {
        HttpSession session = request.getSession();
        if(session != null)
        {
            try
            {
            	
            	System.out.println("I am here to getting out");
                response.setHeader("Cache-Control","no-cache"); //Forces caches to obtain a new copy of the page from the origin server
                response.setHeader("Cache-Control","no-store"); //Directs caches not to store the page under any circumstance
                response.setDateHeader("Expires", 0); //Causes the proxy cache to see the page as "stale"
                response.setHeader("Pragma","no-cache"); //HTTP 1.0 backward compatibility
                session.setAttribute("admin_name",null);
                session.invalidate();
                //response.sendRedirect("/WEB-INF/views/loginView.jsp");
                RequestDispatcher dispatcher //
                = this.getServletContext().getRequestDispatcher("index.html?logout=true");
 
        dispatcher.forward(request, response);
            }
            catch(Exception e)
            {
                System.out.println(e.getMessage());
                System.out.println(e);
                e.printStackTrace();
            }

        }
        else
        {


        }
    }

}
