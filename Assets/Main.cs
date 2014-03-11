using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    Color drp, btnActive;
    void Awake(){
        drp = new Color(0.1f, 0.1f, 0.1f);
        btnActive = new Color(1, 0.822f, 0.016f);
        //print(Color.yellow);
    }

    void OnGUI(){
        EZGUI.init();

        if(EZGUI.placeBtn(new EZOpt("Back", 45, 85, 85, Color.white, Color.red, Color.black)) || Input.GetKeyDown(KeyCode.Backspace)){
            Application.LoadLevel("title");
        }

        int fSize = 43;
        
        EZOpt titleLabel = new EZOpt("GUI.Label", fSize, 300, 100, Color.green, drp);
        titleLabel.italic = true;
        titleLabel.bold = true;
        EZGUI.placeTxt(titleLabel);

        EZGUI.placeTxt(new EZOpt("Place Text", fSize, 300, 200, Color.green, drp));
        EZGUI.flashTxt(new EZOpt("Flash Text", fSize, 300, 300, Color.green, drp));
        EZGUI.blinkTxt(new EZOpt("Blink Text", fSize, 300, 400, Color.green, drp));
        EZGUI.pulseTxt(new EZOpt("Pulse Text", fSize, 300, 500, Color.green, drp));

        titleLabel.str = "GUI.Button";
        titleLabel.x = 700;
        titleLabel.color = Color.red;
        EZGUI.placeTxt(titleLabel);

        EZGUI.placeBtn(new EZOpt("Place Button", fSize, 700, 200, Color.red, Color.yellow, btnActive, drp));
        EZGUI.flashBtn(new EZOpt("Flash Button", fSize, 700, 300, Color.red, Color.yellow, btnActive, drp));
        EZGUI.blinkBtn(new EZOpt("Blink Button", fSize, 700, 400, Color.red, Color.yellow, btnActive, drp));
        EZGUI.pulseBtn(new EZOpt("Pulse Button", fSize, 700, 500, Color.red, Color.yellow, btnActive, drp));


        EZOpt e = new EZOpt("By specifying a width and calling wrapTxt(), the text will wrap automatically when over a certain width.  Allowing text to fall to the next line automatically.", 45, 1300, 100);
        e.width = 400;
        EZGUI.wrapTxt(e);

    }
}
