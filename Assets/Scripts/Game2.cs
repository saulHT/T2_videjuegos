using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game2 : MonoBehaviour
{
    public GameObject player;
    public Player player_;

    public Text vida_text;
    public Text enemigos_text;
    public Text tiempo_text;

    private int vidas_ = 3;
    private int enemigo= 6;
    public float tiempo = 0;
    void Start()
    {
        tiempo_text.text = "Tiempo: 00:00";
    }

    private void Update()
    {
        
    }
    public string tiempo_formato()
    {
        
        string minuto = Mathf.Floor(tiempo/60).ToString("00");
        return  minuto;
    }

    public void reducir_enemigo(int vala)
    {
        enemigo -= 1;
        maximo_enemigo(vala);
    }

    public void maximo_enemigo(int vala)
    {
        var text = "Enemigo: ";
        

        for (var i = 0; i < enemigo; i++)
        {
            text += "I";
        }
        enemigos_text.text = text;
    }

    public void reducir_vida()
    {
        vidas_ -= 1;
        vidas_maximos();
    }
    public void vidas_maximos()
    {
        var text = "vidas: ";
        for (var i = 0; i < vidas_; i++)
        {
            text += "I";
        }
        vida_text.text = text;
    }


}
