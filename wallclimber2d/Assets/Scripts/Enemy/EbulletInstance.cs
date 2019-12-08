using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EbulletInstance : MonoBehaviour
{
    public List<GameObject> EnemyPoolist = new List<GameObject>();
    public GameObject ebullet;
    public float EbulletCount = 15f;
    public Transform E1bulletspawpos;
    public Transform E2bulletspawpos;
    public Transform E3bulletspawpos;
    public E1movement emov;
 

    // Start is called before the first frame update
    void Start()
    {
        instanctiationebullet();
    
    }

    // Update is called once per frame
    void Update()
    {
        
      

    }

    public void instanctiationebullet()
    {
        for (int i = 0; i < EbulletCount; i++)
        {
            var storeelist = Instantiate(ebullet, transform.position, Quaternion.identity);
            storeelist.SetActive(false);
            EnemyPoolist.Add(storeelist);
        }
    }

    public void e1bulletspawnpos()
    {
        EnemyPoolist[0].transform.position = new Vector2(E1bulletspawpos.transform.position.x, E1bulletspawpos.transform.position.y);
        var storeepos = EnemyPoolist[0];
        storeepos.SetActive(true);
        EnemyPoolist.RemoveAt(0);

    }
    public void addbacktolist(GameObject obk)
    {
        obk.SetActive(false);
        EnemyPoolist.Add(obk);
    }
}
