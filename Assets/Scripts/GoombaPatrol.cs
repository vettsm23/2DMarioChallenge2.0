using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaPatrol : MonoBehaviour
{
    public float moveSpeed;

    private AudioSource source;
    public AudioClip deathClip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;


    void Start()
    {
     

    }

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {

            moveSpeed *= -1;
        }

        {
            if (collision.collider.tag == "Player")
            {
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(deathClip);
                Debug.Log("I loved living");
                Destroy(gameObject, 0.25f);
            }
        }
    }

}