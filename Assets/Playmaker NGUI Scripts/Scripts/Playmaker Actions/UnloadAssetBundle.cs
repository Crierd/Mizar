using HutongGames.PlayMaker;

/*
 * *************************************************************************************
 * Created by: Rocket Games Mobile  (http://www.rocketgamesmobile.com), 2013
 * For use in Unity 3.5, Unity 4.0+
 * *************************************************************************************
*/

[ActionCategory("Asset Bundle")]
[Tooltip("Unloads one asset bundle")]
public class UnloadAssetBundle : FsmStateAction
{
    [RequiredField]
    [Tooltip("Asset Bundle Manager Prefab")]
    public FsmGameObject BundleManager;

    [RequiredField]
    [Tooltip("URL of asset bundle - including .unity3d extension")]
    public FsmString BundleURL;

    [RequiredField]
    [Tooltip("Bundle version number")]
    public FsmInt VersionNumber;

    private ManagerAssetBundle asset;

    public override void Reset()
    {
        BundleManager = null;
        BundleURL = null;
        VersionNumber = null;
    }

    public override void OnUpdate()
    {
        DoBundleUnload();
        Finish();
    }

    private void DoBundleUnload()
    {
        // exit if objects are null
        if ((BundleURL == null) || (VersionNumber == null) || (BundleManager == null))
            return;

        // unload the bundle
        BundleManager.Value.GetComponent<ManagerAssetBundle>().UnloadBundle(VersionNumber.Value, BundleURL.Value);
    }
}