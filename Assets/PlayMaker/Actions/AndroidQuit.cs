using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.GameLogic)]
	[Tooltip("Quit the application")]
	public class AndroidQuit : FsmStateAction
	{
		
		public override void OnEnter()
		{
			Debug.Log("APPLICATION QUIT");
			Application.Quit();
			Finish();
		}
	}
}