﻿/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;


public class SaveLoad : MonoBehaviour {


    public List<int> list1 = new List<int>();
    public Vector3 xyz = new Vector3();
    private SaveData data;


	// Use this for initialization
	void Start () {

        Load();

	}
	
	// Update is called once per frame
	void Update () {
        //Q를 누르면 저장
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Save();
        }
	}

    public void Save()
    {
        if (!Directory.Exists(Application.dataPath + "/saves"))
            Directory.CreateDirectory(Application.dataPath + "/saves");
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.dataPath + "/saves/SaveData.dat");
        CopySaveData();
        bf.Serialize(file, data);
        file.Close();
    }

    public void CopySaveData()
    {
        data.list1.Clear();


        foreach (int i in list1)
        {
            data.list1.Add(i);
        }

        data.position = Vector3ToSerVector3(xyz);

    }

    public void Load()
    {
        if(File.Exists(Application.dataPath + "/saves/SaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/saves/SaveData.dat", FileMode.Open);
            data = (SaveData)bf.Deserialize(file);

            file.Close();
        }
    }

    public void CopyLoadData()
    {
        list1.Clear();
        foreach(int i in data.list1)
        {
            list1.Add(i);
        }

        xyz = SerVector3ToVector(data.position);

    }

    public static SerVector3 Vector3ToSerVector3(Vector3 V3)
    {
        SerVector3 SV3 = new SerVector3();
        SV3.x = V3.x;
        SV3.y = V3.y;
        SV3.z = V3.z;

        return SV3;

    }

    public static Vector3 SerVector3ToVector(SerVector3 SV3)
    {
        Vector3 V3 = new Vector3();
        V3.x = SV3.x;
        V3.y = SV3.y;
        V3.z = SV3.z;

        return V3;
    }
}

[System.Serializable]
public class SaveData
{
    public SerVector3 position;

    public List<int> list1 = new List<int>();

}

[System.Serializable]
public class SerVector3
{
    public float x;
    public float y;
    public float z;

}
*/

using UnityEngine;
using System.Collections;
//serialized 데이터 저장을 위해 필요한 namespace
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{

    public MoneyManager theMM;
    public PreferenceManager thePM;
    //public PlayerController thePC;
    public int money;        //A1 일반변수
    public int preference;  //A2 일반변수

    //
   // public PlayerData LocalCopyOfData;
   // public bool IsSceneBeingLoaded = false;
    //

    [Serializable] //B 직렬화가능한 클래스
    public class PlayerData
    {
        
        public int sceneID;
        public int money;
        public int preference;
        public float positionX, positionY, positionZ;


       //
       // public Vector3 playerLocation;
        //public Scene currentScene;
        //public string currentSceneName;
        //
             
    }

    /*[Serializable]
    public struct PlayerLocation
    {
        /// <summary>
        /// x component
        /// </summary>
        public float x;

        /// <summary>
        /// y component
        /// </summary>
        public float y;

        /// <summary>
        /// z component
        /// </summary>
        public float z;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rX"></param>
        /// <param name="rY"></param>
        /// <param name="rZ"></param>
        public PlayerLocation(float rX, float rY, float rZ)
        {
            x = rX;
            y = rY;
            z = rZ;
        }

        /// <summary>
        /// Returns a string representation of the object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}]", x, y, z);
        }

        /// <summary>
        /// Automatic conversion from SerializableVector3 to Vector3
        /// </summary>
        /// <param name="rValue"></param>
        /// <returns></returns>
        public static implicit operator Vector3(PlayerLocation rValue)
        {
            return new Vector3(rValue.x, rValue.y, rValue.z);
        }

        /// <summary>
        /// Automatic conversion from Vector3 to SerializableVector3
        /// </summary>
        /// <param name="rValue"></param>
        /// <returns></returns>
        public static implicit operator PlayerLocation(Vector3 rValue)
        {
            return new PlayerLocation(rValue.x, rValue.y, rValue.z);
        }
    }*/

    void Start()
    {
        theMM = FindObjectOfType<MoneyManager>();
        thePM = FindObjectOfType<PreferenceManager>();
        //thePC = FindObjectOfType<PlayerController>();
        //LoadData();
        //Debug.Log("loaded");
    }

    void Update()
    {
        //F5 키를 누르면 저장함수 호출
        if (Input.GetKeyDown(KeyCode.F5))
        {
          
            SaveData();
            Debug.Log("Saved" + money + preference);
            
        }


        
        if (Input.GetKeyDown(KeyCode.F6))
        {
          
            LoadData();
            Debug.Log("load game" + money + preference);
        }
        

    }

    


    public void SaveData()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/saves/SaveData.dat");
        //
        //FileStream file2 = File.Create(Application.dataPath + "/saves/SaveLocationData.dat");
        //
        PlayerData data = new PlayerData();

        //
        //PlayerLocation locationData = new PlayerLocation();
        //

        //A --> B에 할당

        /*//
        Scene currentScene = SceneManager.GetActiveScene();
        data.currentSceneName = currentScene.name;

        locationData.x = thePC.transform.position.x;
        locationData.y = thePC.transform.position.y;
        locationData.z = thePC.transform.position.z;
        //*/


        theMM.savedMoney = theMM.currentMoney;
        thePM.savedPreference = thePM.currentPreference;

        money = theMM.savedMoney;
        preference = thePM.savedPreference;

        data.money = money;
        
        data.preference = preference;

        //data.sceneID = Application.loadedLevel;
        data.sceneID = SceneManager.GetActiveScene().buildIndex;

        data.positionX = transform.position.x;
        data.positionY = transform.position.y;
        data.positionZ = transform.position.z;



        //B 직렬화하여 파일에 담기
        bf.Serialize(file, data);

        //
        //bf.Serialize(file2, locationData);
        //


        file.Close();
        //
        //file2.Close();
        //

        //PlayerPrefs를 이용한 플레이어 위치 저장. 추후 변경해야할듯.
       /*
        PlayerPrefs.SetFloat("locationX", transform.position.x);
        PlayerPrefs.SetFloat("locationY", transform.position.y);
        PlayerPrefs.SetFloat("locationZ", transform.position.z);
        */
    }

    public void LoadData()
    {
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.dataPath + "/saves/SaveData.dat", FileMode.Open);
        //
        //FileStream file2 = File.Open(Application.dataPath + "/saves/SaveLocationData.dat", FileMode.Open);
        //
        if (file != null && file.Length > 0)
        {
            //파일 역직렬화하여 B에 담기
            PlayerData data = (PlayerData)bf.Deserialize(file);
            //
            //PlayerLocation locationData = (PlayerLocation)bf.Deserialize(file2);
            //

            //B --> A에 할당

            /*//
            SceneManager.LoadScene(data.currentSceneName);
            thePC.transform.position = new Vector3(locationData.x, locationData.y, locationData.z);

            //*/

            money = data.money;
            preference = data.preference;
            theMM.SavedMoney();
            thePM.SavedPreference();
            transform.position = new Vector3(data.positionX, data.positionY, data.positionZ + 0.1f);



            int whichScene = data.sceneID;
            //Application.LoadLevel(whichScene);
            SceneManager.LoadScene(whichScene);

            Debug.Log(money);
            Debug.Log(preference);
        }

        file.Close();

        //PlayerPrefs를 이용한 플레이어 위치 불러오기. 추후 변경해야할듯.
        /*
        float x = PlayerPrefs.GetFloat("locationX");
        float y = PlayerPrefs.GetFloat("locationY");
        float z = PlayerPrefs.GetFloat("locationZ");

        transform.position = new Vector3(x, y, z);
        */
    }
}