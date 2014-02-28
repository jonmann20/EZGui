using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    void OnGUI(){
        EZGUI.init();

        if(EZGUI.placeBtn("Back", 45, 85, 85, Color.white, Color.red, Color.black) || Input.GetKeyDown(KeyCode.Backspace)){
            Application.LoadLevel("title");
        }

        int fSize = 43;

        EZGUI.placeTxt("GUI.Label", fSize, 300, 100, Color.green, Color.black);
        EZGUI.placeTxt("Place Text", fSize, 300, 200, Color.green, Color.black);
        EZGUI.flashTxt("Flash Text", fSize, 300, 300, Color.green, Color.black);
        EZGUI.blinkTxt("Blink Text", fSize, 300, 400, Color.green, Color.black);
        EZGUI.pulseTxt("Pulse Text", fSize, 300, 500, Color.green, Color.black);
        EZGUI.wrapTxt("Wrapping Text over a certain width will fall to the next line automatically", fSize, 300, 500, 200, Color.green, Color.black);

        EZGUI.placeTxt("GUI.Button", fSize, 700, 100, Color.red, Color.black);
        EZGUI.placeBtn("Place Button", fSize, 700, 200, Color.red, Color.yellow);
        EZGUI.flashBtn("Flash Button", fSize, 700, 300, Color.red, Color.yellow);
        EZGUI.blinkBtn("Blink Button", fSize, 700, 400, Color.red, Color.yellow);
        EZGUI.pulseBtn("Pulse Button", fSize, 700, 500, Color.red, Color.yellow);
    }
}
