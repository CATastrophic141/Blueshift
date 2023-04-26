# BlueShift

## Blueshift is a cooperative project aiming at using the Unity engine to develop a VR horror game.

## Team
```
Joshua Glaspey
Naulsberry Jean Baptiste
Rylan Simpson
```

## Assets	[ Name / Author / Liscence / URL / Status ]
```
HiTech SciFi Energy Cell	AntiDed GameDev		Extension Asset			https://assetstore.unity.com/packages/3d/environments/sci-fi/hitech-scifi-energy-cell-154526		Orignal
Kitchen Cabinets - Low Poly	Alstra Infinite		Extension Asset			https://assetstore.unity.com/packages/3d/props/interior/kitchen-cabinets-low-poly-183890		Modified
Lever Power Switch		Sam Feng		CC Attribution			https://sketchfab.com/3d-models/lever-power-switch-374608f75c114b8a9bf41dbc02c51c50			Modified
Locker				VIS Games		Extension Asset			https://assetstore.unity.com/packages/3d/props/locker-56405						Original
Modular Sci-Fi Corridor Pack	Team Proton		Single Entity			https://assetstore.unity.com/packages/3d/environments/sci-fi/modular-sci-fi-corridor-pack-193228	Original
Monster Ceratos			Alex Sop		Single Entity			https://assetstore.unity.com/packages/3d/characters/creatures/monster-ceratos-190965			Original
Oculus Controller Art		Meta Quest		Not Listed (Attribution)	https://developer.oculus.com/downloads/package/oculus-controller-art/					Original
Oculus Hand Models		Meta Quest		Not Listed (Attribution)	https://developer.oculus.com/downloads/package/oculus-hand-models/ 					Original
Old Military Bed		Next Level 3D		Extension Asset			https://assetstore.unity.com/packages/3d/props/interior/old-military-bed-40205				Original
Particle Pack			Unity Technologies	Extension Asset			https://assetstore.unity.com/packages/vfx/particles/particle-pack-127325				Original
Quick Outline			Chris Nolet		Extension Asset			https://assetstore.unity.com/packages/tools/particles-effects/quick-outline-115488			Original
Sci-fi GUI skin			3d.rina			Extension Asset			https://assetstore.unity.com/packages/2d/gui/sci-fi-gui-skin-15606					Original
VR Real Clock			Zulubo			Extension Asset			https://assetstore.unity.com/packages/tools/particles-effects/vr-real-clock-76098			Modified
Yughues Free Metal Materials	Nobiax / Yughues	Extension Asset			https://assetstore.unity.com/packages/2d/textures-materials/metals/yughues-free-metal-materials-12949	Original
```

## Additional Resources	[ Use / Authors ]
```
Level Soundtracks		Aporcyphos, Kammarheit, Atrium Carceri
Chase Theme & Sound Effects	Fesilyan Studios, Epidemic Sound
Monster Sound Effects		Mixkit
```

## Packages Used	[ Name / (Use) ]
```
OpenXR 		(VR compatability and functionalities for Unity)
ProBuilder	(Level design ; Functionality for paramaterized shape creation and modification)
ProGrids	(Level design ; Editor grids and snap functionality)
TextMeshPro	(Text in levels)
```

## Expected AI Behavior
```
This documentation block outlines the key overall behavior patterns of Ceratos,
 the enemy monster of the game, Blueshitft.

>>> LOGIC
>> Ceratos's behavior has been constructed via a modified state machine pattern of logic
> Begins behavior in the start of a level by patrolling
	-> Randomly visits a set of waypoints in the level
		--> More likely to choose waypoints that:
			- Are in front of Ceratos
			- Have not been just previously visited
			- Are nearby previous sightings of the player
> If the player enters Ceratos' hearing range, Ceratos will pause as if listening
	-> If the player moves while they are in the hearing range, Ceratos will investigate the sound
		--> If the player is not seen after investigating, Ceratos resumes its patrol
		--> If the player is seen after investigating, Ceratos will begin the chase
> If the player is seen while Ceratos is patrolling or listening, Ceratos will begin to chase the player
	-> If the player is caught, the player dies and the level is reset
	-> If Ceratos loses sight of the player, Ceratos will continue to the last sighted location of the player
		--> If Ceratos does not see the player, Ceratos will begin its listening state
		--> If Ceratos sees the player, the chase resumes
		--> If the player hides and Ceratos sees the player hide, Ceratos will still go to and kill the player
		--> If the player hides and Ceratos does not see the player hide, Ceratos should not go to and kill the player.
			---> Ceratos should still go to the last sighted location of the player
		--> All chase and investigative behaviors should pause/resume in correspondance with the time freezing mechanic
> If time is frozen during any behavior, Ceratos should freeze in place and not interact with anything or have its logic updated from any player action
	-> When time resumes, Ceratos should resume its previous behavior

>>> ANIMATION
> Ceratos should patrol with a walking animaion
	-> A random footstep should play every time Ceratos' foot hits the ground in animation
> When Ceratos is chasing the player, a running animation should play
	-> A random footstep should play every time Ceratos' foot hits the ground in animation
> When Ceratos is listening or has visited a waypoint, an idle animation should play
> When the player is caught, Ceratos should begin a roaring animation
> When time is frozen, the animator itself should pause, and Ceratos' animation should stop mid-action
```

