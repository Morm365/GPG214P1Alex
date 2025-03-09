using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;



public class Move : MonoBehaviour
{


    public float speed = 2f;

    private Rigidbody2D person;

    private Vector3 move;

    private string savePath; 

    private Vector2 startPosition = new Vector2(0, 0);





    void Start()
    {

        person = GetComponent<Rigidbody2D>();

        // savePath = Path.Combine(Application.persistentDataPath, "player_save.json");

        savePath = Application.dataPath + "/persistentDataPath/playerSavedPosition.json";

        Debug.Log("Save path: " + savePath);

        LoadPosition();

    }

    

    void Update()
    {

        move.x = Input.GetAxisRaw("Horizontal");

        move.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Q))
        {

            SavePosition();

            Debug.Log("Position saved");

        }


    }


    //void OnAplplicationQuit()  //
    //{

    //    SavePosition();

    //}



        void SavePosition()
        {
            Vector2 position = transform.position;

            string json = JsonUtility.ToJson(position);

            File.WriteAllText(savePath, json);
       
        }





    void LoadPosition()
    {

        if (File.Exists(savePath))
        {

            string json = File.ReadAllText(savePath);

            Vector2 position = JsonUtility.FromJson<Vector2>(json);

            transform.position = position;
            
        }

        else
        {

            transform.position = startPosition;
            
        }
    }






    void FixedUpdate()
    {

        person.velocity = move.normalized * speed;


    }



}
