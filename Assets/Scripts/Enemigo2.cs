using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    private int conta1 = 0;
    private int conta2 = 2;
    private Game2 game2_;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        game2_ = FindObjectOfType<Game2>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-4, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.tag == "A")
        {

            conta1++;
            if (conta1==4)
            {
                Destroy(this.gameObject);
                game2_.reducir_enemigo(1);
               // conta1 = 0;
            }
            Debug.Log("disparo "+conta1);
           
            
        }
        if (collision.gameObject.tag == "B")
        {
            conta2++;
            if (conta2 ==4)
            {
                game2_.reducir_enemigo(2);
                Destroy(this.gameObject);
            }
            
            Debug.Log("menos 2");
        }
    }
}
