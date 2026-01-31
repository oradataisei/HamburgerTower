using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syokuzai : MonoBehaviour
{
    Rigidbody2D rb;
    bool down = false;
    [SerializeField] private Next next;
    // Start is called before the first frame update
    void Start()
    {
        next = FindObjectOfType<Next>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) && !down)
        {
            transform.position += Vector3.left * 32 * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.RightArrow) && !down)
        {
            transform.position += Vector3.right * 32 * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.Space) && !down)
        {
            down = true;
            rb.isKinematic = false;
            Invoke("Do", 1);
            next.COUNT++;
        }


        if (Input.GetKey(KeyCode.Escape) && !down)
        {
            next.WENT = true;
        }


        if ((next.WENT && !down) || (next.OUT && !down))
        {
            Destroy(this.gameObject);
        }
    }

    void Do()
    {
        next.GO = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            next.OUT = true;
        }
    }
}
