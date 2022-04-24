using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Update is called once per frame
    public Transform cam;
    public GameObject howToPlayUI;
    public GameObject optionsUI;
    public GameObject HUD;
    public int nextrange = 210;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            howToPlayUI.SetActive(false);
            optionsUI.SetActive(false);
            HUD.SetActive(true);
        }
    }
    public void nextButton()
    {
        cam.position = new Vector3(cam.position.x + nextrange, cam.position.y, cam.position.z);
    }
    public void backButton()
    {
        cam.position = new Vector3(cam.position.x - nextrange, cam.position.y, cam.position.z);
    }
}
