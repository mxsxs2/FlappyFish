# Developer Diary

## Development stages
The developement started with receiving and reading through the design document.

E-mail client to receive more details about the game:
* You mentioned there are collectibles in the game which increases the players score. 
    * What are these collectibles?
    * How/Where do they appear?
* Where is the score presented.
* How does the score increase?
* Should this score be displayed when the user finishes the game?
* The bubbles are just part of the background, right?

Received answers:
* Yes, my idea for this was to make coins appear at random stages of the level. If the player collects a coin , it adds a point to they're score.
* The score can be displayed just above the center of the screen.
* The score increases as the player goes through each obstacle(similar to flappy bird).
* Yes the score should be displayed when the player finishes the game along with the restart option.
* Yes the bubbles are just part of the background.

Developed the main fetures of the game:
* Fish jumping and falling
* Fish boundaries
* Seaweed,seaweed spawner and scroller
* Score collection

Developed the main an pause menu.

Added dying feture to the fish when hits the ground or sinks to the bottom.

Added game over screen

Added social media button which is removed now.

Added settings menu along with sounds in the game.

Gave the game for a few people to play/test it.

Show the game to the client.

Fix bug with the fish disappearing on new game start.

Send screen shots of the game and the game to the client. In the same e-mail explained why I dropped the coin as collectible.

Start looking into unit tests.

Could not write unit tests as the GameObject is always null.

Did not receive feedback from client.

## Differences of the design document
The design document did not mention menu, increasing difficulty, details of the score system, sounds and settings. 
* I created a menu system. 
* Implemented the scrolling in a way it gets faster after every 10th seaweed to make the gameplay harder.
* Increased the score after every seaweed pair passed.
* Added jumping sound and a base music to the game

The application originally was meant to be delivered to UWP. I am unable to register to Microsoft store and my machine has a bug with UWP where the fish randomly falls. Unfortunatelly when the project is built to UWP it only builds a Visual Studio project. This project has to be used to publish in store or build locally. I believe this is not an appropriate form to present to the client threrefore I approached him to accept the final product for Android.

