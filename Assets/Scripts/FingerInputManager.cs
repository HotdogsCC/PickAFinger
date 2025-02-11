using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerInputManager : MonoBehaviour
{
    private Minigame currentMinigame;

    private KeyCode[] keyCodes = {KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None};

    public void SetInput(int num, KeyCode key)
    {
        keyCodes[num] = key;
    }

    private void Update()
    {
        if(currentMinigame != null)
        {
            //sends out inputs
            if(Input.GetKey(keyCodes[0]))
            {
                currentMinigame.Input1();
            }
            if (Input.GetKey(keyCodes[1]))
            {
                currentMinigame.Input2();
            }
            if (Input.GetKey(keyCodes[2]))
            {
                currentMinigame.Input3();
            }
            if (Input.GetKey(keyCodes[3]))
            {
                currentMinigame.Input4();
            }
        }
    }

}
