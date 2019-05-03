using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Experimental.UIElements;


namespace Tom
{

    public class SoftwareRenderer : MonoBehaviour
    {

        public int xSize, ySize;
        public Renderer quadRenderer;
        private Texture2D tex;
        public int arrayNumber;
        public int xCoordinate = 1;
        public int yCoordinate;
        public int textureArea;
        public SceneSetup sceneSetup;
        public int timesByThree;
        public byte redValue;
        public byte greenValue;
        public byte blueValue;
        [SerializeField] [HideInInspector] public byte[] backBuffer;

        public List<Star> starList;

        private void Awake()
        {

            sceneSetup = GetComponent<SceneSetup>();
        }

        private void Start()
        {
//        Star s = new Star(5,5,0);

            // generating texture and back buffer
            tex = new Texture2D(xSize, ySize, TextureFormat.RGB24, false);
            backBuffer = new byte[(xSize * ySize) * 3];

            tex.filterMode = FilterMode.Point; //turns off blur for debugging
            quadRenderer.material.mainTexture = tex;


            sceneSetup.CreateStar();



        }

        // Update is called once per frame
        private void Update()
        {
            //ModifyColours();

            // ColourAll();

            //setting the array number with xCoordinate and y Coordinate input



            //loading byte array into texture
            tex.LoadRawTextureData(backBuffer);
            tex.Apply(false);


            // FindCoordinate();

        }


        public void MoveStars()
        {

        }


        public void ModifyBuffer(int x, int y)
        {
            xCoordinate = x + xSize / 2;
            yCoordinate = y + ySize / 2;
            arrayNumber = ((yCoordinate * xSize) + xCoordinate) * 3;

            //CHANGE THIS
            //MAKE IT NOT PRINT IF IT BIGGER THAN THE X, SAME FOR Y. MAYBE NEED TO CHECK THE NEGATIVE NOW.
            if (xCoordinate > -1 && xCoordinate < xSize && yCoordinate > -1 && yCoordinate < ySize)
            {
                backBuffer[arrayNumber] = redValue;
                backBuffer[arrayNumber + 1] = greenValue;
                backBuffer[arrayNumber + 2] = blueValue;

            }



        }


        public void ColourAll()
        {
            //textureArea = xSize * ySize;
            for (int arrayNumber = 0; (arrayNumber < backBuffer.Length); arrayNumber = arrayNumber + 3)
            {
                //if (arrayNumber >= 0 && arrayNumber < backBuffer.Length && xCoordinate < xSize)
                {
                    backBuffer[arrayNumber] = 0;
                    backBuffer[arrayNumber + 1] = 0;
                    backBuffer[arrayNumber + 2] = 0;
                }
            }


        }


    }

}


