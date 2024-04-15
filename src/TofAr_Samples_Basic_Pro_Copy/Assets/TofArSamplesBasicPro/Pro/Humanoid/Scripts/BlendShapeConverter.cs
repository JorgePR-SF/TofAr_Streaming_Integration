/*
 * SPDX-License-Identifier: (Apache-2.0 OR GPL-2.0-only)
 *
 * Copyright 2023 Sony Semiconductor Solutions Corporation.
 *
 */

using TofAr.V0.Face;
using UnityEngine;
using VRM;

public class BlendShapeConverter : MonoBehaviour
{
    /// <summary>
    /// VRM model controlled by VRM 0.1BlendShape
    /// </summary>
    public VRMBlendShapeProxy bspVrm;

    private static BlendShapePreset[] presets =
    {
		BlendShapePreset.A,
		BlendShapePreset.I,
		BlendShapePreset.U,
		BlendShapePreset.E,
		BlendShapePreset.O,
		BlendShapePreset.Blink_L,
		BlendShapePreset.Blink_R,
	};

    private BlendShapeKey[] keysVrm;

    private float[] vrmblendShapes;

    private void OnEnable()
    {
        TofArFaceManager.OnFaceEstimated += OnFaceEstimated;
    }

    private void OnDisable()
    {
        TofArFaceManager.OnFaceEstimated -= OnFaceEstimated;
    }

    void Start()
    {
        //VRM BlendShape created from Preset
        keysVrm = new BlendShapeKey[presets.Length + 1];
        for (int i = 0; i < presets.Length; i++)
        {
			keysVrm[i] = BlendShapeKey.CreateFromPreset(presets[i]);
        }

        //I want to use Surprised for the top and bottom of the eyes
        //If the clitoris change is defined in Surprised, it will be an unintended movement
        //It is appropriate to create and control a separate BlendShape that only moves the eyes of FIXME Surprised.
        keysVrm[7] = BlendShapeKey.CreateUnknown("Surprised");
	}

    void Update()
    {
        if (vrmblendShapes == null || vrmblendShapes.Length == 0)
        {
            return;
        }

        int index = 0;
        foreach (BlendShapeKey key in keysVrm)
        {
            bspVrm.ImmediatelySetValue(key, vrmblendShapes[index]);
            index++;
        }
	}

    private void OnFaceEstimated(object sender)
    {
        FaceResults frs = (FaceResults)sender;

        FaceResult[] results = frs.results;

        if (results.Length == 0)
        {
            return;
        }

        FaceResult result = results[0];
        vrmblendShapes = result.vrmBlendShapes;
    }
}
