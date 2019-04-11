using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetsFood : MonoBehaviour
{
    public string foodName;
    public bool useable = true;//basically if david can get to it or not
    public int hunger; //how much hunger the food takes
    public int health; //how healthy the food is
    public int cost; //how much the food costs
    
    //script to destory self
    public void PickedUp()
    {
        Destroy(this);
    }

}
