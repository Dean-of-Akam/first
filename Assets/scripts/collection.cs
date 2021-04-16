using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collection : MonoBehaviour
{
    // Start is called before the first frame update
    public void Cherry_Death(){

        FindObjectOfType<playerController>().CherryCount();
        
        Destroy(gameObject);

    }
      public void Gem_Death(){

        FindObjectOfType<playerController>().GemCount();
        
        Destroy(gameObject);

    }

}
