Project Members: Tamanna Saini, Alex Summers

Contributions:

Alex: Did 1/3 of tutorial, linear interp, dot, and particle effect.

Tamanna: Did 2/3 of the tutorial. 

Linear Interpolation: We lerperd where the gargoyles vision to be more inline
to where it is actually looking in current time, so each gargoyles vision rotates
from -50 to 50 degrees on y-axis. This means the player can get caught from not only
the front but the sides, or a player can slip through at the right time when the gargoyle
is not looking. 

Dot Product: Have an arrow above the players head that points to the direction of the goal.
This is achieved by getting 2 dot products. The first is the vector from the player to the goal and 
Vector3.forward. The other dot product being vector from the player to the goal the other 
reference vector.right. Then using those dot product to calculate the angle between them and 
change the arrows transform to the calculated angle. We can then take the arctan2(x, z) (which considers the signs of the angles/dot prods)
to then get the angle to the goal and apply it to the arrow above the player.

Particle Effect: The Ghosts all have white partilces emitting behind them in a cone
shape. It makes it a little more spooky.

