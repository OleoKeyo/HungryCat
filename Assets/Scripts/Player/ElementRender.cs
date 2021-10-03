using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementRender : MonoBehaviour
{
    void Start()
    {
        EventManager.OnElementAddToInventoryEvent += ChangeSprite;
    }

    private void ChangeSprite(Sprite sprite)
    {
        var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            if (spriteRenderers[i].sprite == null)
            {
                spriteRenderers[i].sprite = sprite;
                break;
            }
        }
    }
}
