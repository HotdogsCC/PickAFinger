using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    private FingerManager fingerManager;

    [SerializeField] private List<GameObject> minigames;
    [SerializeField] private GameObject MinigameParent;

    private bool bIsGameRunning = false;

    private void Start()
    {
        fingerManager = FindObjectOfType<FingerManager>();
    }
    public void StartMinigame()
    {
        bIsGameRunning = true;

        //spawns random minigame from list
        GameObject selectedMinigame = minigames[Random.Range(0, minigames.Count)];
        minigames.Remove(selectedMinigame);
        Instantiate(selectedMinigame, MinigameParent.transform, false);
    }
    public void MinigameOver(bool bGameWon)
    {
        bIsGameRunning = false;
        fingerManager.ResetFingerInputs();

        if(bGameWon)
        {
            Debug.Log("GAME WON");
        }
        else
        {
            Debug.Log("game lost");
        }
    }
}
