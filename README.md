# TeslaTools
A program to group multiple tools for the Teslagrad speedrunning community.

## Save Editor (Fully working - please repport bugs !)
This tool creates customisable saves directly into the Teslagrad save folder. You can select checkpoints, powerups, defeated bosses in any order, number of scrolls and even read-only file-type, in order to avoid the game overwriting your favorite training spot ! Usefull for NG+, exploits research, and also a good way to practice particular spots.

## Bingo (Work in progress)
This tool generates bingo cards for bingo races. The bingo will be made of different objectives like collecting specific scrolls and killing or not bosses. Ideas includes perform specific tricks or just gimic thing like killing a certain amount of voidwalker/grue.

## Not integrated into Teslatools
### TeslaSplit
Maintained by BoursinBurger, currently available at [TeslaSplit](https://github.com/BoursinBurger/TeslaSplit)
This tool watches the Teslagrad save game files looking for updates. New saves are made upon entering a room, killing a boss, collecting an item, etc. Upon encountering a key event you're anticipating, it will press the split hotkey for your timesplitting program. This allows hands-free and consistently accurate split times.

Note: I thought of some funny features like an interactive map that could make use of the same principle as TeslaSplit for reading savefiles. Still not sure if some kind of similar tool should be part of TeslaTools.

### TASlasgrad (Work in progress)
This tool records inputs and then play them back for TASing or multi-segment. First attempt to this program (by Dioxymore and me) had major de-sync issue. Recently, DevilSquirrel made a new version which appear to work a little better by replacing some of Teslagrad's DLL. It can be found [here](https://github.com/ShootMe/TeslagradTAS).

### TeslaViewer (Work in progress)
Maintained by Dioxymore (no repo available at the moment). This tool is under construction, still a proof of concept and need some polish. The idea is to display some informations ingame like the character's speed and position, checkpoints and more. Uses the same technique as TASlagrad (replacing game's DLL) to access some ingame variables.
