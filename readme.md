EZGUI
=====

EZGUI is a class for easily laying out text with Unity's OnGUI() function.  It is well suited for text call-to-actions, and simple notification animations.

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

* init()
	* Scales GUI.matrix relative to FULLW and FULLH.
	* MUST be called at the start of OnGUI().

* GUI.Label methods
	* placeTxt(str, fontSize, x, y, ?ezOpt)
		* Draws str with center at (x, y).
	* flashTxt(str, fontSize, x, y, ?ezOpt)
		* Turns str on and off.
	* blinkTxt(str, fontSize, x, y, ?ezOpt)
		* Fades str in and out.
	* pulseTxt(str, fontSize, x, y, ?ezOpt)
		* Scales str's fontSize [0, 9].
	* wrapTxt(str, fontSize, x, y, width, ?ezOpt)
		* Str will wrap to fit in width.  NOTE: text is left justified and top aligned (this includes placement).

* GUI.Button methods: returns true on click
	* placeBtn(str, fontSize, x, y, ?ezOpt)
	* flashBtn(str, fontSize, x, y, ?ezOpt)
	* blinkBtn(str, fontSize, x, y, ?ezOpt)
	* pulseBtn(str, fontSize, x, y, ?ezOpt)
	
* GUI.Window methods
	* placeWindow(str, fontSize, x, y, height, callback, bgColor, ?ezOpt)

* EZOpt: A struct for extending the basic text layout
	* color
	* hoverColor
	* activeColor
	* dropShadow
	* bold
	* italic
	* leftJustify
	* dropShadowX
	* dropShadowY