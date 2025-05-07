Shader "Custom/UnlitDoubleSided"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 100

        Cull Off // Backface Culling 제거: 양면 렌더링 핵심

        Pass
        {
            Lighting Off
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            SetTexture [_MainTex] {
                combine texture * primary
            }
        }
    }
}
