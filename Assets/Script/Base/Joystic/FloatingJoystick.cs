using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    public static FloatingJoystick joystick { get; private set; }

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
        background.gameObject.SetActive(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
    }
}