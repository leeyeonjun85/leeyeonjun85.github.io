---
title: "파이참 재설치 후 인터프리터 에러 해결 하기"

categories:
  - Dev Log

tags:
  - 개발일지
  - 코딩
  - 파이썬
  - 파이참
toc	: "Menu"
toc_label	:
toc_icon :
toc_sticky: true
last_modified_at: 2022-10-18
---


# 파이참 재설치 후 인터프리터 에러 해결 하기

## 파이참 인터프리터에러(pycharm invalid interpreter)
- 컴터 포멧하고싶은 마음이 들어서 컴터 포멧 후 파이참을 재설치 하였음
- 파이참, 파이썬 설치 후 파이참에서 새프로젝트를 생성하였더니 오류 뜸
  - '인터프리터 생성 실패', 세부 정보 - '가상 환경을 생성하지 못했습니다.'
  - Python 패키징 도구를 설치하지 못했습니다.
  - 잘못된 Python SDK
- Python을 잘못 설치한 건가 싶어서 python 3.10.8을 삭제 후 python 3.8.6으로 바꿔봐도 똑같음
- 환경변수 설정 해줘도 똑같음
- 파이참에서 캐시 무효화 해도 똑같음
- 컴터 포멧을 잘못한 건가 싶어서 다시 컴터를 포멧하고 파이썬과 파이참을 재설치해도 똑같음

## 파이참 낮은 버전으로 재설치
- pycharm professional 2022.2.3 삭제 후 pycharm-professional-2022.2으로 재설치
- 문제 해결!!

## 배운 점
- 잘 안될 때는 낮은 버전으로 바꿔보자!!