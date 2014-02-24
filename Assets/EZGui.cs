using UnityEngine;
using System.Collections;

/*
    A class for easily laying out text with Unity's OnGUI() function.
    
    1) Setup a target resolution, and layout your GUI relative to this.
    2) Make a call to EZGui.init() at the start of your OnGUI() function.
    3) Let EZGui handle the aspect ratio and resolution math for you.

*/

public class EZGUI : MonoBehaviour {

    public const float FULLW = 1920;
    public const float FULLH = 1080;

    public const float HALFW = FULLW / 2;
    public const float HALFH = FULLH / 2;

    public static void init(){
        float rx = Screen.width / FULLW;
        float ry = Screen.height / FULLH;

        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(rx, ry, 1));
    }

    public static void placeTxt(string str, int fontSize, float x, float y, Color? color=null){
        GUIContent content = new GUIContent(str);

        GUIStyle style = new GUIStyle();
        style.fontSize = fontSize;
        style.normal.textColor = color ?? Color.white;

        Vector2 size = style.CalcSize(content);
        GUI.Label(new Rect(x - size.x/2, y - size.y, size.x, size.y), content, style);
    }
    
    public static string lastToolTip = " ";

    public static void test(){
        GUILayout.Button(new GUIContent ("Quit", "Button2"));
    }

    public static bool placeBtn(string str, int fontSize, float x, float y, Color? color=null, Color? hoverColor=null) {
        GUIContent content = new GUIContent(str);

        GUIStyle style = new GUIStyle();
        style.normal.textColor = color ?? Color.white;
        style.fontSize = fontSize;
        
        Vector2 size = style.CalcSize(content);
        Rect btnPos = new Rect(x - size.x/2, y - size.y, size.x, size.y);
        
        Rect fixedBtnPos = new Rect(btnPos.x, btnPos.y + size.y, btnPos.width, btnPos.height);
        if(fixedBtnPos.Contains(GUIUtility.ScreenToGUIPoint(Input.mousePosition))) {
            style.normal.textColor = hoverColor ?? color ?? Color.white;
        }

        return GUI.Button(btnPos, content, style);
    }

    public static void blinkTxt(string str, int fontSize, float x, float y, Color? color=null){
        GUIContent content = new GUIContent(str);

        Color c = color ?? Color.white;
        c.a = Mathf.PingPong(Time.time, 1);

        GUIStyle style = new GUIStyle();
        style.fontSize = fontSize;
        style.normal.textColor = c;

        Vector2 size = style.CalcSize(content);
        GUI.Label(new Rect(x - size.x/2, y - size.y, size.x, size.y), content, style);
    }

    public static bool blinkBtn(string str, int fontSize, float x, float y, Color? color=null, Color? hoverColor=null) {
        GUIContent content = new GUIContent(str);

        Color c = color ?? Color.white;
        Color c2 = hoverColor ?? color ?? Color.white;
        c2.a = c.a = Mathf.PingPong(Time.time, 1);
        
        GUIStyle style = new GUIStyle();
        style.fontSize = fontSize;
        style.normal.textColor = c;
        style.hover.textColor = c2;

        Vector2 size = style.CalcSize(content);
        Rect btnPos = new Rect(x - size.x/2, y - size.y, size.x, size.y);

        Rect fixedBtnPos = new Rect(btnPos.x, btnPos.y + size.y, btnPos.width, btnPos.height);
        if(fixedBtnPos.Contains(GUIUtility.ScreenToGUIPoint(Input.mousePosition))) {
            style.normal.textColor = hoverColor ?? color ?? Color.white;
        }

        return GUI.Button(btnPos, content, style);
    }

    public static bool flashBtn(string str, int fontSize, float x, float y, Color? color=null, Color? hoverColor=null) {
        GUIContent content = new GUIContent(str);

        Color c = color ?? Color.white;
        Color c2 = hoverColor ?? color ?? Color.white;
        c2.a = c.a = (Time.time % 2 < 1) ? 1 : 0;

        GUIStyle style = new GUIStyle();
        style.fontSize = fontSize;
        style.normal.textColor = c;
        style.hover.textColor = c2;

        Vector2 size = style.CalcSize(content);
        Rect btnPos = new Rect(x - size.x/2, y - size.y, size.x, size.y);

        Rect fixedBtnPos = new Rect(btnPos.x, btnPos.y + size.y, btnPos.width, btnPos.height);
        if(fixedBtnPos.Contains(GUIUtility.ScreenToGUIPoint(Input.mousePosition))) {
            style.normal.textColor = hoverColor ?? color ?? Color.white;
        }

        return GUI.Button(btnPos, content, style);
    }

    public static Rect getPos(string str, int fontSize, float x, float y){
        GUIContent content = new GUIContent(str);

        GUIStyle style = new GUIStyle();
        style.fontSize = fontSize;

        Vector2 size = style.CalcSize(content);
        return new Rect(x - size.x/2, y - size.y, size.x, size.y);
    }
}


//style.alignment = TextAnchor.MiddleCenter;
//style.wordWrap = true;