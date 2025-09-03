using UnityEngine;
using TMPro;

public class PostViewItem : MonoBehaviour
{
    [SerializeField]
    private TMP_Text userId;
    [SerializeField]
    private TMP_Text postId;
    [SerializeField]
    private TMP_Text title;
    [SerializeField]
    private TMP_Text body;

    public void Init(PostDTO data)
    {
        userId.text = data.UserId.ToString();
        postId.text = data.Id.ToString();
        title.text = data.Title;
        body.text = data.Body;
    }
}
