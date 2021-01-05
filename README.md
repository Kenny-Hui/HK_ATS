# HK ATS
## Introduction
HK_ATS is a train plugin made for Hong Kong trains in the train simulator <a href="https://github.com/leezer3/OpenBVE">OpenBVE</a>  
Still learning C#, any help would be apperciated  
## Usage
**1.** Create a file called hkconfig.cfg on the folder where the plugin is stored  
**2.** It is recommended to follow the template below  
```
; Panel indicator, i in keyi represents the key on the top number row of your keyboard (Default key assignment)
; Format: function = Pluginstate
[indicator]
key2 = 105
key3 = 106
key4 = 107
key5 = 102
key6 = 103
key7 = 104
key8 = 99
key9 = 100
key0 = 251
overspeed = 201
idletimerexceed = 100

[system]
; Define the speed limit, 0 to disable
speedlimit = 45

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

; Whether to lock the power notch to 0 when the door is opened
; 0 = The power notch will not be locked, even when the door is opened
; 1 = The driver can't power the train when the door is opened
doorpowerlock = 1

; Only unlock the door of where the station platform is
; 0 = door are always unlocked
; 1 = door are locked on the side that isn't a station platform
station = 1

[sound]
key2 = 221
key3 = 221
dsdtimerexceeded = 224
dsdtimerbrake = 219
```

## Section
### [indicator]
Panel indicator, i in keyi represents the key on the top number row of your keyboard (Default key assignment)
Format: function = Pluginstate

#### Example:
```
[indicator]
; When the "2" ley is pressed on the keyboard, trigger PluginIndicator 105
key2 = 105
key3 = 106
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
**speedlimit** - define the speedlimit in km/h, -1 means theres no speed limit  
**limitspeed** - Whether to stop the train from accelerating beyond the speedlimit  
0 = No action will be taken  
1 = Set Power Notch to 0  
2 = Apply emergency brake until the train fully stops

#### Example:
```
[system]  
; Speedlimit is 70 km/h
speedlimit = 70
; Apply EMG brake until the train fully stops, if the train exceeded 70 km/h
limitspeed = 2
```

### [dsdtimer]
Most train has an vigilance device. After a certain period of inactivity, the alarm will sound. If the driver does not take action, the device will automatically apply brake.  
**resettimerkey** - Key to reset the Idle Timer (key0, key1 etc.)  
**dsdtimerlimit** - Time before exceeding the DSD time limit (in second)  
**dsdtimerbrake** - Second before applying brake after exceeding the DSD time limit (0 to disable brake action)  
**disableontrainstop** - Whether to disable DSD when the train is stopped (1 to disable DSD on train stop)  
**resetondoormove** - Whether to reset the timer when a door opened (1 to reset the timer when door opened)  
**resetonnotchmove** = Whether to reset the timer when driver switch to another notch, or if another reverser is set (1 to reset the timer)  

#### Example:
```
[dsdtimer]  
; Key to reset the DSD Timer
resettimerkey = key0
; After 20 second, the DSD will be triggered
dsdtimerlimit = 20
; The train will apply emergency brake on 5 second after the DSD is triggered
dsdtimerbrake = 5
; Don't start the timer if the train is fully stopped
disableontrainstop = 1
; When the door is opened/closed, reset the DSD timer
resetondoormove = 1
; Reset the DSD timer when moving the reverser, or the power/brake notch
resetonnotchmove = 1
```

## Note
**1.** Lines that does not start with semicolon (';'), square bracket ('[]') or if the line does not have an equality sign (=) will be ignored.  
**2.** This plugin is in WIP, more feature will be added soon. (And you can also suggest one on the issue tab if you want)  
**3.** Prebuilt binary will not be provided for now, contact Lubuntu#2271 on discord if you need the compiled plugin  
**4.** This plugin is built on VS2019 targetting .NET Framework 4.6.1  
