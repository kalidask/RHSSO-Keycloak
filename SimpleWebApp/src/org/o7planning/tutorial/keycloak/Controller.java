package org.o7planning.tutorial.keycloak;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;

/**
 * Controller simplifies access to the server environment from the JSP.
 *
 * @author Stan Silvert ssilvert@redhat.com (C) 2015 Red Hat Inc.
 */
public class Controller {

    public void handleLogout(HttpServletRequest req) throws ServletException {
        if (req.getParameter("logout") != null) {
            req.logout();
        }
    }

    public boolean isLoggedIn(HttpServletRequest req) {
        return req.getUserPrincipal() != null;
    }

}

