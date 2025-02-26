using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KnifeAnimation : MonoBehaviour
{
    [SerializeField] private GameObject knifeObj;
    [SerializeField] private Transform targetStabLocation;
    [SerializeField] private float moveSpeed;

    private bool bIsStabbing = false;

    // Update is called once per frame
    void Update()
    {
        CheckIfShouldStab();
    }

    public void StartStabbing()
    {
        bIsStabbing = true;
    }

    void CheckIfShouldStab()
    {
        //early return if the knife animation shouldnt play
        if (!bIsStabbing) return;
        
        //moves knife down
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y - (moveSpeed * Time.deltaTime),
            transform.position.z);
        //checks if knife has reached stab location
        if (transform.position.y <= targetStabLocation.position.y)
        {
            //stops stab animation from playing
            bIsStabbing = false;
        }
    }
}
