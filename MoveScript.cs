using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveScript : MonoBehaviour
{
    [Range(0,10)]
    public float Speed = 3;
    public float DirectionX, DirectionY;
    [SerializeField]
    public SpriteRenderer sr;
    [SerializeField]
    public Rigidbody2D rb;
    public TextMeshProUGUI ShowCounter;
    [HideInInspector]
    public bool CanJump;
    [Space(100)]
    [Header("Наше количество звёзд")]
    public int Counter;
    public bool isGround;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        ShowCounter.text = $"Количество собранных звёзд {Counter}";
    }

    void Update()
    {
        MoveAndJump();
    }
    void MoveAndJump()
    {
        DirectionX = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(DirectionX, 0);
        transform.Translate(movement * Speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround == true)
            {
                rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
                isGround = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Действие для тега Stars
        if (collision.gameObject.tag == "Stars")
        {
            // Визуализируем подбирание звезды
            Destroy(collision.gameObject);
            // Считаем количество собранных звёзд
            Counter++;
            // Выводим текст с кол-вом собранных звёзд
            ShowCounter.text = $"Количество собранных звёзд {Counter}";
        }
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
