using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpritePostProcessor : AssetPostprocessor
{
    private void OnPostprocessSprites(Texture2D i_Texture, Sprite[] i_Sprites)
    {
        Debug.Log("Sprites: " + i_Sprites.Length);
    }

    private void OnPostprocessTexture(Texture2D i_Texture)
    {
        Debug.Log("Texture2D: (" + i_Texture.width + " x " + i_Texture.height + ")");
    }

}
