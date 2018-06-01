using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event {

	private string name;

	public Event(string name){
		this.name = name;
	}

	public string getName(){
		return this.name;
	}

	public void emit(){
		Event.emit (this);
	}

	public static void emit(Event ev){
		EventListener.Call (ev);
	}

}
