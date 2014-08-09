# Examples for UnitySteer

This repository will contain a set of UnitySteer examples.  It’s just been cleaned.

UnitySteer is a library for autonomous agents in Unity written and maintained by
[Ricardo J. Méndez](https://github.com/ricardojmendez). Pull requests
are welcome.

# A word on methodology

Since these are tutorial examples, I expect I’ll just run development straight off master.  The UnitySteer repository does follow git flow, so expect this tutorial repository will be a work-in-progress and might at any given point reference a LibNoise development branch.

# Checking out the repository

It includes the UnitySteer Github repository as a submodule.   If you have just cloned the project and find missing behaviors, make sure that:

* You actually have some files inside the Assets/LibNoise folder;
* You have run _git submodule update_ to check out the latest referenced version;

Or you could use an application like [SourceTree](http://www.sourcetreeapp.com/) which handles the submodule semantics for you.

# Current examples

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

# License

UnitySteer is released under the
[MIT license](http://opensource.org/licenses/MIT). See License.txt.

# Other third-party components

Includes [GoKit](https://github.com/prime31/GoKit), which has its own license. See [GoKit's repository](https://github.com/prime31/GoKit) for details.

Includes some textures from Unity’s standard examples.