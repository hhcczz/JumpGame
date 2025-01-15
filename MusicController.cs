using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    StageManager stagemanager;

    public Button[] buttons; // 버튼 배열

    private AudioSource BtnSoundSource; // BtnSoundSource 컴포넌트

    private AudioSource BGsource; // BGsource 컴포넌트
    public AudioClip BGClip;

    private void Start()
    {
        // AudioSource 컴포넌트를 가져오고 배경음악 클립을 설정합니다.
        BtnSoundSource = GetComponent<AudioSource>();

        // 배경음악을 재생할 AudioSource 컴포넌트를 설정합니다.
        BGsource = gameObject.AddComponent<AudioSource>();

        // BG 설정
        BGsource.clip = BGClip;
        if(SceneManager.GetActiveScene().name != "Main Scene") BGsource.volume = 0.6f;
        else BGsource.volume = 0.3f;
        BGsource.loop = true;
        BGsource.Play();

        stagemanager = StageManager.Instance;

        // 모든 버튼에 대한 이벤트 리스너를 등록합니다.
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i; // 클로저를 위한 인덱스 복사
            buttons[i].onClick.AddListener(() => BtnSoundControl(buttonIndex));
        }

        MusicControl();
    }

    public void BtnSoundControl(int buttonIndex)
    {
        if (stagemanager.stageData.SoundController == true)
            BtnSoundSource.Play();
            
        else
            BtnSoundSource.Stop();
    }

    public void MusicControl()
    {
        if (stagemanager.stageData.SoundController == true)
            BGsource.mute = false;
        else
            BGsource.mute = true;
    }
}
