using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public float HP;
    //public GameObject player = this.GameObject;
    // Start is called before the first frame update
    void Start()
    {
         HP = 1000f;
    }
    
        
        
    

    // Update is called once per frame
    void Update()
    {
        if (HP < 1)
        {
            Debug.Log(gameObject.name + " defeated");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            enabled = false;
        }
        
    }
}
