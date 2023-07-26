# computer-graphics-lab

Student: Sameer Najjar 

Project: 3D Powder Game.

Project directed by: Dr. Roi Poranne

Project Playlist:
https://www.youtube.com/playlist?list=PLOvCmpy3lU4yshcjsMLpbFAtVgZafQdbi

# week 1
    learn unity basics and  implemnt the player movment , jumping , simple ablity
	to interact , simple shooting method (in total 8+ hours of work ).
# week 2
    improve and fix bugs in the gun and shooting and make it more usable for extra guns in the future
	, improve the interact class and the interact layer in addition to new UI for the interact
	that pop up when the player is close to an 
    interactable object that shows the interact button and what it does . (in total 7 hours of work )
# week 3 
    work on the gun class , add muzzle flash , bullet trail , bullet hit effect , fix the raycast 
	fix the fireRate problem and make the gun more realistic by adding bullet spread for the gun  
	(in total 8 hours of work ).
	video of the current progress:
https://youtu.be/AiwKF44i9Uk
# week 4
    holidays  
# week 5
    create a basic enemy ai that move randomly aroud his given place , if he detect the play ,
	follow him and if the player is in range shoot him if the player is out of range go back the
	original and move randomly to find the player .
	(in total 6 hours of work ).
# week 6
    start to work on the powder game part using a system like SPH which was very slow and didnt work
	in the end so I deleted everything and decided to start over next week with a grid-based system.
	(in total 8 hours of work).
# week 7
    create the grid-based system using a 3d array , implement the camera movement for the grid word and  
	create a simple falling sand that fall from the sky and implement a sand behavior that contorl the  
	sand falling and movment logic , currently this behavior isnt perfect and some improvement.
	(in total 10 hours of work ).
	video of the current progress:
https://youtu.be/oLZWX5oUBW8
# week 8
 - Fix the sand movment 
 - improve and increase the size of the game grid 
 - create a gui to chose the elements and to clear the grid 
 - add 3 new elemnt :
    - water
    - snow
    - lava 
 - the elemnt interact with each other in this way :
    - snow melt after 5 second and become water
  	- lava evaporation the water then disappear 
	- lava melt the snow immediately then disappear 
	- water flow over the sand 
 - over all about 7 hours of work 
 - video of the current progress:
    - https://youtu.be/wh65bEyY1gs
# week 9
    no progress this week due to preparing for the seminar in computer graphics and HWs in other courses
# week 10
  - add 3 new elemnt :
    - stone
    - acid
    - smoke 
  - the elemnt interact with each other in this way :
    - acid melt melt every other elemnt and disappear after 10 seconds
    - stone is a solid elemnt that doest interact with other elemnt 
    - smoke appears when melting elemnts in interacts like lava and water , acid with other elemnt .
  - over all about 8 hours of work 
# week 11
    no progress this week due to final exams
# week 12
  - fix bugs and improve the elemnts interacting with each other 
  - add 3 new elemnt :
    - fire
    - oil
    - cloud 
  - the elemnt interact with each other in this way :
    - fire:
      - burn elemnts like oil and acid  and convert it to fire
      - melt snow 
      - water extinguished the fire
      - fire disappear after 10 seconds 
    - oil flow over water and can ignite by fire .
    - clouds appers after the evaporation of water and after 10 seconds it will rain water and disappear  .
  - over all about 6 hours of work 
fix some interactrs and program speed 
# week 13
  - work on the gui of the game :
    - create the game main menu
	- create the pause menu
	- improve and change the game gui
  - add a new feature that allow the user to change the grid spawn size :
    - 1*1 
	- 3*3
  - over all about 8 hours of work 
# week 14
  - no progress this week, final exams.
#week 15 
  - add the Final two elements
     - salt:
        - Dissolves in water 
        - convert the water to salty water and if this water gets evaporation the salt will appear again.
        - act like sand and snow in  term of movment 
	 - wood:
           - flow over water
           - can get burned by lava and fire 
  - fix a bug that caused the elemnts to spawn out of the grid index and crash the game
  - improve the elements interactions and fix some bugs (there are more and harder bugs that i still need to fix)
  - improve the game stability and performance 
  - some changes in the elemnts materials 
  - fix a bug that makes all fluids apple to move throw walls
  - over all about 8 hours of work 
#week 16 
  - fix a bug in sand and water 
  - fix a bug when wood is under water they move to the same cube
  - fix a bug with lava and salty water create infinity water 
  - fix a bug in the interact between oil and water
  - fix other bugs with elemnts interacts
  - fix a bug that allow to elemnts to enter the same cell in the grid 
  - fix a bug that cause a crash and freeze when oil interact with water and fire in the same time .
  - make the grid smaller to improve pefomnce (also it was way to big and hard to control)
  - make the buttons bigger and easier to click
  - over all about 8 hours of work 
#week 17
  - fix build errors 
  - adjust the preapre the project to the finale build 
  - fix problems with canvas 
  - fix some bugs in the elemnts and the gui 
  - build and finish the project 
  




