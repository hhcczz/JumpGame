using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Warp : MonoBehaviour
{

    public bool LastStage_Clear = false; // 마지막 스테이지 클리어 조건 확인

    private bool isWaiting = false;
    private float waitStartTime = 0f;
    private float waitDuration = 1f; // 대기 시간 설정 (1초)

    private int ClickBtnNum;

    bool first_Click = false; // 초기 배경 처음 클릭 조건 확인
    public GameObject LevelPanel; // 레벨 선택 패널
    public GameObject EnterPress; // 시작 패널
    public Button[] buttons; // 버튼 배열

    private AudioSource StartClickSound; // BtnSoundSource 컴포넌트

    StageManager stagemanager; // StageManager 스크립트에서 받아오기

    
    // Instance로 데이터 들고다니는 방식 Awake 활용
    private void Awake()
    {
        stagemanager = StageManager.Instance;
    }

    private void Start()
    {
        stagemanager.LoadData(); // 데이터 불러오기

        StartClickSound = GetComponent<AudioSource>();

        Debug.Log("실행 함수 : Start");

        for (int i = 0; i < buttons.Length; i++)
        {
            Debug.Log("스테이지(Start) " + i + "OPEN 현황 : " + StageManager.Instance.stageData.StageOpen[i]);
        }

        for (int i = 1; i < buttons.Length; i++)
        {
            if (!StageManager.Instance.stageData.StageOpen[i])
            {
                Color buttonColor = buttons[i].image.color;
                buttonColor.a = 0.5f; // 알파 값을 0.5로 설정 (반투명)
                buttons[i].image.color = buttonColor;
            }
        }

        // 모든 버튼에 대한 이벤트 리스너 등록
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i; // 클로저를 위한 인덱스 복사
            buttons[i].onClick.AddListener(() => ButtonClicked(buttonIndex));

        }
    }

    private void ButtonClicked(int buttonIndex)
    {
        Debug.Log("버튼 " + (buttonIndex + 1) + "번 클릭");
        ClickBtnNum = buttonIndex + 1;
        if (StageManager.Instance.stageData.StageOpen[buttonIndex] == false)
        {
            Debug.Log("아직 클리어 하지 못한 스테이지 : Stage " + (buttonIndex + 1));
            return;
        }

        if (!isWaiting)
        {
            // 대기 중이 아니면 대기 시작
            isWaiting = true;
            waitStartTime = Time.time;
        }

    }

    private void Update()
    {
        if (isWaiting)
        {
            // 대기 중일 때 처리
            float elapsedTime = Time.time - waitStartTime;
            if (elapsedTime >= waitDuration)
            {
                // 대기 시간이 종료되면 씬 전환
                isWaiting = false;
                SceneManager.LoadScene("Stage " + ClickBtnNum);
            }
        }
        // PC에서 마우스 클릭 이벤트를 감지합니다.
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            if (!first_Click)
            {
                first_Click = true;
                LevelPanel.SetActive(true);
                EnterPress.SetActive(false);
                if(stagemanager.stageData.SoundController == true) StartClickSound.Play();
            }
        }
    }
}
