# HK_ATS
## Introduction
**NOTE: This plugin will be deprecated after another major release (2.0)**  
**Consider creating your own plugin with <a href="https://github.com/zbx1425/BlocklyAts">BlocklyAts</a> - A user friendly tool to create your own customized plugin instead.**  
  
HK_ATS is a train plugin made for Hong Kong trains in the train simulator <a href="https://github.com/leezer3/OpenBVE">OpenBVE</a>.  
The goal is to create an universal train plugin that is highly customizable, and can be used across all Hong Kong trains.  
Safety System in this plugin is rather simple, and it's intended to make sure newer player can enjoy the driving experience without too much hassle.    

## Usage
Download the plugin from the release page on the right.  
Create a file called hkats.ini on the folder where the plugin is stored.  
It is recommended to follow the template below  
```
; Keydown event, see https://github.com/Kenny-Hui/HK_ATS/blob/main/README.md for full list of Key Functions
; Format: keyfunction = Pluginstates, SoundIndex, Hold
; Enter "hold" on the third argument will make the pluginstates reset back to 0 after releasing the key
[keydown]
key2 = 105,221
key3 = 106,221
key4 = 107
key5 = 102
key6 = 103
key7 = 104
key8 = 99,0,hold
key9 = 100
key0 = 251
keyspace = 225

[system]
; Panel Indicator on overspeed
overspeedPanel = 201

; Panel Indicator on Vigilance Timeout
idletimerexceedPanel = 100

; Define the speed limit, 0 to disable
speedlimit = 55

; Whether to stop the train from accelerating beyond the speedlimit
; 0 = No action will be taken
; 1 = Set Power Notch to 0
; 2 = Apply emergency brake after exceeding speed limit until the train fully stops
limitspeed = 2

[vigilance]
; Key to reset the Vigilance Device
resettimerkey = key0

; Time before exceeding the Vigilance time limit (in second)
timerlimit = 20

; Second before applying brake after exceeding the Vigilance time limit (0 to disable brake action)
timerbrake = 5

; Whether to disable/reset the Vigilance device when the train is stopped (1 to disable/reset on train stop)
disableontrainstop = 1

; Whether to reset the timer when a door opened (1 to reset the timer when door opened)
resetondoormove = 1

; Whether to reset the timer when driver switch to another notch, or if another reverser is set (1 to reset the timer)
resetonnotchmove = 1

; The SoundIndex played when the Vigilance Device timeout exceeded
timerexceededsound = 224

; The SoundIndex played when the Vigilance Device applies brake
timerbrakesound = 219

; Which Klaxon (Horn) will reset the Vigilance Timer
; 0 = Horning won't reset the timer
; 1 = Primary Horn
; 2 = Secondary Horn
; 3 = Music Horn
; 4 = All Horn
resetonklaxon = 4

[interlock]
; Lock the door when the train is moving
; 0 = door are always unlocked
; 1 = door are locked once the train departs
door = 1

; Whether to apply brake when the door is opened
; 0 = No brake will be applied when the door is opened
; 1 = Apply 70% of the total brake notch when the door is opened
doorapplybrake = 1

; Whether to lock the power notch when the door is opened
; 0 = The power notch will not be locked when the door is opened
; 1 = The driver can't power the train when the door is opened
doorpowerlock = 1

; Whether to only unlock the door of where the station platform is
; 0 = door are always unlocked
; 1 = door are locked on the side that isn't a station platform
station = 1

[beacon]
; Format: beaconi/speedlimit = Pluginstates
speedlimit = 18

; Format: beaconi = Pluginstates,SoundIndex
beacon13 = 99,222

[soundloop]
key2 = 222
key3 = 222

[misc]
; The pluginstates to display how many meters the train travelled, will reset on jump stations
; Adding a comma specifies the nth digit of meters, up to 6 digit
; e.g. travelmeterpanel = 2,223 means pluginstates 223 will display the 2nd digit of the total meters

travelmeterpanel = 1,244
travelmeterpanel = 2,245

; Pluginstates to display what the camera mode currently is
; The returned value is:
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

; The pluginstates to display/The SoundIndex played when the train crashed into the previous train (if any)
; This allows custom crash animations and sound
; The previous train is set by the .RunInterval command
; Format: crash = Panelindicator,Soundindex
; SoundIndex could be optional, but Panelindicator must be filled
crash = 213,223

; The minimum speed to be considered as a crash if player's trains touches the previous train
; e.g. crashspeed = 5, if player's trains touches the previous train and is lower than 5 km/h, it would not be considered as a crash
crashspeed = 5
```

