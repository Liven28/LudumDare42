using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class Save : MonoBehaviour
{
    private CommunVariables scrCommunVariables;


    void Awake ()
    {
        scrCommunVariables = GetComponent<CommunVariables>();
        FntLoad();
    }


    public void FntSave()
    {
        if (Directory.Exists(Application.dataPath + "/Saves") == false)
        {
            Directory.CreateDirectory(Application.dataPath + "/Saves");
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/Saves" + "/Scores.dat");
        GameData dataSave = new GameData();

        dataSave.HightScore = scrCommunVariables.HightScore;

        bf.Serialize(file, dataSave);
        file.Close();
    }

    public void FntLoad()
    {
        if (scrCommunVariables == null)
        {
            scrCommunVariables = GetComponent<CommunVariables>();
        }
        if (File.Exists(Application.dataPath + "/Saves" + "/Scores.dat"))
        {
            BinaryFormatter bf2 = new BinaryFormatter();
            FileStream file2 = File.Open(Application.dataPath + "/Saves" + "/Scores.dat", FileMode.Open);
            GameData dataLoad = (GameData)bf2.Deserialize(file2);
            file2.Close();

            scrCommunVariables.HightScore = dataLoad.HightScore;
        }
        else
        {
            scrCommunVariables.HightScore = 0;        
        }
    }

    [Serializable]
    class GameData
    {
        public int HightScore;
    }
}
