using System.IO;
using UnityEngine;

public class Data : MonoBehaviour
{
    public GameData gameData;
    string saveFilePath;

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

    public void RestoreJson()
    {
        File.Delete(saveFilePath = Application.persistentDataPath + "/gameData.Json");
    }


    [System.Serializable]
    public class GameData
    {
        public int savedBestKillCount;
        public int savedBestWavesCount;
    }



}
