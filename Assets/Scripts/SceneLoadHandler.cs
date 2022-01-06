using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadHandler : SceneHandler
{
    public static int TargetTrigger = -1;
    [SerializeField] private GameObject playerPrefab;

    private void Start()
    {
        loadPlayer();
    }

    private void loadPlayer()
    {
        Transform player;
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            player = Instantiate(playerPrefab).transform;
        }

        FindObjectOfType<GameHandler>().GetSceneLoadTrigger(TargetTrigger).LoadObject(player);

    }
}
