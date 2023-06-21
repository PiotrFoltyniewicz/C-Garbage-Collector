using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePickup : MonoBehaviour
{
    PointTracker pointTracker;
    PlayerHealth playerHealth;

    public ParticleSystem exceptions;
    public Sprite[] productionCode;
    AudioSource errorSource;
    Image prodImage;

    void Awake()
    {
        pointTracker = GameObject.Find("GameManager").GetComponent<PointTracker>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        prodImage = GameObject.Find("Canvas/ProductionCode").GetComponent<Image>();
        errorSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.CompareTag("UnpickableItem"))
        {
            float bouncesMultiplier = 1f + (float)collision.GetComponent<ItemBounces>().GetItemBounces() * 0.25f;
            pointTracker.SetPoints((int)(25 * bouncesMultiplier));
            collision.gameObject.SetActive(false);
        }
        else if(collision != null && collision.CompareTag("PickableItem"))
        {
            errorSource.Play();
            StartCoroutine(ChangeProdSprite());
            Instantiate(exceptions, new Vector2(collision.transform.position.x, -5f), Quaternion.Euler(-90f,0f,0f));
            playerHealth.TakeHealth();
            collision.gameObject.SetActive(false);
        }
    }

    IEnumerator ChangeProdSprite()
    {
        prodImage.sprite = productionCode[1];
        yield return new WaitForSeconds(0.2f);
        prodImage.sprite = productionCode[0];
    }
}
