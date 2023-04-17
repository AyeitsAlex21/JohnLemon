Project Members: Tamanna Saini, Alex Summers

Contributions:

Linear Interpolation: We lerperd where the gargoyles vision to be more inline
to where it is actually looking in current time, so each gargoyles vision rotates
from -50 to 50 degrees on y-axis. This means the player can get caught from not only
the front but the sides, or a player can slip through at the right time when the gargoyle
is not looking. 

Dot Product: Have an arrow above the players head that points to the direction of the goal.
This is achieved by getting the dot product of the vector from the player to the goal and 
Vector3.forward. Then using that dot product to calculate the angle between them and 
change the arrows transform to the calculated angle. 

Particle Effect: The Ghosts all have white partilces emitting behind them in a cone
shape. It makes it a little more spooky.