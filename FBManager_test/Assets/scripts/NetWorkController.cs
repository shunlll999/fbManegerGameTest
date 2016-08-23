using UnityEngine;
using System.Collections;

public class PostData{

	public string requestFor = "chooseDrill";
	public int score = -1;

}

public class NetWorkController : MonoBehaviour {


	static NetWorkController _instance = null;

	public static NetWorkController Instance{

		get{
			if(_instance == null){


				if( _instance == null ){

					GameObject go = new GameObject("_NetWorkController");
					DontDestroyOnLoad(go);
					_instance = go.AddComponent<NetWorkController>();

				}
			}
			return _instance;
		}

	}

	public enum Events{ GET_DATA_EVENT, POST_DATA_EVENT }  
	public delegate void RequestData( JSONObject obj );
	RequestData callBack;
	string url = "http://localhost:8100/values";
	PostData postData;

	public void GetData( Events eventstring , string parameters, PostData postData , RequestData callBack ){
		this.callBack = callBack;
		if( postData != null ){
			this.postData = postData;
		}


		switch( eventstring ){
			case Events.GET_DATA_EVENT:
				StartCoroutine("LoadData", url+"/"+parameters);
			break;

			case Events.POST_DATA_EVENT:
				StartCoroutine("PostData", url);
			break;
		}


	}

	IEnumerator LoadData( string url ){

		Debug.Log(url);
		WWW www = new WWW(url);
		yield return www;

		JSONObject obj = new JSONObject(www.text);
		callBack(obj);

	}

	IEnumerator PostData( string url ){

		Debug.Log(url);
		// Create a form object for sending high score data to the server
		WWWForm form = new WWWForm();
		// Assuming the perl script manages high scores for different games
		form.AddField( "game", "MyGameName" );
		// The name of the player submitting the scores
		form.AddField( "request", postData.requestFor );
		// The score
		form.AddField( "score", postData.score );

		// Create a download object
		WWW download = new WWW( url, form.data );

		// Wait until the download is done
		yield return download;

		if(!string.IsNullOrEmpty(download.error)) {
			Debug.Log( "Error downloading: " + download.error );
		} else {
			JSONObject obj = new JSONObject(download.text);
			callBack(obj);
		}

	}

}
