using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float moveSpeed = 5f; // —корость движени€ противника
    public float followDistance = 5f; // –ассто€ние, на котором противник начнет следовать за игроком
    public float stoppingDistance = 2f; // –ассто€ние, на котором противник остановитс€ перед игроком
    public float followSpeed = 7f; // —корость следовани€ за игроком
    public Transform player; // —сылка на объект игрока

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // –ассчитываем вектор направлени€ к игроку
        Vector2 direction = player.position - transform.position;
        float distanceToPlayer = direction.magnitude;

        if (distanceToPlayer <= followDistance)
        {
            // ≈сли игрок находитс€ в зоне следовани€, противник начинает двигатьс€ в его сторону
            if (distanceToPlayer > stoppingDistance)
            {
                // ƒвижение к игроку
                Vector2 moveDirection = direction.normalized;
                rb.velocity = moveDirection * moveSpeed;
            }
            else
            {
                // ѕротивник останавливаетс€ перед игроком
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            // ѕротивник движетс€ случайным образом, если игрок находитс€ за пределами зоны следовани€
            rb.velocity = Random.insideUnitCircle.normalized * moveSpeed;
        }
    }
}
