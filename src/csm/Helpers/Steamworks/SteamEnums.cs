// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2022 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

#define STEAMWORKS_LIN_OSX

#if !(UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX || STEAMWORKS_WIN || STEAMWORKS_LIN_OSX)
	#define DISABLESTEAMWORKS
#endif

#if !DISABLESTEAMWORKS

using Flags = System.FlagsAttribute;

namespace CSM.Helpers.Steamworks {
	//-----------------------------------------------------------------------------
	// Purpose: possible results when registering an activation code
	//-----------------------------------------------------------------------------
	public enum ERegisterActivationCodeResult : int {
		k_ERegisterActivationCodeResultOK = 0,
		k_ERegisterActivationCodeResultFail = 1,
		k_ERegisterActivationCodeResultAlreadyRegistered = 2,
		k_ERegisterActivationCodeResultTimeout = 3,
		k_ERegisterActivationCodeAlreadyOwned = 4,
	}

	//-----------------------------------------------------------------------------
	// Purpose: set of relationships to other users
	//-----------------------------------------------------------------------------
	public enum EFriendRelationship : int {
		k_EFriendRelationshipNone = 0,
		k_EFriendRelationshipBlocked = 1,			// this doesn't get stored; the user has just done an Ignore on an friendship invite
		k_EFriendRelationshipRequestRecipient = 2,
		k_EFriendRelationshipFriend = 3,
		k_EFriendRelationshipRequestInitiator = 4,
		k_EFriendRelationshipIgnored = 5,			// this is stored; the user has explicit blocked this other user from comments/chat/etc
		k_EFriendRelationshipIgnoredFriend = 6,
		k_EFriendRelationshipSuggested_DEPRECATED = 7,		// was used by the original implementation of the facebook linking feature, but now unused.

		// keep this updated
		k_EFriendRelationshipMax = 8,
	}

	//-----------------------------------------------------------------------------
	// Purpose: list of states a friend can be in
	//-----------------------------------------------------------------------------
	public enum EPersonaState : int {
		k_EPersonaStateOffline = 0,			// friend is not currently logged on
		k_EPersonaStateOnline = 1,			// friend is logged on
		k_EPersonaStateBusy = 2,			// user is on, but busy
		k_EPersonaStateAway = 3,			// auto-away feature
		k_EPersonaStateSnooze = 4,			// auto-away for a long time
		k_EPersonaStateLookingToTrade = 5,	// Online, trading
		k_EPersonaStateLookingToPlay = 6,	// Online, wanting to play
		k_EPersonaStateInvisible = 7,		// Online, but appears offline to friends.  This status is never published to clients.
		k_EPersonaStateMax,
	}

	//-----------------------------------------------------------------------------
	// Purpose: flags for enumerating friends list, or quickly checking a the relationship between users
	//-----------------------------------------------------------------------------
	[Flags]
	public enum EFriendFlags : int {
		k_EFriendFlagNone			= 0x00,
		k_EFriendFlagBlocked		= 0x01,
		k_EFriendFlagFriendshipRequested	= 0x02,
		k_EFriendFlagImmediate		= 0x04,			// "regular" friend
		k_EFriendFlagClanMember		= 0x08,
		k_EFriendFlagOnGameServer	= 0x10,
		// k_EFriendFlagHasPlayedWith	= 0x20,	// not currently used
		// k_EFriendFlagFriendOfFriend	= 0x40, // not currently used
		k_EFriendFlagRequestingFriendship = 0x80,
		k_EFriendFlagRequestingInfo = 0x100,
		k_EFriendFlagIgnored		= 0x200,
		k_EFriendFlagIgnoredFriend	= 0x400,
		// k_EFriendFlagSuggested		= 0x800,	// not used
		k_EFriendFlagChatMember		= 0x1000,
		k_EFriendFlagAll			= 0xFFFF,
	}

	//-----------------------------------------------------------------------------
	// Purpose: user restriction flags
	//-----------------------------------------------------------------------------
	public enum EUserRestriction : int {
		k_nUserRestrictionNone		= 0,	// no known chat/content restriction
		k_nUserRestrictionUnknown	= 1,	// we don't know yet (user offline)
		k_nUserRestrictionAnyChat	= 2,	// user is not allowed to (or can't) send/recv any chat
		k_nUserRestrictionVoiceChat	= 4,	// user is not allowed to (or can't) send/recv voice chat
		k_nUserRestrictionGroupChat	= 8,	// user is not allowed to (or can't) send/recv group chat
		k_nUserRestrictionRating	= 16,	// user is too young according to rating in current region
		k_nUserRestrictionGameInvites	= 32,	// user cannot send or recv game invites (e.g. mobile)
		k_nUserRestrictionTrading	= 64,	// user cannot participate in trading (console, mobile)
	}

	// These values are passed as parameters to the store
	public enum EOverlayToStoreFlag : int {
		k_EOverlayToStoreFlag_None = 0,
		k_EOverlayToStoreFlag_AddToCart = 1,
		k_EOverlayToStoreFlag_AddToCartAndShow = 2,
	}

	//-----------------------------------------------------------------------------
	// Purpose: Tells Steam where to place the browser window inside the overlay
	//-----------------------------------------------------------------------------
	public enum EActivateGameOverlayToWebPageMode : int {
		k_EActivateGameOverlayToWebPageMode_Default = 0,		// Browser will open next to all other windows that the user has open in the overlay.
																// The window will remain open, even if the user closes then re-opens the overlay.

		k_EActivateGameOverlayToWebPageMode_Modal = 1			// Browser will be opened in a special overlay configuration which hides all other windows
																// that the user has open in the overlay. When the user closes the overlay, the browser window
																// will also close. When the user closes the browser window, the overlay will automatically close.
	}

	//-----------------------------------------------------------------------------
	// Purpose: See GetProfileItemPropertyString and GetProfileItemPropertyUint
	//-----------------------------------------------------------------------------
	public enum ECommunityProfileItemType : int {
		k_ECommunityProfileItemType_AnimatedAvatar		 = 0,
		k_ECommunityProfileItemType_AvatarFrame			 = 1,
		k_ECommunityProfileItemType_ProfileModifier		 = 2,
		k_ECommunityProfileItemType_ProfileBackground	 = 3,
		k_ECommunityProfileItemType_MiniProfileBackground = 4,
	}

	public enum ECommunityProfileItemProperty : int {
		k_ECommunityProfileItemProperty_ImageSmall	   = 0, // string
		k_ECommunityProfileItemProperty_ImageLarge	   = 1, // string
		k_ECommunityProfileItemProperty_InternalName   = 2, // string
		k_ECommunityProfileItemProperty_Title		   = 3, // string
		k_ECommunityProfileItemProperty_Description	   = 4, // string
		k_ECommunityProfileItemProperty_AppID		   = 5, // uint32
		k_ECommunityProfileItemProperty_TypeID		   = 6, // uint32
		k_ECommunityProfileItemProperty_Class		   = 7, // uint32
		k_ECommunityProfileItemProperty_MovieWebM	   = 8, // string
		k_ECommunityProfileItemProperty_MovieMP4	   = 9, // string
		k_ECommunityProfileItemProperty_MovieWebMSmall = 10, // string
		k_ECommunityProfileItemProperty_MovieMP4Small  = 11, // string
	}

	// used in PersonaStateChange_t::m_nChangeFlags to describe what's changed about a user
	// these flags describe what the client has learned has changed recently, so on startup you'll see a name, avatar & relationship change for every friend
	[Flags]
	public enum EPersonaChange : int {
		k_EPersonaChangeName		= 0x0001,
		k_EPersonaChangeStatus		= 0x0002,
		k_EPersonaChangeComeOnline	= 0x0004,
		k_EPersonaChangeGoneOffline	= 0x0008,
		k_EPersonaChangeGamePlayed	= 0x0010,
		k_EPersonaChangeGameServer	= 0x0020,
		k_EPersonaChangeAvatar		= 0x0040,
		k_EPersonaChangeJoinedSource= 0x0080,
		k_EPersonaChangeLeftSource	= 0x0100,
		k_EPersonaChangeRelationshipChanged = 0x0200,
		k_EPersonaChangeNameFirstSet = 0x0400,
		k_EPersonaChangeBroadcast = 0x0800,
		k_EPersonaChangeNickname =	0x1000,
		k_EPersonaChangeSteamLevel = 0x2000,
		k_EPersonaChangeRichPresence = 0x4000,
	}

	// list of possible return values from the ISteamGameCoordinator API
	public enum EGCResults : int {
		k_EGCResultOK = 0,
		k_EGCResultNoMessage = 1,			// There is no message in the queue
		k_EGCResultBufferTooSmall = 2,		// The buffer is too small for the requested message
		k_EGCResultNotLoggedOn = 3,			// The client is not logged onto Steam
		k_EGCResultInvalidMessage = 4,		// Something was wrong with the message being sent with SendMessage
	}

	public enum EHTMLMouseButton : int {
		eHTMLMouseButton_Left = 0,
		eHTMLMouseButton_Right = 1,
		eHTMLMouseButton_Middle = 2,
	}

	public enum EMouseCursor : int {
		dc_user = 0,
		dc_none,
		dc_arrow,
		dc_ibeam,
		dc_hourglass,
		dc_waitarrow,
		dc_crosshair,
		dc_up,
		dc_sizenw,
		dc_sizese,
		dc_sizene,
		dc_sizesw,
		dc_sizew,
		dc_sizee,
		dc_sizen,
		dc_sizes,
		dc_sizewe,
		dc_sizens,
		dc_sizeall,
		dc_no,
		dc_hand,
		dc_blank, // don't show any custom cursor, just use your default
		dc_middle_pan,
		dc_north_pan,
		dc_north_east_pan,
		dc_east_pan,
		dc_south_east_pan,
		dc_south_pan,
		dc_south_west_pan,
		dc_west_pan,
		dc_north_west_pan,
		dc_alias,
		dc_cell,
		dc_colresize,
		dc_copycur,
		dc_verticaltext,
		dc_rowresize,
		dc_zoomin,
		dc_zoomout,
		dc_help,
		dc_custom,

		dc_last, // custom cursors start from this value and up
	}

	[Flags]
	public enum EHTMLKeyModifiers : int {
		k_eHTMLKeyModifier_None = 0,
		k_eHTMLKeyModifier_AltDown = 1 << 0,
		k_eHTMLKeyModifier_CtrlDown = 1 << 1,
		k_eHTMLKeyModifier_ShiftDown = 1 << 2,
	}

	public enum EInputSourceMode : int {
		k_EInputSourceMode_None,
		k_EInputSourceMode_Dpad,
		k_EInputSourceMode_Buttons,
		k_EInputSourceMode_FourButtons,
		k_EInputSourceMode_AbsoluteMouse,
		k_EInputSourceMode_RelativeMouse,
		k_EInputSourceMode_JoystickMove,
		k_EInputSourceMode_JoystickMouse,
		k_EInputSourceMode_JoystickCamera,
		k_EInputSourceMode_ScrollWheel,
		k_EInputSourceMode_Trigger,
		k_EInputSourceMode_TouchMenu,
		k_EInputSourceMode_MouseJoystick,
		k_EInputSourceMode_MouseRegion,
		k_EInputSourceMode_RadialMenu,
		k_EInputSourceMode_SingleButton,
		k_EInputSourceMode_Switches
	}

	// Note: Please do not use action origins as a way to identify controller types. There is no
	// guarantee that they will be added in a contiguous manner - use GetInputTypeForHandle instead.
	// Versions of Steam that add new controller types in the future will extend this enum so if you're
	// using a lookup table please check the bounds of any origins returned by Steam.
	public enum EInputActionOrigin : int {
		// Steam Controller
		k_EInputActionOrigin_None,
		k_EInputActionOrigin_SteamController_A,
		k_EInputActionOrigin_SteamController_B,
		k_EInputActionOrigin_SteamController_X,
		k_EInputActionOrigin_SteamController_Y,
		k_EInputActionOrigin_SteamController_LeftBumper,
		k_EInputActionOrigin_SteamController_RightBumper,
		k_EInputActionOrigin_SteamController_LeftGrip,
		k_EInputActionOrigin_SteamController_RightGrip,
		k_EInputActionOrigin_SteamController_Start,
		k_EInputActionOrigin_SteamController_Back,
		k_EInputActionOrigin_SteamController_LeftPad_Touch,
		k_EInputActionOrigin_SteamController_LeftPad_Swipe,
		k_EInputActionOrigin_SteamController_LeftPad_Click,
		k_EInputActionOrigin_SteamController_LeftPad_DPadNorth,
		k_EInputActionOrigin_SteamController_LeftPad_DPadSouth,
		k_EInputActionOrigin_SteamController_LeftPad_DPadWest,
		k_EInputActionOrigin_SteamController_LeftPad_DPadEast,
		k_EInputActionOrigin_SteamController_RightPad_Touch,
		k_EInputActionOrigin_SteamController_RightPad_Swipe,
		k_EInputActionOrigin_SteamController_RightPad_Click,
		k_EInputActionOrigin_SteamController_RightPad_DPadNorth,
		k_EInputActionOrigin_SteamController_RightPad_DPadSouth,
		k_EInputActionOrigin_SteamController_RightPad_DPadWest,
		k_EInputActionOrigin_SteamController_RightPad_DPadEast,
		k_EInputActionOrigin_SteamController_LeftTrigger_Pull,
		k_EInputActionOrigin_SteamController_LeftTrigger_Click,
		k_EInputActionOrigin_SteamController_RightTrigger_Pull,
		k_EInputActionOrigin_SteamController_RightTrigger_Click,
		k_EInputActionOrigin_SteamController_LeftStick_Move,
		k_EInputActionOrigin_SteamController_LeftStick_Click,
		k_EInputActionOrigin_SteamController_LeftStick_DPadNorth,
		k_EInputActionOrigin_SteamController_LeftStick_DPadSouth,
		k_EInputActionOrigin_SteamController_LeftStick_DPadWest,
		k_EInputActionOrigin_SteamController_LeftStick_DPadEast,
		k_EInputActionOrigin_SteamController_Gyro_Move,
		k_EInputActionOrigin_SteamController_Gyro_Pitch,
		k_EInputActionOrigin_SteamController_Gyro_Yaw,
		k_EInputActionOrigin_SteamController_Gyro_Roll,
		k_EInputActionOrigin_SteamController_Reserved0,
		k_EInputActionOrigin_SteamController_Reserved1,
		k_EInputActionOrigin_SteamController_Reserved2,
		k_EInputActionOrigin_SteamController_Reserved3,
		k_EInputActionOrigin_SteamController_Reserved4,
		k_EInputActionOrigin_SteamController_Reserved5,
		k_EInputActionOrigin_SteamController_Reserved6,
		k_EInputActionOrigin_SteamController_Reserved7,
		k_EInputActionOrigin_SteamController_Reserved8,
		k_EInputActionOrigin_SteamController_Reserved9,
		k_EInputActionOrigin_SteamController_Reserved10,

		// PS4 Dual Shock
		k_EInputActionOrigin_PS4_X,
		k_EInputActionOrigin_PS4_Circle,
		k_EInputActionOrigin_PS4_Triangle,
		k_EInputActionOrigin_PS4_Square,
		k_EInputActionOrigin_PS4_LeftBumper,
		k_EInputActionOrigin_PS4_RightBumper,
		k_EInputActionOrigin_PS4_Options,	//Start
		k_EInputActionOrigin_PS4_Share,		//Back
		k_EInputActionOrigin_PS4_LeftPad_Touch,
		k_EInputActionOrigin_PS4_LeftPad_Swipe,
		k_EInputActionOrigin_PS4_LeftPad_Click,
		k_EInputActionOrigin_PS4_LeftPad_DPadNorth,
		k_EInputActionOrigin_PS4_LeftPad_DPadSouth,
		k_EInputActionOrigin_PS4_LeftPad_DPadWest,
		k_EInputActionOrigin_PS4_LeftPad_DPadEast,
		k_EInputActionOrigin_PS4_RightPad_Touch,
		k_EInputActionOrigin_PS4_RightPad_Swipe,
		k_EInputActionOrigin_PS4_RightPad_Click,
		k_EInputActionOrigin_PS4_RightPad_DPadNorth,
		k_EInputActionOrigin_PS4_RightPad_DPadSouth,
		k_EInputActionOrigin_PS4_RightPad_DPadWest,
		k_EInputActionOrigin_PS4_RightPad_DPadEast,
		k_EInputActionOrigin_PS4_CenterPad_Touch,
		k_EInputActionOrigin_PS4_CenterPad_Swipe,
		k_EInputActionOrigin_PS4_CenterPad_Click,
		k_EInputActionOrigin_PS4_CenterPad_DPadNorth,
		k_EInputActionOrigin_PS4_CenterPad_DPadSouth,
		k_EInputActionOrigin_PS4_CenterPad_DPadWest,
		k_EInputActionOrigin_PS4_CenterPad_DPadEast,
		k_EInputActionOrigin_PS4_LeftTrigger_Pull,
		k_EInputActionOrigin_PS4_LeftTrigger_Click,
		k_EInputActionOrigin_PS4_RightTrigger_Pull,
		k_EInputActionOrigin_PS4_RightTrigger_Click,
		k_EInputActionOrigin_PS4_LeftStick_Move,
		k_EInputActionOrigin_PS4_LeftStick_Click,
		k_EInputActionOrigin_PS4_LeftStick_DPadNorth,
		k_EInputActionOrigin_PS4_LeftStick_DPadSouth,
		k_EInputActionOrigin_PS4_LeftStick_DPadWest,
		k_EInputActionOrigin_PS4_LeftStick_DPadEast,
		k_EInputActionOrigin_PS4_RightStick_Move,
		k_EInputActionOrigin_PS4_RightStick_Click,
		k_EInputActionOrigin_PS4_RightStick_DPadNorth,
		k_EInputActionOrigin_PS4_RightStick_DPadSouth,
		k_EInputActionOrigin_PS4_RightStick_DPadWest,
		k_EInputActionOrigin_PS4_RightStick_DPadEast,
		k_EInputActionOrigin_PS4_DPad_North,
		k_EInputActionOrigin_PS4_DPad_South,
		k_EInputActionOrigin_PS4_DPad_West,
		k_EInputActionOrigin_PS4_DPad_East,
		k_EInputActionOrigin_PS4_Gyro_Move,
		k_EInputActionOrigin_PS4_Gyro_Pitch,
		k_EInputActionOrigin_PS4_Gyro_Yaw,
		k_EInputActionOrigin_PS4_Gyro_Roll,
		k_EInputActionOrigin_PS4_DPad_Move,
		k_EInputActionOrigin_PS4_Reserved1,
		k_EInputActionOrigin_PS4_Reserved2,
		k_EInputActionOrigin_PS4_Reserved3,
		k_EInputActionOrigin_PS4_Reserved4,
		k_EInputActionOrigin_PS4_Reserved5,
		k_EInputActionOrigin_PS4_Reserved6,
		k_EInputActionOrigin_PS4_Reserved7,
		k_EInputActionOrigin_PS4_Reserved8,
		k_EInputActionOrigin_PS4_Reserved9,
		k_EInputActionOrigin_PS4_Reserved10,

