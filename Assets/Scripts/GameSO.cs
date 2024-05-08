
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class GameSO : ScriptableObject
{
    [SerializeField] public bool accept;
    [SerializeField] public float volume;


    public void Initialize()
    {
        accept = false;
        volume = 0.5f;
    }
}
