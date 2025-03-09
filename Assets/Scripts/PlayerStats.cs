using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq.Expressions;
using UnityEngine.Rendering;


[System.Serializable]

public class PlayerStats
{

    [SerializeField] private string playerName;

    [SerializeField] private float playerSize;

    [SerializeField] private string playerColor; 

    public PlayerStats()
    {



    }

    public PlayerStats(string playerName, string playerSize, string playerColor)
    {

        this.playerName = playerName;

        if(!float.TryParse(playerSize, out this.playerSize))
        {

            Debug.Log("playerSize cant converted to  float ");
        }

        //  this.playerSize = playerSize;


        this.playerColor = playerColor;


    }






    public string ReturnPlayerSaveData()
    {

        string returnData = "Name: " + playerName + "    Size: " + playerSize + "    Color: " + playerColor;

        return returnData;

    }



    void Start()
    {
        





    }

    
    
    


    void Update()
    {
        





    }




}
