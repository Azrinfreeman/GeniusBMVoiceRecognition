# Portfolio demo verification

These checks are pending. They describe a future validation session, not completed test results.

## Prepare an isolated session

- [ ] Import the full project in Unity 2022.3.60f1 and record any missing assets, native dependencies, or compilation errors.
- [ ] Review all `UnityWebRequest` calls. Replace the score, ranking, and profile-deletion endpoints with an isolated test service before Play mode or device testing.
- [ ] Use a disposable profile and device account; verify which profile fields and device information leave the app.
- [ ] Confirm redistribution rights for bundled game assets, plugins, fonts, models, and build content before sharing a build.

## Verify the learning flow

- [ ] Start from `Home` with the existing four-scene build order.
- [ ] Create and switch test profiles; verify local progress survives a restart.
- [ ] Select each of the three reading levels and inspect the correct question group.
- [ ] On Android, verify microphone permission, `ms-MY` recognition, cancellation, and behavior when recognition is unavailable.
- [ ] Try an accepted answer and an incorrect answer. Record the transcript, similarity feedback, audio cue, and next-question behavior.
- [ ] Complete a question group and check rewards and round progression.
- [ ] Test Wi-Fi, mobile-data, and disconnected behavior. Do not describe an offline fallback until it has been demonstrated.
- [ ] If showcasing Whisper, verify its model file, selected language, native libraries, microphone recording, and scene activation separately.
- [ ] Against the isolated backend only, verify score submission, rankings, and deletion using disposable profiles.

## Prepare portfolio evidence

- [ ] Capture screenshots or a short video from the actual running app, using disposable profile names.
- [ ] Record the editor version, target device, build outcome, and observed limitations alongside the demo.
- [ ] Describe transcript matching accurately; do not present its percentage as pronunciation accuracy or an educational effectiveness result.

## Repository follow-up

The current repository already tracks Mono crash reports/memory dumps and Burst debug output. The added ignore rules prevent matching new untracked files from being added; they do not remove existing tracked content or history. Review these artifacts separately before further distribution. Any deletion or history cleanup requires a separate decision.
