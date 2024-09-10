---
title: "Google API"
excerpt: "구글API 활용하여 구글 캘린더, 구글 드라이브 연동하기"

categories:
  - Dev Log

tags:
  - 개발일지
  - 스마트팩토리
  - API

use_math: true

header:
  teaser: /assets/images/background/bitcoin-7693848_1920.png

last_modified_at: 2024-09-10
---




<br><br><br><br>


![image](../../assets/images/background/bitcoin-7693848_1920.png){: .align-center width="70%"}   


<br><br><br><br>


# Google API  
> 구글API 활용하여 구글 캘린더, 구글 드라이브 연동하기  



<br><br><br><br>



## 개요
- 고객사에서 회사에서 사용중인 MES에 <mark>구글 캘린더 기능을 통합</mark>하여 사용할 수 있도록 요청하였음
- **C#**에서 **구글 캘린더**를 불러오고, 새로운 이벤트를 생성하는 **테스트 프로그램**을 만든자
- 추가적으로, 구글 캘린더에 첨부파일을 추가하기 위하여 **구글 드라이브**도 함께 활용하자


<br><br> 


### 구성

![image](../../assets/ppt/스크린샷%202024-09-10%20185019.png){: .align-center width="80%"}   

- 사용자가 구글 캘린더를 조회, 추가, 삭제 할 수 있는 **테스트 UI 프로그램**은 간단하게 C# Winform(.NET Framework 4.7.2) 으로 만들자
- C#으로 구글API를 사용하려면 `Google.Apis` 패키지가 필요
- 누겟으로 `Google.Apis`, `Google.Apis.Auth`, `Google.Apis.Calendar.v3`, `Google.Apis.Drive.v3`를 설치
- `캘린더 ID 저장` > `드라이브 폴더 ID 저장` > `구글 API 설정` > `테스트 UI 프로그램 작성`




<br><br><br><br>


## 캘린더 ID 저장
- 어떠한 캘린더에 이벤트를 등록할지, 캘린더를 특정하기 위한 캘린더의 ID를 얻자

### `새 캘린더 만들기`를 클릭하여 새로운 캘린더를 만들자
![image](../../assets/images/post/2024-09-10-GoogleAPI/스크린샷%202024-09-10%20225609.png){: .align-center width="80%"} 

### 캘린더 설정 > 캘린더 통합 > 캘린더 ID 를 저장
![image](../../assets/images/post/2024-09-10-GoogleAPI/스크린샷%202024-09-10%20225815.png){: .align-center width="80%"} 




<br><br><br><br>


## 참고자료
- [Google Cloud](https://console.cloud.google.com/)





<br><br><br><br>
<center>
<h1>끝까지 읽어주셔서 감사합니다😉</h1>
</center>
<br><br><br><br>





