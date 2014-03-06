using UnityEngine;
using System.Collections;

/*
    Author: Jon Wiedmann
    Email: jonwiedmann@gmail.com
    Repo: https://github.com/jonmann20/EZGui
    License: MIT

    EZGui is a class for easily laying out text with Unity's OnGUI() function.  It is well suited for text call-to-actions, and simple notification animations.
    
    0) Add this file anywhere in the Assets folder (does NOT need to be attached to a game object in the heirarchy)
    1) Setup a target resolution, and layout your GUI relative to this, using FULLW instead of Screen.width etc...
    2) Make a call to init() at the start of your OnGUI() function.
*/

public class EZGUI : MonoBehaviour {

    public const float FULLW = 1920;
    public const float FULLH = 1080;

    public const float HALFW = FULLW / 2;
    public const float HALFH = FULLH / 2;

    public static bool leftJustify = false;

    struct GUIObject {
        public GUIContent cnt;
        public GUIStyle style;
        public Vector2 size;
        public Rect rect;
    }

    /// <summary>
    /// Scales GUI.matrix relative to FULLW and FULLH.  Resets leftJustify to false.  
    /// Must be called at the start of OnGUI()!
    /// </summary>
    public static void init(){
        float rx = Screen.width / FULLW;
        float ry = Screen.height / FULLH;

        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(rx, ry, 1));
        
