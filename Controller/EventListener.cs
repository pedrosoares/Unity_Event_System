using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventListener {

	private static Dictionary<string, List<EventListener>> listeners = new Dictionary<string, List<EventListener>>();

	public static void addListener(string event_name, EventListener listener){
		List<EventListener> events_listeners;
		if (EventListener.listeners.ContainsKey (event_name)) {
			EventListener.listeners.TryGetValue (event_name, out events_listeners);	
		} else {
			events_listeners = new List<EventListener> ();
			EventListener.listeners.Add (event_name, events_listeners);
		}
		events_listeners.Add (listener);
	}

	public static void Call(Event triggered){
		List<EventListener> events_listeners;
		if (EventListener.listeners.ContainsKey (triggered.getName())) {
			EventListener.listeners.TryGetValue (triggered.getName(), out events_listeners);	
		} else {
			return;
		}

		foreach(EventListener ev in events_listeners){
			ev.handle (triggered);
		}
	}

	public abstract void handle (Event event_);

}
