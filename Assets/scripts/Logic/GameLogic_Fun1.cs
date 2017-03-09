using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class GameLogic_Fun1: MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{
		public enum AxisOption
		{
			// Options for which axes to use
			Both, // Use both
			OnlyHorizontal, // Only horizontal
			OnlyVertical // Only vertical
		}

		public int MovementRange = 100;
		public AxisOption axesToUse = AxisOption.Both; // The options for the axes that the still will use
		public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input
		public string verticalAxisName = "Vertical"; // The name given to the vertical axis for the cross platform input


        public GameObject effectMakeFire;
        public Transform effectPos;

		Vector3 m_StartPos;
        Vector2 m_TouchPos;
        Vector2 m_DragMove = Vector2.zero;
        


       // Vector3 m_LastPos;
		bool m_UseX; // Toggle for using the x axis5                                                                                                                                                                                                                                                                                                                                            
		bool m_UseY; // Toggle for using the Y axis
                     //CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input
                     //CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input
        


        void Start()
        {
            m_StartPos = transform.localPosition;
            Debug.Log("m_startpos:" + m_StartPos);
        }

		void UpdateVirtualAxes(Vector3 value)
		{
            /*
			var delta = m_StartPos - value;
			delta.y = -delta.y;
			delta /= MovementRange;
            */
		}

		void CreateVirtualAxes()
		{
			// set axes to use
			m_UseX = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyHorizontal);
			m_UseY = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyVertical);

			// create new axes based on axes to use
			if (m_UseX)
			{
				
			}
			if (m_UseY)
			{
				//m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
				//CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
			}
		}

        void CreateMakeFireEffect(string s)
        {
            GameObject go = (GameObject)Instantiate(effectMakeFire, effectPos.position, Quaternion.identity);
            go.transform.parent = effectPos;
            go.transform.localScale = Vector3.one * 2;
            go.GetComponent<Text>().text = "make effect size:" + s;
        }

		public void OnDrag(PointerEventData data)
		{
            
            Vector2 mov = (data.position - m_TouchPos)*2;
            if (m_DragMove != Vector2.zero)
            {
                float disqr = (m_DragMove - mov).sqrMagnitude;
                if(disqr > 10000)
                    CreateMakeFireEffect(disqr.ToString());
            }
            m_DragMove = mov;

            transform.localPosition = new Vector3(m_StartPos.x + mov.x, m_StartPos.y + mov.y, m_StartPos.z);

            /*
				int delta = (int)(data.position.x - m_StartPos.x);
				delta = Mathf.Clamp(delta, - MovementRange, MovementRange);
				newPos.x = delta;

				delta = (int)(data.position.y - m_StartPos.y);
				delta = Mathf.Clamp(delta, -MovementRange, MovementRange);
				newPos.y = delta;

			*/
			//UpdateVirtualAxes(transform.position);
            
           // transform.position = data.position;


        



		}


		public void OnPointerUp(PointerEventData data)
		{

            Debug.Log("on up");
            transform.localPosition = m_StartPos;
            m_DragMove = Vector2.zero;
            //UpdateVirtualAxes(m_StartPos);
        }


		public void OnPointerDown(PointerEventData data)
        {
            Debug.Log("on down");
            
            m_TouchPos = data.position;
        }

		void OnDisable()
		{
		}
	}
}