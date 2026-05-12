using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resolutionText;

    public void SetResolution()
    {
        string resolution = resolutionText.text;
        string[] splitResolution = resolution.Split(char.Parse("x"));
        int hor = int.Parse(splitResolution[0]);
        int vert = int.Parse(splitResolution[1]);
        Screen.SetResolution(hor, vert, true);
    }
}
