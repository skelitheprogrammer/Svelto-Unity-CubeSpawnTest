# SveltoECS-Demo: Spawning cubes!

The goal of this demo is to learn what Svelto is, learn how to use it, and see if this framework is suitable for making games
without the headache

# Philosophy

Project has been built with couple things in mind:

- Check most of the Svelto features;
- Understand how work with Svelto;
- Create flexible project;
- Showcase capabilities of the framework;

I added one small thing to complicate the development of this demo. I created an imaginary designer who has 1 problem:
He is incompetent. He has no backbone. He's not sure of what he's asking for, and he might change his mind tomorrow.
With this
with that twist, my demo ended up taking an interesting route.

# Problem

The starting script for this demo is:
“You need to create a demo in which, on startup, 100 cubes will appear in the shape of a sphere and move from the sphere
normally
unrestricted.”

# Solution

> [!NOTE]
> Project still in "lazy" development. This means that I will upgrade it, when I will get time.

![100CubesAroundShereWithRandomSpeed.gif](Unity.Recordings%2F100CubesAroundShereWithRandomSpeed.gif)

Using svelto's recommendations and approaches, I ended up creating a MainCompositionRoot that solves all dependencies.
This project doesn't include any DI frameworks, that was my choice. Asteroids doesn't need DI, so this is a demo.

Entry-point for this demo is MainContext, which initializes MainCompositionRoot.
![MainContextShowcase.png](image%2FMainContextShowcase.png)

Each Module/Feature divided into own Abstraction Layer.

Logic only* exists inside Engines(so called Systems). Some of them exists in services.

# Structure

- Everything that should be drawn on screen should be treated as a "View" layer.
    - ECS manages visuals. There is no from engine sync (gameObjects creates entities).
- Personal Config System. Allows to create various combinations of entities in editor, using ScriptableObjects.
- Personal Player Loop integration. Using PlayerLoopExtender I integrated update flow inside Unity's Player Loop.

## View Layer

When the project starts, the composition root receives configuration data from the Context and acts on it.
The configuration data specifies which entities and how many should be spawned in the scene.

To manage view I introduced feature, prestented in [ECS.Rx](https://ecsrx.gitbook.io/project/plugins/view-plugin), but
in my own vision.

- Ecs should not know about what type of instance he should draw: GameObject/SBR/Graphics/GL.
- To get instance of a view I created `IViewHandler`, which handles how to get a view.
- To control sync entity with view I introduced `EntityInstanceManager`, which stores relations between Entity and View.
- For performance reason I introduced `IViewPool` and `IViewFactory`, which `IViewHandler` instance `CubeViewHandler`
  uses to get instances (what if one day I would need to have a ViewHandler which will not need a pool? Some single call
  instances..)

## Config System

When time goes on, designer wanted to change some things. He wanted to change entities move. Now he wanted to apply Sine
wave movement.
Config system allows to bridge the gap with how to spawn entities. With time I added various options, how to spawn an
entities.

![ConfigSystemInstance.png](image%2FConfigSystemInstance.png)

Each parameter can have different behaviours. If you need exactly 100 cubes, user have to select `Value Reference Int`
and pass value.
If you want in range, you select `Min Max Unity Random Range int`, which allows to randomly select number in predefined
range.

This system has its flaws, which I listed in Issues, but it solves my problem with configuration

## PlayerLoopExtender

Its personal, home project which extends and simplifies capabilities of Unity's Player
Loop. [See more](https://github.com/skelitheprogrammer/PlayerLoopExtender)

# Other Features

In the end I added Attribute Feature, which extends entity base behaviour. Due svelto nature of "No structural change on
entity in runtime" we can't change how entity act after it created. So, you have to assign all possible behaviour
preactivly.
And my designer wants to change cube's behaviour! He wants to destroy them after distance rach (tomorrow he wanted to
destroy them after time, and on the next day he wanted to let them revive after some time).
With that I created attributes. They allow user in config add those behaviours and their conditions.
![ConfigSystemAttributes.png](image%2FConfigSystemAttributes.png)

# Future
Check issues if you want to know what I want to improve in the future

