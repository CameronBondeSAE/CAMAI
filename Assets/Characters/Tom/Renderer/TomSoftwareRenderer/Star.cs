using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tom
{



    [Serializable]
    public class Star
    {
        public Vector3 position;

        public Vector3Int colour;

        public Star(Vector3 position)
        {
            this.position = position;
        }
    }
}