		// XBox One
		k_EInputActionOrigin_XBoxOne_A,
		k_EInputActionOrigin_XBoxOne_B,
		k_EInputActionOrigin_XBoxOne_X,
		k_EInputActionOrigin_XBoxOne_Y,
		k_EInputActionOrigin_XBoxOne_LeftBumper,
		k_EInputActionOrigin_XBoxOne_RightBumper,
		k_EInputActionOrigin_XBoxOne_Menu,  //Start
		k_EInputActionOrigin_XBoxOne_View,  //Back
		k_EInputActionOrigin_XBoxOne_LeftTrigger_Pull,
		k_EInputActionOrigin_XBoxOne_LeftTrigger_Click,
		k_EInputActionOrigin_XBoxOne_RightTrigger_Pull,
		k_EInputActionOrigin_XBoxOne_RightTrigger_Click,
		k_EInputActionOrigin_XBoxOne_LeftStick_Move,
		k_EInputActionOrigin_XBoxOne_LeftStick_Click,
		k_EInputActionOrigin_XBoxOne_LeftStick_DPadNorth,
		k_EInputActionOrigin_XBoxOne_LeftStick_DPadSouth,
		k_EInputActionOrigin_XBoxOne_LeftStick_DPadWest,
		k_EInputActionOrigin_XBoxOne_LeftStick_DPadEast,
		k_EInputActionOrigin_XBoxOne_RightStick_Move,
		k_EInputActionOrigin_XBoxOne_RightStick_Click,
		k_EInputActionOrigin_XBoxOne_RightStick_DPadNorth,
		k_EInputActionOrigin_XBoxOne_RightStick_DPadSouth,
		k_EInputActionOrigin_XBoxOne_RightStick_DPadWest,
		k_EInputActionOrigin_XBoxOne_RightStick_DPadEast,
		k_EInputActionOrigin_XBoxOne_DPad_North,
		k_EInputActionOrigin_XBoxOne_DPad_South,
		k_EInputActionOrigin_XBoxOne_DPad_West,
		k_EInputActionOrigin_XBoxOne_DPad_East,
		k_EInputActionOrigin_XBoxOne_DPad_Move,
		k_EInputActionOrigin_XBoxOne_LeftGrip_Lower,
		k_EInputActionOrigin_XBoxOne_LeftGrip_Upper,
		k_EInputActionOrigin_XBoxOne_RightGrip_Lower,
		k_EInputActionOrigin_XBoxOne_RightGrip_Upper,
		k_EInputActionOrigin_XBoxOne_Share, // Xbox Series X controllers only
		k_EInputActionOrigin_XBoxOne_Reserved6,
		k_EInputActionOrigin_XBoxOne_Reserved7,
		k_EInputActionOrigin_XBoxOne_Reserved8,
		k_EInputActionOrigin_XBoxOne_Reserved9,
		k_EInputActionOrigin_XBoxOne_Reserved10,

		// XBox 360
		k_EInputActionOrigin_XBox360_A,
		k_EInputActionOrigin_XBox360_B,
		k_EInputActionOrigin_XBox360_X,
		k_EInputActionOrigin_XBox360_Y,
		k_EInputActionOrigin_XBox360_LeftBumper,
		k_EInputActionOrigin_XBox360_RightBumper,
		k_EInputActionOrigin_XBox360_Start,		//Start
		k_EInputActionOrigin_XBox360_Back,		//Back
		k_EInputActionOrigin_XBox360_LeftTrigger_Pull,
		k_EInputActionOrigin_XBox360_LeftTrigger_Click,
		k_EInputActionOrigin_XBox360_RightTrigger_Pull,
		k_EInputActionOrigin_XBox360_RightTrigger_Click,
		k_EInputActionOrigin_XBox360_LeftStick_Move,
		k_EInputActionOrigin_XBox360_LeftStick_Click,
		k_EInputActionOrigin_XBox360_LeftStick_DPadNorth,
		k_EInputActionOrigin_XBox360_LeftStick_DPadSouth,
		k_EInputActionOrigin_XBox360_LeftStick_DPadWest,
		k_EInputActionOrigin_XBox360_LeftStick_DPadEast,
		k_EInputActionOrigin_XBox360_RightStick_Move,
		k_EInputActionOrigin_XBox360_RightStick_Click,
		k_EInputActionOrigin_XBox360_RightStick_DPadNorth,
		k_EInputActionOrigin_XBox360_RightStick_DPadSouth,
		k_EInputActionOrigin_XBox360_RightStick_DPadWest,
		k_EInputActionOrigin_XBox360_RightStick_DPadEast,
		k_EInputActionOrigin_XBox360_DPad_North,
		k_EInputActionOrigin_XBox360_DPad_South,
		k_EInputActionOrigin_XBox360_DPad_West,
		k_EInputActionOrigin_XBox360_DPad_East,
		k_EInputActionOrigin_XBox360_DPad_Move,
		k_EInputActionOrigin_XBox360_Reserved1,
		k_EInputActionOrigin_XBox360_Reserved2,
		k_EInputActionOrigin_XBox360_Reserved3,
		k_EInputActionOrigin_XBox360_Reserved4,
		k_EInputActionOrigin_XBox360_Reserved5,
		k_EInputActionOrigin_XBox360_Reserved6,
		k_EInputActionOrigin_XBox360_Reserved7,
		k_EInputActionOrigin_XBox360_Reserved8,
		k_EInputActionOrigin_XBox360_Reserved9,
		k_EInputActionOrigin_XBox360_Reserved10,


		// Switch - Pro or Joycons used as a single input device.
		// This does not apply to a single joycon
		k_EInputActionOrigin_Switch_A,
		k_EInputActionOrigin_Switch_B,
		k_EInputActionOrigin_Switch_X,
		k_EInputActionOrigin_Switch_Y,
		k_EInputActionOrigin_Switch_LeftBumper,
		k_EInputActionOrigin_Switch_RightBumper,
		k_EInputActionOrigin_Switch_Plus,	//Start
		k_EInputActionOrigin_Switch_Minus,	//Back
		k_EInputActionOrigin_Switch_Capture,
		k_EInputActionOrigin_Switch_LeftTrigger_Pull,
		k_EInputActionOrigin_Switch_LeftTrigger_Click,
		k_EInputActionOrigin_Switch_RightTrigger_Pull,
		k_EInputActionOrigin_Switch_RightTrigger_Click,
		k_EInputActionOrigin_Switch_LeftStick_Move,
		k_EInputActionOrigin_Switch_LeftStick_Click,
		k_EInputActionOrigin_Switch_LeftStick_DPadNorth,
		k_EInputActionOrigin_Switch_LeftStick_DPadSouth,
		k_EInputActionOrigin_Switch_LeftStick_DPadWest,
		k_EInputActionOrigin_Switch_LeftStick_DPadEast,
		k_EInputActionOrigin_Switch_RightStick_Move,
		k_EInputActionOrigin_Switch_RightStick_Click,
		k_EInputActionOrigin_Switch_RightStick_DPadNorth,
		k_EInputActionOrigin_Switch_RightStick_DPadSouth,
		k_EInputActionOrigin_Switch_RightStick_DPadWest,
		k_EInputActionOrigin_Switch_RightStick_DPadEast,
		k_EInputActionOrigin_Switch_DPad_North,
		k_EInputActionOrigin_Switch_DPad_South,
		k_EInputActionOrigin_Switch_DPad_West,
		k_EInputActionOrigin_Switch_DPad_East,
		k_EInputActionOrigin_Switch_ProGyro_Move,  // Primary Gyro in Pro Controller, or Right JoyCon
		k_EInputActionOrigin_Switch_ProGyro_Pitch,  // Primary Gyro in Pro Controller, or Right JoyCon
		k_EInputActionOrigin_Switch_ProGyro_Yaw,  // Primary Gyro in Pro Controller, or Right JoyCon
		k_EInputActionOrigin_Switch_ProGyro_Roll,  // Primary Gyro in Pro Controller, or Right JoyCon
		k_EInputActionOrigin_Switch_DPad_Move,
		k_EInputActionOrigin_Switch_Reserved1,
		k_EInputActionOrigin_Switch_Reserved2,
		k_EInputActionOrigin_Switch_Reserved3,
		k_EInputActionOrigin_Switch_Reserved4,
		k_EInputActionOrigin_Switch_Reserved5,
		k_EInputActionOrigin_Switch_Reserved6,
		k_EInputActionOrigin_Switch_Reserved7,
		k_EInputActionOrigin_Switch_Reserved8,
		k_EInputActionOrigin_Switch_Reserved9,
		k_EInputActionOrigin_Switch_Reserved10,

		// Switch JoyCon Specific
		k_EInputActionOrigin_Switch_RightGyro_Move,  // Right JoyCon Gyro generally should correspond to Pro's single gyro
		k_EInputActionOrigin_Switch_RightGyro_Pitch,  // Right JoyCon Gyro generally should correspond to Pro's single gyro
		k_EInputActionOrigin_Switch_RightGyro_Yaw,  // Right JoyCon Gyro generally should correspond to Pro's single gyro
		k_EInputActionOrigin_Switch_RightGyro_Roll,  // Right JoyCon Gyro generally should correspond to Pro's single gyro
		k_EInputActionOrigin_Switch_LeftGyro_Move,
		k_EInputActionOrigin_Switch_LeftGyro_Pitch,
		k_EInputActionOrigin_Switch_LeftGyro_Yaw,
		k_EInputActionOrigin_Switch_LeftGyro_Roll,
		k_EInputActionOrigin_Switch_LeftGrip_Lower, // Left JoyCon SR Button
		k_EInputActionOrigin_Switch_LeftGrip_Upper, // Left JoyCon SL Button
		k_EInputActionOrigin_Switch_RightGrip_Lower,  // Right JoyCon SL Button
		k_EInputActionOrigin_Switch_RightGrip_Upper,  // Right JoyCon SR Button
		k_EInputActionOrigin_Switch_Reserved11,
		k_EInputActionOrigin_Switch_Reserved12,
		k_EInputActionOrigin_Switch_Reserved13,
		k_EInputActionOrigin_Switch_Reserved14,
		k_EInputActionOrigin_Switch_Reserved15,
		k_EInputActionOrigin_Switch_Reserved16,
		k_EInputActionOrigin_Switch_Reserved17,
		k_EInputActionOrigin_Switch_Reserved18,
		k_EInputActionOrigin_Switch_Reserved19,
		k_EInputActionOrigin_Switch_Reserved20,

		// Added in SDK 1.51
		k_EInputActionOrigin_PS5_X,
		k_EInputActionOrigin_PS5_Circle,
		k_EInputActionOrigin_PS5_Triangle,
		k_EInputActionOrigin_PS5_Square,
		k_EInputActionOrigin_PS5_LeftBumper,
		k_EInputActionOrigin_PS5_RightBumper,
		k_EInputActionOrigin_PS5_Option,	//Start
		k_EInputActionOrigin_PS5_Create,		//Back
		k_EInputActionOrigin_PS5_Mute,
		k_EInputActionOrigin_PS5_LeftPad_Touch,
		k_EInputActionOrigin_PS5_LeftPad_Swipe,
		k_EInputActionOrigin_PS5_LeftPad_Click,
		k_EInputActionOrigin_PS5_LeftPad_DPadNorth,
		k_EInputActionOrigin_PS5_LeftPad_DPadSouth,
		k_EInputActionOrigin_PS5_LeftPad_DPadWest,
		k_EInputActionOrigin_PS5_LeftPad_DPadEast,
		k_EInputActionOrigin_PS5_RightPad_Touch,
		k_EInputActionOrigin_PS5_RightPad_Swipe,
		k_EInputActionOrigin_PS5_RightPad_Click,
		k_EInputActionOrigin_PS5_RightPad_DPadNorth,
		k_EInputActionOrigin_PS5_RightPad_DPadSouth,
		k_EInputActionOrigin_PS5_RightPad_DPadWest,
		k_EInputActionOrigin_PS5_RightPad_DPadEast,
		k_EInputActionOrigin_PS5_CenterPad_Touch,
		k_EInputActionOrigin_PS5_CenterPad_Swipe,
		k_EInputActionOrigin_PS5_CenterPad_Click,
		k_EInputActionOrigin_PS5_CenterPad_DPadNorth,
		k_EInputActionOrigin_PS5_CenterPad_DPadSouth,
		k_EInputActionOrigin_PS5_CenterPad_DPadWest,
		k_EInputActionOrigin_PS5_CenterPad_DPadEast,
		k_EInputActionOrigin_PS5_LeftTrigger_Pull,
		k_EInputActionOrigin_PS5_LeftTrigger_Click,
		k_EInputActionOrigin_PS5_RightTrigger_Pull,
		k_EInputActionOrigin_PS5_RightTrigger_Click,
		k_EInputActionOrigin_PS5_LeftStick_Move,
		k_EInputActionOrigin_PS5_LeftStick_Click,
		k_EInputActionOrigin_PS5_LeftStick_DPadNorth,
		k_EInputActionOrigin_PS5_LeftStick_DPadSouth,
		k_EInputActionOrigin_PS5_LeftStick_DPadWest,
		k_EInputActionOrigin_PS5_LeftStick_DPadEast,
		k_EInputActionOrigin_PS5_RightStick_Move,
		k_EInputActionOrigin_PS5_RightStick_Click,
		k_EInputActionOrigin_PS5_RightStick_DPadNorth,
		k_EInputActionOrigin_PS5_RightStick_DPadSouth,
		k_EInputActionOrigin_PS5_RightStick_DPadWest,
		k_EInputActionOrigin_PS5_RightStick_DPadEast,
		k_EInputActionOrigin_PS5_DPad_North,
		k_EInputActionOrigin_PS5_DPad_South,
		k_EInputActionOrigin_PS5_DPad_West,
		k_EInputActionOrigin_PS5_DPad_East,
		k_EInputActionOrigin_PS5_Gyro_Move,
		k_EInputActionOrigin_PS5_Gyro_Pitch,
		k_EInputActionOrigin_PS5_Gyro_Yaw,
		k_EInputActionOrigin_PS5_Gyro_Roll,
		k_EInputActionOrigin_PS5_DPad_Move,
		k_EInputActionOrigin_PS5_Reserved1,
		k_EInputActionOrigin_PS5_Reserved2,
		k_EInputActionOrigin_PS5_Reserved3,
		k_EInputActionOrigin_PS5_Reserved4,
		k_EInputActionOrigin_PS5_Reserved5,
		k_EInputActionOrigin_PS5_Reserved6,
		k_EInputActionOrigin_PS5_Reserved7,
		k_EInputActionOrigin_PS5_Reserved8,
		k_EInputActionOrigin_PS5_Reserved9,
		k_EInputActionOrigin_PS5_Reserved10,
		k_EInputActionOrigin_PS5_Reserved11,
		k_EInputActionOrigin_PS5_Reserved12,
		k_EInputActionOrigin_PS5_Reserved13,
		k_EInputActionOrigin_PS5_Reserved14,
		k_EInputActionOrigin_PS5_Reserved15,
		k_EInputActionOrigin_PS5_Reserved16,
		k_EInputActionOrigin_PS5_Reserved17,
		k_EInputActionOrigin_PS5_Reserved18,
		k_EInputActionOrigin_PS5_Reserved19,
		k_EInputActionOrigin_PS5_Reserved20,

		// Added in SDK 1.53
		k_EInputActionOrigin_SteamDeck_A,
		k_EInputActionOrigin_SteamDeck_B,
		k_EInputActionOrigin_SteamDeck_X,
		k_EInputActionOrigin_SteamDeck_Y,
		k_EInputActionOrigin_SteamDeck_L1,
		k_EInputActionOrigin_SteamDeck_R1,
		k_EInputActionOrigin_SteamDeck_Menu,
		k_EInputActionOrigin_SteamDeck_View,
		k_EInputActionOrigin_SteamDeck_LeftPad_Touch,
		k_EInputActionOrigin_SteamDeck_LeftPad_Swipe,
		k_EInputActionOrigin_SteamDeck_LeftPad_Click,
		k_EInputActionOrigin_SteamDeck_LeftPad_DPadNorth,
		k_EInputActionOrigin_SteamDeck_LeftPad_DPadSouth,
		k_EInputActionOrigin_SteamDeck_LeftPad_DPadWest,
		k_EInputActionOrigin_SteamDeck_LeftPad_DPadEast,
		k_EInputActionOrigin_SteamDeck_RightPad_Touch,
		k_EInputActionOrigin_SteamDeck_RightPad_Swipe,
		k_EInputActionOrigin_SteamDeck_RightPad_Click,
		k_EInputActionOrigin_SteamDeck_RightPad_DPadNorth,
		k_EInputActionOrigin_SteamDeck_RightPad_DPadSouth,
		k_EInputActionOrigin_SteamDeck_RightPad_DPadWest,
		k_EInputActionOrigin_SteamDeck_RightPad_DPadEast,
		k_EInputActionOrigin_SteamDeck_L2_SoftPull,
		k_EInputActionOrigin_SteamDeck_L2,
		k_EInputActionOrigin_SteamDeck_R2_SoftPull,
		k_EInputActionOrigin_SteamDeck_R2,
		k_EInputActionOrigin_SteamDeck_LeftStick_Move,
		k_EInputActionOrigin_SteamDeck_L3,
		k_EInputActionOrigin_SteamDeck_LeftStick_DPadNorth,
		k_EInputActionOrigin_SteamDeck_LeftStick_DPadSouth,
		k_EInputActionOrigin_SteamDeck_LeftStick_DPadWest,
		k_EInputActionOrigin_SteamDeck_LeftStick_DPadEast,
		k_EInputActionOrigin_SteamDeck_LeftStick_Touch,
		k_EInputActionOrigin_SteamDeck_RightStick_Move,
		k_EInputActionOrigin_SteamDeck_R3,
		k_EInputActionOrigin_SteamDeck_RightStick_DPadNorth,
		k_EInputActionOrigin_SteamDeck_RightStick_DPadSouth,
		k_EInputActionOrigin_SteamDeck_RightStick_DPadWest,
		k_EInputActionOrigin_SteamDeck_RightStick_DPadEast,
		k_EInputActionOrigin_SteamDeck_RightStick_Touch,
		k_EInputActionOrigin_SteamDeck_L4,
		k_EInputActionOrigin_SteamDeck_R4,
		k_EInputActionOrigin_SteamDeck_L5,
		k_EInputActionOrigin_SteamDeck_R5,
		k_EInputActionOrigin_SteamDeck_DPad_Move,
		k_EInputActionOrigin_SteamDeck_DPad_North,
		k_EInputActionOrigin_SteamDeck_DPad_South,
		k_EInputActionOrigin_SteamDeck_DPad_West,
		k_EInputActionOrigin_SteamDeck_DPad_East,
		k_EInputActionOrigin_SteamDeck_Gyro_Move,
		k_EInputActionOrigin_SteamDeck_Gyro_Pitch,
		k_EInputActionOrigin_SteamDeck_Gyro_Yaw,
		k_EInputActionOrigin_SteamDeck_Gyro_Roll,
		k_EInputActionOrigin_SteamDeck_Reserved1,
		k_EInputActionOrigin_SteamDeck_Reserved2,
		k_EInputActionOrigin_SteamDeck_Reserved3,
		k_EInputActionOrigin_SteamDeck_Reserved4,
		k_EInputActionOrigin_SteamDeck_Reserved5,
		k_EInputActionOrigin_SteamDeck_Reserved6,
		k_EInputActionOrigin_SteamDeck_Reserved7,
		k_EInputActionOrigin_SteamDeck_Reserved8,
		k_EInputActionOrigin_SteamDeck_Reserved9,
		k_EInputActionOrigin_SteamDeck_Reserved10,
		k_EInputActionOrigin_SteamDeck_Reserved11,
		k_EInputActionOrigin_SteamDeck_Reserved12,
		k_EInputActionOrigin_SteamDeck_Reserved13,
		k_EInputActionOrigin_SteamDeck_Reserved14,
		k_EInputActionOrigin_SteamDeck_Reserved15,
		k_EInputActionOrigin_SteamDeck_Reserved16,
		k_EInputActionOrigin_SteamDeck_Reserved17,
		k_EInputActionOrigin_SteamDeck_Reserved18,
		k_EInputActionOrigin_SteamDeck_Reserved19,
		k_EInputActionOrigin_SteamDeck_Reserved20,

