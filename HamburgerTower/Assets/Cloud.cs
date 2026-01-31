using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1, 6);
        transform.position = new Vector3(24, Random.Range(-2, 3), 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < -24)
        {
            speed = Random.Range(1, 6);
            transform.position = new Vector3(24, Random.Range(-2, 3), 2);
        }
    }
}
