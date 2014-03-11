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

public struct EZOpt {
    public string str;
    public int fontSize;
    public float x, y;
    
    public Color? color, hover, active, drop;
    public bool bold, italic, leftJustify;
    public int dropShadowX, dropShadowY, width;


    public EZOpt(
        string str, int fontSize, float x, float y, 
        Color? color=null, Color? hoverColor=null, Color? activeColor=null, Color? dropShadow=null, 
        bool bold=false, bool italic=false, bool leftJustify=false,
        int dropShadowX=5, int dropShadowY=5, int width=0
    ){
        this.str = str;
        this.fontSize = fontSize;
        this.x = x;
        this.y = y;

        this.color = color ?? Color.white;
        this.hover = hoverColor;
        this.active = activeColor;
        this.drop = dropShadow;
        this.bold = bold;
        this.italic = italic;
        this.leftJustify = leftJustify;
        this.dropShadowX = dropShadowX;
        this.dropShadowY = dropShadowY;
        this.width = width;
    }
};

public class EZGUI : MonoBehaviour {

    public const float FULLW = 1920;
    public const float FULLH = 1080;

    public const float HALFW = FULLW / 2;
    public const float HALFH = FULLH / 2;

    struct GUIObject {
        public GUIContent cnt;
        public GUIStyle style;
        public Vector2 size;
        public Rect rect;
    }

