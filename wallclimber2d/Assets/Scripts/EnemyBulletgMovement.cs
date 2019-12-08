using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletgMovement : MonoBehaviour
{
    public float speed = 110f;
    public EbulletInstance ebs;

    // Start is called before the first frame update
    void Start()
    {
        ebs = GameObject.Find("EBulletInstance1").GetComponent<EbulletInstance>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 17.77f)
        {
            var temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            ebs.addbacktolist(gameObject);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Ground"))
       {
            ebs.addbacktolist(gameObject);
        }
    }
}
