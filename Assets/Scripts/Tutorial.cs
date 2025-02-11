using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Image[] images;
    [SerializeField] private bool[] isImagesActive = { false, false, false, false, false };

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetKey(0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SetKey(1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SetKey(2);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            SetKey(3);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetKey(4);
        }
    }

    private void SetKey(int keyIndex)
    {
        images[keyIndex].color = Color.green;
        isImagesActive[keyIndex] = true;
        if(CheckImagesActive())
        {
            Debug.Log("good to go");
            Destroy(gameObject);
        }
    }

    private bool CheckImagesActive()
    {
        foreach(bool active in isImagesActive)
        {
            if(active == false)
            {
                return false;
            }
        }
        return true;
    }
}
