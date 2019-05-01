using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Russell
{
    public class Spinner_Model : CharacterBase
    {
        private WhosAround checkTarget;
        public float movementSpeed;
        private void Awake()
        {
            checkTarget = GetComponent<WhosAround>();
        }


        private void Update()
        {
            //if (checkTarget.whosAround.Count != 0)
            //{
            //    Target = checkTarget.whosAround[Random.Range(0, checkTarget.whosAround.Count)];
            //}
            //else Target = null;
            //Move();
            

        }
        
        public void Move()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * movementSpeed;
            
            Ray ray;
            ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            var origin = transform.position;
            if (Physics.Raycast(origin, Quaternion.AngleAxis(20f, transform.right) * transform.forward, out hit, 8f))
            {
                
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                if (Physics.Raycast(ray, out hit, 50f))
                {
                    
                    rb.AddForce(0, 0, movementSpeed * Time.deltaTime);
                    if (Physics.Raycast(origin, Quaternion.AngleAxis(45f, transform.up) * transform.forward,
                        out hit, 10f))
                        rb.transform.Rotate(0, -80 * Time.deltaTime, 0);
                    else if (Physics.Raycast(origin, Quaternion.AngleAxis(-45f, transform.up) * transform.forward,
                        out hit, 10f)) rb.transform.Rotate(0, 80 * Time.deltaTime, 0);

                    if (Physics.Raycast(origin, Quaternion.AngleAxis(90f, transform.up) * transform.forward,
                        out hit,
                        5f))
                        rb.transform.Rotate(0, -120 * Time.deltaTime, 0);
                    if (Physics.Raycast(origin, Quaternion.AngleAxis(-90f, transform.up) * transform.forward,
                        out hit,
                        5f))
                        rb.transform.Rotate(0, 120 * Time.deltaTime, 0);
                }
            }
        }
    }

}

