# HK_ATS
## Introduction
HK_ATS is a train plugin made for Hong Kong trains in the train simulator <a href="https://github.com/leezer3/OpenBVE">OpenBVE</a>.  
The goal is to create an universal train plugin that is highly customizable, and can be used across all Hong Kong trains.  
Safety System in this plugin is rather simple, and it's intended to make sure newer player can enjoy the driving experience without too much hassle.  
Still new to C#, any help would be apperciated!  
## Usage
Create a file called hkats.ini on the folder where the plugin is stored.  
It is recommended to follow the template below  
```
; Keydown event, i in keyi represents the key on the top number row of your keyboard (Default key assignment)
; Format: keyi = PluginIndex, SoundIndex
; SoundIndex could be optional, but PluginIndex must be filled
[keydown]
key2 = 105,221
key3 = 106,221
key4 = 107
key5 = 102
key6 = 103
key7 = 104
key8 = 99
key9 = 100
key0 = 251
keyspace = 225

[system]
; Panel Indicator on overspeed and Vigilance Timeout
overspeedPanel = 201
idletimerexceedPanel = 100
; Define the speed limit, 0 to disable
speedlimit = 55

; Whether to stop the train from accelerating beyond the speedlimit
; 0 = No action will be taken
; 1 = Set Power Notch to 0
; 2 = Apply emergency brake after exceeding speed limit until the train fully stops
limitspeed = 2

[dsdtimer]
; Key to reset the Idle Timer
resettimerkey = key0

; Time before exceeding the DSD time limit (in second)
dsdtimerlimit = 20

; Second before applying brake after exceeding the DSD time limit (0 to disable brake action)
dsdtimerbrake = 5

; Whether to disable DSD when the train is stopped (1 to disable DSD on train stop)
disableontrainstop = 1

; Whether to reset the timer when a door opened (1 to reset the timer when door opened)
resetondoormove = 1

; Whether to reset the timer when driver switch to another notch, or if another reverser is set (1 to reset the timer)
resetonnotchmove = 1

[interlock]
; Lock the door when the train is moving
; 0 = door are always unlocked
; 1 = door are locked once the train departs
door = 1

; Whether to apply brake when the door is opened
; 0 = No brake will be applied when the door is opened
; 1 = Apply 70% of the total brake notch when the door is opened
doorapplybrake = 1

; Whether to lock the power notch to 0 when the door is opened
; 0 = The power notch will not be locked when the door is opened
; 1 = The driver can't power the train when the door is opened
doorpowerlock = 1

; Only unlock the door of where the station platform is
; 0 = door are always unlocked
; 1 = door are locked on the side that isn't a station platform
station = 1

[sound]
dsdtimerexceeded = 224
dsdtimerbrake = 219

; Format: beaconi/speedlimit = PluginIndex, SoundIndex
[beacon]
speedlimit = 12
beacon13 = 99,222

[misc]
; The Pluginstates to display how many meters the train travelled, will reset on jump stations
; Adding an comma specifies the nth digit of meters, up to 6 digit
; e.g. travelmeterpanel = 2,223 Means Pluginstates 223 will display the 2nd digit of the total meters

travelmeterpanel = 0

; PluginStates to display what the camera mode currently is
; 0 = Interior (2D Cab), F1
; 1 = Interior (Look Ahead), F1
; 2 = Exterior, F2
; 3 = Exterior (Follow the Track), F3
; 4 = FlyBy (Look at the train), F4
; 5 = FlyBy (Look and zoom at the train), F4
cameramodepanel = 0

; Whether to disable Time Acceleration (Ctrl+J)
; 0 = Ctrl+J will speed up the simulations (default behavior)
; 1 = Ctrl+J will not do anything
disabletimeaccel = 0
```

## Section
### [keydown]
When a key is pressed, i in keyi represents the key on the top number row of your keyboard (Default key assignment)  
Format: function = PanelIndex, SoundIndex  

#### Example:
```
[keydown]
; When the "2" key is pressed on the keyboard, trigger PluginIndicator 105
; When the "3" key is pressed on the keyboard, trigger PluginIndicator 106 and play sound index 27 defined in sound.cfg
key2 = 105
key3 = 106, 27
keyspace = 107
overspeed = 201
idletimerexceed = 100
```
### [interlock]
The interlock section offers different variety of train interlocking.  
1 means it's enabled, 0 means it's disabled  
**door** - Whether to lock the door when the train departs  
**doorpowerlock** - Whether to lock the power when the door is opened  
**station** - Whether to only allow the driver to open the door the platform is  