		k_EInputActionOrigin_Count, // If Steam has added support for new controllers origins will go here.
		k_EInputActionOrigin_MaximumPossibleValue = 32767, // Origins are currently a maximum of 16 bits.
	}

	public enum EXboxOrigin : int {
		k_EXboxOrigin_A,
		k_EXboxOrigin_B,
		k_EXboxOrigin_X,
		k_EXboxOrigin_Y,
		k_EXboxOrigin_LeftBumper,
		k_EXboxOrigin_RightBumper,
		k_EXboxOrigin_Menu,  //Start
		k_EXboxOrigin_View,  //Back
		k_EXboxOrigin_LeftTrigger_Pull,
		k_EXboxOrigin_LeftTrigger_Click,
		k_EXboxOrigin_RightTrigger_Pull,
		k_EXboxOrigin_RightTrigger_Click,
		k_EXboxOrigin_LeftStick_Move,
		k_EXboxOrigin_LeftStick_Click,
		k_EXboxOrigin_LeftStick_DPadNorth,
		k_EXboxOrigin_LeftStick_DPadSouth,
		k_EXboxOrigin_LeftStick_DPadWest,
		k_EXboxOrigin_LeftStick_DPadEast,
		k_EXboxOrigin_RightStick_Move,
		k_EXboxOrigin_RightStick_Click,
		k_EXboxOrigin_RightStick_DPadNorth,
		k_EXboxOrigin_RightStick_DPadSouth,
		k_EXboxOrigin_RightStick_DPadWest,
		k_EXboxOrigin_RightStick_DPadEast,
		k_EXboxOrigin_DPad_North,
		k_EXboxOrigin_DPad_South,
		k_EXboxOrigin_DPad_West,
		k_EXboxOrigin_DPad_East,
		k_EXboxOrigin_Count,
	}

	public enum ESteamControllerPad : int {
		k_ESteamControllerPad_Left,
		k_ESteamControllerPad_Right
	}

	public enum EControllerHapticLocation : int {
		k_EControllerHapticLocation_Left = ( 1 << ESteamControllerPad.k_ESteamControllerPad_Left ),
		k_EControllerHapticLocation_Right = ( 1 << ESteamControllerPad.k_ESteamControllerPad_Right ),
		k_EControllerHapticLocation_Both = ( 1 << ESteamControllerPad.k_ESteamControllerPad_Left | 1 << ESteamControllerPad.k_ESteamControllerPad_Right ),
	}

	public enum EControllerHapticType : int {
		k_EControllerHapticType_Off,
		k_EControllerHapticType_Tick,
		k_EControllerHapticType_Click,
	}

	public enum ESteamInputType : int {
		k_ESteamInputType_Unknown,
		k_ESteamInputType_SteamController,
		k_ESteamInputType_XBox360Controller,
		k_ESteamInputType_XBoxOneController,
		k_ESteamInputType_GenericGamepad,		// DirectInput controllers
		k_ESteamInputType_PS4Controller,
		k_ESteamInputType_AppleMFiController,	// Unused
		k_ESteamInputType_AndroidController,	// Unused
		k_ESteamInputType_SwitchJoyConPair,		// Unused
		k_ESteamInputType_SwitchJoyConSingle,	// Unused
		k_ESteamInputType_SwitchProController,
		k_ESteamInputType_MobileTouch,			// Steam Link App On-screen Virtual Controller
		k_ESteamInputType_PS3Controller,		// Currently uses PS4 Origins
		k_ESteamInputType_PS5Controller,		// Added in SDK 151
		k_ESteamInputType_SteamDeckController,	// Added in SDK 153
		k_ESteamInputType_Count,
		k_ESteamInputType_MaximumPossibleValue = 255,
	}

	// Individual values are used by the GetSessionInputConfigurationSettings bitmask
	public enum ESteamInputConfigurationEnableType : int {
		k_ESteamInputConfigurationEnableType_None			= 0x0000,
		k_ESteamInputConfigurationEnableType_Playstation	= 0x0001,
		k_ESteamInputConfigurationEnableType_Xbox			= 0x0002,
		k_ESteamInputConfigurationEnableType_Generic		= 0x0004,
		k_ESteamInputConfigurationEnableType_Switch			= 0x0008,
	}

	// These values are passed into SetLEDColor
	public enum ESteamInputLEDFlag : int {
		k_ESteamInputLEDFlag_SetColor,
		// Restore the LED color to the user's preference setting as set in the controller personalization menu.
		// This also happens automatically on exit of your game.
		k_ESteamInputLEDFlag_RestoreUserDefault
	}

	// These values are passed into GetGlyphPNGForActionOrigin
	public enum ESteamInputGlyphSize : int {
		k_ESteamInputGlyphSize_Small,	// 32x32 pixels
		k_ESteamInputGlyphSize_Medium,	// 128x128 pixels
		k_ESteamInputGlyphSize_Large,	// 256x256 pixels
		k_ESteamInputGlyphSize_Count,
	}

	public enum ESteamInputGlyphStyle : int {
		// Base-styles - cannot mix
		ESteamInputGlyphStyle_Knockout 	= 0x0, // Face buttons will have colored labels/outlines on a knocked out background
											   // Rest of inputs will have white detail/borders on a knocked out background
		ESteamInputGlyphStyle_Light		= 0x1, // Black detail/borders on a white background
		ESteamInputGlyphStyle_Dark 		= 0x2, // White detail/borders on a black background

		// Modifiers
		// Default ABXY/PS equivalent glyphs have a solid fill w/ color matching the physical buttons on the device
		ESteamInputGlyphStyle_NeutralColorABXY 	= 0x10, // ABXY Buttons will match the base style color instead of their normal associated color
		ESteamInputGlyphStyle_SolidABXY 		= 0x20,	// ABXY Buttons will have a solid fill
	}

	public enum ESteamInputActionEventType : int {
		ESteamInputActionEventType_DigitalAction,
		ESteamInputActionEventType_AnalogAction,
	}

	[Flags]
	public enum ESteamItemFlags : int {
		// Item status flags - these flags are permanently attached to specific item instances
		k_ESteamItemNoTrade = 1 << 0, // This item is account-locked and cannot be traded or given away.

		// Action confirmation flags - these flags are set one time only, as part of a result set
		k_ESteamItemRemoved = 1 << 8,	// The item has been destroyed, traded away, expired, or otherwise invalidated
		k_ESteamItemConsumed = 1 << 9,	// The item quantity has been decreased by 1 via ConsumeItem API.

		// All other flag bits are currently reserved for internal Steam use at this time.
		// Do not assume anything about the state of other flags which are not defined here.
	}

	// lobby type description
	public enum ELobbyType : int {
		k_ELobbyTypePrivate = 0,		// only way to join the lobby is to invite to someone else
		k_ELobbyTypeFriendsOnly = 1,	// shows for friends or invitees, but not in lobby list
		k_ELobbyTypePublic = 2,			// visible for friends and in lobby list
		k_ELobbyTypeInvisible = 3,		// returned by search, but not visible to other friends
										//    useful if you want a user in two lobbies, for example matching groups together
										//	  a user can be in only one regular lobby, and up to two invisible lobbies
		k_ELobbyTypePrivateUnique = 4,	// private, unique and does not delete when empty - only one of these may exist per unique keypair set
										// can only create from webapi
	}

	// lobby search filter tools
	public enum ELobbyComparison : int {
		k_ELobbyComparisonEqualToOrLessThan = -2,
		k_ELobbyComparisonLessThan = -1,
		k_ELobbyComparisonEqual = 0,
		k_ELobbyComparisonGreaterThan = 1,
		k_ELobbyComparisonEqualToOrGreaterThan = 2,
		k_ELobbyComparisonNotEqual = 3,
	}

	// lobby search distance. Lobby results are sorted from closest to farthest.
	public enum ELobbyDistanceFilter : int {
		k_ELobbyDistanceFilterClose,		// only lobbies in the same immediate region will be returned
		k_ELobbyDistanceFilterDefault,		// only lobbies in the same region or near by regions
		k_ELobbyDistanceFilterFar,			// for games that don't have many latency requirements, will return lobbies about half-way around the globe
		k_ELobbyDistanceFilterWorldwide,	// no filtering, will match lobbies as far as India to NY (not recommended, expect multiple seconds of latency between the clients)
	}

	//-----------------------------------------------------------------------------
	// Purpose: Used in ChatInfo messages - fields specific to a chat member - must fit in a uint32
	//-----------------------------------------------------------------------------
	[Flags]
	public enum EChatMemberStateChange : int {
		// Specific to joining / leaving the chatroom
		k_EChatMemberStateChangeEntered			= 0x0001,		// This user has joined or is joining the chat room
		k_EChatMemberStateChangeLeft			= 0x0002,		// This user has left or is leaving the chat room
		k_EChatMemberStateChangeDisconnected	= 0x0004,		// User disconnected without leaving the chat first
		k_EChatMemberStateChangeKicked			= 0x0008,		// User kicked
		k_EChatMemberStateChangeBanned			= 0x0010,		// User kicked and banned
	}

	//-----------------------------------------------------------------------------
	// Purpose: Functions for quickly creating a Party with friends or acquaintances,
	//			EG from chat rooms.
	//-----------------------------------------------------------------------------
	public enum ESteamPartyBeaconLocationType : int {
		k_ESteamPartyBeaconLocationType_Invalid = 0,
		k_ESteamPartyBeaconLocationType_ChatGroup = 1,

		k_ESteamPartyBeaconLocationType_Max,
	}

	public enum ESteamPartyBeaconLocationData : int {
		k_ESteamPartyBeaconLocationDataInvalid = 0,
		k_ESteamPartyBeaconLocationDataName = 1,
		k_ESteamPartyBeaconLocationDataIconURLSmall = 2,
		k_ESteamPartyBeaconLocationDataIconURLMedium = 3,
		k_ESteamPartyBeaconLocationDataIconURLLarge = 4,
	}

	public enum PlayerAcceptState_t : int {
		k_EStateUnknown = 0,
		k_EStatePlayerAccepted = 1,
		k_EStatePlayerDeclined = 2,
	}

	//-----------------------------------------------------------------------------
	// Purpose:
	//-----------------------------------------------------------------------------
	public enum AudioPlayback_Status : int {
		AudioPlayback_Undefined = 0,
		AudioPlayback_Playing = 1,
		AudioPlayback_Paused = 2,
		AudioPlayback_Idle = 3
	}

	// list of possible errors returned by SendP2PPacket() API
	// these will be posted in the P2PSessionConnectFail_t callback
	public enum EP2PSessionError : int {
		k_EP2PSessionErrorNone = 0,
		k_EP2PSessionErrorNoRightsToApp = 2,			// local user doesn't own the app that is running
		k_EP2PSessionErrorTimeout = 4,					// target isn't responding, perhaps not calling AcceptP2PSessionWithUser()
														// corporate firewalls can also block this (NAT traversal is not firewall traversal)
														// make sure that UDP ports 3478, 4379, and 4380 are open in an outbound direction

		// The following error codes were removed and will never be sent.
		// For privacy reasons, there is no reply if the user is offline or playing another game.
		k_EP2PSessionErrorNotRunningApp_DELETED = 1,
		k_EP2PSessionErrorDestinationNotLoggedIn_DELETED = 3,

		k_EP2PSessionErrorMax = 5
	}

	// SendP2PPacket() send types
	// Typically k_EP2PSendUnreliable is what you want for UDP-like packets, k_EP2PSendReliable for TCP-like packets
	public enum EP2PSend : int {
		// Basic UDP send. Packets can't be bigger than 1200 bytes (your typical MTU size). Can be lost, or arrive out of order (rare).
		// The sending API does have some knowledge of the underlying connection, so if there is no NAT-traversal accomplished or
		// there is a recognized adjustment happening on the connection, the packet will be batched until the connection is open again.
		k_EP2PSendUnreliable = 0,

		// As above, but if the underlying p2p connection isn't yet established the packet will just be thrown away. Using this on the first
		// packet sent to a remote host almost guarantees the packet will be dropped.
		// This is only really useful for kinds of data that should never buffer up, i.e. voice payload packets
		k_EP2PSendUnreliableNoDelay = 1,

		// Reliable message send. Can send up to 1MB of data in a single message.
		// Does fragmentation/re-assembly of messages under the hood, as well as a sliding window for efficient sends of large chunks of data.
		k_EP2PSendReliable = 2,

		// As above, but applies the Nagle algorithm to the send - sends will accumulate
		// until the current MTU size (typically ~1200 bytes, but can change) or ~200ms has passed (Nagle algorithm).
		// Useful if you want to send a set of smaller messages but have the coalesced into a single packet
		// Since the reliable stream is all ordered, you can do several small message sends with k_EP2PSendReliableWithBuffering and then
		// do a normal k_EP2PSendReliable to force all the buffered data to be sent.
		k_EP2PSendReliableWithBuffering = 3,

	}

	// connection progress indicators, used by CreateP2PConnectionSocket()
	public enum ESNetSocketState : int {
		k_ESNetSocketStateInvalid = 0,

		// communication is valid
		k_ESNetSocketStateConnected = 1,

		// states while establishing a connection
		k_ESNetSocketStateInitiated = 10,				// the connection state machine has started

		// p2p connections
		k_ESNetSocketStateLocalCandidatesFound = 11,	// we've found our local IP info
		k_ESNetSocketStateReceivedRemoteCandidates = 12,// we've received information from the remote machine, via the Steam back-end, about their IP info

		// direct connections
		k_ESNetSocketStateChallengeHandshake = 15,		// we've received a challenge packet from the server

		// failure states
		k_ESNetSocketStateDisconnecting = 21,			// the API shut it down, and we're in the process of telling the other end
		k_ESNetSocketStateLocalDisconnect = 22,			// the API shut it down, and we've completed shutdown
		k_ESNetSocketStateTimeoutDuringConnect = 23,	// we timed out while trying to creating the connection
		k_ESNetSocketStateRemoteEndDisconnected = 24,	// the remote end has disconnected from us
		k_ESNetSocketStateConnectionBroken = 25,		// connection has been broken; either the other end has disappeared or our local network connection has broke

	}

	// describes how the socket is currently connected
	public enum ESNetSocketConnectionType : int {
		k_ESNetSocketConnectionTypeNotConnected = 0,
		k_ESNetSocketConnectionTypeUDP = 1,
		k_ESNetSocketConnectionTypeUDPRelay = 2,
	}

	// Feature types for parental settings
	public enum EParentalFeature : int {
		k_EFeatureInvalid = 0,
		k_EFeatureStore = 1,
		k_EFeatureCommunity = 2,
		k_EFeatureProfile = 3,
		k_EFeatureFriends = 4,
		k_EFeatureNews = 5,
		k_EFeatureTrading = 6,
		k_EFeatureSettings = 7,
		k_EFeatureConsole = 8,
		k_EFeatureBrowser = 9,
		k_EFeatureParentalSetup = 10,
		k_EFeatureLibrary = 11,
		k_EFeatureTest = 12,
		k_EFeatureSiteLicense = 13,
		k_EFeatureMax
	}

	//-----------------------------------------------------------------------------
	// Purpose: The form factor of a device
	//-----------------------------------------------------------------------------
	public enum ESteamDeviceFormFactor : int {
		k_ESteamDeviceFormFactorUnknown		= 0,
		k_ESteamDeviceFormFactorPhone		= 1,
		k_ESteamDeviceFormFactorTablet		= 2,
		k_ESteamDeviceFormFactorComputer	= 3,
		k_ESteamDeviceFormFactorTV			= 4,
	}

	[Flags]
	public enum ERemoteStoragePlatform : int {
		k_ERemoteStoragePlatformNone		= 0,
		k_ERemoteStoragePlatformWindows		= (1 << 0),
		k_ERemoteStoragePlatformOSX			= (1 << 1),
		k_ERemoteStoragePlatformPS3			= (1 << 2),
		k_ERemoteStoragePlatformLinux		= (1 << 3),
		k_ERemoteStoragePlatformSwitch		= (1 << 4),
		k_ERemoteStoragePlatformAndroid		= (1 << 5),
		k_ERemoteStoragePlatformIOS			= (1 << 6),
		// NB we get one more before we need to widen some things

		k_ERemoteStoragePlatformAll = -1
	}

	public enum ERemoteStoragePublishedFileVisibility : int {
		k_ERemoteStoragePublishedFileVisibilityPublic = 0,
		k_ERemoteStoragePublishedFileVisibilityFriendsOnly = 1,
		k_ERemoteStoragePublishedFileVisibilityPrivate = 2,
		k_ERemoteStoragePublishedFileVisibilityUnlisted = 3,
	}

	public enum EWorkshopFileType : int {
		k_EWorkshopFileTypeFirst = 0,

