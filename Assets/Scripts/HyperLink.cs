
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HyperLink : MonoBehaviour, IPointerClickHandler
{
    protected Camera cam;
    private void Awake()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        TextMeshProUGUI pText = GetComponent<TextMeshProUGUI>();

        int linkIndex = TMP_TextUtilities.FindIntersectingLink(pText, new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0), null);
        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = pText.textInfo.linkInfo[linkIndex];
            Application.OpenURL(linkInfo.GetLinkID());
        }
    }
}
