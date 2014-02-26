using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

    enum State {START, SELECT, INSTRUCTIONS};
    State state = State.START;

    int slot = 0;

    void Update(){
        if(state == State.SELECT){
            float vert = Input.GetAxisRaw("Vertical");

            if(vert > 0){           // up

            }
            else if(vert < 0){      // down

            }
        }
    }

    void OnGUI(){
        EZGUI.init();

        EZGUI.placeTxt("EZGUI", 80, EZGUI.HALFW, 200, Color.yellow, Color.black);
        EZGUI.placeTxt("by Jon Wiedmann", 25, EZGUI.HALFW, 250);

        switch(state){
            case State.START:
                if(EZGUI.flashBtn("Press Start", 55, EZGUI.HALFW, EZGUI.HALFH, Color.white, new Color(0.8f, 0.8f, 0.8f), Color.black)){
                    state = State.SELECT;
                }

                break;
            case State.SELECT:
                if(EZGUI.placeBtn("Campaign", 55, EZGUI.HALFW, EZGUI.HALFH - 100, Color.white, Color.magenta, new Color(0.1f, 0.1f, 0.1f))) {
                    Application.LoadLevel("main");
                }

                if(EZGUI.placeBtn("Instructions", 55, EZGUI.HALFW, EZGUI.HALFH, Color.white, Color.cyan)) {
                    state = State.INSTRUCTIONS;
                }

                if(EZGUI.placeBtn("Back", 55, EZGUI.HALFW, EZGUI.HALFH + 100, Color.white, Color.red)){
                    state = State.START;
                }

                break;
            case State.INSTRUCTIONS:
                if(EZGUI.pulseBtn("Back", 55, 80, 80, Color.white, Color.green, Color.black)){
                    state = State.SELECT;
                }

                EZGUI.placeTxt("The Instructions here", 55, EZGUI.HALFW, EZGUI.HALFH);

                break;
        }
    }
}
