using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadTrigger : MonoBehaviour
{
    [SerializeField] private Transform sceneLoadLocator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            FindObjectOfType<GameHandler>().LoadSceneTrigger(this);
    }

    public void LoadObject (Transform obj)
    {
        obj.position = sceneLoadLocator.position;
    }
}
