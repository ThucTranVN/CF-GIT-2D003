using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class Demo : BaseManager<Demo>
{
    public string DemoLink1;
    public string DemoLink2;
    public string DemoLink3;

    public Action<List<PostDTO>> OnGetPostDTO;

    private List<PostDTO> postDTOs = new();

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        //GetPostData(DemoLink1);
    }

    public void GetPostData(string url)
    {
        CoroutineHelper.Call(GetRequest(url, (result) =>
        {
            if (!string.IsNullOrEmpty(result))
            {
                postDTOs = JsonConvert.DeserializeObject<List<PostDTO>>(result); // From Json to class

                OnGetPostDTO?.Invoke(postDTOs);

                //JsonConvert.SerializeObject(postDTOs); // From class to Json

                Debug.Log($"postDTOs Count: {postDTOs.Count} - {JsonConvert.SerializeObject(postDTOs)}");
            }
        }));
    }

    private IEnumerator GetRequest(string url, Action<string> result)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = url.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    result.Invoke(webRequest.downloadHandler.text);
                    Debug.Log("<color=green> " + pages[page] + ":\nReceived: " + webRequest.downloadHandler.text + " </color>");
                    break;
            }
        }
    }
}
