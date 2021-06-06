using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinkOnApp : MonoBehaviour
{

    public void OpenYouTube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCWC2FMpsqdekceaIOEXy6aw");
    }
    public void OpenIns()
    {
        Application.OpenURL("https://www.instagram.com/liuyuemingm/");
    }
    public void OpenBilibili()
    {
        Application.OpenURL("https://space.bilibili.com/455968471");
    }
}
