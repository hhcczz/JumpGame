using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{

    public GameObject[] Character;
    StageManagerData CharacterData = new StageManagerData();
    public int Stage_Character_State = 0;

    public void InitCharacterArray()
    {
        Character = new GameObject[3]; // 캐릭터 배열 초기화 로직 추가
    }

    void Start()
    {
        CharacterData = StageManager.Instance.stageData; // StageManager에서 데이터를 가져옴
        Character[Stage_Character_State].SetActive(false);
        Character[CharacterData.Character_state].SetActive(true);

    }

    public void ChangeTarget(Transform Target)
    {
        Target = Character[CharacterData.Character_state].transform;
    }

}
