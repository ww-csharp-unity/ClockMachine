using UnityEngine;
using System.Collections;

public class GlobalTime : MonoBehaviour
{
	public float hours;
	public float minutes;
	public float seconds;
	public float totalSeconds;
	public float subSeconds;
	public bool callSubSecond;
	public bool stopSubSecond;

	private void Awake()
	{
		seconds = 0;
		StartCoroutine(GlobalTimer());
		StartCoroutine(SubSecond());
	}

	// suspend execution for waitTime seconds
	IEnumerator GlobalTimer()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			seconds++;
			totalSeconds++;
		}
	}

	IEnumerator SubSecond()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.15f);
			subSeconds++;
		}
	}

	private void Update()
	{
		if (seconds >= 60)
		{
			minutes++;
			seconds = 0;
		}

		if (minutes >= 60)
		{
			hours++;
			minutes = 0;
		}

		if (totalSeconds >= 1000)
		{
			totalSeconds = 0;
		}

		if (subSeconds >= 1000)
		{
			subSeconds = 0;
		}
	}
}


/* Used to control subSecond coroutine
		if (callSubSecond)
		{
			StartCoroutine(SubSecond());
		}

if (stopSubSecond)
{
	StopCoroutine(SubSecond());
}
*/
