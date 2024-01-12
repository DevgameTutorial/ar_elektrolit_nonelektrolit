using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetSiblingIndexes(){
        gameObject.SetActive(false);
        transform.parent.GetChild(transform.GetSiblingIndex()+1).gameObject.SetActive(true);
    }
}
