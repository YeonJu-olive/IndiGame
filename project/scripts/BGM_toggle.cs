using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_toggle: MonoBehaviour
{
    public Sprite checkedImage;    // 켜진 상태의 이미지
    public Sprite uncheckedImage;  // 꺼진 상태의 이미지

    private Toggle toggle;
    private Image toggleImage;

    void Start()
    {
        // Toggle 컴포넌트 참조
        toggle = GetComponent<Toggle>();

        // null 체크 추가
        if (toggle != null)
        {
            // targetGraphic이 null인 경우, toggleImage도 null이 됨에 주의
            toggleImage = toggle.targetGraphic as Image;

            // 토글 상태 변경 리스너 등록
            toggle.onValueChanged.AddListener(OnToggleValueChanged);

            // 기본 이미지 비활성화
            if (toggle.graphic != null)
            {
                toggle.graphic.enabled = false;
            }

            // 스타트할 때 내가 설정한 이미지로 초기화
            if (toggleImage != null)
            {
                toggleImage.sprite = toggle.isOn ? checkedImage : uncheckedImage;
            }
        }
        else
        {
            Debug.LogError("Toggle component not found.");
        }
    }

    // 토글 상태 변경 시 호출되는 함수
    void OnToggleValueChanged(bool isOn)
    {
        // 토글 상태에 따라 이미지 변경
        if (isOn)
        {
            toggleImage.sprite = checkedImage; // 켜진 상태의 이미지로 변경
            AudioManager.instance.PlayBGM();
        }
        else
        {
            toggleImage.sprite = uncheckedImage; // 꺼진 상태의 이미지로 변경
            AudioManager.instance.StopBGM();
        }
        if (toggleImage != null)
        {
            // 토글 상태에 따라 이미지 변경
            toggleImage.sprite = isOn ? checkedImage : uncheckedImage;

            // 디버그 로그
            Debug.Log(isOn ? "체크 표시가 생김" : "체크 표시가 없어짐");
        }
    }
}