		k_EWorkshopFileTypeCommunity			  = 0,		// normal Workshop item that can be subscribed to
		k_EWorkshopFileTypeMicrotransaction		  = 1,		// Workshop item that is meant to be voted on for the purpose of selling in-game
		k_EWorkshopFileTypeCollection			  = 2,		// a collection of Workshop or Greenlight items
		k_EWorkshopFileTypeArt					  = 3,		// artwork
		k_EWorkshopFileTypeVideo				  = 4,		// external video
		k_EWorkshopFileTypeScreenshot			  = 5,		// screenshot
		k_EWorkshopFileTypeGame					  = 6,		// Greenlight game entry
		k_EWorkshopFileTypeSoftware				  = 7,		// Greenlight software entry
		k_EWorkshopFileTypeConcept				  = 8,		// Greenlight concept
		k_EWorkshopFileTypeWebGuide				  = 9,		// Steam web guide
		k_EWorkshopFileTypeIntegratedGuide		  = 10,		// application integrated guide
		k_EWorkshopFileTypeMerch				  = 11,		// Workshop merchandise meant to be voted on for the purpose of being sold
		k_EWorkshopFileTypeControllerBinding	  = 12,		// Steam Controller bindings
		k_EWorkshopFileTypeSteamworksAccessInvite = 13,		// internal
		k_EWorkshopFileTypeSteamVideo			  = 14,		// Steam video
		k_EWorkshopFileTypeGameManagedItem		  = 15,		// managed completely by the game, not the user, and not shown on the web

		// Update k_EWorkshopFileTypeMax if you add values.
		k_EWorkshopFileTypeMax = 16

	}

	public enum EWorkshopVote : int {
		k_EWorkshopVoteUnvoted = 0,
		k_EWorkshopVoteFor = 1,
		k_EWorkshopVoteAgainst = 2,
		k_EWorkshopVoteLater = 3,
	}

	public enum EWorkshopFileAction : int {
		k_EWorkshopFileActionPlayed = 0,
		k_EWorkshopFileActionCompleted = 1,
	}

	public enum EWorkshopEnumerationType : int {
		k_EWorkshopEnumerationTypeRankedByVote = 0,
		k_EWorkshopEnumerationTypeRecent = 1,
		k_EWorkshopEnumerationTypeTrending = 2,
		k_EWorkshopEnumerationTypeFavoritesOfFriends = 3,
		k_EWorkshopEnumerationTypeVotedByFriends = 4,
		k_EWorkshopEnumerationTypeContentByFriends = 5,
		k_EWorkshopEnumerationTypeRecentFromFollowedUsers = 6,
	}

	public enum EWorkshopVideoProvider : int {
		k_EWorkshopVideoProviderNone = 0,
		k_EWorkshopVideoProviderYoutube = 1
	}

	public enum EUGCReadAction : int {
		// Keeps the file handle open unless the last byte is read.  You can use this when reading large files (over 100MB) in sequential chunks.
		// If the last byte is read, this will behave the same as k_EUGCRead_Close.  Otherwise, it behaves the same as k_EUGCRead_ContinueReading.
		// This value maintains the same behavior as before the EUGCReadAction parameter was introduced.
		k_EUGCRead_ContinueReadingUntilFinished = 0,

		// Keeps the file handle open.  Use this when using UGCRead to seek to different parts of the file.
		// When you are done seeking around the file, make a final call with k_EUGCRead_Close to close it.
		k_EUGCRead_ContinueReading = 1,

		// Frees the file handle.  Use this when you're done reading the content.
		// To read the file from Steam again you will need to call UGCDownload again.
		k_EUGCRead_Close = 2,
	}

	public enum ERemoteStorageLocalFileChange : int {
		k_ERemoteStorageLocalFileChange_Invalid = 0,

		// The file was updated from another device
		k_ERemoteStorageLocalFileChange_FileUpdated = 1,

		// The file was deleted by another device
		k_ERemoteStorageLocalFileChange_FileDeleted = 2,
	}

	public enum ERemoteStorageFilePathType : int {
		k_ERemoteStorageFilePathType_Invalid = 0,

		// The file is directly accessed by the game and this is the full path
		k_ERemoteStorageFilePathType_Absolute = 1,

		// The file is accessed via the ISteamRemoteStorage API and this is the filename
		k_ERemoteStorageFilePathType_APIFilename = 2,
	}

	public enum EVRScreenshotType : int {
		k_EVRScreenshotType_None			= 0,
		k_EVRScreenshotType_Mono			= 1,
		k_EVRScreenshotType_Stereo			= 2,
		k_EVRScreenshotType_MonoCubemap		= 3,
		k_EVRScreenshotType_MonoPanorama	= 4,
		k_EVRScreenshotType_StereoPanorama	= 5
	}

	// Matching UGC types for queries
	public enum EUGCMatchingUGCType : int {
		k_EUGCMatchingUGCType_Items				 = 0,		// both mtx items and ready-to-use items
		k_EUGCMatchingUGCType_Items_Mtx			 = 1,
		k_EUGCMatchingUGCType_Items_ReadyToUse	 = 2,
		k_EUGCMatchingUGCType_Collections		 = 3,
		k_EUGCMatchingUGCType_Artwork			 = 4,
		k_EUGCMatchingUGCType_Videos			 = 5,
		k_EUGCMatchingUGCType_Screenshots		 = 6,
		k_EUGCMatchingUGCType_AllGuides			 = 7,		// both web guides and integrated guides
		k_EUGCMatchingUGCType_WebGuides			 = 8,
		k_EUGCMatchingUGCType_IntegratedGuides	 = 9,
		k_EUGCMatchingUGCType_UsableInGame		 = 10,		// ready-to-use items and integrated guides
		k_EUGCMatchingUGCType_ControllerBindings = 11,
		k_EUGCMatchingUGCType_GameManagedItems	 = 12,		// game managed items (not managed by users)
		k_EUGCMatchingUGCType_All				 = ~0,		// @note: will only be valid for CreateQueryUserUGCRequest requests
	}

	// Different lists of published UGC for a user.
	// If the current logged in user is different than the specified user, then some options may not be allowed.
	public enum EUserUGCList : int {
		k_EUserUGCList_Published,
		k_EUserUGCList_VotedOn,
		k_EUserUGCList_VotedUp,
		k_EUserUGCList_VotedDown,
		k_EUserUGCList_WillVoteLater,
		k_EUserUGCList_Favorited,
		k_EUserUGCList_Subscribed,
		k_EUserUGCList_UsedOrPlayed,
		k_EUserUGCList_Followed,
	}

	// Sort order for user published UGC lists (defaults to creation order descending)
	public enum EUserUGCListSortOrder : int {
		k_EUserUGCListSortOrder_CreationOrderDesc,
		k_EUserUGCListSortOrder_CreationOrderAsc,
		k_EUserUGCListSortOrder_TitleAsc,
		k_EUserUGCListSortOrder_LastUpdatedDesc,
		k_EUserUGCListSortOrder_SubscriptionDateDesc,
		k_EUserUGCListSortOrder_VoteScoreDesc,
		k_EUserUGCListSortOrder_ForModeration,
	}

	// Combination of sorting and filtering for queries across all UGC
	public enum EUGCQuery : int {
		k_EUGCQuery_RankedByVote								  = 0,
		k_EUGCQuery_RankedByPublicationDate						  = 1,
		k_EUGCQuery_AcceptedForGameRankedByAcceptanceDate		  = 2,
		k_EUGCQuery_RankedByTrend								  = 3,
		k_EUGCQuery_FavoritedByFriendsRankedByPublicationDate	  = 4,
		k_EUGCQuery_CreatedByFriendsRankedByPublicationDate		  = 5,
		k_EUGCQuery_RankedByNumTimesReported					  = 6,
		k_EUGCQuery_CreatedByFollowedUsersRankedByPublicationDate = 7,
		k_EUGCQuery_NotYetRated									  = 8,
		k_EUGCQuery_RankedByTotalVotesAsc						  = 9,
		k_EUGCQuery_RankedByVotesUp								  = 10,
		k_EUGCQuery_RankedByTextSearch							  = 11,
		k_EUGCQuery_RankedByTotalUniqueSubscriptions			  = 12,
		k_EUGCQuery_RankedByPlaytimeTrend						  = 13,
		k_EUGCQuery_RankedByTotalPlaytime						  = 14,
		k_EUGCQuery_RankedByAveragePlaytimeTrend				  = 15,
		k_EUGCQuery_RankedByLifetimeAveragePlaytime				  = 16,
		k_EUGCQuery_RankedByPlaytimeSessionsTrend				  = 17,
		k_EUGCQuery_RankedByLifetimePlaytimeSessions			  = 18,
		k_EUGCQuery_RankedByLastUpdatedDate						  = 19,
	}

	public enum EItemUpdateStatus : int {
		k_EItemUpdateStatusInvalid 				= 0, // The item update handle was invalid, job might be finished, listen too SubmitItemUpdateResult_t
		k_EItemUpdateStatusPreparingConfig 		= 1, // The item update is processing configuration data
		k_EItemUpdateStatusPreparingContent		= 2, // The item update is reading and processing content files
		k_EItemUpdateStatusUploadingContent		= 3, // The item update is uploading content changes to Steam
		k_EItemUpdateStatusUploadingPreviewFile	= 4, // The item update is uploading new preview file image
		k_EItemUpdateStatusCommittingChanges	= 5  // The item update is committing all changes
	}

	[Flags]
	public enum EItemState : int {
		k_EItemStateNone			= 0,	// item not tracked on client
		k_EItemStateSubscribed		= 1,	// current user is subscribed to this item. Not just cached.
		k_EItemStateLegacyItem		= 2,	// item was created with ISteamRemoteStorage
		k_EItemStateInstalled		= 4,	// item is installed and usable (but maybe out of date)
		k_EItemStateNeedsUpdate		= 8,	// items needs an update. Either because it's not installed yet or creator updated content
		k_EItemStateDownloading		= 16,	// item update is currently downloading
		k_EItemStateDownloadPending	= 32,	// DownloadItem() was called for this item, content isn't available until DownloadItemResult_t is fired
	}

	public enum EItemStatistic : int {
		k_EItemStatistic_NumSubscriptions					 = 0,
		k_EItemStatistic_NumFavorites						 = 1,
		k_EItemStatistic_NumFollowers						 = 2,
		k_EItemStatistic_NumUniqueSubscriptions				 = 3,
		k_EItemStatistic_NumUniqueFavorites					 = 4,
		k_EItemStatistic_NumUniqueFollowers					 = 5,
		k_EItemStatistic_NumUniqueWebsiteViews				 = 6,
		k_EItemStatistic_ReportScore						 = 7,
		k_EItemStatistic_NumSecondsPlayed					 = 8,
		k_EItemStatistic_NumPlaytimeSessions				 = 9,
		k_EItemStatistic_NumComments						 = 10,
		k_EItemStatistic_NumSecondsPlayedDuringTimePeriod	 = 11,
		k_EItemStatistic_NumPlaytimeSessionsDuringTimePeriod = 12,
	}

	public enum EItemPreviewType : int {
		k_EItemPreviewType_Image							= 0,	// standard image file expected (e.g. jpg, png, gif, etc.)
		k_EItemPreviewType_YouTubeVideo						= 1,	// video id is stored
		k_EItemPreviewType_Sketchfab						= 2,	// model id is stored
		k_EItemPreviewType_EnvironmentMap_HorizontalCross	= 3,	// standard image file expected - cube map in the layout
																	// +---+---+-------+
																	// |   |Up |       |
																	// +---+---+---+---+
																	// | L | F | R | B |
																	// +---+---+---+---+
																	// |   |Dn |       |
																	// +---+---+---+---+
		k_EItemPreviewType_EnvironmentMap_LatLong			= 4,	// standard image file expected
		k_EItemPreviewType_ReservedMax						= 255,	// you can specify your own types above this value
	}

	public enum EFailureType : int {
		k_EFailureFlushedCallbackQueue,
		k_EFailurePipeFail,
	}

	// type of data request, when downloading leaderboard entries
	public enum ELeaderboardDataRequest : int {
		k_ELeaderboardDataRequestGlobal = 0,
		k_ELeaderboardDataRequestGlobalAroundUser = 1,
		k_ELeaderboardDataRequestFriends = 2,
		k_ELeaderboardDataRequestUsers = 3
	}

	// the sort order of a leaderboard
	public enum ELeaderboardSortMethod : int {
		k_ELeaderboardSortMethodNone = 0,
		k_ELeaderboardSortMethodAscending = 1,	// top-score is lowest number
		k_ELeaderboardSortMethodDescending = 2,	// top-score is highest number
	}

	// the display type (used by the Steam Community web site) for a leaderboard
	public enum ELeaderboardDisplayType : int {
		k_ELeaderboardDisplayTypeNone = 0,
		k_ELeaderboardDisplayTypeNumeric = 1,			// simple numerical score
		k_ELeaderboardDisplayTypeTimeSeconds = 2,		// the score represents a time, in seconds
		k_ELeaderboardDisplayTypeTimeMilliSeconds = 3,	// the score represents a time, in milliseconds
	}

	public enum ELeaderboardUploadScoreMethod : int {
		k_ELeaderboardUploadScoreMethodNone = 0,
		k_ELeaderboardUploadScoreMethodKeepBest = 1,	// Leaderboard will keep user's best score
		k_ELeaderboardUploadScoreMethodForceUpdate = 2,	// Leaderboard will always replace score with specified
	}

	// Steam API call failure results
	public enum ESteamAPICallFailure : int {
		k_ESteamAPICallFailureNone = -1,			// no failure
		k_ESteamAPICallFailureSteamGone = 0,		// the local Steam process has gone away
		k_ESteamAPICallFailureNetworkFailure = 1,	// the network connection to Steam has been broken, or was already broken
		// SteamServersDisconnected_t callback will be sent around the same time
		// SteamServersConnected_t will be sent when the client is able to talk to the Steam servers again
		k_ESteamAPICallFailureInvalidHandle = 2,	// the SteamAPICall_t handle passed in no longer exists
		k_ESteamAPICallFailureMismatchedCallback = 3,// GetAPICallResult() was called with the wrong callback type for this API call
	}

	// Input modes for the Big Picture gamepad text entry
	public enum EGamepadTextInputMode : int {
		k_EGamepadTextInputModeNormal = 0,
		k_EGamepadTextInputModePassword = 1
	}

	// Controls number of allowed lines for the Big Picture gamepad text entry
	public enum EGamepadTextInputLineMode : int {
		k_EGamepadTextInputLineModeSingleLine = 0,
		k_EGamepadTextInputLineModeMultipleLines = 1
	}

	public enum EFloatingGamepadTextInputMode : int {
		k_EFloatingGamepadTextInputModeModeSingleLine = 0,		// Enter dismisses the keyboard
		k_EFloatingGamepadTextInputModeModeMultipleLines = 1,	// User needs to explictly close the keyboard
		k_EFloatingGamepadTextInputModeModeEmail = 2,			// Keyboard layout is email, enter dismisses the keyboard
		k_EFloatingGamepadTextInputModeModeNumeric = 3,			// Keyboard layout is numeric, enter dismisses the keyboard

	}

	// The context where text filtering is being done
	public enum ETextFilteringContext : int {
		k_ETextFilteringContextUnknown = 0,	// Unknown context
		k_ETextFilteringContextGameContent = 1,	// Game content, only legally required filtering is performed
		k_ETextFilteringContextChat = 2,	// Chat from another player
		k_ETextFilteringContextName = 3,	// Character or item name
	}

	//-----------------------------------------------------------------------------
	// results for CheckFileSignature
	//-----------------------------------------------------------------------------
	public enum ECheckFileSignature : int {
		k_ECheckFileSignatureInvalidSignature = 0,
		k_ECheckFileSignatureValidSignature = 1,
		k_ECheckFileSignatureFileNotFound = 2,
		k_ECheckFileSignatureNoSignaturesFoundForThisApp = 3,
		k_ECheckFileSignatureNoSignaturesFoundForThisFile = 4,
	}

	public enum EMatchMakingServerResponse : int {
		eServerResponded = 0,
		eServerFailedToRespond,
		eNoServersListedOnMasterServer // for the Internet query type, returned in response callback if no servers of this type match
	}

	public enum EServerMode : int {
		eServerModeInvalid = 0, // DO NOT USE
		eServerModeNoAuthentication = 1, // Don't authenticate user logins and don't list on the server list
		eServerModeAuthentication = 2, // Authenticate users, list on the server list, don't run VAC on clients that connect
		eServerModeAuthenticationAndSecure = 3, // Authenticate users, list on the server list and VAC protect clients
	}

