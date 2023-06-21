using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    PointTracker pointTracker;
    public ParticleSystem bounceEffect;
    public AudioSource bounceSound;
    public AudioSource redPickupSound;

    void Awake()
    {
        pointTracker = GameObject.Find("GameManager").GetComponent<PointTracker>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.transform.CompareTag("PickableItem"))
        {
            collision.gameObject.SetActive(false);
            pointTracker.SetPoints(100);
            redPickupSound.Play();
        }
        else if(collision != null && collision.transform.CompareTag("UnpickableItem"))
        {
            Instantiate(bounceEffect, collision.GetContact(0).point, Quaternion.Euler(-90f,0f,0f));
            bounceSound.Play();
        }
    }
}
