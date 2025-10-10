// 代码生成时间: 2025-10-11 03:01:24
 * Following C# best practices for readability, error handling, maintenance, and extensibility.
 */

using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Maui.Media;

namespace MauiApp
{
    public class SoundManagerService
    {
        private readonly Dictionary<string, SoundPlayer> _sounds;
        private readonly string _soundsDirectory;

        public SoundManagerService(string soundsDirectory)
        {
            _sounds = new Dictionary<string, SoundPlayer>();
            _soundsDirectory = soundsDirectory;
        }

        // Play a sound effect by its name.
        public void PlaySound(string soundName)
        {
            if (string.IsNullOrEmpty(soundName))
            {
                throw new ArgumentException("Sound name cannot be null or empty.", nameof(soundName));
            }

            if (_sounds.TryGetValue(soundName, out var player))
            {
                player.Play();
            }
            else
            {
                throw new FileNotFoundException($"Sound file '{soundName}' not found in '{_soundsDirectory}'.");
            }
        }

        // Stop a currently playing sound effect.
        public void StopSound(string soundName)
        {
            if (_sounds.TryGetValue(soundName, out var player))
            {
                player.Stop();
            }
            else
            {
                throw new InvalidOperationException($"Sound '{soundName}' is not playing or does not exist.");
            }
        }

        // Pause a currently playing sound effect.
        public void PauseSound(string soundName)
        {
            if (_sounds.TryGetValue(soundName, out var player))
            {
                player.Pause();
            }
            else
            {
                throw new InvalidOperationException($"Sound '{soundName}' is not playing or does not exist.");
            }
        }

        // Load all sound effects from the specified directory.
        public void LoadSounds()
        {
            foreach (var file in Directory.GetFiles(_soundsDirectory))
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var player = new SoundPlayer(file);
                _sounds[fileName] = player;
            }
        }

        // Unload a sound effect from memory.
        public void UnloadSound(string soundName)
        {
            if (_sounds.ContainsKey(soundName))
            {
                _sounds[soundName].Dispose();
                _sounds.Remove(soundName);
            }
            else
            {
                throw new InvalidOperationException($"Sound '{soundName}' not loaded.");
            }
        }

        // Unload all sound effects from memory.
        public void UnloadAllSounds()
        {
            foreach (var player in _sounds.Values)
            {
                player.Dispose();
            }
            _sounds.Clear();
        }
    }
}
