# HK ATS
## Introduction
HK_ATS is a train plugin made for Hong Kong trains in the train simulator <a href="https://github.com/leezer3/OpenBVE">OpenBVE</a>  
Still learning C#, any help would be apperciated :P  
## Usage
**1.** Create a file called hkconfig.cfg on the folder where you store your plugin  
**2.** Follow the config template below  
```[atskey]
key2 = 105
key3 = 106
key4 = 107
key5 = 102
key6 = 103
key7 = 104
key8 = 99
key9 = 100
key0 = 251
[interlock]
door = 1
doorapplybrake = 1
station = 1
[system]
speedlimit = 45
```

## Section
### [atskey]
The atskey section defines the indicator to use when a key is pressed.  
Key*i* should be the number key on top row of your keyboard  

#### Example:
```
[atskey]
/ When the "2" ley is pressed on the keyboard, trigger PluginIndicator 105 /
key2 = 105
```
### [interlock]
The interlock section offers different variety of train interlocking.  
1 means it's enabled, 0 means it's disabled  
**door** - Whether to lock the door when the train departs  
**doorapplybrake** - Whether to apply brake when the door is opened  
**Station** - Whether to only allow the driver to open the door the platform is  

#### Example:
```
[interlock]
/ Driver can't open the door after the train departs /  
door = 1
/ Driver can depart whenever he wants, even if the door is open /  
doorapplybrake = 0
/ If the platform is on the left side, the driver can't open the right door /  
station = 1
```
### [system]
The system section defines different security system.  
1 means it's enabled, 0 means it's disabled  
speedlimit = define the speedlimit in km/h, -1 means theres no speed limit  

#### Example:
```
[system]  
/ After 70 km/h, the train will no longer accelerate /  
speedlimit = 70
```

## Note
**1.** Lines that does not start with slash ('/'), square bracket ('[]') or if the line does not have an equality sign (=) will make the plugin not load.  
It shouldn't be too hard to patch, and there will probably be check against this soon  
**2.** This project is not anywhere finished yet, more feature will be added. (And you can also suggest one on the issue tab if you want)  
**3.** Prebuilt binary will not be provided for now, contact Lubuntu#2271 on discord if you need the compiled plugin  
**4.** This plugin is built on VS2019 targetting .NET Framework 4.6.1  
