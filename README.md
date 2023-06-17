### Update June 17th 2023: resuming my work here. Yey !
### !!!GAME IS NOT READY YET AND DOESN'T HAVE AN EXECUTABLE NEITHER!!!
- Personal project to study and have fun. 
- This project is totally inspired by Fable: The Lost Chapters (surface description about all game features in spanish: [Link](https://docs.google.com/document/d/1t4plu7HMYJZV1-eDG6YQ-mEuIuHNXUMcWRfZKBudyCk/edit?usp=sharing). Description made by me, so probably I am missing a few elements. 

# Progress
## Game Components ([link](https://github.com/camilohoyos16/RPG/tree/main/Assets/Scripts/GameComponents))
A lot of info and behavior work by Game Components. Each component has a unique ID and specific unity components and probably other Game Components.
## Actions ([link](https://github.com/camilohoyos16/RPG/tree/main/Assets/Scripts/Actions))
Now you can create an action for everything and attach them to almost any entity in the game. Each action needs to be declared with its own Game Components to define the behavior.
## Effects ([link](https://github.com/camilohoyos16/RPG/tree/main/Assets/Scripts/Effects))
This is all you have to interact with the environment in special ways. IDK how to define them, so better give examples: 
>- Ugly sword which just make damage. Has just 1 effect called "SimpleDamageEffect" (kind of) and just deal damage to the target.
>- Super electric and burn sword (also simple damage): Has 3 effects: 1 for the simple damage, 1 for the electric effect and 1 for the burn damage.
- Active Effects: everything which will interact with the target directly and inmediatly. This can add passive effects. 
>- Simple damage: make damage directly.
>- Damage over time applier: a lot of abilities can implement this one, like poison, burn, electric, etc.  This will remain inside target making damage directly. 
- Passive Effects: everything which modify the damage received.
>- Vulnerability to burn: everytime burn effect is applied this will take the damage value and apply a formula over it and  return the final damage value.(value * 2)
## Entities controller ([link](https://github.com/camilohoyos16/RPG/blob/main/Assets/Scripts/Entities/EntitiesController.cs))
This has a reference to all the entities in the game, having a player implementation like this: Enity->character->controller character->player.
The interact action work through this controller checking all the characters and all the entities around, everytime a character goes inside of entity radius, this will add the interact action with the specific entity.
- **NOTE**: here, we need to implement a quadtree to improve performance, but if there is not a game yet, there is any performance to improve, right?
## Stats ([link](https://github.com/camilohoyos16/RPG/tree/main/Assets/Scripts/Stats))
- Class to replace a lot of variables inside the game, mainly stats (like its own name says) like health, mana, experience, etc.
- Created a dinamyc stats system to be used mainly on "StatsComponent". There a bunch of scriptable objects to define the name of all the stats you need to use and hold them inside a static dictionary so you just need to defined the id of the stats you need to get from StatsComponent. 
