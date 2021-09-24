Shader "Custom/MyOutlineShader"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("OutlineWidth", float) = 0
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200

        Pass
        {
            Cull Front;
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0
            #include "UnityCG.cginc"

            float _Outline;
            float4 _Color;

            struct v2f
            {
                float4 pos:SV_POSITION;
            }

            v2f vert(appdata_base v)
            {
                v2f output;
                output.pos 
            }
            //не дописано и не доотлажено

        }
        ENDCG
    }
    FallBack "Diffuse"
}
