EZGui
=====

EZGui is a class for easily laying out text with Unity's OnGUI() function.  It is well suited for text call-to-actions, and simple notification animations.

Live Demo
---------
* [Try Demo](http://jonmann20.github.io/playground/EZGui/)
* Resize your browser window to see the scaling happen.

Setup
-----
1. Add this file anywhere in the Assets folder (does NOT need to be attached to a game object in the heirarchy)
2. Setup a target resolution, and layout your GUI relative to this, using FULLW instead of Screen.width etc...
3. Make a call to init() at the start of your OnGUI() function.

API
---
* FULLW
* FULLH
* HALFW
* HALFH
* leftJustify
	* Set this to true to left justify text.
	
* init()
	* Scales GUI.matrix relative to FULLW and FULLH.
	* Resets leftJustify to false.
	* MUST be called at the start of OnGUI().

* GUI.Label methods
	* placeTxt(str, fontSize, x, y, ?color, ?dropShadowColor)
		* Draws str with center at (x, y).
	* flashTxt(str, fontSize, x, y, ?color, ?dropShadowColor)
		* Turns str on and off.
	* blinkTxt(str, fontSize, x, y, ?color, ?dropShadowColor)
		* Fades str in and out.
	* pulseTxt(str, fontSize, x, y, ?color, ?dropShadowColor)
		* Scales str's fontSize [0, 9].

* GUI.Button methods
	* placeBtn(str, fontSize, x, y, ?color, ?hoverColor, ?dropShadowColor)
	* flashBtn(str, fontSize, x, y, ?color, ?hoverColor, ?dropShadowColor)
	* blinkBtn(str, fontSize, x, y, ?color, ?hoverColor, ?dropShadowColor)
	* pulseBtn(str, fontSize, x, y, ?color, ?hoverColor, ?dropShadowColor)

