using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tegan
{
   public class NearestNeighbours : MonoBehaviour
   {
       public List<CharacterBase> neighbours = new List<CharacterBase>();

       private void OnTriggerEnter(Collider other)
       {
           if (other.GetComponent<CharacterBase>())
           {
               neighbours.Add(other.GetComponent<CharacterBase>());
           }
          
           foreach (CharacterBase character in neighbours)
           {
               Debug.Log("Someone is nearby");
           }
       }

       private void OnTriggerExit(Collider other)
       {
           neighbours.Remove(other.GetComponent<CharacterBase>());

           foreach (CharacterBase character in neighbours)
           {
               Debug.Log("Someone has moved away");
           }
       }
   }
}