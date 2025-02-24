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

    
    private List<Finger> hand = new List<Finger>();
    private Dictionary<Finger, int> FingerToInputNum = new Dictionary<Finger, int>();
    [SerializeField] private Minigame currentMinigame;
    [SerializeField] private List<GameObject> fingerGameObjects;

    private void Start()
    {
        //Initialises hand
        hand.Add(Finger.Pinky);
        hand.Add(Finger.Ring);
        hand.Add(Finger.Middle);
        hand.Add(Finger.Pointer);
        hand.Add(Finger.Thumb);

        //Initialises FingerToInputNum Dictionary at 0
        ResetFingerInputs();

        //enables finger chopping
        SetFingerChopping(true);

        //TEMP CODE FOR TESTING
        FingerToInputNum[Finger.Ring] = 1;
        FingerToInputNum[Finger.Pointer] = 2;
    }

    public void RemoveFinger(Finger finger)
    {
        hand.Remove(finger);
        SetFingerChopping(false);
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

    //Resets finger input values, ready for the next game
    public void ResetFingerInputs()
    {
        FingerToInputNum[Finger.Pinky] = 0;
        FingerToInputNum[Finger.Ring] = 0;
        FingerToInputNum[Finger.Middle] = 0;
        FingerToInputNum[Finger.Pointer] = 0;
        FingerToInputNum[Finger.Thumb] = 0;
    }

    public void SetFingerChopping(bool bShouldChop)
    {
        foreach (var finger in fingerGameObjects)
        {
            finger.GetComponent<Outline>().enabled = bShouldChop;
            finger.GetComponent<FingerSelect>().enabled = bShouldChop;
        }
    }
}
