using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerManager : MonoBehaviour
{
    public enum Finger
    {
        Thumb,
        Pointer,
        Middle,
        Ring,
        Pinky
    }

    [SerializeField] private List<Finger> hand;
    private Dictionary<Finger, int> FingerToInputNum = new Dictionary<Finger, int>();
    private Minigame currentMinigame;

    private void Start()
    {
        //Initialises hand
        hand.Add(Finger.Pinky);
        hand.Add(Finger.Ring);
        hand.Add(Finger.Middle);
        hand.Add(Finger.Pointer);
        hand.Add(Finger.Thumb);

        //Initialises FingerToInputNum Dictionary at 0
        foreach (Finger finger in hand)
        {
            FingerToInputNum.Add(finger, 0);
        }

        //TEMP CODE FOR TESTING
        FingerToInputNum[Finger.Middle] = 1;
    }

    public void RemoveFinger(Finger finger)
    {
        hand.Remove(finger);
        foreach(Finger _fing in hand)
        {
            Debug.Log(_fing);
        }
    }

    private void Update()
    {
        if(currentMinigame != null)
        {
            CheckInputs();
        }
    }

    //checks all the keys
    private void CheckInputs()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //returns the input number bound to pinky
            BroadcastInput(FingerToInputNum[Finger.Pinky]);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //returns the input number bound to ring
            BroadcastInput(FingerToInputNum[Finger.Ring]);
        }

        if (Input.GetKey(KeyCode.W))
        {
            //returns the input number bound to middle
            BroadcastInput(FingerToInputNum[Finger.Middle]);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //returns the input number bound to pointer
            BroadcastInput(FingerToInputNum[Finger.Pointer]);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            //returns the input number bound to thumb
            BroadcastInput(FingerToInputNum[Finger.Thumb]);
        }
    }

    //Converts input index into a function to send into the minigame
    private void BroadcastInput(int i)
    {
        switch (i)
        {
            case 1:
                Debug.Log("sending input 1 to minigame");
                currentMinigame.Input1();
                break;
            case 2:
                currentMinigame.Input2();
                break;
            case 3:
                currentMinigame.Input3();
                break;
            case 4:
                currentMinigame.Input4();
                break;
            default:
                Debug.LogWarning("BroadcastInput() int i is not a valid input number FingerManager.cs");
                break;
        }
    }

    private void ResetFingerInputs()
    {
        FingerToInputNum[Finger.Pinky] = 0;
        FingerToInputNum[Finger.Ring] = 0;
        FingerToInputNum[Finger.Middle] = 0;
        FingerToInputNum[Finger.Pointer] = 0;
        FingerToInputNum[Finger.Thumb] = 0;
    }
}
