using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    void OnGUI(){
        EZGUI.init();

		EZGUI.placeTxt("GUI.Label", 55, 200, 100, Color.green, Color.black);
		EZGUI.placeTxt("Place Text", 55, 200, 200, Color.green, Color.black);
		EZGUI.flashTxt("Flash Text", 55, 200, 300, Color.green, Color.black);
		EZGUI.blinkTxt("Blink Text", 55, 200, 400, Color.green, Color.black);
		EZGUI.pulseTxt("Pulse Text", 55, 200, 500, Color.green, Color.black);

		EZGUI.placeTxt("GUI.Button", 55, 600, 100, Color.red, Color.black);
		EZGUI.placeBtn("Place Button", 55, 600, 200, Color.red, Color.yellow);
		EZGUI.flashBtn("Flash Button", 55, 600, 300, Color.red, Color.yellow);
		EZGUI.blinkBtn("Blink Button", 55, 600, 400, Color.red, Color.yellow);
		EZGUI.pulseBtn("Pulse Button", 55, 600, 500, Color.red, Color.yellow);
    }
}
