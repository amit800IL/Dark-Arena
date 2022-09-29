using System.IO;
using UnityEngine;

public class Data : MonoBehaviour
{
    string saveFilePath;
    public GameData gameData;

    private void Awake()
    {
        gameData = new GameData();
        saveFilePath = Application.persistentDataPath + "/gameData.Json";
    }

    private void Start()
    {
        ReadFromJson();
    }
    public void WriteToJson()
    {
        gameData.savedBestKillCount = DataSaver.BestkillCountNum;
        gameData.savedBestWavesCount = DataSaver.bestWavesSurvivedNum;
        string JsonString = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFilePath, JsonString);

    }

    public void ReadFromJson()
    {
        if (File.Exists(saveFilePath))
        {
            string contentFromSaveFile = File.ReadAllText(saveFilePath);
            gameData = JsonUtility.FromJson<GameData>(contentFromSaveFile);

            DataSaver.BestkillCountNum = gameData.savedBestKillCount;
            DataSaver.bestWavesSurvivedNum = gameData.savedBestWavesCount;

        }
    }

    //public void RestoreJson()
    //{
    //  if (File.Exists(saveFilePath))
    //    {
    //        File.Delete(saveFilePath);
    //        string JsonString = JsonUtility.ToJson(saveFilePath);
    //        File.WriteAllText(saveFilePath, JsonString);
    //    }
    //}


    [System.Serializable]
    public class GameData
    {
        public int savedBestKillCount;
        public int savedBestWavesCount;
    }



}
