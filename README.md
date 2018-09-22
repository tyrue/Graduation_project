---
typora-copy-images-to: ..\..\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img
---

# 다중 무선 컨트롤러를 이용한 VR 노인  재활 근력 운동 (VR Rehabilitation Exercise development for Elderly people’s muscle using multiple wireless controllers)

## 1. 서론

### 1) 필요성

[1] 가상현실을 교육 및 훈련, 운동에 접목하였을 경우 높은 몰입감과 개별화된 상호작용을 통한 학습 효과 향상을 기대할 수 있고, 텍스트와 2D 자료로 설명하기에는 어렵거나 부족한 학습 내용, 고위험·고가 장비 교육 등의 영역에 매우 효과적이다. 

[2] 장애 인구 중 65세 이상 노인이 절반 가까운 46.6%로, 2000년(30.3%)에 비해 고령화 추세가 뚜렷하게 드러났다. 또 장애인 가구의 26.4%는 1인 가구로 조사됐다. 

[3] 근력 운동은 노인들의 근육량, 근력, 뼈 무기질 밀도, 뼈 강도, 신체조성 및 일상생활 수행 능력을 향상시키고, … 규칙적으로 근력 운동에 참여할 수 있는 환경을 조성하는 것이 필요하다고 생각된다.

***



### 2) 연구목적

**다중 무선 컨트롤러를 통해 신체 움직임을 측정 후, 이를 VR 콘텐츠와 연동하여  노인들의 재활 근력 운동을 돕는 시스템 개발**

***



### 3) 구성도

#### (1) 전체 구성도

![noname01](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\noname01.png)

***

#### (2) 하드웨어

![noname02](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\noname02.png)

사용자의 운동동작에 따른 움직임을 측정할 수 있는 IMU센서와 전원공급을 위한 리튬 폴리머 배터리가 부착된 디바이스를 사용자의 신체에 부착 가능한 형태로 설계한다. 

***

#### (3) 소프트웨어

| ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\10.png) | ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\11.png) |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| 메인 화면                                                    | 썰매 게임 - 상체 운동                                        |
| ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\8.png) | ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\9.png) |
| 외줄타기 게임 - 척추 운동                                    | 로켓 게임 - 무릎 운동                                        |
| ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\6.png) | ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\7.png) |
| 메뉴 – 게임 선택 가능                                        | 운동 방법 알아보기 – 영상과 음성 출력                        |
| ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\4.png) | ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\5.png) |
| 게임메뉴 – 게임 내에서 메뉴 띄우기                           | 게임 종료 시 메뉴                                            |
| ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\3.png) | ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\2.png) |
| 게임 UI 설명 화면                                            | 컨트롤러 초기화 화면                                         |
| ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\1.png) |                                                              |
| 컨트롤러 인식 화면                                           |                                                              |

사용자가 착용한 ‘다중 무선 컨트롤러’와 HMD(Head Mounted Display)로부터 받아들인 값으로 진행된다. 총 3가지의 게임과 관련 메뉴들로 구성된다.

***



## 2. 본론

### 1) 작품 특징

#### (1) 하드웨어를 통한 노인 재활 근력 운동

아두이노와 IMU 센서, 블루투스를 이용하여 사용자로부터 운동에 대한 결과 값을 판단한다. 이 판단에서 올바르게 운동을 하고 있다면 소프트웨어에 정상적으로 운동을 하고 있다는 결과를 전송한다.

***

#### (2) 소프트웨어를 통한 노인 재활 근력 운동

VR HMD 의 화면을 통해 사용자가 원하는 운동을 선택하게 한다. 선택한 운동에 따라 사용자가 확인 할 수 있는 매뉴얼을 제공하고 운동을 시작할 수 있게 한다. 팔 운동은 사격, 허리 운동은 외줄타기, 다리 운동은 야바위 투호에 대응된다. 사용자는 운동에 맞게 컨트롤러를 지정된 위치에 장착하고 운동과 함께 게임을 시행, VR HMD 에 즉각적인 화면이 나오고 피드백을 제시한다.

***



### 2) 기대효과

#### (1) 노인 재활 근력 운동에 대해 흥미를 유발 시킨다.

간편한 컨트롤러 사용법과 VR HMD를 통한 게임을 통해 노인 재활 근력 운동을 하는 데에 흥미를 유발시켜 운동에 대한 거부감을 줄이고, 노인의 건강에 도움이 되게 할 수 있다.

***

#### (2) 다중 컨트롤러의 확장성을 통해 여러 운동에 대응 할 수 있다.

같은 기능을 가진 컨트롤러를 여러 개 만듦으로서 한 가지의 운동뿐만 아니라 여러 개의 운동에도 대응 할 수 있게 되어 콘텐츠나 컨트롤러에 제약을 받지 않고, 운동을 추가만 함으로서 간단하게 운동을 즐길 수 있다.

***



### 3) 문제점

#### (1) 제한 조건

운동 중 움직임으로 인한 센서의 정확한 값을 측정할 필요는 없으나, 일상적인 움직임에 대해 견딜 수 있는 내구성이 요구된다.

