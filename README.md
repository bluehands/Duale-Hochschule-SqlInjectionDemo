# SqlInjectionDemo
A simple app to show how SqlInjection works. 

## How to start
* Create a MS Sql Server Database. See **CreateDB.txt** or use **SqlInjectionDemo.dacpac**
* Don't forget to add soma data
* Open the solution and adjust the connection string
* Start the app

## Demo
Enter UserName and Password. The app just concat the sql string with the user input. DON'T DO THIS AT HOME. The resulting string is printed out for demonstration reason.

The sql is executed against the database with Command.ExecuteReader and the result is printed. Use the sample input from **SampleSQL.txt** 

Have fun.


