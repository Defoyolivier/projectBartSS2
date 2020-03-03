
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TexturePreprocess : AssetPostprocessor
{
    // Lors de l'importation d'une texture, cette fonction sera appelée
    private void OnPreprocessTexture()
    {
        Debug.Log(assetPath);
        // Le chemin d'acces de la texture lors de son importation
        // EndsWith() => mon string termine avec [string]
        // ToLower() => Mets le string tout en minuscule
        // Contains(string) => Contient un string défini
        if (assetPath.EndsWith(".png") && assetPath.ToLower().Contains("ReadWrite"))
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            textureImporter.isReadable = true;
            textureImporter.textureType = TextureImporterType.Sprite;
        }
    }
}
