# [Unity 2D] 개구리 모험
> Mobile Platform

<br>

# 📘 소개
<table align="center">
  <tr>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/03329ac3-e817-4511-abed-56c021b4a784" width="350px"/>
    </td>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/460d680c-6b66-4d04-a248-cd3210d8e568" width="350px"/>
    </td>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/e9e88da0-2866-4ea3-af74-d54de46ff4c4" width="350px"/>
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/692caa8e-17f8-41e4-8577-924703c8c64e" width="350px"/>
    </td>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/d9c9938d-c92e-4dad-8147-24b93c3405f4" width="350px"/>
    </td>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/c6a975a5-54ef-497f-abc1-2429817df373" width="350px"/>
    </td>
  </tr>
</table>

<p align="center"><strong>게임 플레이 사진</strong></p>

# 🎮 프로젝트 개요

- **Unity 2D 기반의 점프 액션 게임**입니다.
  
- Unity 엔진을 직접 활용하여 게임을 개발해보고자 하는 목표로 제작을 시작했습니다.
  
- **개발 기간**: 2023.02.01 ~ 2023.04.01 (약 2개월)
  
- **형상 관리**: GitHub

<br>

# 🛠️ 개발 환경
| 항목 | 내용 |
|:---|:---|
| **엔진** | Unity 2021.3.21f1 (LTS) |
| **언어** | C# |
| **플랫폼** | Android (모바일 빌드 대상) |
| **형상 관리** | GitHub |

  <br>

# 🧪 사용 기술
| 기술 | 설명 |
|:---|:---|
| **디자인 패턴** | 싱글톤(Singleton)과 Static을 조합하여 매니저 클래스들을 효율적으로 관리 |
| **데이터 저장** | 게임 데이터를 JSON 형태로 직렬화하여 저장하며, Dictionary 자료구조도 포함 |

<br>

# 🍓 게임 설명

> ![이미지](https://github.com/user-attachments/assets/cc6b83e9-8cf4-418d-86ab-47ab4b5b680d)

- 게임은 총 **5개의 과일 테마 스테이지**로 구성되어 있습니다.  
  → **사과, 바나나, 오렌지, 파인애플, 딸기**

- 각 스테이지의 **끝 지점에는 해당 과일이 위치**해 있으며, 이를 획득하면 다음 스테이지가 해금됩니다.

- 도중에는 다양한 **장애물**과 **적 몬스터**가 등장하여 플레이어의 진행을 방해합니다.

- **5개의 과일을 모두 수집하면 게임이 종료**되며, 이를 통해 최종 클리어 여부가 결정됩니다.

# 🗺️ 전체 맵
<div align="center">
  <img src="https://github.com/user-attachments/assets/e5e17403-57ef-4481-b6a0-bd90fcd0f163" width="100%" height="100%"/>
  
  < Stage 1 >
  
  <img src="https://github.com/user-attachments/assets/3f8f78b6-e161-4615-85be-0cf3f14fb9f6" width="100%" height="100%"/>
  
  < Stage 2 >
  
  <img src="https://github.com/user-attachments/assets/b9dc2ae2-1811-4d67-9212-048c24a95405" width="100%" height="100%"/>
  
  < Stage 3 >
  
  <img src="https://github.com/user-attachments/assets/eb89e633-7955-4376-8eca-638dadebe076" width="100%" height="100%"/>
  
  < Stage 4 >
  
  <img src="https://github.com/user-attachments/assets/2a183c0b-3319-466f-ba74-0ad168df0998" width="100%" height="100%"/>
  
  < Stage 5 >
  
</div>

<br>

# 🚀 게임 핵심 포인트

## 🕹️ 점프 키 제거 (자동 점프 시스템)
- 플레이어의 조작에서 **점프 키를 제거**하고, **이동 시 자동 점프가 발생**하도록 설계했습니다.
- 이로 인해 조작은 단순하지만, **정밀 점프 타이밍과 맵 구조 분석이 난이도 조절 요소로 작용**합니다.

---

## 🌍 다양한 맵 구성
- 각 스테이지는 **획득할 과일 테마에 따라 고유한 배경과 맵 타입**을 가집니다.
- 맵 타입 예시: **초원, 습지, 사막, 유적, 설산**

---

## 💾 자유로운 저장 시스템
- 각 맵에는 **기본 세이브 포인트 2개**가 배치되어 있으며,
- 추가로 **광고 시청을 통해 임의 위치에 세이브 포인트를 생성**할 수 있습니다.
- 광고는 **게임 흐름을 방해하지 않는 선**에서 자연스럽게 녹아들도록 설계되었습니다.

---

## ☠️ 다양한 함정 및 몬스터
- 맵에는 **보이는 함정**, **숨겨진 함정**, **개성 있는 몬스터**가 배치되어 있습니다.
- 특히 **보이지 않는 함정 요소**는 플레이어에게 도전 욕구를 유도하며,
  실패 시 자연스럽게 **광고 기반 세이브 포인트 생성 유도**로 이어지도록 UX 흐름을 설계했습니다.
    
<br>

# ▶️ 소개 영상
+ [소개 영상](https://youtu.be/FfVZurRKt90)

