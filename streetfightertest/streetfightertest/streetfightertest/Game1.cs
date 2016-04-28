//Sorry

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace streetfightertest {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteEffects flip = SpriteEffects.FlipHorizontally;
        SpriteFont titleFont;
        SpriteFont textFont;

        GamePadState pad1, pad2;
        SoundEffect kenAttackSound, kenHadoukenSound, kenShoryukenSound, kenTatsumakiSound, kenDeathSound;
        SoundEffect ryuAttackSound, ryuHadoukenSound, ryuShoryukenSound, ryuTatsumakiSound, ryuDeathSound;
        SoundEffect hitSmallSound, hitMediumSound, hitHighSound, blockSound;
        SoundEffect narratorWin;

        Rectangle kenRect;
        Rectangle kenHadoukenRect;
        Rectangle kenHitboxMovementRect;

        Rectangle ryuRect;
        Rectangle ryuHadoukenRect;
        Rectangle ryuHitboxMovementRect;

        Texture2D background;
        Rectangle backgroundRect;

        Texture2D[] kenIdlePics = new Texture2D[4];
        Texture2D[] kenWalkingPics = new Texture2D[5];
        Texture2D[] kenJumpingPics = new Texture2D[7];
        Texture2D kenCrouchPic;
        Texture2D[] kenForwardJumpingPics = new Texture2D[6];
        Texture2D[] ryuIdlePics = new Texture2D[4];
        Texture2D[] ryuWalkingPics = new Texture2D[5];
        Texture2D[] ryuJumpingPics = new Texture2D[7];
        Texture2D ryuCrouchPic;
        Texture2D[] ryuForwardJumpingPics = new Texture2D[6];

        Texture2D[] kenLowPunchPics = new Texture2D[3];
        Texture2D[] kenMediumHighPunchPics = new Texture2D[5];
        Texture2D[] ryuLowPunchPics = new Texture2D[3];
        Texture2D[] ryuMediumHighPunchPics = new Texture2D[5];

        Texture2D[] kenLowMediumCrouchPunchPics = new Texture2D[3];
        Texture2D[] kenHighCrouchPunchPics = new Texture2D[5];
        Texture2D[] ryuLowMediumCrouchPunchPics = new Texture2D[3];
        Texture2D[] ryuHighCrouchPunchPics = new Texture2D[5];

        Texture2D[] kenForwardLowPunchPics = new Texture2D[3];
        Texture2D[] kenForwardMediumPunchPics = new Texture2D[7];
        Texture2D[] kenForwardHighPunchPics = new Texture2D[5];
        Texture2D[] ryuForwardLowPunchPics = new Texture2D[3];
        Texture2D[] ryuForwardMediumPunchPics = new Texture2D[7];
        Texture2D[] ryuForwardHighPunchPics = new Texture2D[5];

        Texture2D[] kenLowMediumKickPics = new Texture2D[3];
        Texture2D[] kenHighKickPics = new Texture2D[5];
        Texture2D[] ryuLowMediumKickPics = new Texture2D[3];
        Texture2D[] ryuHighKickPics = new Texture2D[5];

        Texture2D[] kenLowCrouchKickPics = new Texture2D[3];
        Texture2D[] kenMediumCrouchKickPics = new Texture2D[3];
        Texture2D[] kenHighCrouchKickPics = new Texture2D[5];
        Texture2D[] ryuLowCrouchKickPics = new Texture2D[3];
        Texture2D[] ryuMediumCrouchKickPics = new Texture2D[3];
        Texture2D[] ryuHighCrouchKickPics = new Texture2D[5];

        Texture2D[] kenForwardLowKickPics = new Texture2D[3];
        Texture2D[] kenForwardMediumKickPics = new Texture2D[5];
        Texture2D[] kenForwardHighKickPics = new Texture2D[5];
        Texture2D[] ryuForwardLowKickPics = new Texture2D[3];
        Texture2D[] ryuForwardMediumKickPics = new Texture2D[5];
        Texture2D[] ryuForwardHighKickPics = new Texture2D[5];

        Texture2D[] kenHadoukenPics = new Texture2D[4];
        Texture2D[] kenHadoukenProjectilePics = new Texture2D[6];
        Texture2D[] kenTatsumakiPics = new Texture2D[12];
        Texture2D[] kenShoryukenPics = new Texture2D[7];
        Texture2D[] ryuHadoukenPics = new Texture2D[4];
        Texture2D[] ryuHadoukenProjectilePics = new Texture2D[6];
        Texture2D[] ryuTatsumakiPics = new Texture2D[12];
        Texture2D[] ryuShoryukenPics = new Texture2D[7];

        Texture2D[] kenHitPics = new Texture2D[4];
        Texture2D[] kenFaceHitPics = new Texture2D[4];
        Texture2D kenCrouchHitPic;
        Texture2D[] kenKnockoutPics = new Texture2D[5];
        Texture2D[] kenKnockdownPics = new Texture2D[8];
        Texture2D[] kenVictoryPics = new Texture2D[3];
        Texture2D[] ryuHitPics = new Texture2D[4];
        Texture2D[] ryuFaceHitPics = new Texture2D[4];
        Texture2D ryuCrouchHitPic;
        Texture2D[] ryuKnockoutPics = new Texture2D[5];
        Texture2D[] ryuKnockdownPics = new Texture2D[8];
        Texture2D[] ryuVictoryPics = new Texture2D[3];

        Texture2D hitboxMovementPic;
        Texture2D hitboxAttackPic;

        Texture2D kenBlockPic, kenBlockCrouchPic, ryuBlockPic, ryuBlockCrouchPic;

        Texture2D[] healthBar = new Texture2D[3];

        Rectangle lowPunchHitboxKen, mediumPunchHitboxKen, highPunchHitboxKen, lowKickHitboxKen, mediumKickHitboxKen, highKickHitboxKen,
            crouchLowPunchHitboxKen, crouchMediumPunchHitboxKen, crouchHighPunchHitboxKen, crouchLowKickHitboxKen, crouchMediumKickHitboxKen, crouchHighKickHitboxKen,
            forwardLowPunchHitboxKen, forwardMediumPunchHitboxKen, forwardHighPunchHitboxKen, forwardLowKickHitboxKen, forwardMediumKickHitboxKen, forwardHighKickHitboxKen,
            hadoukenHitboxKen, tatsumakiHitboxKen, shoryukenHitboxKen,
            lowPunchHitboxRyu, mediumPunchHitboxRyu, highPunchHitboxRyu, lowKickHitboxRyu, mediumKickHitboxRyu, highKickHitboxRyu,
            crouchLowPunchHitboxRyu, crouchMediumPunchHitboxRyu, crouchHighPunchHitboxRyu, crouchLowKickHitboxRyu, crouchMediumKickHitboxRyu, crouchHighKickHitboxRyu,
            forwardLowPunchHitboxRyu, forwardMediumPunchHitboxRyu, forwardHighPunchHitboxRyu, forwardLowKickHitboxRyu, forwardMediumKickHitboxRyu, forwardHighKickHitboxRyu,
            hadoukenHitboxRyu, tatsumakiHitboxRyu, shoryukenHitboxRyu;

        int movementSeparation = 8;
        int jumpSeparation = 5;
        const int jumpIncrementHeight = 60;
        const int comboTimeLimit = 30;
        int attackSeparation = 6;
        int afterActionPause = 10;
        int hitSeparation = 10;
        const int victorySeparation = 30;
        const int blockDuration = 20;

        int ticks = 0;

        //hitbox coordinates in relation to body
        const int lowPunchX = 240; const int lowPunchY = 190;
        const int lowPunchReverseX = 100; const int lowPunchReverseY = 190;
        const int mediumPunchX = 240; const int mediumPunchY = 180;
        const int mediumPunchReverseX = 60; const int mediumPunchReverseY = 180;
        const int highPunchX = 240; const int highPunchY = 180;
        const int highPunchReverseX = 50; const int highPunchReverseY = 180;

        const int lowKickX = 220; const int lowKickY = 140;
        const int lowKickReverseX = 120; const int lowKickReverseY = 140;
        const int mediumKickX = 220; const int mediumKickY = 140;
        const int mediumKickReverseX = 120; const int mediumKickReverseY = 140;
        const int highKickX = 220; const int highKickY = 140;
        const int highKickReverseX = 80; const int highKickReverseY = 140;

        const int crouchLowPunchX = 240; const int crouchLowPunchY = 265;
        const int crouchLowPunchReverseX = 100; const int crouchLowPunchReverseY = 265;
        const int crouchMediumPunchX = 240; const int crouchMediumPunchY = 265;
        const int crouchMediumPunchReverseX = 100; const int crouchMediumPunchReverseY = 265;
        const int crouchHighPunchX = 240; const int crouchHighPunchY = 50;
        const int crouchHighPunchReverseX = 100; const int crouchHighPunchReverseY = 50;

        const int crouchLowKickX = 230; const int crouchLowKickY = 320;
        const int crouchLowKickReverseX = 60; const int crouchLowKickReverseY = 320;
        const int crouchMediumKickX = 230; const int crouchMediumKickY = 320;
        const int crouchMediumKickReverseX = 10; const int crouchMediumKickReverseY = 320;
        const int crouchHighKickX = 230; const int crouchHighKickY = 320;
        const int crouchHighKickReverseX = 60; const int crouchHighKickReverseY = 320;

        const int forwardLowPunchX = 220; const int forwardLowPunchY = 130;
        const int forwardLowPunchReverseX = 130; const int forwardLowPunchReverseY = 140;
        const int forwardMediumPunchX = 260; const int forwardMediumPunchY = 170;
        const int forwardMediumPunchReverseX = 90; const int forwardMediumPunchReverseY = 170;
        const int forwardHighPunchX = 260; const int forwardHighPunchY = 80;
        const int forwardHighPunchReverseX = 90; const int forwardHighPunchReverseY = 80;

        const int forwardLowKickX = 250; const int forwardLowKickY = 250;
        const int forwardLowKickReverseX = 60; const int forwardLowKickReverseY = 250;
        const int forwardMediumKickX = 240; const int forwardMediumKickY = 150;
        const int forwardMediumKickReverseX = 110; const int forwardMediumKickReverseY = 150;
        const int forwardHighKickX = 260; const int forwardHighKickY = 100;
        const int forwardHighKickReverseX = 35; const int forwardHighKickReverseY = 110;

        const int hadoukenX = 50;
        const int hadoukenReverseX = -30;
        const int tatsumakiX = 105; const int tatsumakiY = 140;
        const int tatsumakiReverseX = 105; const int tatsumakiReverseY = 140;
        const int shoryukenX = 165; const int shoryukenY = 20;
        const int shoryukenReverseX = 115; const int shoryukenReverseY = 20;

        //ken variables
        int kenAfterActionCount = 30;
        bool kenActionIsNotRunning;
        bool kenActionsPaused = false;

        int kenIdleState = 0;
        int kenWalkingState = 0;
        int kenJumpState = 0;
        int kenForwardJumpState = 0;
        int kenBackwardJumpState = 0;

        int kenLowPunchState = 0;
        int kenLowPunchCrouchState = 0;
        int kenForwardLowPunchState = 0;
        int kenMediumPunchState = 0;
        int kenMediumPunchCrouchState = 0;
        int kenForwardMediumPunchState = 0;
        int kenHighPunchState = 0;
        int kenHighPunchCrouchState = 0;
        int kenForwardHighPunchState = 0;

        int kenLowKickState = 0;
        int kenLowCrouchKickState = 0;
        int kenForwardLowKickState = 0;
        int kenMediumKickState = 0;
        int kenMediumCrouchKickState = 0;
        int kenForwardMediumKickState = 0;
        int kenHighKickState = 0;
        int kenHighCrouchKickState = 0;
        int kenForwardHighKickState = 0;

        int kenInputHadoukenRectX = 0;
        int kenInputHadoukenRectY = 0;

        int kenHadoukenState = 0;
        int kenTatsumakiState = 0;
        int kenShoryukenState = 0;

        int kenHitState = 0;
        int kenFaceHitState = 0;
        int kenKnockdownState = 0;
        int kenKnockoutState = 0;
        int kenVictoryState = 0;

        int kenHadoukenCounter = 0; bool kenHadoukenComboStage1 = false; bool kenHadoukenComboStage2 = false;
        int kenTatsumakiCounter = 0; bool kenTatsumakiComboStage1 = false; bool kenTatsumakiComboStage2 = false;
        int kenShoryukenCounter = 0; bool kenShoryukenComboStage1 = false; bool kenShoryukenComboStage2 = false; bool kenShoryukenComboStage3 = false;

        bool kenFacingRight = true;
        bool kenCrouching = false;

        //ryu variables
        int ryuAfterActionCount = 30;
        bool ryuActionIsNotRunning;
        bool ryuActionsPaused = false;

        int ryuIdleState = 0;
        int ryuWalkingState = 0;
        int ryuJumpState = 0;
        int ryuForwardJumpState = 0;
        int ryuBackwardJumpState = 0;

        int ryuLowPunchState = 0;
        int ryuLowPunchCrouchState = 0;
        int ryuForwardLowPunchState = 0;
        int ryuMediumPunchState = 0;
        int ryuMediumPunchCrouchState = 0;
        int ryuForwardMediumPunchState = 0;
        int ryuHighPunchState = 0;
        int ryuHighPunchCrouchState = 0;
        int ryuForwardHighPunchState = 0;

        int ryuLowKickState = 0;
        int ryuLowCrouchKickState = 0;
        int ryuForwardLowKickState = 0;
        int ryuMediumKickState = 0;
        int ryuMediumCrouchKickState = 0;
        int ryuForwardMediumKickState = 0;
        int ryuHighKickState = 0;
        int ryuHighCrouchKickState = 0;
        int ryuForwardHighKickState = 0;

        int ryuInputHadoukenRectX = 0;
        int ryuInputHadoukenRectY = 0;

        int ryuHadoukenState = 0;
        int ryuTatsumakiState = 0;
        int ryuShoryukenState = 0;

        int ryuHitState = 0;
        int ryuFaceHitState = 0;
        int ryuKnockdownState = 0;
        int ryuKnockoutState = 0;
        int ryuVictoryState = 0;

        int ryuHadoukenCounter = 0; bool ryuHadoukenComboStage1 = false; bool ryuHadoukenComboStage2 = false;
        int ryuTatsumakiCounter = 0; bool ryuTatsumakiComboStage1 = false; bool ryuTatsumakiComboStage2 = false;
        int ryuShoryukenCounter = 0; bool ryuShoryukenComboStage1 = false; bool ryuShoryukenComboStage2 = false; bool ryuShoryukenComboStage3 = false;

        bool ryuCrouching = false;

        enum KenState {
            Idle, WalkingForward, WalkingBackward, Jumping, Crouching, ForwardJumping, BackwardJumping,
            LowPunch, LowPunchCrouch, MediumPunch, MediumPunchCrouch, HighPunch, HighPunchCrouch,
            ForwardLowPunch, ForwardMediumPunch, ForwardHighPunch,
            LowKick, LowCrouchKick, MediumKick, MediumCrouchKick, HighKick, HighCrouchKick,
            ForwardLowKick, ForwardMediumKick, ForwardHighKick,
            Hadouken, Tatsumaki, Shoryuken,

            IdleReverse, WalkingForwardReverse, WalkingBackwardReverse, JumpingReverse, CrouchingReverse, ForwardJumpingReverse, BackwardJumpingReverse,
            LowPunchReverse, LowPunchCrouchReverse, MediumPunchReverse, MediumPunchCrouchReverse, HighPunchReverse, HighPunchCrouchReverse,
            ForwardLowPunchReverse, ForwardMediumPunchReverse, ForwardHighPunchReverse,
            LowKickReverse, LowCrouchKickReverse, MediumKickReverse, MediumCrouchKickReverse, HighKickReverse, HighCrouchKickReverse,
            ForwardLowKickReverse, ForwardMediumKickReverse, ForwardHighKickReverse,
            HadoukenReverse, TatsumakiReverse, ShoryukenReverse,

            Hit, HitReverse, FaceHit, FaceHitReverse, CrouchHit, CrouchHitReverse,
            Knockdown, KnockdownReverse,
            Block, BlockReverse, CrouchBlock, CrouchBlockReverse,
            Knockout, KnockoutReverse, Victory, VictoryReverse

        };

        enum RyuState {
            Idle, WalkingForward, WalkingBackward, Jumping, Crouching, ForwardJumping, BackwardJumping,
            LowPunch, LowPunchCrouch, MediumPunch, MediumPunchCrouch, HighPunch, HighPunchCrouch,
            ForwardLowPunch, ForwardMediumPunch, ForwardHighPunch,
            LowKick, LowCrouchKick, MediumKick, MediumCrouchKick, HighKick, HighCrouchKick,
            ForwardLowKick, ForwardMediumKick, ForwardHighKick,
            Hadouken, Tatsumaki, Shoryuken,

            IdleReverse, WalkingForwardReverse, WalkingBackwardReverse, JumpingReverse, CrouchingReverse, ForwardJumpingReverse, BackwardJumpingReverse,
            LowPunchReverse, LowPunchCrouchReverse, MediumPunchReverse, MediumPunchCrouchReverse, HighPunchReverse, HighPunchCrouchReverse,
            ForwardLowPunchReverse, ForwardMediumPunchReverse, ForwardHighPunchReverse,
            LowKickReverse, LowCrouchKickReverse, MediumKickReverse, MediumCrouchKickReverse, HighKickReverse, HighCrouchKickReverse,
            ForwardLowKickReverse, ForwardMediumKickReverse, ForwardHighKickReverse,
            HadoukenReverse, TatsumakiReverse, ShoryukenReverse,

            Hit, HitReverse, FaceHit, FaceHitReverse, CrouchHit, CrouchHitReverse,
            Knockdown, KnockdownReverse,
            Block, BlockReverse, CrouchBlock, CrouchBlockReverse,
            Knockout, KnockoutReverse, Victory, VictoryReverse

        };

        KenState ken = KenState.Idle;
        RyuState ryu = RyuState.Idle;

        Rectangle kenHealthBar, ryuHealthBar;

        int kenHealth = 100;
        int ryuHealth = 100;

        bool kenIsHit = false;
        bool ryuIsHit = false;
        bool kenIsBlock = false;
        bool ryuIsBlock = false;

        bool kenHadoukenBlock = false;
        bool ryuHadoukenBlock = false;
        int kenHadoukenBlockCounter = 0;
        int ryuHadoukenBlockCounter = 0;

        int kenHitCounter = 0;
        int ryuHitCounter = 0;
        int kenHitTimeCounter = 0;
        int ryuHitTimeCounter = 0;

        bool kenGoingDown = false;
        bool ryuGoingDown = false;

        int kenKnockdownCount = 0;
        int ryuKnockdownCount = 0;

        //Text variables
        Vector2 kenNameVector = new Vector2(20, 10);
        Vector2 ryuNameVector = new Vector2(730, 10);
        Vector2 winMessageVector = new Vector2(350, 120);
        Vector2 playAgainMessageVector = new Vector2(230, 150);

        String winMessage = "";
        String playAgainMessage = "Press Start or Enter to Play Again";

        bool deathSoundPlayed = false;
        bool victorySoundPlayed = false;

        bool endGame = false;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            backgroundRect = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            kenRect = new Rectangle(0, 65, 400, 400);
            kenHadoukenRect = new Rectangle(0, 0, 100, 100);
            kenHitboxMovementRect = new Rectangle(0, 0, 100, 250);

            ryuRect = new Rectangle(400, 65, 400, 400);
            ryuHadoukenRect = new Rectangle(0, 0, 100, 100);
            ryuHitboxMovementRect = new Rectangle(0, 0, 100, 250);

            lowPunchHitboxKen = new Rectangle(-1000, -1000, 70, 30);
            mediumPunchHitboxKen = new Rectangle(-1000, -1000, 110, 30);
            highPunchHitboxKen = new Rectangle(-1000, -1000, 110, 30);
            lowKickHitboxKen = new Rectangle(-1000, -1000, 60, 60);
            mediumKickHitboxKen = new Rectangle(-1000, -1000, 60, 60);
            highKickHitboxKen = new Rectangle(-1000, -1000, 110, 80);
            crouchLowPunchHitboxKen = new Rectangle(-1000, -1000, 70, 40);
            crouchMediumPunchHitboxKen = new Rectangle(-1000, -1000, 70, 40);
            crouchHighPunchHitboxKen = new Rectangle(-1000, -1000, 40, 220);
            crouchLowKickHitboxKen = new Rectangle(-1000, -1000, 110, 80);
            crouchMediumKickHitboxKen = new Rectangle(-1000, -1000, 140, 80);
            crouchHighKickHitboxKen = new Rectangle(-1000, -1000, 110, 80);
            forwardLowPunchHitboxKen = new Rectangle(-1000, -1000, 55, 60);
            forwardMediumPunchHitboxKen = new Rectangle(-1000, -1000, 55, 50);
            forwardHighPunchHitboxKen = new Rectangle(-1000, -1000, 55, 160);
            forwardLowKickHitboxKen = new Rectangle(-1000, -1000, 90, 80);
            forwardMediumKickHitboxKen = new Rectangle(-1000, -1000, 50, 150);
            forwardHighKickHitboxKen = new Rectangle(-1000, -200, 110, 160);
            hadoukenHitboxKen = new Rectangle(-1000, -1000, 80, 100);
            tatsumakiHitboxKen = new Rectangle(-1000, -1000, 200, 40);
            shoryukenHitboxKen = new Rectangle(-1000, -1000, 100, 200);

            lowPunchHitboxRyu = new Rectangle(-1000, -1000, 70, 30);
            mediumPunchHitboxRyu = new Rectangle(-1000, -1000, 110, 30);
            highPunchHitboxRyu = new Rectangle(-1000, -1000, 110, 30);
            lowKickHitboxRyu = new Rectangle(-1000, -1000, 60, 60);
            mediumKickHitboxRyu = new Rectangle(-1000, -1000, 60, 60);
            highKickHitboxRyu = new Rectangle(-1000, -1000, 110, 80);
            crouchLowPunchHitboxRyu = new Rectangle(-1000, -1000, 70, 40);
            crouchMediumPunchHitboxRyu = new Rectangle(-1000, -1000, 70, 40);
            crouchHighPunchHitboxRyu = new Rectangle(-1000, -1000, 40, 220);
            crouchLowKickHitboxRyu = new Rectangle(-1000, -1000, 110, 80);
            crouchMediumKickHitboxRyu = new Rectangle(-1000, -1000, 140, 80);
            crouchHighKickHitboxRyu = new Rectangle(-1000, -1000, 110, 80);
            forwardLowPunchHitboxRyu = new Rectangle(-1000, -1000, 55, 60);
            forwardMediumPunchHitboxRyu = new Rectangle(-1000, -1000, 55, 50);
            forwardHighPunchHitboxRyu = new Rectangle(-1000, -1000, 55, 160);
            forwardLowKickHitboxRyu = new Rectangle(-1000, -1000, 90, 80);
            forwardMediumKickHitboxRyu = new Rectangle(-1000, -1000, 50, 150);
            forwardHighKickHitboxRyu = new Rectangle(-1000, -200, 110, 160);
            hadoukenHitboxRyu = new Rectangle(-1000, -1000, 80, 100);
            tatsumakiHitboxRyu = new Rectangle(-1000, -1000, 200, 40);
            shoryukenHitboxRyu = new Rectangle(-1000, -1000, 100, 200);


            kenHealthBar = new Rectangle(20, 50, 200, 30);
            ryuHealthBar = new Rectangle(480, 50, 200, 30);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("street_fighter_background");

            kenAttackSound = Content.Load<SoundEffect>("character_sounds/ken_attack");
            kenHadoukenSound = Content.Load<SoundEffect>("character_sounds/ken_hadouken");
            kenShoryukenSound = Content.Load<SoundEffect>("character_sounds/ken_shoryuken");
            kenTatsumakiSound = Content.Load<SoundEffect>("character_sounds/ken_tatsumaki");
            kenDeathSound = Content.Load<SoundEffect>("character_sounds/ken_death");

            ryuAttackSound = Content.Load<SoundEffect>("character_sounds/ryu_attack");
            ryuHadoukenSound = Content.Load<SoundEffect>("character_sounds/ryu_hadouken");
            ryuShoryukenSound = Content.Load<SoundEffect>("character_sounds/ryu_shoryuken");
            ryuTatsumakiSound = Content.Load<SoundEffect>("character_sounds/ryu_tatsumaki");
            ryuDeathSound = Content.Load<SoundEffect>("character_sounds/ryu_death");

            hitSmallSound = Content.Load<SoundEffect>("hit_sounds/hit_small");
            hitMediumSound = Content.Load<SoundEffect>("hit_sounds/hit_medium");
            hitHighSound = Content.Load<SoundEffect>("hit_sounds/hit_high");
            blockSound = Content.Load<SoundEffect>("hit_sounds/block");

            narratorWin = Content.Load<SoundEffect>("narrator_sounds/you_win");

            for (int i = 0; i < kenIdlePics.Length; i++) kenIdlePics[i] = Content.Load<Texture2D>("ken_idle" + (i + 1));
            for (int i = 0; i < kenWalkingPics.Length; i++) kenWalkingPics[i] = Content.Load<Texture2D>("ken_walking" + (i + 1));
            for (int i = 0; i < kenJumpingPics.Length; i++) kenJumpingPics[i] = Content.Load<Texture2D>("ken_jumping" + (i + 1));
            kenCrouchPic = Content.Load<Texture2D>("ken_crouch");
            for (int i = 0; i < kenForwardJumpingPics.Length; i++) kenForwardJumpingPics[i] = Content.Load<Texture2D>("ken_forwardjump" + (i + 1));

            for (int i = 0; i < kenLowPunchPics.Length; i++) kenLowPunchPics[i] = Content.Load<Texture2D>("ken_low_punch" + (i + 1));
            for (int i = 0; i < kenMediumHighPunchPics.Length; i++) kenMediumHighPunchPics[i] = Content.Load<Texture2D>("ken_medium_high_punch" + (i + 1));
            
            for (int i = 0; i < kenLowMediumCrouchPunchPics.Length; i++) kenLowMediumCrouchPunchPics[i] = Content.Load<Texture2D>("ken_crouch_low_medium_punch" + (i + 1));
            for (int i = 0; i < kenHighCrouchPunchPics.Length; i++) kenHighCrouchPunchPics[i] = Content.Load<Texture2D>("ken_crouch_high_punch" + (i + 1));

            for (int i = 0; i < kenForwardLowPunchPics.Length; i++) kenForwardLowPunchPics[i] = Content.Load<Texture2D>("ken_forward_low_punch" + (i + 1));
            for (int i = 0; i < kenForwardMediumPunchPics.Length; i++) kenForwardMediumPunchPics[i] = Content.Load<Texture2D>("ken_forward_medium_punch" + (i + 1));
            for (int i = 0; i < kenForwardHighPunchPics.Length; i++) kenForwardHighPunchPics[i] = Content.Load<Texture2D>("ken_forward_high_punch" + (i + 1));

            for (int i = 0; i < kenLowMediumKickPics.Length; i++) kenLowMediumKickPics[i] = Content.Load<Texture2D>("ken_low_medium_kick" + (i + 1));
            for (int i = 0; i < kenHighKickPics.Length; i++) kenHighKickPics[i] = Content.Load<Texture2D>("ken_high_kick" + (i + 1));
            
            for (int i = 0; i < kenLowCrouchKickPics.Length; i++) kenLowCrouchKickPics[i] = Content.Load<Texture2D>("ken_crouch_low_kick" + (i + 1));
            for (int i = 0; i < kenMediumCrouchKickPics.Length; i++) kenMediumCrouchKickPics[i] = Content.Load<Texture2D>("ken_crouch_medium_kick" + (i + 1));
            for (int i = 0; i < kenHighCrouchKickPics.Length; i++) kenHighCrouchKickPics[i] = Content.Load<Texture2D>("ken_crouch_high_kick" + (i + 1));

            for (int i = 0; i < kenForwardLowKickPics.Length; i++) kenForwardLowKickPics[i] = Content.Load<Texture2D>("ken_forward_low_kick" + (i + 1));
            for (int i = 0; i < kenForwardMediumKickPics.Length; i++) kenForwardMediumKickPics[i] = Content.Load<Texture2D>("ken_forward_medium_kick" + (i + 1));
            for (int i = 0; i < kenForwardHighKickPics.Length; i++) kenForwardHighKickPics[i] = Content.Load<Texture2D>("ken_forward_high_kick" + (i + 1));

            for (int i = 0; i < kenHadoukenPics.Length; i++) kenHadoukenPics[i] = Content.Load<Texture2D>("ken_hadouken" + (i + 1));
            for (int i = 0; i < kenHadoukenProjectilePics.Length; i++) kenHadoukenProjectilePics[i] = Content.Load<Texture2D>("ken_projectile_hadouken" + (i + 1));
            for (int i = 0; i < kenTatsumakiPics.Length; i++) kenTatsumakiPics[i] = Content.Load<Texture2D>("ken_tatsumaki" + (i + 1));
            for (int i = 0; i < kenShoryukenPics.Length; i++) kenShoryukenPics[i] = Content.Load<Texture2D>("ken_shoryuken" + (i + 1));

            for (int i = 0; i < kenHitPics.Length; i++) kenHitPics[i] = Content.Load<Texture2D>("ken_hit" + (i + 1));
            for (int i = 0; i < kenFaceHitPics.Length; i++) kenFaceHitPics[i] = Content.Load<Texture2D>("ken_face_hit" + (i + 1));
            kenCrouchHitPic = Content.Load<Texture2D>("ken_crouch_hit");
            for (int i = 0; i < kenKnockdownPics.Length; i++) kenKnockdownPics[i] = Content.Load<Texture2D>("ken_knockdown" + (i + 1));
            for (int i = 0; i < kenKnockoutPics.Length; i++) kenKnockoutPics[i] = Content.Load<Texture2D>("ken_knockout" + (i + 1));
            for (int i = 0; i < kenVictoryPics.Length; i++) kenVictoryPics[i] = Content.Load<Texture2D>("ken_victory" + (i + 1));


            for (int i = 0; i < ryuIdlePics.Length; i++) ryuIdlePics[i] = Content.Load<Texture2D>("ryu_idle" + (i + 1));
            for (int i = 0; i < ryuWalkingPics.Length; i++) ryuWalkingPics[i] = Content.Load<Texture2D>("ryu_walking" + (i + 1));
            for (int i = 0; i < ryuJumpingPics.Length; i++) ryuJumpingPics[i] = Content.Load<Texture2D>("ryu_jumping" + (i + 1));
            ryuCrouchPic = Content.Load<Texture2D>("ryu_crouch");
            for (int i = 0; i < ryuForwardJumpingPics.Length; i++) ryuForwardJumpingPics[i] = Content.Load<Texture2D>("ryu_forward_jump" + (i + 1));

            for (int i = 0; i < ryuLowPunchPics.Length; i++) ryuLowPunchPics[i] = Content.Load<Texture2D>("ryu_low_punch" + (i + 1));
            for (int i = 0; i < ryuMediumHighPunchPics.Length; i++) ryuMediumHighPunchPics[i] = Content.Load<Texture2D>("ryu_medium_high_punch" + (i + 1));

            for (int i = 0; i < ryuLowMediumCrouchPunchPics.Length; i++) ryuLowMediumCrouchPunchPics[i] = Content.Load<Texture2D>("ryu_crouch_low_medium_punch" + (i + 1));
            for (int i = 0; i < ryuHighCrouchPunchPics.Length; i++) ryuHighCrouchPunchPics[i] = Content.Load<Texture2D>("ryu_crouch_high_punch" + (i + 1));

            for (int i = 0; i < ryuForwardLowPunchPics.Length; i++) ryuForwardLowPunchPics[i] = Content.Load<Texture2D>("ryu_forward_low_punch" + (i + 1));
            for (int i = 0; i < ryuForwardMediumPunchPics.Length; i++) ryuForwardMediumPunchPics[i] = Content.Load<Texture2D>("ryu_forward_medium_punch" + (i + 1));
            for (int i = 0; i < ryuForwardHighPunchPics.Length; i++) ryuForwardHighPunchPics[i] = Content.Load<Texture2D>("ryu_forward_high_punch" + (i + 1));

            for (int i = 0; i < ryuLowMediumKickPics.Length; i++) ryuLowMediumKickPics[i] = Content.Load<Texture2D>("ryu_low_medium_kick" + (i + 1));
            for (int i = 0; i < ryuHighKickPics.Length; i++) ryuHighKickPics[i] = Content.Load<Texture2D>("ryu_high_kick" + (i + 1));

            for (int i = 0; i < ryuLowCrouchKickPics.Length; i++) ryuLowCrouchKickPics[i] = Content.Load<Texture2D>("ryu_crouch_low_kick" + (i + 1));
            for (int i = 0; i < ryuMediumCrouchKickPics.Length; i++) ryuMediumCrouchKickPics[i] = Content.Load<Texture2D>("ryu_crouch_medium_kick" + (i + 1));
            for (int i = 0; i < ryuHighCrouchKickPics.Length; i++) ryuHighCrouchKickPics[i] = Content.Load<Texture2D>("ryu_crouch_high_kick" + (i + 1));

            for (int i = 0; i < ryuForwardLowKickPics.Length; i++) ryuForwardLowKickPics[i] = Content.Load<Texture2D>("ryu_forward_low_kick" + (i + 1));
            for (int i = 0; i < ryuForwardMediumKickPics.Length; i++) ryuForwardMediumKickPics[i] = Content.Load<Texture2D>("ryu_forward_medium_kick" + (i + 1));
            for (int i = 0; i < ryuForwardHighKickPics.Length; i++) ryuForwardHighKickPics[i] = Content.Load<Texture2D>("ryu_forward_high_kick" + (i + 1));

            for (int i = 0; i < ryuHadoukenPics.Length; i++) ryuHadoukenPics[i] = Content.Load<Texture2D>("ryu_hadouken" + (i + 1));
            for (int i = 0; i < ryuHadoukenProjectilePics.Length; i++) ryuHadoukenProjectilePics[i] = Content.Load<Texture2D>("hadouken_projectile" + (i + 1));
            for (int i = 0; i < ryuTatsumakiPics.Length; i++) ryuTatsumakiPics[i] = Content.Load<Texture2D>("ryu_tatsumaki" + (i + 1));
            for (int i = 0; i < ryuShoryukenPics.Length; i++) ryuShoryukenPics[i] = Content.Load<Texture2D>("ryu_shoryuken" + (i + 1));

            for (int i = 0; i < ryuHitPics.Length; i++) ryuHitPics[i] = Content.Load<Texture2D>("ryu_hit" + (i + 1));
            for (int i = 0; i < ryuFaceHitPics.Length; i++) ryuFaceHitPics[i] = Content.Load<Texture2D>("ryu_face_hit" + (i + 1));
            ryuCrouchHitPic = Content.Load<Texture2D>("ryu_crouch_hit");
            for (int i = 0; i < ryuKnockdownPics.Length; i++) ryuKnockdownPics[i] = Content.Load<Texture2D>("ryu_knockdown" + (i + 1));
            for (int i = 0; i < ryuKnockoutPics.Length; i++) ryuKnockoutPics[i] = Content.Load<Texture2D>("ryu_knockout" + (i + 1));
            for (int i = 0; i < ryuVictoryPics.Length; i++) ryuVictoryPics[i] = Content.Load<Texture2D>("ryu_victory" + (i + 1));

            kenBlockPic = Content.Load<Texture2D>("ken_block_standing");
            kenBlockCrouchPic = Content.Load<Texture2D>("ken_block_crouching");
            ryuBlockPic = Content.Load<Texture2D>("ryu_block_standing");
            ryuBlockCrouchPic = Content.Load<Texture2D>("ryu_block_crouching");

            hitboxMovementPic = Content.Load<Texture2D>("hitbox");
            hitboxAttackPic = Content.Load<Texture2D>("attack_hitbox");

            healthBar[0] = Content.Load<Texture2D>("health_bar_healthy");
            healthBar[1] = Content.Load<Texture2D>("health_bar_warning");
            healthBar[2] = Content.Load<Texture2D>("health_bar_danger");

            titleFont = Content.Load<SpriteFont>("TitleFont");
            textFont = Content.Load<SpriteFont>("TextFont");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            pad1 = GamePad.GetState(PlayerIndex.One);
            pad2 = GamePad.GetState(PlayerIndex.Two);
            KeyboardState kb = Keyboard.GetState();

            if (kenHitboxMovementRect.X < ryuHitboxMovementRect.X) {
                kenFacingRight = true;
            } else {
                kenFacingRight = false;
            }

            checkKenState();
            checkRyuState();

            if (kenActionIsNotRunning) clearKenHitBoxes();

            if (ryuActionIsNotRunning) clearRyuHitBoxes();

            if (kenAfterActionCount < afterActionPause) kenActionsPaused = true;
            else kenActionsPaused = false;

            if (ryuAfterActionCount < afterActionPause) ryuActionsPaused = true;
            else ryuActionsPaused = false;

            if (kenFacingRight && !endGame) {

                //detects hadouken combo in a time limit for ken facing right and ryu facing left
                if (kenHadoukenComboStage1 && kenHadoukenCounter <= comboTimeLimit) {
                    kenHadoukenCounter++;

                    if (kb.IsKeyDown(Keys.D) || pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed) kenHadoukenComboStage2 = true;

                    if (((kb.IsKeyDown(Keys.R) || kb.IsKeyDown(Keys.T) || kb.IsKeyDown(Keys.Y)) || (pad1.Buttons.X == ButtonState.Pressed || pad1.Buttons.Y == ButtonState.Pressed || pad1.Buttons.RightShoulder == ButtonState.Pressed)) && kenHadoukenComboStage2 && kenActionIsNotRunning) {

                        ken = KenState.Hadouken;
                        kenCrouching = false;

                        kenInputHadoukenRectX = kenRect.X + 230;
                        kenInputHadoukenRectY = kenRect.Y + 190;

                        kenHadoukenRect.X = kenInputHadoukenRectX;
                        kenHadoukenRect.Y = kenInputHadoukenRectY;

                        kenHadoukenComboStage1 = false;
                        kenHadoukenComboStage2 = false;

                        clearKenHitBoxes();

                        kenHadoukenState = 0;

                        if (!kenShoryukenComboStage3)
                            kenHadoukenSound.Play();

                    }

                    if (kenHadoukenCounter == comboTimeLimit) {
                        kenHadoukenComboStage1 = false;
                        kenHadoukenComboStage2 = false;
                    }

                }

                if (ryuHadoukenComboStage1 && ryuHadoukenCounter <= comboTimeLimit) {
                    ryuHadoukenCounter++;

                    if (kb.IsKeyDown(Keys.Left) || pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed) ryuHadoukenComboStage2 = true;

                    if (((kb.IsKeyDown(Keys.I) || kb.IsKeyDown(Keys.O) || kb.IsKeyDown(Keys.P)) || (pad2.Buttons.X == ButtonState.Pressed || pad2.Buttons.Y == ButtonState.Pressed || pad2.Buttons.RightShoulder == ButtonState.Pressed)) && ryuHadoukenComboStage2 && ryuActionIsNotRunning) {

                        ryu = RyuState.HadoukenReverse;
                        ryuCrouching = false;

                        ryuInputHadoukenRectX = ryuRect.X + 70;
                        ryuInputHadoukenRectY = ryuRect.Y + 190;

                        ryuHadoukenRect.X = ryuInputHadoukenRectX;
                        ryuHadoukenRect.Y = ryuInputHadoukenRectY;

                        clearRyuHitBoxes();

                        ryuHadoukenComboStage1 = false;
                        ryuHadoukenComboStage2 = false;

                        ryuHadoukenState = 0;

                        if (!ryuShoryukenComboStage3)
                            ryuHadoukenSound.Play();

                    }

                    if (ryuHadoukenCounter == comboTimeLimit) {
                        ryuHadoukenComboStage1 = false;
                        ryuHadoukenComboStage2 = false;
                    }

                }

                //detects tatsumaki combo in a time limit for ken facing right and ryu facing left
                if (kenTatsumakiComboStage1 && kenTatsumakiCounter <= comboTimeLimit) {
                    kenTatsumakiCounter++;

                    if (kb.IsKeyDown(Keys.A) || pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed) kenTatsumakiComboStage2 = true;

                    if (((kb.IsKeyDown(Keys.F) || kb.IsKeyDown(Keys.G) || kb.IsKeyDown(Keys.H)) || (pad1.Buttons.A == ButtonState.Pressed || pad1.Buttons.B == ButtonState.Pressed || pad1.Triggers.Right == 1)) && kenTatsumakiComboStage2 && kenActionIsNotRunning) {

                        ken = KenState.Tatsumaki;
                        kenCrouching = false;

                        clearKenHitBoxes();

                        kenTatsumakiComboStage1 = false;
                        kenTatsumakiComboStage2 = false;

                        kenTatsumakiSound.Play();

                    }

                    if (kenTatsumakiCounter == comboTimeLimit) {
                        kenTatsumakiComboStage1 = false;
                        kenTatsumakiComboStage2 = false;
                    }

                }

                if (ryuTatsumakiComboStage1 && ryuTatsumakiCounter <= comboTimeLimit) {
                    ryuTatsumakiCounter++;

                    if (kb.IsKeyDown(Keys.Right) || pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed) ryuTatsumakiComboStage2 = true;

                    if (((kb.IsKeyDown(Keys.K) || kb.IsKeyDown(Keys.L) || kb.IsKeyDown(Keys.OemSemicolon)) || (pad2.Buttons.A == ButtonState.Pressed || pad2.Buttons.B == ButtonState.Pressed || pad2.Triggers.Right == 1)) && ryuTatsumakiComboStage2 && ryuActionIsNotRunning) {

                        ryu = RyuState.TatsumakiReverse;
                        ryuCrouching = false;

                        clearRyuHitBoxes();

                        ryuTatsumakiComboStage1 = false;
                        ryuTatsumakiComboStage2 = false;

                        ryuTatsumakiSound.Play();

                    }

                    if (ryuTatsumakiCounter == comboTimeLimit) {
                        ryuTatsumakiComboStage1 = false;
                        ryuTatsumakiComboStage2 = false;
                    }

                }

                //detects shoryuken combo in a time limit for ken facing right and ryu facing left
                if (kenShoryukenComboStage1 && kenShoryukenCounter <= comboTimeLimit) {
                    kenShoryukenCounter++;

                    if (kb.IsKeyDown(Keys.S) || pad1.ThumbSticks.Left.Y == -1 || pad1.DPad.Down == ButtonState.Pressed) kenShoryukenComboStage2 = true;

                    if ((kb.IsKeyDown(Keys.D) || pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed) && kenShoryukenComboStage2) kenShoryukenComboStage3 = true;

                    if (((kb.IsKeyDown(Keys.R) || kb.IsKeyDown(Keys.T) || kb.IsKeyDown(Keys.Y)) || (pad1.Buttons.X == ButtonState.Pressed || pad1.Buttons.Y == ButtonState.Pressed || pad1.Buttons.RightShoulder == ButtonState.Pressed)) && kenShoryukenComboStage3 && kenActionIsNotRunning) {

                        ken = KenState.Shoryuken;
                        kenCrouching = false;

                        clearKenHitBoxes();

                        kenShoryukenComboStage1 = false;
                        kenShoryukenComboStage2 = false;
                        kenShoryukenComboStage3 = false;

                        kenShoryukenSound.Play();

                    }

                    if (kenShoryukenCounter == comboTimeLimit) {
                        kenShoryukenComboStage1 = false;
                        kenShoryukenComboStage2 = false;
                        kenShoryukenComboStage3 = false;
                    }

                }

                if (ryuShoryukenComboStage1 && ryuShoryukenCounter <= comboTimeLimit) {
                    ryuShoryukenCounter++;

                    if (kb.IsKeyDown(Keys.Down) || pad2.ThumbSticks.Left.Y == -1 || pad2.DPad.Down == ButtonState.Pressed) ryuShoryukenComboStage2 = true;

                    if ((kb.IsKeyDown(Keys.Left) || pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed) && ryuShoryukenComboStage2) ryuShoryukenComboStage3 = true;

                    if (((kb.IsKeyDown(Keys.I) || kb.IsKeyDown(Keys.O) || kb.IsKeyDown(Keys.P)) || (pad2.Buttons.X == ButtonState.Pressed || pad2.Buttons.Y == ButtonState.Pressed || pad2.Buttons.RightShoulder == ButtonState.Pressed)) && ryuShoryukenComboStage3 && ryuActionIsNotRunning) {

                        ryu = RyuState.ShoryukenReverse;
                        ryuCrouching = false;

                        clearRyuHitBoxes();

                        ryuShoryukenComboStage1 = false;
                        ryuShoryukenComboStage2 = false;
                        ryuShoryukenComboStage3 = false;

                        ryuShoryukenSound.Play();

                    }

                    if (ryuShoryukenCounter == comboTimeLimit) {
                        ryuShoryukenComboStage1 = false;
                        ryuShoryukenComboStage2 = false;
                        ryuShoryukenComboStage3 = false;
                    }

                }



                checkKenState();
                checkRyuState();

                //Input controls to set the state of ken facing right
                if (((kb.IsKeyDown(Keys.D) && kb.IsKeyDown(Keys.F)) || ((pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed) && pad1.Buttons.A == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.ForwardLowKick;

                    forwardLowKickHitboxKen.X = kenRect.X + forwardLowKickX;
                    forwardLowKickHitboxKen.Y = kenRect.Y + forwardLowKickY;

                    kenForwardLowKickState = 0;

                    kenAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.D) && kb.IsKeyDown(Keys.G)) || ((pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed) && pad1.Buttons.B == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.ForwardMediumKick;

                    forwardMediumKickHitboxKen.X = kenRect.X + forwardMediumKickX;
                    forwardMediumKickHitboxKen.Y = kenRect.Y + forwardMediumKickY;

                    kenForwardMediumKickState = 0;

                    kenAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.D) && kb.IsKeyDown(Keys.H)) || ((pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed) && pad1.Triggers.Right == 1)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.ForwardHighKick;

                    forwardHighKickHitboxKen.X = kenRect.X + forwardHighKickX;
                    forwardHighKickHitboxKen.Y = kenRect.Y + forwardHighKickY;

                    kenForwardHighKickState = 0;

                    kenAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.D) && kb.IsKeyDown(Keys.R)) || ((pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed) && pad1.Buttons.X == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.ForwardLowPunch;

                    forwardLowPunchHitboxKen.X = kenRect.X + forwardLowPunchX;
                    forwardLowPunchHitboxKen.Y = kenRect.Y + forwardLowPunchY;

                    kenForwardLowPunchState = 0;

                    kenAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.D) && kb.IsKeyDown(Keys.T)) || ((pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed) && pad1.Buttons.Y == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.ForwardMediumPunch;

                    forwardMediumPunchHitboxKen.X = kenRect.X + forwardMediumPunchX;
                    forwardMediumPunchHitboxKen.Y = kenRect.Y + forwardMediumPunchY;

                    kenForwardMediumPunchState = 0;

                    kenAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.D) && kb.IsKeyDown(Keys.Y)) || ((pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed) && pad1.Buttons.RightShoulder == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.ForwardHighPunch;

                    forwardHighPunchHitboxKen.X = kenRect.X + forwardHighPunchX;
                    forwardHighPunchHitboxKen.Y = kenRect.Y + forwardHighPunchY;

                    kenForwardHighPunchState = 0;

                    kenAttackSound.Play();

                } else if ((kb.IsKeyDown(Keys.F) || pad1.Buttons.A == ButtonState.Pressed) && kenActionIsNotRunning && !kenActionsPaused) {

                    if (ken == KenState.Crouching) {

                        ken = KenState.LowCrouchKick;
                        crouchLowKickHitboxKen.X = kenRect.X + crouchLowKickX;
                        crouchLowKickHitboxKen.Y = kenRect.Y + crouchLowKickY;

                    } else {

                        ken = KenState.LowKick;
                        lowKickHitboxKen.X = kenRect.X + lowKickX;
                        lowKickHitboxKen.Y = kenRect.Y + lowKickY;

                    }

                    kenAttackSound.Play();
                    kenLowKickState = 0;
                    kenLowCrouchKickState = 0;

                } else if ((kb.IsKeyDown(Keys.G) || pad1.Buttons.B == ButtonState.Pressed) && kenActionIsNotRunning && !kenActionsPaused) {

                    if (ken == KenState.Crouching) {

                        ken = KenState.MediumCrouchKick;
                        crouchMediumKickHitboxKen.X = kenRect.X + crouchMediumKickX;
                        crouchMediumKickHitboxKen.Y = kenRect.Y + crouchMediumKickY;

                    } else {

                        ken = KenState.MediumKick;
                        mediumKickHitboxKen.X = kenRect.X + mediumKickX;
                        mediumKickHitboxKen.Y = kenRect.Y + mediumKickY;

                    }

                    kenAttackSound.Play();
                    kenMediumKickState = 0;
                    kenMediumCrouchKickState = 0;

                } else if ((kb.IsKeyDown(Keys.H) || pad1.Triggers.Right == 1) && kenActionIsNotRunning && !kenActionsPaused) {

                    if (ken == KenState.Crouching) {

                        ken = KenState.HighCrouchKick;
                        crouchHighKickHitboxKen.X = kenRect.X + crouchHighKickX;
                        crouchHighKickHitboxKen.Y = kenRect.Y + crouchHighKickY;

                    } else {

                        ken = KenState.HighKick;
                        highKickHitboxKen.X = kenRect.X + highKickX;
                        highKickHitboxKen.Y = kenRect.Y + highKickY;

                    }

                    kenAttackSound.Play();
                    kenHighKickState = 0;
                    kenHighCrouchKickState = 0;

                } else if ((kb.IsKeyDown(Keys.Y) || pad1.Buttons.RightShoulder == ButtonState.Pressed) && kenActionIsNotRunning && !kenActionsPaused) {

                    if (ken == KenState.Crouching) {

                        ken = KenState.HighPunchCrouch;
                        crouchHighPunchHitboxKen.X = kenRect.X + crouchHighPunchX;
                        crouchHighPunchHitboxKen.Y = kenRect.Y + crouchHighPunchY;

                    } else {

                        ken = KenState.HighPunch;
                        highPunchHitboxKen.X = kenRect.X + highPunchX;
                        highPunchHitboxKen.Y = kenRect.Y + highPunchY;

                    }

                    kenAttackSound.Play();
                    kenHighPunchState = 0;
                    kenHighPunchCrouchState = 0;

                } else if ((kb.IsKeyDown(Keys.T) || pad1.Buttons.Y == ButtonState.Pressed) && kenActionIsNotRunning && !kenActionsPaused) {

                    if (ken == KenState.Crouching) {

                        ken = KenState.MediumPunchCrouch;
                        crouchMediumPunchHitboxKen.X = kenRect.X + crouchMediumPunchX;
                        crouchMediumPunchHitboxKen.Y = kenRect.Y + crouchMediumPunchY;

                    } else {

                        ken = KenState.MediumPunch;
                        mediumPunchHitboxKen.X = kenRect.X + mediumPunchX;
                        mediumPunchHitboxKen.Y = kenRect.Y + mediumPunchY;

                    }

                    kenAttackSound.Play();
                    kenMediumPunchState = 0;
                    kenMediumPunchCrouchState = 0;

                } else if ((kb.IsKeyDown(Keys.R) || pad1.Buttons.X == ButtonState.Pressed) && kenActionIsNotRunning && !kenActionsPaused) {

                    if (ken == KenState.Crouching) {

                        ken = KenState.LowPunchCrouch;
                        crouchLowPunchHitboxKen.X = kenRect.X + crouchLowPunchX;
                        crouchLowPunchHitboxKen.Y = kenRect.Y + crouchLowPunchY;

                    } else {

                        ken = KenState.LowPunch;
                        lowPunchHitboxKen.X = kenRect.X + lowPunchX;
                        lowPunchHitboxKen.Y = kenRect.Y + lowPunchY;

                    }

                    kenAttackSound.Play();
                    kenLowPunchState = 0;
                    kenLowPunchCrouchState = 0;

                } else if (((kb.IsKeyDown(Keys.W) && kb.IsKeyDown(Keys.D)) || (pad1.ThumbSticks.Left.Y > 0 && pad1.ThumbSticks.Left.X > 0) || (pad1.DPad.Up == ButtonState.Pressed && pad1.DPad.Right == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.ForwardJumping;
                    kenForwardJumpState = 0;

                } else if (((kb.IsKeyDown(Keys.W) && kb.IsKeyDown(Keys.A) || (pad1.ThumbSticks.Left.Y > 0 && pad1.ThumbSticks.Left.X < 0) || (pad1.DPad.Up == ButtonState.Pressed && pad1.DPad.Left == ButtonState.Pressed))) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.BackwardJumping;
                    kenBackwardJumpState = 5;

                } else if ((kb.IsKeyDown(Keys.S) || (pad1.ThumbSticks.Left.Y == -1) || (pad1.DPad.Down == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.Crouching;
                    kenCrouching = true;

                    kenHadoukenCounter = 0;
                    kenHadoukenComboStage1 = true;

                    kenTatsumakiCounter = 0;
                    kenTatsumakiComboStage1 = true;

                } else if ((kb.IsKeyDown(Keys.A) || (pad1.ThumbSticks.Left.X == -1) || (pad1.DPad.Left == ButtonState.Pressed)) && kenActionIsNotRunning) {

                    ken = KenState.WalkingBackward;
                    kenCrouching = false;

                } else if ((kb.IsKeyDown(Keys.D) || (pad1.ThumbSticks.Left.X == 1) || (pad1.DPad.Right == ButtonState.Pressed)) && kenActionIsNotRunning) {

                    ken = KenState.WalkingForward;
                    kenCrouching = false;

                    if (!kenShoryukenComboStage1) kenShoryukenCounter = 0;
                    kenShoryukenComboStage1 = true;

                } else if ((kb.IsKeyDown(Keys.W) || (pad1.ThumbSticks.Left.Y == 1) || (pad1.DPad.Up == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.Jumping;
                    kenJumpState = 0;

                } else if (kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.Idle;
                    kenCrouching = false;

                }


                //Input controls to set the state of ryu facing left
                if (((kb.IsKeyDown(Keys.Left) && kb.IsKeyDown(Keys.K)) || ((pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed) && pad2.Buttons.A == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.ForwardLowKickReverse;

                    forwardLowKickHitboxRyu.X = ryuRect.X + forwardLowKickReverseX;
                    forwardLowKickHitboxRyu.Y = ryuRect.Y + forwardLowKickReverseY;

                    ryuForwardLowKickState = 0;

                    ryuAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.Left) && kb.IsKeyDown(Keys.L)) || ((pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed) && pad2.Buttons.B == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.ForwardMediumKickReverse;

                    forwardMediumKickHitboxRyu.X = ryuRect.X + forwardMediumKickReverseX;
                    forwardMediumKickHitboxRyu.Y = ryuRect.Y + forwardMediumKickReverseY;

                    ryuForwardMediumKickState = 0;

                    ryuAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.Left) && kb.IsKeyDown(Keys.OemSemicolon)) || ((pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed) && pad2.Triggers.Right == 1)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.ForwardHighKickReverse;

                    forwardHighKickHitboxRyu.X = ryuRect.X + forwardHighKickReverseX;
                    forwardHighKickHitboxRyu.Y = ryuRect.Y + forwardHighKickReverseY;

                    ryuForwardHighKickState = 0;

                    ryuAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.Left) && kb.IsKeyDown(Keys.I)) || ((pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed) && pad2.Buttons.X == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.ForwardLowPunchReverse;

                    forwardLowPunchHitboxRyu.X = ryuRect.X + forwardLowPunchReverseX;
                    forwardLowPunchHitboxRyu.Y = ryuRect.Y + forwardLowPunchReverseY;

                    ryuForwardLowPunchState = 0;

                    ryuAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.Left) && kb.IsKeyDown(Keys.O)) || ((pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed) && pad2.Buttons.Y == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.ForwardMediumPunchReverse;

                    forwardMediumPunchHitboxRyu.X = ryuRect.X + forwardMediumPunchReverseX;
                    forwardMediumPunchHitboxRyu.Y = ryuRect.Y + forwardMediumPunchReverseY;

                    ryuForwardMediumPunchState = 0;

                    ryuAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.Left) && kb.IsKeyDown(Keys.P)) || ((pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed) && pad2.Buttons.RightShoulder == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.ForwardHighPunchReverse;

                    forwardHighPunchHitboxRyu.X = ryuRect.X + forwardHighPunchReverseX;
                    forwardHighPunchHitboxRyu.Y = ryuRect.Y + forwardHighPunchReverseY;

                    ryuForwardHighPunchState = 0;

                    ryuAttackSound.Play();

                } else if ((kb.IsKeyDown(Keys.K) || pad2.Buttons.A == ButtonState.Pressed) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    if (ryu == RyuState.CrouchingReverse) {

                        ryu = RyuState.LowCrouchKickReverse;

                        crouchLowKickHitboxRyu.X = ryuRect.X + crouchLowKickReverseX;
                        crouchLowKickHitboxRyu.Y = ryuRect.Y + crouchLowKickReverseY;

                    } else {

                        ryu = RyuState.LowKickReverse;

                        lowKickHitboxRyu.X = ryuRect.X + lowKickReverseX;
                        lowKickHitboxRyu.Y = ryuRect.Y + lowKickReverseY;

                    }

                    ryuAttackSound.Play();
                    ryuLowKickState = 0;
                    ryuLowCrouchKickState = 0;

                } else if ((kb.IsKeyDown(Keys.L) || pad2.Buttons.B == ButtonState.Pressed) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    if (ryu == RyuState.CrouchingReverse) {

                        ryu = RyuState.MediumCrouchKickReverse;

                        crouchMediumKickHitboxRyu.X = ryuRect.X + crouchMediumKickReverseX;
                        crouchMediumKickHitboxRyu.Y = ryuRect.Y + crouchMediumKickReverseY;

                    } else {

                        ryu = RyuState.MediumKickReverse;

                        mediumKickHitboxRyu.X = ryuRect.X + mediumKickReverseX;
                        mediumKickHitboxRyu.Y = ryuRect.Y + mediumKickReverseY;

                    }

                    ryuAttackSound.Play();
                    ryuMediumKickState = 0;
                    ryuMediumCrouchKickState = 0;

                } else if ((kb.IsKeyDown(Keys.OemSemicolon) || pad2.Triggers.Right == 1) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    if (ryu == RyuState.CrouchingReverse) {

                        ryu = RyuState.HighCrouchKickReverse;

                        crouchHighKickHitboxRyu.X = ryuRect.X + crouchHighKickReverseX;
                        crouchHighKickHitboxRyu.Y = ryuRect.Y + crouchHighKickReverseY;

                    } else {

                        ryu = RyuState.HighKickReverse;

                        highKickHitboxRyu.X = ryuRect.X + highKickReverseX;
                        highKickHitboxRyu.Y = ryuRect.Y + highKickReverseY;

                    }

                    ryuAttackSound.Play();
                    ryuHighKickState = 0;
                    ryuHighCrouchKickState = 0;

                } else if ((kb.IsKeyDown(Keys.P) || pad2.Buttons.RightShoulder == ButtonState.Pressed) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    if (ryu == RyuState.CrouchingReverse) {

                        ryu = RyuState.HighPunchCrouchReverse;

                        crouchHighPunchHitboxRyu.X = ryuRect.X + crouchHighPunchReverseX;
                        crouchHighPunchHitboxRyu.Y = ryuRect.Y + crouchHighPunchReverseY;

                    } else {

                        ryu = RyuState.HighPunchReverse;

                        highPunchHitboxRyu.X = ryuRect.X + highPunchReverseX;
                        highPunchHitboxRyu.Y = ryuRect.Y + highPunchReverseY;

                    }

                    ryuAttackSound.Play();
                    ryuHighPunchState = 0;
                    ryuHighPunchCrouchState = 0;

                } else if ((kb.IsKeyDown(Keys.O) || pad2.Buttons.Y == ButtonState.Pressed) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    if (ryu == RyuState.CrouchingReverse) {

                        ryu = RyuState.MediumPunchCrouchReverse;

                        crouchMediumPunchHitboxRyu.X = ryuRect.X + crouchMediumPunchReverseX;
                        crouchMediumPunchHitboxRyu.Y = ryuRect.Y + crouchMediumPunchReverseY;

                    } else {

                        ryu = RyuState.MediumPunchReverse;

                        mediumPunchHitboxRyu.X = ryuRect.X + mediumPunchReverseX;
                        mediumPunchHitboxRyu.Y = ryuRect.Y + mediumPunchReverseY;

                    }

                    ryuAttackSound.Play();
                    ryuMediumPunchState = 0;
                    ryuMediumPunchCrouchState = 0;

                } else if ((kb.IsKeyDown(Keys.I) || pad2.Buttons.X == ButtonState.Pressed) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    if (ryu == RyuState.CrouchingReverse) {

                        ryu = RyuState.LowPunchCrouchReverse;

                        crouchLowPunchHitboxRyu.X = ryuRect.X + crouchLowPunchReverseX;
                        crouchLowPunchHitboxRyu.Y = ryuRect.Y + crouchLowPunchReverseY;

                    } else {

                        ryu = RyuState.LowPunchReverse;

                        lowPunchHitboxRyu.X = ryuRect.X + lowPunchReverseX;
                        lowPunchHitboxRyu.Y = ryuRect.Y + lowPunchReverseY;

                    }

                    ryuAttackSound.Play();
                    ryuLowPunchState = 0;
                    ryuLowPunchCrouchState = 0;

                } else if (((kb.IsKeyDown(Keys.Up) && kb.IsKeyDown(Keys.Left)) || (pad2.ThumbSticks.Left.Y > 0 && pad2.ThumbSticks.Left.X < 0) || (pad2.DPad.Up == ButtonState.Pressed && pad2.DPad.Left == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.ForwardJumpingReverse;
                    ryuForwardJumpState = 0;

                } else if (((kb.IsKeyDown(Keys.Up) && kb.IsKeyDown(Keys.Right)) || (pad2.ThumbSticks.Left.Y > 0 && pad2.ThumbSticks.Left.X > 0) || (pad2.DPad.Up == ButtonState.Pressed && pad2.DPad.Right == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.BackwardJumpingReverse;
                    ryuBackwardJumpState = 5;

                } else if (((kb.IsKeyDown(Keys.Down) || (pad2.ThumbSticks.Left.Y == -1) || (pad2.DPad.Down == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused)) {

                    ryu = RyuState.CrouchingReverse;
                    ryuCrouching = true;

                    ryuHadoukenCounter = 0;
                    ryuHadoukenComboStage1 = true;

                    ryuTatsumakiCounter = 0;
                    ryuTatsumakiComboStage1 = true;

                } else if ((kb.IsKeyDown(Keys.Right) || (pad2.ThumbSticks.Left.X == 1) || (pad2.DPad.Right == ButtonState.Pressed)) && ryuActionIsNotRunning) {

                    ryu = RyuState.WalkingBackwardReverse;
                    ryuCrouching = false;

                } else if ((kb.IsKeyDown(Keys.Left) || (pad2.ThumbSticks.Left.X == -1) || (pad2.DPad.Left == ButtonState.Pressed)) && ryuActionIsNotRunning) {

                    ryu = RyuState.WalkingForwardReverse;
                    ryuCrouching = false;

                    if (!ryuShoryukenComboStage1) ryuShoryukenCounter = 0;
                    ryuShoryukenComboStage1 = true;

                } else if ((kb.IsKeyDown(Keys.Up) || (pad2.ThumbSticks.Left.Y == 1) || (pad2.DPad.Up == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.JumpingReverse;
                    ryuJumpState = 0;

                } else if (ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.IdleReverse;
                    ryuCrouching = false;

                }

            }
            
            //Input controls for ken facing left and ryu facing right
            if (!kenFacingRight && !endGame) {

                //detects hadouken combo in a time limit for ken facing left and ryu facing right
                if (kenHadoukenComboStage1 && kenHadoukenCounter <= comboTimeLimit) {
                    kenHadoukenCounter++;

                    if ((kb.IsKeyDown(Keys.A) || pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed)) kenHadoukenComboStage2 = true;

                    if (((kb.IsKeyDown(Keys.R) || kb.IsKeyDown(Keys.T) || kb.IsKeyDown(Keys.Y) || (pad1.Buttons.X == ButtonState.Pressed || pad1.Buttons.Y == ButtonState.Pressed || pad1.Buttons.RightShoulder == ButtonState.Pressed))) && kenHadoukenComboStage2 && kenActionIsNotRunning) {

                        ken = KenState.HadoukenReverse;
                        kenCrouching = false;

                        clearKenHitBoxes();

                        kenInputHadoukenRectX = kenRect.X + 70;
                        kenInputHadoukenRectY = kenRect.Y + 190;

                        kenHadoukenRect.X = kenInputHadoukenRectX;
                        kenHadoukenRect.Y = kenInputHadoukenRectY;

                        kenHadoukenComboStage1 = false;
                        kenHadoukenComboStage2 = false;

                        kenHadoukenState = 0;

                        if (!kenShoryukenComboStage3)
                            kenHadoukenSound.Play();

                    }

                    if (kenHadoukenCounter == comboTimeLimit) {
                        kenHadoukenComboStage1 = false;
                        kenHadoukenComboStage2 = false;
                    }

                }

                if (ryuHadoukenComboStage1 && ryuHadoukenCounter <= comboTimeLimit) {
                    ryuHadoukenCounter++;

                    if (kb.IsKeyDown(Keys.Right) || pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed) ryuHadoukenComboStage2 = true;

                    if (((kb.IsKeyDown(Keys.I) || kb.IsKeyDown(Keys.O) || kb.IsKeyDown(Keys.P)) || (pad2.Buttons.X == ButtonState.Pressed || pad2.Buttons.Y == ButtonState.Pressed || pad2.Buttons.RightShoulder == ButtonState.Pressed)) && ryuHadoukenComboStage2 && ryuActionIsNotRunning) {

                        ryu = RyuState.Hadouken;
                        ryuCrouching = false;

                        clearRyuHitBoxes();

                        ryuInputHadoukenRectX = ryuRect.X + 230;
                        ryuInputHadoukenRectY = ryuRect.Y + 190;

                        ryuHadoukenRect.X = ryuInputHadoukenRectX;
                        ryuHadoukenRect.Y = ryuInputHadoukenRectY;

                        ryuHadoukenComboStage1 = false;
                        ryuHadoukenComboStage2 = false;

                        ryuHadoukenState = 0;

                        if (!ryuShoryukenComboStage3)
                            ryuHadoukenSound.Play();

                    }

                    if (ryuHadoukenCounter == comboTimeLimit) {
                        ryuHadoukenComboStage1 = false;
                        ryuHadoukenComboStage2 = false;
                    }

                }

                //detects tatsumaki combo in a time limit for ken facing left and ryu facing right
                if (kenTatsumakiComboStage1 && kenTatsumakiCounter <= comboTimeLimit) {
                    kenTatsumakiCounter++;

                    if (kb.IsKeyDown(Keys.D) || pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed) kenTatsumakiComboStage2 = true;

                    if (((kb.IsKeyDown(Keys.F) || kb.IsKeyDown(Keys.G) || kb.IsKeyDown(Keys.H)) || (pad1.Buttons.A == ButtonState.Pressed || pad1.Buttons.B == ButtonState.Pressed || pad1.Triggers.Right == 1)) && kenTatsumakiComboStage2 && kenActionIsNotRunning) {

                        ken = KenState.TatsumakiReverse;
                        kenCrouching = false;

                        clearKenHitBoxes();

                        kenTatsumakiComboStage1 = false;
                        kenTatsumakiComboStage2 = false;

                        kenTatsumakiSound.Play();

                    }

                    if (kenTatsumakiCounter == comboTimeLimit) {
                        kenTatsumakiComboStage1 = false;
                        kenTatsumakiComboStage2 = false;
                    }

                }

                if (ryuTatsumakiComboStage1 && ryuTatsumakiCounter <= comboTimeLimit) {
                    ryuTatsumakiCounter++;

                    if (kb.IsKeyDown(Keys.Left) || pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed) ryuTatsumakiComboStage2 = true;

                    if (((kb.IsKeyDown(Keys.K) || kb.IsKeyDown(Keys.L) || kb.IsKeyDown(Keys.OemSemicolon)) || (pad2.Buttons.A == ButtonState.Pressed || pad2.Buttons.B == ButtonState.Pressed || pad2.Triggers.Right == 1)) && ryuTatsumakiComboStage2 && ryuActionIsNotRunning) {

                        ryu = RyuState.Tatsumaki;
                        ryuCrouching = false;

                        clearRyuHitBoxes();

                        ryuTatsumakiComboStage1 = false;
                        ryuTatsumakiComboStage2 = false;

                        ryuTatsumakiSound.Play();

                    }

                    if (ryuTatsumakiCounter == comboTimeLimit) {
                        ryuTatsumakiComboStage1 = false;
                        ryuTatsumakiComboStage2 = false;
                    }

                }

                //detects shoryuken combo in a time limit for ken facing left and ryu facing right
                if (kenShoryukenComboStage1 && kenShoryukenCounter <= comboTimeLimit) {
                    kenShoryukenCounter++;

                    if (kb.IsKeyDown(Keys.S) || pad1.ThumbSticks.Left.Y == 1 || pad1.DPad.Down == ButtonState.Pressed) kenShoryukenComboStage2 = true;

                    if ((kb.IsKeyDown(Keys.A) || pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed) && kenShoryukenComboStage2) kenShoryukenComboStage3 = true;

                    if (((kb.IsKeyDown(Keys.R) || kb.IsKeyDown(Keys.T) || kb.IsKeyDown(Keys.Y)) || (pad1.Buttons.X == ButtonState.Pressed || pad1.Buttons.Y == ButtonState.Pressed || pad1.Buttons.RightShoulder == ButtonState.Pressed)) && kenShoryukenComboStage3 && kenActionIsNotRunning) {

                        ken = KenState.ShoryukenReverse;
                        kenCrouching = false;

                        clearKenHitBoxes();

                        kenShoryukenComboStage1 = false;
                        kenShoryukenComboStage2 = false;
                        kenShoryukenComboStage3 = false;

                        kenShoryukenSound.Play();

                    }

                    if (kenShoryukenCounter == comboTimeLimit) {
                        kenShoryukenComboStage1 = false;
                        kenShoryukenComboStage2 = false;
                        kenShoryukenComboStage3 = false;
                    }

                }

                if (ryuShoryukenComboStage1 && ryuShoryukenCounter <= comboTimeLimit) {
                    ryuShoryukenCounter++;

                    if (kb.IsKeyDown(Keys.Down) || pad2.ThumbSticks.Left.Y == -1 || pad2.DPad.Down == ButtonState.Pressed) ryuShoryukenComboStage2 = true;

                    if ((kb.IsKeyDown(Keys.Right) || pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed) && ryuShoryukenComboStage2) ryuShoryukenComboStage3 = true;

                    if (((kb.IsKeyDown(Keys.I) || kb.IsKeyDown(Keys.O) || kb.IsKeyDown(Keys.P)) || (pad2.Buttons.X == ButtonState.Pressed || pad2.Buttons.Y == ButtonState.Pressed || pad2.Buttons.RightShoulder == ButtonState.Pressed)) && ryuShoryukenComboStage3 && ryuActionIsNotRunning) {

                        ryu = RyuState.Shoryuken;
                        ryuCrouching = false;

                        clearRyuHitBoxes();

                        ryuShoryukenComboStage1 = false;
                        ryuShoryukenComboStage2 = false;
                        ryuShoryukenComboStage3 = false;

                        ryuShoryukenSound.Play();

                    }

                    if (ryuShoryukenCounter == comboTimeLimit) {
                        ryuShoryukenComboStage1 = false;
                        ryuShoryukenComboStage2 = false;
                        ryuShoryukenComboStage3 = false;
                    }

                }

                checkKenState();
                checkRyuState();

                //Input controls to set the state of ken facing left
                if (((kb.IsKeyDown(Keys.A) && kb.IsKeyDown(Keys.F)) || ((pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed) && pad1.Buttons.A == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.ForwardLowKickReverse;

                    forwardLowKickHitboxKen.X = kenRect.X + forwardLowKickReverseX;
                    forwardLowKickHitboxKen.Y = kenRect.Y + forwardLowKickReverseY;

                    kenForwardLowKickState = 0;

                    kenAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.A) && kb.IsKeyDown(Keys.G)) || ((pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed) && pad1.Buttons.B == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.ForwardMediumKickReverse;

                    forwardMediumKickHitboxKen.X = kenRect.X + forwardMediumKickReverseX;
                    forwardMediumKickHitboxKen.Y = kenRect.Y + forwardMediumKickReverseY;

                    kenForwardMediumKickState = 0;

                    kenAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.A) && kb.IsKeyDown(Keys.H)) || ((pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed) && pad1.Triggers.Right == 1))  && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.ForwardHighKickReverse;

                    forwardHighKickHitboxKen.X = kenRect.X + forwardHighKickReverseX;
                    forwardHighKickHitboxKen.Y = kenRect.Y + forwardHighKickReverseY;

                    kenForwardHighKickState = 0;

                    kenAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.A) && kb.IsKeyDown(Keys.R)) || ((pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed) && pad1.Buttons.X == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.ForwardLowPunchReverse;

                    forwardLowPunchHitboxKen.X = kenRect.X + forwardLowPunchReverseX;
                    forwardLowPunchHitboxKen.Y = kenRect.Y + forwardLowPunchReverseY;

                    kenForwardLowPunchState = 0;

                    kenAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.A) && kb.IsKeyDown(Keys.T)) || ((pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed) && pad2.Buttons.Y == ButtonState.Pressed))  && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.ForwardMediumPunchReverse;

                    forwardMediumPunchHitboxKen.X = kenRect.X + forwardMediumPunchReverseX;
                    forwardMediumPunchHitboxKen.Y = kenRect.Y + forwardMediumPunchReverseY;

                    kenForwardMediumPunchState = 0;

                    kenAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.A) && kb.IsKeyDown(Keys.Y)) || ((pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed) && pad1.Buttons.RightShoulder == ButtonState.Pressed))  && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.ForwardHighPunchReverse;

                    forwardHighPunchHitboxKen.X = kenRect.X + forwardHighPunchReverseX;
                    forwardHighPunchHitboxKen.Y = kenRect.Y + forwardHighPunchReverseY;

                    kenForwardHighPunchState = 0;

                    kenAttackSound.Play();

                } else if ((kb.IsKeyDown(Keys.F)|| pad1.Buttons.A == ButtonState.Pressed) && kenActionIsNotRunning && !kenActionsPaused) {

                    if (ken == KenState.CrouchingReverse) {

                        ken = KenState.LowCrouchKickReverse;

                        crouchLowKickHitboxKen.X = kenRect.X + crouchLowKickReverseX;
                        crouchLowKickHitboxKen.Y = kenRect.Y + crouchLowKickReverseY;

                    } else {

                        ken = KenState.LowKickReverse;

                        lowKickHitboxKen.X = kenRect.X + lowKickReverseX;
                        lowKickHitboxKen.Y = kenRect.Y + lowKickReverseY;

                    }

                    kenAttackSound.Play();
                    kenLowKickState = 0;
                    kenLowCrouchKickState = 0;

                } else if ((kb.IsKeyDown(Keys.G) || pad1.Buttons.B == ButtonState.Pressed) && kenActionIsNotRunning && !kenActionsPaused) {

                    if (ken == KenState.CrouchingReverse) {

                        ken = KenState.MediumCrouchKickReverse;

                        crouchMediumKickHitboxKen.X = kenRect.X + crouchMediumKickReverseX;
                        crouchMediumKickHitboxKen.Y = kenRect.Y + crouchMediumKickReverseY;

                    } else {

                        ken = KenState.MediumKickReverse;

                        mediumKickHitboxKen.X = kenRect.X + mediumKickReverseX;
                        mediumKickHitboxKen.Y = kenRect.Y + mediumKickReverseY;

                    }

                    kenAttackSound.Play();
                    kenMediumKickState = 0;
                    kenMediumCrouchKickState = 0;

                } else if ((kb.IsKeyDown(Keys.H) || pad1.Triggers.Right == 1) && kenActionIsNotRunning && !kenActionsPaused) {

                    if (ken == KenState.CrouchingReverse) {

                        ken = KenState.HighCrouchKickReverse;

                        crouchHighKickHitboxKen.X = kenRect.X + crouchHighKickReverseX;
                        crouchHighKickHitboxKen.Y = kenRect.Y + crouchHighKickReverseY;

                    } else {

                        ken = KenState.HighKickReverse;

                        highKickHitboxKen.X = kenRect.X + highKickReverseX;
                        highKickHitboxKen.Y = kenRect.Y + highKickReverseY;

                    }

                    kenAttackSound.Play();
                    kenHighKickState = 0;
                    kenHighCrouchKickState = 0;

                } else if ((kb.IsKeyDown(Keys.Y) || pad1.Buttons.RightShoulder == ButtonState.Pressed) && kenActionIsNotRunning && !kenActionsPaused) {

                    if (ken == KenState.CrouchingReverse) {

                        ken = KenState.HighPunchCrouchReverse;

                        crouchHighPunchHitboxKen.X = kenRect.X + crouchHighPunchReverseX;
                        crouchHighPunchHitboxKen.Y = kenRect.Y + crouchHighPunchReverseY;

                    } else {

                        ken = KenState.HighPunchReverse;

                        highPunchHitboxKen.X = kenRect.X + highPunchReverseX;
                        highPunchHitboxKen.Y = kenRect.Y + highPunchReverseY;

                    }

                    kenAttackSound.Play();
                    kenHighPunchState = 0;
                    kenHighPunchCrouchState = 0;

                } else if ((kb.IsKeyDown(Keys.T) || pad1.Buttons.Y == ButtonState.Pressed) && kenActionIsNotRunning && !kenActionsPaused) {

                    if (ken == KenState.CrouchingReverse) {

                        ken = KenState.MediumPunchCrouchReverse;

                        crouchMediumPunchHitboxKen.X = kenRect.X + crouchMediumPunchReverseX;
                        crouchMediumPunchHitboxKen.Y = kenRect.Y + crouchMediumPunchReverseY;

                    } else {

                        ken = KenState.MediumPunchReverse;

                        mediumPunchHitboxKen.X = kenRect.X + mediumPunchReverseX;
                        mediumPunchHitboxKen.Y = kenRect.Y + mediumPunchReverseY;

                    }

                    kenAttackSound.Play();
                    kenMediumPunchState = 0;
                    kenMediumPunchCrouchState = 0;

                } else if ((kb.IsKeyDown(Keys.R) || pad1.Buttons.X == ButtonState.Pressed) && kenActionIsNotRunning && !kenActionsPaused) {

                    if (ken == KenState.CrouchingReverse) {

                        ken = KenState.LowPunchCrouchReverse;

                        crouchLowPunchHitboxKen.X = kenRect.X + crouchLowPunchReverseX;
                        crouchLowPunchHitboxKen.Y = kenRect.Y + crouchLowPunchReverseY;

                    } else {

                        ken = KenState.LowPunchReverse;

                        lowPunchHitboxKen.X = kenRect.X + lowPunchReverseX;
                        lowPunchHitboxKen.Y = kenRect.Y + lowPunchReverseY;

                    }

                    kenAttackSound.Play();
                    kenLowPunchState = 0;
                    kenLowPunchCrouchState = 0;

                } else if (((kb.IsKeyDown(Keys.W) && kb.IsKeyDown(Keys.A))|| (pad1.ThumbSticks.Left.Y > 0 && pad1.ThumbSticks.Left.X < 0) || (pad1.DPad.Up == ButtonState.Pressed && pad1.DPad.Left == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.ForwardJumpingReverse;
                    kenForwardJumpState = 0;

                } else if (((kb.IsKeyDown(Keys.W) && kb.IsKeyDown(Keys.D)) || (pad1.ThumbSticks.Left.Y > 0 && pad1.ThumbSticks.Left.X > 0) || (pad1.DPad.Up == ButtonState.Pressed && pad1.DPad.Right == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.BackwardJumpingReverse;
                    kenBackwardJumpState = 5;

                } else if (((kb.IsKeyDown(Keys.S) || (pad1.ThumbSticks.Left.Y == -1)) || (pad1.DPad.Down == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.CrouchingReverse;
                    kenCrouching = true;

                    kenHadoukenCounter = 0;
                    kenHadoukenComboStage1 = true;

                    kenTatsumakiCounter = 0;
                    kenTatsumakiComboStage1 = true;

                } else if ((kb.IsKeyDown(Keys.D) || (pad1.ThumbSticks.Left.X == 1) || (pad1.DPad.Right == ButtonState.Pressed)) && kenActionIsNotRunning) {

                    ken = KenState.WalkingBackwardReverse;
                    kenCrouching = false;

                } else if ((kb.IsKeyDown(Keys.A) || (pad1.ThumbSticks.Left.X == -1) || (pad1.DPad.Left == ButtonState.Pressed)) && kenActionIsNotRunning) {

                    ken = KenState.WalkingForwardReverse;
                    kenCrouching = false;

                    if (!kenShoryukenComboStage1) kenShoryukenCounter = 0;
                    kenShoryukenComboStage1 = true;

                } else if ((kb.IsKeyDown(Keys.W) || (pad1.ThumbSticks.Left.Y == 1) || (pad1.DPad.Up == ButtonState.Pressed)) && kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.JumpingReverse;
                    kenJumpState = 0;

                } else if (kenActionIsNotRunning && !kenActionsPaused) {

                    ken = KenState.IdleReverse;
                    kenCrouching = false;

                }

                //Input controls for the state of ryu facing right
                if (((kb.IsKeyDown(Keys.Right) && kb.IsKeyDown(Keys.K)) || ((pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed) && pad2.Buttons.A == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.ForwardLowKick;

                    forwardLowKickHitboxRyu.X = ryuRect.X + forwardLowKickX;
                    forwardLowKickHitboxRyu.Y = ryuRect.Y + forwardLowKickY;

                    ryuForwardLowKickState = 0;

                    ryuAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.Right) && kb.IsKeyDown(Keys.L)) || ((pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed) && pad2.Buttons.B == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.ForwardMediumKick;

                    forwardMediumKickHitboxRyu.X = ryuRect.X + forwardMediumKickX;
                    forwardMediumKickHitboxRyu.Y = ryuRect.Y + forwardMediumKickY;

                    ryuForwardMediumKickState = 0;

                    ryuAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.Right) && kb.IsKeyDown(Keys.OemSemicolon)) || ((pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed) && pad2.Triggers.Right == 1)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.ForwardHighKick;

                    forwardHighKickHitboxRyu.X = ryuRect.X + forwardHighKickX;
                    forwardHighKickHitboxRyu.Y = ryuRect.Y + forwardHighKickY;

                    ryuForwardHighKickState = 0;

                    ryuAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.Right) && kb.IsKeyDown(Keys.I))|| ((pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed) && pad2.Buttons.X == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.ForwardLowPunch;

                    forwardLowPunchHitboxRyu.X = ryuRect.X + forwardLowPunchX;
                    forwardLowPunchHitboxRyu.Y = ryuRect.Y + forwardLowPunchY;

                    ryuForwardLowPunchState = 0;

                    ryuAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.Right) && kb.IsKeyDown(Keys.O))|| ((pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed) && pad2.Buttons.Y == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.ForwardMediumPunch;

                    forwardMediumPunchHitboxRyu.X = ryuRect.X + forwardMediumPunchX;
                    forwardMediumPunchHitboxRyu.Y = ryuRect.Y + forwardMediumPunchY;

                    ryuForwardMediumPunchState = 0;

                    ryuAttackSound.Play();

                } else if (((kb.IsKeyDown(Keys.Right) && kb.IsKeyDown(Keys.P)) || ((pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed) && pad2.Buttons.RightShoulder == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.ForwardHighPunch;

                    forwardHighPunchHitboxRyu.X = ryuRect.X + forwardHighPunchX;
                    forwardHighPunchHitboxRyu.Y = ryuRect.Y + forwardHighPunchY;

                    ryuForwardHighPunchState = 0;

                    ryuAttackSound.Play();

                } else if ((kb.IsKeyDown(Keys.K) || pad2.Buttons.A == ButtonState.Pressed) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    if (ryu == RyuState.Crouching) {

                        ryu = RyuState.LowCrouchKick;

                        crouchLowKickHitboxRyu.X = ryuRect.X + crouchLowKickX;
                        crouchLowKickHitboxRyu.Y = ryuRect.Y + crouchLowKickY;

                    } else {

                        ryu = RyuState.LowKick;

                        lowKickHitboxRyu.X = ryuRect.X + lowKickX;
                        lowKickHitboxRyu.Y = ryuRect.Y + lowKickY;

                    }

                    ryuAttackSound.Play();
                    ryuLowKickState = 0;
                    ryuLowCrouchKickState = 0;

                } else if ((kb.IsKeyDown(Keys.L) || pad2.Buttons.B == ButtonState.Pressed) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    if (ryu == RyuState.Crouching) {

                        ryu = RyuState.MediumCrouchKick;

                        crouchMediumKickHitboxRyu.X = ryuRect.X + crouchMediumKickX;
                        crouchMediumKickHitboxRyu.Y = ryuRect.Y + crouchMediumKickY;

                    } else {

                        ryu = RyuState.MediumKick;

                        mediumKickHitboxRyu.X = ryuRect.X + mediumKickX;
                        mediumKickHitboxRyu.Y = ryuRect.Y + mediumKickY;

                    }

                    ryuAttackSound.Play();
                    ryuMediumKickState = 0;
                    ryuMediumCrouchKickState = 0;

                } else if ((kb.IsKeyDown(Keys.OemSemicolon) || pad2.Triggers.Right == 1) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    if (ryu == RyuState.Crouching) {

                        ryu = RyuState.HighCrouchKick;

                        crouchHighKickHitboxRyu.X = ryuRect.X + crouchHighKickX;
                        crouchHighKickHitboxRyu.Y = ryuRect.Y + crouchHighKickY;

                    } else {

                        ryu = RyuState.HighKick;

                        highKickHitboxRyu.X = ryuRect.X + highKickX;
                        highKickHitboxRyu.Y = ryuRect.Y + highKickY;

                    }

                    ryuAttackSound.Play();
                    ryuHighKickState = 0;
                    ryuHighCrouchKickState = 0;

                } else if ((kb.IsKeyDown(Keys.P) || pad2.Buttons.RightShoulder == ButtonState.Pressed) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    if (ryu == RyuState.Crouching) {

                        ryu = RyuState.HighPunchCrouch;

                        crouchHighPunchHitboxRyu.X = ryuRect.X + crouchHighPunchX;
                        crouchHighPunchHitboxRyu.Y = ryuRect.Y + crouchHighPunchY;

                    } else {

                        ryu = RyuState.HighPunch;

                        highPunchHitboxRyu.X = ryuRect.X + highPunchX;
                        highPunchHitboxRyu.Y = ryuRect.Y + highPunchY;

                    }

                    ryuAttackSound.Play();
                    ryuHighPunchState = 0;
                    ryuHighPunchCrouchState = 0;

                } else if ((kb.IsKeyDown(Keys.O) || pad2.Buttons.Y == ButtonState.Pressed) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    if (ryu == RyuState.Crouching) {

                        ryu = RyuState.MediumPunchCrouch;

                        crouchMediumPunchHitboxRyu.X = ryuRect.X + crouchMediumPunchX;
                        crouchMediumPunchHitboxRyu.Y = ryuRect.Y + crouchMediumPunchY;

                    } else {

                        ryu = RyuState.MediumPunch;

                        mediumPunchHitboxRyu.X = ryuRect.X + mediumPunchX;
                        mediumPunchHitboxRyu.Y = ryuRect.Y + mediumPunchY;

                    }

                    ryuAttackSound.Play();
                    ryuMediumPunchState = 0;
                    ryuMediumPunchCrouchState = 0;

                } else if ((kb.IsKeyDown(Keys.I) || pad2.Buttons.X == ButtonState.Pressed) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    if (ryu == RyuState.Crouching) {

                        ryu = RyuState.LowPunchCrouch;

                        crouchLowPunchHitboxRyu.X = ryuRect.X + crouchLowPunchX;
                        crouchLowPunchHitboxRyu.Y = ryuRect.Y + crouchLowPunchY;

                    } else {

                        ryu = RyuState.LowPunch;

                        lowPunchHitboxRyu.X = ryuRect.X + lowPunchX;
                        lowPunchHitboxRyu.Y = ryuRect.Y + lowPunchY;

                    }

                    ryuAttackSound.Play();
                    ryuLowPunchState = 0;
                    ryuLowPunchCrouchState = 0;

                } else if (((kb.IsKeyDown(Keys.Up) && kb.IsKeyDown(Keys.Right)) || (pad2.ThumbSticks.Left.Y > 0 && pad2.ThumbSticks.Left.X > 0) || (pad2.DPad.Up == ButtonState.Pressed && pad2.DPad.Right == ButtonState.Pressed))  && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.ForwardJumping;
                    ryuForwardJumpState = 0;

                } else if (((kb.IsKeyDown(Keys.Up) && kb.IsKeyDown(Keys.Left)) || (pad2.ThumbSticks.Left.Y > 0 && pad2.ThumbSticks.Left.X < 0) || (pad2.DPad.Up == ButtonState.Pressed && pad2.DPad.Left == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.BackwardJumping;
                    ryuBackwardJumpState = 5;

                } else if ((kb.IsKeyDown(Keys.Down) || (pad2.ThumbSticks.Left.Y == -1) || (pad2.DPad.Down == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.Crouching;
                    ryuCrouching = true;

                    ryuHadoukenCounter = 0;
                    ryuHadoukenComboStage1 = true;

                    ryuTatsumakiCounter = 0;
                    ryuTatsumakiComboStage1 = true;

                } else if ((kb.IsKeyDown(Keys.Left) || (pad2.ThumbSticks.Left.X == -1) || (pad2.DPad.Left == ButtonState.Pressed)) && ryuActionIsNotRunning) {

                    ryu = RyuState.WalkingBackward;
                    ryuCrouching = false;

                } else if ((kb.IsKeyDown(Keys.Right) || (pad2.ThumbSticks.Left.X == 1) || (pad2.DPad.Right == ButtonState.Pressed)) && ryuActionIsNotRunning) {

                    ryu = RyuState.WalkingForward;
                    ryuCrouching = false;

                    if (!ryuShoryukenComboStage1) ryuShoryukenCounter = 0;
                    ryuShoryukenComboStage1 = true;

                } else if ((kb.IsKeyDown(Keys.Up) || (pad2.ThumbSticks.Left.Y == 1) || (pad2.DPad.Up == ButtonState.Pressed)) && ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.Jumping;
                    ryuJumpState = 0;

                } else if (ryuActionIsNotRunning && !ryuActionsPaused) {

                    ryu = RyuState.Idle;
                    ryuCrouching = false;

                }

            }



            //intersections of the attacks and movement hitbox

            //intersections for ken hitting ryu
            if (lowPunchHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 1;
                    ryuHealthBar.X += 3;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 1;
                    ryuHealthBar.X += 3;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsHit = true;

                    ryu = RyuState.Hit;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                } else {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsHit = true;

                    ryu = RyuState.HitReverse;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (mediumPunchHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 2;
                    ryuHealthBar.X += 6;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 2;
                    ryuHealthBar.X += 6;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsHit = true;

                    ryu = RyuState.Hit;
                    ryuHitCounter++;

                    hitMediumSound.Play();

                } else {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsHit = true;

                    ryu = RyuState.HitReverse;
                    ryuHitCounter++;

                    hitMediumSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (highPunchHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 7;
                    ryuHealthBar.X += 21;
                    ryuIsHit = true;

                    ryu = RyuState.Hit;
                    ryuHitCounter++;

                    hitMediumSound.Play();

                } else {

                    ryuHealth -= 7;
                    ryuHealthBar.X += 21;
                    ryuIsHit = true;

                    ryu = RyuState.HitReverse;
                    ryuHitCounter++;

                    hitMediumSound.Play();

                }

                if (ryuRect.Y > 65) ryu = RyuState.Knockdown;

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (lowKickHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 1;
                    ryuHealthBar.X += 3;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 1;
                    ryuHealthBar.X += 3;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsHit = true;

                    ryu = RyuState.FaceHit;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                } else {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsHit = true;

                    ryu = RyuState.FaceHitReverse;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (mediumKickHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 2;
                    ryuHealthBar.X += 6;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 2;
                    ryuHealthBar.X += 6;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsHit = true;

                    ryu = RyuState.FaceHit;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                } else {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsHit = true;

                    ryu = RyuState.FaceHitReverse;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (highKickHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 7;
                    ryuHealthBar.X += 21;
                    ryuIsHit = true;

                    ryu = RyuState.FaceHit;
                    ryuHitCounter++;

                    hitMediumSound.Play();

                } else {

                    ryuHealth -= 7;
                    ryuHealthBar.X += 21;
                    ryuIsHit = true;

                    ryu = RyuState.FaceHitReverse;
                    ryuHitCounter++;

                    hitMediumSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }

            if (crouchLowPunchHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 1;
                    ryuHealthBar.X += 3;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 1;
                    ryuHealthBar.X += 3;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.Hit;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                } else {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.HitReverse;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (crouchMediumPunchHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 2;
                    ryuHealthBar.X += 6;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 2;
                    ryuHealthBar.X += 6;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.Hit;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                } else {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.HitReverse;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (crouchHighPunchHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 10;
                    ryuHealthBar.X += 30;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.FaceHit;
                    ryuHitCounter++;

                    hitMediumSound.Play();

                } else {

                    ryuHealth -= 10;
                    ryuHealthBar.X += 30;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.FaceHitReverse;
                    ryuHitCounter++;

                    hitMediumSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (crouchLowKickHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 1;
                    ryuHealthBar.X += 3;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 1;
                    ryuHealthBar.X += 3;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.Hit;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                } else {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.HitReverse;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (crouchMediumKickHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 2;
                    ryuHealthBar.X += 6;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 2;
                    ryuHealthBar.X += 6;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.Hit;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                } else {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.HitReverse;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (crouchHighKickHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 10;
                    ryuHealthBar.X += 30;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.Knockdown;

                    hitMediumSound.Play();

                } else {

                    ryuHealth -= 10;
                    ryuHealthBar.X += 30;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.KnockdownReverse;

                    hitMediumSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }

            if (forwardLowPunchHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 1;
                    ryuHealthBar.X += 3;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 1;
                    ryuHealthBar.X += 3;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.FaceHit;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                } else {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.FaceHitReverse;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (forwardMediumPunchHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 2;
                    ryuHealthBar.X += 6;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 2;
                    ryuHealthBar.X += 6;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 7;
                    ryuHealthBar.X += 21;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.Hit;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                } else {

                    ryuHealth -= 7;
                    ryuHealthBar.X += 21;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.HitReverse;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (forwardHighPunchHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 10;
                    ryuHealthBar.X += 30;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.FaceHit;
                    ryuHitCounter++;

                    hitMediumSound.Play();

                } else {

                    ryuHealth -= 10;
                    ryuHealthBar.X += 30;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.FaceHitReverse;
                    ryuHitCounter++;

                    hitMediumSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (forwardLowKickHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 1;
                    ryuHealthBar.X += 3;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 1;
                    ryuHealthBar.X += 3;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.Hit;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                } else {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.HitReverse;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (forwardMediumKickHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 2;
                    ryuHealthBar.X += 6;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 2;
                    ryuHealthBar.X += 6;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 7;
                    ryuHealthBar.X += 21;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.Hit;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                } else {

                    ryuHealth -= 7;
                    ryuHealthBar.X += 21;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.HitReverse;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (forwardHighKickHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 3;
                    ryuHealthBar.X += 9;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 10;
                    ryuHealthBar.X += 30;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.FaceHit;
                    ryuHitCounter++;

                    hitMediumSound.Play();

                } else {

                    ryuHealth -= 10;
                    ryuHealthBar.X += 30;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.FaceHitReverse;
                    ryuHitCounter++;

                    hitMediumSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }

            if (hadoukenHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuHadoukenBlock = true;
                    ryuHadoukenBlockCounter = 0;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuHadoukenBlock = true;
                    ryuHadoukenBlockCounter = 0;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 10;
                    ryuHealthBar.X += 30;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.Hit;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                } else {

                    ryuHealth -= 10;
                    ryuHealthBar.X += 30;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.HitReverse;
                    ryuHitCounter++;

                    hitSmallSound.Play();

                }

                ken = KenState.Idle;

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (tatsumakiHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && ryuRect.Y == 65) {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && ryuRect.Y == 65) {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 10;
                    ryuHealthBar.X += 30;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.Knockdown;

                    hitMediumSound.Play();

                } else {

                    ryuHealth -= 10;
                    ryuHealthBar.X += 30;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.KnockdownReverse;

                    hitMediumSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }
            if (shoryukenHitboxKen.Intersects(ryuHitboxMovementRect) && !ryuIsHit && !ryuIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (!kenFacingRight && (pad2.ThumbSticks.Left.X == -1 || pad2.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.Left)) && kenRect.Y == 65) {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight && (pad2.ThumbSticks.Left.X == 1 || pad2.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.Right)) && kenRect.Y == 65) {

                    ryuHealth -= 5;
                    ryuHealthBar.X += 15;
                    ryuIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight) {

                    ryuHealth -= 10;
                    ryuHealthBar.X += 30;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHit;
                    else ryu = RyuState.Knockdown;

                    hitMediumSound.Play();

                } else {

                    ryuHealth -= 10;
                    ryuHealthBar.X += 30;
                    ryuIsHit = true;

                    if (ryuCrouching) ryu = RyuState.CrouchHitReverse;
                    else ryu = RyuState.KnockdownReverse;

                    hitMediumSound.Play();

                }

                ryuHitState = 0;
                ryuFaceHitState = 0;

            }



            //intersections for ryu hitting ken
            if (lowPunchHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 1;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 1;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 3;
                    kenIsHit = true;

                    ken = KenState.Hit;
                    kenHitCounter++;

                    hitSmallSound.Play();

                } else {

                    kenHealth -= 3;
                    kenIsHit = true;

                    ken = KenState.HitReverse;
                    kenHitCounter++;

                    hitSmallSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (mediumPunchHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 2;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 2;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 5;
                    kenIsHit = true;

                    ken = KenState.Hit;
                    kenHitCounter++;

                    hitSmallSound.Play();

                } else {

                    kenHealth -= 5;
                    kenIsHit = true;

                    ken = KenState.HitReverse;
                    kenHitCounter++;

                    hitSmallSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (highPunchHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 3;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 3;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 7;
                    kenIsHit = true;

                    ken = KenState.Hit;
                    kenHitCounter++;

                    hitSmallSound.Play();

                } else {

                    kenHealth -= 7;
                    kenIsHit = true;

                    ken = KenState.HitReverse;
                    kenHitCounter++;

                    hitSmallSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (lowKickHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 1;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 1;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 3;
                    kenIsHit = true;

                    ken = KenState.FaceHit;
                    kenHitCounter++;

                    hitSmallSound.Play();

                } else {

                    kenHealth -= 3;
                    kenIsHit = true;

                    ken = KenState.FaceHitReverse;
                    kenHitCounter++;

                    hitSmallSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (mediumKickHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 2;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 2;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 5;
                    kenIsHit = true;

                    ken = KenState.FaceHit;
                    kenHitCounter++;

                    hitSmallSound.Play();


                } else {

                    kenHealth -= 5;
                    kenIsHit = true;

                    ken = KenState.FaceHitReverse;
                    kenHitCounter++;

                    hitSmallSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (highKickHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 3;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 3;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 7;
                    kenIsHit = true;

                    ken = KenState.FaceHit;
                    kenHitCounter++;

                    hitMediumSound.Play();

                } else {

                    kenHealth -= 7;
                    kenIsHit = true;

                    ken = KenState.FaceHitReverse;
                    kenHitCounter++;

                    hitMediumSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }

            if (crouchLowPunchHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 1;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 1;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 3;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.Hit;
                    kenHitCounter++;

                    hitSmallSound.Play();

                } else {

                    kenHealth -= 3;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.HitReverse;
                    kenHitCounter++;

                    hitSmallSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (crouchMediumPunchHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 2;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 2;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 5;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.Hit;
                    kenHitCounter++;

                    hitSmallSound.Play();

                } else {

                    kenHealth -= 5;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.HitReverse;
                    kenHitCounter++;

                    hitSmallSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (crouchHighPunchHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 3;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 3;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 10;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.FaceHit;
                    kenHitCounter++;

                    hitMediumSound.Play();

                } else {

                    kenHealth -= 10;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.FaceHitReverse;
                    kenHitCounter++;

                    hitMediumSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (crouchLowKickHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 1;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 1;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 3;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.Hit;
                    kenHitCounter++;

                    hitSmallSound.Play();

                } else {

                    kenHealth -= 3;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.HitReverse;
                    kenHitCounter++;

                    hitSmallSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (crouchMediumKickHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 2;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 2;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 5;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.Hit;
                    kenHitCounter++;

                    hitSmallSound.Play();

                } else {

                    kenHealth -= 5;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.HitReverse;
                    kenHitCounter++;

                    hitSmallSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (crouchHighKickHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 3;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 3;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 10;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.Knockdown;

                    hitMediumSound.Play();

                } else {

                    kenHealth -= 10;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.KnockdownReverse;

                    hitMediumSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }

            if (forwardLowPunchHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 1;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 1;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 5;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.FaceHit;
                    kenHitCounter++;

                    hitSmallSound.Play();

                } else {

                    kenHealth -= 5;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.FaceHitReverse;
                    kenHitCounter++;

                    hitSmallSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (forwardMediumPunchHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 2;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 2;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 7;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.Hit;
                    kenHitCounter++;

                    hitSmallSound.Play();

                } else {

                    kenHealth -= 7;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.HitReverse;
                    kenHitCounter++;

                    hitSmallSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (forwardHighPunchHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 3;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 3;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 10;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.FaceHit;
                    kenHitCounter++;

                    hitMediumSound.Play();

                } else {

                    kenHealth -= 10;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.FaceHitReverse;
                    kenHitCounter++;

                    hitMediumSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (forwardLowKickHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 1;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 1;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 5;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.Hit;
                    kenHitCounter++;

                    hitSmallSound.Play();

                } else {

                    kenHealth -= 5;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.HitReverse;
                    kenHitCounter++;

                    hitSmallSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (forwardMediumKickHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 2;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 2;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 7;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.Hit;
                    kenHitCounter++;

                    hitSmallSound.Play();

                } else {

                    kenHealth -= 7;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.HitReverse;
                    kenHitCounter++;

                    hitSmallSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (forwardHighKickHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 3;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 3;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 10;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.FaceHit;
                    kenHitCounter++;

                    hitMediumSound.Play();

                } else {

                    kenHealth -= 10;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.FaceHitReverse;
                    kenHitCounter++;

                    hitMediumSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }

            if (hadoukenHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 5;
                    kenHadoukenBlock = true;
                    kenHadoukenBlockCounter = 0;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 5;
                    kenHadoukenBlock = true;
                    kenHadoukenBlockCounter = 0;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 10;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.Hit;
                    kenHitCounter++;

                    hitSmallSound.Play();

                } else {

                    kenHealth -= 10;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.HitReverse;
                    kenHitCounter++;

                    hitSmallSound.Play();

                }

                ryu = RyuState.Idle;

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (tatsumakiHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 5;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 5;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 15;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.Knockdown;

                    hitMediumSound.Play();

                } else {

                    kenHealth -= 15;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.KnockdownReverse;

                    hitMediumSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }
            if (shoryukenHitboxRyu.Intersects(kenHitboxMovementRect) && !kenIsHit && !kenIsBlock) {

                clearKenHitBoxes(); clearRyuHitBoxes();

                if (kenFacingRight && (pad1.ThumbSticks.Left.X == -1 || pad1.DPad.Left == ButtonState.Pressed || kb.IsKeyDown(Keys.A)) && kenRect.Y == 65) {

                    kenHealth -= 5;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (!kenFacingRight && (pad1.ThumbSticks.Left.X == 1 || pad1.DPad.Right == ButtonState.Pressed || kb.IsKeyDown(Keys.D)) && kenRect.Y == 65) {

                    kenHealth -= 5;
                    kenIsBlock = true;

                    blockSound.Play();

                } else if (kenFacingRight) {

                    kenHealth -= 15;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHit;
                    else ken = KenState.Knockdown;

                    hitMediumSound.Play();

                } else {

                    kenHealth -= 15;
                    kenIsHit = true;

                    if (kenCrouching) ken = KenState.CrouchHitReverse;
                    else ken = KenState.KnockdownReverse;

                    hitMediumSound.Play();

                }

                kenHitState = 0;
                kenFaceHitState = 0;

            }

            //hadouken collisions
            if (kenHadoukenRect.Intersects(ryuHadoukenRect) && ((ken == KenState.Hadouken && ryu == RyuState.HadoukenReverse) || (ken == KenState.HadoukenReverse && ryu == RyuState.Hadouken))) {

                if (kenFacingRight) {

                    ken = KenState.Idle;
                    ryu = RyuState.IdleReverse;

                    kenHadoukenRect.X = -1000;
                    kenHadoukenRect.Y = -1000;
                    ryuHadoukenRect.X = -1000;
                    ryuHadoukenRect.Y = -1000;

                } else {

                    ken = KenState.IdleReverse;
                    ryu = RyuState.Idle;

                    kenHadoukenRect.X = -1000;
                    kenHadoukenRect.Y = -1000;
                    ryuHadoukenRect.X = -1000;
                    ryuHadoukenRect.Y = -1000;

                }

            }

            //Hit animation
            if (ticks % hitSeparation == 0) {

                switch (ken) {

                    case KenState.Hit:
                        if (kenHitState == 0) {

                            if (kenRect.Y < 65) {

                                kenGoingDown = true;
                                kenHitState = 0;

                            } else kenHitState = 1;

                        }

                        if (kenHitState > 0) kenHitState++;

                        if (kenHitState >= kenHitPics.Length) {

                            ken = KenState.Idle;
                            kenIsHit = false;
                            kenHitState = 0;

                        }
                        break;
                    case KenState.HitReverse:
                        if (kenHitState == 0) {

                            if (kenRect.Y < 65) {

                                kenGoingDown = true;
                                kenHitState = 0;

                            } else kenHitState = 1;

                        }

                        if (kenHitState > 0) kenHitState++;

                        if (kenHitState >= kenHitPics.Length) {

                            ken = KenState.IdleReverse;
                            kenIsHit = false;
                            kenHitState = 0;

                        }
                        break;
                    case KenState.CrouchHit:
                        if (ryu == RyuState.IdleReverse || ryu == RyuState.WalkingForwardReverse || ryu == RyuState.WalkingBackwardReverse || ryu == RyuState.CrouchingReverse) {

                            ken = KenState.Crouching;
                            kenIsHit = false;

                        }
                        break;
                    case KenState.CrouchHitReverse:
                        if (ryu == RyuState.Idle || ryu == RyuState.WalkingForward || ryu == RyuState.WalkingBackward || ryu == RyuState.Crouching) {

                            ken = KenState.CrouchingReverse;
                            kenIsHit = false;

                        }
                        break;
                    case KenState.FaceHit:
                        if (kenFaceHitState == 0) {

                            if (kenRect.Y < 65) {

                                kenGoingDown = true;
                                kenFaceHitState = 0;

                            } else kenFaceHitState = 1;

                        }

                        if (kenFaceHitState > 0) kenFaceHitState++;

                        if (kenFaceHitState >= kenFaceHitPics.Length) {

                            ken = KenState.Idle;
                            kenIsHit = false;
                            kenFaceHitState = 0;

                        }
                        break;
                    case KenState.FaceHitReverse:
                        if (kenFaceHitState == 0) {

                            if (kenRect.Y < 65) {

                                kenFaceHitState = 0;
                                kenGoingDown = true;

                            } else kenFaceHitState = 1;

                        }

                        if (kenFaceHitState > 0) kenFaceHitState++;

                        if (kenFaceHitState >= kenFaceHitPics.Length) {

                            ken = KenState.IdleReverse;
                            kenIsHit = false;
                            kenFaceHitState = 0;

                        }
                        break;
                    case KenState.Knockdown:
                        if (kenKnockdownState == 0) {

                            if (kenRect.Y < 65) {

                                kenGoingDown = true;

                            } else kenKnockdownState = 1;

                        }

                        if (kenKnockdownState > 0 && kenKnockdownState <= 4) {

                            if (kenKnockdownState != 4) kenKnockdownState++;
                            else {

                                kenKnockdownCount++;
                                if (kenKnockdownCount == 10) {

                                    kenKnockdownState++;
                                    kenKnockdownCount = 0;

                                }

                            }

                            if (kenKnockdownState < 4) {

                                kenRect.X -= 60;

                            }

                        } else if (kenKnockdownState > 4) kenKnockdownState++;

                        if (kenKnockdownState >= kenKnockdownPics.Length) {

                            ken = KenState.Idle;
                            kenIsHit = false;
                            kenKnockdownState = 0;

                        }
                        break;
                    case KenState.KnockdownReverse:
                        if (kenKnockdownState == 0) {

                            if (kenRect.Y < 65) {

                                kenGoingDown = true;

                            } else kenKnockdownState = 1;

                        }

                        if (kenKnockdownState > 0 && kenKnockdownState <= 4) {

                            if (kenKnockdownState != 4) kenKnockdownState++;
                            else {

                                kenKnockdownCount++;
                                if (kenKnockdownCount == 10) {

                                    kenKnockdownState++;
                                    kenKnockdownCount = 0;

                                }

                            }

                            if (kenKnockdownState < 4) {

                                kenRect.X += 60;

                            }

                        } else if (kenKnockdownState > 4) kenKnockdownState++;

                        if (kenKnockdownState >= kenKnockdownPics.Length) {

                            ken = KenState.IdleReverse;
                            kenIsHit = false;
                            kenKnockdownState = 0;

                        }
                        break;

                }

                switch (ryu) {

                    case RyuState.Hit:
                        if (ryuHitState == 0) {

                            if (ryuRect.Y < 65) ryuGoingDown = true;
                            else ryuHitState = 1;

                        }

                        if (ryuHitState > 0) ryuHitState++;

                        if (ryuHitState >= ryuHitPics.Length) {

                            ryu = RyuState.Idle;
                            ryuIsHit = false;
                            ryuHitState = 0;

                        }
                        break;
                    case RyuState.HitReverse:
                        if (ryuHitState == 0) {

                            if (ryuRect.Y < 65) ryuGoingDown = true;
                            else ryuHitState = 1;

                        }

                        if (ryuHitState > 0) ryuHitState++;

                        if (ryuHitState >= ryuHitPics.Length) {

                            ryu = RyuState.IdleReverse;
                            ryuIsHit = false;
                            ryuHitState = 0;

                        }
                        break;
                    case RyuState.CrouchHit:
                        if (ken == KenState.IdleReverse || ken == KenState.WalkingForwardReverse || ken == KenState.WalkingBackwardReverse || ken == KenState.CrouchingReverse) {

                                ryu = RyuState.Crouching;
                                ryuIsHit = false;

                        }
                        break;
                    case RyuState.CrouchHitReverse:
                        if (ken == KenState.Idle || ken == KenState.WalkingForward || ken == KenState.WalkingBackward || ken == KenState.Crouching) {

                            ryu = RyuState.CrouchingReverse;
                            ryuIsHit = false;

                        }
                        break;
                    case RyuState.FaceHit:
                        if (ryuFaceHitState == 0) {

                            if (ryuRect.Y < 65) {

                                ryu = RyuState.Hit;
                                ryuGoingDown = true;

                            } else ryuFaceHitState = 1;

                        }

                        if (ryuFaceHitState > 0) ryuFaceHitState++;

                        if (ryuFaceHitState >= ryuFaceHitPics.Length) {

                            ryu = RyuState.Idle;
                            ryuIsHit = false;
                            ryuFaceHitState = 0;

                        }
                        break;
                    case RyuState.FaceHitReverse:
                        if (ryuFaceHitState == 0) {

                            if (ryuRect.Y < 65) {

                                ryu = RyuState.HitReverse;
                                ryuGoingDown = true;

                            } else ryuFaceHitState = 1;

                        }

                        if (ryuFaceHitState > 0) ryuFaceHitState++;

                        if (ryuFaceHitState >= ryuFaceHitPics.Length) {

                            ryu = RyuState.IdleReverse;
                            ryuIsHit = false;
                            ryuFaceHitState = 0;

                        }
                        break;
                    case RyuState.Knockdown:
                        if (ryuKnockdownState == 0) {

                            if (ryuRect.Y < 65) {

                                ryuGoingDown = true;

                            } else ryuKnockdownState = 1;

                        }

                        if (ryuKnockdownState > 0 && ryuKnockdownState <= 4) {

                            if (ryuKnockdownState != 4) ryuKnockdownState++;
                            else {

                                ryuKnockdownCount++;
                                if (ryuKnockdownCount == 10) {

                                    ryuKnockdownState++;
                                    ryuKnockdownCount = 0;

                                }

                            }

                            if (ryuKnockdownState < 4) {

                                ryuRect.X -= 60;

                            }

                        } else if (ryuKnockdownState > 4) ryuKnockdownState++;

                        if (ryuKnockdownState >= ryuKnockdownPics.Length) {

                            ryu = RyuState.Idle;
                            ryuIsHit = false;
                            ryuKnockdownState = 0;

                        }
                        break;
                    case RyuState.KnockdownReverse:
                        if (ryuKnockdownState == 0) {

                            if (ryuRect.Y < 65) {

                                ryuGoingDown = true;

                            } else ryuKnockdownState = 1;

                        }

                        if (ryuKnockdownState > 0 && ryuKnockdownState <= 4) {

                            if (ryuKnockdownState != 4) ryuKnockdownState++;
                            else {

                                ryuKnockdownCount++;
                                if (ryuKnockdownCount == 10) {

                                    ryuKnockdownState++;
                                    ryuKnockdownCount = 0;

                                }

                            }

                            if (ryuKnockdownState < 4) {

                                ryuRect.X += 60;

                            }

                        } else if (ryuKnockdownState > 4) ryuKnockdownState++;

                        if (ryuKnockdownState >= ryuKnockdownPics.Length) {

                            ryu = RyuState.IdleReverse;
                            ryuIsHit = false;
                            ryuKnockdownState = 0;

                        }
                        break;

                }

            }

            //When they're hit mid-air
            if (kenGoingDown) {

                if (kenFacingRight) ken = KenState.Knockdown;
                else ken = KenState.KnockdownReverse;

                if (kenFacingRight) kenRect.X -= 2;
                else kenRect.X += 2;

                kenRect.Y += 6;

                if (kenRect.Y >= 65) {

                    kenRect.Y = 65;
                    kenGoingDown = false;
                    kenKnockdownState = 1;

                }

            }

            if (ryuGoingDown) {

                if (kenFacingRight) ryu = RyuState.KnockdownReverse;
                else ryu = RyuState.Knockdown;

                if (kenFacingRight) ryuRect.X += 2;
                else ryuRect.X -= 2;

                ryuRect.Y += 6;
                
                if (ryuRect.Y >= 65) {

                    ryuRect.Y = 65;
                    ryuGoingDown = false;
                    ryuKnockdownState = 1;

                }

            }


            //Sets isBlock to false when the attack is done
            if (ken == KenState.Idle || ken == KenState.IdleReverse ||
                ken == KenState.WalkingForward || ken == KenState.WalkingForwardReverse ||
                ken == KenState.WalkingBackward || ken == KenState.WalkingBackwardReverse ||
                ken == KenState.Crouching || ken == KenState.CrouchingReverse) {

                ryuIsBlock = false;

            }
            if (ryu == RyuState.Idle || ryu == RyuState.IdleReverse ||
                ryu == RyuState.WalkingForward || ryu == RyuState.WalkingForwardReverse ||
                ryu == RyuState.WalkingBackward || ryu == RyuState.WalkingBackwardReverse ||
                ryu == RyuState.Crouching || ryu == RyuState.CrouchingReverse) {

                kenIsBlock = false;

            }


            if (kenIsBlock) {

                if (kenFacingRight) {

                    if (kenCrouching) ken = KenState.CrouchBlock;
                    else ken = KenState.Block;

                } else {

                    if (kenCrouching) ken = KenState.CrouchBlockReverse;
                    else ken = KenState.BlockReverse;

                }

            }

            if (ryuIsBlock) {

                if (kenFacingRight) {

                    if (ryuCrouching) ryu = RyuState.CrouchBlockReverse;
                    else ryu = RyuState.BlockReverse;

                } else {

                    if (ryuCrouching) ryu = RyuState.CrouchBlock;
                    else ryu = RyuState.Block;

                }

            }

            if (kenHadoukenBlock) {

                if (kenFacingRight) {

                    if (kenCrouching) ken = KenState.CrouchBlock;
                    else ken = KenState.Block;

                } else {

                    if (kenCrouching) ken = KenState.CrouchBlockReverse;
                    else ken = KenState.BlockReverse;

                }

                kenHadoukenBlockCounter++;

                if (kenHadoukenBlockCounter == blockDuration) {

                    kenHadoukenBlock = false;

                }

            }

            if (ryuHadoukenBlock) {

                if (kenFacingRight) {

                    if (ryuCrouching) ryu = RyuState.CrouchBlockReverse;
                    else ryu = RyuState.BlockReverse;

                } else {

                    if (ryuCrouching) ryu = RyuState.CrouchBlock;
                    else ryu = RyuState.Block;

                }

                ryuHadoukenBlockCounter++;

                if (ryuHadoukenBlockCounter == blockDuration) {

                    ryuHadoukenBlock = false;

                }

            }
            

            //Knockdown after 3 hits in 3 seconds
            if (kenHitCounter > 0) {

                kenHitTimeCounter++;

                if (kenHitCounter == 3 && kenHitTimeCounter <= 180) {

                    if (kenFacingRight) ken = KenState.Knockdown;
                    else ken = KenState.KnockdownReverse;

                    kenHitCounter = 0;
                    kenHitTimeCounter = 0;

                }

                if (kenHitTimeCounter > 180) {

                    kenHitCounter = 0;
                    kenHitTimeCounter = 0;

                }

            }

            if (ryuHitCounter > 0) {

                ryuHitTimeCounter++;

                if (ryuHitCounter == 3 && ryuHitTimeCounter <= 180) {

                    if (!kenFacingRight) ryu = RyuState.Knockdown;
                    else ryu = RyuState.KnockdownReverse;

                    ryuHitCounter = 0;
                    ryuHitTimeCounter = 0;

                }

                if (ryuHitTimeCounter > 180) {

                    ryuHitCounter = 0;
                    ryuHitTimeCounter = 0;

                }

            }

            //Animations for idle and walking
            ticks++;
            kenAfterActionCount++;
            ryuAfterActionCount++;

            if (ticks % movementSeparation == 0) {

                switch (ken) {

                    case KenState.Idle:
                        kenIdleState++;
                        kenWalkingState = 0;
                        if (kenIdleState == kenIdlePics.Length) kenIdleState = 0;
                        break;
                    case KenState.IdleReverse:
                        kenIdleState++;
                        kenWalkingState = 0;
                        if (kenIdleState == kenIdlePics.Length) kenIdleState = 0;
                        break;
                    case KenState.WalkingForward:
                        kenWalkingState++;
                        if (kenWalkingState == kenWalkingPics.Length) kenWalkingState = 0;
                        break;
                    case KenState.WalkingForwardReverse:
                        kenWalkingState++;
                        if (kenWalkingState == kenWalkingPics.Length) kenWalkingState = 0;
                        break;
                    case KenState.WalkingBackward:
                        kenWalkingState--;
                        if (kenWalkingState == -1) kenWalkingState = kenWalkingPics.Length - 1;
                        break;
                    case KenState.WalkingBackwardReverse:
                        kenWalkingState--;
                        if (kenWalkingState == -1) kenWalkingState = kenWalkingPics.Length - 1;
                        break;
                    default:
                        break;

                }

                switch (ryu) {

                    case RyuState.Idle:
                        ryuIdleState++;
                        ryuWalkingState = 0;
                        if (ryuIdleState == ryuIdlePics.Length) ryuIdleState = 0;
                        break;
                    case RyuState.IdleReverse:
                        ryuIdleState++;
                        ryuWalkingState = 0;
                        if (ryuIdleState == ryuIdlePics.Length) ryuIdleState = 0;
                        break;
                    case RyuState.WalkingForward:
                        ryuWalkingState++;
                        if (ryuWalkingState == ryuWalkingPics.Length) ryuWalkingState = 0;
                        break;
                    case RyuState.WalkingForwardReverse:
                        ryuWalkingState++;
                        if (ryuWalkingState == ryuWalkingPics.Length) ryuWalkingState = 0;
                        break;
                    case RyuState.WalkingBackward:
                        ryuWalkingState--;
                        if (ryuWalkingState == -1) ryuWalkingState = ryuWalkingPics.Length - 1;
                        break;
                    case RyuState.WalkingBackwardReverse:
                        ryuWalkingState--;
                        if (ryuWalkingState == -1) ryuWalkingState = ryuWalkingPics.Length - 1;
                        break;
                    default:
                        break;

                }

            }

            //Animation for jumping
            if (ticks % jumpSeparation == 0 && (ken == KenState.Jumping || ken == KenState.JumpingReverse)) {

                switch (kenJumpState) {
                    case 0:
                        kenRect.Y -= jumpIncrementHeight;
                        break;
                    case 1: 
                        kenRect.Y -= jumpIncrementHeight;
                        break;
                    case 2:
                        kenRect.Y -= jumpIncrementHeight;
                        break;
                    case 4:
                        kenRect.Y += jumpIncrementHeight;
                        break;
                    case 5:
                        kenRect.Y += jumpIncrementHeight;
                        break;
                    case 6:
                        kenRect.Y += jumpIncrementHeight;
                        break;
                }


                kenJumpState++;

                if (kenJumpState == 7) {

                    kenJumpState = 0;
                    kenAfterActionCount = 0;
                    if (ken == KenState.Jumping) ken = KenState.Idle;
                    if (ken == KenState.JumpingReverse) ken = KenState.IdleReverse;

                }   

            }

            if (ticks % jumpSeparation == 0 && (ryu == RyuState.Jumping || ryu == RyuState.JumpingReverse)) {

                switch (ryuJumpState) {
                    case 0:
                        ryuRect.Y -= jumpIncrementHeight;
                        break;
                    case 1:
                        ryuRect.Y -= jumpIncrementHeight;
                        break;
                    case 2:
                        ryuRect.Y -= jumpIncrementHeight;
                        break;
                    case 4:
                        ryuRect.Y += jumpIncrementHeight;
                        break;
                    case 5:
                        ryuRect.Y += jumpIncrementHeight;
                        break;
                    case 6:
                        ryuRect.Y += jumpIncrementHeight;
                        break;
                }


                ryuJumpState++;

                if (ryuJumpState == 7) {

                    ryuJumpState = 0;
                    ryuAfterActionCount = 0;
                    if (ryu == RyuState.Jumping) ryu = RyuState.Idle;
                    if (ryu == RyuState.JumpingReverse) ryu = RyuState.IdleReverse;

                }

            }


            //Animation for forward jumping
            if (ticks % jumpSeparation == 0 && (ken == KenState.ForwardJumping || ken == KenState.ForwardJumpingReverse)) {

                switch (kenForwardJumpState) {
                    case 0:
                        kenRect.Y -= jumpIncrementHeight;
                        break;
                    case 1:
                        kenRect.Y -= jumpIncrementHeight;
                        break;
                    case 2:
                        kenRect.Y -= jumpIncrementHeight;
                        break;
                    case 3:
                        kenRect.Y += jumpIncrementHeight;
                        break;
                    case 4:
                        kenRect.Y += jumpIncrementHeight;
                        break;
                    case 5:
                        kenRect.Y += jumpIncrementHeight;
                        break;
                }

                kenForwardJumpState++;
                if (ken == KenState.ForwardJumping) kenRect.X += 30;
                if (ken == KenState.ForwardJumpingReverse) kenRect.X -= 30;
               

                if (kenForwardJumpState == 6) {

                    kenForwardJumpState = 0;
                    kenAfterActionCount = 0;
                    if (ken == KenState.ForwardJumping) ken = KenState.Idle;
                    if (ken == KenState.ForwardJumpingReverse) ken = KenState.IdleReverse;

                }

            }



            if (ticks % jumpSeparation == 0 && (ryu == RyuState.ForwardJumping || ryu == RyuState.ForwardJumpingReverse)) {

                switch (ryuForwardJumpState) {
                    case 0:
                        ryuRect.Y -= jumpIncrementHeight;
                        break;
                    case 1:
                        ryuRect.Y -= jumpIncrementHeight;
                        break;
                    case 2:
                        ryuRect.Y -= jumpIncrementHeight;
                        break;
                    case 3:
                        ryuRect.Y += jumpIncrementHeight;
                        break;
                    case 4:
                        ryuRect.Y += jumpIncrementHeight;
                        break;
                    case 5:
                        ryuRect.Y += jumpIncrementHeight;
                        break;
                }

                ryuForwardJumpState++;
                if (ryu == RyuState.ForwardJumping) ryuRect.X += 30;
                if (ryu == RyuState.ForwardJumpingReverse) ryuRect.X -= 30;


                if (ryuForwardJumpState == 6) {

                    ryuForwardJumpState = 0;
                    ryuAfterActionCount = 0;
                    if (ryu == RyuState.ForwardJumping) ryu = RyuState.Idle;
                    if (ryu == RyuState.ForwardJumpingReverse) ryu = RyuState.IdleReverse;

                }

            }

            //Animation for backward jumping
            if (ticks % jumpSeparation == 0 && (ken == KenState.BackwardJumping || ken == KenState.BackwardJumpingReverse)) {

                switch (kenBackwardJumpState) {
                    case 0:
                        kenRect.Y += jumpIncrementHeight;
                        break;
                    case 1:
                        kenRect.Y += jumpIncrementHeight;
                        break;
                    case 2:
                        kenRect.Y += jumpIncrementHeight;
                        break;
                    case 3:
                        kenRect.Y -= jumpIncrementHeight;
                        break;
                    case 4:
                        kenRect.Y -= jumpIncrementHeight;
                        break;
                    case 5:
                        kenRect.Y -= jumpIncrementHeight;
                        break;
                }


                kenBackwardJumpState--;
                if (ken == KenState.BackwardJumping) kenRect.X -= 30;
                if (ken == KenState.BackwardJumpingReverse) kenRect.X += 30;

                if (kenBackwardJumpState == -1) {

                    kenBackwardJumpState = 5;
                    kenAfterActionCount = 0;
                    if (ken == KenState.BackwardJumping) ken = KenState.Idle;
                    if (ken == KenState.BackwardJumpingReverse) ken = KenState.IdleReverse;

                }

            }

            if (ticks % jumpSeparation == 0 && (ryu == RyuState.BackwardJumping || ryu == RyuState.BackwardJumpingReverse)) {

                switch (ryuBackwardJumpState) {
                    case 0:
                        ryuRect.Y += jumpIncrementHeight;
                        break;
                    case 1:
                        ryuRect.Y += jumpIncrementHeight;
                        break;
                    case 2:
                        ryuRect.Y += jumpIncrementHeight;
                        break;
                    case 3:
                        ryuRect.Y -= jumpIncrementHeight;
                        break;
                    case 4:
                        ryuRect.Y -= jumpIncrementHeight;
                        break;
                    case 5:
                        ryuRect.Y -= jumpIncrementHeight;
                        break;
                }


                ryuBackwardJumpState--;
                if (ryu == RyuState.BackwardJumping) ryuRect.X -= 30;
                if (ryu == RyuState.BackwardJumpingReverse) ryuRect.X += 30;

                if (ryuBackwardJumpState == -1) {

                    ryuBackwardJumpState = 5;
                    ryuAfterActionCount = 0;
                    if (ryu == RyuState.BackwardJumping) ryu = RyuState.Idle;
                    if (ryu == RyuState.BackwardJumpingReverse) ryu = RyuState.IdleReverse;

                }

            }

            //Movement for walking
            switch (ken) {

                case KenState.WalkingForward:
                    kenRect.X += 3;
                    break;
                case KenState.WalkingBackward:
                    kenRect.X -= 3;
                    break;
                case KenState.WalkingForwardReverse:
                    kenRect.X -= 3;
                    break;
                case KenState.WalkingBackwardReverse:
                    kenRect.X += 3;
                    break;

            }

            switch (ryu) {

                case RyuState.WalkingForward:
                    ryuRect.X += 3;
                    break;
                case RyuState.WalkingBackward:
                    ryuRect.X -= 3;
                    break;
                case RyuState.WalkingForwardReverse:
                    ryuRect.X -= 3;
                    break;
                case RyuState.WalkingBackwardReverse:
                    ryuRect.X += 3;
                    break;

            }

            //Animation for attacks
            if (ticks % attackSeparation == 0) {

                switch (ken) {

                    case KenState.LowPunch:
                        kenLowPunchState++;
                        if (kenLowPunchState == kenLowPunchPics.Length) {
                            kenLowPunchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.LowPunchCrouch:
                        kenLowPunchCrouchState++;
                        if (kenLowPunchCrouchState == kenLowMediumCrouchPunchPics.Length) {
                            kenLowPunchCrouchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Crouching;
                        }
                        break;
                    case KenState.ForwardLowPunch:
                        kenForwardLowPunchState++;
                        if (kenForwardLowPunchState == kenForwardLowPunchPics.Length) {
                            kenForwardLowPunchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.MediumPunch:
                        kenMediumPunchState++;
                        if (kenMediumPunchState == kenMediumHighPunchPics.Length) {
                            kenMediumPunchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.MediumPunchCrouch:
                        kenMediumPunchCrouchState++;
                        if (kenMediumPunchCrouchState == kenLowMediumCrouchPunchPics.Length) {
                            kenMediumPunchCrouchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Crouching;
                        }
                        break;
                    case KenState.ForwardMediumPunch:
                        kenForwardMediumPunchState++;
                        if (kenForwardMediumPunchState == kenForwardMediumPunchPics.Length) {
                            kenForwardMediumPunchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.HighPunch:
                        kenHighPunchState++;
                        if (kenHighPunchState == kenMediumHighPunchPics.Length) {
                            kenHighPunchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.HighPunchCrouch:
                        kenHighPunchCrouchState++;
                        if (kenHighPunchCrouchState == kenHighCrouchPunchPics.Length) {
                            kenHighPunchCrouchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Crouching;
                        }
                        break;
                    case KenState.ForwardHighPunch:
                        kenForwardHighPunchState++;
                        if (kenForwardHighPunchState == kenForwardHighPunchPics.Length) {
                            kenForwardHighPunchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.LowKick:
                        kenLowKickState++;
                        if (kenLowKickState == kenLowMediumKickPics.Length) {
                            kenLowKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.LowCrouchKick:
                        kenLowCrouchKickState++;
                        if (kenLowCrouchKickState == kenLowCrouchKickPics.Length) {
                            kenLowCrouchKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Crouching;
                        }
                        break;
                    case KenState.ForwardLowKick:
                        kenForwardLowKickState++;
                        if (kenForwardLowKickState == kenForwardLowKickPics.Length) {
                            kenForwardLowKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.MediumKick:
                        kenMediumKickState++;
                        if (kenMediumKickState == kenLowMediumKickPics.Length) {
                            kenMediumKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.MediumCrouchKick:
                        kenMediumCrouchKickState++;
                        if (kenMediumCrouchKickState == kenMediumCrouchKickPics.Length) {
                            kenMediumCrouchKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Crouching;
                        }
                        break;
                    case KenState.ForwardMediumKick:
                        kenForwardMediumKickState++;
                        if (kenForwardMediumKickState == kenForwardMediumKickPics.Length) {
                            kenForwardMediumKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.HighKick:
                         kenHighKickState++;
                        if (kenHighKickState == kenHighKickPics.Length) {
                            kenHighKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.HighCrouchKick:
                        kenHighCrouchKickState++;
                        if (kenHighCrouchKickState == kenHighCrouchKickPics.Length) {
                            kenHighCrouchKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Crouching;
                        }
                        break;
                    case KenState.ForwardHighKick:
                        kenForwardHighKickState++;
                        if (kenForwardHighKickState == kenForwardHighKickPics.Length) {
                            kenForwardHighKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.Hadouken:
                        if (kenHadoukenState != 3) kenHadoukenState++;

                        hadoukenHitboxKen.X = kenHadoukenRect.X + hadoukenX;
                        hadoukenHitboxKen.Y = kenHadoukenRect.Y;

                        if (kenHadoukenRect.X == kenInputHadoukenRectX + 300) {
                            kenHadoukenState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.Tatsumaki:
                        kenRect.X += 25;
                        kenTatsumakiState++;

                        tatsumakiHitboxKen.X = kenRect.X + tatsumakiX;
                        tatsumakiHitboxKen.Y = kenRect.Y + tatsumakiY;

                        if (kenTatsumakiState == kenTatsumakiPics.Length) {
                            kenTatsumakiState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.Shoryuken:
                        kenRect.X += 30;
                        kenShoryukenState++;

                        shoryukenHitboxKen.X = kenRect.X + shoryukenX;
                        shoryukenHitboxKen.Y = kenRect.Y + shoryukenY;

                        if (kenShoryukenState == kenShoryukenPics.Length) {
                            kenShoryukenState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.Idle;
                        }
                        break;
                    case KenState.LowPunchReverse:
                        kenLowPunchState++;
                        if (kenLowPunchState == kenLowPunchPics.Length) {
                            kenLowPunchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    case KenState.LowPunchCrouchReverse:
                        kenLowPunchCrouchState++;
                        if (kenLowPunchCrouchState == kenLowMediumCrouchPunchPics.Length) {
                            kenLowPunchCrouchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.CrouchingReverse;
                        }
                        break;
                    case KenState.ForwardLowPunchReverse:
                        kenForwardLowPunchState++;
                        if (kenForwardLowPunchState == kenForwardLowPunchPics.Length) {
                            kenForwardLowPunchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    case KenState.MediumPunchReverse:
                        kenMediumPunchState++;
                        if (kenMediumPunchState == kenMediumHighPunchPics.Length) {
                            kenMediumPunchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    case KenState.MediumPunchCrouchReverse:
                        kenMediumPunchCrouchState++;
                        if (kenMediumPunchCrouchState == kenLowMediumCrouchPunchPics.Length) {
                            kenMediumPunchCrouchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.CrouchingReverse;
                        }
                        break;
                    case KenState.ForwardMediumPunchReverse:
                        kenForwardMediumPunchState++;
                        if (kenForwardMediumPunchState == kenForwardMediumPunchPics.Length) {
                            kenForwardMediumPunchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    case KenState.HighPunchReverse:
                        kenHighPunchState++;
                        if (kenHighPunchState == kenMediumHighPunchPics.Length) {
                            kenHighPunchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    case KenState.HighPunchCrouchReverse:
                        kenHighPunchCrouchState++;
                        if (kenHighPunchCrouchState == kenHighCrouchPunchPics.Length) {
                            kenHighPunchCrouchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.CrouchingReverse;
                        }
                        break;
                    case KenState.ForwardHighPunchReverse:
                        kenForwardHighPunchState++;
                        if (kenForwardHighPunchState == kenForwardHighPunchPics.Length) {
                            kenForwardHighPunchState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    case KenState.LowKickReverse:
                        kenLowKickState++;
                        if (kenLowKickState == kenLowMediumKickPics.Length) {
                            kenLowKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    case KenState.LowCrouchKickReverse:
                        kenLowCrouchKickState++;
                        if (kenLowCrouchKickState == kenLowCrouchKickPics.Length) {
                            kenLowCrouchKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.CrouchingReverse;
                        }
                        break;
                    case KenState.ForwardLowKickReverse:
                        kenForwardLowKickState++;
                        if (kenForwardLowKickState == kenForwardLowKickPics.Length) {
                            kenForwardLowKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    case KenState.MediumKickReverse:
                        kenMediumKickState++;
                        if (kenMediumKickState == kenLowMediumKickPics.Length) {
                            kenMediumKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    case KenState.MediumCrouchKickReverse:
                        kenMediumCrouchKickState++;
                        if (kenMediumCrouchKickState == kenMediumCrouchKickPics.Length) {
                            kenMediumCrouchKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.CrouchingReverse;
                        }
                        break;
                    case KenState.ForwardMediumKickReverse:
                        kenForwardMediumKickState++;
                        if (kenForwardMediumKickState == kenForwardMediumKickPics.Length) {
                            kenForwardMediumKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    case KenState.HighKickReverse:
                        kenHighKickState++;
                        if (kenHighKickState == kenHighKickPics.Length) {
                            kenHighKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    case KenState.HighCrouchKickReverse:
                        kenHighCrouchKickState++;
                        if (kenHighCrouchKickState == kenHighCrouchKickPics.Length) {
                            kenHighCrouchKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.CrouchingReverse;
                        }
                        break;
                    case KenState.ForwardHighKickReverse:
                        kenForwardHighKickState++;
                        if (kenForwardHighKickState == kenForwardHighKickPics.Length) {
                            kenForwardHighKickState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    case KenState.HadoukenReverse:
                        if (kenHadoukenState != 3) kenHadoukenState++;

                        hadoukenHitboxKen.X = kenHadoukenRect.X + hadoukenReverseX;
                        hadoukenHitboxKen.Y = kenHadoukenRect.Y;

                        if (kenHadoukenRect.X == kenInputHadoukenRectX - 300) {
                            kenHadoukenState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    case KenState.TatsumakiReverse:
                        kenRect.X -= 25;

                        tatsumakiHitboxKen.X = kenRect.X + tatsumakiReverseX;
                        tatsumakiHitboxKen.Y = kenRect.Y + tatsumakiReverseY;

                        kenTatsumakiState++;
                        if (kenTatsumakiState == kenTatsumakiPics.Length) {
                            kenTatsumakiState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    case KenState.ShoryukenReverse:
                        kenRect.X -= 30;

                        shoryukenHitboxKen.X = kenRect.X + shoryukenReverseX;
                        shoryukenHitboxKen.Y = kenRect.Y + shoryukenReverseY;

                        kenShoryukenState++;
                        if (kenShoryukenState == kenShoryukenPics.Length) {
                            kenShoryukenState = 0;
                            kenAfterActionCount = 0;
                            ken = KenState.IdleReverse;
                        }
                        break;
                    default:
                        break;

                }

                switch (ryu) {

                    case RyuState.LowPunch:
                        ryuLowPunchState++;
                        if (ryuLowPunchState == ryuLowPunchPics.Length) {
                            ryuLowPunchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.LowPunchCrouch:
                        ryuLowPunchCrouchState++;
                        if (ryuLowPunchCrouchState == ryuLowMediumCrouchPunchPics.Length) {
                            ryuLowPunchCrouchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Crouching;
                        }
                        break;
                    case RyuState.ForwardLowPunch:
                        ryuForwardLowPunchState++;
                        if (ryuForwardLowPunchState == ryuForwardLowPunchPics.Length) {
                            ryuForwardLowPunchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.MediumPunch:
                        ryuMediumPunchState++;
                        if (ryuMediumPunchState == ryuMediumHighPunchPics.Length) {
                            ryuMediumPunchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.MediumPunchCrouch:
                        ryuMediumPunchCrouchState++;
                        if (ryuMediumPunchCrouchState == ryuLowMediumCrouchPunchPics.Length) {
                            ryuMediumPunchCrouchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Crouching;
                        }
                        break;
                    case RyuState.ForwardMediumPunch:
                        ryuForwardMediumPunchState++;
                        if (ryuForwardMediumPunchState == ryuForwardMediumPunchPics.Length) {
                            ryuForwardMediumPunchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.HighPunch:
                        ryuHighPunchState++;
                        if (ryuHighPunchState == ryuMediumHighPunchPics.Length) {
                            ryuHighPunchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.HighPunchCrouch:
                        ryuHighPunchCrouchState++;
                        if (ryuHighPunchCrouchState == ryuHighCrouchPunchPics.Length) {
                            ryuHighPunchCrouchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Crouching;
                        }
                        break;
                    case RyuState.ForwardHighPunch:
                        ryuForwardHighPunchState++;
                        if (ryuForwardHighPunchState == ryuForwardHighPunchPics.Length) {
                            ryuForwardHighPunchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.LowKick:
                        ryuLowKickState++;
                        if (ryuLowKickState == ryuLowMediumKickPics.Length) {
                            ryuLowKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.LowCrouchKick:
                        ryuLowCrouchKickState++;
                        if (ryuLowCrouchKickState == ryuLowCrouchKickPics.Length) {
                            ryuLowCrouchKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Crouching;
                        }
                        break;
                    case RyuState.ForwardLowKick:
                        ryuForwardLowKickState++;
                        if (ryuForwardLowKickState == ryuForwardLowKickPics.Length) {
                            ryuForwardLowKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.MediumKick:
                        ryuMediumKickState++;
                        if (ryuMediumKickState == ryuLowMediumKickPics.Length) {
                            ryuMediumKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.MediumCrouchKick:
                        ryuMediumCrouchKickState++;
                        if (ryuMediumCrouchKickState == ryuMediumCrouchKickPics.Length) {
                            ryuMediumCrouchKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Crouching;
                        }
                        break;
                    case RyuState.ForwardMediumKick:
                        ryuForwardMediumKickState++;
                        if (ryuForwardMediumKickState == ryuForwardMediumKickPics.Length) {
                            ryuForwardMediumKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.HighKick:
                        ryuHighKickState++;
                        if (ryuHighKickState == ryuHighKickPics.Length) {
                            ryuHighKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.HighCrouchKick:
                        ryuHighCrouchKickState++;
                        if (ryuHighCrouchKickState == ryuHighCrouchKickPics.Length) {
                            ryuHighCrouchKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Crouching;
                        }
                        break;
                    case RyuState.ForwardHighKick:
                        ryuForwardHighKickState++;
                        if (ryuForwardHighKickState == ryuForwardHighKickPics.Length) {
                            ryuForwardHighKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.Hadouken:
                        if (ryuHadoukenState != 3) ryuHadoukenState++;

                        hadoukenHitboxRyu.X = ryuHadoukenRect.X + hadoukenX;
                        hadoukenHitboxRyu.Y = ryuHadoukenRect.Y;

                        if (ryuHadoukenRect.X == ryuInputHadoukenRectX + 300) {
                            ryuHadoukenState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.Tatsumaki:
                        ryuRect.X += 25;

                        tatsumakiHitboxRyu.X = ryuRect.X + tatsumakiX;
                        tatsumakiHitboxRyu.Y = ryuRect.Y + tatsumakiY;

                        ryuTatsumakiState++;
                        if (ryuTatsumakiState == ryuTatsumakiPics.Length) {
                            ryuTatsumakiState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.Shoryuken:
                        ryuRect.X += 30;

                        shoryukenHitboxRyu.X = ryuRect.X + shoryukenX;
                        shoryukenHitboxRyu.Y = ryuRect.Y + shoryukenY;

                        ryuShoryukenState++;
                        if (ryuShoryukenState == ryuShoryukenPics.Length) {
                            ryuShoryukenState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.Idle;
                        }
                        break;
                    case RyuState.LowPunchReverse:
                        ryuLowPunchState++;
                        if (ryuLowPunchState == ryuLowPunchPics.Length) {
                            ryuLowPunchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    case RyuState.LowPunchCrouchReverse:
                        ryuLowPunchCrouchState++;
                        if (ryuLowPunchCrouchState == ryuLowMediumCrouchPunchPics.Length) {
                            ryuLowPunchCrouchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.CrouchingReverse;
                        }
                        break;
                    case RyuState.ForwardLowPunchReverse:
                        ryuForwardLowPunchState++;
                        if (ryuForwardLowPunchState == ryuForwardLowPunchPics.Length) {
                            ryuForwardLowPunchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    case RyuState.MediumPunchReverse:
                        ryuMediumPunchState++;
                        if (ryuMediumPunchState == ryuMediumHighPunchPics.Length) {
                            ryuMediumPunchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    case RyuState.MediumPunchCrouchReverse:
                        ryuMediumPunchCrouchState++;
                        if (ryuMediumPunchCrouchState == ryuLowMediumCrouchPunchPics.Length) {
                            ryuMediumPunchCrouchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.CrouchingReverse;
                        }
                        break;
                    case RyuState.ForwardMediumPunchReverse:
                        ryuForwardMediumPunchState++;
                        if (ryuForwardMediumPunchState == ryuForwardMediumPunchPics.Length) {
                            ryuForwardMediumPunchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    case RyuState.HighPunchReverse:
                        ryuHighPunchState++;
                        if (ryuHighPunchState == ryuMediumHighPunchPics.Length) {
                            ryuHighPunchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    case RyuState.HighPunchCrouchReverse:
                        ryuHighPunchCrouchState++;
                        if (ryuHighPunchCrouchState == ryuHighCrouchPunchPics.Length) {
                            ryuHighPunchCrouchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.CrouchingReverse;
                        }
                        break;
                    case RyuState.ForwardHighPunchReverse:
                        ryuForwardHighPunchState++;
                        if (ryuForwardHighPunchState == ryuForwardHighPunchPics.Length) {
                            ryuForwardHighPunchState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    case RyuState.LowKickReverse:
                        ryuLowKickState++;
                        if (ryuLowKickState == ryuLowMediumKickPics.Length) {
                            ryuLowKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    case RyuState.LowCrouchKickReverse:
                        ryuLowCrouchKickState++;
                        if (ryuLowCrouchKickState == ryuLowCrouchKickPics.Length) {
                            ryuLowCrouchKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.CrouchingReverse;
                        }
                        break;
                    case RyuState.ForwardLowKickReverse:
                        ryuForwardLowKickState++;
                        if (ryuForwardLowKickState == ryuForwardLowKickPics.Length) {
                            ryuForwardLowKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    case RyuState.MediumKickReverse:
                        ryuMediumKickState++;
                        if (ryuMediumKickState == ryuLowMediumKickPics.Length) {
                            ryuMediumKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    case RyuState.MediumCrouchKickReverse:
                        ryuMediumCrouchKickState++;
                        if (ryuMediumCrouchKickState == ryuMediumCrouchKickPics.Length) {
                            ryuMediumCrouchKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.CrouchingReverse;
                        }
                        break;
                    case RyuState.ForwardMediumKickReverse:
                        ryuForwardMediumKickState++;
                        if (ryuForwardMediumKickState == ryuForwardMediumKickPics.Length) {
                            ryuForwardMediumKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    case RyuState.HighKickReverse:
                        ryuHighKickState++;
                        if (ryuHighKickState == ryuHighKickPics.Length) {
                            ryuHighKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    case RyuState.HighCrouchKickReverse:
                        ryuHighCrouchKickState++;
                        if (ryuHighCrouchKickState == ryuHighCrouchKickPics.Length) {
                            ryuHighCrouchKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.CrouchingReverse;
                        }
                        break;
                    case RyuState.ForwardHighKickReverse:
                        ryuForwardHighKickState++;
                        if (ryuForwardHighKickState == ryuForwardHighKickPics.Length) {
                            ryuForwardHighKickState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    case RyuState.HadoukenReverse:
                        if (ryuHadoukenState != 3) ryuHadoukenState++;

                        hadoukenHitboxRyu.X = ryuHadoukenRect.X + hadoukenReverseX;
                        hadoukenHitboxRyu.Y = ryuHadoukenRect.Y;

                        if (ryuHadoukenRect.X == ryuInputHadoukenRectX - 300) {
                            ryuHadoukenState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    case RyuState.TatsumakiReverse:
                        ryuRect.X -= 25;
                        ryuTatsumakiState++;

                        tatsumakiHitboxRyu.X = ryuRect.X + tatsumakiReverseX;
                        tatsumakiHitboxRyu.Y = ryuRect.Y + tatsumakiReverseY;

                        if (ryuTatsumakiState == ryuTatsumakiPics.Length) {
                            ryuTatsumakiState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    case RyuState.ShoryukenReverse:
                        ryuRect.X -= 30;
                        ryuShoryukenState++;

                        shoryukenHitboxRyu.X = ryuRect.X + shoryukenReverseX;
                        shoryukenHitboxRyu.Y = ryuRect.Y + shoryukenReverseY;

                        if (ryuShoryukenState == ryuShoryukenPics.Length) {
                            ryuShoryukenState = 0;
                            ryuAfterActionCount = 0;
                            ryu = RyuState.IdleReverse;
                        }
                        break;
                    default:
                        break;

                }

                if (kenHadoukenState == 3 && ken == KenState.Hadouken) kenHadoukenRect.X += 30;
                if (ryuHadoukenState == 3 && ryu == RyuState.Hadouken) ryuHadoukenRect.X += 30;

                if (kenHadoukenState == 3 && ken == KenState.HadoukenReverse) kenHadoukenRect.X -= 30;
                if (ryuHadoukenState == 3 && ryu == RyuState.HadoukenReverse) ryuHadoukenRect.X -= 30;

            }

            //Boundaries of the map
            if (kenRect.X < -150) kenRect.X = -150;
            if (kenRect.X > 550) kenRect.X = 550;
            if (ryuRect.X < -150) ryuRect.X = -150;
            if (ryuRect.X > 550) ryuRect.X = 550;


            //Checks so they dont run across each other
            if (kenHitboxMovementRect.Intersects(ryuHitboxMovementRect) && kenFacingRight) {

                if (ken != KenState.Idle) kenRect.X -= 3;
                if (ryu != RyuState.IdleReverse) ryuRect.X += 3;

                if (ken == KenState.Idle && ryu == RyuState.IdleReverse) {

                    kenRect.X -= 3;
                    ryuRect.X += 3;

                }

            }

            if (kenHitboxMovementRect.Intersects(ryuHitboxMovementRect) && !kenFacingRight) {

                if (ken != KenState.IdleReverse) kenRect.X += 3;
                if (ryu != RyuState.Idle) ryuRect.X -= 3;

                if (ken == KenState.IdleReverse && ryu == RyuState.Idle) {

                    kenRect.X += 3;
                    ryuRect.X -= 3;

                }

            }


            //Changes movement hitbox depending on crouch and not
            if (kenFacingRight) {

                if (kenCrouching) {

                    kenHitboxMovementRect.X = kenRect.X + 160;
                    kenHitboxMovementRect.Y = kenRect.Y + 230;

                } else if (ken == KenState.Tatsumaki) {

                    kenHitboxMovementRect.X = kenRect.X + 140;
                    kenHitboxMovementRect.Y = kenRect.Y + 50;

                } else {

                    kenHitboxMovementRect.X = kenRect.X + 140;
                    kenHitboxMovementRect.Y = kenRect.Y + 150;

                }

                if (ryuCrouching) {

                    ryuHitboxMovementRect.X = ryuRect.X + 140;
                    ryuHitboxMovementRect.Y = ryuRect.Y + 230;


                } else if (ryu == RyuState.TatsumakiReverse) {

                    ryuHitboxMovementRect.X = ryuRect.X + 160;
                    ryuHitboxMovementRect.Y = ryuRect.Y + 50;

                } else {

                    ryuHitboxMovementRect.X = ryuRect.X + 160;
                    ryuHitboxMovementRect.Y = ryuRect.Y + 150;

                }

            } else {

                if (kenCrouching) {

                    kenHitboxMovementRect.X = kenRect.X + 140;
                    kenHitboxMovementRect.Y = kenRect.Y + 230;

                } else if (ken == KenState.TatsumakiReverse) {

                    kenHitboxMovementRect.X = kenRect.X + 160;
                    kenHitboxMovementRect.Y = kenRect.Y + 50;

                } else {

                    kenHitboxMovementRect.X = kenRect.X + 160;
                    kenHitboxMovementRect.Y = kenRect.Y + 150;

                }

                if (ryuCrouching) {

                    ryuHitboxMovementRect.X = ryuRect.X + 160;
                    ryuHitboxMovementRect.Y = ryuRect.Y + 230;


                } else if (ryu == RyuState.Tatsumaki) {

                    ryuHitboxMovementRect.X = ryuRect.X + 140;
                    ryuHitboxMovementRect.Y = ryuRect.Y + 50;

                } else {

                    ryuHitboxMovementRect.X = ryuRect.X + 140;
                    ryuHitboxMovementRect.Y = ryuRect.Y + 150;

                }

            }

            kenHealthBar.Width = kenHealth * 3;
            ryuHealthBar.Width = ryuHealth * 3;


            //Check for win
            if (kenHealth <= 0) {

                movementSeparation = 60;
                jumpSeparation = 60;
                attackSeparation = 60;
                afterActionPause = 60;
                hitSeparation = 60;

                endGame = true;

                if (kenFacingRight) {

                    ken = KenState.Knockout;

                    if (!deathSoundPlayed) {

                        kenDeathSound.Play();
                        deathSoundPlayed = true;

                    }

                } else {

                    ken = KenState.KnockoutReverse;

                    if (!deathSoundPlayed) {

                        kenDeathSound.Play();
                        deathSoundPlayed = true;

                    }

                }

            }

            if (ryuHealth <= 0) {

                movementSeparation = 60;
                jumpSeparation = 60;
                attackSeparation = 60;
                afterActionPause = 60;
                hitSeparation = 60;

                endGame = true;

                if (kenFacingRight) {

                    ryu = RyuState.KnockoutReverse;

                    if (!deathSoundPlayed) {

                        ryuDeathSound.Play();
                        deathSoundPlayed = true;

                    }

                } else {

                    ryu = RyuState.Knockout;

                    if (!deathSoundPlayed) {

                        ryuDeathSound.Play();
                        deathSoundPlayed = true;

                    }

                }

            }

            if (ticks % movementSeparation == 0) {

                switch (ken) {

                    case KenState.Knockout:
                        if (kenRect.Y < 65) {

                            kenRect.X -= 20;
                            kenRect.Y += 30;
                            if (kenRect.Y > 65) kenRect.Y = 65;

                        }

                        if (kenKnockoutState < kenKnockoutPics.Length - 1 && kenRect.Y == 65) {

                            kenKnockoutState++;
                            kenRect.X -= 40;

                        } else if (kenKnockoutState >= kenKnockoutPics.Length - 1 && kenRect.Y == 65) {

                            kenKnockoutState = kenKnockoutPics.Length - 1;
                            ryu = RyuState.VictoryReverse;

                        }

                        break;
                    case KenState.KnockoutReverse:
                        if (kenRect.Y < 65) {

                            kenRect.X += 20;
                            kenRect.Y += 30;
                            if (kenRect.Y > 65) kenRect.Y = 65;

                        }

                        if (kenKnockoutState < kenKnockoutPics.Length - 1 && kenRect.Y == 65) {

                            kenKnockoutState++;
                            kenRect.X += 40;

                        } else if (kenKnockoutState >= kenKnockoutPics.Length - 1 && kenRect.Y == 65) {

                            kenKnockoutState = kenKnockoutPics.Length - 1;
                            ryu = RyuState.Victory;

                        }
                        break;

                }

                switch (ryu) {

                    case RyuState.Knockout:
                        if (ryuRect.Y < 65) {

                            ryuRect.X -= 20;
                            ryuRect.Y += 30;
                            if (ryuRect.Y > 65) ryuRect.Y = 65;

                        }

                        if (ryuKnockoutState < ryuKnockoutPics.Length - 1 && ryuRect.Y == 65) {

                            ryuKnockoutState++;
                            ryuRect.X -= 40;

                        } else if (ryuKnockoutState >= ryuKnockoutPics.Length - 1 && ryuRect.Y == 65) {

                            ryuKnockoutState = ryuKnockoutPics.Length - 1;
                            ken = KenState.VictoryReverse;

                        } 
                        break;
                    case RyuState.KnockoutReverse:
                        if (ryuRect.Y < 65) {

                            ryuRect.X += 20;
                            ryuRect.Y += 30;
                            if (ryuRect.Y > 65) ryuRect.Y = 65;

                        }

                        if (ryuKnockoutState < ryuKnockoutPics.Length - 1 && ryuRect.Y == 65) {

                            ryuKnockoutState++;
                            ryuRect.X += 40;

                        } else if (ryuKnockoutState >= ryuKnockoutPics.Length - 1 && ryuRect.Y == 65) {

                            ryuKnockoutState = ryuKnockoutPics.Length - 1;
                            ken = KenState.Victory;

                        }
                        break;

                }

            }

            if (ticks % victorySeparation == 0) {

                switch (ken) {

                    case KenState.Victory:
                        if (kenVictoryState < kenVictoryPics.Length - 1 && ryuKnockoutState == ryuKnockoutPics.Length - 1) kenVictoryState++;

                        if (!victorySoundPlayed) {

                            narratorWin.Play();
                            victorySoundPlayed = true;

                        }
                        break;
                    case KenState.VictoryReverse:
                        if (kenVictoryState < kenVictoryPics.Length - 1 && ryuKnockoutState == ryuKnockoutPics.Length - 1) kenVictoryState++;

                        if (!victorySoundPlayed) {

                            narratorWin.Play();
                            victorySoundPlayed = true;

                        }
                        break;

                }

                switch (ryu) {

                    case RyuState.Victory:
                        if (ryuVictoryState < ryuVictoryPics.Length - 1 && kenKnockoutState == kenKnockoutPics.Length - 1) ryuVictoryState++;

                        if (!victorySoundPlayed) {

                            narratorWin.Play();
                            victorySoundPlayed = true;

                        }
                        break;
                    case RyuState.VictoryReverse:
                        if (ryuVictoryState < ryuVictoryPics.Length - 1 && kenKnockoutState == kenKnockoutPics.Length - 1) ryuVictoryState++;

                        if (!victorySoundPlayed) {

                            narratorWin.Play();
                            victorySoundPlayed = true;

                        }
                        break;

                }

            }

            if ((ken == KenState.Victory || ken == KenState.VictoryReverse || ryu == RyuState.Victory || ryu == RyuState.VictoryReverse) 
                && (pad1.Buttons.Start == ButtonState.Pressed || pad2.Buttons.Start == ButtonState.Pressed || kb.IsKeyDown(Keys.Enter))
                && (kenKnockoutState == kenKnockoutPics.Length - 1 || ryuKnockoutState == ryuKnockoutPics.Length - 1)) {

                kenHealth = 100;
                ryuHealth = 100;

                kenRect.X = 0;
                kenRect.Y = 65;

                ryuRect.X = 400;
                ryuRect.Y = 65;

                ryuHealthBar.X = 480;

                kenIsHit = false;
                ryuIsHit = false;

                kenKnockoutState = 0;
                kenVictoryState = 0;
                ryuKnockoutState = 0;
                ryuVictoryState = 0;

                deathSoundPlayed = false;
                victorySoundPlayed = false;
                endGame = false;

                movementSeparation = 8;
                jumpSeparation = 5;
                attackSeparation = 6;
                afterActionPause = 10;
                hitSeparation = 10;

                ken = KenState.Idle;
                ryu = RyuState.IdleReverse;

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(background, backgroundRect, Color.White);

            switch (ken) {
                case KenState.Idle:
                    spriteBatch.Draw(kenIdlePics[kenIdleState], kenRect, Color.White);
                    break;
                case KenState.WalkingForward:
                    spriteBatch.Draw(kenWalkingPics[kenWalkingState], kenRect, Color.White);
                    break;
                case KenState.WalkingBackward:
                    spriteBatch.Draw(kenWalkingPics[kenWalkingState], kenRect, Color.White);
                    break;
                case KenState.Jumping:
                    spriteBatch.Draw(kenJumpingPics[kenJumpState], kenRect, Color.White);
                    break;
                case KenState.Crouching:
                    spriteBatch.Draw(kenCrouchPic, kenRect, Color.White);
                    break;
                case KenState.ForwardJumping:
                    spriteBatch.Draw(kenForwardJumpingPics[kenForwardJumpState], kenRect, Color.White);
                    break;
                case KenState.BackwardJumping:
                    spriteBatch.Draw(kenForwardJumpingPics[kenBackwardJumpState], kenRect, Color.White);
                    break;
                case KenState.LowPunch:
                    spriteBatch.Draw(kenLowPunchPics[kenLowPunchState], kenRect, Color.White);
                    break;
                case KenState.LowPunchCrouch:
                    spriteBatch.Draw(kenLowMediumCrouchPunchPics[kenLowPunchCrouchState], kenRect, Color.White);
                    break;
                case KenState.ForwardLowPunch:
                    spriteBatch.Draw(kenForwardLowPunchPics[kenForwardLowPunchState], kenRect, Color.White);
                    break;
                case KenState.MediumPunch:
                    spriteBatch.Draw(kenMediumHighPunchPics[kenMediumPunchState], kenRect, Color.White);
                    break;
                case KenState.MediumPunchCrouch:
                    spriteBatch.Draw(kenLowMediumCrouchPunchPics[kenMediumPunchCrouchState], kenRect, Color.White);
                    break;
                case KenState.ForwardMediumPunch:
                    spriteBatch.Draw(kenForwardMediumPunchPics[kenForwardMediumPunchState], kenRect, Color.White);
                    break;
                case KenState.HighPunch:
                    spriteBatch.Draw(kenMediumHighPunchPics[kenHighPunchState], kenRect, Color.White);
                    break;
                case KenState.HighPunchCrouch:
                    spriteBatch.Draw(kenHighCrouchPunchPics[kenHighPunchCrouchState], kenRect, Color.White);
                    break;
                case KenState.ForwardHighPunch:
                    spriteBatch.Draw(kenForwardHighPunchPics[kenForwardHighPunchState], kenRect, Color.White);
                    break;
                case KenState.LowKick:
                    spriteBatch.Draw(kenLowMediumKickPics[kenLowKickState], kenRect, Color.White);
                    break;
                case KenState.LowCrouchKick:
                    spriteBatch.Draw(kenLowCrouchKickPics[kenLowCrouchKickState], kenRect, Color.White);
                    break;
                case KenState.ForwardLowKick:
                    spriteBatch.Draw(kenForwardLowKickPics[kenForwardLowKickState], kenRect, Color.White);
                    break;
                case KenState.MediumKick:
                    spriteBatch.Draw(kenLowMediumKickPics[kenMediumKickState], kenRect, Color.White);
                    break;
                case KenState.MediumCrouchKick:
                    spriteBatch.Draw(kenMediumCrouchKickPics[kenMediumCrouchKickState], kenRect, Color.White);
                    break;
                case KenState.ForwardMediumKick:
                    spriteBatch.Draw(kenForwardMediumKickPics[kenForwardMediumKickState], kenRect, Color.White);
                    break;
                case KenState.HighKick:
                    spriteBatch.Draw(kenHighKickPics[kenHighKickState], kenRect, Color.White);
                    break;
                case KenState.HighCrouchKick:
                    spriteBatch.Draw(kenHighCrouchKickPics[kenHighCrouchKickState], kenRect, Color.White);
                    break;
                case KenState.ForwardHighKick:
                    spriteBatch.Draw(kenForwardHighKickPics[kenForwardHighKickState], kenRect, Color.White);
                    break;
                case KenState.Hadouken:
                    spriteBatch.Draw(kenHadoukenPics[kenHadoukenState], kenRect, Color.White);
                    if (kenHadoukenState == 3) spriteBatch.Draw(kenHadoukenProjectilePics[1], kenHadoukenRect, Color.White);
                    break;
                case KenState.Tatsumaki:
                    spriteBatch.Draw(kenTatsumakiPics[kenTatsumakiState], kenRect, Color.White);
                    break;
                case KenState.Shoryuken:
                    spriteBatch.Draw(kenShoryukenPics[kenShoryukenState], kenRect, Color.White);
                    break;
                case KenState.IdleReverse:
                    spriteBatch.Draw(kenIdlePics[kenIdleState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.WalkingForwardReverse:
                    spriteBatch.Draw(kenWalkingPics[kenWalkingState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.WalkingBackwardReverse:
                    spriteBatch.Draw(kenWalkingPics[kenWalkingState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.JumpingReverse:
                    spriteBatch.Draw(kenJumpingPics[kenJumpState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.CrouchingReverse:
                    spriteBatch.Draw(kenCrouchPic, kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.ForwardJumpingReverse:
                    spriteBatch.Draw(kenForwardJumpingPics[kenForwardJumpState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.BackwardJumpingReverse:
                    spriteBatch.Draw(kenForwardJumpingPics[kenBackwardJumpState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.LowPunchReverse:
                    spriteBatch.Draw(kenLowPunchPics[kenLowPunchState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.LowPunchCrouchReverse:
                    spriteBatch.Draw(kenLowMediumCrouchPunchPics[kenLowPunchCrouchState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.ForwardLowPunchReverse:
                    spriteBatch.Draw(kenForwardLowPunchPics[kenForwardLowPunchState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.MediumPunchReverse:
                    spriteBatch.Draw(kenMediumHighPunchPics[kenMediumPunchState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.MediumPunchCrouchReverse:
                    spriteBatch.Draw(kenLowMediumCrouchPunchPics[kenMediumPunchCrouchState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.ForwardMediumPunchReverse:
                    spriteBatch.Draw(kenForwardMediumPunchPics[kenForwardMediumPunchState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.HighPunchReverse:
                    spriteBatch.Draw(kenMediumHighPunchPics[kenHighPunchState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.HighPunchCrouchReverse:
                    spriteBatch.Draw(kenHighCrouchPunchPics[kenHighPunchCrouchState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.ForwardHighPunchReverse:
                    spriteBatch.Draw(kenForwardHighPunchPics[kenForwardHighPunchState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.LowKickReverse:
                    spriteBatch.Draw(kenLowMediumKickPics[kenLowKickState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.LowCrouchKickReverse:
                    spriteBatch.Draw(kenLowCrouchKickPics[kenLowCrouchKickState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.ForwardLowKickReverse:
                    spriteBatch.Draw(kenForwardLowKickPics[kenForwardLowKickState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.MediumKickReverse:
                    spriteBatch.Draw(kenLowMediumKickPics[kenMediumKickState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.MediumCrouchKickReverse:
                    spriteBatch.Draw(kenMediumCrouchKickPics[kenMediumCrouchKickState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.ForwardMediumKickReverse:
                    spriteBatch.Draw(kenForwardMediumKickPics[kenForwardMediumKickState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.HighKickReverse:
                    spriteBatch.Draw(kenHighKickPics[kenHighKickState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.HighCrouchKickReverse:
                    spriteBatch.Draw(kenHighCrouchKickPics[kenHighCrouchKickState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.ForwardHighKickReverse:
                    spriteBatch.Draw(kenForwardHighKickPics[kenForwardHighKickState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.HadoukenReverse:
                    spriteBatch.Draw(kenHadoukenPics[kenHadoukenState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    if (kenHadoukenState == 3) spriteBatch.Draw(kenHadoukenProjectilePics[1], kenHadoukenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.TatsumakiReverse:
                    spriteBatch.Draw(kenTatsumakiPics[kenTatsumakiState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.ShoryukenReverse:
                    spriteBatch.Draw(kenShoryukenPics[kenShoryukenState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.Block:
                    spriteBatch.Draw(kenBlockPic, kenRect, Color.White);
                    break;
                case KenState.BlockReverse:
                    spriteBatch.Draw(kenBlockPic, kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.CrouchBlock:
                    spriteBatch.Draw(kenBlockCrouchPic, kenRect, Color.White);
                    break;
                case KenState.CrouchBlockReverse:
                    spriteBatch.Draw(kenBlockCrouchPic, kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.Hit:
                    spriteBatch.Draw(kenHitPics[kenHitState], kenRect, Color.White);
                    break;
                case KenState.HitReverse:
                    spriteBatch.Draw(kenHitPics[kenHitState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.FaceHit:
                    spriteBatch.Draw(kenFaceHitPics[kenFaceHitState], kenRect, Color.White);
                    break;
                case KenState.FaceHitReverse:
                    spriteBatch.Draw(kenFaceHitPics[kenFaceHitState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.CrouchHit:
                    spriteBatch.Draw(kenCrouchHitPic, kenRect, Color.White);
                    break;
                case KenState.CrouchHitReverse:
                    spriteBatch.Draw(kenCrouchHitPic, kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.Knockdown:
                    spriteBatch.Draw(kenKnockdownPics[kenKnockdownState], kenRect, Color.White);
                    break;
                case KenState.KnockdownReverse:
                    spriteBatch.Draw(kenKnockdownPics[kenKnockdownState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.Knockout:
                    spriteBatch.Draw(kenKnockoutPics[kenKnockoutState], kenRect, Color.White);
                    break;
                case KenState.KnockoutReverse:
                    spriteBatch.Draw(kenKnockoutPics[kenKnockoutState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case KenState.Victory:
                    spriteBatch.Draw(kenVictoryPics[kenVictoryState], kenRect, Color.White);

                    if (ryuKnockoutState == ryuKnockoutPics.Length - 1) {

                        winMessage = "Ken Wins!";
                        spriteBatch.DrawString(textFont, winMessage, winMessageVector, Color.Yellow);
                        spriteBatch.DrawString(textFont, playAgainMessage, playAgainMessageVector, Color.Yellow);

                    }
                    break;
                case KenState.VictoryReverse:
                    spriteBatch.Draw(kenVictoryPics[kenVictoryState], kenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);

                    if (ryuKnockoutState == ryuKnockoutPics.Length - 1) {

                        winMessage = "Ken Wins!";
                        spriteBatch.DrawString(textFont, winMessage, winMessageVector, Color.Yellow);
                        spriteBatch.DrawString(textFont, playAgainMessage, playAgainMessageVector, Color.Yellow);

                    }
                    break;
            }

            switch (ryu) {
                case RyuState.Idle:
                    spriteBatch.Draw(ryuIdlePics[ryuIdleState], ryuRect, Color.White);
                    break;
                case RyuState.WalkingForward:
                    spriteBatch.Draw(ryuWalkingPics[ryuWalkingState], ryuRect, Color.White);
                    break;
                case RyuState.WalkingBackward:
                    spriteBatch.Draw(ryuWalkingPics[ryuWalkingState], ryuRect, Color.White);
                    break;
                case RyuState.Jumping:
                    spriteBatch.Draw(ryuJumpingPics[ryuJumpState], ryuRect, Color.White);
                    break;
                case RyuState.Crouching:
                    spriteBatch.Draw(ryuCrouchPic, ryuRect, Color.White);
                    break;
                case RyuState.ForwardJumping:
                    spriteBatch.Draw(ryuForwardJumpingPics[ryuForwardJumpState], ryuRect, Color.White);
                    break;
                case RyuState.BackwardJumping:
                    spriteBatch.Draw(ryuForwardJumpingPics[ryuBackwardJumpState], ryuRect, Color.White);
                    break;
                case RyuState.LowPunch:
                    spriteBatch.Draw(ryuLowPunchPics[ryuLowPunchState], ryuRect, Color.White);
                    break;
                case RyuState.LowPunchCrouch:
                    spriteBatch.Draw(ryuLowMediumCrouchPunchPics[ryuLowPunchCrouchState], ryuRect, Color.White);
                    break;
                case RyuState.ForwardLowPunch:
                    spriteBatch.Draw(ryuForwardLowPunchPics[ryuForwardLowPunchState], ryuRect, Color.White);
                    break;
                case RyuState.MediumPunch:
                    spriteBatch.Draw(ryuMediumHighPunchPics[ryuMediumPunchState], ryuRect, Color.White);
                    break;
                case RyuState.MediumPunchCrouch:
                    spriteBatch.Draw(ryuLowMediumCrouchPunchPics[ryuMediumPunchCrouchState], ryuRect, Color.White);
                    break;
                case RyuState.ForwardMediumPunch:
                    spriteBatch.Draw(ryuForwardMediumPunchPics[ryuForwardMediumPunchState], ryuRect, Color.White);
                    break;
                case RyuState.HighPunch:
                    spriteBatch.Draw(ryuMediumHighPunchPics[ryuHighPunchState], ryuRect, Color.White);
                    break;
                case RyuState.HighPunchCrouch:
                    spriteBatch.Draw(ryuHighCrouchPunchPics[ryuHighPunchCrouchState], ryuRect, Color.White);
                    break;
                case RyuState.ForwardHighPunch:
                    spriteBatch.Draw(ryuForwardHighPunchPics[ryuForwardHighPunchState], ryuRect, Color.White);
                    break;
                case RyuState.LowKick:
                    spriteBatch.Draw(ryuLowMediumKickPics[ryuLowKickState], ryuRect, Color.White);
                    break;
                case RyuState.LowCrouchKick:
                    spriteBatch.Draw(ryuLowCrouchKickPics[ryuLowCrouchKickState], ryuRect, Color.White);
                    break;
                case RyuState.ForwardLowKick:
                    spriteBatch.Draw(ryuForwardLowKickPics[ryuForwardLowKickState], ryuRect, Color.White);
                    break;
                case RyuState.MediumKick:
                    spriteBatch.Draw(ryuLowMediumKickPics[ryuMediumKickState], ryuRect, Color.White);
                    break;
                case RyuState.MediumCrouchKick:
                    spriteBatch.Draw(ryuMediumCrouchKickPics[ryuMediumCrouchKickState], ryuRect, Color.White);
                    break;
                case RyuState.ForwardMediumKick:
                    spriteBatch.Draw(ryuForwardMediumKickPics[ryuForwardMediumKickState], ryuRect, Color.White);
                    break;
                case RyuState.HighKick:
                    spriteBatch.Draw(ryuHighKickPics[ryuHighKickState], ryuRect, Color.White);
                    break;
                case RyuState.HighCrouchKick:
                    spriteBatch.Draw(ryuHighCrouchKickPics[ryuHighCrouchKickState], ryuRect, Color.White);
                    break;
                case RyuState.ForwardHighKick:
                    spriteBatch.Draw(ryuForwardHighKickPics[ryuForwardHighKickState], ryuRect, Color.White);
                    break;
                case RyuState.Hadouken:
                    spriteBatch.Draw(ryuHadoukenPics[ryuHadoukenState], ryuRect, Color.White);
                    if (ryuHadoukenState == 3) spriteBatch.Draw(ryuHadoukenProjectilePics[1], ryuHadoukenRect, Color.White);
                    break;
                case RyuState.Tatsumaki:
                    spriteBatch.Draw(ryuTatsumakiPics[ryuTatsumakiState], ryuRect, Color.White);
                    break;
                case RyuState.Shoryuken:
                    spriteBatch.Draw(ryuShoryukenPics[ryuShoryukenState], ryuRect, Color.White);
                    break;
                case RyuState.IdleReverse:
                    spriteBatch.Draw(ryuIdlePics[ryuIdleState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.WalkingForwardReverse:
                    spriteBatch.Draw(ryuWalkingPics[ryuWalkingState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.WalkingBackwardReverse:
                    spriteBatch.Draw(ryuWalkingPics[ryuWalkingState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.JumpingReverse:
                    spriteBatch.Draw(ryuJumpingPics[ryuJumpState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.CrouchingReverse:
                    spriteBatch.Draw(ryuCrouchPic, ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.ForwardJumpingReverse:
                    spriteBatch.Draw(ryuForwardJumpingPics[ryuForwardJumpState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.BackwardJumpingReverse:
                    spriteBatch.Draw(ryuForwardJumpingPics[ryuBackwardJumpState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.LowPunchReverse:
                    spriteBatch.Draw(ryuLowPunchPics[ryuLowPunchState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.LowPunchCrouchReverse:
                    spriteBatch.Draw(ryuLowMediumCrouchPunchPics[ryuLowPunchCrouchState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.ForwardLowPunchReverse:
                    spriteBatch.Draw(ryuForwardLowPunchPics[ryuForwardLowPunchState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.MediumPunchReverse:
                    spriteBatch.Draw(ryuMediumHighPunchPics[ryuMediumPunchState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.MediumPunchCrouchReverse:
                    spriteBatch.Draw(ryuLowMediumCrouchPunchPics[ryuMediumPunchCrouchState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.ForwardMediumPunchReverse:
                    spriteBatch.Draw(ryuForwardMediumPunchPics[ryuForwardMediumPunchState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.HighPunchReverse:
                    spriteBatch.Draw(ryuMediumHighPunchPics[ryuHighPunchState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.HighPunchCrouchReverse:
                    spriteBatch.Draw(ryuHighCrouchPunchPics[ryuHighPunchCrouchState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.ForwardHighPunchReverse:
                    spriteBatch.Draw(ryuForwardHighPunchPics[ryuForwardHighPunchState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.LowKickReverse:
                    spriteBatch.Draw(ryuLowMediumKickPics[ryuLowKickState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.LowCrouchKickReverse:
                    spriteBatch.Draw(ryuLowCrouchKickPics[ryuLowCrouchKickState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.ForwardLowKickReverse:
                    spriteBatch.Draw(ryuForwardLowKickPics[ryuForwardLowKickState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.MediumKickReverse:
                    spriteBatch.Draw(ryuLowMediumKickPics[ryuMediumKickState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.MediumCrouchKickReverse:
                    spriteBatch.Draw(ryuMediumCrouchKickPics[ryuMediumCrouchKickState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.ForwardMediumKickReverse:
                    spriteBatch.Draw(ryuForwardMediumKickPics[ryuForwardMediumKickState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.HighKickReverse:
                    spriteBatch.Draw(ryuHighKickPics[ryuHighKickState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.HighCrouchKickReverse:
                    spriteBatch.Draw(ryuHighCrouchKickPics[ryuHighCrouchKickState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.ForwardHighKickReverse:
                    spriteBatch.Draw(ryuForwardHighKickPics[ryuForwardHighKickState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.HadoukenReverse:
                    spriteBatch.Draw(ryuHadoukenPics[ryuHadoukenState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    if (ryuHadoukenState == 3) spriteBatch.Draw(ryuHadoukenProjectilePics[1], ryuHadoukenRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.TatsumakiReverse:
                    spriteBatch.Draw(ryuTatsumakiPics[ryuTatsumakiState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.ShoryukenReverse:
                    spriteBatch.Draw(ryuShoryukenPics[ryuShoryukenState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.Block:
                    spriteBatch.Draw(ryuBlockPic, ryuRect, Color.White);
                    break;
                case RyuState.BlockReverse:
                    spriteBatch.Draw(ryuBlockPic, ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.CrouchBlock:
                    spriteBatch.Draw(ryuBlockCrouchPic, ryuRect, Color.White);
                    break;
                case RyuState.CrouchBlockReverse:
                    spriteBatch.Draw(ryuBlockCrouchPic, ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.Hit:
                    spriteBatch.Draw(ryuHitPics[ryuHitState], ryuRect, Color.White);
                    break;
                case RyuState.HitReverse:
                    spriteBatch.Draw(ryuHitPics[ryuHitState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.FaceHit:
                    spriteBatch.Draw(ryuFaceHitPics[ryuFaceHitState], ryuRect, Color.White);
                    break;
                case RyuState.FaceHitReverse:
                    spriteBatch.Draw(ryuFaceHitPics[ryuFaceHitState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.CrouchHit:
                    spriteBatch.Draw(ryuCrouchHitPic, ryuRect, Color.White);
                    break;
                case RyuState.CrouchHitReverse:
                    spriteBatch.Draw(ryuCrouchHitPic, ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.Knockdown:
                    spriteBatch.Draw(ryuKnockdownPics[ryuKnockdownState], ryuRect, Color.White);
                    break;
                case RyuState.KnockdownReverse:
                    spriteBatch.Draw(ryuKnockdownPics[ryuKnockdownState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.Knockout:
                    spriteBatch.Draw(ryuKnockoutPics[ryuKnockoutState], ryuRect, Color.White);
                    break;
                case RyuState.KnockoutReverse:
                    spriteBatch.Draw(ryuKnockoutPics[ryuKnockoutState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);
                    break;
                case RyuState.Victory:
                    spriteBatch.Draw(ryuVictoryPics[ryuVictoryState], ryuRect, Color.White);

                    if (kenKnockoutState == kenKnockoutPics.Length - 1) {

                        winMessage = "Ryu Wins!";
                        spriteBatch.DrawString(textFont, winMessage, winMessageVector, Color.Yellow);
                        spriteBatch.DrawString(textFont, playAgainMessage, playAgainMessageVector, Color.Yellow);

                    }
                    break;
                case RyuState.VictoryReverse:
                    spriteBatch.Draw(ryuVictoryPics[ryuVictoryState], ryuRect, null, Color.White, 0f, new Vector2(0, 0), flip, 0f);

                    if (kenKnockoutState == kenKnockoutPics.Length - 1) {

                        winMessage = "Ryu Wins!";
                        spriteBatch.DrawString(textFont, winMessage, winMessageVector, Color.Yellow);
                        spriteBatch.DrawString(textFont, playAgainMessage, playAgainMessageVector, Color.Yellow);

                    }
                    break;
            }

            /*
            spriteBatch.Draw(hitboxMovementPic, kenHitboxMovementRect, Color.White);
            spriteBatch.Draw(hitboxMovementPic, ryuHitboxMovementRect, Color.White);

            spriteBatch.Draw(hitboxAttackPic, lowPunchHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, mediumPunchHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, highPunchHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, lowKickHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, mediumKickHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, highKickHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, crouchLowPunchHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, crouchMediumPunchHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, crouchHighPunchHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, crouchLowKickHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, crouchMediumKickHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, crouchHighKickHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, forwardLowPunchHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, forwardMediumPunchHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, forwardHighPunchHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, forwardLowKickHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, forwardMediumKickHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, forwardHighKickHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, hadoukenHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, tatsumakiHitboxKen, Color.White);
            spriteBatch.Draw(hitboxAttackPic, shoryukenHitboxKen, Color.White);

            spriteBatch.Draw(hitboxAttackPic, lowPunchHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, mediumPunchHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, highPunchHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, lowKickHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, mediumKickHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, highKickHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, crouchLowPunchHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, crouchMediumPunchHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, crouchHighPunchHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, crouchLowKickHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, crouchMediumKickHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, crouchHighKickHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, forwardLowPunchHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, forwardMediumPunchHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, forwardHighPunchHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, forwardLowKickHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, forwardMediumKickHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, forwardHighKickHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, hadoukenHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, tatsumakiHitboxRyu, Color.White);
            spriteBatch.Draw(hitboxAttackPic, shoryukenHitboxRyu, Color.White);
            */
            

            if (kenHealth > 60) spriteBatch.Draw(healthBar[0], kenHealthBar, Color.White);
            else if (kenHealth > 20) spriteBatch.Draw(healthBar[1], kenHealthBar, Color.White);
            else spriteBatch.Draw(healthBar[2], kenHealthBar, Color.White);

            if (ryuHealth > 60) spriteBatch.Draw(healthBar[0], ryuHealthBar, Color.White);
            else if (ryuHealth > 20) spriteBatch.Draw(healthBar[1], ryuHealthBar, Color.White);
            else spriteBatch.Draw(healthBar[2], ryuHealthBar, Color.White);

            spriteBatch.DrawString(titleFont, "Ken", kenNameVector, Color.Yellow);
            spriteBatch.DrawString(titleFont, "Ryu", ryuNameVector, Color.Yellow);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void clearKenHitBoxes() {

            lowPunchHitboxKen.X = -1000; lowPunchHitboxKen.Y = -1000;
            mediumPunchHitboxKen.X = -1000; mediumPunchHitboxKen.Y = -1000;
            highPunchHitboxKen.X = -1000; highPunchHitboxKen.Y = -1000;
            lowKickHitboxKen.X = -1000; lowKickHitboxKen.Y = -1000;
            mediumKickHitboxKen.X = -1000; mediumKickHitboxKen.Y = -1000;
            highKickHitboxKen.X = -1000; highKickHitboxKen.Y = -1000;
            crouchLowPunchHitboxKen.X = -1000; crouchLowPunchHitboxKen.Y = -1000;
            crouchMediumPunchHitboxKen.X = -1000; crouchMediumPunchHitboxKen.Y = -1000;
            crouchHighPunchHitboxKen.X = -1000; crouchHighPunchHitboxKen.Y = -1000;
            crouchLowKickHitboxKen.X = -1000; crouchLowKickHitboxKen.Y = -1000;
            crouchMediumKickHitboxKen.X = -1000; crouchMediumKickHitboxKen.Y = -1000;
            crouchHighKickHitboxKen.X = -1000; crouchHighKickHitboxKen.Y = -1000;
            forwardLowPunchHitboxKen.X = -1000; forwardLowPunchHitboxKen.Y = -1000;
            forwardMediumPunchHitboxKen.X = -1000; forwardMediumPunchHitboxKen.Y = -1000;
            forwardHighPunchHitboxKen.X = -1000; forwardHighPunchHitboxKen.Y = -1000;
            forwardLowKickHitboxKen.X = -1000; forwardLowKickHitboxKen.Y = -1000;
            forwardMediumKickHitboxKen.X = -1000; forwardMediumKickHitboxKen.Y = -1000;
            forwardHighKickHitboxKen.X = -1000; forwardHighKickHitboxKen.Y = -200;
            hadoukenHitboxKen.X = -1000; hadoukenHitboxKen.Y = -1000;
            tatsumakiHitboxKen.X = -1000; tatsumakiHitboxKen.Y = -1000;
            shoryukenHitboxKen.X = -1000; shoryukenHitboxKen.Y = -1000;

        }

        public void clearRyuHitBoxes() {

            lowPunchHitboxRyu.X = -1000; lowPunchHitboxRyu.Y = -1000;
            mediumPunchHitboxRyu.X = -1000; mediumPunchHitboxRyu.Y = -1000;
            highPunchHitboxRyu.X = -1000; highPunchHitboxRyu.Y = -1000;
            lowKickHitboxRyu.X = -1000; lowKickHitboxRyu.Y = -1000;
            mediumKickHitboxRyu.X = -1000; mediumKickHitboxRyu.Y = -1000;
            highKickHitboxRyu.X = -1000; highKickHitboxRyu.Y = -1000;
            crouchLowPunchHitboxRyu.X = -1000; crouchLowPunchHitboxRyu.Y = -1000;
            crouchMediumPunchHitboxRyu.X = -1000; crouchMediumPunchHitboxRyu.Y = -1000;
            crouchHighPunchHitboxRyu.X = -1000; crouchHighPunchHitboxRyu.Y = -1000;
            crouchLowKickHitboxRyu.X = -1000; crouchLowKickHitboxRyu.Y = -1000;
            crouchMediumKickHitboxRyu.X = -1000; crouchMediumKickHitboxRyu.Y = -1000;
            crouchHighKickHitboxRyu.X = -1000; crouchHighKickHitboxRyu.Y = -1000;
            forwardLowPunchHitboxRyu.X = -1000; forwardLowPunchHitboxRyu.Y = -1000;
            forwardMediumPunchHitboxRyu.X = -1000; forwardMediumPunchHitboxRyu.Y = -1000;
            forwardHighPunchHitboxRyu.X = -1000; forwardHighPunchHitboxRyu.Y = -1000;
            forwardLowKickHitboxRyu.X = -1000; forwardLowKickHitboxRyu.Y = -1000;
            forwardMediumKickHitboxRyu.X = -1000; forwardMediumKickHitboxRyu.Y = -1000;
            forwardHighKickHitboxRyu.X = -1000; forwardHighKickHitboxRyu.Y = -200;
            hadoukenHitboxRyu.X = -1000; hadoukenHitboxRyu.Y = -1000;
            tatsumakiHitboxRyu.X = -1000; tatsumakiHitboxRyu.Y = -1000;
            shoryukenHitboxRyu.X = -1000; shoryukenHitboxRyu.Y = -1000;

        }

        public void checkKenState() {

            kenActionIsNotRunning = ken != KenState.Jumping && ken != KenState.ForwardJumping && ken != KenState.BackwardJumping
                && ken != KenState.LowPunch && ken != KenState.LowPunchCrouch
                && ken != KenState.MediumPunch && ken != KenState.MediumPunchCrouch
                && ken != KenState.HighPunch && ken != KenState.HighPunchCrouch
                && ken != KenState.ForwardLowPunch && ken != KenState.ForwardMediumPunch && ken != KenState.ForwardHighPunch
                && ken != KenState.LowKick && ken != KenState.LowCrouchKick
                && ken != KenState.MediumKick && ken != KenState.MediumCrouchKick
                && ken != KenState.HighKick && ken != KenState.HighCrouchKick
                && ken != KenState.ForwardLowKick && ken != KenState.ForwardMediumKick && ken != KenState.ForwardHighKick
                && ken != KenState.Hadouken && ken != KenState.Tatsumaki && ken != KenState.Shoryuken
                && ken != KenState.JumpingReverse && ken != KenState.ForwardJumpingReverse && ken != KenState.BackwardJumpingReverse
                && ken != KenState.LowPunchReverse && ken != KenState.LowPunchCrouchReverse
                && ken != KenState.MediumPunchReverse && ken != KenState.MediumPunchCrouchReverse
                && ken != KenState.HighPunchReverse && ken != KenState.HighPunchCrouchReverse
                && ken != KenState.ForwardLowPunchReverse && ken != KenState.ForwardMediumPunchReverse && ken != KenState.ForwardHighPunchReverse
                && ken != KenState.LowKickReverse && ken != KenState.LowCrouchKickReverse
                && ken != KenState.MediumKickReverse && ken != KenState.MediumCrouchKickReverse
                && ken != KenState.HighKickReverse && ken != KenState.HighCrouchKickReverse
                && ken != KenState.ForwardLowKickReverse && ken != KenState.ForwardMediumKickReverse && ken != KenState.ForwardHighKickReverse
                && ken != KenState.HadoukenReverse && ken != KenState.TatsumakiReverse && ken != KenState.ShoryukenReverse
                && ken != KenState.Hit && ken != KenState.HitReverse && ken != KenState.FaceHit && ken != KenState.FaceHitReverse
                && ken != KenState.CrouchHit && ken != KenState.CrouchHitReverse && ken != KenState.Knockdown && ken != KenState.KnockdownReverse
                && ken != KenState.Knockout && ken != KenState.KnockoutReverse && ken != KenState.Victory && ken != KenState.VictoryReverse
                && !kenIsBlock && !kenHadoukenBlock;

        }

        public void checkRyuState() {

            ryuActionIsNotRunning = ryu != RyuState.Jumping && ryu != RyuState.ForwardJumping && ryu != RyuState.BackwardJumping
                && ryu != RyuState.LowPunch && ryu != RyuState.LowPunchCrouch
                && ryu != RyuState.MediumPunch && ryu != RyuState.MediumPunchCrouch
                && ryu != RyuState.HighPunch && ryu != RyuState.HighPunchCrouch
                && ryu != RyuState.ForwardLowPunch && ryu != RyuState.ForwardMediumPunch && ryu != RyuState.ForwardHighPunch
                && ryu != RyuState.LowKick && ryu != RyuState.LowCrouchKick
                && ryu != RyuState.MediumKick && ryu != RyuState.MediumCrouchKick
                && ryu != RyuState.HighKick && ryu != RyuState.HighCrouchKick
                && ryu != RyuState.ForwardLowKick && ryu != RyuState.ForwardMediumKick && ryu != RyuState.ForwardHighKick
                && ryu != RyuState.Hadouken && ryu != RyuState.Tatsumaki && ryu != RyuState.Shoryuken
                && ryu != RyuState.JumpingReverse && ryu != RyuState.ForwardJumpingReverse && ryu != RyuState.BackwardJumpingReverse
                && ryu != RyuState.LowPunchReverse && ryu != RyuState.LowPunchCrouchReverse
                && ryu != RyuState.MediumPunchReverse && ryu != RyuState.MediumPunchCrouchReverse
                && ryu != RyuState.HighPunchReverse && ryu != RyuState.HighPunchCrouchReverse
                && ryu != RyuState.ForwardLowPunchReverse && ryu != RyuState.ForwardMediumPunchReverse && ryu != RyuState.ForwardHighPunchReverse
                && ryu != RyuState.LowKickReverse && ryu != RyuState.LowCrouchKickReverse
                && ryu != RyuState.MediumKickReverse && ryu != RyuState.MediumCrouchKickReverse
                && ryu != RyuState.HighKickReverse && ryu != RyuState.HighCrouchKickReverse
                && ryu != RyuState.ForwardLowKickReverse && ryu != RyuState.ForwardMediumKickReverse && ryu != RyuState.ForwardHighKickReverse
                && ryu != RyuState.HadoukenReverse && ryu != RyuState.TatsumakiReverse && ryu != RyuState.ShoryukenReverse
                && ryu != RyuState.Hit && ryu != RyuState.HitReverse && ryu != RyuState.FaceHit && ryu != RyuState.FaceHitReverse
                && ryu != RyuState.CrouchHit && ryu != RyuState.CrouchHitReverse && ryu != RyuState.Knockdown && ryu != RyuState.KnockdownReverse
                && ryu != RyuState.Knockout && ryu != RyuState.KnockoutReverse && ryu != RyuState.Victory && ryu != RyuState.VictoryReverse
                && !ryuIsBlock && !ryuHadoukenBlock;

        }

    }

}