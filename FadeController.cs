using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    public Button[] buttons; // 버튼 배열

    StageManager stagemanager; // StageManager 스크립트에서 받아오기

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Main Scene") StartCoroutine(FadeFlow_Stage_OUT());

        if (SceneManager.GetActiveScene().name == "Main Scene")
        {
            // 모든 버튼에 대한 이벤트 리스너 등록
            for (int i = 0; i < buttons.Length; i++)
            {
                int buttonIndex = i; // 클로저를 위한 인덱스 복사
                buttons[i].onClick.AddListener(() => Fade(buttonIndex));

            }
        }
    }

    public void Fade(int buttonIndex)
    {
        if (StageManager.Instance.stageData.StageOpen[buttonIndex] == true) StartCoroutine(FadeFlow_Stage_IN());
    }

    IEnumerator FadeFlow_Stage_OUT()
    {
        time = 0f;
        Color alpha = Panel.color;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;

        }
        Panel.gameObject.SetActive(false);

    }

    IEnumerator FadeFlow_Stage_IN()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while(alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1,time);
            Panel.color = alpha;
            yield return null;

        }

    }
}
