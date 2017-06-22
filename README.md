# Interactive-Pascal
Unity generated Pascal Numbers, featuring color coded numerical patterns and VR extension. This project is made in TreeHacks 2017.

## Authors (ordered by last name)
Shawn Hu - Wrote descriptions of the significance of the highlighted numbers of the Pascal's triangle based on the properties indicated (divisible by [2, 7], diagonals, etc)

Mari Liis Pedak - Suggested this awesome idea to work on, implemented raycasting and menu button movements for VR and programmed some of the logic behind switching between properties

Kyle Wong - Generated the Pascal's Triangle with text displayed as 3D text for a more immersive VR experience, programmed the highlighting mechanisms satisfying given mathematical properties and some of the logic behind switching between properties

## Technologies used
Unity + C# and Samsung Gear VR

## Instructions
1. Should the scripts be detached from the game objects when you download this repository, attach the scripts to the following game objects: 
CameraRotate and RayCaster attached to Main Camera
CreateColor attached to colors
DescChanger attached to DescText
TriangleGenerator attached to Triangle, with how ever many rows you want, and the Cube (from the Prefabs folder) as the Prefab. 

2. Use the following keys, with the following functionalities:

    **On a computer**

* `r` key to change remainder
* `t` key to change the modulus
* `y` key to switch between diagonals
* `WASD or arrow keys (up, left, down, right)` to rotate the camera up, left, down, right, respectively
* `z` key to zoom in
* `x` key to zoom out

  **On Samsung Gear VR**

* Just tap the button on the side of the VR to confirm a selection. Rotate the gear to rotate the camera. Look directly at one of the buttons (the buttons should slightly pop up), tap to "press" that button!