using UnityEngine;
using System.Collections;

public class stopLocationService : TestLocationService {

	public void stopLocationServiceOnClick(){

		// Stop service if there is no need to query location updates continuously
		Input.location.Stop();
		Debug.LogWarning("Service stopped.");
		geolocationStatus.text = "Location service stopped.";
	}
}
