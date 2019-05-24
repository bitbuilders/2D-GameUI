using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaceArea : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] UICreator m_UICreator = null;
    [SerializeField] GraphicRaycaster m_Raycaster;
    [SerializeField] EventSystem m_EventSystem;

    PointerEventData m_PointerEventData;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            m_Raycaster.Raycast(m_PointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject == gameObject)
                {
                    m_UICreator.PlaceElement(Input.mousePosition);
                    break;
                }
            }
        }
    }
}