	// General result codes
	public enum EResult : int {
		k_EResultNone = 0,							// no result
		k_EResultOK	= 1,							// success
		k_EResultFail = 2,							// generic failure
		k_EResultNoConnection = 3,					// no/failed network connection
	//	k_EResultNoConnectionRetry = 4,				// OBSOLETE - removed
		k_EResultInvalidPassword = 5,				// password/ticket is invalid
		k_EResultLoggedInElsewhere = 6,				// same user logged in elsewhere
		k_EResultInvalidProtocolVer = 7,			// protocol version is incorrect
		k_EResultInvalidParam = 8,					// a parameter is incorrect
		k_EResultFileNotFound = 9,					// file was not found
		k_EResultBusy = 10,							// called method busy - action not taken
		k_EResultInvalidState = 11,					// called object was in an invalid state
		k_EResultInvalidName = 12,					// name is invalid
		k_EResultInvalidEmail = 13,					// email is invalid
		k_EResultDuplicateName = 14,				// name is not unique
		k_EResultAccessDenied = 15,					// access is denied
		k_EResultTimeout = 16,						// operation timed out
		k_EResultBanned = 17,						// VAC2 banned
		k_EResultAccountNotFound = 18,				// account not found
		k_EResultInvalidSteamID = 19,				// steamID is invalid
		k_EResultServiceUnavailable = 20,			// The requested service is currently unavailable
		k_EResultNotLoggedOn = 21,					// The user is not logged on
		k_EResultPending = 22,						// Request is pending (may be in process, or waiting on third party)
		k_EResultEncryptionFailure = 23,			// Encryption or Decryption failed
		k_EResultInsufficientPrivilege = 24,		// Insufficient privilege
		k_EResultLimitExceeded = 25,				// Too much of a good thing
		k_EResultRevoked = 26,						// Access has been revoked (used for revoked guest passes)
		k_EResultExpired = 27,						// License/Guest pass the user is trying to access is expired
		k_EResultAlreadyRedeemed = 28,				// Guest pass has already been redeemed by account, cannot be acked again
		k_EResultDuplicateRequest = 29,				// The request is a duplicate and the action has already occurred in the past, ignored this time
		k_EResultAlreadyOwned = 30,					// All the games in this guest pass redemption request are already owned by the user
		k_EResultIPNotFound = 31,					// IP address not found
		k_EResultPersistFailed = 32,				// failed to write change to the data store
		k_EResultLockingFailed = 33,				// failed to acquire access lock for this operation
		k_EResultLogonSessionReplaced = 34,
		k_EResultConnectFailed = 35,
		k_EResultHandshakeFailed = 36,
		k_EResultIOFailure = 37,
		k_EResultRemoteDisconnect = 38,
		k_EResultShoppingCartNotFound = 39,			// failed to find the shopping cart requested
		k_EResultBlocked = 40,						// a user didn't allow it
		k_EResultIgnored = 41,						// target is ignoring sender
		k_EResultNoMatch = 42,						// nothing matching the request found
		k_EResultAccountDisabled = 43,
		k_EResultServiceReadOnly = 44,				// this service is not accepting content changes right now
		k_EResultAccountNotFeatured = 45,			// account doesn't have value, so this feature isn't available
		k_EResultAdministratorOK = 46,				// allowed to take this action, but only because requester is admin
		k_EResultContentVersion = 47,				// A Version mismatch in content transmitted within the Steam protocol.
		k_EResultTryAnotherCM = 48,					// The current CM can't service the user making a request, user should try another.
		k_EResultPasswordRequiredToKickSession = 49,// You are already logged in elsewhere, this cached credential login has failed.
		k_EResultAlreadyLoggedInElsewhere = 50,		// You are already logged in elsewhere, you must wait
		k_EResultSuspended = 51,					// Long running operation (content download) suspended/paused
		k_EResultCancelled = 52,					// Operation canceled (typically by user: content download)
		k_EResultDataCorruption = 53,				// Operation canceled because data is ill formed or unrecoverable
		k_EResultDiskFull = 54,						// Operation canceled - not enough disk space.
		k_EResultRemoteCallFailed = 55,				// an remote call or IPC call failed
		k_EResultPasswordUnset = 56,				// Password could not be verified as it's unset server side
		k_EResultExternalAccountUnlinked = 57,		// External account (PSN, Facebook...) is not linked to a Steam account
		k_EResultPSNTicketInvalid = 58,				// PSN ticket was invalid
		k_EResultExternalAccountAlreadyLinked = 59,	// External account (PSN, Facebook...) is already linked to some other account, must explicitly request to replace/delete the link first
		k_EResultRemoteFileConflict = 60,			// The sync cannot resume due to a conflict between the local and remote files
		k_EResultIllegalPassword = 61,				// The requested new password is not legal
		k_EResultSameAsPreviousValue = 62,			// new value is the same as the old one ( secret question and answer )
		k_EResultAccountLogonDenied = 63,			// account login denied due to 2nd factor authentication failure
		k_EResultCannotUseOldPassword = 64,			// The requested new password is not legal
		k_EResultInvalidLoginAuthCode = 65,			// account login denied due to auth code invalid
		k_EResultAccountLogonDeniedNoMail = 66,		// account login denied due to 2nd factor auth failure - and no mail has been sent
		k_EResultHardwareNotCapableOfIPT = 67,		//
		k_EResultIPTInitError = 68,					//
		k_EResultParentalControlRestricted = 69,	// operation failed due to parental control restrictions for current user
		k_EResultFacebookQueryError = 70,			// Facebook query returned an error
		k_EResultExpiredLoginAuthCode = 71,			// account login denied due to auth code expired
		k_EResultIPLoginRestrictionFailed = 72,
		k_EResultAccountLockedDown = 73,
		k_EResultAccountLogonDeniedVerifiedEmailRequired = 74,
		k_EResultNoMatchingURL = 75,
		k_EResultBadResponse = 76,					// parse failure, missing field, etc.
		k_EResultRequirePasswordReEntry = 77,		// The user cannot complete the action until they re-enter their password
		k_EResultValueOutOfRange = 78,				// the value entered is outside the acceptable range
		k_EResultUnexpectedError = 79,				// something happened that we didn't expect to ever happen
		k_EResultDisabled = 80,						// The requested service has been configured to be unavailable
		k_EResultInvalidCEGSubmission = 81,			// The set of files submitted to the CEG server are not valid !
		k_EResultRestrictedDevice = 82,				// The device being used is not allowed to perform this action
		k_EResultRegionLocked = 83,					// The action could not be complete because it is region restricted
		k_EResultRateLimitExceeded = 84,			// Temporary rate limit exceeded, try again later, different from k_EResultLimitExceeded which may be permanent
		k_EResultAccountLoginDeniedNeedTwoFactor = 85,	// Need two-factor code to login
		k_EResultItemDeleted = 86,					// The thing we're trying to access has been deleted
		k_EResultAccountLoginDeniedThrottle = 87,	// login attempt failed, try to throttle response to possible attacker
		k_EResultTwoFactorCodeMismatch = 88,		// two factor code mismatch
		k_EResultTwoFactorActivationCodeMismatch = 89,	// activation code for two-factor didn't match
		k_EResultAccountAssociatedToMultiplePartners = 90,	// account has been associated with multiple partners
		k_EResultNotModified = 91,					// data not modified
		k_EResultNoMobileDevice = 92,				// the account does not have a mobile device associated with it
		k_EResultTimeNotSynced = 93,				// the time presented is out of range or tolerance
		k_EResultSmsCodeFailed = 94,				// SMS code failure (no match, none pending, etc.)
		k_EResultAccountLimitExceeded = 95,			// Too many accounts access this resource
		k_EResultAccountActivityLimitExceeded = 96,	// Too many changes to this account
		k_EResultPhoneActivityLimitExceeded = 97,	// Too many changes to this phone
		k_EResultRefundToWallet = 98,				// Cannot refund to payment method, must use wallet
		k_EResultEmailSendFailure = 99,				// Cannot send an email
		k_EResultNotSettled = 100,					// Can't perform operation till payment has settled
		k_EResultNeedCaptcha = 101,					// Needs to provide a valid captcha
		k_EResultGSLTDenied = 102,					// a game server login token owned by this token's owner has been banned
		k_EResultGSOwnerDenied = 103,				// game server owner is denied for other reason (account lock, community ban, vac ban, missing phone)
		k_EResultInvalidItemType = 104,				// the type of thing we were requested to act on is invalid
		k_EResultIPBanned = 105,					// the ip address has been banned from taking this action
		k_EResultGSLTExpired = 106,					// this token has expired from disuse; can be reset for use
		k_EResultInsufficientFunds = 107,			// user doesn't have enough wallet funds to complete the action
		k_EResultTooManyPending = 108,				// There are too many of this thing pending already
		k_EResultNoSiteLicensesFound = 109,			// No site licenses found
		k_EResultWGNetworkSendExceeded = 110,		// the WG couldn't send a response because we exceeded max network send size
		k_EResultAccountNotFriends = 111,			// the user is not mutually friends
		k_EResultLimitedUserAccount = 112,			// the user is limited
		k_EResultCantRemoveItem = 113,				// item can't be removed
		k_EResultAccountDeleted = 114,				// account has been deleted
		k_EResultExistingUserCancelledLicense = 115,	// A license for this already exists, but cancelled
		k_EResultCommunityCooldown = 116,			// access is denied because of a community cooldown (probably from support profile data resets)
		k_EResultNoLauncherSpecified = 117,			// No launcher was specified, but a launcher was needed to choose correct realm for operation.
		k_EResultMustAgreeToSSA = 118,				// User must agree to china SSA or global SSA before login
		k_EResultLauncherMigrated = 119,			// The specified launcher type is no longer supported; the user should be directed elsewhere
		k_EResultSteamRealmMismatch = 120,			// The user's realm does not match the realm of the requested resource
		k_EResultInvalidSignature = 121,			// signature check did not match
		k_EResultParseFailure = 122,				// Failed to parse input
		k_EResultNoVerifiedPhone = 123,				// account does not have a verified phone number
		k_EResultInsufficientBattery = 124,			// user device doesn't have enough battery charge currently to complete the action
		k_EResultChargerRequired = 125,				// The operation requires a charger to be plugged in, which wasn't present
		k_EResultCachedCredentialInvalid = 126,		// Cached credential was invalid - user must reauthenticate
		K_EResultPhoneNumberIsVOIP = 127,			// The phone number provided is a Voice Over IP number
	}

	// Error codes for use with the voice functions
	public enum EVoiceResult : int {
		k_EVoiceResultOK = 0,
		k_EVoiceResultNotInitialized = 1,
		k_EVoiceResultNotRecording = 2,
		k_EVoiceResultNoData = 3,
		k_EVoiceResultBufferTooSmall = 4,
		k_EVoiceResultDataCorrupted = 5,
		k_EVoiceResultRestricted = 6,
		k_EVoiceResultUnsupportedCodec = 7,
		k_EVoiceResultReceiverOutOfDate = 8,
		k_EVoiceResultReceiverDidNotAnswer = 9,

	}

	// Result codes to GSHandleClientDeny/Kick
	public enum EDenyReason : int {
		k_EDenyInvalid = 0,
		k_EDenyInvalidVersion = 1,
		k_EDenyGeneric = 2,
		k_EDenyNotLoggedOn = 3,
		k_EDenyNoLicense = 4,
		k_EDenyCheater = 5,
		k_EDenyLoggedInElseWhere = 6,
		k_EDenyUnknownText = 7,
		k_EDenyIncompatibleAnticheat = 8,
		k_EDenyMemoryCorruption = 9,
		k_EDenyIncompatibleSoftware = 10,
		k_EDenySteamConnectionLost = 11,
		k_EDenySteamConnectionError = 12,
		k_EDenySteamResponseTimedOut = 13,
		k_EDenySteamValidationStalled = 14,
		k_EDenySteamOwnerLeftGuestUser = 15,
	}

	// results from BeginAuthSession
	public enum EBeginAuthSessionResult : int {
		k_EBeginAuthSessionResultOK = 0,						// Ticket is valid for this game and this steamID.
		k_EBeginAuthSessionResultInvalidTicket = 1,				// Ticket is not valid.
		k_EBeginAuthSessionResultDuplicateRequest = 2,			// A ticket has already been submitted for this steamID
		k_EBeginAuthSessionResultInvalidVersion = 3,			// Ticket is from an incompatible interface version
		k_EBeginAuthSessionResultGameMismatch = 4,				// Ticket is not for this game
		k_EBeginAuthSessionResultExpiredTicket = 5,				// Ticket has expired
	}

	// Callback values for callback ValidateAuthTicketResponse_t which is a response to BeginAuthSession
	public enum EAuthSessionResponse : int {
		k_EAuthSessionResponseOK = 0,							// Steam has verified the user is online, the ticket is valid and ticket has not been reused.
		k_EAuthSessionResponseUserNotConnectedToSteam = 1,		// The user in question is not connected to steam
		k_EAuthSessionResponseNoLicenseOrExpired = 2,			// The license has expired.
		k_EAuthSessionResponseVACBanned = 3,					// The user is VAC banned for this game.
		k_EAuthSessionResponseLoggedInElseWhere = 4,			// The user account has logged in elsewhere and the session containing the game instance has been disconnected.
		k_EAuthSessionResponseVACCheckTimedOut = 5,				// VAC has been unable to perform anti-cheat checks on this user
		k_EAuthSessionResponseAuthTicketCanceled = 6,			// The ticket has been canceled by the issuer
		k_EAuthSessionResponseAuthTicketInvalidAlreadyUsed = 7,	// This ticket has already been used, it is not valid.
		k_EAuthSessionResponseAuthTicketInvalid = 8,			// This ticket is not from a user instance currently connected to steam.
		k_EAuthSessionResponsePublisherIssuedBan = 9,			// The user is banned for this game. The ban came via the web api and not VAC
	}

	// results from UserHasLicenseForApp
	public enum EUserHasLicenseForAppResult : int {
		k_EUserHasLicenseResultHasLicense = 0,					// User has a license for specified app
		k_EUserHasLicenseResultDoesNotHaveLicense = 1,			// User does not have a license for the specified app
		k_EUserHasLicenseResultNoAuth = 2,						// User has not been authenticated
	}

	// Steam account types
	public enum EAccountType : int {
		k_EAccountTypeInvalid = 0,
		k_EAccountTypeIndividual = 1,		// single user account
		k_EAccountTypeMultiseat = 2,		// multiseat (e.g. cybercafe) account
		k_EAccountTypeGameServer = 3,		// game server account
		k_EAccountTypeAnonGameServer = 4,	// anonymous game server account
		k_EAccountTypePending = 5,			// pending
		k_EAccountTypeContentServer = 6,	// content server
		k_EAccountTypeClan = 7,
		k_EAccountTypeChat = 8,
		k_EAccountTypeConsoleUser = 9,		// Fake SteamID for local PSN account on PS3 or Live account on 360, etc.
		k_EAccountTypeAnonUser = 10,

		// Max of 16 items in this field
		k_EAccountTypeMax
	}

	//-----------------------------------------------------------------------------
	// Purpose: Chat Entry Types (previously was only friend-to-friend message types)
	//-----------------------------------------------------------------------------
	public enum EChatEntryType : int {
		k_EChatEntryTypeInvalid = 0,
		k_EChatEntryTypeChatMsg = 1,		// Normal text message from another user
		k_EChatEntryTypeTyping = 2,			// Another user is typing (not used in multi-user chat)
		k_EChatEntryTypeInviteGame = 3,		// Invite from other user into that users current game
		k_EChatEntryTypeEmote = 4,			// text emote message (deprecated, should be treated as ChatMsg)
		//k_EChatEntryTypeLobbyGameStart = 5,	// lobby game is starting (dead - listen for LobbyGameCreated_t callback instead)
		k_EChatEntryTypeLeftConversation = 6, // user has left the conversation ( closed chat window )
		// Above are previous FriendMsgType entries, now merged into more generic chat entry types
		k_EChatEntryTypeEntered = 7,		// user has entered the conversation (used in multi-user chat and group chat)
		k_EChatEntryTypeWasKicked = 8,		// user was kicked (data: 64-bit steamid of actor performing the kick)
		k_EChatEntryTypeWasBanned = 9,		// user was banned (data: 64-bit steamid of actor performing the ban)
		k_EChatEntryTypeDisconnected = 10,	// user disconnected
		k_EChatEntryTypeHistoricalChat = 11,	// a chat message from user's chat history or offilne message
		//k_EChatEntryTypeReserved1 = 12, // No longer used
		//k_EChatEntryTypeReserved2 = 13, // No longer used
		k_EChatEntryTypeLinkBlocked = 14, // a link was removed by the chat filter.
	}

	//-----------------------------------------------------------------------------
	// Purpose: Chat Room Enter Responses
	//-----------------------------------------------------------------------------
	public enum EChatRoomEnterResponse : int {
		k_EChatRoomEnterResponseSuccess = 1,		// Success
		k_EChatRoomEnterResponseDoesntExist = 2,	// Chat doesn't exist (probably closed)
		k_EChatRoomEnterResponseNotAllowed = 3,		// General Denied - You don't have the permissions needed to join the chat
		k_EChatRoomEnterResponseFull = 4,			// Chat room has reached its maximum size
		k_EChatRoomEnterResponseError = 5,			// Unexpected Error
		k_EChatRoomEnterResponseBanned = 6,			// You are banned from this chat room and may not join
		k_EChatRoomEnterResponseLimited = 7,		// Joining this chat is not allowed because you are a limited user (no value on account)
		k_EChatRoomEnterResponseClanDisabled = 8,	// Attempt to join a clan chat when the clan is locked or disabled
		k_EChatRoomEnterResponseCommunityBan = 9,	// Attempt to join a chat when the user has a community lock on their account
		k_EChatRoomEnterResponseMemberBlockedYou = 10, // Join failed - some member in the chat has blocked you from joining
		k_EChatRoomEnterResponseYouBlockedMember = 11, // Join failed - you have blocked some member already in the chat
		// k_EChatRoomEnterResponseNoRankingDataLobby = 12,  // No longer used
		// k_EChatRoomEnterResponseNoRankingDataUser = 13,  //  No longer used
		// k_EChatRoomEnterResponseRankOutOfRange = 14, //  No longer used
		k_EChatRoomEnterResponseRatelimitExceeded = 15, // Join failed - to many join attempts in a very short period of time
	}

	// Special flags for Chat accounts - they go in the top 8 bits
	// of the steam ID's "instance", leaving 12 for the actual instances
	[Flags]
	public enum EChatSteamIDInstanceFlags : int {
		k_EChatAccountInstanceMask = 0x00000FFF, // top 8 bits are flags

		k_EChatInstanceFlagClan = ( Constants.k_unSteamAccountInstanceMask + 1 ) >> 1,	// top bit
		k_EChatInstanceFlagLobby = ( Constants.k_unSteamAccountInstanceMask + 1 ) >> 2,	// next one down, etc
		k_EChatInstanceFlagMMSLobby = ( Constants.k_unSteamAccountInstanceMask + 1 ) >> 3,	// next one down, etc

		// Max of 8 flags
	}

	//-----------------------------------------------------------------------------
	// Purpose: Possible positions to tell the overlay to show notifications in
	//-----------------------------------------------------------------------------
	public enum ENotificationPosition : int {
		k_EPositionTopLeft = 0,
		k_EPositionTopRight = 1,
		k_EPositionBottomLeft = 2,
		k_EPositionBottomRight = 3,
	}

	//-----------------------------------------------------------------------------
	// Purpose: Broadcast upload result details
	//-----------------------------------------------------------------------------
	public enum EBroadcastUploadResult : int {
		k_EBroadcastUploadResultNone = 0,	// broadcast state unknown
		k_EBroadcastUploadResultOK = 1,		// broadcast was good, no problems
		k_EBroadcastUploadResultInitFailed = 2,	// broadcast init failed
		k_EBroadcastUploadResultFrameFailed = 3,	// broadcast frame upload failed
		k_EBroadcastUploadResultTimeout = 4,	// broadcast upload timed out
		k_EBroadcastUploadResultBandwidthExceeded = 5,	// broadcast send too much data
		k_EBroadcastUploadResultLowFPS = 6,	// broadcast FPS too low
		k_EBroadcastUploadResultMissingKeyFrames = 7,	// broadcast sending not enough key frames
		k_EBroadcastUploadResultNoConnection = 8,	// broadcast client failed to connect to relay
		k_EBroadcastUploadResultRelayFailed = 9,	// relay dropped the upload
		k_EBroadcastUploadResultSettingsChanged = 10,	// the client changed broadcast settings
		k_EBroadcastUploadResultMissingAudio = 11,	// client failed to send audio data
		k_EBroadcastUploadResultTooFarBehind = 12,	// clients was too slow uploading
		k_EBroadcastUploadResultTranscodeBehind = 13,	// server failed to keep up with transcode
		k_EBroadcastUploadResultNotAllowedToPlay = 14, // Broadcast does not have permissions to play game
		k_EBroadcastUploadResultBusy = 15, // RTMP host to busy to take new broadcast stream, choose another
		k_EBroadcastUploadResultBanned = 16, // Account banned from community broadcast
		k_EBroadcastUploadResultAlreadyActive = 17, // We already already have an stream running.
		k_EBroadcastUploadResultForcedOff = 18, // We explicitly shutting down a broadcast
		k_EBroadcastUploadResultAudioBehind = 19, // Audio stream was too far behind video
		k_EBroadcastUploadResultShutdown = 20,	// Broadcast Server was shut down
		k_EBroadcastUploadResultDisconnect = 21,	// broadcast uploader TCP disconnected
		k_EBroadcastUploadResultVideoInitFailed = 22,	// invalid video settings
		k_EBroadcastUploadResultAudioInitFailed = 23,	// invalid audio settings
	}

