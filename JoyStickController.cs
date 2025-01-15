using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    RectTransform rect;
    public RectTransform handle;

    private Vector2 move = Vector2.zero;
    public Vector2 Move => move;

    float widthHalf;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        widthHalf = rect.sizeDelta.x * 0.5f;

    }

    public void OnDrag(PointerEventData eventData)
    {
        // 드래그되는 위치를 가져와서 정규화된 방향 벡터로 변환합니다.
        Vector2 touch = (eventData.position - rect.anchoredPosition) / (rect.sizeDelta.x * 0.5f);

        // 방향 벡터가 1보다 큰 경우, 방향 벡터를 정규화하여 크기를 1로 맞춥니다.
        touch = touch.magnitude > 1 ? touch.normalized : touch;

        // 핸들의 위치를 조정하여 조이스틱의 현재 값을 나타냅니다.
        handle.anchoredPosition = touch * widthHalf;
        move = touch;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 포인터가 다운될 때, OnDrag 함수를 호출하여 이동 값을 업데이트합니다.
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 포인터가 업될 때, 핸들 위치를 초기화하고 이동 값을 0으로 설정합니다.
        handle.anchoredPosition = Vector2.zero;
        move = Vector2.zero;
    }
}
