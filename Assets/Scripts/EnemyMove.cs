using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
   
    [SerializeField]
    protected float speed = 1f;
    protected GameManager gameManager = null;


    protected virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime * gameManager.difficult);
        if (transform.position.y > gameManager.MaxPosition.y + 3) 
        {
            if(gameManager == null)
            {
                gameManager = FindObjectOfType<GameManager>();
            }
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if(gameManager==null)
            {
                gameManager = FindObjectOfType<GameManager>();
            }
            gameManager.AddScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

   

 
