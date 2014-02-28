using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

    delegate void State();
    State state;

    void Awake(){
        state = start;
    }

    void OnGUI(){
        EZGUI.init();

        EZGUI.placeTxt("EZGUI", 80, EZGUI.HALFW, 200, Color.yellow, new Color(0.1f, 0.1f, 0.1f));
        EZGUI.placeTxt("by Jon Wiedmann", 25, EZGUI.HALFW, 250);

        state();
    }

    void start(){
        if(EZGUI.flashBtn("Press Start", 55, EZGUI.HALFW, EZGUI.HALFH, Color.white, new Color(0.8f, 0.8f, 0.8f), new Color(0.1f, 0.1f, 0.1f)) || Input.GetKeyDown(KeyCode.Return)) {
            state = select;
        }
    }

    void select(){
        if(EZGUI.placeBtn("Campaign", 55, EZGUI.HALFW, EZGUI.HALFH - 100, Color.white, Color.green, new Color(0.1f, 0.1f, 0.1f))) {
            Application.LoadLevel("main");
        }

        if(EZGUI.placeBtn("Instructions", 55, EZGUI.HALFW, EZGUI.HALFH, Color.white, Color.green, new Color(0.1f, 0.1f, 0.1f))) {
            state = instructions;
        }

        if(EZGUI.placeBtn("Back", 55, EZGUI.HALFW, EZGUI.HALFH + 100, Color.white, Color.red, new Color(0.1f, 0.1f, 0.1f)) || Input.GetKeyDown(KeyCode.Backspace)) {
            state = start;
        }
    }

    void instructions(){
        if(EZGUI.pulseBtn("Back", 52, 85, 85, Color.white, Color.red, new Color(0.1f, 0.1f, 0.1f)) || Input.GetKeyDown(KeyCode.Backspace)) {
            state = select;
        }

        EZGUI.leftJustify = true;

        EZGUI.placeTxt("Pressing Back will activate the \"Back\" button.", 42, 50, EZGUI.HALFH - 100);
        EZGUI.placeTxt("Pressing Enter will activate the will activate the \"Press Start\" button.", 42, 50, EZGUI.HALFH);
    }
}
