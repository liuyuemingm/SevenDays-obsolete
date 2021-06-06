using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour
{

	public void OpenInstagram()
	{
#if !UNITY_EDITOR
		openWindow("https://www.instagram.com/liuyuemingm/");
#endif
	}

	public void OpenYouTube()
	{
#if !UNITY_EDITOR
		openWindow("https://www.youtube.com/channel/UCWC2FMpsqdekceaIOEXy6aw");
#endif
	}

	public void OpenBilibili()
	{
#if !UNITY_EDITOR
		openWindow("https://space.bilibili.com/455968471");
#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}