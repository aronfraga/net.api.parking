# API - Parking System 

<p align="center">
    <img src="https://skillicons.dev/icons?i=git,cs,dotnet,azure,visualstudio" />
</p>

🌎 Deploy -  

 - I will have it deployed soon. 🙂

 ⚒️ Installation - for run in local

 - You need to have SQL Server 2019
 - Create a database with next name "parkingapi"
 - Go to "appsettings.json" and update the connection string 👇
    "Server=.\\SQLExpress;Database=parkingapi;TrustServerCertificate=True;Trusted_Connection=True;"
        remember that "\\SQLExpress" is the instance if you instance has a other name you need to change it.

▶️ Usage 

 - Open Visual Studio and Start it.
 - or in your terminal run ---> dotnet run 

📍 Endpoints
````
Account { GET, POST, PUT, DELETE }
    - get - /api/account - get all account registered.
    - get - /api/account/id - you need put an id by params and this endpoint will return the specific account.
    - post - /api/account - create a new account, send by body the next specific json.
        {
          "email": "Pedrolopez@gmail.com", 
          "password": "Perro456",
          "firstName": "Pedro",
          "lastName": "Lopez",
          "vehicles": [ 
                        {"plate": "AF123WR"},
		                    {"plate": "AE944XS"} 
                      ]
}
    - update - /api/account/id - update a specific account with by body is the same json that get for create one but you need to add "id" for be updated.
    - delete - /api/account/id - delete a specific account with "id" by params, the action will do a logical delete. 
````
````
Spot { GET, POST, PUT }
    - post - /api/spot - create the garage size, if you have a garage with 20 spot to park put 20.
    - get - /api/spot - get all spot status
    - put - /api/spot - update spot status on your garage, this should not be controlled on your own. 
                        The idea is that when a reservation is made it changes to not available or available when the place is released.
      {
	      "id" : 1,   ------> garage id
	      "status" : true --> garage status true is available and false is not available
      }

````

🧗🏽‍♂️ Contributing

 - Just me Aaron Fraga :bowtie:

🔖 License

 - It's free :smiley: :smiley:
