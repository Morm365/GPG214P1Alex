using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class TextureLoader : MonoBehaviour
{

    //  public string fileName = "Textures/Figure1.png";

    // public string folderPath = Application.streamingAssetsPath;

    public string folderPath;

    private string combinedFilePathLocation;

    //public string spriteName = "Textures/Figure1.png";


    public string[] spriteNames = { "Textures/Figure1.png", "Textures/Figure2.png", "Textures/Figure3.png" };

    public Image[] imageSlots;

    // public Image currentTriangleSprite;

    private string combinedTrianglesFilePath;
    

    

    void Start()
    {

        // combinedFilePathLocation = Path.Combine(folderPath, fileName);

        folderPath = Application.streamingAssetsPath;

        //combinedTrianglesFilePath = Path.Combine(folderPath, spriteName);



        // LoadTexture();

        //LoadSprite();

        LoadSprites();

    }


    //private void LoadTexture()
    //{

    //    if (File.Exists(combinedFilePathLocation))
    //    {

    //        byte[] spriteBytes = File.ReadAllBytes(combinedFilePathLocation);  // read all bytes

    //        Texture2D texture = new Texture2D(2, 2);         //temporary texture for holding inside

    //        texture.LoadImage(spriteBytes);

    //        GetComponent<Renderer>().material.mainTexture = texture;
            
    //    } 
    //    else
    //    {
    //        Debug.Log("Texture not found" + combinedFilePathLocation);
    //    }

    //}







    private void LoadSprites() 
    {

        //if (File.Exists(combinedTrianglesFilePath))
        //{

        //    byte[] imageBytes = File.ReadAllBytes(combinedTrianglesFilePath);  // read all bytes

        //    Texture2D texture = new Texture2D(2, 2);         //temporary texture for holding inside

        //    texture.LoadImage(imageBytes);

        //    // GetComponent<Renderer>().material.mainTexture = texture;

        //    currentTriangleSprite.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);


        //}
        //else
        //{
        //    Debug.Log("Texture not found" + combinedTrianglesFilePath);
        //}

        for (int i = 0; i < spriteNames.Length; i++)
        {

            string filePath = Path.Combine(folderPath, spriteNames[i]);

            if (File.Exists(filePath))
            {

                byte[] imageBytes = File.ReadAllBytes(filePath);

                Texture2D texture = new Texture2D(2, 2);

                texture.LoadImage(imageBytes);

                texture.Apply();





                imageSlots[i].sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

                imageSlots[i].rectTransform.sizeDelta = new Vector2(texture.width, texture.height);




            }



        }















    }









    void Update()
    {



        
    }
}
