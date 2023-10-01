# PROGRESSION OF THE PROJECT
Daily logs of my progression on the project and contributions to it.

## DETAILED REPORT
NB: this report stars a few days later after the assignment was given, as I was having some issues with Visual Studio, Linux, reinstalling Windows, getting motivated...

!!! SKIP THIS PART IF YOU WANT TO GET TO THE ACTUAL PROJECT, THIS IS FOR INFORMATIVE PURPOSE AS I STARTED OVER FROM SCRATCH !!!
### 2023-09-22
It's important to note that for now I am following to the T a tutorial as I am having a harder time wrapping my mind around the game logic.

**On lunch break**
- I set up the project in Visual Studio, my final decision being a Tetris game
- Poked around WFA

**Evening after class**
#### Game Grid
The first step was to create a game grid for the Tetris:
- I defined a 2D array to represent it, with 20 rows and 10 columns
- Two additional rows are hidden at the top for block spawning
- The tiles are represented with values from 0 to 7, corresponding to a different color for the tiles

- The `GameGrid` class was created to manage the game grid, it includes properties for the number of rows and columns, as well as an indexer to access grid elements.
- Methods to check boundaries, to check if a cell is empty, and to determine a row state (empty or full) were implemented, as well as methods to clear full rows and shift row downs.

#### Block Representation
There is seven different blocks in Tetris. Each of them have four rotation states, so a system to store their tile positions within a bounding grid was designed.
So for the `Block` class I needed to store its rotation states, tile positions, and current positionn on the grid. They can rotate, move and reset to their initial state.
Specific block shapes and behaviours were defined in subclasses to specify tile positions, the starting offset, with an unique ID.

#### Block Queue
- The `BlockQueue` class was created to manage the upcoming blocks in the game. It includes an rray of the seven block types, a random object for selecting blocks, and a property to retrieve the next block in the queue.

#### Game State
- The `GameState` class includes properties for the current block, game grid, block queue, and the game over status. Essential methods such as checking if the curfrent block is in a legal position, handling block rotations and movements, and determining if the game was over.
- Functionalities to place a block on the grid, clear full rows and update the game accordingly to that were also added.

### 2023-09-24
- Commented over the whole code in order to try and understand more
- Tried to start setting up the UI, having a hard time understanding WFA!!!

!!! THE GOOD SPOT !!!
### 2023-09-27
#### Work on Basic Mechanics & Setting Up Environment
- Restarted the project by setting up the .gitignore.
- Successfully set up the PictureBox and established a link between an image and a tile position, providing a visual representation on the UI.
- Played around with the block matrix. Managed to test out block population, confirming its functionality.
- Shifted the DisplayBlock method to the Block class for better encapsulation and organization.
- Tweaked movement functionality: Enhanced movement controls by implementing move left and right functions.
- Addressed issues regarding the X and Y axis.
- Developed the game grid collision system to ensure that the blocks respond correctly to boundaries.

### 2023-09-29
#### Intensive Game Logic Development
- Made necessary modifications to the initial state of blocks to cater for their rotation.
- Implemented key Tetris functionalities such as rotations, timer-based downward movement, and block collisions.
- Worked on creating an effective loop for block generation and placement.
- Focused on the mechanics of row clearing, a core part of the Tetris game.
- Began testing and setting up a rudimentary 'game over' state for gameplay validation.

### 2023-09-30
#### Enhancing Gameplay & UI
- Advanced further with the game's scoring system.
- Worked on the implementation of the 'next block preview' to enhance gameplay experience.
- Added another layer of the scoring system and made notable progress in previewing the next block on the game interface.

### 2023-10-01
#### Polishing & Refinements
- Made UI improvements, updated scoring system, and UI tweaks to make the game more visually appealing.
- Added background music to improve the game's ambiance.
- Introduced the block swap feature, enhancing the game's strategic element.
- Code organization took precedence: Reorganized various sections of the code for clarity and maintenance.
- Ensured that the code was comprehensible with clean-up operations and commenting.
