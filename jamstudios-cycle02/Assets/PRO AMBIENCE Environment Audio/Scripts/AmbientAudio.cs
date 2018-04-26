using UnityEngine;
using System.Collections;

public class AmbientAudio : MonoBehaviour {

	[Header("Audio Source References")]
	public AudioSource loopAudioSource;
	public AudioSource soundAudioSource;
	public AudioSource startEndSource;

	[Header("Ambient Loop Playback Controls")]
	[Tooltip("The ambient audio and triggered sounds, if selected, will start automatically")]
	public bool playOnStart=true;
	[Tooltip("Should the ambient audio loop start at a random position")]
	public bool randomiseStartPosition=false;
	[Tooltip("The audio will be faded in when started and out when stopped")]
	public bool fadeAudio;
	[Tooltip("The amount of time, in seconds, for the audio to fade in or out")]
	public float fadeTime=3;
	[Tooltip("If set, this sound will play when the ambience is started")]
	public AudioClip startSound;
	[Tooltip("If set, this sound will play when the ambience is stopped")]
	public AudioClip endSound;

	[Header("One Shot Sound Playback Controls")]
	[Tooltip("The sounds to be randomly triggered, populate this list with audio clips")]
	public AudioClip[] oneShotAudioClips;
	[Tooltip("The shortest interval between triggered sounds")]
	public float minInterval=3;
	[Tooltip("The longest interval between triggered sounds")]
	public float maxInterval=15;
	[Tooltip("Sounds can be triggered before the last sound is finished playing")]
	public bool dontWaitForLastSound=false;
	[Tooltip("The maximum percentage variation in pitch. Leave at 0 to disable pitch variation")]
	[Range(0,100)]
	public float percentPitchVariation;
	[Tooltip("The maximum percentage variation in volume. Leave at 0 to disable volume variation")]
	[Range(0,100)]
	public float percentVolumeVariation;
	[Tooltip("The maximum amount of panning variation. Leave at 0 to disable panning variation")]
	[Range(0,100)]
	public float percentPanVariation;

	[Header("3D & Spatial Settings")]
	[Tooltip("Automatically removes spatial settings from all audio sources")]
	public bool force2D;
	[Tooltip("Automatically matches the 3D audio min and maximum distance settings for all sources to the Ambient Loop's Setting")]
	public bool autoMatch3DDistance;

	[HideInInspector]
	public bool audioPlaying;
	float defaultLoopVolume;
	float defaultSoundVolume;
	float defaultPitch;
	float defaultPan;
	float minAreaSize;
	float maxAreaSize;

	// Use this for initialization
	void Awake () 
	{
		defaultLoopVolume=loopAudioSource.volume;
		defaultSoundVolume=soundAudioSource.volume;
		defaultPitch=soundAudioSource.pitch;
		defaultPan=soundAudioSource.panStereo;
		minAreaSize=loopAudioSource.minDistance;
		maxAreaSize=loopAudioSource.maxDistance;

		SetupSpatialisation(loopAudioSource);
		SetupSpatialisation(soundAudioSource);
		SetupSpatialisation(startEndSource);

		if(fadeAudio)
		{
			loopAudioSource.volume=0;
			soundAudioSource.volume=0;
		}

		if (playOnStart)
		{
			StartAudio();
		}
	}

	// Call this to begin playback

	public void StartAudio()
	{
		audioPlaying=true;
		if(!loopAudioSource.isPlaying)
		{
			if(randomiseStartPosition)
				loopAudioSource.time=Random.Range(0f,loopAudioSource.clip.length-1f); 
			loopAudioSource.Play();
		}
		if(fadeAudio)
			StartCoroutine(FadeIn ());
		if(startSound)
		{
			startEndSource.clip=startSound;
			startEndSource.Play();
		}
		if(oneShotAudioClips.Length>0)
			StartCoroutine(Sounds ());
	}

	// Call this to stop playback

	public void StopAudio()
	{
		if(fadeAudio)
			StartCoroutine(FadeOut ());
		else
		{
			loopAudioSource.Stop();
			soundAudioSource.Stop();
			audioPlaying=false;
			StopAllCoroutines();
		}
		
		if(endSound)
		{
			startEndSource.clip=endSound;
			startEndSource.Play();
		}
	}

	IEnumerator FadeIn()
	{
		while(loopAudioSource.volume < defaultLoopVolume)
		{

			loopAudioSource.volume += defaultLoopVolume * (Time.deltaTime / fadeTime);
			soundAudioSource.volume += defaultSoundVolume * (Time.deltaTime / fadeTime);
			yield return null;
		}
	}

	IEnumerator FadeOut()
	{
		while(loopAudioSource.volume > 0)
			{
				
				loopAudioSource.volume -= defaultLoopVolume * (Time.deltaTime / fadeTime);
				soundAudioSource.volume -= defaultSoundVolume * (Time.deltaTime / fadeTime);
				yield return null;
			}
		loopAudioSource.Stop();
		soundAudioSource.Stop();
		audioPlaying=false;
		StopAllCoroutines();
	}

	IEnumerator Sounds()
	{
		if(oneShotAudioClips.Length==0)
		{
			Debug.Log("Ambient Audio - No One Sounds To Trigger.");
			yield break;
		}
		while(audioPlaying)
		{
			yield return new WaitForSeconds(Random.Range(minInterval,maxInterval));

			if(!dontWaitForLastSound)
			{
				if(!soundAudioSource.isPlaying)
				{
					PlayOneShot();
				}
			}
			else
			{
				PlayOneShot();
			}
			yield return null;
		}
	}

	void PlayOneShot()
	{
		soundAudioSource.clip = oneShotAudioClips[Random.Range(0,oneShotAudioClips.Length)];
		soundAudioSource.pitch = Mathf.Clamp(Random.Range(defaultPitch/100*(100-percentPitchVariation),defaultPitch/100*(100+percentPitchVariation)),0,3);
		soundAudioSource.volume = Mathf.Clamp(Random.Range(defaultSoundVolume/100*(100-percentVolumeVariation),defaultSoundVolume/100*(100+percentVolumeVariation)),0,1);
		soundAudioSource.panStereo = Mathf.Clamp(Random.Range(defaultPan-(percentPanVariation/100),defaultPan+(percentPanVariation/100)),-1,1);
		soundAudioSource.Play();
	}

	void SetupSpatialisation(AudioSource sourceToSpatialise)
	{
		if(!force2D)
		{
			if(autoMatch3DDistance)
			sourceToSpatialise.minDistance=minAreaSize;
			sourceToSpatialise.maxDistance=maxAreaSize;
		}
		else
			sourceToSpatialise.spatialBlend=0;
	}
}

