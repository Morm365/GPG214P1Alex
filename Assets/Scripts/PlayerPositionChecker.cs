using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerPositionChecker : MonoBehaviour
{

    public Transform player;

    private float timePerCheck = 20f; //interval

    private string path;



    void Start()
    {

        path = Path.Combine(Application.streamingAssetsPath, "PlayerInfo.txt");

        StartCoroutine(Position());


    }

    IEnumerator Position()
    {

        while(true)
        {

            yield return new WaitForSeconds(timePerCheck);        // wait before next writing


            WritePosition();

        }
            

    }

    void WritePosition()
    {

        string logEntry ="X= " + player.position.x + "Y= " + player.position.y;

        File.AppendAllText(path, logEntry + "\n");

    }
       

    void Update()
    {
        



    }
}
