using UnityEngine;

public class UIManager : BaseManager<UIManager>
{
    public GamePanel GamePanel;
    public MenuPanel MenuPanel;
    public WinPanel WinPanel;
    public LoosePanel LoosePanel;
    public SettingPanel SettingPanel;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        MenuPanel.gameObject.SetActive(true);
        WinPanel.gameObject.SetActive(false);
        LoosePanel.gameObject.SetActive(false);
        SettingPanel.gameObject.SetActive(false);
        GamePanel.gameObject.SetActive(false);
    }
}
