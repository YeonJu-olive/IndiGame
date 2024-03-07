using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    // 여기에 다양한 사운드 변수들을 추가할 수 있습니다.
    public AudioSource bgmSource;

    void Awake()
    {
        // 싱글톤 패턴 적용
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // BGM 재생 함수
    public void PlayBGM()
    {
        // 여기에 BGM 재생 코드 추가
        bgmSource.Play();
    }

    // BGM 정지 함수
    public void StopBGM()
    {
        // 여기에 BGM 정지 코드 추가
        bgmSource.Stop();
    }
}