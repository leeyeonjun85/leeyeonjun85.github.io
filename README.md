# Welcome! Lee Yeonjun's GitHub Homepage~😃


## 블로그 소개
- [이연준의 GitHub 홈페이지](https://leeyeonjun85.github.io/)를 방문해주셔서 감사합니다.
- `개발일지`와 `개인블로그` 중심으로 만들어나갈 예정입니다.  

<br>

### [About me](https://leeyeonjun85.github.io/about/)
- 저를 `소개`하는 페이지입니다.

<br>

### [Categoryes](https://leeyeonjun85.github.io/categories/)
- `개발일지`를 카테고리별로 정리하였습니다.


<br><br><hr><br><br>


## 블로그 관리용 참고자료

### 여러번 띄어쓰기 하기
- 스페이스바를 여러번 눌러도 띄어쓰기가 적용되지 않을 때 여러번 띄어쓰기 하는 방법
- 전각문자 띄어쓰기 이용
  - (`　`) : 괄호 안을 복사해서 붙여넣기
- 띄어쓰기 코드 사용
  - `&nbsp;`

- Markdown에서 수식 띄어쓰기
  - `\,`     : 한칸
  - `\;`     : 두칸
  - `\quad`  : 네칸
  - `\qquad` : 여덟칸

<br>

### 컴퓨터 리셋 후 GitHub 개발서버 셋팅
```bash
# Ruby 설치
## 아래 주소에서 다운받아서 실행하여 설치
https://rubyinstaller.org/downloads/
## jekyll은 32bit이기 때문에 (x86)으로 설치
# rubyinstaller-devkit-2.7.8-1-x86.exe
    
# 루비 설치 후 컴퓨터 재시작 후 VSCode Gitbash 터미널
ruby -v           # 루비 버전확인 가능
bundle install    # bundle 설치하기 / CMD 터미널에서 실행해야 함
jekyll -v         # 지킬 버전확인 가능

# Run jekyll Dev. Server!
bundle exec jekyll serve  # CMD 터미널에서 실행해야 함
## Dev. Sever is...
http://127.0.0.1:4000
## To stop Press
Ctrl + C


# 에러나면... Ruby gem 설치 환경 확인
gem env
```

<br>

### 한 줄로 깃애드, 깃커밋, 깃푸시 실행하기
```bash
git add . && git commit -m "Update" && git push
```

<br>

### 텍스트 정렬
```md
{: .text-left}
{: .text-center}
{: .text-right}
```

<br>

### 이미지 정렬
```md
{: .align-left}
{: .align-center}
{: .align-right}
```

<br>

### 문단에 배경색 입히기
```md
{: .notice}
{: .notice--primary}
{: .notice--info}
{: .notice--warning}
{: .notice--danger}
{: .notice--success}
```