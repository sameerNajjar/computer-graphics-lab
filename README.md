# Computer graphics lab University of Haifa

Student: Sameer Najjar 

Project: 3D Powder Game.

Project directed by: Dr. Roi Poranne

Project Playlist:
  - https://www.youtube.com/playlist?list=PLOvCmpy3lU4yshcjsMLpbFAtVgZafQdbi
  
Download and Run:
  - download Game.zip from the repo unzip it and run 3D-Powder-Game.exe

About the game:
 - the game is inspired by 2d falling sand and powder games.
 - the main feature of the game and the hardest chalnge is that unlike other falling sand 
 and powder game the game is 3D not 2D
 - the game contains 12 elements:
    - sand:
	    - sand precipitates in water and oil 
		- fire and lava cant burn it 
		- only acid can destroy sand particles
	- water:
	    - water flows over solid particles like sand and stone
		- water evaporates when its near lava , fire, and acid and creates a cloud particle
		- water extinguishes fire and lava 
	- snow:
	    - snow melts after 5s automatically 
		- snow melts if it touches lava,fire and acid particles
		- when snow melts it creates a water particle 
		- snow particles move the same as sand particles 
	- lava:
	    - lava particles automatically disappear after 10 seconds
		- lava extinguishes when touching water 
		- lava can also burn acid and oil 
		- lava particles are fluids so their movement is similar to water 
	- Acid:
	    - lava particles automatically disappear after 10 seconds
		- acid particles can destroy every other particle
		- acid particles are fluids so they move similar to lava and water 
	- stone:
	    - stone is a solid particle 
		- it doesn't interact with any other particle 
		- only acid can interact with stone and destroy it 
	- smoke:
	    - smoke appears when lava,fire and acid burn any element 
		- smoke it fluid so its moves like other fluid (but in the sky)
		- smoke automatically disappears after 10s 
	- fire:
	    - the difference between fire and lava is that fire isn't a fluid like lava
		- since fire isn't a fluid its only spread when it can burn its neighbors
		- fire automatically disappears after 10s
	- oil:
	    - oil flow over water
		- oil can get burned and become fire when touching fire or lava
		- oil is fluid
	- cloud:
	    - cloud rains water after 5 seconds 
		- clouds disappear after 10 seconds
		- cloud is a fluid so its moves like smoke
		- clouds appear when evaporates water
	- salt :
	    - salt melts in water 
		- salt moves like sand and snow
		- when salt melts in water and that water evaporates salt appears again 
	- wood :
	    - wood is a solid element like stone
		- wood flow over water
		- fire and lava can burn wood 