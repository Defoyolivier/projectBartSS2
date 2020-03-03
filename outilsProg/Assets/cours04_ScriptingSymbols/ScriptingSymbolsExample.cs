#if UNITY_EDITOR
#define PIKACHEATS
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptingSymbolsExample : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
#if UNITY_EDITOR
        Debug.LogError("In Editor", gameObject);
#else
        Debug.LogError("Not In Editor");
#endif
    }

    // Update is called once per frame
    private void Update()
    {
#if PIKACHEATS

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.LogError("Pressed A ");
        }
#endif

#if AUTRE_CHOSES
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Pressed B ");
        }
#endif
    }

}
