using UnityEngine;
using System.Collections;

public class ConditionMenuController : MonoBehaviour {

	public WachButton choose_drill_btn;
	public WachButton select_player_btn;
	public WachButton start_btn;

	private PostData postData;

	void Start () {
		//Dynamics for button click 
		AddEventClick(choose_drill_btn);
		AddEventClick(select_player_btn);
		AddEventClick(start_btn);
	}

	private void AddEventClick( WachButton btn ){
		//Custom event OnClick
		btn.OnClick += OnClick;
	}

	void OnClick (WachButton unit)
	{

		postData = new PostData();
		postData.requestFor = unit.requestForm;
		postData.score = 20;
		NetWorkController.Instance.GetData( NetWorkController.Events.POST_DATA_EVENT, unit.requestForm, postData , SendDataComplete );

	}

	public void SendDataComplete( JSONObject obj ){
		Debug.Log("Success!");
	}

	

}
