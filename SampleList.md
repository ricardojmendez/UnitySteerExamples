# General notes

* I recommend going through the examples in the described order, as some of the proposed experiments and questions assume a degree of familiarity with other the previous ones.
* These are not meant only as demo scenes, but as a sandbox for you to experiment with the behaviors and learn the ins and outs of how UnitySteer agents are composed.  Make sure you at the very least follow the experimentation notes before pressing on.
* Most of these examples will use SteerForTether to ensure that the agent does not wander off too far from the center of the scene.  That’s its sole reason for existing.

# Basic examples

## Wandering

The most basic example: a single agent  wanders aimlessly around the scene while remained tethered between 15 units of (0, 0, 0).

Use this scene to experiment with maximum speed, maximum force, turn time and other AutonomousVehicle properties.

Behaviors used:

- AutonomousVehicle
- SteerForWander
- SteerForTether

## Go For Point

Now things are getting interesting. We have two wanderers on the scene, which will pick a point, move to it, and once they arrive just select a new one.    They do this by using an event handler on the steering behavior, which triggers when the vehicle has reached its target.

See GoForPointController.cs

There’s two agents on the scene: the green one will approach its target at a constant speed, the yellow one will slow down as it reaches it.

Things to experiment with:

* AutonomousVehicle has two properties that control how quickly it accelerates or decelerates, Acceleration Rate and Deceleration Rate. What happens with the yellow agent if you double the deceleration rate? If you set it to 1?
* What happens with the yellow target if you increase the AutonomousVehicle’s Tick Length? Why?
* What happens if the Turn Time is too high and the target point really close?

Behaviors used:

- AutonomousVehicle
- SteerForPoint

## Neighbor examples

The neighbour examples are a set of scenes meant to demonstrate how the various SteerForNeighbor behaviors interact with each other. I suggest you review them in the following order.

### Neighbors-Alignment

Instantiates a set of agents whose main behavior is to steer for alignment.  They’ll be created within 10 units of the origin.  Run the scene.

Things to experiment with:

* What happens when you play it? Are all agents moving or do some remain static? Why? (review SteerForAlignment)
* If some agents do remain static, when do they start moving again?
* How is the behavior affected if you change the Angle value on the prefab’s SteerForNeighborGroup?  What about the Min/Max Radius properties?
* There’s a SteerForForward behavior on the prefab.  What happens if you enable the behavior and then play the scene?  
* What happens if you then increase the weight of SteerForForward?
* What happens if you decrease the weight of SteerForNeighborGroup?

### Neighbors-Separation

Instantiates a set of agents whose main behavior is to stay away from each other. Run the scene after you’ve gone through te Neighbors-Alignment experiments.

Things to experiment with:

* What happens when an agent doesn’t have any others within its radius detection radius? Why?
* What happens if you alter the comfort distance?
* There’s a Draw Neighbors property on SteerForNeighborGroup. Enable it and experiment with the behavior settings. How do they change which agents the others react to?
* Change the Max Queue Processed from AutonomousVehicle on the  Neighbors-Separation prefab to a much lower value, such as 20.  Run the scene and check what happens with the neighbour detection trace lines.  Why is that?

### Neighbors-Cohesion

Instantiates a set of agents whose main behavior is to stay close to their detected neighbours. Run the scene after you’ve gone through te Neighbors-Alignment and Neighbors-Separation experiments.

Things to experiment with:

* What’s the general agent behavior? 
* What happens if you increase the SteerForCohesion behavior’s comfort distance? What happens if you decrease it?
* Does the behavior change if you change the SteerForNeighborGroup angle property from 45 to 90? How about 120?

### Combination examples

There’s two more scenes on the repository, combining Alignment with Cohesion and Alignment with separation. 

Some experiment notes: 

* How do they differ from the scenes where only one of the behaviors is used?
* Steering behaviors have a weight.  Play around with these values and see how the behavior changes. For starters, give a very high value to Alignment and very low to Separation, or very high to Separation and very low to Alignment.
* Can you create an agent which mixes Separation and Cohesion? How does it act?
* What happens if you mix all three? Any preferred combination of properties?

## PathFollowing

This scene contains an agent which will obtain a path from a series of transforms, then follow it to the end. If you select the agent while the scene is running, you’ll be able to see the path on the gizmo display.  See PathFollowingController for implementation details.

Some experiment notes:

