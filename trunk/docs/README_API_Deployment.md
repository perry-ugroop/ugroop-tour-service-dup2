**DEPLOYMENT OF TOUR SERVICE API AND TOUR DB IN DOCKER**

1. In your working folder,copy folder named "tour_api" and "tour_db".
2. Copy the "docker-compose.yml" in your working folder.
3. Copy all source codes from trunk/src into "tour_api" folder.
4. Using your shell command prompt, install chocolatey 
   type : iwr https://chocolatey.org/install.ps1 -UseBasicParsing | iex
5. With your shell command, go to your working folder then type "docker-compose up"
6. Test in browser 
	a.) get API containerID type : docker ps
	b.) get IPAddress type : docker inspect --format '{{ .NetworkSettings.Networks.nat.IPAddress }}' <containerID>
	c.) paste in browser address bar : `<IPAddress>`:8000
	

