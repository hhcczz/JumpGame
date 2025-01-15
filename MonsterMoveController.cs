using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterMoveController : MonoBehaviour
{
    StageManagerData saveData = new StageManagerData();

    public GameObject pig; // 몹 돼지 선언
    public float moveDistance = 5f; // 몹 최대 이동 거리 ( 왕복 )
    public float monsterSpeed = 3f; // 몹 스피드
    private Vector2 pig_spawn_position; // 돼지 처음 스폰 위치

    private float currentDistance; // 현재 거리
    private bool movingForward = true; // 앞 뒤 체크 조건 확인

    private AudioSource Monster_Sound; // Monster_Sound 오디오 소스
    public AudioClip MSClip; // Monster_Sound 오디오 Clip

    private void Start()
    {
        // 몬스터 소리를 재생할 AudioSource 컴포넌트를 설정합니다.
        Monster_Sound = gameObject.AddComponent<AudioSource>();

        saveData = StageManager.Instance.stageData; // StageManager에서 데이터를 가져옴
        currentDistance = 0f;
        pig_spawn_position = pig.transform.position;

        // Monster Sound 설정
        Monster_Sound.clip = MSClip;
        Monster_Sound.volume = 1f;
    }

    private void Update()
    {
        if (movingForward)
        {
            if (currentDistance < moveDistance)
            {
                // 일정 거리 이동
                Vector3 newPosition = pig.transform.position + new Vector3(monsterSpeed * Time.deltaTime, 0f, 0f);
                pig.transform.position = newPosition;
                currentDistance += monsterSpeed * Time.deltaTime;
            }
            else
            {
                // 방향 변경
                movingForward = false;
                pig.transform.position = new Vector2(pig_spawn_position.x + moveDistance, pig_spawn_position.y); // 초기 위치 업데이트
            }
        }
        else
        {
            if (currentDistance > 0f)
            {
                // 반대로 이동
                Vector3 newPosition = pig.transform.position - new Vector3(monsterSpeed * Time.deltaTime, 0f, 0f);
                pig.transform.position = newPosition;
                currentDistance -= monsterSpeed * Time.deltaTime;
            }
            else
            {
                // 초기 위치로 되돌아감
                pig.transform.position = pig_spawn_position;
                currentDistance = 0f;
                movingForward = true;
            }
        }

        // 방향에 따른 회전
        if (movingForward)
        {
            pig.transform.rotation = Quaternion.identity;
        }
        else
        {
            pig.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "Stage 4")
            {
                collision.transform.position = saveData.StageSaveData_4;
            }
            if (SceneManager.GetActiveScene().name == "Stage 5")
            {
                collision.transform.position = saveData.StageSaveData_5;
            }
            if (saveData.SoundController == true) Monster_Sound.Play();
        }
    }
}
