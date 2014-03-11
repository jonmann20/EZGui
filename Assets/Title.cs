using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

    delegate void State();
    State state;

    Color drp;

    void Awake(){
        state = start;
        drp = new Color(0.1f, 0.1f, 0.1f);
    }

    void OnGUI(){
        EZGUI.init();

        EZGUI.placeTxt(new EZOpt("EZGUI", 80, EZGUI.HALFW, 200, Color.yellow, drp));
        EZGUI.placeTxt(new EZOpt("by Jon Wiedmann", 25, EZGUI.HALFW, 250));

        state();
    }

    void start(){
        if(EZGUI.flashBtn(new EZOpt("Press Start", 55, EZGUI.HALFW, EZGUI.HALFH, Color.white, new Color(0.8f, 0.8f, 0.8f), new Color(0.7f, 0.7f, 0.7f), drp)) || Input.GetKeyDown(KeyCode.Return)) {
            state = select;
        }
    }

    void select(){
        if(EZGUI.placeBtn(new EZOpt("Campaign", 55, EZGUI.HALFW, EZGUI.HALFH - 100, Color.white, Color.green, new Color(0, 0.9f, 0), drp))) {
            Application.LoadLevel("main");
        }

        if(EZGUI.placeBtn(new EZOpt("Instructions", 55, EZGUI.HALFW, EZGUI.HALFH, Color.white, Color.green, new Color(0, 0.9f, 0), drp))) {
            state = instructions;
        }

        if(EZGUI.placeBtn(new EZOpt("Back", 55, EZGUI.HALFW, EZGUI.HALFH + 100, Color.white, Color.red, new Color(0.9f, 0, 0), drp)) || Input.GetKeyDown(KeyCode.Backspace)) {
            state = start;
        }
    }

    void instructions(){
        if(EZGUI.pulseBtn(new EZOpt("Back", 52, 85, 85, Color.white, Color.red, new Color(0.9f, 0, 0), drp)) || Input.GetKeyDown(KeyCode.Backspace)) {
            state = select;
        }

        
        EZOpt e = new EZOpt("Pressing Back will activate the \"Back\" button.", 42, 50, EZGUI.HALFH - 100);
        e.leftJustify = true;
        EZGUI.placeTxt(e);

        e.str = "Pressing Enter will activate the will activate the \"Press Start\" button.";
        e.y = EZGUI.HALFH;
        EZGUI.placeTxt(e);
    }
}
