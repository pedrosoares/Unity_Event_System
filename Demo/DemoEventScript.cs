using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEventScript : MonoBehaviour {

	public class CustomEvent : Event {

		private Vector3 location;

		public CustomEvent(Vector3 location) : base("custom_event") {
			this.location = location;
		}

		public Vector3 getLocation(){
			return this.location;
		}

	}

	public class DemoEventListener : EventListener {

		public override void handle (Event event_) {
			CustomEvent customEvent = (CustomEvent) event_;
			print ("Event "+customEvent.getName()+" Handled with "+customEvent.getLocation().ToString());
		}

	}

	// Use this for initialization
	void Start () {
		EventListener.addListener ("custom_event", new DemoEventListener());
		EventListener.addListener ("custom_event", new DemoEventListener());
	}
	
	public void EmitEvent(){
		Event.emit (new CustomEvent(this.transform.position));
	}
}
