using UnityEngine;
using System.Collections;

public class FooterMenuController : MonoBehaviour {

    //WachButton is custum Button with my custom event of button
    public WachButton bonus_btn;
	public WachButton physio_btn;
	public WachButton quick_btn;
	public WachButton report_btn;

	//default button
	private WachButton currentBtn;

	void Start () {

		//Dynamics for button click 
		AddEventClick(bonus_btn);
		AddEventClick(physio_btn);
		AddEventClick(quick_btn);
		AddEventClick(report_btn);
	}

	private void AddEventClick( WachButton btn ){
		//Custom event OnClick
		btn.OnClick += OnClick;
	}

	void OnClick (WachButton unit)
	{
		//set current button was clicked to unclick
		if( currentBtn != null ){
			currentBtn.InActiveClick();
		}

		//set new button will active to click lock
		unit.ActiveClick();
		//set new button to current button
		currentBtn = unit;
		//request to Microsoft azure service fabric
		NetWorkController.Instance.GetData( NetWorkController.Events.GET_DATA_EVENT, unit.requestForm, null , GetDataComplete );
	}

	private void GetDataComplete( JSONObject obj ){
		Debug.Log(obj);
	}

}
