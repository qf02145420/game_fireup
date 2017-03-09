using UnityEngine;
using System.Collections;


using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;

public delegate void NetCall(string str);

public class HttpRequest : MonoBehaviour {

    public static HttpRequest instence;
    public string url = "www.outingball.com";
    void Awake()
    {

    }

    

    public IEnumerator GetUserData(NetCall nc)
    {
        // Create a form object for sending high score data to the server
        WWWForm form = new WWWForm();
        // Assuming the perl script manages high scores for different games
        form.AddField("game", "MyGameName");

        // Create a download object
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
    }
}
