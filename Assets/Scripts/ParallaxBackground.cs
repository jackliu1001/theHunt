using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] Vector2 parallaxMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureSizeX;
    private float textureSizeY;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureSizeX = texture.width / sprite.pixelsPerUnit * transform.localScale.x; ;
        textureSizeY = texture.height / sprite.pixelsPerUnit * transform.localScale.y;
    }
    
    private void LateUpdate()
    {
        Vector3 deltaMove = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMove.x * parallaxMultiplier.x, deltaMove.y * parallaxMultiplier.y, deltaMove.z);
        lastCameraPosition = cameraTransform.position;
        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureSizeX)
        {
            float offsetX = (cameraTransform.position.x - transform.position.x) % textureSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetX, transform.position.y);
        }

        if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureSizeY)
        {
            float offsetY = (cameraTransform.position.y - transform.position.y) % textureSizeY;
            transform.position = new Vector3(transform.position.x, cameraTransform.position.y + offsetY);
        }
    }
}
