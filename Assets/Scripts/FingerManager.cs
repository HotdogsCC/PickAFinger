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

    [SerializeField]
    private List<Finger> hand;

    private void Start()
    {
        hand.Add(Finger.Thumb);
        hand.Add(Finger.Pointer);
        hand.Add(Finger.Middle);
        hand.Add(Finger.Ring);
        hand.Add(Finger.Pinky);
    }

    public void RemoveFinger(Finger finger)
    {
        hand.Remove(finger);
        foreach(Finger _fing in hand)
        {
            Debug.Log(_fing);
        }
    }
}
