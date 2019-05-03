using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarField : MonoBehaviour
{
    
    [SerializeField]
    public List<Star> stars = new List<Star>();

    public int maxNumOfStars;
    private SoftwareRenderer rend;

    public float zSpeed;
    
    // Start is called before the first frame update
    private void Start()
    {
        // setting reference to the renderer
        rend = SoftwareRenderer.renderer;
        
        // start the spawning of a shit ton of stars
        StartCoroutine(CreateStar());

        // subscribing to the render event to display all stars every frame
        SoftwareRenderer.Rendering += SetStars;
    }

    private void UpdateStarPosition()
    {
        // updating position of stars
        foreach (Star s in stars)
        {
            s.UpdatePosition(s.position.x, s.position.y ,s.position.z + (zSpeed * Time.deltaTime));
        }

        // deleting the oldest stars
        if (stars.Count > maxNumOfStars)
        {
            stars[stars.Count - 1] = null;
            stars.RemoveAt(stars.Count - 1);
        }
    }

    public void SetStars()
    {
        UpdateStarPosition();
        // loop to send pos of every star to renderer
        foreach (Star s in stars)
        {
            rend.Set3DSpecificPixel(s.position.x, s.position.y, s.position.z, s.colour);  
        }
    }

    public IEnumerator CreateStar()
    {
        // spawns stars randomly near the centre of the screen with random colours
        while (true)
        {
            Star s = new Star((0 + Random.Range(-rend.xSize * 0.3f, rend.xSize * 0.3f)),(0 + Random.Range(-rend.xSize * 0.3f, rend.xSize * 0.3f)), new Vector3Int(Random.Range(100, 255),Random.Range(100, 255),Random.Range(100, 255)));
            
            stars.Insert(0, s);
            
            yield return new WaitForSeconds(0.001f);
        }
    }
    
}
