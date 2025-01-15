using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    StageManagerData CharacterData = new StageManagerData();

    public Transform target; // 카메라가 따라갈 대상
    public float moveSmoothTime = 1.5f; // 시작 지점에서 도착 지점까지의 부드러운 이동을 위한 시간
    public float followSmoothTime = 0.25f; // 캐릭터를 따라다니는 부드러운 이동을 위한 시간
    public float targetOrthographicSize = 2.115904f; // 원하는 타겟 카메라의 크기
    public float sizeChangeSpeed = 0.5f; // 카메라 크기 변경 속도
    public GameObject JoyStickPanel;

    public bool isStartCamera = false;

    private Camera mainCamera; // 메인 카메라
    private Vector3 moveVelocity = Vector3.zero; // SmoothDamp 함수에 사용할 이동 속도 변수
    private Vector3 followVelocity = Vector3.zero; // SmoothDamp 함수에 사용할 따라다니는 속도 변수
    public bool isMovingToDestination = false; // 시작 지점에서 도착 지점으로 이동 중인지 여부
    private float currentOrthographicSize; // 현재 카메라의 orthographicSize

    CharacterManager characterManager = new CharacterManager(); // CharacterManager 참조 변수

    private void Start()
    {
        mainCamera = Camera.main;
        currentOrthographicSize = mainCamera.orthographicSize;

        characterManager = FindObjectOfType<CharacterManager>(); // CharacterManager 인스턴스 가져오기

        if (characterManager != null)
        {
            CharacterData = StageManager.Instance.stageData; // StageManager에서 데이터를 가져옴
            target = characterManager.Character[CharacterData.Character_state].transform;
        }
    }

    private void Update()
    {
        if (!isStartCamera) return;
        if (isMovingToDestination)
        {
            MoveToDestination();
        }
        else
        {
            FollowPlayer();
        }

        UpdateCameraSize();
    }

    private void MoveToDestination()
    {
        mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, new Vector3(target.transform.position.x, target.transform.position.y, mainCamera.transform.position.z), ref moveVelocity, moveSmoothTime);

        float distance = Vector3.Distance(mainCamera.transform.position, new Vector3(target.transform.position.x, target.transform.position.y, mainCamera.transform.position.z));
        if (distance <= 0.1f)
        {
            isMovingToDestination = false; // 도착 지점에 도착하면 이동 완료
            JoyStickPanel.SetActive(true);
        }
    }

    private void FollowPlayer()
    {
        Vector3 targetCamPos = new Vector3(target.position.x, target.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, targetCamPos, ref followVelocity, followSmoothTime);
    }

    private void UpdateCameraSize()
    {
        if (Mathf.Abs(mainCamera.orthographicSize - targetOrthographicSize) > 0.01f)
        {
            currentOrthographicSize = Mathf.Lerp(currentOrthographicSize, targetOrthographicSize, sizeChangeSpeed * Time.deltaTime);
            mainCamera.orthographicSize = currentOrthographicSize;
        }
    }

    public void StartCameraMovement()
    {
        isMovingToDestination = true;
    }


}

//위 스크립트에서 target 변수에는 카메라가 따라갈 대상인 캐릭터의 Transform 컴포넌트를 넣어주고,
//smoothing 변수에는 카메라의 부드러운 이동을 위한 스무딩 값을 설정합니다.
//그리고 Start() 함수에서는 카메라와 대상 간의 거리 차이를 계산하고,
//FixedUpdate() 함수에서는 Lerp() 함수를 사용하여 카메라를 부드럽게 따라가게 만듭니다.
//이 스크립트를 Main Camera에 추가하면, 캐릭터를 따라가는 카메라를 구현할 수 있습니다.

//Transform: Unity에서 객체의 위치, 회전, 크기 등을 나타내는 컴포넌트
//offset: 카메라와 대상 간의 거리 차이
//Start(): 스크립트가 활성화될 때 한 번 실행되는 함수
//transform.position: 객체의 현재 위치
//target.position: 대상의 현재 위치
//Vector3.Lerp(): 두 벡터 사이를 보간하여 새로운 값을 반환하는 함수
//Time.deltaTime: 이전 프레임부터 현재 프레임까지의 시간 간격 (초 단위)