## Key Functions
**Note: All keys assignment below is the default key assignment from OpenBVE**  
**key2** = The 2 on the number row of your keyboard  
**key3** = The 3 on the number row of your keyboard  
**key4** = The 4 on the number row of your keyboard  
**key5** = The 5 on the number row of your keyboard  
**key6** = The 6 on the number row of your keyboard  
**key7** = The 7 on the number row of your keyboard  
**key8** = The 8 on the number row of your keyboard  
**key9** = The 9 on the number row of your keyboard  
**key0** = The 0 key on the number row of your keyboard  
**keyspace** = The space bar on your keyboard  
**keypgup** = The PageUp key on your keyboard  
**keypgdn** = The PageDown key on your keyboard  
**keyend** = The End key on your keyboard  
**keyhome** = The Home key on your keyboard  
**keydel** = The Delete key on your keyboard  
**keyins** = The Insert key on your keyboard  
**keywiperup** = The key to increase wiper speed, default key is Y  
**keywiperdown** = The key to decrease wiper speed, default key is Ctrl+Y  
**keymainbreaker** = The key to toggle the main breaker, default key is B  
**keyraisepan** = The key to raises the pantograph, default key is P  
**keylowerpan** = The key to lower the pantograph, default key is Ctrl+P  
**keylivesteaminjector** = The key to activate/deactivate the live stream injector, default is I  
**keyrightdoor** = The key to open/close the right door, default is F6  
**keyleftdoor** = The key to open/close the left door, default is F5  
**keygearup** = The key to shift up a gear in a train fitted with a gearbox, default is G  
**keygeardown** = The key to shift down a gear in a train fitted with a gearbox, default is Ctrl+G  
**keyfillfuel** = The key to fills fuel, default is none?  
**keyincreasecutoff** = The key to decrease the cutoff, default is U  
**keydecreasecutoff** = The key to decrease the cutoff, default is Ctrl+U  
**keysteaminjector** = The key to activate/deactivate exhaust steam injector, default is O  
**keyblowers** = The key to activate/deactivate the blowers, default is K  
**keyenginestart** = The key to start the engine, default is E  
**keyenginestop** = The key to stop the engine, default is Ctrl+E  

## Config file - Sections
### [keydown]
When a key is pressed, i in keyi represents the key on the top number row of your keyboard (Default key assignment)  
Format: `keyfunction = PanelIndex, SoundIndex, Hold`  
Enter "hold" on the third argument if you want to activate a pluginstates only when the player is holding the key.  
You can type 0 on SoundIndex if you don't want any sound, but you want the hold feature

#### Example:
```
[keydown]
; When the "2" key is pressed, trigger PluginIndicator 105 and play SoundIndex 221 defined in sound.cfg
key2 = 105,221

; When the "3" key is pressed, only trigger PluginIndicator 106
key3 = 106

; When the "8" key is pressed, trigger PluginIndicator 99, but don't play any sound.
; Will deactivate PluginIndicator 99 (set back to 0) once the player is no longer holding the "8" key.
key8 = 99,0,hold
```
### [interlock]
The interlock section offers different variety of train interlocking.  
1 means it's enabled, 0 means it's disabled  
**door** - Whether to lock the door when the train is running  
**doorapplybrake** - Whether to apply 70% of the brake when the door is opened  
**doorpowerlock** - Whether to lock the power when the door is opened  
**station** - Whether to only allow the driver to open the door where the platform is  

#### Example:
```
[interlock]
; Driver can't open the door after the train departs  
door = 1  

; The following combination means that the driver can't apply power when the door is opened, but no brake will be applied ;
; If the track section is sloping upwards/downwards, the train could also accelerate from the force ;  

; No brake will be applied when the door is opened  
doorapplybrake = 0  
; Driver can't power the train if the door is opened  
doorpowerlock = 1  

; If the platform is on the left side, the driver can't open the right door  
station = 1
```
### [system]
The system section defines different security system.    
**overspeedPanel** - PanelIndicator to activate when overspeeding  
**speedlimit** - define the speedlimit in km/h, -1 for no speed limit  
**limitspeed** - Whether to stop the train from accelerating beyond the speedlimit  
0 = No action will be taken  
1 = Cut off power 
2 = Apply emergency brake until the train fully stops

