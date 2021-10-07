using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = player.position.x;
        var y = player.position.y + 2;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