#### Example:
```
[interlock]
; Driver can't open the door after the train departs  
door = 1
; Driver can power the train whenever he wants, even if the door is open  
doorpowerlock = 0
; If the platform is on the left side, the driver can't open the right door  
station = 1
```
### [system]
The system section defines different security system.    
**overspeedPanel** - PanelIndicator to activate when overspeeding  
**idletimerexceedPanel** PanelIndicator to activate when the timer exceeds the vigilance device's time limit  
**speedlimit** - define the speedlimit in km/h, -1 for no speed limit  
**limitspeed** - Whether to stop the train from accelerating beyond the speedlimit  
0 = No action will be taken  
1 = Cut off power 
2 = Apply emergency brake until the train fully stops

#### Example:
```
[system]  
; Panel Indicator on overspeed and Vigilance Timeout
overspeedPanel = 201
idletimerexceedPanel = 100

; Speedlimit is 70 km/h
speedlimit = 70

; Apply EMG brake until the train fully stops, if the train exceeded 70 km/h
limitspeed = 2
```

### [dsdtimer]
Most train has an vigilance device (DVS on MTR SP1900).  
After a certain period of inactivity, the alarm will sound.  
If the driver does not take action, the device will automatically apply brake.  
**resettimerkey** - Key to reset the Idle Timer (key0, key1 etc.)  
**dsdtimerlimit** - Time before exceeding the DSD time limit (in second)  
**dsdtimerbrake** - Second before applying brake after exceeding the DSD time limit (0 to disable brake action)  
**disableontrainstop** - Whether to disable DSD when the train is stopped (1 to disable DSD on train stop)  
**resetondoormove** - Whether to reset the timer when a door opened (1 to reset the timer when door opened)  
**resetonnotchmove** = Whether to reset the timer when driver switch to another notch, or if another reverser is set (1 to reset the timer)  

#### Example:
```
[dsdtimer]  
; Key to reset the Vigilance Device Timer
resettimerkey = key0
; After 20 second, the Vigilance Device will be triggered
dsdtimerlimit = 20
; The train will apply emergency brake on 5 second after the Vigilance Device is triggered
dsdtimerbrake = 5
; Don't start the timer if the train is fully stopped
disableontrainstop = 1
; When the door is opened/closed, reset the Vigilance Device timer
resetondoormove = 1
; Reset the DSD timer when moving the reverser, or the power/brake notch
resetonnotchmove = 1
```

### [beacon]
Events when a train traveled pass a beacon. i in beaconi represents the beacon type.  
Type and Data in CSV route command: `Track.Beacon **Type**; BeaconStructureIndex; Section; **Data**`  
**speedlimit** - Define the speedlimit  
**beaconi** - Custom beacon, can be used to activate PanelIndex and SoundIndex  

#### Example:
```
[beacon]  
; When the train passes beacon 124, adjust the speed limit according to the data provided.
speedlimit = 124
; When the train passes beacon 125, triggers PluginIndex 150 and play soundIndex 102
beacon125 = 150,102
```

### [misc]
Miscellaneous functions  

**travelmeterpanel** - The Pluginstates to display how many meters the train travelled, will reset on jump stations.  
Adding an comma specifies the nth digit of meters, up to 6 digit  
travelmeterpanel = `2,223` Means Pluginstates 223 will display the 2nd digit of the total meters  

**cameramodepanel** - PluginStates to display what the camera mode currently is  
*0* = Interior (2D Cab), F1  
*1* = Interior (Look Ahead), F1  
*2* = Exterior, F2  
*3* = Exterior (Follow the Track), F3  
*4* = FlyBy (Look at the train), F4  
*5* = FlyBy (Look and zoom at the train), F4  

**disabletimeaccel** - Whether to disable Time Acceleration (Ctrl+J)  
*0* = Ctrl+J will speed up the simulations (default behavior)  
*1* = Ctrl+J will not do anything  
disabletimeaccel = 0

#### Example:
```
[misc]
; Pluginstates[193] will return the first digit of the travelmeter
; Pluginstates[192] will return the second digit of the travelmeter
; Pluginstates[191] will return the third digit of the travelmeter
; e.g. The train travelled 534m
; Pluginstates[193] will return 4
; Pluginstates[192] will return 3
; Pluginstates[191] will return 5

travelmeterpanel = 1,193
travelmeterpanel = 2,192
travelmeterpanel = 3,191

; Pluginstates[230] will return 0 if the camera is in an 2D Cab
cameramodepanel = 230

; Pressing Ctrl+J will not do anything
disabletimeaccel = 1
```

## Note
**1.** Lines that does not start with semicolon (';'), square bracket ('[]') or if the line does not have an equality sign (=) will be ignored.  
**2.** This plugin is still work in progress, README and documentation can be changed without being notified  
**3.** Prebuilt binary will not be provided for now, contact LX86#2271 on discord if you need the compiled plugin  
**4.** This plugin is built on Visual Studio 2019 targetting .NET Framework 4.6.1  
**5.** While this plugin is made for HK Trains, you can still use it if you think the feature is applicable to your train  
