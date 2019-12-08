using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBulletInstance : MonoBehaviour
{
    public List<GameObject> Poolist = new List<GameObject>();
    public float count = 20f;
    public GameObject bullet;
    public Transform spawnposition;
    // Start is called before the first frame update
    void Start()
    {
        instanctiation(); 
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.F))
        //{
        //    spawn();
        //}
        if(Input.GetButtonDown("Fire1"))
        {
            spawn();
        }
        
    }
    public void instanctiation()
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(bullet, transform.position, Quaternion.identity);
            obj.SetActive(false);
            Poolist.Add(obj);
        }
    }

    public void spawn()
    {
        Poolist[0].transform.position= new Vector2(spawnposition.transform.position.x, spawnposition.transform.position.y);
        var temp = Poolist[0];
        temp.SetActive(true);
        Poolist.RemoveAt(0);

    }

    public void addbacktolist(GameObject o)
    {
        o.SetActive(false);
        Poolist.Add(o);
    
    }

}
