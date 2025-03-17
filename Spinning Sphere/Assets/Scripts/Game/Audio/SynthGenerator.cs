using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SynthGenerator : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]
    private float Amplitude = 0.5f;

    [SerializeField, Range(0f, 2f)]
    private float Pitch = 1.0f;

    [SerializeField]
    private Note CurrentNote = Note.C; // middle C

    [SerializeField]
    private WaveType CurrentWaveType = WaveType.Sine;

    private double Phase;
    private int SampleRate;

    enum Note
    {
        C,
        CS,
        D,
        DS,
        E,
        F,
        FS,
        G,
        GS,
        A,
        AS,
        B
    }

    enum WaveType
    {
        Saw,
        Sine,
        Square,
        Triangle
    }

    private void Awake()
    {
        SampleRate = AudioSettings.outputSampleRate;
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        double phaseIncrement = (GetFrequencyFromNote(CurrentNote) / SampleRate) * Pitch;

        for (int sample = 0; sample < data.Length; sample += channels)
        {
            float value = GetValueFromWaveType(CurrentWaveType) * Amplitude;

            Phase = (Phase + phaseIncrement) % 1;

            for (int channel = 0; channel < channels; channel++)
            {
                data[sample + channel] = value;
            }
        }
    }

    private float GetFrequencyFromNote(Note note) => note switch
    {
        Note.C  => 261.63f,
        Note.CS => 277.18f,
        Note.D  => 293.66f,
        Note.DS => 311.13f,
        Note.E  => 329.63f,
        Note.F  => 349.23f,
        Note.FS => 369.99f,
        Note.G  => 392.00f,
        Note.GS => 415.30f,
        Note.A  => 440.00f,
        Note.AS => 466.16f,
        Note.B  => 493.88f,
        _       => throw new System.NotImplementedException(),
    };

    private float GetValueFromWaveType(WaveType type) => type switch
    {
        WaveType.Saw      => (float)(Phase * 2 - 1),
        WaveType.Sine     => Mathf.Sin((float)Phase * 2f * Mathf.PI),
        WaveType.Square   => Mathf.Round((float)Phase) * 2 - 1,
        WaveType.Triangle => Mathf.Abs((float)(Phase + 0.25 - Mathf.Round((float)(Phase + 0.25)))) * 2 - 1,
        _                 => throw new System.NotImplementedException(),
    };
}
