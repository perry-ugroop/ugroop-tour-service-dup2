**DEPLOYMENT OF TOUR API AND TOUR DB IN DOCKER**


1. Clone the latest code 
   Fork -> https://github.com/trebugroop/UGroopWebApi
   Branch -> Issue_16

2. Create this folder structure on your local machine -> "C:/data/docker_volumes/tourdb/logs"
   The created directory will be use as host copy of logs during docker deployment.

3. Using your shell command prompt, install Chocolatey 
   type -> iwr https://chocolatey.org/install.ps1 -UseBasicParsing | iex

4. From your shell tool, go to your cloned folder\trunk\src. 

5. Build the images, type -> docker-compose up -d --build 

   Note: Wait 5 minutes to create the database after build complete

6. You may check if DB is already created by getting IP Address of TourDB
   
   a.) type -> docker inspect --format '{{ .NetworkSettings.Networks.nat.IPAddress }}' <tourdb_container_id> 
   b.) connect via sql management studio ; Login : sa  /  Password : Password1*

7. Check if API is running, type -> docker ps
   a.) If API is not running, type -> docker ps -a  ; get the <tourapi_container_id> 
   b.) Run the Tour API service, type -> docker start <tourapi_container_id>

8. Test the API via Swagger
	
   a.) Type in browser -> http://cnt_tour_api:8000/swagger/ui/index
   b.) Test Add_TourType -> http://cnt_tour_api:8000/swagger/ui/index#!/Tour/Tour_Add_TourType
   c.) Paste in parameter , then "Try it out!"
	
		{
		  "TourType_Insert" :
		  {
			"TourTypeName" : "Adventure via Teleportation"
		  }
		}
	
   d.) Test Add_Tour -> http://cnt_tour_api:8000/swagger/ui/index#!/Tour/Tour_Add_Tour
	
   e.) Paste in parameter , then "Try it out!"
	
	    {
			"Tour_Insert" :  {
				"AccountId" : "1",
				"OrgId" : "1",
				"TourTypeId" : "1",
				"TourName" : "AAA",
				"StartDate" : "2020-12-20 22:43:09.340",
				"EndDate" : "2020-12-30 22:43:09.340",
				"TourDescription" : "AAA",
				"DestinationCity" : "Mars City",
				"TargetNo" : "500",
				"Photo" : "AAA",
			}
		}
	