    /// <summary>
    /// Scales GUI.matrix relative to FULLW and FULLH.  
    /// Must be called at the start of OnGUI()!
    /// </summary>
    public static void init(){
        float rx = Screen.width / FULLW;
        float ry = Screen.height / FULLH;

        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(rx, ry, 1));
    }

    static GUIObject getGUIObject(EZOpt e){
        GUIObject gObj = new GUIObject();

        gObj.cnt = new GUIContent(e.str);

        gObj.style = new GUIStyle();
        gObj.style.fontSize = e.fontSize;
        gObj.style.normal.textColor = e.color ?? Color.white;

        gObj.size = gObj.style.CalcSize(gObj.cnt);
        gObj.rect = new Rect(e.x - gObj.size.x/2, e.y - gObj.size.y, gObj.size.x, gObj.size.y);

        if(e.leftJustify){
            gObj.rect.x += gObj.rect.width/2;
        }

        if(e.italic && e.bold) {
            gObj.style.fontStyle = FontStyle.BoldAndItalic;
        }
        else if(e.italic) {
            gObj.style.fontStyle = FontStyle.Italic;
        }
        else if(e.bold) {
            gObj.style.fontStyle = FontStyle.Bold;
        }

        return gObj;
    }

    static void addDropShadow(GUIObject g, int dropShadowOffsetX, int dropShadowOffsetY, Color? dropShadow=null) {
        if(dropShadow != null && g.style.normal.textColor.a != 0){
            Color prevColor = g.style.normal.textColor;

            Color ds = (Color)dropShadow;
            ds.a = prevColor.a;
            g.style.normal.textColor = ds;

            GUI.Label(new Rect(g.rect.x + dropShadowOffsetX, g.rect.y + dropShadowOffsetY, g.rect.width, g.rect.height), g.cnt, g.style);

            g.style.normal.textColor = prevColor;
        }
    }

    static bool checkMouse(GUIObject g, Color? hoverColor, Color? activeColor){
        if(hoverColor != null) {
            Vector2 mousePos = GUIUtility.ScreenToGUIPoint(Input.mousePosition);
            mousePos.y = FULLH - mousePos.y;

            if(g.rect.Contains(mousePos)){
                if(activeColor != null && Input.GetMouseButton(0)) {
                    g.style.normal.textColor = (Color)activeColor;
                }
                else {
                    g.style.normal.textColor = (Color)hoverColor;
                }

                return true;
            }
        }

        return false;
    }

    #region GUI.Label

    /// <summary>
    /// Draws str with center at (x, y).
    /// </summary>
    public static void placeTxt(EZOpt e){
        GUIObject g = getGUIObject(e);
        addDropShadow(g, e.dropShadowX, e.dropShadowY, e.drop);

        GUI.Label(g.rect, g.cnt, g.style);
    }

    /// <summary>
    /// Str will wrap to fit in width.
    /// </summary>
    public static void wrapTxt(EZOpt e) {
        GUIObject g = getGUIObject(e);

        addDropShadow(g, e.dropShadowX, e.dropShadowY, e.drop);

        GUIStyle style = GUI.skin.GetStyle("Label");
        style.fontSize = g.style.fontSize;
        style.normal.textColor = g.style.normal.textColor;

        GUI.Label(new Rect(e.x, e.y, e.width, FULLH), e.str, style);
    }

    /// <summary>
    /// Fades str in and out.
    /// </summary>
    public static void blinkTxt(EZOpt e) {
        GUIObject g = getGUIObject(e);

        Color c = g.style.normal.textColor;
        c.a = Mathf.PingPong(Time.time, 1);
        g.style.normal.textColor = c;

        addDropShadow(g, e.dropShadowX, e.dropShadowY, e.drop);

        GUI.Label(g.rect, g.cnt, g.style);
    }

    /// <summary>
    /// Turns str on and off.
    /// </summary>
    public static void flashTxt(EZOpt e) {
		GUIObject g = getGUIObject(e);
		
        if(Time.time % 2 < 1) {
            addDropShadow(g, e.dropShadowX, e.dropShadowY, e.drop);

            GUI.Label(g.rect, g.cnt, g.style);
        }
	}

    /// <summary>
    /// Scales str's fontSize [0, 9].
    /// </summary>
	public static void pulseTxt(EZOpt e){
		float pp = Mathf.PingPong(Time.time, 0.9f);
		pp *= 10;
		e.fontSize += (int)pp;
		
		GUIObject g = getGUIObject(e);

        addDropShadow(g, e.dropShadowX, e.dropShadowY, e.drop);

		GUI.Label(g.rect, g.cnt, g.style);
	}

    #endregion GUI.Label

    #region GUI.Button

    /// <summary>
    /// Draws str with center at (x, y).
    /// </summary>
    /// <returns>True if button was clicked.</returns>
    public static bool placeBtn(EZOpt e){
        GUIObject g = getGUIObject(e);

        checkMouse(g, e.hover, e.active);
        addDropShadow(g, e.dropShadowX, e.dropShadowY, e.drop);
        
        return GUI.Button(g.rect, g.cnt, g.style);
    }

    /// <summary>
    /// Fades str in and out.
    /// </summary>
    /// <returns>True if button was clicked.</returns>
    public static bool blinkBtn(EZOpt e) {
        GUIObject g = getGUIObject(e);

        Color c = g.style.normal.textColor;
        c.a = Mathf.PingPong(Time.time, 1);
        g.style.normal.textColor = c;

        checkMouse(g, e.hover, e.active);
        addDropShadow(g, e.dropShadowX, e.dropShadowY, e.drop);

        return GUI.Button(g.rect, g.cnt, g.style);
    }

    /// <summary>
    /// Turns str's alpha value on and off.
    /// </summary>
    /// <returns>True if button was clicked.</returns>
    public static bool flashBtn(EZOpt e) {
        GUIObject g = getGUIObject(e);

        Color c = g.style.normal.textColor;
        c.a = (Time.time % 2 < 1) ? 1 : 0;
        g.style.normal.textColor = c;

        checkMouse(g, e.hover, e.active);
        addDropShadow(g, e.dropShadowX, e.dropShadowY, e.drop);

        return GUI.Button(g.rect, g.cnt, g.style);
    }

    /// <summary>
    /// Scales str's fontSize [0, 9].
    /// </summary>
    /// <returns>True if button was clicked.</returns>
    public static bool pulseBtn(EZOpt e) {

        GUIObject g = getGUIObject(e);
        bool isHover = checkMouse(g, e.hover, e.active);

        if(!isHover){
            float pp = Mathf.PingPong(Time.time, 0.9f);
            pp *= 10;
            e.fontSize += (int)pp;
            
            g = getGUIObject(e);
        }
        else {
            e.fontSize += 9;  // make text fullsize on hover

            g = getGUIObject(e);

            if(e.active != null && Input.GetMouseButton(0)) {
                g.style.normal.textColor = (Color)e.active;
            }
            else {
                g.style.normal.textColor = (Color)e.hover;
            }
        }

        addDropShadow(g, e.dropShadowX, e.dropShadowY, e.drop);

        return GUI.Button(g.rect, g.cnt, g.style);
    }

    #endregion GUI.Button


}


//style.alignment = TextAnchor.MiddleCenter;
//g.style.wordWrap = true;