using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
   
    [SerializeField]
    protected float speed = 10f;

    protected GameManager gameManager = null;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    protected virtual void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        CheckLimit();
    }

    private void CheckLimit()
    {

        if (transform.position.y < gameManager.MinPosition.y - 3f)
        {
            Despawn();
        }
    }


    protected void Despawn()
    {
        transform.SetParent(gameManager.poolManager.transform, false);
        gameObject.SetActive(false);
    }
}


   