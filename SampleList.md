# Basic examples

# Advanced examples

## Obstacle Avoidance

A large flock of boids will move around a scene while at the same time avoiding scattered capsules, which are treated as spherical obstacles.  If there is a collision with an obstacle, the obstacle will be destroyed and the collision logged. The colliding vehicle will change color.

This is a great scene for experimenting with spherical obstacle avoidance settings and see if they cause more or less collisions and how they change the way voids act.  Some experiments to get you started:

- Increase the number of obstacles on the scene
- Increase or decrease the obstacle’s DetectableObject radius
- Increase the boid prefab’s maximum speed on their AutonomousVehicle
- Increase or decrease the boid prefab’s turn time on their AutonomousVehicle

Main steerings used:

- SteerForSphericalObstacleAvoidance
- SteerForNeighborGroup
- SteerForSeparation
- SteerForCohesion
- SteerForAlignment
- SteerForWander

## Playing Tag

A group of boids will flock around until one of them is designated at a prey.  When that happens, said boid will stop flocking and will start evading the others using SteerForEvasion, and adding some randomness via SteerForWander.  The rest of the behaviours will gradually turn into predators by activating their own pursuit behaviour.

Whichever predator captures the prey will grow slightly fatter and slower.

Main steerings used:

- SteerForNeighborGroup
- SteerForSeparation
- SteerForCohesion
- SteerForAlignment
- SteerForPursuit
- SteerForEvasion
- SteerForWander

There is one main scene, and several demonstrating planar flocking by constraining one axis at a time.

See TagPlayer.cs for the controlling behaviour.

