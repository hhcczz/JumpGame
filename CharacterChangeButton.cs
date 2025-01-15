using UnityEngine;
using UnityEngine.UI;
public class CharacterChangeButton : MonoBehaviour
{
    StageManagerData CharacterData = new StageManagerData();

    public Button[] CharacterBtn; // 캐릭터 배열
    public GameObject[] characters; // 캐릭터 GameObject 배열

    // Start is called before the first frame update
    void Start()
    {
        CharacterData = StageManager.Instance.stageData; // StageManager에서 데이터를 가져옴
        characters[CharacterData.Character_state].SetActive(true);
        // 모든 버튼에 대한 이벤트 리스너 등록
        for (int i = 0; i < CharacterBtn.Length; i++)
        {
            int buttonIndex = i; // 클로저를 위한 인덱스 복사
            CharacterBtn[i].onClick.AddListener(() => ButtonClicked(buttonIndex));

        }
    }
    private void ButtonClicked(int buttonIndex)
    {
        Debug.Log("버튼 " + (buttonIndex + 1) + "번 클릭");
        characters[CharacterData.Character_state].SetActive(false);

        CharacterData.Character_state = buttonIndex;

        characters[CharacterData.Character_state].SetActive(true);

    }
}
