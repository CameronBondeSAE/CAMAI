using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auriel
{
   public class NearestNeighbours : MonoBehaviour
   {
       public List<CharacterBase> neighbours;
           
       // Start is called before the first frame update
       void Start()
       {
            //List<CharacterBase> neighbours = new List<CharacterBase>();
       }

       // Update is called once per frame
       void Update()
       {
           
       }

       private void OnTriggerEnter(Collider other)
       {
           neighbours.Add(new CharacterBase());
           
           foreach (CharacterBase character in neighbours)
           {
               Debug.Log("Someone is nearby");
           }
       }

       private void OnTriggerExit(Collider other)
       {
           neighbours.Remove(new CharacterBase());

           foreach (CharacterBase character in neighbours)
           {
               Debug.Log("Someone has moved away");
           }
       }
   }
}