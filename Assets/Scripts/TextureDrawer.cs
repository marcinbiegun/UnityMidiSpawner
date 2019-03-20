using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureDrawer : MonoBehaviour
{

    public Texture2D dynamicTexture;

    // Start is called before the first frame update
    void Start()
    {
        dynamicTexture = new Texture2D(64, 64);
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
        int randomX = (int)Random.Range(0f, (float)width);
        int randomY = (int)Random.Range(0f, (float)height);

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


        Color color = Color.white;
        dynamicTexture.SetPixel(0, randomY, color);

        dynamicTexture.Apply();
    }
}