#### Example:
```
[system]  
; Panel Indicator on overspeed
overspeedPanel = 201

; Speedlimit is 70 km/h
speedlimit = 70

; Apply EMG brake until the train fully stops, if the train exceeded 70 km/h
limitspeed = 2
```

### [vigilance]
Most train has an vigilance device (Also called DVS on MTR SP1900).  
After a certain period of inactivity, the alarm will sound.  
If the driver does not take action, the device can automatically apply brake.  
**resettimerkey** - Key to reset the Vigilance Device Timer (key0, key1 etc.)  
**timerlimit** - Time before exceeding the Vigilance Device time limit (in second)  
**timerbrake** - Second before applying brake after exceeding the DSD time limit (0 to disable brake action)  
**disableontrainstop** - Whether to disable Vigilance Device timer when the train is stopped (1 to disable DSD on train stop)  
**resetondoormove** - Whether to reset the timer when a door opened (1 to reset the timer when door opened)  
**resetonnotchmove** - Whether to reset the timer when driver switch to another notch, or if another reverser is set (1 to reset the timer)  
**resetonklaxon** - Specify the Klaxon (Horn) that will reset the Vigilance Timer when horned  
**timerexceedPanel** Panel Indicator to activate when the timer exceeds the vigilance device's time limit  
0 = Horning won't reset the timer  
1 = Primary Horn  
2 = Secondary Horn  
3 = Music Horn  
4 = All Horn  
**timerexceededsound** - The SoundIndex played when the Vigilance Device timeout exceeded  
**timerbrakesound** - The SoundIndex played when the Vigilance Device applies brake


#### Example:
```
[vigilance]
; Key to reset the Vigilance Device
resettimerkey = key0

; Time before exceeding the Vigilance time limit (in second)
timerlimit = 20

; Second before applying brake after exceeding the Vigilance time limit (0 to disable brake action)
timerbrake = 5

; Whether to disable/reset the Vigilance device when the train is stopped (1 to disable/reset on train stop)
disableontrainstop = 1

; Whether to reset the timer when a door opened (1 to reset the timer when door opened)
resetondoormove = 1

; Whether to reset the timer when driver switch to another notch, or if another reverser is set (1 to reset the timer)
resetonnotchmove = 1

; Pressing the Secondary Horn (Usually numpad "+") will reset the Vigilance Timer
resetonklaxon = 2

; The SoundIndex played when the Vigilance Device timeout exceeded
timerexceededsound = 224

; The SoundIndex played when the Vigilance Device applies brake
timerbrakesound = 219

; Panel Indicator on Vigilance Timeout
idletimerexceedPanel = 100
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

**travelmeterpanel** - The panel indicator to display how many meters the train travelled, will reset on jump stations.  
Adding an comma specifies the nth digit of meters, up to 6 digit  
travelmeterpanel = `2,223` Means Pluginstates[223] will display the 2nd digit of the total meters  

**cameramodepanel** - Panel Indicator to display what the camera mode currently is  
Returned Value:  
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

**crash** - The pluginstates to display/The SoundIndex played when the train crashed into the previous RunInterval train (if any)  
This would allow custom crash animations and sound  
Format: **crash = Pluginstates,Soundindex**  
Specified plugin indicator will be reset when the train jumped to another stations<br><br>
Conditions to trigger a crash:  
**1.** The train has not been crashed before  
**2.** The distance between the previous train and the current train must be less than 0.2m and higher than -1m  

**crashspeed** - The minimum speed to be considered as a crash if player's trains touches the previous train  



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

; Pluginstates[230] will return 0 if player is in a 2D Cab
cameramodepanel = 230

; Pressing Ctrl+J will not do anything
disabletimeaccel = 1

; When player's train crashed into the previous train, it will activate Pluginstates[213] and SoundIndex 223
crash = 213,223

; If the speed is the player's train is less than 5 km/h, it won't be considered as a crash
crashspeed = 5
```

## Note
**1.** Lines that does not start with semicolon (';'), square bracket ('[]') or if the line does not have an equality sign (=) will be ignored.  
**2.** This plugin is still work in progress, README and documentation can be changed without being notified  
**3.** This plugin is built on Visual Studio 2019 targetting .NET Framework 4.6.1. Please reference OpenBveApi  
**4.** While this plugin is made for HK Trains, you can still use it if you think the feature is applicable to your train  
**5.** Feel free to report any bug found on the Issue tab
