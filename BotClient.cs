using Concentus.Enums;
using Concentus.Structs;
using GeoVR.Shared;
using System;
using System.Collections.Generic;

namespace ATISPlugin
{
    internal class BotClient
    {
        private static byte[] encodedBuffer = new byte[1275];
        private static OpusEncoder opusEncoder = new OpusEncoder(48000, 1, OpusApplication.OPUS_APPLICATION_VOIP);

        public static PutBotRequestDto AddBotRequest(
          byte[] audioData,
          uint frequency,
          double latDeg,
          double lonDeg,
          double altM)
        {
            short[] numArray1 = ConvertBytesTo16BitPCM(audioData);
            opusEncoder.Bitrate = 8192;
            Array.Clear((Array)encodedBuffer, 0, encodedBuffer.Length);
            int num1 = (int)Math.Floor((double)numArray1.Length / 960.0);
            int num2 = 0;
            List<byte[]> numArrayList = new List<byte[]>();
            for (int index = 0; index < num1; ++index)
            {
                int count = opusEncoder.Encode(numArray1, num2, 960, encodedBuffer, 0, encodedBuffer.Length);
                byte[] dst = new byte[count];
                Buffer.BlockCopy((Array)encodedBuffer, 0, (Array)dst, 0, count);
                numArrayList.Add(dst);
                num2 += 960;
            }
            short[] numArray2 = new short[960];
            int count1 = numArray1.Length - num1 * 960;
            Buffer.BlockCopy((Array)numArray1, num2, (Array)numArray2, 0, count1);
            int count2 = opusEncoder.Encode(numArray2, 0, 960, encodedBuffer, 0, encodedBuffer.Length);
            byte[] dst1 = new byte[count2];
            Buffer.BlockCopy((Array)encodedBuffer, 0, (Array)dst1, 0, count2);
            numArrayList.Add(dst1);
            return new PutBotRequestDto()
            {
                Transceivers = new List<TransceiverDto>()
                {
                    new TransceiverDto()
                    {
                    ID = (ushort) 0,
                    Frequency = frequency,
                    LatDeg = latDeg,
                    LonDeg = lonDeg,
                    HeightMslM = altM,
                    HeightAglM = altM
                    }
                },
                Interval = TimeSpan.FromSeconds((double)audioData.Length / 96000.0 + 3.0),
                OpusData = numArrayList
            };
        }

        private static short[] ConvertBytesTo16BitPCM(byte[] input)
        {
            int length = input.Length / 2;
            short[] numArray = new short[length];
            int num = 0;
            for (int index = 0; index < length; ++index)
                numArray[num++] = BitConverter.ToInt16(input, index * 2);
            return numArray;
        }
    }
}
