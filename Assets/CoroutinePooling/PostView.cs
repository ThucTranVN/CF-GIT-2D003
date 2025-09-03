using System.Collections.Generic;
using UnityEngine;

public class PostView : MonoBehaviour
{
    [SerializeField]
    private PostViewItem prefItem;

    private void Awake()
    {
        //prefItem.gameObject.SetActive(false);
    }

    void Start()
    {
        if (Demo.HasInstance)
        {
            Demo.Instance.OnGetPostDTO += OnGetPostData;
            Demo.Instance.GetPostData(Demo.Instance.DemoLink1);
        }
    }

    private void OnDestroy()
    {
        if (Demo.HasInstance)
        {
            Demo.Instance.OnGetPostDTO -= OnGetPostData;
        }
    }


    private void OnGetPostData(List<PostDTO> datas)
    {
        if(datas?.Count > 0)
        {
            foreach (var data in datas)
            {
                PostViewItem viewItem = Instantiate(prefItem, prefItem.transform.parent);
                viewItem.Init(data);
                //prefItem.gameObject.SetActive(true);
            }
        }
    }
}
