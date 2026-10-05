# Genius BM Voice Recognition

**A Unity application for practising Bahasa Melayu reading through spoken answers and game-based progression.**

Genius BM Suara connects syllable and word prompts with speech-to-text, visual feedback, and player progress. It integrates educational question logic with an existing game framework and speech plugins. The Unity product name is `GBMSuara`.

## What the project demonstrates

- **Reading activities across three levels:** serialized question prefabs contain prompts such as `ba`, `bi`, and `baju`, with accepted transcript variants.
- **Speech integration:** an Android speech-recognition callback passes recognized text into the question evaluator. A separate Whisper microphone integration is also included.
- **Immediate feedback and progression:** transcript similarity drives correct/incorrect feedback, audio cues, next-question controls, and round completion.
- **Multiple local player profiles:** player selection and progress are stored using Unity `PlayerPrefs`.
- **Online score integration:** client code submits scores and loads rankings through an external PHP service.

The source snapshot uses **Unity 2022.3.60f1**, **C#**, **TextMesh Pro**, **Unity UI**, and Android native plugins. Its configured application version is **2.0.7**.

## Learning flow

1. Select or create a player profile and choose a reading level.
2. Read the displayed prompt aloud through the microphone interaction.
3. A speech integration produces a text transcript.
4. The evaluator compares that transcript with the prompt's accepted variants.
5. Feedback and next-question controls guide progression; local counters track rewards and completed rounds.

The matching algorithm uses normalized **Levenshtein string similarity**. This measures how closely the recognized text matches an accepted answer; it is not an acoustic pronunciation score or a measured speech-model confidence value. Acceptance thresholds differ between the Android and Whisper integrations and, for Android, by level.

## Explore the implementation

| Area | Source |
| --- | --- |
| Prompts, feedback, and round completion | [QuestionController](Assets/QuestionController.cs) and [question prefabs](Assets/PrefabsQuestion/) |
| Transcript similarity and its UI | [SimilarityCalculator](Assets/SimilarityCalculator.cs) |
| Android speech callback and evaluation | [SpeechRecognizerDemo2](Assets/AndroidUltimatePlugin/SpeechTTS/Scripts/Example/SpeechRecognizerDemo2.cs) |
| Whisper recording and evaluation | [MicrophoneDemo](Assets/Samples/2%20-%20Microphone/MicrophoneDemo.cs) |
| Level selection | [LevelController](Assets/LevelController.cs) |
| Profiles and score submission | [PlayerInputController](Assets/PlayerInputController.cs) and [GameStartupController](Assets/GameStartupController.cs) |
| Rankings and profile selection UI | [TransformController](Assets/TransformController.cs) |
| Connectivity and speech UI activation | [CheckInternet](Assets/CheckInternet.cs) and [PluginController](Assets/PluginController.cs) |

## Open the project

1. Clone or download this repository and retain the complete `Assets`, `Packages`, and `ProjectSettings` directories, including Unity `.meta` files.
2. Open the repository root in Unity Hub using **2022.3.60f1**, as recorded in [ProjectVersion.txt](ProjectSettings/ProjectVersion.txt). Avoid an automatic editor upgrade for the first inspection.
3. Allow Unity to import assets and resolve the versions in [manifest.json](Packages/manifest.json) and [packages-lock.json](Packages/packages-lock.json).
4. **Before entering Play mode or testing on a device, review the external-service behavior below.** Prepare an isolated test backend and disposable test profiles before exercising network features.
5. Open [Home.unity](Assets/_Flippy_Journey/Scenes/Home.unity). The enabled scene order in [EditorBuildSettings.asset](ProjectSettings/EditorBuildSettings.asset) is `Home` → `Loading` → `Ingame` → `Character`.
6. For Android evaluation, use the corresponding Unity Android build support and a device with microphone permission and a compatible speech-recognition service. Device behavior must be verified separately from an Editor import.

### External services and player data

The PHP backend is not included in this repository. Endpoint strings are currently embedded in the client scripts:

- [GameStartupController](Assets/GameStartupController.cs) posts to `insertmark.php` under the configured `app-hanana.com/gbmsuara` service. At startup, an existing selected profile can trigger submission of its name, ID, progress counters, and device name.
- [TransformController](Assets/TransformController.cs) requests rankings from `fetchRanking.php`.
- [PlayerDeleteController](Assets/PlayerDeleteController.cs) requests server-side profile deletion through `fetchDelete.php`.

Review and replace these endpoint strings in an isolated test copy before a functional demo. Use disposable data and do not exercise deletion against the existing service. Service availability, authorization behavior, and response formats have not been validated by this documentation pass.

`PlayerPrefs` provides local persistence, not secure account authentication. Do not use real learner information for a portfolio demo.

### Speech dependencies

The Android integration defaults to `ms-MY` through the included locale mapping. The embedded [Whisper package metadata](Packages/com.whisper.unity/package.json) identifies `com.whisper.unity` version **1.3.2** by Macoron. The [Whisper prefab](Assets/PrefabsQuestion/mic/Whisper.prefab) is configured for language `ms` and a StreamingAssets-relative model path of `Whisper/ggml-tiny.bin`. That model file is absent from the inspected repository tree; supply a compatible model and verify its usage terms before testing that integration.

Including multiple recognizers does not establish a working offline fallback. The current `PluginController.ShowRightPlugin()` enables only its first configured plugin when connectivity is detected and disables both configured plugins when it is not. Confirm scene wiring and actual recognition behavior on a device.

## Project status

This README describes the checked-in source and configuration. It does not certify a successful Unity import, Android build, microphone session, backend connection, recognition accuracy, or learning outcome. No app or production-service requests were run during this documentation pass.

See the [demo verification checklist](docs/DEMO_CHECKLIST.md) for the remaining checks before recording a portfolio walkthrough.

## Included components and licensing

The repository includes third-party game assets/framework code under [`Assets/_Flippy_Journey`](Assets/_Flippy_Journey/), Gigadrillgames Android Ultimate Plugin code under [`Assets/AndroidUltimatePlugin`](Assets/AndroidUltimatePlugin/), a separate [`SpeechRecognitionSystem`](Assets/SpeechRecognitionSystem/), and the embedded Whisper Unity package. These components should be credited separately from the application-specific integration and question logic.

Existing component notices include the [NativeShare license](Assets/_Flippy_Journey/Plugins/NativeShare/LICENSE.txt) and [font license](Assets/_Flippy_Journey/Fonts/Open%20Font%20License.markdown). The Whisper package metadata declares MIT licensing for that package. No repository-wide license grant is provided here; component licenses do not grant rights to every bundled asset. Confirm ownership and redistribution terms before reusing or republishing the project or distributing a build.
