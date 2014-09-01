# Examples for UnitySteer

This repository will contain a set of UnitySteer examples.  It’s just been cleaned.

UnitySteer is a library for autonomous agents in Unity written and maintained by
[Ricardo J. Méndez](https://github.com/ricardojmendez). Pull requests
are welcome.

See [SampleList.md](SampleList.md) for a description of the current examples.

# A word on methodology

Since these are tutorial examples, I expect I’ll just run development straight off master.  The UnitySteer repository does follow git flow, so expect this tutorial repository will be a work-in-progress and might at any given point reference a UnitySteer development branch.

# Checking out the repository

It includes the UnitySteer Github repository as a submodule.   If you have just cloned the project and find missing behaviours, make sure that:

* You actually have some files inside the Assets/UnitySteer folder;
* You have run _git submodule update_ to check out the latest referenced version;

Or you could use an application like [SourceTree](http://www.sourcetreeapp.com/) which handles the submodule semantics for you.

# Known issue on Unity 4.3.x

I’m developing and testing these examples on Unity 4.5 and 4.6.  Are you getting a NullReferenceException on 4.3.4?  [Read the comments on this post for a workaround](http://arges-systems.com/blog/2014/08/22/unitysteer-3-0-beta-2/).

# License

UnitySteer is released under the
[MIT license](http://opensource.org/licenses/MIT). See License.txt.

# Other third-party components

Includes [GoKit](https://github.com/prime31/GoKit), which has its own license. See [GoKit's repository](https://github.com/prime31/GoKit) for details.

Includes some textures from Unity’s standard examples.