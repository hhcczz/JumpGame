using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class StageManagerData
{
    [SerializeField]
    // 스테이지 오픈 데이터 관리
    public bool[] StageOpen;

    // 캐릭터 변경 데이터 관리
    public int Character_state = 0; // 0 Frog,
                                    // 1 Dude,
                                    // 2 Pink,
                                    // 3 Virtual Guy
    public bool SoundController = true;

    // 스테이지 세이브 데이터 관리
    public Vector2 StageSaveData_1 = new Vector2(0, 0);
    public Vector2 StageSaveData_2 = new Vector2(0, 0);
    public Vector2 StageSaveData_3 = new Vector2(0, 0);
    public Vector2 StageSaveData_4 = new Vector2(0, 0);
    public Vector2 StageSaveData_5 = new Vector2(0, 0);

    // 관리자 게임 전용 스테이지 관리
}

public class StageManager : MonoBehaviour
{
    private static StageManager instance;
    private string path;
    private string filename = "Save";

    public static StageManager Instance
    {
        get { return instance; }
    }

    public StageManagerData stageData;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        path = Application.persistentDataPath + "/";
        Debug.Log(path);

        LoadData(); // 데이터 로드

        if (stageData == null)
        {
            // 저장된 데이터가 없거나 올바르지 않은 경우, 기본값으로 초기화
            stageData = new StageManagerData();
            stageData.StageOpen = new bool[5];
            stageData.StageOpen[0] = true;
        }
        else if (stageData.StageOpen == null || stageData.StageOpen.Length == 0)
        {
            // StageOpen 배열이 null이거나 길이가 0인 경우, 기본값으로 초기화
            stageData.StageOpen = new bool[5];
            stageData.StageOpen[0] = true;
        }
        stageData.StageOpen[1] = true;
        stageData.StageOpen[2] = true;
        stageData.StageOpen[3] = true;
        stageData.StageOpen[4] = true;

        // 데이터 저장
        SaveData();
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(stageData);
        File.WriteAllText(path + filename, data);
    }

    public void LoadData()
    {
        string filePath = path + filename;
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            stageData = JsonUtility.FromJson<StageManagerData>(data);
        }
    }
}


