using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRenderer;

    public void DrawNoiseMap(float[,] noiseMap)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        Texture2D texture = new Texture2D(width, height);
        
        // Could do texture.SetPixel but it is easier to generate an array and apply them all at once
        Color[] colourMap = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Lerping is linear interpolation - returns a value in between two points at a point on a linear scale
                colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
            }
        }
        texture.SetPixels(colourMap);
        texture.Apply();
        
        // Cannot use textureRenderer.material as that is only instantiated at runtime
        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(width, 1, height);
    }
}
