using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDropCatch : Minigame
{
    [Header("Game Objects")]
    [SerializeField] private GameObject itemDropping;
    [SerializeField] private GameObject itemCatcher;
    
    [Header("Item Drop")]
    [SerializeField] private Vector3 itemDropSpawn;
    [SerializeField] private float spawnRadius = 1.0f;
    [SerializeField] private float initialSpeed = 0.1f;
    [SerializeField] private float gravity = 1.0f;

    [Header("Item Catcher")]
    [SerializeField] private Vector3 itemCatchSpawn;
    [SerializeField] private float catchRange;
    [SerializeField] private float moveSpeed = 1.0f;

    private float dropSpeed = 0.0f;

    private void Start()
    {
        //makes the droplet spawn
        Vector3 randomXOffset = new Vector3(Random.Range(-spawnRadius, spawnRadius), 0, 0);
        itemDropping.transform.localPosition = itemDropSpawn + randomXOffset;

        dropSpeed = -initialSpeed;
    }

    private void Update()
    {
        CheckIfItemCaught();
        LowerDroplet();
    }

    void CheckIfItemCaught()
    {
        //check if item has reached the ground
        if (itemDropping.transform.position.y <= itemCatcher.transform.position.y)
        {
            //check if item is caught
            if (itemDropping.transform.position.x >= itemCatcher.transform.position.x - catchRange &&
                itemDropping.transform.position.x <= itemCatcher.transform.position.x + catchRange)
            {
                minigameManager.MinigameOver(true);
            }
            else
            {
                minigameManager.MinigameOver(false);
            }
        }
    }

    void LowerDroplet()
    {
        itemDropping.transform.Translate(0, dropSpeed * Time.deltaTime, 0);
        dropSpeed -= gravity * Time.deltaTime;
    }

    public override void Input1()
    {
        itemCatcher.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
    }

    public override void Input2()
    {
        itemCatcher.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }

    public override void Input3()
    {
        throw new System.NotImplementedException();
    }

    public override void Input4()
    {
        throw new System.NotImplementedException();
    }

    
}
