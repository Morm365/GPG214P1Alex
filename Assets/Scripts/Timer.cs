using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;



[System.Serializable]


public class SaveInfo
{

    public int actualNumber;

}
 


public class Timer : MonoBehaviour
{

    public Text numbers;

    public int actualNumber = 0;

    public float ping = 0.6f;

    private float updatedTime = 0f;

    public float timerUp = 0f;

    //  private bool continuation = true;

    private string filePath;



    void Start()
    {
        filePath = Application.dataPath + "/persistentDataPath/actualNumber.json";

        LoadNumber();

        numbers.text = actualNumber.ToString();

    }

    


    void Update()
    {

      //  if (!continuation) return;

         timerUp += Time.deltaTime; 



        if (timerUp <= 100f && Time.time >= updatedTime)
        {
            updatedTime = Time.time + ping;

            // timerUp = 0f;
            // actualNumber = 0;

            actualNumber++;

            numbers.text = actualNumber.ToString();


        }

        if (actualNumber >= 100)
        {

            actualNumber = 0;

            timerUp = 0f;


        }


        if(Input.GetKeyDown(KeyCode.Q))
        {

            SaveNumber();

        }




    }


    void SaveNumber()
    {

            SaveInfo data = new SaveInfo { actualNumber = actualNumber };

            string json = JsonUtility.ToJson(data, true);

            File.WriteAllText(filePath, json);


        



    }



    void LoadNumber()
    {

        if (File.Exists(filePath))
        {

            string json = File.ReadAllText(filePath);

            SaveInfo data = JsonUtility.FromJson<SaveInfo>(json);

            actualNumber = data.actualNumber;

        }




    }






}
