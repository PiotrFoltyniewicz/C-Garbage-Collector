using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBounces : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    int itemBounces = 0;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnEnable()
    {
        spriteRenderer.color = Color.white;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null && (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("UnpickableItem") || collision.gameObject.CompareTag("PickableItem")))
        {
            itemBounces += 1;
            ChangeColor();
        }
    }

    public int GetItemBounces()
    {
        return itemBounces;
    }

    void ChangeColor()
    {
        if (gameObject.tag == "UnpickableItem")
        {
            Color newColor = new Color(spriteRenderer.color.r - 0.1f, 1, spriteRenderer.color.b - 0.1f);
            spriteRenderer.color = newColor;
        }
    }
}
