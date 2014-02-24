using UnityEngine;
using System.Collections;

/*
    EZGui is a class for easily laying out text with Unity's OnGUI() function.
    
    0) Add this file anywhere in the Assets folder (does NOT need to be attached to a game object in the heirarchy)
    1) Setup a target resolution, and layout your GUI relative to this.
    2) Make a call to EZGui.init() at the start of your OnGUI() function.
    3) Use EZGui.FULLW instead of Screen.width, etc...
    4) Let EZGui handle the aspect ratio and resolution math for you.

*/

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

    public static void init(){
        float rx = Screen.width / FULLW;
        float ry = Screen.height / FULLH;

        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(rx, ry, 1));
    }

    static GUIObject getGUIObject(string str, int fontSize, float x, float y, Color? color){
        GUIObject gObj = new GUIObject();

        gObj.cnt = new GUIContent(str);

        gObj.style = new GUIStyle();
        gObj.style.fontSize = fontSize;
        gObj.style.normal.textColor = color ?? Color.white;

        gObj.size = gObj.style.CalcSize(gObj.cnt);
        gObj.rect = new Rect(x - gObj.size.x/2, y - gObj.size.y, gObj.size.x, gObj.size.y);

        return gObj;
    }

    #region GUI.Label

    public static void placeTxt(string str, int fontSize, float x, float y, Color? color=null){
        GUIObject g = getGUIObject(str, fontSize, x, y, color);

        GUI.Label(g.rect, g.cnt, g.style);
    }

    public static void placeTxtWShadow(string str, int fontSize, float x, float y, Color color, Color dropShadow) {
        GUIObject g = getGUIObject(str, fontSize, x, y, color);

        g.style.normal.textColor = dropShadow;
        GUI.Label(new Rect(g.rect.x + 5, g.rect.y + 5, g.rect.width, g.rect.height), g.cnt, g.style);

        g.style.normal.textColor = color;
        GUI.Label(g.rect, g.cnt, g.style);
    }

    public static void blinkTxt(string str, int fontSize, float x, float y, Color? color=null) {
        GUIObject g = getGUIObject(str, fontSize, x, y, color);

        Color c = g.style.normal.textColor;
        c.a = Mathf.PingPong(Time.time, 1);

        g.style.normal.textColor = c;

        GUI.Label(g.rect, g.cnt, g.style);
    }

    #endregion GUI.Label

    #region GUI.Button
    public static bool placeBtn(string str, int fontSize, float x, float y, Color? color=null, Color? hoverColor=null) {
        GUIObject g = getGUIObject(str, fontSize, x, y, color);

        if(hoverColor != null) {
            Vector2 mousePos = GUIUtility.ScreenToGUIPoint(Input.mousePosition);
            mousePos.y = FULLH - mousePos.y;

            if(g.rect.Contains(mousePos)) {
                g.style.normal.textColor = (Color)hoverColor;
            }
        }

        return GUI.Button(g.rect, g.cnt, g.style);
    }

    public static bool blinkBtn(string str, int fontSize, float x, float y, Color? color=null, Color? hoverColor=null) {
        GUIObject g = getGUIObject(str, fontSize, x, y, color);

        Color c = g.style.normal.textColor;
        c.a = Mathf.PingPong(Time.time, 1);
        
        g.style.normal.textColor = c;

        if(hoverColor != null) {
            Vector2 mousePos = GUIUtility.ScreenToGUIPoint(Input.mousePosition);
            mousePos.y = FULLH - mousePos.y;

            if(g.rect.Contains(mousePos)) {
                Color c2 = hoverColor ?? c;
                c2.a = c.a;
                g.style.normal.textColor = c2;
            }
        }

        return GUI.Button(g.rect, g.cnt, g.style);
    }

    public static bool flashBtn(string str, int fontSize, float x, float y, Color? color=null, Color? hoverColor=null) {
        GUIObject g = getGUIObject(str, fontSize, x, y, color);

        Color c = g.style.normal.textColor;
        c.a = (Time.time % 2 < 1) ? 1 : 0; ;

        g.style.normal.textColor = c;

        if(hoverColor != null) {
            Vector2 mousePos = GUIUtility.ScreenToGUIPoint(Input.mousePosition);
            mousePos.y = FULLH - mousePos.y;

            if(g.rect.Contains(mousePos)) {
                Color c2 = hoverColor ?? c;
                c2.a = c.a;
                g.style.normal.textColor = c2;
            }
        }

        return GUI.Button(g.rect, g.cnt, g.style);
    }

    #endregion GUI.Button
}


//style.alignment = TextAnchor.MiddleCenter;
//style.wordWrap = true;