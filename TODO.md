# Features

- Different actions take different time to complete.
- Player can cancel currently developing Actions.
- Sim moves to points instead of teleporting.
- Display Needs.
- Add different rates of increment of Needs depending of the specific Need.
- Place furniture.
- Move furniture.
- Build.
- Different Furnitures affect different to the Needs based on their stats.
- Add free will. [Resource](https://www.youtube.com/watch?v=9gf2MT-IOsg).
- Sims can themselves cancel Actions (based on mood, inability to perform, etc.).

- Add the rest of Needs.
- Add the rest of Actions.
- Make laying to restore Comfort.
- Adequate Needs increment values of Furnitures to the real ones:
    - Ranges from 1 to 10.
    - Also, Needs values goes from -100 to 100.

 
# Refactors

- Create a "gauge" for ints that are clamped between two values.
- Make Sim.Perform(Action) private. Sim should encapsulate which action it must perform, taking into account the Action Queue.