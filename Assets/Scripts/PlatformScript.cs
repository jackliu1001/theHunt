using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private PlatformEffector2D effector;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.S))
        //    waitTime = 0.5f;

        //if (Input.GetKey(KeyCode.S))
        //    if (waitTime <= 0)
        //    {
        //        effector.rotationalOffset = 180f;
        //        waitTime = 0.5f;
        //    }
        //    else
        //        waitTime -= Time.deltaTime;

        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space))
        {
            effector.rotationalOffset = 180f;
            StartCoroutine(Platform());
        }
    }

    IEnumerator Platform()
    {
        yield return new WaitForSeconds(0.5f);
        effector.rotationalOffset = 0;
    }
}