## VR APK Installation / Download
```
For VR titles, they run on the .apk file extension. In order to load a .apk project onto the Meta Quest and Meta Quest 2, the following steps need to be taken:

1. Download the advanced installer of Sidequest. Sidequest is a developer's hub and file manager for the device.
https://sidequestvr.com/setup-howto

2. Connect the VR headset by USB to your computer in developer mode. Enable USB Debugging and Oculus Link.
- If developer mode is not enabled, move to step 3. Otherwise, skip to step 4.
- You can make sure this was done properly if the headset appears on the top-left of the Sidequest menu.

3. To enable developer mode on the Quest 2, follow the steps below.
	a. Navigate to the Oculus developer website and log in to your meta account.
		https://developer.oculus.com/manage/organizations/create/
	b. From the developer dashboard, verify your account by setting up two-factor authentication
	c. Optional: Once verified, navigate back to the developer dashboard and create a new organization. Choose a unique name.
	d. Power on your headset, and connect to the Meta Quest app on a phone or tablet. Ensure you are signed in with the same account.
	e. From the app go to "Menu", then the "Devices" icon.
	f. Click "Headset Settings." Then navigate to "Developer Mode" and toggle it on.
	g. Bravo, developer mode is enabled. Now, once your headset is plugged into your PC, enable USB Debugging and Oculus Link.

4. Navigate to "Install APK file from folder" icon in the top right menu bar, and select the .apk file for the game. 

5. Once it finishes, you can unplug the headset. It will be in the Apps library under "unknown sources."

>>> For this product, look for the file named "Blueshift" and select it. <<<
```
## XR Interaction Toolkit Support
```
A major problem with using the Unity XR Interaction Toolkit is dealing with collisions when using a continuous movement provider for a player.
There's no direct way to stop the user from walking through walls.
The struggle with this is that the provided scripts are protected, meaning that without an interface, these controls are unaccessible.
Therefore, as a working solution, we have devised the CustomContinuousMoveProvider script.
```

### Code: Interface, Locomotion Calculation, and Example
```csharp

	/* The following is documentation relevant to a custom modification of the OpenXR continuous movement provider, which provides for wall collision detection */

    /* INTERFACE */
	// The movement provider interfaces the ActionBasedContinuousMoveProvider class.
    public class CustomContinuousMoveProvider : ActionBasedContinuousMoveProvider

    /* LOCOMOTION CALCULATION FUNCTIONS*/
	// The following overrides MoveRig(), ReadInput(), and ComputeDesiredMove(), along with implement other methods to work as its own Continuous Move Provider script.

    // Override MoveRig with the same access modifier as in the base class
    protected override void MoveRig(Vector3 translationInWorldSpace)
    {
        base.MoveRig(translationInWorldSpace);
    }

    // Method to be called to move the player while referencing the continuous movement provider
    public void CustomMove(Vector3 translationInWorldSpace)
    {
        MoveRig(translationInWorldSpace);
    }

    // Method to get the input from the joystick
    protected override Vector2 ReadInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    // Override the ComputeDesiredMove method to customize the player's movement
    protected override Vector3 ComputeDesiredMove(Vector2 input)
    {
        return base.ComputeDesiredMove(input);
    }

    // Public function to calculate the next move vector
    public Vector3 ComputeMove()
    {
        return ComputeDesiredMove(ReadInput());
    }

/* It also allows to connect with a Player Controller script for collision projection.
*  If the next move input would land the player inside an object that should experience a collision,
*	 the controller script reverts the forward movement back to the previous location of the player.
* An example of implementing the Custom Continuous Move Provider into a Player Controller is shown below. */

    /* EXAMPLE*/
    // Create a collision layer mask
    int layerMask = (1 << LayerMask.NameToLayer("LayerWithCollisions1")) | (1 << LayerMask.NameToLayer("LayerWithCollisions2"));

    // Calculate the next movement vector
    Vector3 move = CustomContinuousMoveProvider.ComputeMove();            

    // If there's movement, check if there is a wall collider
    if (move.magnitude > 0.00001f)
    {
        // Calculate the player's next position based on the current input
        Vector3 nextPosition = transform.position + move;

        // Check for collisions at the next position
        if (Physics.CheckSphere(nextPosition, 0.2f, layerMask))
        {
            // Move the player back to their previous position
	    // Precondition: lastPosition is a Vector3 declared outside the Update() loop
            transform.position = lastPosition;
        }
        else
        {
            // Update the last position
            lastPosition = transform.position;
        }
    }

/* For convenience sake, a Continuous Move Provider is still attached to the locomotion manager,
 * but these values are copied to the Custom Continuous Move Provider via the Awake() function.*/
```

## Known Bugs
```
- If you enter a hiding location while you are visible and being chased by Ceratos,
	 and enter a hiding location not visible to Ceratos, it will not recognize that it "saw" the player hide
- Power lever on level 3 calls its functionality, but can detach from the wall / spaz out.
- Footstep audio playback can be inconsistent/unsynced with player movement
- Turning via joystick counts as "moving" in Ceratos' listening radius
- Infreqent & abnormal behavior when triggering pause menu
- Slight lag in level 2's hallway
```