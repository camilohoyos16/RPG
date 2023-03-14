using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour, IController
{
    private Canvas m_canvas;
    private Transform m_canvasTransform;

    private Stack<UiElement> m_openElements = new Stack<UiElement>();

    public void InitController()
    {
        m_canvas = GetComponent<Canvas>();
        m_canvasTransform = m_canvas.transform;
    }

    public void UpdateController(WorldState worldState)
    {
    }

    public UiElement InstantiateElement(UiElement prefab)
    {
        UiElement uiElement = Instantiate(prefab, m_canvasTransform);
        return uiElement;
    }

    public void ShowElement(UiElement uiElement)
    {
        uiElement.Show();
        uiElement.SetParent(m_canvasTransform);
        m_openElements.Push(uiElement);
    }

    public void HideElement(UiElement closeUntil = null)
    {
        bool closeAllDesired = closeUntil == null;
        do
        {
            UiElement currentElement = m_openElements.Pop();
            currentElement.Hide();

            if(currentElement == closeUntil)
            {
                closeAllDesired = true;
            }
        }
        while (!closeAllDesired);

    }
}
