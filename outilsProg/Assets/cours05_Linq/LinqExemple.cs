using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqExemple : MonoBehaviour
{
    [SerializeField]
    private class Character
    {
        public GameObject m_Sword;
        public float m_Health;
        public float m_Speed;
        public AudioClip m_DeadSound;
    }

    public List<GameObject> m_Objects;

    private void OnGUI()
    {
        GameObject closestObject = GetClosestObject(m_Objects);
        //Debug.Log(closestObject.name);

        //Avoir le premier dans la liste
        GameObject closestLinq = m_Objects
            .OrderBy(pikachu => Vector3.Distance(transform.position, pikachu.transform.position))
            .FirstOrDefault();

        //Debug.Log(closestLinq.name);

        // avoir le dernier dans la liste(v1)
        GameObject furthestObject = m_Objects
            .OrderBy(go => Vector3.Distance(transform.position, go.transform.position))
            .LastOrDefault();

        //Debug.Log(furthestObject.name);

        //avoir le dernier dans la liste(v2)
        GameObject furthestObject2 = m_Objects
        .OrderByDescending(go => Vector3.Distance(transform.position, go.transform.position))
        .LastOrDefault();

        //Debug.Log(furthestObject2.name);

        // 'Skip' le nombre d'élements spécifiés
        GameObject[] skips = m_Objects
            .Skip(1)
            .ToArray();

        /*for(int i = 0; i < skips.Length; i++)
        {
            Debug.Log(skips[i].name);
        }*/

        // 'Prend' le nombre d"élements spécifiés
        List<GameObject> takeExemple = m_Objects
            .Take(2)
            .ToList();

        /*for (int i = 0; i < takeExemple.Count; i++)
        {
            Debug.Log(takeExemple[i].name);
        }*/

        //where sert a filtrer la liste et de retourner les éléments selon la condition spécifiés
        List<GameObject> capsules = m_Objects
            .Where(go => go.GetComponent<CapsuleCollider>() != null)
            .ToList();

        /*for (int i = 0; i < capsules.Count; i++)
        {
            Debug.Log(capsules[i].name);
        }*/

        bool anyExemple = m_Objects
            .Any(go => go.name == "cube 2");

        //Debug.Log(anyExemple);

        List<int> intExemple = new List<int>() { 1, 1, 1, 2, 2, 2, 2, 3, 4, 4 };

        int[] distinctInt = intExemple
            .Distinct()
            .ToArray();

        /*for (int i = 0; i < distinctInt.Length; i++)
        {
            Debug.Log(distinctInt[i]);
        }*/


        
    }


    private GameObject GetClosestObject(List<GameObject> i_GameObjects)
    {
        float smallestDistance = Mathf.Infinity;

        GameObject closestObject = null;
        
        for(int i = 0; i < i_GameObjects.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, i_GameObjects[i].transform.position);
            if(distance < smallestDistance)
            {
                smallestDistance = distance;
                closestObject = i_GameObjects[i];
            }
        }

        return closestObject;
    }


}
