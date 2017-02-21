**DEPLOYMENT OF TOUR SERVICE API AND TOUR DB IN DOCKER**


1. From your shell tool, go to your working folder (cloned issue#16) \trunk\docs.

2. Copy all source codes from trunk/src (https://github.com/trebugroop/UGroopWebApi/tree/Issue_3/trunk/src) then     	paste into your working folder "tour_api". This is supposed to be the latest code before pull request has 	been granted for issue#3.

3. Using your shell command prompt, install chocolatey 
   type : iwr https://chocolatey.org/install.ps1 -UseBasicParsing | iex

4. With your shell command, go to your working folder then type "docker-compose up"

5. Test Tour API in browser:
	a.) get API containerID type : docker ps
	b.) get IPAddress type : docker inspect --format '{{ .NetworkSettings.Networks.nat.IPAddress }}' <containerID>
	c.) paste in browser address bar : `<IPAddress>`:8000/swagger/ui/index

Note: Still on progress of completion of swagger API documentation for testing reference.
	

