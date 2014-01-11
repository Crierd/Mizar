using HutongGames.PlayMaker;
using UnityEngine;

/*
 * *************************************************************************************
 * Created by: Rocket Games Mobile  (http://www.rocketgamesmobile.com), 2013
 * For use in Unity 3.5, Unity 4.0+
 * *************************************************************************************
*/

/// <summary>
/// Place on the NGUI GameObject you want to monitor events from (for example, a UIButton)
/// </summary>
public class NguiEventForwarder : MonoBehaviour 
{
    #region Variables

    /// <summary>
    /// When true, event messages are logged to the console
    /// </summary>
    public bool debug;

    /// <summary>
    /// The Playmaker FSM to forward event messages to
    /// </summary>
    public PlayMakerFSM targetFSM;

    // Variables
    #endregion

    #region OnEnable

    void OnEnable()
    {
        // use the first FSM on this GameObject, if one was not specified
        if (targetFSM == null)
            targetFSM = GetComponent<PlayMakerFSM>();

        // if we couldn't find the FSM, then disable this script
        if (targetFSM == null)
        {
            enabled = false;
            Debug.LogWarning("No FSM Target assigned. NGUIEventForwarder is not disabled");
        }
    }

    // OnEnable
    #endregion

    #region ForwardNGUIEvent

    /// <summary>
    /// Forwards the NGUI events to the selected Playmaker FSM
    /// </summary>
    /// <param name="nguiEvent"></param>
    void ForwardNGUIEvent(NGuiPlayMakerEventsEnum nguiEvent)
    {
        // exit if we are disabled or no FSM found
        if ((!enabled) || (targetFSM == null))
            return;

        // log the message
        if (debug)
            Debug.Log(string.Format("NGUI Event Forwarder - Sending {0} to {1} > {2}", nguiEvent.ToString(), targetFSM.gameObject.name, targetFSM.FsmName));

        // forward the event
        targetFSM.SendEvent(NGuiPlayMakerEvents.GetFsmEventEnumValue(nguiEvent));
    }

    // ForwardNGUIEvent
    #endregion

    #region NGUI_Events

    void OnClick()
    {
        // forward the event to the FSM
        ForwardNGUIEvent(NGuiPlayMakerEventsEnum.OnClickEvent);
    }


    void OnHover(bool isOver)
    {
        // forward the event to the FSM
        ForwardNGUIEvent(
            isOver ?
                NGuiPlayMakerEventsEnum.OnHoverEnterEvent :
                NGuiPlayMakerEventsEnum.OnHoverExitEvent);
    }

    void OnPress(bool pressed)
    {
        // forward the event to the FSM
        ForwardNGUIEvent(
            pressed ? 
                NGuiPlayMakerEventsEnum.OnPressDownEvent :
                NGuiPlayMakerEventsEnum.OnPresReleasedEvent);
    }

    void OnSelect(bool selected)
    {
        // forward the event to the FSM
        ForwardNGUIEvent(
            selected ?
                NGuiPlayMakerEventsEnum.OnSelectDownEvent :
                NGuiPlayMakerEventsEnum.OnSelectReleasedEvent);
    }

    void OnDrag(Vector2 delta)
    {
        // set event data
        Fsm.EventData.Vector3Data = new Vector3(delta.x, delta.y);

        // forward the event to the FSM
        ForwardNGUIEvent(NGuiPlayMakerEventsEnum.OnDragEvent);
    }

    void OnDrop(GameObject go)
    {
        // set event data
        Fsm.EventData.GameObjectData = go;

        // forward the event to the FSM
        ForwardNGUIEvent(NGuiPlayMakerEventsEnum.OnDropEvent);
    }

    void OnTooltip(bool show)
    {
        // forward the event to the FSM
        ForwardNGUIEvent(
            show ?
                NGuiPlayMakerEventsEnum.OnTooltipShowEvent :
                NGuiPlayMakerEventsEnum.OnTooltipHideEvent);
    }

    void OnSubmitChange()
    {
        // forward the event to the FSM
        ForwardNGUIEvent(NGuiPlayMakerEventsEnum.OnSubmitEvent);
    }

    void OnSliderChange(float value)
    {
        // set event data
        Fsm.EventData.FloatData = value;

        // forward the event to the FSM
        ForwardNGUIEvent(NGuiPlayMakerEventsEnum.OnSliderChangeEvent);
    }

    void OnSelectionChange(string item)
    {
        // set event data
        Fsm.EventData.StringData = item;

        // forward the event to the FSM
        ForwardNGUIEvent(NGuiPlayMakerEventsEnum.OnSelectionChangeEvent);
    }

    // NGUI_Events
    #endregion
}
