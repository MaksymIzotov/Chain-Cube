using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad Instance;

    List<ItemStoredInfo> items = new List<ItemStoredInfo>();
    string saveFile;
    void Awake()
    {
        saveFile = Application.persistentDataPath + "/gamedata.json";
        Instance = this;
    }

    public void SaveData()
    {
        if (File.Exists(saveFile))
            File.Delete(saveFile);

        items.Clear();

        foreach (GameObject n in GameObject.FindGameObjectsWithTag("Cube"))
        {
            if (n.transform.parent != null) { continue; }

            CubeInfo info = n.GetComponent<CubeController>().info;

            ItemStoredInfo item = new ItemStoredInfo();
            item.id = info.index;
            item.x = n.transform.position.x;
            item.y = n.transform.position.y;
            item.z = n.transform.position.z;

            item.rotX = n.transform.rotation.x;
            item.rotY = n.transform.rotation.y;
            item.rotZ = n.transform.rotation.z;
            item.rotW = n.transform.rotation.w;

            items.Add(item);
        }

        string json = JsonConvert.SerializeObject(items);

        File.WriteAllText(saveFile, json);

        PlayerPrefs.SetInt("IsSaved", 1);
        PlayerPrefs.SetInt("Score", Gameplay.Instance.score);
    }

    public void LoadData()
    {
        if (File.Exists(saveFile))
        {
            string fileContents = File.ReadAllText(saveFile);

            items = JsonConvert.DeserializeObject<List<ItemStoredInfo>>(fileContents);
        }
        Gameplay.Instance.score = PlayerPrefs.GetInt("Score");

        CubesSpawner.Instance.LoadState(items);
    }


    #region Handle OnQuit Save
    private void OnApplicationPause(bool pause)
    {
        if (Gameplay.Instance.gameState == Gameplay.STATE.MENU) { return; }

        SaveData();
    }

    private void OnApplicationQuit()
    {
        if (Gameplay.Instance.gameState == Gameplay.STATE.MENU) { return; }

        SaveData();
    }

    #endregion
}
