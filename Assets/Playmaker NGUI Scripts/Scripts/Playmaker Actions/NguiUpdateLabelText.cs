using HutongGames.PlayMaker;
using UnityEngine;

/*
 * *************************************************************************************
 * Created by: Rocket Games Mobile  (http://www.rocketgamesmobile.com), 2013
 * For use in Unity 3.5, Unity 4.0+
 * *************************************************************************************
*/

[ActionCategory("NGUI")]
[Tooltip("Updates the text in an NGUI Label")]
public class NguiUpdateLabelText : FsmStateAction
{
    [RequiredField]
    [Tooltip("NGUI Label to update")]
    public FsmOwnerDefault NguiLabel;

    [RequiredField]
    [UIHint(UIHint.Variable)]
    [Tooltip("New text for NGUI Label")]
    public FsmString newValue;

    [Tooltip("When true, runs on every frame")]
    public bool everyFrame;

    public override void Reset()
    {
        NguiLabel = null;
        newValue = null;
        everyFrame = false;
    }

    public override void OnEnter()
    {
        DoUpdateLabel();

        if (!everyFrame)
            Finish();
    }

    public override void OnUpdate()
    {
        DoUpdateLabel();
    }

    private void DoUpdateLabel()
    {
        // exit if objects are null
        if ((NguiLabel == null) || (newValue == null))
            return;

        // get the object as a GO
        GameObject NLabelGO = Fsm.GetOwnerDefaultTarget(NguiLabel);

        // exit if there is no NGUI label on it
        UILabel NLabel = NLabelGO.GetComponent<UILabel>();
        if (NLabel == null)
            return;

        // update the label text
        NLabel.text = newValue.Value;
    }
}