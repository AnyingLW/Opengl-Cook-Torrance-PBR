#version 330 core
in vec2 TexCoord;
in vec3 Color;

out vec4 FragColor;

uniform sampler2D texture1;
uniform sampler2D texture2;
uniform float par;

void main(){
	FragColor = mix(texture(texture1,TexCoord),texture(texture2,TexCoord),par);
}