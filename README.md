# Flappy Fish
Thei game is made for Mobile Applications Development 3 at GMIT 4th year.

## Game Play
The game is a spin off from Flappy Bird. The gameplay is simple. When it starst the player has to go through between two sea weeds which are placed vertically and comes towards the player. The player can swim upwards with the fish by pressing space on a computer or tapping the screen on a touch screen device(either pc, mobile, tablet etc.). Once the player hits the seaweed or sinks to the ground, the fish dies and the game finishes.
## Menus
The game has several menus:
* Main menu - the player can start a game or set the settings
* Settings menu- the player can turn off the sounds or change the username
* Pause menu - the player can puse the game play and sees this menu. The player can resume or give up the game
* End menu - this menu is visible when the game is finished. This leads to main menu.
## Difficulty
I did some reserach by giving the game to different people to play. By the reviews is was able to determine the fish's jumping velocity and and the speed of the game.

When the player reaches the every 10th seaweed, the game scrolling gets faster. When the player reaches the 10th speed level the game just keeps that speed until the fish dies.

## Technical details
The game was made in unity version 2018.2.18f1.

There is only one scene in the game. To change the different menus and the game play, canvases were used. I developed a custom canvas changer to activate a given canvas and deactive all the others.

The wish produces an event on collisions:
* The fish hit event when the fish dies
* Score hit event when the fish hits a score line. Each score line is behind a seaweed pair and it is invisible.

An event is published after every 10th score line to notify the scrolling items to speed up.

Every static string and setting is stored in `Const` file for convenience.

## Test
The game was given to a number of people to check if there are any bugs in the game or crashes.
* Test person one: _The fish jumps too much_
    * Action taken: The fish's jumping velocity has been reduced
* Test person two: _The fish s almost the same colour as the background_
    * Action taken: None. I do not want to change the fish's colour
* Test person three: _The fish disappears when a new game is started after the fish dies_
    * Action taken: _Repositioned the fish to be visible all the time_
* The other test people did not find any issues.

## Resources
[Fish](https://www.google.ie/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwijqOni_fvdAhUrsqQKHSkMDbMQjhx6BAgBEAM&url=https%3A%2F%2Fbr.vexels.com%2Fpng-svg%2Fprevisualizar%2F143215%2Fdesenhos-animados-roxos-dos-peixes&psig=AOvVaw20goE1hj6kjL6bUrNleuuU&ust=1539264620982581)

[Sounds](http://soundbible.com/tags-fish.html)
[Jump Sound](http://d2s0dwtr0maev1.cloudfront.net/animals/fish/fish_small_jump_06.mp3)