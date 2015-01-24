using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm
{
	class Program
	{
		public const string DEVICE_NAME = "Speakers (High Definition Audio";
		public const int PLAY_COUNT = 3;
		public const string FILE_PATH = "C:\\Users\\Hayden\\Music\\Hawaiian.wav";
		static void Main(string[] args)
		{
			int deviceIndex = 0;
			Console.WriteLine("# Audio Devices: " + WaveOut.DeviceCount);
			for (var i = 0; i < WaveOut.DeviceCount; i++)
			{
				var capabilities = WaveOut.GetCapabilities(i);
				Console.WriteLine("Device " + i + ": " + capabilities.ProductName);
				if (capabilities.ProductName == DEVICE_NAME)
				{
					deviceIndex = i;
					break;
				}
				
			}
			// Play it!
			var reader = new WaveFileReader(FILE_PATH);
			var waveOut = new WaveOutEvent();
			waveOut.DeviceNumber = deviceIndex;
			waveOut.Init(reader);
			var playCount = 0;
			while (true)
			{
				if (waveOut.PlaybackState != PlaybackState.Playing)
				{
					if (playCount >= PLAY_COUNT)
					{
						break;
					}
					reader.Position = 0;
					waveOut.Play();
					playCount++;
				}
			}
		}
	}
}
