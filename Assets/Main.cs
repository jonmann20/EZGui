using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    Color drp, btnActive;

    bool windowOpen = false, windowClosed = true;

    void Awake() {
        drp = new Color(0.1f, 0.1f, 0.1f);
        btnActive = new Color(1, 0.822f, 0.016f);
    }

    void OnGUI(){
        EZGUI.init();

        if(EZGUI.placeBtn("Back", 45, 85, 85, new EZOpt(Color.white, Color.red, new Color(0.9f, 0, 0), drp)).btn || Input.GetKeyDown(KeyCode.Backspace)) {
            Application.LoadLevel("title");
        }

        int fSize = 43;
        
        //--- Label
        EZOpt titleOpt = new EZOpt(Color.green, drp);
        titleOpt.italic = true;
        titleOpt.bold = true;
        EZGUI.placeTxt("GUI.Label", fSize, 250, 300, titleOpt);

        EZOpt lblOpt = new EZOpt(Color.green, drp);
        EZGUI.placeTxt("Place Text", fSize, 250, 400, lblOpt);
        EZGUI.flashTxt("Flash Text", fSize, 250, 500, lblOpt);
        EZGUI.blinkTxt("Blink Text", fSize, 250, 600, lblOpt);
        EZGUI.pulseTxt("Pulse Text", fSize, 250, 700, lblOpt);

        //--- Button
        titleOpt.color = Color.red;
        EZGUI.placeTxt("GUI.Button", fSize, 650, 300, titleOpt);

        EZOpt btnOpt = new EZOpt(Color.red, Color.yellow, btnActive, drp);
        EZGUI.placeBtn("Place Button", fSize, 650, 400, btnOpt);
        EZGUI.flashBtn("Flash Button", fSize, 650, 500, btnOpt);
        EZGUI.blinkBtn("Blink Button", fSize, 650, 600, btnOpt);
        EZGUI.pulseBtn("Pulse Button", fSize, 650, 700, btnOpt);

        //--- Wrap
        titleOpt.leftJustify = true;
        titleOpt.color = new Color(0.8f, 0.8f, 0.8f);
        EZGUI.placeTxt("wrapTxt()", fSize, 920, 300, titleOpt);

        EZGUI.wrapTxt("By specifying a width, the text will wrap automatically when over a certain width.  NOTE: text is left justified and top aligned.", 
            fSize, 
            920, 
            350, 
            400,
            new EZOpt((Color)titleOpt.color, drp)
        );

        //--- Window
        EZGUI.placeTxt("GUI.Window", fSize, 1600, 300, new EZOpt(Color.cyan, drp));

        if(windowClosed){
			windowOpen = EZGUI.placeBtn("Open Window", fSize, 1600, 500, new EZOpt(Color.cyan, new Color(0, 0.9f, 0.9f), new Color(0, 0.8f, 0.8f), drp)).btn;
        }

        if(windowOpen) {
            windowClosed = EZGUI.placeWindow("Player Info", 30, 1450, 375, 300, windowCallback, Color.black, new EZOpt(Color.cyan));
        }
    }

    void windowCallback(int windowID) {
        EZOpt e = new EZOpt();
        e.leftJustify = true;

        EZGUI.placeTxt("Username: freeCode", 28, 20, 100, e);
        EZGUI.placeTxt("# Kills: 100", 28, 20, 140, e);
        EZGUI.placeTxt("Perk: Invisibility", 28, 20, 180, e);
    }
}
