# Basic examples

## Wandering

The most basic example: a single agent  wanders aimlessly around the scene while remained tethered between 15 units of (0, 0, 0).

Use this scene to experiment with maximum speed, maximum force, turn time and other AutonomousVehicle properties.

Behaviours used:

- AutonomousVehicle
- SteerForWander
- SteerForTether

## Go For Point

Now things are getting interesting. We have two wanderers on the scene, which will pick a point, move to it, and once they arrive just select a new one.    They do this by using an event handler on the steering behaviour, which triggers when the vehicle has reached its target.

See GoForPointController.cs

There’s two agents on the scene: the green one will approach its target at a constant speed, the yellow one will slow down as it reaches it.

Things to experiment with:

* AutonomousVehicle has two properties that control how quickly it accelerates or decelerates, Acceleration Rate and Deceleration Rate. What happens with the yellow agent if you double the deceleration rate? If you set it to 1?
* What happens with the yellow target if you increase the AutonomousVehicle’s Tick Length? Why?
* What happens if the Turn Time is too high and the target point really close?

Behaviours used:

- AutonomousVehicle
- SteerForPoint

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

