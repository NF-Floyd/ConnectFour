# Connect Four AI Coding

Connect Four - AI Coding is a project for young/learning developers.
It shows with a graphical user interface how your code is making decisions in a game.
It's developed in C#.

## Description
This little project is intended for young C# programmers, who would like to learn a little bit about AI coding.

## How to use

1. Open the solution file "ConnectFour\ConnectFour.sln" and compile it. **Note:** The project won't execute at this state, because of missing player1 and player2 libraries in the executing directory.
1. You can use any of the compiled libraries from the ConnectFourPlayer projects and rename one to player1.dll and the other to player2.dll.
1. Copy both of the player?.dll files to the directory where the compiled ConnectFour.exe locates. This should be ConnectFour\bin\Debug or ConnectFour\bin\Release.
1. Now you can run the project or the ConnectFour.exe directly.

### Available Players AIs
* `{"ConnectFourPlayer_Random"}`: This player sets randomly slots - *no further intelligence* ;-)
* `{"ConnectFourPlayer_Schmidt"}`: This player has *beginner intelligence*. **Note:** It can be used for player1 only, because it is hard coded so.
* `{"ConnectFourPlayer_NFriendsFloyd"}`: This player has *intermediate intelligence*.
