using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameManager gameManager;

	private void Start()
	{
        gameManager = FindObjectOfType<GameManager>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            StartCoroutine(DestroyBird());
        }
        else if (collision.contacts[0].normal.y < 0.5)
        {
            StartCoroutine(DestroyBird());
        }


        IEnumerator DestroyBird()
        {
            yield return new WaitForSeconds(1.7f);
            Destroy(gameObject);
            gameManager.birdDestroy = true;
        }
    }
}

