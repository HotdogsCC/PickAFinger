using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject selectCam;
    [SerializeField] private GameObject chopCam;
    
    // Start is called before the first frame update
    void Start()
    {
        selectCam.SetActive(true);
        chopCam.SetActive(false);
    }

    public void EnableCam(GameObject cam)
    {
        DisableCams();
        cam.SetActive(true);
    }
    
    private void DisableCams()
    {
        selectCam.SetActive(false);
        chopCam.SetActive(false);
    }
}
