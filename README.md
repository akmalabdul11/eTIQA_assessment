# Introduction 
This Web App is using .Net frame work. MVC. Main used to create user and view the user details. The user only register their self (@POST) Only admin has access 
to view list of user (@GET), update user(@PUT), delete user(@DELETE).

Please take a look at API folder for all the operation. (put, delete, post, get). 
I have sperate the API base on the function. Example AdminAPI for admin and FreelancerAPI for freelancer.

# Getting Started
1. Install VS code
2. Install MSSQL Express

# Build and Test
TODO: 
1. Clone the project.
2. Instal MSSQL inside VS code.
3. Connect the database. Follow step below.
    - server name put '.'. this is because we are sing local machine.
    - database name put 'db3000'.
    - select 'intergrated'
    - then click 'enable tursted server'
4. Run the appilcation as usual. 
5. Visit http://localhost:"YOURPORT"/ for freelancer signup.
6. After SignUp you can check the username by the MSSQL or http://localhost:YOUPORT/Admin/AdminView
    -Note: that the ui for adminview is not complete yet because its an option but the backend is completed. If you click F12. You can see the list of the freelancer. After clicking 'search'
    you can see the user that you wanted to search will be appear on console. 

7. Please refer to Image_evident file. It is list of screenshot from postman that the C# backend has been tested and working well. 
    
# View
I also have hosted the project on azure portal and using azure devops as the stagging process. 
You can visit this link https://etiqaassessment.azurewebsites.net
