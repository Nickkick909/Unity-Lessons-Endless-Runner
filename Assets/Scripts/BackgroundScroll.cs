using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float scrollSpeed = 0;
    float offset = 0;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        offset += Time.deltaTime * scrollSpeed;

        sprite.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
