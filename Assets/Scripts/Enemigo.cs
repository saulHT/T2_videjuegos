using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private int conta1 = 0;
   // private int conta2 = 2;
    private Game game_;
    private Rigidbody2D rb;
    private bool a = false;
    private bool b = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        game_ = FindObjectOfType<Game>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(-5, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="A")
        {
            conta1++;
            if (conta1 == 3)
            {
                Debug.Log("menos 1");
                game_.reducir_enemigo(1);
                Destroy(this.gameObject);
                a = true;
            }
                
        }
        if (collision.gameObject.tag=="B")
        {
            b = true;
            game_.reducir_enemigo(2);
            Destroy(this.gameObject);

            Debug.Log("menos 2");
        }
        if (a==true && b==true)
        {
            game_.reducir_enemigo(2);
            Destroy(this.gameObject);
        }
        
    }
}
