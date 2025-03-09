using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class FileSystem : MonoBehaviour
{







    void Start()
    {

        



        string assetPath = Application.dataPath;
        Debug.Log("Asset Path: " + assetPath);





        //        PERSISTANT

        string persistentPath = Application.persistentDataPath;
        Debug.Log("Persistent Path: " + persistentPath);






        //           STREAMINGASSETS

        //string streamingAssetsPath = Application.streamingAssetsPath;

        string streamingAssetsPath = Path.Combine(assetPath, "StreamingAssets");

        if (Directory.Exists(streamingAssetsPath))             //check before getting access exists on not
        {

            Debug.Log("StreamingAssets Patch: " + streamingAssetsPath);
            
        }

        else // dont exists
        {
            Debug.Log("StreamingAssets dont exists ");

            Directory.CreateDirectory(Path.Combine(Application.dataPath, "StreamingAssets")); //create it (StreamingAssets folder)

         //   Directory.CreateDirectory(streamingAssetsPath));

            Debug.Log("StreamingAssets Patch: " + streamingAssetsPath);

        }

        if(File.Exists(Path.Combine(Application.streamingAssetsPath, "PlayerInfo.txt")))
        {

            Debug.Log("PlayerInfo exists ");

        }

        else
        {

            File.CreateText(Path.Combine(Application.streamingAssetsPath, "PlayerInfo.txt"));
            
            Debug.Log("PlayerInfo created ");

        }

        //        EDITOR  



        // string editorPath = "Assets/Editor/";

        string editorPath = Path.Combine(Application.dataPath, "Editor"); 

       // string editorPath = Application.editorPath;

        if (Directory.Exists(editorPath))             //check before getting access exists on not
        {

            Debug.Log("Editor Patch: " + editorPath);

        }

        else // dont exists
        {

            Directory.CreateDirectory(Path.Combine(Application.dataPath, "Editor")); //create it (Editot folder)
            Debug.Log("Editor Patch: " + editorPath);

        }




        //             RESOURCES

        //string resourcesPath = Path.Combine(Application.dataPath, "Resources");
        //string resourcesPath = Application.resourcesPath;
        string resourcesPath = "Assets/Resources/";
        Debug.Log("Resources Patch: " + resourcesPath);

       // Object dronePrefab = Resources.Load("Drone.prefab");

        GameObject dronePrefab = Resources.Load<GameObject>("Drone");

        if (dronePrefab == null)
        {
            Debug.Log("Error no drone ");


        }

        else
        {
            Debug.Log(" drone ");
            GameObject droneInstance = Instantiate(dronePrefab, new Vector3(0, 3, 0), Quaternion.identity);

        }

        //if (File.Exists(Path.Combine(Application.resourcesPath, "DroneInfo.txt")))
        //{

        //    Debug.Log("DroneInfo exists");

        //}

        //else
        //{

        //    //File.CreateText(Path.Combine(Application.resourcesPath, "DroneInfo.txt"));
        //    //Debug.Log("DroneInfo exists");

        //}






        string filePath = Path.Combine(Application.dataPath, "example.txt");



    }




    void Update()
    {




    }



}
