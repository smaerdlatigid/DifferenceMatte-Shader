using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CaptureBackground : MonoBehaviour
{
    [SerializeField] Material mat = null;

    Texture2D background;
    WebCamTexture webcam;
    public RawImage rawimage;


    void Start()
    {
        // Init camera
        webcam = new WebCamTexture(640, 480, 30);
        rawimage.texture = webcam;
        webcam.Play();

        transform.localScale = new Vector3(webcam.width / 100f, 1, webcam.height / 100f);

        background = new Texture2D(webcam.width, webcam.height, TextureFormat.ARGB32, false);
        Background();
    }

    public void Background()
    {
        var pixels = webcam.GetPixels(0, 0, webcam.width, webcam.height);
        background.SetPixels(pixels);
        background.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetTexture("webcam", webcam);
        mat.SetTexture("background", background);
    }

    void OnDestroy()
    {
        webcam?.Stop();
    }
}
