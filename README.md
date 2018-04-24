# CrossbowVR (AKA STORM THE DOOR!)
Team Project for Gesture Based UI Developement Due April 9th 2018,  by Karle Sleith (FourLeaf Interactive) and Albert Rando Jimenez (Dullahan Studio).

Download the latest release [HERE](https://github.com/karlesleith/CrossbowVR/blob/master/releases/CrossbowVR%201.0.0.apk) !

![Screenshot](https://github.com/karlesleith/CrossbowVR/blob/master/ReadMeImages/ScreenShot1.PNG)

## Introduction 
In "Storm The Door", you are a lone infantry tasked to protect the village from a hoard of mischievous Goblins.

[![CrossbowVR](https://github.com/karlesleith/CrossbowVR/blob/master/ReadMeImages/YoutubeDemoImage.png)](https://www.youtube.com/watch?v=zAAsw9H6QTI)

### How To Play
This game is compatible with Android devices and intended to be played with a VR Viewer (Such as Google Cardboard). In order to interact with the game and menus the player will have to "look" around using their gaze to either select options in the menus or shoot at the devious goblins.

When the title screen loads, simply look at the "Play" button to start the game.
<br/>
When the game beings you find yourself on the Castle Walls, you are able to Teleport between towers by looking at the "Green Arrow" to fire at the pesky Goblin, just look at them!

![Screenshot](https://github.com/karlesleith/CrossbowVR/blob/master/ReadMeImages/ScreenShot2.PNG)

The Goal is to compete for the HighScore, So make sure you take out as many Goblins as you can before they destroy the gate, but don't worry, once you complete a round you get a nifty bonus to the Gates Health


## Development
During the process of development we learned how to use the Android SDK Google Cardboard VR packages for Unity. Scenearios have been design and built up from scratch. Low-poly terrain created using unity, krita and blender. Animations have been customized using mixamo. All scripts have been written from scratch and built around the cardboard sdk to maximize its capabilities. It is open for further development, so in case of future iterations we can add more scenarios and more complex score systems and leaderboards. With some effort the game can be ported to other platforms.

### Software Architecture

![Architecture](https://github.com/karlesleith/CrossbowVR/blob/master/ReadMeImages/Architecture.png)
<p align="center">
<img src="https://github.com/karlesleith/CrossbowVR/blob/master/ReadMeImages/Architecture.png" width="350">
</p>

The game uses a set of scripts that run on top of the Unity Engine. We have the following scripts:
* Game Loop Scripts:
    * GameLoopCtrl: Manages the game loop, setting the times of the events.
    * GateHealthCtrl: Manages the losing condition, which is the healt of the Gate.
    * Spawner: Script responsible of spwaning the goblins.
* Menu and UI:
    * MainMenu
    * TitleCamera
* Core Mechanics:
    * PlayerScript: Handles player actions, such as shoot bolts at enemies.
    * EnemyCtrl: Controlls Enemy Behaviour.
    * TeleporterCtrl: Manages player teleportation between towers.
    * BoltCtrl: Handles bolt displacement alon the raycast.
* Visual Effects:
    * EnemyAnimationCtrl: Plays enemy animations when required.

    ![diagram](https://github.com/karlesleith/CrossbowVR/blob/master/ReadMeImages/UmlDiagram.png)


## Conclusions & Recommendations

Developing a game always has a playful component. By doing something be love we have enjoyed this project thoroughly, and we polished it so the mechanichs are intuitive and well designed allowing users to engage quickly with the game loop. We further improved our knowledge on C#, and the usage of Unity's built-in AI by using Agents and Navigation Meshes. The google cardboard SDK can be tricky to use but once we got down to it we managed to fully implement it in our game to a successful extent. 


## Authors

* **Karle Sleith** - *Design and Development* - [karlesleith](https://github.com/karlesleith)
* **Albert Rando** - *Design and Development* - [rndmized](https://github.com/rndmized)

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/karlesleith/CrossbowVR/blob/master/LICENSE) file for details

## Tools

* [Visual Studio 2017](https://www.visualstudio.com/downloads/)
* [Unity Editor 2017](https://unity3d.com/unity/editor)
* [Android SDK's](https://developer.android.com/studio/index.html)
* [Google Cardboard SDK](https://vr.google.com/cardboard/)
* [Blender](https://www.blender.org/)
* [Krita](https://krita.org/en/)

## Acknowledgments and References

* Goblin Models : [polynext.meximus.com](http://polynext.meximus.com/)
* Low Poly Weapons: [SICS Production](https://www.facebook.com/SICSproduction/)
* Nature Starter Kit : [Shape Assets](https://www.assetstore.unity3d.com/en/#!/publisher/3292)
* [PostProcessing Stack](https://assetstore.unity.com/packages/essentials/post-processing-stack-83912)
* Texts : [TextMesh Pro](https://assetstore.unity.com/packages/essentials/beta-projects/textmesh-pro-84126)
* Animations: [Mixamo](https://www.mixamo.com/)
