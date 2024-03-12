using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyCircle : MonoBehaviour
{
    public float speed = 5f; // —корость движени€ противника
    private bool movingRight = true; // ‘лаг дл€ определени€ направлени€ движени€

    void Update()
    {
        // ƒвижение вперед
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    // ќбработка столкновений
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ≈сли столкновение произошло с чем-то, кроме другого противника (или чего-то другого, что должно остановить движение), измен€ем направление
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            movingRight = !movingRight;
        }
    }
}