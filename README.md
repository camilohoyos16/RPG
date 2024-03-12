### Update February 27th 2024: resuming my work here. Yey !
### !!!GAME IS NOT READY YET AND DOESN'T HAVE AN EXECUTABLE NEITHER!!!
- Personal project to study and have fun. 
- This project is totally inspired by Fable: The Lost Chapters (surface description about all game features in spanish: [Link](https://docs.google.com/document/d/1t4plu7HMYJZV1-eDG6YQ-mEuIuHNXUMcWRfZKBudyCk/edit?usp=sharing). Description made by me, so probably I am missing a few elements. 

# Progress
## Game Components ([link](https://github.com/camilohoyos16/RPG/tree/main/Assets/Scripts/GameComponents))
A lot of info and behavior work by Game Components. Each component has a unique ID and specific unity components and probably other Game Components.
## Actions ([link](https://github.com/camilohoyos16/RPG/tree/main/Assets/Scripts/Actions))
Action needs to be declared with its own Game Components to define the behavior. Actions are managed by 2 lists, 1 for the adquired actions and 1 for the available actions that is constantly update to allow or restrict player in certain occassions.
Actions are suposed to be used by any entity not just player. In that order there is an special class called "InputAction" that wraps up, dynamically, when an action is added to the player.
List of Actions:
- Attack Distance.
- Attack Melee.
- Generic Interaction.
- Jump.
- Move
- Open Inventory.
- Use Item.
- Wield Weapons.
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
Stats are being used almost everywhere, in player, in entities, in object, in effects and so on. Stat has a base value, a list of modifiers and a current value, which is calculated by a formula applying modifiers over the base value
Stats works in paired with StatsComponent which is in charged to hold all the stats of its owner. No matter if it's a chair, if the chair has "health", there sould be a StatsComponent attached to it.
