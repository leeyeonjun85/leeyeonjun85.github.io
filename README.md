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

<hr><hr>
<br>
<hr><hr>

### 컴퓨터 리셋 후 GitHub 개발서버 셋팅
```bash
# Ruby 설치
## 아래 주소에서 다운받아서 실행하여 설치
https://rubyinstaller.org/downloads/
## rubyinstaller-devkit-3.3.5-1-x64.exe
## Jekyll 4.x → Ruby 3.x 권장

## [중요] 설치 마법사 마지막의 "Run 'ridk install'" 체크 → 창에서 Enter (MSYS2+toolchain 설치)
   1 - MSYS2 base installation
   2 - MSYS2 system update (optional)
   3 - MSYS2 and MINGW development toolchain
## 이 단계를 건너뛰면 bundle install 시 네이티브 gem 컴파일 실패함
## 놓쳤다면 새 터미널에서:  ridk install   (그 후 Enter)
    
# 설치 후 새 터미널(PowerShell 또는 CMD 권장) 에서 확인
ruby -v               # Ruby 버전 확인
gem install bundler   # bundler 없을 때만 (Ruby 3.x는 기본 포함)

# 블로그 폴더 안에서 의존성 설치
bundle install        # Gemfile 기준 gem 설치
bundle exec jekyll -v # Jekyll 버전 확인 (전역 jekyll 대신 bundle exec 권장)

# Run jekyll Dev. Server!
bundle exec jekyll serve --livereload   # 저장 시 브라우저 자동 새로고침
## Dev. Server is...
http://127.0.0.1:4000
## To stop Press
Ctrl + C


# ── 문제 해결 ──
gem env               # gem 설치 환경 확인
# Windows 플랫폼 lock 에러가 나면:
bundle lock --add-platform x64-mingw-ucrt x64-mingw32 ruby
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



### VSCode 편집기 상단에 클래스, 함수 표시 설정
- 설정 > 텍스트 편집기 > `Editor > Sticky Scroll: Enabled` 체크박스
- 편집기 위쪽에서 스크롤하는 동안 중첩된 현재 범위를 표시합니다.