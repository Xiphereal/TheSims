# Features

## Must
- Display Needs.
- Sim moves to points instead of teleporting.
- Control camera.
- Add different rates of increment of Needs depending of the specific Need.
- Allow to control time.

## Should
- Place furniture.
- Move furniture.
- Build.
- Player can cancel currently developing Actions.
- Different Furnitures affect different to the Needs based on their stats.
- Free will. [Resource](https://www.youtube.com/watch?v=9gf2MT-IOsg).
- Sims can themselves cancel Actions (based on mood, inability to perform, etc.).

## Could
- Add the rest of Needs (Room, Fun & Social).
- Add the rest of Actions.
- Make laying to restore Comfort.
- Work.
- Buy & building cost simoleons.
- Adequate Needs increment values of Furnitures to the real ones:
    - Ranges from 1 to 10.
    - Also, Needs values goes from -100 to 100.
- Hours & days.

 ## Won't have
 - Sim & family creation.
 - Neighborhood.
 - Personality.
 - Work carreers.

# Refactors

- Create a "gauge" for ints that are clamped between two values.
- Make Sim.Perform(Action) private. Sim should encapsulate which action it must perform, taking into account the Action Queue.