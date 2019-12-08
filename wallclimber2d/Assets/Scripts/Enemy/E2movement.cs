using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class E2movement : MonoBehaviour
{
    float xpos;
    float ypos = -3.59f;
    public Rigidbody2D rb;

    public float distance;
    public float distancebwp;

    public Transform playerdist;
  public  EbulletInstance ebv;
    public Vector2 playdist;
    public Vector2 enemdist;

   
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("randomposi", 0.2f, 0.8f);
        Physics2D.queriesStartInColliders = false;
        ebv = GameObject.Find("EBulletInstance1").GetComponent<EbulletInstance>();

    
      
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);
     
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(xpos, ypos), 0.25f);
        
        
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitinfo.collider.gameObject.CompareTag("Player"))
        {
            Debug.DrawLine(transform.position, hitinfo.point, Color.red);
       
        }
        else
        {
            Debug.DrawLine(transform.position,transform.position+transform.right*distance, Color.green);
        }
        playdist = playerdist.gameObject.transform.position;
        enemdist = rb.gameObject.transform.position;
       distancebwp= Vector2.Distance(playdist, enemdist);
     if(distancebwp<3)
        {
            ebv.e1bulletspawnpos();
        }
     

 
  
    }
    public void randomposi()
    {
        xpos = Random.Range(-5.733f,1.51f);
    }
   
  
}
