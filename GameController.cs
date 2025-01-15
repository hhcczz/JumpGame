using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject settingsBtn; // 설정 버튼
    public GameObject ReturnBtn; // 설정 버튼
    public GameObject messageBox; // 메시지 박스 게임 오브젝트
    public GameObject StartBG; // 게임 시작 배경
    public Button startButton; // 게임 시작 버튼
    public CameraController cameraController; // CameraController 컴포넌트 참조 변수

    private void Start()
    {
        // 메시지 박스를 활성화하여 표시
        messageBox.SetActive(true);

        // startButton에 클릭 이벤트 리스너 추가
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        // 메시지 박스를 비활성화하여 숨깁니다.
        messageBox.SetActive(false);

        // 카메라 이동 시작
        cameraController.StartCameraMovement();
        cameraController.isStartCamera = true;
        settingsBtn.SetActive(true);
        ReturnBtn.SetActive(true);
        StartBG.SetActive(false);
    }
}
