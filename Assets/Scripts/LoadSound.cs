using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class LoadSound : MonoBehaviour
{
    //public string fileName = "Sound1.wav";
    //public string fileName = "Sound2.wav";
    //public string fileName = "Sound3.wav";

    public string folderName = "Sounds";

    private string combinedFilePath1;
    private string combinedFilePath2;
    private string combinedFilePath3;

    private AudioSource audioSource;

    private AudioClip musClip1;
    private AudioClip musClip2;
    private AudioClip musClip3;


    void Start()
    {

        combinedFilePath1 = Path.Combine(Application.streamingAssetsPath, folderName, "Sound1.wav");
        combinedFilePath2 = Path.Combine(Application.streamingAssetsPath, folderName, "Sound2.wav");
        combinedFilePath3 = Path.Combine(Application.streamingAssetsPath, folderName, "Sound3.wav");


        audioSource = GetComponent<AudioSource>();

        if(audioSource == null)
        {

            Debug.Log("no audio");

            return;

        }

        //LoadSoundFromFile();

        musClip1 = LoadSoundFromFile(combinedFilePath1);

        musClip2 = LoadSoundFromFile(combinedFilePath2);

        musClip3 = LoadSoundFromFile(combinedFilePath3);


    }




    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.R))
        {

            PlaySound(musClip1);

        }


        if (Input.GetKeyDown(KeyCode.Q))
        {

            PlaySound(musClip2);

        }


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {

            PlaySound(musClip3);

        }
    }



    AudioClip LoadSoundFromFile(string filePath)
    {

        //if (File.Exists(combinedFilePath))
        //{

            // byte[] audioData = File.ReadAllBytes(combinedFilePath);        //store data in array

            byte[] fileBytes = File.ReadAllBytes(filePath);

            int headerOffset = 44;  //head of the raw file

            int channels = BitConverter.ToInt16(fileBytes, 22);

            int sampleRate = BitConverter.ToInt32(fileBytes, 24);

            int sampleCount = (fileBytes.Length - headerOffset) / 2 / channels;

            /*float[] floatArray = new float[audioData.Length / 2];*/    // conversation from byte array to float array  (2 bits in byte)

            float[] audioData = new float[sampleCount * channels];



            //for (int i = 0; i < floatArray.Length; i++)
            //{

            //    short bitValue = System.BitConverter.ToInt16(audioData, i * 2);

            //    floatArray[i] = bitValue / 32768.0f;

            //}

            for (int i = 0; i < sampleCount * channels; i++)
            {

                short sample = BitConverter.ToInt16(fileBytes, headerOffset + i * 2);

                //floatArray[i] = bitValue / 32768.0f;

                audioData[i] = sample / 32768.0f;

            }



            // musClip = AudioClip.Create("Mus", floatArray.Length, 1, 44100, false);

            // musClip = AudioClip.Create("Mus", sampleCount, channels, sampleRate, false);

            // musClip.SetData(floatArray, 0);

            //musClip.SetData(audioData, 0);

            // audioSource.clip = musClip;

            AudioClip clip = AudioClip.Create(Path.GetFileName(filePath), sampleCount, channels, sampleRate, false);

            clip.SetData(audioData, 0);


            return clip;

        //}




        //else
        //{

        //    Debug.Log("no audio in " + combinedFilePath);

        //}

    }



    void PlaySound(AudioClip clip)
    {
        

        if (clip != null)
        {
            audioSource.clip = clip;

            audioSource.Play();
        }


     //   audioSource.PlayOneShot(musClip);



    }


}
