# Introduction
 
This Repository contains the sample code to fetch the JSON data in ASP .Net core web API and expose the endpoint API to consume in different framework.
 
# Prerequisites
.Net Core 2.2 SDK 2.2
 
# Steps to run the code
 
1)      Download the code form the GitHub
https://github.com/ShivuSK/DemoWebApi
 
2)      Open the Command Prompt and navigate the folder where project file is located
3)      Run the below command to build and execute the solution
	   * Command to build the solution
	        * Dotnet build
	   * Command to run the solution
	        * Dotnet run watch
 4) On successful build and run, open the browser and type the below URL
           http://localhost:5000/api/GetPetsOwners
           Expected json output is 
{"Cats":
	 [{"gender":"Male",
		  "names":["Garfield","Tom","Max","Jim"]
	  },
	  {"gender":"Female",
		 "names":["Garfield","Tabby","Simba"]
	  }
	 ]
}

# View the output in webpage
5)  Run the html file (GetPetOwners.html) which is available in the solution folder
    This HTML file consume the web API and display the results
   The expected output is

* Male
	* Garfield
	* Jim
	* Max
	* Tom

* Female
	* Garfield
	* Simba
	* Tabby
     
