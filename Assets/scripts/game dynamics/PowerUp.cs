using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Ball.Mode type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            collision.gameObject.GetComponent<Ball>().changeMode(type);
        }
    }
}
