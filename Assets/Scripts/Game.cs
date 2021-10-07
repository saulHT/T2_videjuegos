using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text vidas_text;
    public Text enemigos_text;

    private int vidas_ = 3;
    private int enemigo = 5;
    void Start()
    {
        
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
        vidas_text.text = text;
    }
}
