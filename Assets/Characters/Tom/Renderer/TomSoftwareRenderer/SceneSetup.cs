using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.XR.WSA.Input;

namespace Tom
{



    public class SceneSetup : MonoBehaviour
    {
        public int starNumber = 10;
        private float starSpeed;
        private SoftwareRenderer softwareRenderer;

        private void Awake()
        {
            softwareRenderer = GetComponent<SoftwareRenderer>();
        }


        public void CreateStar()
        {

            for (int i = 0; i < starNumber; i++)
            {

                Star star = new Star(new Vector3(0, 0, Random.Range(0, 10f)));
                star.position.x = Random.Range(-softwareRenderer.xSize, softwareRenderer.xSize);
                star.position.y = Random.Range(-softwareRenderer.ySize, softwareRenderer.ySize);
                softwareRenderer.ModifyBuffer((int) star.position.x, (int) star.position.y);
                softwareRenderer.starList.Add(star);

            }

        }

        private void Update()
        {
            //this blacks out the stars to refresh


            if (!Input.GetKey(KeyCode.H))
            {
                softwareRenderer.ColourAll();
            }

            foreach (Star star in softwareRenderer.starList)
            {
                //star movement/speed
                star.position.z += -Time.deltaTime;
                starSpeed = star.position.z += -Time.deltaTime;


                // perspective
                float xPerspective = star.position.x / (star.position.z);
                float yPerspective = star.position.y / (star.position.z);
                if (star.position.z < 1.0)
                {
                    star.position.z = Random.Range(0, 10f);
                }

                softwareRenderer.ModifyBuffer((int) xPerspective, (int) yPerspective);

                if (Input.GetKey(KeyCode.Space))
                {
                    star.position.z += -Time.deltaTime * 5;
                }



                if (Input.GetKeyDown(KeyCode.B))
                {
                    star.position.z += -Time.deltaTime;
                }
            }
        }
    }
}