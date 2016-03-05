using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class GameControl : MonoBehaviour {
    public static GameControl control;

    public bool[] remainingPics;

    void Awake()
    {
        remainingPics = new bool[PickupPic.NUM_PICS];
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
        for (int i = 0; i < PickupPic.NUM_PICS; ++i)
        {
            remainingPics[i] = true;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/picsLeft.dat");

        gameData data = new gameData();
        data.remainingPics = remainingPics;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/picsLeft.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/picsLeft.dat", FileMode.Open);
            gameData data = (gameData)bf.Deserialize(file);
            file.Close();

            remainingPics = data.remainingPics;
        }
    }

        
}

[Serializable]
class gameData
{
    public bool[] remainingPics = new bool[PickupPic.NUM_PICS];
}