	//-----------------------------------------------------------------------------
	// Purpose: Reasons a user may not use the Community Market.
	//          Used in MarketEligibilityResponse_t.
	//-----------------------------------------------------------------------------
	[Flags]
	public enum EMarketNotAllowedReasonFlags : int {
		k_EMarketNotAllowedReason_None = 0,

		// A back-end call failed or something that might work again on retry
		k_EMarketNotAllowedReason_TemporaryFailure = (1 << 0),

		// Disabled account
		k_EMarketNotAllowedReason_AccountDisabled = (1 << 1),

		// Locked account
		k_EMarketNotAllowedReason_AccountLockedDown = (1 << 2),

		// Limited account (no purchases)
		k_EMarketNotAllowedReason_AccountLimited = (1 << 3),

		// The account is banned from trading items
		k_EMarketNotAllowedReason_TradeBanned = (1 << 4),

		// Wallet funds aren't tradable because the user has had no purchase
		// activity in the last year or has had no purchases prior to last month
		k_EMarketNotAllowedReason_AccountNotTrusted = (1 << 5),

		// The user doesn't have Steam Guard enabled
		k_EMarketNotAllowedReason_SteamGuardNotEnabled = (1 << 6),

		// The user has Steam Guard, but it hasn't been enabled for the required
		// number of days
		k_EMarketNotAllowedReason_SteamGuardOnlyRecentlyEnabled = (1 << 7),

		// The user has recently forgotten their password and reset it
		k_EMarketNotAllowedReason_RecentPasswordReset = (1 << 8),

		// The user has recently funded his or her wallet with a new payment method
		k_EMarketNotAllowedReason_NewPaymentMethod = (1 << 9),

		// An invalid cookie was sent by the user
		k_EMarketNotAllowedReason_InvalidCookie = (1 << 10),

		// The user has Steam Guard, but is using a new computer or web browser
		k_EMarketNotAllowedReason_UsingNewDevice = (1 << 11),

		// The user has recently refunded a store purchase by his or herself
		k_EMarketNotAllowedReason_RecentSelfRefund = (1 << 12),

		// The user has recently funded his or her wallet with a new payment method that cannot be verified
		k_EMarketNotAllowedReason_NewPaymentMethodCannotBeVerified = (1 << 13),

		// Not only is the account not trusted, but they have no recent purchases at all
		k_EMarketNotAllowedReason_NoRecentPurchases = (1 << 14),

		// User accepted a wallet gift that was recently purchased
		k_EMarketNotAllowedReason_AcceptedWalletGift = (1 << 15),
	}

	//
	// describes XP / progress restrictions to apply for games with duration control /
	// anti-indulgence enabled for minor Steam China users.
	//
	// WARNING: DO NOT RENUMBER
	public enum EDurationControlProgress : int {
		k_EDurationControlProgress_Full = 0,	// Full progress
		k_EDurationControlProgress_Half = 1,	// deprecated - XP or persistent rewards should be halved
		k_EDurationControlProgress_None = 2,	// deprecated - XP or persistent rewards should be stopped

		k_EDurationControl_ExitSoon_3h = 3,		// allowed 3h time since 5h gap/break has elapsed, game should exit - steam will terminate the game soon
		k_EDurationControl_ExitSoon_5h = 4,		// allowed 5h time in calendar day has elapsed, game should exit - steam will terminate the game soon
		k_EDurationControl_ExitSoon_Night = 5,	// game running after day period, game should exit - steam will terminate the game soon
	}

	//
	// describes which notification timer has expired, for steam china duration control feature
	//
	// WARNING: DO NOT RENUMBER
	public enum EDurationControlNotification : int {
		k_EDurationControlNotification_None = 0,		// just informing you about progress, no notification to show
		k_EDurationControlNotification_1Hour = 1,		// "you've been playing for N hours"

		k_EDurationControlNotification_3Hours = 2,		// deprecated - "you've been playing for 3 hours; take a break"
		k_EDurationControlNotification_HalfProgress = 3,// deprecated - "your XP / progress is half normal"
		k_EDurationControlNotification_NoProgress = 4,	// deprecated - "your XP / progress is zero"

		k_EDurationControlNotification_ExitSoon_3h = 5,	// allowed 3h time since 5h gap/break has elapsed, game should exit - steam will terminate the game soon
		k_EDurationControlNotification_ExitSoon_5h = 6,	// allowed 5h time in calendar day has elapsed, game should exit - steam will terminate the game soon
		k_EDurationControlNotification_ExitSoon_Night = 7,// game running after day period, game should exit - steam will terminate the game soon
	}

	//
	// Specifies a game's online state in relation to duration control
	//
	public enum EDurationControlOnlineState : int {
		k_EDurationControlOnlineState_Invalid = 0,				// nil value
		k_EDurationControlOnlineState_Offline = 1,				// currently in offline play - single-player, offline co-op, etc.
		k_EDurationControlOnlineState_Online = 2,				// currently in online play
		k_EDurationControlOnlineState_OnlineHighPri = 3,		// currently in online play and requests not to be interrupted
	}

	public enum EGameSearchErrorCode_t : int {
		k_EGameSearchErrorCode_OK = 1,
		k_EGameSearchErrorCode_Failed_Search_Already_In_Progress = 2,
		k_EGameSearchErrorCode_Failed_No_Search_In_Progress = 3,
		k_EGameSearchErrorCode_Failed_Not_Lobby_Leader = 4, // if not the lobby leader can not call SearchForGameWithLobby
		k_EGameSearchErrorCode_Failed_No_Host_Available = 5, // no host is available that matches those search params
		k_EGameSearchErrorCode_Failed_Search_Params_Invalid = 6, // search params are invalid
		k_EGameSearchErrorCode_Failed_Offline = 7, // offline, could not communicate with server
		k_EGameSearchErrorCode_Failed_NotAuthorized = 8, // either the user or the application does not have priveledges to do this
		k_EGameSearchErrorCode_Failed_Unknown_Error = 9, // unknown error
	}

	public enum EPlayerResult_t : int {
		k_EPlayerResultFailedToConnect = 1, // failed to connect after confirming
		k_EPlayerResultAbandoned = 2,		// quit game without completing it
		k_EPlayerResultKicked = 3,			// kicked by other players/moderator/server rules
		k_EPlayerResultIncomplete = 4,		// player stayed to end but game did not conclude successfully ( nofault to player )
		k_EPlayerResultCompleted = 5,		// player completed game
	}

	public enum ESteamIPv6ConnectivityProtocol : int {
		k_ESteamIPv6ConnectivityProtocol_Invalid = 0,
		k_ESteamIPv6ConnectivityProtocol_HTTP = 1,		// because a proxy may make this different than other protocols
		k_ESteamIPv6ConnectivityProtocol_UDP = 2,		// test UDP connectivity. Uses a port that is commonly needed for other Steam stuff. If UDP works, TCP probably works.
	}

	// For the above transport protocol, what do we think the local machine's connectivity to the internet over ipv6 is like
	public enum ESteamIPv6ConnectivityState : int {
		k_ESteamIPv6ConnectivityState_Unknown = 0,	// We haven't run a test yet
		k_ESteamIPv6ConnectivityState_Good = 1,		// We have recently been able to make a request on ipv6 for the given protocol
		k_ESteamIPv6ConnectivityState_Bad = 2,		// We failed to make a request, either because this machine has no ipv6 address assigned, or it has no upstream connectivity
	}

	// HTTP related types
	// This enum is used in client API methods, do not re-number existing values.
	public enum EHTTPMethod : int {
		k_EHTTPMethodInvalid = 0,
		k_EHTTPMethodGET,
		k_EHTTPMethodHEAD,
		k_EHTTPMethodPOST,
		k_EHTTPMethodPUT,
		k_EHTTPMethodDELETE,
		k_EHTTPMethodOPTIONS,
		k_EHTTPMethodPATCH,

		// The remaining HTTP methods are not yet supported, per rfc2616 section 5.1.1 only GET and HEAD are required for
		// a compliant general purpose server.  We'll likely add more as we find uses for them.

		// k_EHTTPMethodTRACE,
		// k_EHTTPMethodCONNECT
	}

	// HTTP Status codes that the server can send in response to a request, see rfc2616 section 10.3 for descriptions
	// of each of these.
	public enum EHTTPStatusCode : int {
		// Invalid status code (this isn't defined in HTTP, used to indicate unset in our code)
		k_EHTTPStatusCodeInvalid =					0,

		// Informational codes
		k_EHTTPStatusCode100Continue =				100,
		k_EHTTPStatusCode101SwitchingProtocols =	101,

		// Success codes
		k_EHTTPStatusCode200OK =					200,
		k_EHTTPStatusCode201Created =				201,
		k_EHTTPStatusCode202Accepted =				202,
		k_EHTTPStatusCode203NonAuthoritative =		203,
		k_EHTTPStatusCode204NoContent =				204,
		k_EHTTPStatusCode205ResetContent =			205,
		k_EHTTPStatusCode206PartialContent =		206,

		// Redirection codes
		k_EHTTPStatusCode300MultipleChoices =		300,
		k_EHTTPStatusCode301MovedPermanently =		301,
		k_EHTTPStatusCode302Found =					302,
		k_EHTTPStatusCode303SeeOther =				303,
		k_EHTTPStatusCode304NotModified =			304,
		k_EHTTPStatusCode305UseProxy =				305,
		//k_EHTTPStatusCode306Unused =				306, (used in old HTTP spec, now unused in 1.1)
		k_EHTTPStatusCode307TemporaryRedirect =		307,

		// Error codes
		k_EHTTPStatusCode400BadRequest =			400,
		k_EHTTPStatusCode401Unauthorized =			401, // You probably want 403 or something else. 401 implies you're sending a WWW-Authenticate header and the client can sent an Authorization header in response.
		k_EHTTPStatusCode402PaymentRequired =		402, // This is reserved for future HTTP specs, not really supported by clients
		k_EHTTPStatusCode403Forbidden =				403,
		k_EHTTPStatusCode404NotFound =				404,
		k_EHTTPStatusCode405MethodNotAllowed =		405,
		k_EHTTPStatusCode406NotAcceptable =			406,
		k_EHTTPStatusCode407ProxyAuthRequired =		407,
		k_EHTTPStatusCode408RequestTimeout =		408,
		k_EHTTPStatusCode409Conflict =				409,
		k_EHTTPStatusCode410Gone =					410,
		k_EHTTPStatusCode411LengthRequired =		411,
		k_EHTTPStatusCode412PreconditionFailed =	412,
		k_EHTTPStatusCode413RequestEntityTooLarge =	413,
		k_EHTTPStatusCode414RequestURITooLong =		414,
		k_EHTTPStatusCode415UnsupportedMediaType =	415,
		k_EHTTPStatusCode416RequestedRangeNotSatisfiable = 416,
		k_EHTTPStatusCode417ExpectationFailed =		417,
		k_EHTTPStatusCode4xxUnknown = 				418, // 418 is reserved, so we'll use it to mean unknown
		k_EHTTPStatusCode429TooManyRequests	=		429,
		k_EHTTPStatusCode444ConnectionClosed =		444, // nginx only?

		// Server error codes
		k_EHTTPStatusCode500InternalServerError =	500,
		k_EHTTPStatusCode501NotImplemented =		501,
		k_EHTTPStatusCode502BadGateway =			502,
		k_EHTTPStatusCode503ServiceUnavailable =	503,
		k_EHTTPStatusCode504GatewayTimeout =		504,
		k_EHTTPStatusCode505HTTPVersionNotSupported = 505,
		k_EHTTPStatusCode5xxUnknown =				599,
	}

	/// Describe the status of a particular network resource
	public enum ESteamNetworkingAvailability : int {
		// Negative values indicate a problem.
		//
		// In general, we will not automatically retry unless you take some action that
		// depends on of requests this resource, such as querying the status, attempting
		// to initiate a connection, receive a connection, etc.  If you do not take any
		// action at all, we do not automatically retry in the background.
		k_ESteamNetworkingAvailability_CannotTry = -102,		// A dependent resource is missing, so this service is unavailable.  (E.g. we cannot talk to routers because Internet is down or we don't have the network config.)
		k_ESteamNetworkingAvailability_Failed = -101,			// We have tried for enough time that we would expect to have been successful by now.  We have never been successful
		k_ESteamNetworkingAvailability_Previously = -100,		// We tried and were successful at one time, but now it looks like we have a problem

		k_ESteamNetworkingAvailability_Retrying = -10,		// We previously failed and are currently retrying

		// Not a problem, but not ready either
		k_ESteamNetworkingAvailability_NeverTried = 1,		// We don't know because we haven't ever checked/tried
		k_ESteamNetworkingAvailability_Waiting = 2,			// We're waiting on a dependent resource to be acquired.  (E.g. we cannot obtain a cert until we are logged into Steam.  We cannot measure latency to relays until we have the network config.)
		k_ESteamNetworkingAvailability_Attempting = 3,		// We're actively trying now, but are not yet successful.

		k_ESteamNetworkingAvailability_Current = 100,			// Resource is online/available


		k_ESteamNetworkingAvailability_Unknown = 0,			// Internal dummy/sentinel, or value is not applicable in this context
		k_ESteamNetworkingAvailability__Force32bit = 0x7fffffff,
	}

	//
	// Describing network hosts
	//
	/// Different methods of describing the identity of a network host
	public enum ESteamNetworkingIdentityType : int {
		// Dummy/empty/invalid.
		// Please note that if we parse a string that we don't recognize
		// but that appears reasonable, we will NOT use this type.  Instead
		// we'll use k_ESteamNetworkingIdentityType_UnknownType.
		k_ESteamNetworkingIdentityType_Invalid = 0,

		//
		// Basic platform-specific identifiers.
		//
		k_ESteamNetworkingIdentityType_SteamID = 16, // 64-bit CSteamID
		k_ESteamNetworkingIdentityType_XboxPairwiseID = 17, // Publisher-specific user identity, as string
		k_ESteamNetworkingIdentityType_SonyPSN = 18, // 64-bit ID
		k_ESteamNetworkingIdentityType_GoogleStadia = 19, // 64-bit ID
		//k_ESteamNetworkingIdentityType_NintendoNetworkServiceAccount,
		//k_ESteamNetworkingIdentityType_EpicGameStore
		//k_ESteamNetworkingIdentityType_WeGame

		//
		// Special identifiers.
		//

		// Use their IP address (and port) as their "identity".
		// These types of identities are always unauthenticated.
		// They are useful for porting plain sockets code, and other
		// situations where you don't care about authentication.  In this
		// case, the local identity will be "localhost",
		// and the remote address will be their network address.
		//
		// We use the same type for either IPv4 or IPv6, and
		// the address is always store as IPv6.  We use IPv4
		// mapped addresses to handle IPv4.
		k_ESteamNetworkingIdentityType_IPAddress = 1,

		// Generic string/binary blobs.  It's up to your app to interpret this.
		// This library can tell you if the remote host presented a certificate
		// signed by somebody you have chosen to trust, with this identity on it.
		// It's up to you to ultimately decide what this identity means.
		k_ESteamNetworkingIdentityType_GenericString = 2,
		k_ESteamNetworkingIdentityType_GenericBytes = 3,

		// This identity type is used when we parse a string that looks like is a
		// valid identity, just of a kind that we don't recognize.  In this case, we
		// can often still communicate with the peer!  Allowing such identities
		// for types we do not recognize useful is very useful for forward
		// compatibility.
		k_ESteamNetworkingIdentityType_UnknownType = 4,

		// Make sure this enum is stored in an int.
		k_ESteamNetworkingIdentityType__Force32bit = 0x7fffffff,
	}

	/// "Fake IPs" are assigned to hosts, to make it easier to interface with
	/// older code that assumed all hosts will have an IPv4 address
	public enum ESteamNetworkingFakeIPType : int {
		k_ESteamNetworkingFakeIPType_Invalid, // Error, argument was not even an IP address, etc.
		k_ESteamNetworkingFakeIPType_NotFake, // Argument was a valid IP, but was not from the reserved "fake" range
		k_ESteamNetworkingFakeIPType_GlobalIPv4, // Globally unique (for a given app) IPv4 address.  Address space managed by Steam
		k_ESteamNetworkingFakeIPType_LocalIPv4, // Locally unique IPv4 address.  Address space managed by the local process.  For internal use only; should not be shared!

		k_ESteamNetworkingFakeIPType__Force32Bit = 0x7fffffff
	}

	//
	// Connection status
	//
	/// High level connection status
	public enum ESteamNetworkingConnectionState : int {

		/// Dummy value used to indicate an error condition in the API.
		/// Specified connection doesn't exist or has already been closed.
		k_ESteamNetworkingConnectionState_None = 0,

		/// We are trying to establish whether peers can talk to each other,
		/// whether they WANT to talk to each other, perform basic auth,
		/// and exchange crypt keys.
		///
		/// - For connections on the "client" side (initiated locally):
		///   We're in the process of trying to establish a connection.
		///   Depending on the connection type, we might not know who they are.
		///   Note that it is not possible to tell if we are waiting on the
		///   network to complete handshake packets, or for the application layer
		///   to accept the connection.
		///
		/// - For connections on the "server" side (accepted through listen socket):
		///   We have completed some basic handshake and the client has presented
		///   some proof of identity.  The connection is ready to be accepted
		///   using AcceptConnection().
		///
		/// In either case, any unreliable packets sent now are almost certain
		/// to be dropped.  Attempts to receive packets are guaranteed to fail.
		/// You may send messages if the send mode allows for them to be queued.
		/// but if you close the connection before the connection is actually
		/// established, any queued messages will be discarded immediately.
		/// (We will not attempt to flush the queue and confirm delivery to the
		/// remote host, which ordinarily happens when a connection is closed.)
		k_ESteamNetworkingConnectionState_Connecting = 1,

		/// Some connection types use a back channel or trusted 3rd party
		/// for earliest communication.  If the server accepts the connection,
		/// then these connections switch into the rendezvous state.  During this
		/// state, we still have not yet established an end-to-end route (through
		/// the relay network), and so if you send any messages unreliable, they
		/// are going to be discarded.
		k_ESteamNetworkingConnectionState_FindingRoute = 2,

		/// We've received communications from our peer (and we know
		/// who they are) and are all good.  If you close the connection now,
		/// we will make our best effort to flush out any reliable sent data that
		/// has not been acknowledged by the peer.  (But note that this happens
		/// from within the application process, so unlike a TCP connection, you are
		/// not totally handing it off to the operating system to deal with it.)
		k_ESteamNetworkingConnectionState_Connected = 3,

		/// Connection has been closed by our peer, but not closed locally.
		/// The connection still exists from an API perspective.  You must close the
		/// handle to free up resources.  If there are any messages in the inbound queue,
		/// you may retrieve them.  Otherwise, nothing may be done with the connection
		/// except to close it.
		///
		/// This stats is similar to CLOSE_WAIT in the TCP state machine.
		k_ESteamNetworkingConnectionState_ClosedByPeer = 4,

