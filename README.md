1.配置GLFW和glad库，并用简单窗口进行测试。
2.配置VAO,VBO,VS,FS以绘制三角形，其中应用EBO可以重复利用同一顶点以节省存储空间。
3.将着色器抽象为着色器类，该类完成对着色器的读取以及设定。
4.应用纹理，了解纹理的各种设置参数，以及混合应用多个纹理。
5.变换，用矩阵实现平移、旋转及缩放。
6.坐标系统，用model、view、projection矩阵将模型正确的变换到屏幕空间。
7.实现摄像机类，改变viewport矩阵的position实现摄像机响应键盘的平移，改变viewport矩阵的direction实现摄像机随鼠标改变朝向，改变projection矩阵的fov项实现视野随鼠标滚轮的放大缩小。
8.颜色，增加一个光源，让物体的颜色由光源和物体本身的颜色决定。
9.为物体设置ambient、diffuse、specular以模拟现实中物体的材质，为光源设置ambient、diffuse、specular以模拟现实中光源颜色及强度对物体颜色的影响。
10.应用漫反射贴图和高光贴图，实现更真实的光照效果。
11.实现平行光、点光源、聚光。
12.汇总前述各种光源，搭建一个多光源的场景。
13.引入assimp库，将场景拆解成model、mesh等，实现对复杂模型的加载和渲染。
14.通过更高精度的深度缓冲、在两个贴着的物体之间设置一个微小的偏移值、将近平面设置的更远（近平面有更高的精度）来解决z-fighting。
15.给屏幕的每一个像素分配一个值，每个片段渲染时与模板缓冲区的值比较来确定要不要丢弃这个片段，通过模板测试可以实现物体轮廓的绘制等。
16.通过颜色缓冲以及纹理的alpha值进行混合。（混合与深度测试冲突时先对物体进行排序，然后按从远到近次序绘制）
17.定义构成模型的三角形的顶点数组时，逆时针定义正面的三角形，顺时针定义背面/需要剔除的三角形，渲染时通过判断三角形的旋转方向剔除背面的三角形。
18.用颜色缓冲（深度、模板）定义自己的帧缓冲，第一次渲染时填充帧缓冲，第二次渲染时利用之前帧缓冲的内容，从而实现核效果（锐化、边缘检测等）以及
后视镜。
19.用立方体贴图实现巨大场景的渲染。通过不同的方式对立方体贴图进行采样，从而获得物体对立方体贴图中环境的反射、折射效果。
20.利用uniform缓冲减少需要设置的uniform的数量并加快速度。
21.利用几何着色器可以将一组顶点转换为不同的图元并生成更多顶点，还可通过沿三角形面法线方向平移顶点实现爆破物体、法向量可视化以及绘制毛发。（后两者需要两次光栅化，一次使用几何着色器平移顶点，一次不用）
22.当需要渲染大量相似的模型时（如小行星带），利用实例化数组将模型的转换矩阵存入顶点属性中，并告知系统渲染新实例时才更新顶点属性，从而减少cpu和gpu的数据交互，提高帧数。
23.blinn-Phong模型相较于Phong模型，在计算镜面反射光时用半程向量和法线做点积来衡量镜面光的强度，这样可以避免视线与反射光夹角>90°时镜面光直接归零。
24.显示器一般会对输入的颜色值取2.2次方后输出，以适应人眼对光线的敏感度，gamma校正要做的是在输出最终颜色前取该颜色值的1/2.2次方从而确保得到正确的颜色。
25.通过采样像素周围的其他像素并进行平均来应用PCF抗锯齿。
26.万象阴影贴图（点阴影贴图），用六个面的立方体贴图实现点阴影的shadow map。
27.不在切线空间下的法线贴图的应用受到原平面朝向的限制，这个问题可以通过切线空间来解决。三角形的边E可以用ΔU和ΔV表示，即E1=ΔU1T+ΔV1B，E2=ΔU2T+ΔV2B，联立两方程即可解出切线和负切线，再加上切线空间下默认定义的指向z轴正方向的法线即可定义该三角形的切线空间。将TBN矩阵应用在光源、片段位置、摄像机位置上，可以减少开销并能正确应用法线贴图。
28.视差贴图，一般与法线贴图配套使用，用原纹理坐标从深度贴图中采样出深度，将该深度近似为纹理坐标的偏移值沿视线方向加到纹理坐标上并从纹理上采样得到该点颜色，实现视差。陡峭视差映射将深度分层，查询最合适的偏移值以解决在陡峭位置渲染不真实的问题。视差遮蔽映射在陡峭视差映射的基础上再对交叉点的两个深度层进行插值，返回插值后的纹理坐标。
29.HDR渲染允许更大范围的颜色值渲染从而得到更多场景细节，然后通过各种色调映射算法以及不同的曝光度换回LDR。曝光度高=阴影处细节多。
30.第一次渲染场景时在帧缓冲中额外附加一张颜色缓冲存放亮度超过一定值的片段，然后对该缓冲进行高斯模糊（分别对行和列进行模糊，以大幅提高性能），最后将之前的场景与高斯模糊的结果相加，即可实现泛光。
31.为了渲染含有大量光源的场景引入延迟渲染，首先渲染一次场景但不计算光照而将场景的顶点位置、颜色、法线、深度、高光等信息存入g-buffer中。然后在第二轮渲染中利用g-buffer中的信息逐像素结合光照确定片段颜色。(需与正向渲染结合才能实现混合)（进一步优化，使用光体积）
32.Lo(p,ωo)=∫Ωfr(p,ωi,ωo)Li(p,ωi)n⋅ωidωi；
BRDF=kd(f-lambert)+ks(f-cook−torrance):kd、ks为反射、折射能量比例，用来表示漫反射和镜面反射各自占比。f-lambert用表面颜色表示；f-cook−torrance=DFG/4(ωo⋅n)(ωi⋅n)，D法线分布函数：描述物体微表面法线与半程向量一致的数量比率，G几何函数：根据粗糙度估算微表面自遮挡损耗，F菲涅尔项：根据ωo和物体基础反射率来确定物体反射和折射各自的比例）
L=d²Φ/dAdωcosθ
辐射率L=一个拥有辐射强度Φ的光源在单位面积A和单位立体角ω上辐射出的总能量。
Li(p,ωi)：即每个光源对于p点辐射出的能量（颜色值）。
最后对以ωo为观察方向，以p点为球心的半球面逐立体角积分得到的总和即为ωo方向下p点的辐射率（即颜色值）。
33.实现一个包含四个点光源的简单PBR模型，对于每一个光源计算其颜色（辐射率）贡献并相加，并应用反射率贴图等。
34.IBL的漫反射部分：首先使用stb_image.h加载.hdr图像为浮点数数组，然后将.hdr的等距柱状投影转换为立方体贴图,然后对立方体贴图进行卷积并生成辐照度贴图，最后在片段中根据法线从辐照度图中采样得到环境光的diffuse部分。
35.IBL的高光部分：将高光部分拆成预滤波环境部分和BRDF积分部分，通过卷积得到对应的两张贴图，应用到最好的PBR着色器中，实现完整的PBR光照模型。