using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Spin : MonoBehaviour {


    [Range(-30, 30)] public float velocity = 1;
    [SerializeField] GameObject[] mirrors;
    private Vector2[] lastMirrorMove;
    void Start()
    {
        lastMirrorMove = new Vector2[mirrors.Length];
        InvokeRepeating("doSpin", 0, 0.025f);
    }

    // Update is called once per frame
    void doSpin()
    {
        gameObject.transform.Rotate(Vector3.forward * velocity * 2);
        for (int i=0;i<lastMirrorMove.Length; i++)
        {
            if (mirrors[i].activeInHierarchy)
            {
                mirrors[i].transform.Rotate(Vector3.forward * velocity * 2);
                lastMirrorMove[i] = Vector2.Lerp(lastMirrorMove[i], new Vector2(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f)), UnityEngine.Random.Range(0, 0.025f));
                mirrors[i].transform.Translate(lastMirrorMove[i]);
            }
            else
            {
                mirrors[i].transform.localPosition = Vector2.zero;
            }
        }
        

    }
}
