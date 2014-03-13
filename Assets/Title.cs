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

        EZGUI.placeTxt("EZGUI", 80, EZGUI.HALFW, 200, new EZOpt(Color.yellow, drp));
        EZGUI.placeTxt("by Jon Wiedmann", 25, EZGUI.HALFW, 250);

        state();
    }

    void start(){
        if(EZGUI.flashBtn("Press Start", 55, EZGUI.HALFW, EZGUI.HALFH, new EZOpt(Color.white, new Color(0.8f, 0.8f, 0.8f), new Color(0.7f, 0.7f, 0.7f), drp)) || Input.GetKeyDown(KeyCode.Return)) {
            state = select;
        }
    }

    void select(){
        EZOpt opt = new EZOpt(Color.white, Color.green, new Color(0,0.9f, 0), drp);

        if(EZGUI.placeBtn("Campaign", 55, EZGUI.HALFW, EZGUI.HALFH - 100, opt)) {
            Application.LoadLevel("main");
        }

        if(EZGUI.placeBtn("Instructions", 55, EZGUI.HALFW, EZGUI.HALFH, opt)) {
            state = instructions;
        }

        if(EZGUI.placeBtn("Back", 55, EZGUI.HALFW, EZGUI.HALFH + 100, new EZOpt(Color.white, Color.red, new Color(0.9f, 0, 0), drp)) || Input.GetKeyDown(KeyCode.Backspace)) {
            state = start;
        }
    }

    void instructions(){
        if(EZGUI.pulseBtn("Back", 52, 85, 85, new EZOpt(Color.white, Color.red, new Color(0.9f, 0, 0), drp)) || Input.GetKeyDown(KeyCode.Backspace)) {
            state = select;
        }

        EZOpt opt = new EZOpt();
        opt.leftJustify = true;

        EZGUI.placeTxt("Pressing Back will activate the \"Back\" button.", 42, 50, EZGUI.HALFH - 100, opt);
        EZGUI.placeTxt("Pressing Enter will activate the will activate the \"Press Start\" button.", 42, 50, EZGUI.HALFH, opt);
    }
}
