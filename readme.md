EZGui
=====

EZGui is a class for easily laying out text with Unity's OnGUI() function.

Live Demo
---------
* [Try Demo](http://jonmann20.github.io/playground/EZGui/)
* Be sure to resize your browser window to see the scaling happen.

Setup
-----
1. Add this file anywhere in the Assets folder (does NOT need to be attached to a game object in the heirarchy)
2. Setup a target resolution, and layout your GUI relative to this.
3. Make a call to EZGui.init() at the start of your OnGUI() function.
4. Use EZGui.FULLW instead of Screen.width, etc...
5. Let EZGui handle the aspect ratio and resolution math for you.

API
---
* init()
	* MUST be called at the start of OnGUI().

* GUI.Label
	* placeTxt(str, fontSize, x, y, ?color)
		* Draw's str at (x, y).
	* flashTxt(str, fontSize, x, y, ?color)
		* Turns str on and of over time at (x, y).
	* blinkTxt(str, fontSize, x, y, ?color)
		* Same as flash, but with crossfade.
	* pulseTxt(str, fontSize, x, y, ?color)
		* Scales str's size in and out over time at (x, y).

* GUI.Button
	* placeBtn(str, fontSize, x, y, ?color, ?hoverColor)
	* flashBtn(str, fontSize, x, y, ?color, ?hoverColor)
	* blinkBtn(str, fontSize, x, y, ?color, ?hoverColor)
	* pulseBtn(str, fontSize, x, y, ?color, ?hoverColor)

NOTE: all method are available in the form:
* fooWShadow(..., ?dropShadowColor)
	* Adds a drop shadow to the text.

