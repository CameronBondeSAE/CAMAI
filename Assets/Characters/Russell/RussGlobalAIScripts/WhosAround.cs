using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhosAround : MonoBehaviour
{
    public List<CharacterBase> whosAround = new List<CharacterBase>();

    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<CharacterBase>())
        {
            whosAround.Add(other.GetComponent<CharacterBase>());
            //numberOfPlayers = whosAround.Count;
        }
    }
    private void OnTriggerExit(Collider other)
    { 
        whosAround.Remove(other.GetComponent<CharacterBase>());  
        //numberOfPlayers = whosAround.Count;
    }
}
