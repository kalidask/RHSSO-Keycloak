# RHSSO-Keycloak

ASP.Net based MVC webapp 

1. Simplelogin

This is simple .Net based login web application which is integrated /secured under the RH-SSO / Keycloak.

2. bpost-aspnetcore-local-logins

It's another .Net based login web applicaiton

3. SimpleWebApp

This is simple login web application developed in JAVA to showcase integration with RH-SSO / Keycloak






Git push for submodules:
-----------------------------

1.  find . -name ".git*" --> in main / global directory
2.  rm -rf submodule/.git
3.  git rm --cached submodule
4.  git add -A
5.  git commit -m "msg"
6. git push -u origin master
