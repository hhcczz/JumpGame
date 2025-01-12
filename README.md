# [Unity 2D] 개구리 모험
> Mobile Platform

<br>

# 1. 소개
<div align="center">

  <img src="https://github.com/user-attachments/assets/03329ac3-e817-4511-abed-56c021b4a784" width="33%" height="33%"/>
  <img src="https://github.com/user-attachments/assets/460d680c-6b66-4d04-a248-cd3210d8e568" width="33%" height="33%"/>
  <img src="https://github.com/user-attachments/assets/e9e88da0-2866-4ea3-af74-d54de46ff4c4" width="33%" height="33%"/>
 
  <img src="https://github.com/user-attachments/assets/692caa8e-17f8-41e4-8577-924703c8c64e" width="33%" height="33%"/>
  <img src="https://github.com/user-attachments/assets/d9c9938d-c92e-4dad-8147-24b93c3405f4" width="33%" height="33%"/>
  <img src="https://github.com/user-attachments/assets/c6a975a5-54ef-497f-abc1-2429817df373" width="33%" height="33%"/>

  < 게임 플레이 사진 >
</div>

+ Unity 2D Jump 게임입니다.

+ Unity로 게임을 만들어 보고싶어서 제작해봤습니다.

+ 개발기간: 2023.02.01 ~ 2024.04.01 ( 약 2개월 )

+ 형상관리: Github

<br>

# 2. 개발 환경
+ Unity 2021.3.21f1 LTS
+ C#
+ Android

  <br>

# 3. 사용 기술
| 기술 | 설명 |
|:---:|:---|
| 디자인 패턴 | ● **싱글톤** + **Static** 2가지를 사용하여 Manager 관리 |
| Save | 게임 데이터를 모두 Json으로 변환하여 관리 ( Dictionary 포함 ) |

<br>

# 4. 게임 설명

- 총 5개의 스테이지로 구성되어있습니다. -> 사과, 바나나, 오렌지, 파인애플, 딸기
- 맵 끝에 존재하는 과일을 획득하면 다음 스테이지가 해금되며, 도착까지 다양한 장애물 및 몹들이 존재합니다.
- 총 과일 5개를 모으면 게임이 종료됩니다.
  
<img src="https://github.com/user-attachments/assets/cc6b83e9-8cf4-418d-86ab-47ab4b5b680d" width="100%" height="100%"/>
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

# 5. 게임 포인트
  - 점프 키 제거
     - 점프 키를 제거하고 이동할 때는 무조건 점프가 되며 이동됩니다.
     - 점프가 자동이라는 제약조건을 넣어서 게임 난이도를 조절하였습니다.
       
  - 다양한 맵 종류
     - 과일마다 맵이 다릅니다.
     - 초원, 습지, 사막, 유적, 설산
       
  - 자유로운 저장
     - 맵에는 고유 세이브포인트가 2 군데 존재하지만, 광고를 보면 원하는 자리에 세이브 포인트가 생성됩니다.
     - 광고를 플레이어가 게임을 진행하면서 영향을 주지 않는 선에서 넣었습니다.
       
  - 함정
     - 보이는 함정, 안보이는 함정, 다양한 몹들로 게임 분위기를 맞추었습니다.
     - 특히 안보이는 함정을 통해 플레이어가 자연스럽게 광고에 손이 가게 설계했습니다.
       
    
<br>

## 6. 소개 영상
+ [소개 영상](https://youtu.be/FfVZurRKt90)

