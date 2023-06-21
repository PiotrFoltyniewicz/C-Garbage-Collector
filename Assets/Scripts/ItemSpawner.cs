using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner instance;
    public GameObject itemPrefab;
    private List<GameObject> objectPool;
    public Sprite[] pickableItemSprites;
    public Sprite[] unpickableItemSprites;

    float spawnTimeLeft;

    GameDifficulty gameDifficulty;

    void Awake()
    {
        instance = this;
        objectPool = new List<GameObject>();
        gameDifficulty = GameObject.Find("GameManager").GetComponent<GameDifficulty>();
    }

    void Update()
    {
        spawnTimeLeft -= Time.deltaTime;
        if(spawnTimeLeft < 0)
        {
            spawnTimeLeft = gameDifficulty.GetItemSpawnTime();
            SpawnItem();
        }
    }

    GameObject GetPooledItem()
    {
        foreach(GameObject item in objectPool)
        {
            if (!item.activeInHierarchy)
            {
                return item;
            }
        }
        GameObject newItem = Instantiate(itemPrefab);
        objectPool.Add(newItem);
        newItem.SetActive(false);
        return newItem;
    }

    void SpawnItem()
    {
        GameObject item = GetPooledItem();
        item.transform.position = new Vector2(Random.Range(-6f, 6f), transform.position.y);
        item.SetActive(true);
        Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
        rb.SetRotation(Random.Range(-120f, 120f));
        rb.AddRelativeForce(Vector2.up * 300);
        rb.gravityScale = Random.Range(gameDifficulty.GetItemGravityScaleRange().Item1, gameDifficulty.GetItemGravityScaleRange().Item2);
        SetItem(gameDifficulty.GetItemRandomizer(), item);
    }

    void SetItem(int chance , GameObject item)
    {
        if (Random.Range(1,100) <= chance)
        {
            item.tag = "PickableItem";
            item.GetComponent<SpriteRenderer>().sprite = pickableItemSprites[Random.Range(0, pickableItemSprites.Length)];
        }
        else
        {
            item.tag = "UnpickableItem";
            item.GetComponent<SpriteRenderer>().sprite = unpickableItemSprites[Random.Range(0, unpickableItemSprites.Length)];
        }

    }
}
