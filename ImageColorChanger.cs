using UnityEngine;
using UnityEngine.UI;

public class ImageColorChanger : MonoBehaviour
{
    public Image targetImage;
    public Color clearColor;

    private Color originalColor;

    private void Start()
    {
        // 초기 이미지 색상 저장
        originalColor = targetImage.color;
    }

    public void ChangeImageColor()
    {
        // 이미지의 색상을 clearColor로 변경
        targetImage.color = clearColor;
    }

    public void RestoreImageColor()
    {
        // 이미지의 색상을 원래대로 복원
        targetImage.color = originalColor;
    }
}
