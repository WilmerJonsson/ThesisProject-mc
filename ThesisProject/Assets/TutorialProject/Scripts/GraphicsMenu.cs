using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{
    GameObject playerObject;
    [SerializeField] TMP_Dropdown resolutionDropDown;
    [SerializeField] Slider mouseSensitivitySlider;
    [SerializeField] TMP_Text sensitivityValueTxt;
    Resolution[] resolutions;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        PopulateResDropDown();
    }

    public void ChangeSensitivity()
    {
        int newSensitivity = (int)mouseSensitivitySlider.value;
        sensitivityValueTxt.text = newSensitivity.ToString();
        playerObject.GetComponent<PlayerLook>().mouseSensitivity = newSensitivity; 
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void PopulateResDropDown()
    {
        int currentResolutionIndex = 0;

        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        for (int i = 0; i < resolutions.Length; i++)
        {
            options.Add(resolutions[i].width + "x" + resolutions[i].height);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }

            resolutionDropDown.ClearOptions();
            resolutionDropDown.AddOptions(options);
            resolutionDropDown.value = currentResolutionIndex;
            resolutionDropDown.RefreshShownValue();
        }
    }

    public void ChangeResolution(int resIndex)
    {
        Screen.SetResolution(resolutions[resIndex].width, resolutions[resIndex].height, Screen.fullScreen);
    }
}
