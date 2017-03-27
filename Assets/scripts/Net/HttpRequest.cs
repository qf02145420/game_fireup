using UnityEngine;
using System.Collections;


using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;

public delegate void NetCallBack(string str);

public class HttpRequest : MonoBehaviour {

    public static HttpRequest instence;
    void Awake()
    {
        instence = this;
    }
    public void WWWError(string err)
    {
        Debug.Log(err);
    }

    public IEnumerator HttpRequest_Get(string protocelname, string parameterstr, NetCallBack nc)
    {
        string url = GameData.serverUrl + protocelname + "?" + parameterstr;
        //url = System.Uri.EscapeUriString(url);
        WWW www = new WWW(url);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            nc(www.text); 
            www.Dispose();
        }
        else {
            WWWError(www.error);
        }
    }

    public IEnumerator HttpRequest_Post(string protocelname, string jsondata, NetCallBack nc)
    {
        string url = GameData.serverUrl + protocelname;

        WWWForm wf = new WWWForm();
        wf.AddField("json",jsondata);

        WWW www = new WWW(url, wf);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            nc(www.text);
            www.Dispose();
        }
        else {
            WWWError(www.error);
        }
    }


    /*
    public IEnumerator GetUserData(NetCallBack nc)
    {
        // Create a form object for sending high score data to the server
        WWWForm form = new WWWForm();
        // Assuming the perl script manages high scores for different games
        form.AddField("game", "MyGameName");

        //Create a download object
        WWW download = new WWW(url, form);

        // Wait until the download is done
        yield return download;

        if (!string.IsNullOrEmpty(download.error))
        {
            print("Error downloading: " + download.error);
        }
        else {
            // show the highscores
            nc(download.text);
        }

          var jsonstring=ToJSON(mydata);
          var form = new WWWForm();
          form.AddField("jsonstring", jsonstring);
          var postwww: WWW = new WWW(jsonURL1, form);
          yield postwww;
          print(postwww.data);
    }
    */
}
