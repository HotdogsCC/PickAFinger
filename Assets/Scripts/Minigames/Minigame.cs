using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    //how many virtual inputs the minigame takes
    protected int inputsNum = 0;

    protected MinigameManager minigameManager;

    private void Awake()
    {
        Debug.Log("hi");
        minigameManager = FindObjectOfType<MinigameManager>();
    }

    public abstract void Input1();
    public abstract void Input2();
    public abstract void Input3();
    public abstract void Input4();

}