		/// A disruption in the connection has been detected locally.  (E.g. timeout,
		/// local internet connection disrupted, etc.)
		///
		/// The connection still exists from an API perspective.  You must close the
		/// handle to free up resources.
		///
		/// Attempts to send further messages will fail.  Any remaining received messages
		/// in the queue are available.
		k_ESteamNetworkingConnectionState_ProblemDetectedLocally = 5,

	//
	// The following values are used internally and will not be returned by any API.
	// We document them here to provide a little insight into the state machine that is used
	// under the hood.
	//

		/// We've disconnected on our side, and from an API perspective the connection is closed.
		/// No more data may be sent or received.  All reliable data has been flushed, or else
		/// we've given up and discarded it.  We do not yet know for sure that the peer knows
		/// the connection has been closed, however, so we're just hanging around so that if we do
		/// get a packet from them, we can send them the appropriate packets so that they can
		/// know why the connection was closed (and not have to rely on a timeout, which makes
		/// it appear as if something is wrong).
		k_ESteamNetworkingConnectionState_FinWait = -1,

		/// We've disconnected on our side, and from an API perspective the connection is closed.
		/// No more data may be sent or received.  From a network perspective, however, on the wire,
		/// we have not yet given any indication to the peer that the connection is closed.
		/// We are in the process of flushing out the last bit of reliable data.  Once that is done,
		/// we will inform the peer that the connection has been closed, and transition to the
		/// FinWait state.
		///
		/// Note that no indication is given to the remote host that we have closed the connection,
		/// until the data has been flushed.  If the remote host attempts to send us data, we will
		/// do whatever is necessary to keep the connection alive until it can be closed properly.
		/// But in fact the data will be discarded, since there is no way for the application to
		/// read it back.  Typically this is not a problem, as application protocols that utilize
		/// the lingering functionality are designed for the remote host to wait for the response
		/// before sending any more data.
		k_ESteamNetworkingConnectionState_Linger = -2,

		/// Connection is completely inactive and ready to be destroyed
		k_ESteamNetworkingConnectionState_Dead = -3,

		k_ESteamNetworkingConnectionState__Force32Bit = 0x7fffffff
	}

	/// Enumerate various causes of connection termination.  These are designed to work similar
	/// to HTTP error codes: the numeric range gives you a rough classification as to the source
	/// of the problem.
	public enum ESteamNetConnectionEnd : int {
		// Invalid/sentinel value
		k_ESteamNetConnectionEnd_Invalid = 0,

		//
		// Application codes.  These are the values you will pass to
		// ISteamNetworkingSockets::CloseConnection.  You can use these codes if
		// you want to plumb through application-specific reason codes.  If you don't
		// need this facility, feel free to always pass
		// k_ESteamNetConnectionEnd_App_Generic.
		//
		// The distinction between "normal" and "exceptional" termination is
		// one you may use if you find useful, but it's not necessary for you
		// to do so.  The only place where we distinguish between normal and
		// exceptional is in connection analytics.  If a significant
		// proportion of connections terminates in an exceptional manner,
		// this can trigger an alert.
		//

		// 1xxx: Application ended the connection in a "usual" manner.
		//       E.g.: user intentionally disconnected from the server,
		//             gameplay ended normally, etc
		k_ESteamNetConnectionEnd_App_Min = 1000,
		k_ESteamNetConnectionEnd_App_Generic = k_ESteamNetConnectionEnd_App_Min,
			// Use codes in this range for "normal" disconnection
		k_ESteamNetConnectionEnd_App_Max = 1999,

		// 2xxx: Application ended the connection in some sort of exceptional
		//       or unusual manner that might indicate a bug or configuration
		//       issue.
		//
		k_ESteamNetConnectionEnd_AppException_Min = 2000,
		k_ESteamNetConnectionEnd_AppException_Generic = k_ESteamNetConnectionEnd_AppException_Min,
			// Use codes in this range for "unusual" disconnection
		k_ESteamNetConnectionEnd_AppException_Max = 2999,

		//
		// System codes.  These will be returned by the system when
		// the connection state is k_ESteamNetworkingConnectionState_ClosedByPeer
		// or k_ESteamNetworkingConnectionState_ProblemDetectedLocally.  It is
		// illegal to pass a code in this range to ISteamNetworkingSockets::CloseConnection
		//

		// 3xxx: Connection failed or ended because of problem with the
		//       local host or their connection to the Internet.
		k_ESteamNetConnectionEnd_Local_Min = 3000,

			// You cannot do what you want to do because you're running in offline mode.
		k_ESteamNetConnectionEnd_Local_OfflineMode = 3001,

			// We're having trouble contacting many (perhaps all) relays.
			// Since it's unlikely that they all went offline at once, the best
			// explanation is that we have a problem on our end.  Note that we don't
			// bother distinguishing between "many" and "all", because in practice,
			// it takes time to detect a connection problem, and by the time
			// the connection has timed out, we might not have been able to
			// actively probe all of the relay clusters, even if we were able to
			// contact them at one time.  So this code just means that:
			//
			// * We don't have any recent successful communication with any relay.
			// * We have evidence of recent failures to communicate with multiple relays.
		k_ESteamNetConnectionEnd_Local_ManyRelayConnectivity = 3002,

			// A hosted server is having trouble talking to the relay
			// that the client was using, so the problem is most likely
			// on our end
		k_ESteamNetConnectionEnd_Local_HostedServerPrimaryRelay = 3003,

			// We're not able to get the SDR network config.  This is
			// *almost* always a local issue, since the network config
			// comes from the CDN, which is pretty darn reliable.
		k_ESteamNetConnectionEnd_Local_NetworkConfig = 3004,

			// Steam rejected our request because we don't have rights
			// to do this.
		k_ESteamNetConnectionEnd_Local_Rights = 3005,

			// ICE P2P rendezvous failed because we were not able to
			// determine our "public" address (e.g. reflexive address via STUN)
			//
			// If relay fallback is available (it always is on Steam), then
			// this is only used internally and will not be returned as a high
			// level failure.
		k_ESteamNetConnectionEnd_Local_P2P_ICE_NoPublicAddresses = 3006,

		k_ESteamNetConnectionEnd_Local_Max = 3999,

		// 4xxx: Connection failed or ended, and it appears that the
		//       cause does NOT have to do with the local host or their
		//       connection to the Internet.  It could be caused by the
		//       remote host, or it could be somewhere in between.
		k_ESteamNetConnectionEnd_Remote_Min = 4000,

			// The connection was lost, and as far as we can tell our connection
			// to relevant services (relays) has not been disrupted.  This doesn't
			// mean that the problem is "their fault", it just means that it doesn't
			// appear that we are having network issues on our end.
		k_ESteamNetConnectionEnd_Remote_Timeout = 4001,

			// Something was invalid with the cert or crypt handshake
			// info you gave me, I don't understand or like your key types,
			// etc.
		k_ESteamNetConnectionEnd_Remote_BadCrypt = 4002,

			// You presented me with a cert that was I was able to parse
			// and *technically* we could use encrypted communication.
			// But there was a problem that prevents me from checking your identity
			// or ensuring that somebody int he middle can't observe our communication.
			// E.g.: - the CA key was missing (and I don't accept unsigned certs)
			// - The CA key isn't one that I trust,
			// - The cert doesn't was appropriately restricted by app, user, time, data center, etc.
			// - The cert wasn't issued to you.
			// - etc
		k_ESteamNetConnectionEnd_Remote_BadCert = 4003,

			// These will never be returned
			//k_ESteamNetConnectionEnd_Remote_NotLoggedIn_DEPRECATED = 4004,
			//k_ESteamNetConnectionEnd_Remote_NotRunningApp_DEPRECATED = 4005,

			// Something wrong with the protocol version you are using.
			// (Probably the code you are running is too old.)
		k_ESteamNetConnectionEnd_Remote_BadProtocolVersion = 4006,

			// NAT punch failed failed because we never received any public
			// addresses from the remote host.  (But we did receive some
			// signals form them.)
			//
			// If relay fallback is available (it always is on Steam), then
			// this is only used internally and will not be returned as a high
			// level failure.
		k_ESteamNetConnectionEnd_Remote_P2P_ICE_NoPublicAddresses = 4007,

		k_ESteamNetConnectionEnd_Remote_Max = 4999,

		// 5xxx: Connection failed for some other reason.
		k_ESteamNetConnectionEnd_Misc_Min = 5000,

			// A failure that isn't necessarily the result of a software bug,
			// but that should happen rarely enough that it isn't worth specifically
			// writing UI or making a localized message for.
			// The debug string should contain further details.
		k_ESteamNetConnectionEnd_Misc_Generic = 5001,

			// Generic failure that is most likely a software bug.
		k_ESteamNetConnectionEnd_Misc_InternalError = 5002,

			// The connection to the remote host timed out, but we
			// don't know if the problem is on our end, in the middle,
			// or on their end.
		k_ESteamNetConnectionEnd_Misc_Timeout = 5003,

			//k_ESteamNetConnectionEnd_Misc_RelayConnectivity_DEPRECATED = 5004,

			// There's some trouble talking to Steam.
		k_ESteamNetConnectionEnd_Misc_SteamConnectivity = 5005,

			// A server in a dedicated hosting situation has no relay sessions
			// active with which to talk back to a client.  (It's the client's
			// job to open and maintain those sessions.)
		k_ESteamNetConnectionEnd_Misc_NoRelaySessionsToClient = 5006,

			// While trying to initiate a connection, we never received
			// *any* communication from the peer.
			//k_ESteamNetConnectionEnd_Misc_ServerNeverReplied = 5007,

			// P2P rendezvous failed in a way that we don't have more specific
			// information
		k_ESteamNetConnectionEnd_Misc_P2P_Rendezvous = 5008,

			// NAT punch failed, probably due to NAT/firewall configuration.
			//
			// If relay fallback is available (it always is on Steam), then
			// this is only used internally and will not be returned as a high
			// level failure.
		k_ESteamNetConnectionEnd_Misc_P2P_NAT_Firewall = 5009,

			// Our peer replied that it has no record of the connection.
			// This should not happen ordinarily, but can happen in a few
			// exception cases:
			//
			// - This is an old connection, and the peer has already cleaned
			//   up and forgotten about it.  (Perhaps it timed out and they
			//   closed it and were not able to communicate this to us.)
			// - A bug or internal protocol error has caused us to try to
			//   talk to the peer about the connection before we received
			//   confirmation that the peer has accepted the connection.
			// - The peer thinks that we have closed the connection for some
			//   reason (perhaps a bug), and believes that is it is
			//   acknowledging our closure.
		k_ESteamNetConnectionEnd_Misc_PeerSentNoConnection = 5010,

		k_ESteamNetConnectionEnd_Misc_Max = 5999,

		k_ESteamNetConnectionEnd__Force32Bit = 0x7fffffff
	}

	//
	// Configuration values
	//
	/// Configuration values can be applied to different types of objects.
	public enum ESteamNetworkingConfigScope : int {

		/// Get/set global option, or defaults.  Even options that apply to more specific scopes
		/// have global scope, and you may be able to just change the global defaults.  If you
		/// need different settings per connection (for example), then you will need to set those
		/// options at the more specific scope.
		k_ESteamNetworkingConfig_Global = 1,

		/// Some options are specific to a particular interface.  Note that all connection
		/// and listen socket settings can also be set at the interface level, and they will
		/// apply to objects created through those interfaces.
		k_ESteamNetworkingConfig_SocketsInterface = 2,

		/// Options for a listen socket.  Listen socket options can be set at the interface layer,
		/// if  you have multiple listen sockets and they all use the same options.
		/// You can also set connection options on a listen socket, and they set the defaults
		/// for all connections accepted through this listen socket.  (They will be used if you don't
		/// set a connection option.)
		k_ESteamNetworkingConfig_ListenSocket = 3,

		/// Options for a specific connection.
		k_ESteamNetworkingConfig_Connection = 4,

		k_ESteamNetworkingConfigScope__Force32Bit = 0x7fffffff
	}

	// Different configuration values have different data types
	public enum ESteamNetworkingConfigDataType : int {
		k_ESteamNetworkingConfig_Int32 = 1,
		k_ESteamNetworkingConfig_Int64 = 2,
		k_ESteamNetworkingConfig_Float = 3,
		k_ESteamNetworkingConfig_String = 4,
		k_ESteamNetworkingConfig_Ptr = 5,

		k_ESteamNetworkingConfigDataType__Force32Bit = 0x7fffffff
	}

	/// Configuration options
	public enum ESteamNetworkingConfigValue : int {
		k_ESteamNetworkingConfig_Invalid = 0,

	//
	// Connection options
	//

		/// [connection int32] Timeout value (in ms) to use when first connecting
		k_ESteamNetworkingConfig_TimeoutInitial = 24,

		/// [connection int32] Timeout value (in ms) to use after connection is established
		k_ESteamNetworkingConfig_TimeoutConnected = 25,

		/// [connection int32] Upper limit of buffered pending bytes to be sent,
		/// if this is reached SendMessage will return k_EResultLimitExceeded
		/// Default is 512k (524288 bytes)
		k_ESteamNetworkingConfig_SendBufferSize = 9,

		/// [connection int64] Get/set userdata as a configuration option.
		/// The default value is -1.   You may want to set the user data as
		/// a config value, instead of using ISteamNetworkingSockets::SetConnectionUserData
		/// in two specific instances:
		///
		/// - You wish to set the userdata atomically when creating
		///   an outbound connection, so that the userdata is filled in properly
		///   for any callbacks that happen.  However, note that this trick
		///   only works for connections initiated locally!  For incoming
		///   connections, multiple state transitions may happen and
		///   callbacks be queued, before you are able to service the first
		///   callback!  Be careful!
		///
		/// - You can set the default userdata for all newly created connections
		///   by setting this value at a higher level (e.g. on the listen
		///   socket or at the global level.)  Then this default
		///   value will be inherited when the connection is created.
		///   This is useful in case -1 is a valid userdata value, and you
		///   wish to use something else as the default value so you can
		///   tell if it has been set or not.
		///
		///   HOWEVER: once a connection is created, the effective value is
		///   then bound to the connection.  Unlike other connection options,
		///   if you change it again at a higher level, the new value will not
		///   be inherited by connections.
		///
		/// Using the userdata field in callback structs is not advised because
		/// of tricky race conditions.  Instead, you might try one of these methods:
		///
		/// - Use a separate map with the HSteamNetConnection as the key.
		/// - Fetch the userdata from the connection in your callback
		///   using ISteamNetworkingSockets::GetConnectionUserData, to
		//    ensure you have the current value.
		k_ESteamNetworkingConfig_ConnectionUserData = 40,

		/// [connection int32] Minimum/maximum send rate clamp, 0 is no limit.
		/// This value will control the min/max allowed sending rate that
		/// bandwidth estimation is allowed to reach.  Default is 0 (no-limit)
		k_ESteamNetworkingConfig_SendRateMin = 10,
		k_ESteamNetworkingConfig_SendRateMax = 11,

		/// [connection int32] Nagle time, in microseconds.  When SendMessage is called, if
		/// the outgoing message is less than the size of the MTU, it will be
		/// queued for a delay equal to the Nagle timer value.  This is to ensure
		/// that if the application sends several small messages rapidly, they are
		/// coalesced into a single packet.
		/// See historical RFC 896.  Value is in microseconds.
		/// Default is 5000us (5ms).
		k_ESteamNetworkingConfig_NagleTime = 12,

		/// [connection int32] Don't automatically fail IP connections that don't have
		/// strong auth.  On clients, this means we will attempt the connection even if
		/// we don't know our identity or can't get a cert.  On the server, it means that
		/// we won't automatically reject a connection due to a failure to authenticate.
		/// (You can examine the incoming connection and decide whether to accept it.)
		///
		/// This is a dev configuration value, and you should not let users modify it in
		/// production.
		k_ESteamNetworkingConfig_IP_AllowWithoutAuth = 23,

		/// [connection int32] Do not send UDP packets with a payload of
		/// larger than N bytes.  If you set this, k_ESteamNetworkingConfig_MTU_DataSize
		/// is automatically adjusted
		k_ESteamNetworkingConfig_MTU_PacketSize = 32,

		/// [connection int32] (read only) Maximum message size you can send that
		/// will not fragment, based on k_ESteamNetworkingConfig_MTU_PacketSize
		k_ESteamNetworkingConfig_MTU_DataSize = 33,

		/// [connection int32] Allow unencrypted (and unauthenticated) communication.
		/// 0: Not allowed (the default)
		/// 1: Allowed, but prefer encrypted
		/// 2: Allowed, and preferred
		/// 3: Required.  (Fail the connection if the peer requires encryption.)
		///
		/// This is a dev configuration value, since its purpose is to disable encryption.
		/// You should not let users modify it in production.  (But note that it requires
		/// the peer to also modify their value in order for encryption to be disabled.)
		k_ESteamNetworkingConfig_Unencrypted = 34,

