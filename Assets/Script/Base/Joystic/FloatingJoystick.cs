using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    public static FloatingJoystick joystick { get; private set; }
    private UnityEngine.Vector3 _defaultPosition = new UnityEngine.Vector3(0, -500);

    private void Awake()
    {
        if (joystick != null && joystick != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            joystick = this;
        }
    }

    protected override void Start()
    {
        base.Start();
        background.SetActive();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        //background.SetActive();
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        //background.SetInactive();
        background.localPosition = _defaultPosition;
        base.OnPointerUp(eventData);
    }
}