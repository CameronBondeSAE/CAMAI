using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ChildScript : MonoBehaviour
{
    public int childHealth = 10; //how healthy the child is
    public int happy; //how happy the child ids
    public int hungry; //how hungry the child is

    private void Awake()
    {
        happy = UnityEngine.Random.Range(0, 10);
        hungry = UnityEngine.Random.Range(0, 10);
    }

    public void Feed(int food)
    {
        //set new hunger value
        hungry = hungry + food;
        //make sure it doesn't go over 10
        hungry = Mathf.Clamp(hungry, 0, 10);
    }

    public void Entertain(int fun)
    {
        //set new happy value
        happy = happy + fun;
        //make sure it doesn't go over 10
        happy = Mathf.Clamp(happy, 0, 10);
    }

    public void HealthSet(int health)
    {
        //set new childHealth value
        childHealth = childHealth + health;
        //make sure it doesn't go over 10, or below 0
        childHealth = Mathf.Clamp(childHealth, 0, 10);
    }
}
