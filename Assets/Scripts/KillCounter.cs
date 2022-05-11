using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public static int killCounter = 0;
    public TextMeshProUGUI score;

    public void IncreaseScore()
    {
        killCounter++;
        score.text = killCounter.ToString();
    }

    public int ResetScore()
    {
        return killCounter = 0;
    }
}
