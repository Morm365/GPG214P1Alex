using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UIElements;



public class PlayerOwnFiles : MonoBehaviour
{


    public PlayerStats currentSaveData = new PlayerStats();


    public string fileName = "CharacterSaveData.txt";


    public string textFileContents;

    void Start()
    {

        currentSaveData = new PlayerStats("GreenCircle", "1", "Green");

        WriteData(currentSaveData.ReturnPlayerSaveData());


        GetTextFileComp();

    }


    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Q))
        {

            WriteData(currentSaveData.ReturnPlayerSaveData());

        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            GetTextFileComp();

            if (!string.IsNullOrEmpty(textFileContents))
            {

                ParseCharacterInfo(textFileContents);


            }


        }

    }






    void ParseCharacterInfo(string characterInfo)
    {

        string[] valuesFromText = characterInfo.Split(new char[] { ':', ',' }, System.StringSplitOptions.RemoveEmptyEntries); 

        if(valuesFromText.Length % 2 != 0 )
        {

            Debug.LogError("Strange data");

            return;

        }

        Dictionary<string, string> characterInfoDictionary = new Dictionary<string, string>();                   //<key, access value>

        for(int i=0; i < valuesFromText.Length; i += 2)
        {

            string currentKey = valuesFromText[i];

            string currentValue = valuesFromText[i + 1];

            Debug.Log("Key: " + currentKey + " Value: " + currentValue);

            characterInfoDictionary.Add(currentKey, currentValue);

        }

        string characterName = characterInfoDictionary["Name"];
        string characterSize = characterInfoDictionary["Size"];
        string characterColor = characterInfoDictionary["Color"];

        currentSaveData = new PlayerStats(characterName, characterSize, characterColor);

    }











    void GetTextFileComp()
    {

        if(!string.IsNullOrEmpty(fileName))
        {

            string filePath = Path.Combine(Application.streamingAssetsPath, fileName);


            if(File.Exists(filePath))
            {

                textFileContents = File.ReadAllText(filePath);

                Debug.Log(textFileContents);
            }
            else
            {

                Debug.Log("file doesnt exist");

            }

        }
        else
        {

            Debug.Log("No file");

        }

    }







    void WriteData(string dataToWrite)
    {

        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        using (StreamWriter writer = new StreamWriter(filePath))
        {

            writer.WriteLine(dataToWrite);


        }



        
    }



}
