using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class WachButton : MonoBehaviour {

	public delegate void OnActionClick( WachButton unit );
	public event OnActionClick OnClick;
	public NetWorkController.Requests requestForm;
	private EventTrigger eventTrigger;
	private Button currentBtn;

	void Start()
	{
		//set default button
		currentBtn = this.gameObject.GetComponent<Button>();
		if( !eventTrigger ){
			//set default of EventTrigger
			eventTrigger = this.gameObject.AddComponent<EventTrigger>();
		}

		//Make action by custom event
		AddEventTrigger(OnPointClick, EventTriggerType.PointerClick );
	}

	//Set up my custom event
	void AddEventTrigger( UnityAction action, EventTriggerType triggerType ){
		//addlistener 
		EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();
		trigger.AddListener( (eventdata) => action());

		//add trigger into custom trigger
		EventTrigger.Entry entry = new EventTrigger.Entry(){ callback = trigger, eventID = triggerType };
		eventTrigger.triggers.Add(entry);
	}

	//private event
	void OnPointClick(){
		if( OnClick != null ){
			// dispatch/delegate event to anyone would like to using this event 
			OnClick(this);
		}
	}

	//active button
	public void ActiveClick(){
		currentBtn.interactable = false;
	}

	//inactive button
	public void InActiveClick(){
		currentBtn.interactable = true;
	}

}
