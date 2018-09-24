“Visual Moving Pattern recognition and focus of control” application for the Clinical Research Team ecli.psy, using Unity3D and C# scripts – Greek Institute of Clinical Psychology.

The concept of this of this application is the following:
The user controls the movement of a robot in an open field where clouds have gathered up above it and shoot lighting bolts.
There are 4 clouds shooting one lighting bolt each every three(3) seconds in a standard pattern.
Goal of this application is to investigate how quickly the user can realize that the lighting bolts drop in a standard pattern and collect as many as possible.
This process lasts three(3) minutes (180 seconds) and every minute a percentage of the successfully gathered lighting bolts is registered in a file.
Ideally, every minute the percentage of the gathered lighting bolts should be greater than the previous minute as a result of the user focusing and recognizing the pattern.
At the end of the timer, results are automatically exported to a database (.txt file) in the following format for example:

---------------------------
TOTAL SCORE: 45% (27/60)

FIRST MINUTE: 30%
SECOND MINUTE: 50%
THIRD MINUTE: 55%

LIGHTING BOLT No_1: Successful
LIGHTING BOLT No_2: Unsuccessful
LIGHTING BOLT No_3: Unsuccessful
....
LIGHTING BOLT No_59: Successful
LIGHTING BOLT No_60: Successful

------------------------------------

KEYBOARD CONTROLS:
D or Right Arrow --> Move right
A or Left Arrow  --> Move left
Space            --> Jump


CHEAT SHEET: 
1) The pattern of the lighting bolts dropped from the clouds is the following:
Cloud_1 --> Cloud_3 --> Cloud_2 --> Cloud_4
2) There are three(3) trees that separate the areas where the clouds drop the lighting bolts. Robot can stand anywhere in this small area to gather the lighting bolt triggered from the cloud above it.
