# Introduction 
This Web App is using .Net frame work. MVC. Main used to create user and view the user details. The user only register their self (@POST) Only admin has access 
to view list of user (@GET), update user(@PUT), delete user(@DELETE).

# Getting Started
1. Install VS code
2. Install MSSQL Express

# Build and Test
TODO: 
1. Clone the project.
2. Instal MSSQL.
3. Connect the database. Follow step below.
    - server name put '.'. this is because we are sing local machine.
    - database name put 'db3000'.
    - select 'intergrated'
    - then click 'enable tursted server'
4. Run the appilcation as usual. 
5. Visit http://localhost:5042/ for freelancer signup.
6. After SignUp you can check the username by the MSSQL or http://localhost:5042/Admin/AdminView
    -Note: that the ui for adnminview is not complete yet but the backend is completed. If you click F12. You can see the list of the freelancer. After clicking 'search'
    you can see the user that you wanted to search will be appear on console. 

7. Please refer to Image_evident file. It is list of screenshot from postman that the C# backend has been tested and working well. 
    