		/// [connection int32] Set this to 1 on outbound connections and listen sockets,
		/// to enable "symmetric connect mode", which is useful in the following
		/// common peer-to-peer use case:
		///
		/// - The two peers are "equal" to each other.  (Neither is clearly the "client"
		///   or "server".)
		/// - Either peer may initiate the connection, and indeed they may do this
		///   at the same time
		/// - The peers only desire a single connection to each other, and if both
		///   peers initiate connections simultaneously, a protocol is needed for them
		///   to resolve the conflict, so that we end up with a single connection.
		///
		/// This use case is both common, and involves subtle race conditions and tricky
		/// pitfalls, which is why the API has support for dealing with it.
		///
		/// If an incoming connection arrives on a listen socket or via custom signaling,
		/// and the application has not attempted to make a matching outbound connection
		/// in symmetric mode, then the incoming connection can be accepted as usual.
		/// A "matching" connection means that the relevant endpoint information matches.
		/// (At the time this comment is being written, this is only supported for P2P
		/// connections, which means that the peer identities must match, and the virtual
		/// port must match.  At a later time, symmetric mode may be supported for other
		/// connection types.)
		///
		/// If connections are initiated by both peers simultaneously, race conditions
		/// can arise, but fortunately, most of them are handled internally and do not
		/// require any special awareness from the application.  However, there
		/// is one important case that application code must be aware of:
		/// If application code attempts an outbound connection using a ConnectXxx
		/// function in symmetric mode, and a matching incoming connection is already
		/// waiting on a listen socket, then instead of forming a new connection,
		/// the ConnectXxx call will accept the existing incoming connection, and return
		/// a connection handle to this accepted connection.
		/// IMPORTANT: in this case, a SteamNetConnectionStatusChangedCallback_t
		/// has probably *already* been posted to the queue for the incoming connection!
		/// (Once callbacks are posted to the queue, they are not modified.)  It doesn't
		/// matter if the callback has not been consumed by the app.  Thus, application
		/// code that makes use of symmetric connections must be aware that, when processing a
		/// SteamNetConnectionStatusChangedCallback_t for an incoming connection, the
		/// m_hConn may refer to a new connection that the app has has not
		/// seen before (the usual case), but it may also refer to a connection that
		/// has already been accepted implicitly through a call to Connect()!  In this
		/// case, AcceptConnection() will return k_EResultDuplicateRequest.
		///
		/// Only one symmetric connection to a given peer (on a given virtual port)
		/// may exist at any given time.  If client code attempts to create a connection,
		/// and a (live) connection already exists on the local host, then either the
		/// existing connection will be accepted as described above, or the attempt
		/// to create a new connection will fail.  Furthermore, linger mode functionality
		/// is not supported on symmetric connections.
		///
		/// A more complicated race condition can arise if both peers initiate a connection
		/// at roughly the same time.  In this situation, each peer will receive an incoming
		/// connection from the other peer, when the application code has already initiated
		/// an outgoing connection to that peer.  The peers must resolve this conflict and
		/// decide who is going to act as the "server" and who will act as the "client".
		/// Typically the application does not need to be aware of this case as it is handled
		/// internally.  On both sides, the will observe their outbound connection being
		/// "accepted", although one of them one have been converted internally to act
		/// as the "server".
		///
		/// In general, symmetric mode should be all-or-nothing: do not mix symmetric
		/// connections with a non-symmetric connection that it might possible "match"
		/// with.  If you use symmetric mode on any connections, then both peers should
		/// use it on all connections, and the corresponding listen socket, if any.  The
		/// behaviour when symmetric and ordinary connections are mixed is not defined by
		/// this API, and you should not rely on it.  (This advice only applies when connections
		/// might possibly "match".  For example, it's OK to use all symmetric mode
		/// connections on one virtual port, and all ordinary, non-symmetric connections
		/// on a different virtual port, as there is no potential for ambiguity.)
		///
		/// When using the feature, you should set it in the following situations on
		/// applicable objects:
		///
		/// - When creating an outbound connection using ConnectXxx function
		/// - When creating a listen socket.  (Note that this will automatically cause
		///   any accepted connections to inherit the flag.)
		/// - When using custom signaling, before accepting an incoming connection.
		///
		/// Setting the flag on listen socket and accepted connections will enable the
		/// API to automatically deal with duplicate incoming connections, even if the
		/// local host has not made any outbound requests.  (In general, such duplicate
		/// requests from a peer are ignored internally and will not be visible to the
		/// application code.  The previous connection must be closed or resolved first.)
		k_ESteamNetworkingConfig_SymmetricConnect = 37,

		/// [connection int32] For connection types that use "virtual ports", this can be used
		/// to assign a local virtual port.  For incoming connections, this will always be the
		/// virtual port of the listen socket (or the port requested by the remote host if custom
		/// signaling is used and the connection is accepted), and cannot be changed.  For
		/// connections initiated locally, the local virtual port will default to the same as the
		/// requested remote virtual port, if you do not specify a different option when creating
		/// the connection.  The local port is only relevant for symmetric connections, when
		/// determining if two connections "match."  In this case, if you need the local and remote
		/// port to differ, you can set this value.
		///
		/// You can also read back this value on listen sockets.
		///
		/// This value should not be read or written in any other context.
		k_ESteamNetworkingConfig_LocalVirtualPort = 38,

		/// [connection int32] Enable Dual wifi band support for this connection
		/// 0 = no, 1 = yes, 2 = simulate it for debugging, even if dual wifi not available
		k_ESteamNetworkingConfig_DualWifi_Enable = 39,

		/// [connection int32] True to enable diagnostics reporting through
		/// generic platform UI.  (Only available on Steam.)
		k_ESteamNetworkingConfig_EnableDiagnosticsUI = 46,

	//
	// Simulating network conditions
	//
	// These are global (not per-connection) because they apply at
	// a relatively low UDP layer.
	//

		/// [global float, 0--100] Randomly discard N pct of packets instead of sending/recv
		/// This is a global option only, since it is applied at a low level
		/// where we don't have much context
		k_ESteamNetworkingConfig_FakePacketLoss_Send = 2,
		k_ESteamNetworkingConfig_FakePacketLoss_Recv = 3,

		/// [global int32].  Delay all outbound/inbound packets by N ms
		k_ESteamNetworkingConfig_FakePacketLag_Send = 4,
		k_ESteamNetworkingConfig_FakePacketLag_Recv = 5,

		/// [global float] 0-100 Percentage of packets we will add additional delay
		/// to (causing them to be reordered)
		k_ESteamNetworkingConfig_FakePacketReorder_Send = 6,
		k_ESteamNetworkingConfig_FakePacketReorder_Recv = 7,

		/// [global int32] Extra delay, in ms, to apply to reordered packets.
		k_ESteamNetworkingConfig_FakePacketReorder_Time = 8,

		/// [global float 0--100] Globally duplicate some percentage of packets we send
		k_ESteamNetworkingConfig_FakePacketDup_Send = 26,
		k_ESteamNetworkingConfig_FakePacketDup_Recv = 27,

		/// [global int32] Amount of delay, in ms, to delay duplicated packets.
		/// (We chose a random delay between 0 and this value)
		k_ESteamNetworkingConfig_FakePacketDup_TimeMax = 28,

		/// [global int32] Trace every UDP packet, similar to Wireshark or tcpdump.
		/// Value is max number of bytes to dump.  -1 disables tracing.
		// 0 only traces the info but no actual data bytes
		k_ESteamNetworkingConfig_PacketTraceMaxBytes = 41,


		// [global int32] Global UDP token bucket rate limits.
		// "Rate" refers to the steady state rate. (Bytes/sec, the
		// rate that tokens are put into the bucket.)  "Burst"
		// refers to the max amount that could be sent in a single
		// burst.  (In bytes, the max capacity of the bucket.)
		// Rate=0 disables the limiter entirely, which is the default.
		// Burst=0 disables burst.  (This is not realistic.  A
		// burst of at least 4K is recommended; the default is higher.)
		k_ESteamNetworkingConfig_FakeRateLimit_Send_Rate = 42,
		k_ESteamNetworkingConfig_FakeRateLimit_Send_Burst = 43,
		k_ESteamNetworkingConfig_FakeRateLimit_Recv_Rate = 44,
		k_ESteamNetworkingConfig_FakeRateLimit_Recv_Burst = 45,

	//
	// Callbacks
	//

		// On Steam, you may use the default Steam callback dispatch mechanism.  If you prefer
		// to not use this dispatch mechanism (or you are not running with Steam), or you want
		// to associate specific functions with specific listen sockets or connections, you can
		// register them as configuration values.
		//
		// Note also that ISteamNetworkingUtils has some helpers to set these globally.

		/// [connection FnSteamNetConnectionStatusChanged] Callback that will be invoked
		/// when the state of a connection changes.
		///
		/// IMPORTANT: callbacks are dispatched to the handler that is in effect at the time
		/// the event occurs, which might be in another thread.  For example, immediately after
		/// creating a listen socket, you may receive an incoming connection.  And then immediately
		/// after this, the remote host may close the connection.  All of this could happen
		/// before the function to create the listen socket has returned.  For this reason,
		/// callbacks usually must be in effect at the time of object creation.  This means
		/// you should set them when you are creating the listen socket or connection, or have
		/// them in effect so they will be inherited at the time of object creation.
		///
		/// For example:
		///
		/// exterm void MyStatusChangedFunc( SteamNetConnectionStatusChangedCallback_t *info );
		/// SteamNetworkingConfigValue_t opt; opt.SetPtr( k_ESteamNetworkingConfig_Callback_ConnectionStatusChanged, MyStatusChangedFunc );
		/// SteamNetworkingIPAddr localAddress; localAddress.Clear();
		/// HSteamListenSocket hListenSock = SteamNetworkingSockets()->CreateListenSocketIP( localAddress, 1, &opt );
		///
		/// When accepting an incoming connection, there is no atomic way to switch the
		/// callback.  However, if the connection is DOA, AcceptConnection() will fail, and
		/// you can fetch the state of the connection at that time.
		///
		/// If all connections and listen sockets can use the same callback, the simplest
		/// method is to set it globally before you create any listen sockets or connections.
		k_ESteamNetworkingConfig_Callback_ConnectionStatusChanged = 201,

		/// [global FnSteamNetAuthenticationStatusChanged] Callback that will be invoked
		/// when our auth state changes.  If you use this, install the callback before creating
		/// any connections or listen sockets, and don't change it.
		/// See: ISteamNetworkingUtils::SetGlobalCallback_SteamNetAuthenticationStatusChanged
		k_ESteamNetworkingConfig_Callback_AuthStatusChanged = 202,

		/// [global FnSteamRelayNetworkStatusChanged] Callback that will be invoked
		/// when our auth state changes.  If you use this, install the callback before creating
		/// any connections or listen sockets, and don't change it.
		/// See: ISteamNetworkingUtils::SetGlobalCallback_SteamRelayNetworkStatusChanged
		k_ESteamNetworkingConfig_Callback_RelayNetworkStatusChanged = 203,

		/// [global FnSteamNetworkingMessagesSessionRequest] Callback that will be invoked
		/// when a peer wants to initiate a SteamNetworkingMessagesSessionRequest.
		/// See: ISteamNetworkingUtils::SetGlobalCallback_MessagesSessionRequest
		k_ESteamNetworkingConfig_Callback_MessagesSessionRequest = 204,

		/// [global FnSteamNetworkingMessagesSessionFailed] Callback that will be invoked
		/// when a session you have initiated, or accepted either fails to connect, or loses
		/// connection in some unexpected way.
		/// See: ISteamNetworkingUtils::SetGlobalCallback_MessagesSessionFailed
		k_ESteamNetworkingConfig_Callback_MessagesSessionFailed = 205,

		/// [global FnSteamNetworkingSocketsCreateConnectionSignaling] Callback that will
		/// be invoked when we need to create a signaling object for a connection
		/// initiated locally.  See: ISteamNetworkingSockets::ConnectP2P,
		/// ISteamNetworkingMessages.
		k_ESteamNetworkingConfig_Callback_CreateConnectionSignaling = 206,

		/// [global FnSteamNetworkingFakeIPResult] Callback that's invoked when
		/// a FakeIP allocation finishes.  See: ISteamNetworkingSockets::BeginAsyncRequestFakeIP,
		/// ISteamNetworkingUtils::SetGlobalCallback_FakeIPResult
		k_ESteamNetworkingConfig_Callback_FakeIPResult = 207,

	//
	// P2P connection settings
	//

	//	/// [listen socket int32] When you create a P2P listen socket, we will automatically
	//	/// open up a UDP port to listen for LAN connections.  LAN connections can be made
	//	/// without any signaling: both sides can be disconnected from the Internet.
	//	///
	//	/// This value can be set to zero to disable the feature.
	//	k_ESteamNetworkingConfig_P2P_Discovery_Server_LocalPort = 101,
	//
	//	/// [connection int32] P2P connections can perform broadcasts looking for the peer
	//	/// on the LAN.
	//	k_ESteamNetworkingConfig_P2P_Discovery_Client_RemotePort = 102,

		/// [connection string] Comma-separated list of STUN servers that can be used
		/// for NAT piercing.  If you set this to an empty string, NAT piercing will
		/// not be attempted.  Also if "public" candidates are not allowed for
		/// P2P_Transport_ICE_Enable, then this is ignored.
		k_ESteamNetworkingConfig_P2P_STUN_ServerList = 103,

		/// [connection int32] What types of ICE candidates to share with the peer.
		/// See k_nSteamNetworkingConfig_P2P_Transport_ICE_Enable_xxx values
		k_ESteamNetworkingConfig_P2P_Transport_ICE_Enable = 104,

		/// [connection int32] When selecting P2P transport, add various
		/// penalties to the scores for selected transports.  (Route selection
		/// scores are on a scale of milliseconds.  The score begins with the
		/// route ping time and is then adjusted.)
		k_ESteamNetworkingConfig_P2P_Transport_ICE_Penalty = 105,
		k_ESteamNetworkingConfig_P2P_Transport_SDR_Penalty = 106,
		k_ESteamNetworkingConfig_P2P_TURN_ServerList = 107,
		k_ESteamNetworkingConfig_P2P_TURN_UserList = 108,
		k_ESteamNetworkingConfig_P2P_TURN_PassList = 109,
		//k_ESteamNetworkingConfig_P2P_Transport_LANBeacon_Penalty = 107,
		k_ESteamNetworkingConfig_P2P_Transport_ICE_Implementation = 110,

	//
	// Settings for SDR relayed connections
	//

		/// [int32 global] If the first N pings to a port all fail, mark that port as unavailable for
		/// a while, and try a different one.  Some ISPs and routers may drop the first
		/// packet, so setting this to 1 may greatly disrupt communications.
		k_ESteamNetworkingConfig_SDRClient_ConsecutitivePingTimeoutsFailInitial = 19,

		/// [int32 global] If N consecutive pings to a port fail, after having received successful
		/// communication, mark that port as unavailable for a while, and try a
		/// different one.
		k_ESteamNetworkingConfig_SDRClient_ConsecutitivePingTimeoutsFail = 20,

		/// [int32 global] Minimum number of lifetime pings we need to send, before we think our estimate
		/// is solid.  The first ping to each cluster is very often delayed because of NAT,
		/// routers not having the best route, etc.  Until we've sent a sufficient number
		/// of pings, our estimate is often inaccurate.  Keep pinging until we get this
		/// many pings.
		k_ESteamNetworkingConfig_SDRClient_MinPingsBeforePingAccurate = 21,

		/// [int32 global] Set all steam datagram traffic to originate from the same
		/// local port. By default, we open up a new UDP socket (on a different local
		/// port) for each relay.  This is slightly less optimal, but it works around
		/// some routers that don't implement NAT properly.  If you have intermittent
		/// problems talking to relays that might be NAT related, try toggling
		/// this flag
		k_ESteamNetworkingConfig_SDRClient_SingleSocket = 22,

		/// [global string] Code of relay cluster to force use.  If not empty, we will
		/// only use relays in that cluster.  E.g. 'iad'
		k_ESteamNetworkingConfig_SDRClient_ForceRelayCluster = 29,

		/// [connection string] For debugging, generate our own (unsigned) ticket, using
		/// the specified  gameserver address.  Router must be configured to accept unsigned
		/// tickets.
		k_ESteamNetworkingConfig_SDRClient_DebugTicketAddress = 30,

		/// [global string] For debugging.  Override list of relays from the config with
		/// this set (maybe just one).  Comma-separated list.
		k_ESteamNetworkingConfig_SDRClient_ForceProxyAddr = 31,

		/// [global string] For debugging.  Force ping times to clusters to be the specified
		/// values.  A comma separated list of <cluster>=<ms> values.  E.g. "sto=32,iad=100"
		///
		/// This is a dev configuration value, you probably should not let users modify it
		/// in production.
		k_ESteamNetworkingConfig_SDRClient_FakeClusterPing = 36,

	//
	// Log levels for debugging information of various subsystems.
	// Higher numeric values will cause more stuff to be printed.
	// See ISteamNetworkingUtils::SetDebugOutputFunction for more
	// information
	//
	// The default for all values is k_ESteamNetworkingSocketsDebugOutputType_Warning.
	//
		k_ESteamNetworkingConfig_LogLevel_AckRTT = 13, // [connection int32] RTT calculations for inline pings and replies
		k_ESteamNetworkingConfig_LogLevel_PacketDecode = 14, // [connection int32] log SNP packets send/recv
		k_ESteamNetworkingConfig_LogLevel_Message = 15, // [connection int32] log each message send/recv
		k_ESteamNetworkingConfig_LogLevel_PacketGaps = 16, // [connection int32] dropped packets
		k_ESteamNetworkingConfig_LogLevel_P2PRendezvous = 17, // [connection int32] P2P rendezvous messages
		k_ESteamNetworkingConfig_LogLevel_SDRRelayPings = 18, // [global int32] Ping relays


		// Deleted, do not use
		k_ESteamNetworkingConfig_DELETED_EnumerateDevVars = 35,

		k_ESteamNetworkingConfigValue__Force32Bit = 0x7fffffff
	}

	/// Return value of ISteamNetworkintgUtils::GetConfigValue
	public enum ESteamNetworkingGetConfigValueResult : int {
		k_ESteamNetworkingGetConfigValue_BadValue = -1,	// No such configuration value
		k_ESteamNetworkingGetConfigValue_BadScopeObj = -2,	// Bad connection handle, etc
		k_ESteamNetworkingGetConfigValue_BufferTooSmall = -3, // Couldn't fit the result in your buffer
		k_ESteamNetworkingGetConfigValue_OK = 1,
		k_ESteamNetworkingGetConfigValue_OKInherited = 2, // A value was not set at this level, but the effective (inherited) value was returned.

		k_ESteamNetworkingGetConfigValueResult__Force32Bit = 0x7fffffff
	}

	//
	// Debug output
	//
	/// Detail level for diagnostic output callback.
	/// See ISteamNetworkingUtils::SetDebugOutputFunction
	public enum ESteamNetworkingSocketsDebugOutputType : int {
		k_ESteamNetworkingSocketsDebugOutputType_None = 0,
		k_ESteamNetworkingSocketsDebugOutputType_Bug = 1, // You used the API incorrectly, or an internal error happened
		k_ESteamNetworkingSocketsDebugOutputType_Error = 2, // Run-time error condition that isn't the result of a bug.  (E.g. we are offline, cannot bind a port, etc)
		k_ESteamNetworkingSocketsDebugOutputType_Important = 3, // Nothing is wrong, but this is an important notification
		k_ESteamNetworkingSocketsDebugOutputType_Warning = 4,
		k_ESteamNetworkingSocketsDebugOutputType_Msg = 5, // Recommended amount
		k_ESteamNetworkingSocketsDebugOutputType_Verbose = 6, // Quite a bit
		k_ESteamNetworkingSocketsDebugOutputType_Debug = 7, // Practically everything
		k_ESteamNetworkingSocketsDebugOutputType_Everything = 8, // Wall of text, detailed packet contents breakdown, etc

		k_ESteamNetworkingSocketsDebugOutputType__Force32Bit = 0x7fffffff
	}

	public enum ESteamIPType : int {
		k_ESteamIPTypeIPv4 = 0,
		k_ESteamIPTypeIPv6 = 1,
	}

	// Steam universes.  Each universe is a self-contained Steam instance.
	public enum EUniverse : int {
		k_EUniverseInvalid = 0,
		k_EUniversePublic = 1,
		k_EUniverseBeta = 2,
		k_EUniverseInternal = 3,
		k_EUniverseDev = 4,
		// k_EUniverseRC = 5,				// no such universe anymore
		k_EUniverseMax
	}

}

#endif // !DISABLESTEAMWORKS
