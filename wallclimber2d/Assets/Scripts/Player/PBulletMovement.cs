using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBulletMovement : MonoBehaviour

{
   public  PBulletInstance pb;
    public float speed = 25f;
    // Start is called before the first frame update
    void Start()
    {
        pb = GameObject.Find("Bulletinstance").GetComponent<PBulletInstance>();
    }

    // Update is called once per frame
    void Update()
    {
      
            if (transform.position.x <= 17.87f)
            {
                var temp = transform.position;
                temp.x += speed * Time.deltaTime;
                transform.position = temp;

            }
        else
        {
            pb.addbacktolist(gameObject);
        }

  
}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            pb.addbacktolist(gameObject);
        }
    }
}
