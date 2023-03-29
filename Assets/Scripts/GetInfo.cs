using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetInfo : MonoBehaviour
{
    [SerializeField] private string url;
    [SerializeField] private RawImage image;
    
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            StartCoroutine(GetTexture(url));
        }
    }

    IEnumerator GetTexture(string url)
    {
        var request = UnityWebRequestTexture.GetTexture(url);
        var requestText = UnityWebRequest.Get(url);

        yield return requestText.SendWebRequest();

        // if (!request.isHttpError && !request.isNetworkError )
        // {
        //     image.texture = (Texture2D)(DownloadHandlerTexture.GetContent(request));
        //     Debug.Log($"Finished");
        // }
        // else
        // {
        //     Debug.LogErrorFormat("error request [{0}, {1}]", url, request.error);
        // }
        
        Debug.Log($"Second part");
        
        if (!requestText.isHttpError && !requestText.isNetworkError )
        {
            image.texture = (Texture2D)(DownloadHandlerTexture.GetContent(requestText));
            Debug.Log($"Finished");
        }
        else
        {
            Debug.LogErrorFormat("error request [{0}, {1}]", url, requestText.error);
        }

        request.Dispose();
    }
}
