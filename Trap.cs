using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    StageManagerData saveData = new StageManagerData();
    public AudioClip trapClip; // 함정 클립
    private AudioSource Trap_ASource; // TrapSource 컴포넌트

    private void Start()
    {
        saveData = StageManager.Instance.stageData; // StageManager에서 데이터를 가져옴
        // AudioSource 컴포넌트를 가져오고 배경음악 클립을 설정합니다.
        Trap_ASource = gameObject.AddComponent<AudioSource>();
        Trap_ASource.clip = trapClip;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어를 저장 지점으로 워프시킵니다.
            if (SceneManager.GetActiveScene().name == "Stage 2")
            {
                other.transform.position = saveData.StageSaveData_2;
            }
            else if (SceneManager.GetActiveScene().name == "Stage 3")
            {
                other.transform.position = saveData.StageSaveData_3;
            }
            else if (SceneManager.GetActiveScene().name == "Stage 4")
            {
                other.transform.position = saveData.StageSaveData_4;
            }
            else if (SceneManager.GetActiveScene().name == "Stage 5")
            {
                other.transform.position = saveData.StageSaveData_5;
            }
            if (saveData.SoundController == true) Trap_ASource.Play();
        }
    }
}
