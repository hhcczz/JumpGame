using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleColliderEvent : MonoBehaviour
{
    public GameObject Clear_Fruits;
    StageManager stagemanager;
    StageManagerData saveData = new StageManagerData(); // 데이터 가져오기

    private void Awake()
    {
        stagemanager = StageManager.Instance;
    }

    private void Start()
    {
        saveData = stagemanager.stageData; // StageManager에서 데이터 가져오기
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Character가 부딪힌 경우 저장한 배열 변수 값 사용
        if (collision.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "Stage 1")
            {
                // Stage 1 클리어 상태를 설정
                StageManager.Instance.stageData.StageOpen[1] = true;
                Debug.Log("Stage 1 OPEN 상태 : " + StageManager.Instance.stageData.StageOpen[1]);
                saveData.StageSaveData_1 = new Vector2(0,0);
            }
            else if (SceneManager.GetActiveScene().name == "Stage 2")
            {
                // Stage 2 클리어 상태를 설정
                StageManager.Instance.stageData.StageOpen[2] = true;
                Debug.Log("Stage 2 OPEN 상태 : " + StageManager.Instance.stageData.StageOpen[2]);
                saveData.StageSaveData_2 = new Vector2(0, 0);
            }
            else if (SceneManager.GetActiveScene().name == "Stage 3")
            {
                // Stage 3 클리어 상태를 설정
                StageManager.Instance.stageData.StageOpen[3] = true;
                Debug.Log("Stage 3 OPEN 상태 : " + StageManager.Instance.stageData.StageOpen[3]);
                saveData.StageSaveData_3 = new Vector2(0, 0);
            }
            else if (SceneManager.GetActiveScene().name == "Stage 4")
            {
                // Stage 4 클리어 상태를 설정
                StageManager.Instance.stageData.StageOpen[4] = true;
                Debug.Log("Stage 4 OPEN 상태 : " + StageManager.Instance.stageData.StageOpen[4]);
                saveData.StageSaveData_4 = new Vector2(0, 0);
            }
            else if (SceneManager.GetActiveScene().name == "Stage 5")
            {
                // Stage 5 클리어 상태를 설정
                saveData.StageSaveData_5 = new Vector2(0, 0);
            }
            stagemanager.SaveData();
            SceneManager.LoadScene("Main Scene");
        }
    }
}
