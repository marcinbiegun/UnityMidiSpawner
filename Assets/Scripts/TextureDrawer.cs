using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureDrawer : MonoBehaviour
{

    public Texture2D dynamicTexture;
    public Vector2 textureSize = new Vector2(256, 256);
    public int log = 1;

    // Start is called before the first frame update
    void Start()
    {
        InitTexture();
    }

    void InitTexture() {
        dynamicTexture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        GetComponent<Renderer>().material.SetTexture("_DisplacementTexture", dynamicTexture);
        for (int y = 0; y < dynamicTexture.height; y++) {
            for (int x = 0; x < dynamicTexture.width; x++) {
                Color color = Color.black;
                dynamicTexture.SetPixel(x, y, color);
            }
        }
        dynamicTexture.Apply();
    }


    // Update is called once per frame
    void Update()
    {
        int height = dynamicTexture.height;
        int width = dynamicTexture.width;

        // Move on x by 1
        var pixels = dynamicTexture.GetPixels(
            0,
            0,
            width-1,
            height
        );
        dynamicTexture.SetPixels(
            1,
            0,
            width-1,
            height,
            pixels
        );

        // Draw new strip

        //for (int i = 0; i < height; ++i) {
        //    colors[i] = Color.black;
        //}
        //int randomY = (int)Random.Range(0f, (float)height);
        //colors[randomY] = Color.white;

        float[] spectrum = new float[256];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        Color[] colors = new Color[height];
        for (int i = 0; i < spectrum.Length; ++i) {
            //float power = Mathf.Log(spectrum[i], log);
            //float power = spectrum[i];
            float power = Mathf.Pow(spectrum[i], .5f);
            colors[i] = new Color(power, power, power);
        }

        dynamicTexture.SetPixels(
            0,
            0,
            1,
            height,
            colors
        );


        // Apply changes
        dynamicTexture.Apply();

        //for (int i = 1; i < spectrum.Length - 1; i++) {
        //    Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
        //    Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
        //    Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
        //    Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        //}
    }

}
