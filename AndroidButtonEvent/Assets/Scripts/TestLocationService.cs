

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestLocationService : MonoBehaviour
{
	//class variables available in GUI
	public Text geolocationStatus;
	public Text latitude;
	public Text longitude;
	public Text altitude;
	public Text horizontalAccuracy;
	public Text mHeadingAccuracy;
	public Text mMagneticHeading;
	public Text mRawVector;
	public Text mTrueHeading;
	public Text lastDataTimestamp;

	void onGui(){
		Debug.LogWarning("In onGui.");
	}

	IEnumerator Start()
    {
		Input.compass.enabled = true;

		//Debug.LogWarning("Got a button click.");
		Debug.LogWarning("In start.");
		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser)
			yield break;

		// Start service before querying location
		Input.location.Start();
		Debug.LogWarning("Service Started.");
		geolocationStatus.text = "Location service started.";

		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			Debug.LogWarning("Max wait.");
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		// Service didn't initialize in 20 seconds
		if (maxWait < 1)
		{
			Debug.LogWarning("Timed out.");
			geolocationStatus.text = "Timed out";
			yield break;
		}

		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed)
		{
			Debug.LogWarning("Unable to determine device location.");
			geolocationStatus.text = "Unable to determine device location";
			yield break;
		}
		else
		{
			Debug.LogWarning("Setting variables.");
			// Access granted and location value could be retrieved
			latitude.text = "latitude is " + Input.location.lastData.latitude.ToString();
			longitude.text = "longitude is " + Input.location.lastData.longitude.ToString ();
			altitude.text = "altitude is " + Input.location.lastData.altitude.ToString ();
			horizontalAccuracy.text = "horizontal accuracy is " + Input.location.lastData.horizontalAccuracy.ToString ();
			lastDataTimestamp.text = "Last Data Timestamp is " + Input.location.lastData.timestamp.ToString();

			//Compass 
			mHeadingAccuracy.text = "Heading Accuracy is " + Input.compass.headingAccuracy.ToString();
			mMagneticHeading.text = "Magnetic Heading is " + Input.compass.magneticHeading.ToString();
			mRawVector.text = "Raw Vector is " + Input.compass.rawVector.ToString();
			mTrueHeading.text = "True Heading is " + Input.compass.trueHeading.ToString();
			//transform.rotation = Quaternion.Euler(0, -Input.compass.magneticHeading, 0);
		}

		// Stop service if there is no need to query location updates continuously
		//Input.location.Stop();
		//Debug.LogWarning("Service stopped.");
		//geolocationStatus.text = "Location service stopped.";

    }

	void Update(){

		//Compass 
		mHeadingAccuracy.text = "Heading Accuracy is " + Input.compass.headingAccuracy.ToString();
		mMagneticHeading.text = "Magnetic Heading is " + Input.compass.magneticHeading.ToString();
		mRawVector.text = "Raw Vector is " + Input.compass.rawVector.ToString();
		mTrueHeading.text = "True Heading is " + Input.compass.trueHeading.ToString();
	}

	public void getGeoOnClick (){

		geolocationStatus.text = "onClick";
		//if (lastDataTimestamp.text != Input.location.lastData.timestamp.ToString()) {
			//geolocationStatus.text = "new data";
		latitude.text = "onClick latitude is " + Input.location.lastData.latitude.ToString ();
		longitude.text = "onClick longitude is " + Input.location.lastData.longitude.ToString ();
		altitude.text = "onClick altitude is " + Input.location.lastData.altitude.ToString ();
		horizontalAccuracy.text = "onClick horizontal accuracy is " + Input.location.lastData.horizontalAccuracy.ToString ();
		lastDataTimestamp.text = "onClick Last Data Timestamp is " + Input.location.lastData.timestamp.ToString();
		//}
		// Stop service if there is no need to query location updates continuously
		Input.location.Stop();
		Debug.LogWarning("Service stopped.");
		geolocationStatus.text = "Location service stopped.";
	}



	
	}
