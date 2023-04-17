

Linear Interpolation: We lerperd where the gargoyles vision to be more inline
to where it is actually looking in current time, so each gargoyles vision rotates
from -50 to 50 degrees on y-axis and this means the player can get caught from not only
the front but the sides.

Dot Product: Have an arrow above the players head that points to the direction of the goal.
This is achieved by getting the dot product of the vector from the player to the goal and 
Vector3.forward. Then using that dot product to calculate the angle between them and 
change the arrows transform to the calculated angle. 