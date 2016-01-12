# Examples for UnitySteer

This repository contains a series of examples for UnitySteer, a library for autonomous agents in Unity written and maintained by
[Ricardo J. Méndez](https://github.com/ricardojmendez). Pull requests are welcome.

This version requires Unity 5.  For the last version supporting Unity 4.x, see the [v.3 tag](https://github.com/ricardojmendez/UnitySteerExamples/tree/v3.0).

See [SampleList.md](SampleList.md) for a description of the current examples.

# A word on methodology

Since these are tutorial examples, I expect I’ll just run development straight off master.  The UnitySteer repository does follow git flow, so expect this tutorial repository will be a work-in-progress and might at any given point reference a UnitySteer development branch.

# Checking out the repository

It includes the UnitySteer Github repository as a submodule.   If you have just cloned the project and find missing behaviours, make sure that:

* You actually have some files inside the Assets/UnitySteer folder;
* You have run _git submodule update_ to check out the latest referenced version;

Or you could use an application like [SourceTree](http://www.sourcetreeapp.com/) which handles the submodule semantics for you.

# License

UnitySteer is released under the
[MIT license](http://opensource.org/licenses/MIT). See License.txt.

# Other third-party components

Includes [GoKit](https://github.com/prime31/GoKit), which has its own license. See [GoKit's repository](https://github.com/prime31/GoKit) for details.

Includes some textures from Unity’s standard examples.