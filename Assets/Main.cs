using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

    void OnGUI(){
        EZGUI.init();

        EZGUI.blinkTxt("Alert!!", 55, EZGUI.HALFW, EZGUI.HALFH, Color.red);
    }
}
