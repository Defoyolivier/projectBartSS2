using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIWindow : MonoBehaviour
{
    public GameObject CubeRef;
    [SerializeField]
    private Vector2 m_ScrollRect;
    [SerializeField]
    private Vector3 m_CubePos;
    [SerializeField]
    private Vector3 m_CubeScale;

    [SerializeField]
    private Texture2D PurpleTexture;
    [SerializeField]
    private Texture2D BlueTexture;
    [SerializeField]
    private Texture2D GreenTexture;
    [SerializeField]
    private Texture2D RedTexture;
    [SerializeField]
    private Texture2D WhiteTexture;
    [SerializeField]
    private Texture2D m_BoxBackground;

    [SerializeField]
    private Rect m_WindowRect = new Rect(20f, 20f, 200f, 150f);

    private float m_ScrollPosition;
    private bool m_Toggle;
    private string m_TextField;
    private int m_GridIndex;

    //private string m_PasswordField;
    private int PageNumber;

    private string[] m_ScaleString = new string[] { "Scale 0x", "Scale 0.5x", "Scale 2.0x", "Scale 3.0x" };
    private string[] m_TextureString = new string[] { "Purple 16x16", "Blue 16x16", "Green 16x16", "Red 16x16","White 16x16" };

    private int m_ToolBarIndex;

    private Vector2 m_ScrollPos;

    private void OnGUI()
    {
        Rect rect = new Rect(300f, 0f, 500f, 150f);
        Rect ScollRect = new Rect(450, 75, 200, 20);
        Rect ButtonRect = new Rect(300, 0, 80, 150);
        Rect ToggleRect = new Rect(400f, 55f, 45, 20);


        GUIStyle style = new GUIStyle(GUI.skin.box);
        if (m_BoxBackground != null)
        {
            style.normal.background = m_BoxBackground;
        }
        GUI.Box(rect, "", style);

        rect.x += 220;
        if(PageNumber == 0)
        {
            GUI.Label(rect, "Cheats");
            rect.x -= 120f;
            m_Toggle = GUI.Toggle(ToggleRect, m_Toggle, "Hide");


            if (m_Toggle)
            {
                CubeRef.SetActive(false);
            }
            else
            {
                CubeRef.SetActive(true);
            }

            rect.y += 70f;

            GUI.Label(rect, "Position");
            m_ScrollPosition = CustomSlider(ScollRect, m_ScrollPosition, -5f, 5f);
            rect.x += 40f;
            Rect toolbarRect = new Rect(400f, 110f, 300f, 20f);
            m_ToolBarIndex = GUI.Toolbar(toolbarRect, m_ToolBarIndex, m_ScaleString);


            m_CubePos = CubeRef.GetComponent<Transform>().position;
            m_CubePos.x = m_ScrollPosition;
            CubeRef.transform.position = m_CubePos;


            m_CubeScale = CubeRef.GetComponent<Transform>().localScale;
            if (m_ToolBarIndex == 0)
            {
                m_CubeScale = new Vector3(0, 0, 0);
                CubeRef.transform.localScale = m_CubeScale;
            }
            else if (m_ToolBarIndex == 1)
            {
                m_CubeScale = new Vector3(0.5f, 0.5f, 0.5f);
                CubeRef.transform.localScale = m_CubeScale;
            }
            else if (m_ToolBarIndex == 2)
            {
                m_CubeScale = new Vector3(2, 2, 2);
                CubeRef.transform.localScale = m_CubeScale;
            }
            else if (m_ToolBarIndex == 3)
            {
                m_CubeScale = new Vector3(3, 3, 3);
                CubeRef.transform.localScale = m_CubeScale;
            }

        }
        else if(PageNumber == 1)
        {
            GUI.Label(rect, "Stats");
            rect.x -= 70;
            rect.y += 40;
            GUI.Label(rect, "Local Position: " + CubeRef.transform.position.ToString());
            rect.y += 20;
            GUI.Label(rect, "Local Rotation: " + CubeRef.transform.localEulerAngles.ToString());
            rect.y += 20;
            GUI.Label(rect, "Local Scale: " + CubeRef.transform.localScale.ToString());
        }
        else
        {
            GUI.Label(rect, "GUI");

            Rect scrollView = new Rect(400f, 40f, m_ScrollRect.x, m_ScrollRect.y);
            Rect scrollTotalRect = scrollView;
            scrollTotalRect.height += 50f;
            scrollView.width += 20f;
            m_ScrollPos = GUI.BeginScrollView(scrollView, m_ScrollPos, scrollTotalRect);

            
            m_GridIndex = GUI.SelectionGrid(scrollView, m_GridIndex, m_TextureString, 4);

            switch (m_GridIndex)
            {
                case 0:
                    m_BoxBackground = PurpleTexture;
                    break;
                case 1:
                    m_BoxBackground = BlueTexture;
                    break;
                case 2:
                    m_BoxBackground = GreenTexture;
                    break;
                case 3:
                    m_BoxBackground = RedTexture;
                    break;
                case 4:
                    m_BoxBackground = WhiteTexture;
                    break;

            }

            GUI.EndScrollView();
        }

      
        bool isPressedLeft = GUI.Button(ButtonRect, "Left");
        if (isPressedLeft)
        {
            
            if(PageNumber > 0)
            {
                PageNumber--;
            }
        }
        ButtonRect.x += 420f;
        bool isPressedRight = GUI.Button(ButtonRect, "Right");
        if (isPressedRight)
        {
            if (PageNumber < 3)
            {
                PageNumber++;
            }
            
        }

    }
    private float CustomSlider(Rect i_Position, float i_Value, float i_LeftValue, float i_RightValue)
    {
        i_Value = GUI.HorizontalSlider(i_Position, i_Value, i_LeftValue, i_RightValue);
        Rect labelRect = i_Position;
        labelRect.x += i_Position.width;
        GUI.Label(labelRect, i_Value.ToString("F2"));
        return i_Value;
    }




}
