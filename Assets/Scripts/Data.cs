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

    public void WriteToJson()
    {

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


    [System.Serializable]
    public class GameData
    {
        public int savedBestKillCount;
        public int savedBestWavesCount;
    }



}
