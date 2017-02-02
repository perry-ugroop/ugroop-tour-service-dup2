**DEPLOYMENT OF TOUR SERVICE API IN DOCKER**

1. Copy DockerFile from trunk/docs into your Docker working folder
2. Copy all source codes from trunk/src into your Docker working folder
3. Using your favorite shell tools, install chocolatey 
   type : iwr https://chocolatey.org/install.ps1 -UseBasicParsing | iex
4. Using shell, go to your working folder, type : docker build -t ugroop_api .   `(include the dot)`
5. Test in browser 
    
	a.) get containerID type : docker ps

	b.) get IPAddress type : docker inspect --format '{{ .NetworkSettings.Networks.nat.IPAddress }}' <containerID>

	c.) paste in browser address bar : `<IPAddress>`:8000
	
6. Sweets -> by chocolatey