사용되는 MCU의 크기가 작을수록 컨트롤러의 무게가 가벼워지고 크기가 작아질 수 있으나, MCU가 크기가 작아지면 연결할 수 있는 센서의 수가 줄어들어 하드웨어 구성에 어려움이 있다.

사용자들의 운동 방법에 대한 움직임이 동일하지 않기 때문에, 정확한 값을 요구하는 알고리즘을 적용하기에는 기술적으로 한계가 있다.

***

#### (2) 해결 방법

움직임에 대한 고정을 할 수 있게 벨크로와 같은 고정 장비를 사용한다.

컨트롤러에 부착할 MCU로 아두이노 나노를 사용하여, 컨트롤러 전체의 크기와 무게를 줄일 수 있도록 한다.

운동 값을 판단할 알고리즘을 적용하기 전, 충분한 실험을 통해 운동 값에 대한 범위를 정확히 제시한다.

***



## 3. 결론

### 1) 하드웨어 

IMU를 통해 신체에 부착한 센서의 위치 값(X, Y, Z)을 측정

리튬 폴리머 배터리를 이용하여 센서에 전원공급

센서를 이용한 측정 값을 블루투스 센서를 통해 PC로 전송

AutoCAD를 이용한 외형 설계 및 3D 프린터를 이용하여 출력(총 4개 제작)

Oculus DK2를 사용하여 VR 몰입 환경 제공

***

### 2) 소프트웨어

블루투스 통신을 통해 하드웨어로부터 측정값을 받음

측정값으로 게임을 진행(썰매로 상체 운동하기 게임, 외줄타기로 척추 운동하기 게임, 로켓으로 무릎 운동하기 게임)

이외에도‘운동 방법 알아보기’을 통해 게임 방법들을 확인할 수 있고, 목숨/운동시간/음성/배경음/게임 UI 설명/게임메뉴 등의 콘텐츠를 이용할 수 있다.

***

### 3) 작품제작 소요재료 목록

| 순번 |              제품명              |                             사진                             |                          사용내용                           |
| :--: | :------------------------------: | :----------------------------------------------------------: | :---------------------------------------------------------: |
|  1   |   아두이노 나노(Arduino Nano)    | ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\12.png) |                             MCU                             |
|  2   |        IMU 센서(MPU-9250)        | ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\13.png) | 컨트롤러의 움직임에 따라 센서 값들을 입력받아 움직임을 감지 |
|  3   |       블루투스 모듈(HC-06)       | ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\14.png) |              블루투스 통신을 하여 값들을 통신               |
|  4   |     리튬 폴리머 배터리(3.7V)     | ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\15.png) |                   아두이노에 전력을 공급                    |
|  5   |      배터리 충전기(TP4056)       | ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\16.png) |                  리튬 폴리머 배터리를 충전                  |
|  6   | USB to UART 컨버터 모듈(FT232RL) | ![](C:\Users\DooHyun\Documents\자주 쓰는 것들\학교 문서들\4학년\2학기\졸업작품\img\17.png) |             아두이노와 PC 간 데이터 신호를 교환             |



## 4. 참고자료

[1] 임다미, 김상연, “가상현실 기반 토탈스테이션 훈련 콘텐츠 개발“, 한국디지털콘텐츠학회논문지 제18권 제4호, pp. 631-639, 2017. ​     

[2] 중앙일보 ”국내 장애인 267만명...“절반은 노인, 넷 중 하나는 혼자 산다”,

http://news.joins.com/article/22550173

[3] 박인성, “노인의 행복한 삶을 위한 건강 증진과 근력 운동”, 한국엔터테인먼트산업학회논문지 제11권 제3호, pp. 111-119, 2017. 

[4] 국민건강보험공단지정 노인장기요양보험 지정센터의 노인 운동 소개, 

http://blog.daum.net/_blog/BlogTypeView.do?blogid=0iEHB&articleno=75&categoryId=4&regdt=20140114154103

[5] 강남세란의원의 노인 하체 근력 강화 운동 소개, 

<https://www.youtube.com/watch?v=Dg_wPkeGkUw>

[6] 자생한방병원의 노인 척추 운동 소개,

https://www.youtube.com/watch?v=3o8to5H-iwk

[7] 임희철, 이창영, 임도형, 전경진, 정덕영, 전성철, “고령자 대상 하지 균형증진 운동시스템의 사용성 평가 연구”, 재활복지공학회논문지 제9권 제4호, pp. 293-299, 2015.

[8] 김성호, 신동희, “전신 움직임을 요구하는 컨트롤러가 가상현실 디바이스에서 시지각과 가상현실 멀미에 끼치는 영향”, 한국디지털콘텐츠학회논문지 제18권 제2호, pp. 283-291, 2017.

[9] 라파엘 스마트 글러브 안내 사이트, http://www.neofect.com/ko/solution/

[10] 닌텐도 라보 공식 사이트, https://labo.nintendo.com/