using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OperationLeft : MonoBehaviour ,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
	public void OnPointerDown(PointerEventData data)
	{
#if UNITY_EDITOR 
		joystickTransform.localPosition = data.pressPosition/Canvas.localScale.x;
		_firstTouchPosition = data.pressPosition/Canvas.localScale.x;
#else
		joystickTransform.localPosition = data.pressPosition/_canvasScaleX;
		_firstTouchPosition = data.pressPosition/_canvasScaleX;
#endif

		Data.JoystickPosition = Vector3.zero;

		toggleJoystick(true);
	}

	public void OnPointerUp(PointerEventData data)
	{
		toggleJoystick(false);
		knobTransform.localPosition = Vector3.zero;
	}

	public void OnDrag(PointerEventData data)
	{
#if UNITY_EDITOR 
		Vector2 delta = data.position/Canvas.localScale.x - _firstTouchPosition;
#else
		Vector2 delta = data.position/_canvasScaleX - _firstTouchPosition;
#endif
		delta = Vector2.ClampMagnitude (delta,80);
		Data.JoystickPosition = delta;
		knobTransform.localPosition = delta;
	}

	void Awake()
	{
		joystickTransform = transform.Find("Joystick");
		backgroundImage = transform.Find("Joystick/Background").GetComponent<Image>();
		knobTransform = transform.Find("Joystick/Knob");
		toggleJoystick(false);
	}

	void Start()
	{
#if UNITY_EDITOR 
#else
		_canvasScaleX = Canvas.localScale.x;
#endif
	}

	private void toggleJoystick(bool onOrOff)
	{
		if(onOrOff)
		{
			backgroundImage.color = new Color(1f,1f,1f,0.7f);
			knobTransform.GetComponent<Image>().color = new Color(1f,1f,1f,0.7f);
		}
		else
		{
			backgroundImage.color = new Color(1f,1f,1f,0.1f);
			knobTransform.GetComponent<Image>().color = new Color(1f,1f,1f,0.1f);
		}
	}

	public Transform Hero;
	public Transform Camera;
	public Transform Canvas;

	private Transform joystickTransform;
	private Image backgroundImage;
	private Transform knobTransform;

	private Vector2 _firstTouchPosition;
	private float _canvasScaleX;
}