* If you increase SteerForPathSimplified’s prediction time, the agent will appear to cut corners. Why is that?
* The weight of SteerForPathSimplified is 10, but the vehicle still moves at a constant speed of 5.  Why?
* What happens if you move a path’s points while the agent is already following it?
* How would you implement a path looping behavior?  How about reversing the path?
* AutonomousVehicle has a property labeled “Allowed Movement Axis”. All three axis are checked by default. What happens if you uncheck one of them while the agent is following the path?
* What happens with the path following precision if you increase AutonomousVehicle’s Tick Length or Turn Time?
* What happens with the path’s sharp corners if you increase the agent’s maximum speed?

Finally, a question: this agent does not have some Unity components that the neighbour example agents had, such as a collider or rigid body - why?

## PathFollowing - With Spline

A variant of the previous scene, it contains two path followers: one follows the standard Vector3Pathway, and the other one a SplinePathway.

* How is the behavior different between both?
* Why?
* What happens if you increase or lower the prediction time in both?


# Intermediate examples

You will notice that descriptions and suggested experiment notes are starting to get a bit more vague - by this point users are expected to have gone through the previous examples and to have more familiarity with the library, as well as knowing where to find answers themselves.

## Pursuit / Evasion #1

This scene contains two agents: an evader and a pursuer. When the pursuer gets close enough, the evader will start escaping; otherwise it will stay in place.

Some experiment notes:

* What happens if you decrease the SteerForEvasion’s Safety Distance?
* What happens if you increase or decrease either SteerForEvasion’s or SteerForPursuit’s Prediction Time?
* The pursuer doesn’t always aim for its quarry’s current position. Why?
* SteerForPursuit’s weight is double that of SteerForEvasion’s, yet the pursuer is unlikely to catch up to its quarry. Why?

## Pursuit / Evasion #2

We now encounter our first planar agent example: this scene is exactly the same set up as the last one, down to the values on the agents, but both the pursuer and the evader are configured to only move on two axis - see their AutonomousVehicle’s Allowed Movement Axis setting.

Some experiment notes:

* On this example it is a lot easier for the pursuer to catch up to the evader, even though it still has a lower maximum speed. Why?
* What happens to their interaction if you increase SteerforEvasion’s Safety Distance?
* What happens if you disable movement on yet one more axe?

## Pursuit vs. Follow

A simple scene contrasting the Follow behavior with the Pursuit one.

Some learning notes:

* Which behavior is simpler? Why?
* Why does the Follow behavior uses a transform as its target instead of a vehicle?
* What happens if you disable the pursuer?

# Advanced examples

## Obstacle Avoidance

A large flock of boids will move around a scene while at the same time avoiding scattered capsules, which are treated as spherical obstacles.  If there is a collision with an obstacle, the obstacle will be destroyed and the collision logged. The colliding vehicle will change color.

This is a great scene for experimenting with spherical obstacle avoidance settings and see if they cause more or less collisions and how they change the way voids act.  Some experiments to get you started:

* Increase the number of obstacles on the scene
* Increase or decrease the obstacle’s DetectableObject radius
* Increase the boid prefab’s maximum speed on their AutonomousVehicle
* Increase or decrease the boid prefab’s turn time on their AutonomousVehicle

Main steerings used:

- SteerForSphericalObstacleAvoidance
- SteerForNeighborGroup
- SteerForSeparation
- SteerForCohesion
- SteerForAlignment
- SteerForWander

## Playing Tag

A group of boids will flock around until one of them is designated at a prey.  When that happens, said boid will stop flocking and will start evading the others using SteerForEvasion, and adding some randomness via SteerForWander.  The rest of the behaviors will gradually turn into predators by activating their own pursuit behavior.

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

Learning notes:

* The SteerForNeighbors behaviors (Separation, Cohesion, Alignment) have parameters for a Min/Max Range where they apply.  How does the flocking behavior change if you alter those ranges?
* Why is there a SteerForWander behavior? What happens if you disable it?
* SteerForEvasion will attempt to avoid only the nearest pursuer.  How would you change it so that it takes into account all known pursuers?

See TagPlayer.cs for the controlling behavior.

## Playing Tag - With Obstacles

All together now… it combines the previous tag-playing example with spherical obstacle avoidance, and acts as a test bed for balancing out the strengths between behaviors.

Try running both the PlayingTag and PlayingTag-WithObstacles scenes in parallel. 

* Are the agent’s behaviors different?
* What happens to the flocks near obstacles?
* Is the evasion behavior different because of the presence of the SteerForSphericalObstacles behavior?
