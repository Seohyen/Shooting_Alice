using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : BulletMove
{
    protected override void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y > gameManager.MaxPosition.y + 3f)
        {
            Destroy(gameObject);
        }
    }
}
