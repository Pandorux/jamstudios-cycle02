**** PRO AMBIENCE: Environment Audio ****

Environment Audio includes a scripted player to easily create immersive background audio for your game project as well as over 20 preconfigured Prefabs to choose from, covering a wide range of in game scenarios.

** ADDING AN AMBIENT LOOP TO THE BLANK PLAYER **

To add a loop to the player, add the loop to the Audio Clip field on the AmbientLoop Game Object’s Audio Source. There is no need to select play on awake, as this is controlled via the script.

** ADDING ONE SHOT-SOUNDS **

To have the player trigger random one-shot sounds, drag one or more sounds into the One Shot Audio Clips array in the Ambient Audio script’s settings. The frequency of sounds is controlled with the MIN & MAX interval settings. Selecting ‘Dont Wait For Last Sound’ will allow a newly triggered sound to cut off the previous sound if it’s still playing.

** START & END SOUNDS **

You can add an optional start and end sound to the audio using the Start Sound and End Sound fields in the script controls. These will be triggered when the audio starts and finishes.

** ADJUSTING VOLUME & PITCH **

Volume, pitch and panning can be adjusted directly on the Audio Sources, these are found on the three child game objects within the player.

** ADJUSTING RANDOMISATION **

One shot sounds can be randomised by a percentage of their original value using the corresponding sliders in the script controls.

** ADJUSTING 3D SETTINGS **

3D Settings can be adjusted via individual Audio Source settings. Custom curves have been preconfigured for a realistic ambient stereo image however these can be reconfigured as required.

** FORCE 2D **

Selecting Force 2D in the script settings will overwrite all 3D settings and revert to a 2D sound with no spatialisation.

** AUTO MATCH 3D DISTANCE **

For convenience this setting will copy the 3D settings from the Ambient Loop Audio Source and apply them to the One Shot and Start / End Audio Sources.

** SUPPORT / CONTACT **

For more information please contact me at http://www.johnleonardfrench.co.uk/contact 