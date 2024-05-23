Shader "Custom/DashedLineShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Main Color", Color) = (1,1,1,1)
        _DashSize ("Dash Size", Range(0.01, 1.0)) = 0.05
        _GapSize ("Gap Size", Range(0.01, 1.0)) = 0.05
        _BlurAmount ("Blur Amount", Range(0.0, 1.0)) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Geometry" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite On
        ZTest LEqual

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _DashSize;
            float _GapSize;
            float _BlurAmount;
            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float dashPeriod = _DashSize + _GapSize;
                if (dashPeriod <= 0.0) dashPeriod = 0.01; // Avoid division by zero
                float totalDistance = i.uv.y / dashPeriod;
                float dashPosition = fmod(totalDistance, 1.0);

                float dashStart = 0.0;
                float dashEnd = _DashSize / dashPeriod;

                float horizontalPosition = i.uv.x;
                float blurFactor = smoothstep(0.0, _BlurAmount, horizontalPosition) * (1.0 - smoothstep(1.0 - _BlurAmount, 1.0, horizontalPosition));

                float alpha = smoothstep(dashStart, dashStart + _BlurAmount, dashPosition) * (1.0 - smoothstep(dashEnd - _BlurAmount, dashEnd, dashPosition)) * blurFactor;

                if (dashPosition >= dashEnd)
                {
                    return fixed4(0, 0, 0, 0); // Transparent
                }
                else
                {
                    return fixed4(_Color.rgb, _Color.a * alpha);
                }
            }
            ENDCG
        }
    }
}