        leftJustify = false;
    }

    static GUIObject getGUIObject(string str, int fontSize, float x, float y, Color? color){
        GUIObject gObj = new GUIObject();

        gObj.cnt = new GUIContent(str);

        gObj.style = new GUIStyle();
        gObj.style.fontSize = fontSize;
        gObj.style.normal.textColor = color ?? Color.white;

        gObj.size = gObj.style.CalcSize(gObj.cnt);
        gObj.rect = new Rect(x - gObj.size.x/2, y - gObj.size.y, gObj.size.x, gObj.size.y);

        if(leftJustify){
            gObj.rect.x += gObj.rect.width/2;
        }

        return gObj;
    }

    static void addDropShadow(GUIObject g, Color? dropShadow=null){
        if(dropShadow != null && g.style.normal.textColor.a != 0){
            Color prevColor = g.style.normal.textColor;

            Color ds = (Color)dropShadow;
            ds.a = prevColor.a;
            g.style.normal.textColor = ds;

            GUI.Label(new Rect(g.rect.x + 5, g.rect.y + 5, g.rect.width, g.rect.height), g.cnt, g.style);

            g.style.normal.textColor = prevColor;
        }
    }

    static bool checkHover(GUIObject g, Color? hoverColor){
        if(hoverColor != null) {
            Vector2 mousePos = GUIUtility.ScreenToGUIPoint(Input.mousePosition);
            mousePos.y = FULLH - mousePos.y;

            if(g.rect.Contains(mousePos)){
                g.style.normal.textColor = (Color)hoverColor;
                return true;
            }
        }

        return false;
    }

    #region GUI.Label

    /// <summary>
    /// Draws str with center at (x, y).
    /// </summary>
    public static void placeTxt(string str, int fontSize, float x, float y, Color? color=null, Color? dropShadow=null){
        GUIObject g = getGUIObject(str, fontSize, x, y, color);
        addDropShadow(g, dropShadow);

        GUI.Label(g.rect, g.cnt, g.style);
    }

    /// <summary>
    /// Draws str with center at (x, y).
    /// </summary>
    public static void wrapTxt(string str, int fontSize, float x, float y, float w, Color? color=null, Color? dropShadow=null) {
        GUIObject g = getGUIObject(str, fontSize, x, y, color);
        g.rect.width = w;
        g.style.wordWrap = true;

        addDropShadow(g, dropShadow);

        GUI.Label(g.rect, g.cnt, g.style);
    }

    /// <summary>
    /// Fades str in and out.
    /// </summary>
	public static void blinkTxt(string str, int fontSize, float x, float y, Color? color=null, Color? dropShadow=null){
        GUIObject g = getGUIObject(str, fontSize, x, y, color);

        Color c = g.style.normal.textColor;
        c.a = Mathf.PingPong(Time.time, 1);
        g.style.normal.textColor = c;

        addDropShadow(g, dropShadow);

        GUI.Label(g.rect, g.cnt, g.style);
    }

    /// <summary>
    /// Turns str on and off.
    /// </summary>
	public static void flashTxt(string str, int fontSize, float x, float y, Color? color=null, Color? dropShadow=null){
		GUIObject g = getGUIObject(str, fontSize, x, y, color);
		
        if(Time.time % 2 < 1) {
            addDropShadow(g, dropShadow);

            GUI.Label(g.rect, g.cnt, g.style);
        }
	}

    /// <summary>
    /// Scales str's fontSize [0, 9].
    /// </summary>
	public static void pulseTxt(string str, int fontSize, float x, float y, Color? color=null, Color? dropShadow=null){
		float pp = Mathf.PingPong(Time.time, 0.9f);
		pp *= 10;
		fontSize += (int)pp;
		
		GUIObject g = getGUIObject(str, fontSize, x, y, color);

        addDropShadow(g, dropShadow);

		GUI.Label(g.rect, g.cnt, g.style);
	}

    #endregion GUI.Label

    #region GUI.Button

    /// <summary>
    /// Draws str with center at (x, y).
    /// </summary>
    /// <returns>True if button was clicked.</returns>
    public static bool placeBtn(string str, int fontSize, float x, float y, Color? color=null, Color? hoverColor=null, Color? dropShadow=null){
        GUIObject g = getGUIObject(str, fontSize, x, y, color);

        checkHover(g, hoverColor);
        addDropShadow(g, dropShadow);

        return GUI.Button(g.rect, g.cnt, g.style);
    }

    /// <summary>
    /// Fades str in and out.
    /// </summary>
    /// <returns>True if button was clicked.</returns>
    public static bool blinkBtn(string str, int fontSize, float x, float y, Color? color=null, Color? hoverColor=null, Color? dropShadow=null) {
        GUIObject g = getGUIObject(str, fontSize, x, y, color);

        Color c = g.style.normal.textColor;
        c.a = Mathf.PingPong(Time.time, 1);
        g.style.normal.textColor = c;

        checkHover(g, hoverColor);
        addDropShadow(g, dropShadow);

        return GUI.Button(g.rect, g.cnt, g.style);
    }

    /// <summary>
    /// Turns str's alpha value on and off.
    /// </summary>
    /// <returns>True if button was clicked.</returns>
    public static bool flashBtn(string str, int fontSize, float x, float y, Color? color=null, Color? hoverColor=null, Color? dropShadow=null) {
        GUIObject g = getGUIObject(str, fontSize, x, y, color);

        Color c = g.style.normal.textColor;
        c.a = (Time.time % 2 < 1) ? 1 : 0;
        g.style.normal.textColor = c;

        checkHover(g, hoverColor);
        addDropShadow(g, dropShadow);

        return GUI.Button(g.rect, g.cnt, g.style);
    }

    /// <summary>
    /// Scales str's fontSize [0, 9].
    /// </summary>
    /// <returns>True if button was clicked.</returns>
    public static bool pulseBtn(string str, int fontSize, float x, float y, Color color, Color hoverColor, Color? dropShadow=null) {

        GUIObject g = getGUIObject(str, fontSize, x, y, color);
        bool isHover = checkHover(g, hoverColor);

        if(!isHover){
            float pp = Mathf.PingPong(Time.time, 0.9f);
            pp *= 10;
            fontSize += (int)pp;
            
            g = getGUIObject(str, fontSize, x, y, color);
        }
        else {
            fontSize += 9;  // make text fullsize on hover

            g = getGUIObject(str, fontSize, x, y, color);
            g.style.normal.textColor = (Color)hoverColor;
        }
        
        addDropShadow(g, dropShadow);

        return GUI.Button(g.rect, g.cnt, g.style);
    }

    #endregion GUI.Button
}


//style.alignment = TextAnchor.MiddleCenter;
//g.style.wordWrap = true;