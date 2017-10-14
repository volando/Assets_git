
using UnityEngine;


[RequireComponent (typeof(AudioSource))]
public class WaveForm : MonoBehaviour
{
	public AudioSource audio;
	AudioClip ac;
	public  static float[] samples = new float[512];
	public  static float[] _freqBand = new float[8];
	int numOfSamples;
	public int sca;

	

	// Use this for initialization
	void Awake ()
	{
		audio = gameObject.GetComponent<AudioSource> ();
		audio.clip = Microphone.Start ("Built-in Microphone", true, 10, 44100);
		audio.loop = true;

		while (!(Microphone.GetPosition (null) > 0)) {
		}
		audio.Play ();
	}

	void Update ()
	{
//		float[] spectrum = new float[64];

		AudioListener.GetSpectrumData (samples, 1, FFTWindow.Blackman);

		for (int i = 1; i < samples.Length - 1; i++) {
			Debug.DrawLine (new Vector3 (i, samples [i] * sca, 0), new Vector3 (i + 1, samples [i + 1] * sca, 0), Color.white);
		}

		MakeFrequencyBands ();
	}

	void MakeFrequencyBands ()
	{
		int count = 0;

		for (int i = 0; i < 8; i++) {
//

			float average = 0;
			int sampleCount = (int)Mathf.Pow (2, i) * 2;

			if (i == 7) {
				sampleCount += 2;
			}

			for (int j = 0; j < sampleCount; j++) {
				average += samples [count] * (count + 1);
				count++;

			}

			average /= count;

			_freqBand [i] = average * 10;

//			print ("freqs " + _freqBand [i]);
		}

	}
}

