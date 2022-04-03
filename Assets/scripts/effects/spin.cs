using UnityEngine;
using System.Collections;

public class spin : MonoBehaviour {


    [Range(-30,30)]public float velocity = 1;

    void Start()
    {
        InvokeRepeating("doSpin", 0, 0.025f);
    }

    // Update is called once per frame
    void doSpin()
    {
        gameObject.transform.Rotate(Vector3.forward * velocity * 2);

    }
}
