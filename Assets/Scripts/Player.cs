using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Game Game_;
    private Game2 game2_;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    public Text final_text;
    

    public float velocityX = 15;
    public float jumpForce = 40;

    public GameObject bala;
    public GameObject bala2;
    public Transform transfor_bala;

    private float tiempo = 0;
    private int restar=0;
    private int restar1=0;

    private const int ANIMATION_IDLE = 0;
    private const int ANIMATION_RUN = 1;
    private const int ANIMATION_JUMP = 2;
    private const int ANIMATION_SLIDE = 3;
    private const int ANIMATION_DEAD = 4;
    private const int ANIMATION_SHOOT = 5;
    private const int ANIMATION_RUN_SHOOT = 6;


    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Game_ = FindObjectOfType<Game>();
        game2_ = FindObjectOfType<Game2>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0,rb.velocity.y);
        changeAnimation(ANIMATION_IDLE);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(ANIMATION_RUN);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(ANIMATION_RUN);
        }

        if (Input.GetKey(KeyCode.X))
        {
            changeAnimation(ANIMATION_SLIDE);
        }
        if (Input.GetKey(KeyCode.C))
        {
            changeAnimation(ANIMATION_SHOOT);
        }

        if (Input.GetKey(KeyCode.V))
        {
            Debug.Log("cargando...");
            tiempo += Time.deltaTime;
           // Debug.Log(Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
   
                changeAnimation(ANIMATION_RUN_SHOOT);
                Instantiate(bala, transfor_bala.position, transfor_bala.rotation);
                Debug.Log("bala...1");
            if (tiempo>0.2)
            {
                changeAnimation(ANIMATION_RUN_SHOOT);
                Instantiate(bala2, transfor_bala.position, transfor_bala.rotation);
                Debug.Log("bala...2");
            }
            tiempo = 0;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // salta
            changeAnimation(ANIMATION_JUMP); // saltar
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="C")
        {
            game2_.reducir_vida();
            restar1++;
            Debug.Log("enemigo" + restar);
            if (restar1 == 3)
            {
                changeAnimation(ANIMATION_DEAD);
                Debug.Log("muerto");
            }
        }
        if (collision.gameObject.tag == "Enemigo")
        {
            Game_.reducir_vida();
            restar++;
            Debug.Log("enemigo"+restar);
            if (restar==3)
            {
                changeAnimation(ANIMATION_DEAD);
                Debug.Log("muerto");
            }
        }

        if (collision.gameObject.tag=="esena")
        {
            SceneManager.LoadScene("esena2");
        }

        if (collision.gameObject.tag=="1")
        {
            final_text.text = "Final del Juego ";

           // Instantiate(final_text, transfor_bala.position, transfor_bala.rotation);
        }
    }
    
    private void changeAnimation(int animation)
    {
        animator.SetInteger("estado", animation);
    }
}
