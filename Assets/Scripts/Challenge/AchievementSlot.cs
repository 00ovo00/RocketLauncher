using TMPro;
using UnityEngine;

public class AchievementSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleTxt;
    [SerializeField] private TextMeshProUGUI descTxt;
    [SerializeField] private GameObject checkMark;
    public bool isUnlocked = false;

    public void Init(AchievementSO data)
    {
        data.isUnlocked = false;
        titleTxt.text = data.displayName;
        descTxt.text = data.displayDesc;
        checkMark.SetActive(false);
    }
    // 업적 해금 상태로 표시
    public void MarkAsChecked()
    {
        checkMark.SetActive(true);  // 체크마크 활성화
        isUnlocked = true;  // 해금 상태로 변경
    }
}