using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    protected static PlayerController controller;

    protected TMP_Text score;

    protected TMP_Text hint;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        score = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        hint = GameObject.Find("HintText").GetComponent<TMP_Text>();
    }

    public void SetScore(string point)
    {
        score.text = point;
    }
    public void ClearScore()
    {
        score.text = "0";
    }

    public void SetHint()
    {
        hint.text = controller.GetNumberHint().ToString();
    }    

    public void ClearHint()
    {
        hint.text = "10";
    }

   
}
