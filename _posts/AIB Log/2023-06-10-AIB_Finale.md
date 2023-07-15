---

title: "AI 부트캠프 : 피날레"

excerpt: "코드스테이츠와 함께했던 AI 부트캠프 회고"

categories:
    - AIB Log

tags:
    - 개발일지
    - 코딩
    - AI 부트캠프
    - 코드스테이츠

header:
    teaser: /assets/images/aib/codestates-ci.png

last_modified_at: 2023-06-10

---


<br><br><br><br>


![image](../../assets/images/etc/start_road.jpg){: .align-center width="70%"}  


<br><br><br><br>




# 코드스테이츠와 함께했던 AI 부트캠프 회고  
> 2022년 12월 시작된 AI 부트캠프를 마쳤다.
> 이제 막 




<br><br><br><br>




## Daily Reflection : 3L 회고
### 배운 것(Learned)
간략한 테이블 조회부터 시작해서, 조건을 하나씩 늘려가며 쿼리문을 작성하니 논리적으로 이해하기 쉽다.
{: .notice--success}

<br>

### 아쉬웠던 점(Lacked)
조건을 추가하는 과정이 익숙해지면 더 빨라지겠지?
{: .notice--danger}

<br>

### 좋았던 점(Liked)
쿼리문작성하는데 자신감이 붙었다.
{: .notice--warning}




<br><br><br><br>




## SELECT : 조건에 맞는 도서 리스트 출력하기

### 문제 설명과 문제📜  

#### 문제 설명  
> 다음은 어느 한 서점에서 판매중인 도서들의 `도서 정보(BOOK)` 테이블입니다.
> `BOOK` 테이블은 각 도서의 정보를 담은 테이블로 아래와 같은 구조로 되어있습니다.

| Column name    | Type       | Nullable | Description                           |
| :---:          | :---:      | :---:    | :---:                                 |
| BOOK_ID        | INTEGER    | FALSE	   | 도서 ID                               |
| CATEGORY       | VARCHAR(N) | FALSE	   | 카테고리 (경제, 인문, 소설, 생활, 기술)  |
| AUTHOR_ID      | INTEGER    | FALSE	   | 저자 ID                               |
| PRICE          | INTEGER    | FALSE	   | 판매가 (원)                           |
| PUBLISHED_DATE | DATE       | FALSE	   | 출판일                                |

<br> 

#### 문제  
> `BOOK` 테이블에서 `2021년에 출판`된 `'인문' 카테고리`에 속하는 도서 리스트를 찾아서 `도서 ID(BOOK_ID), 출판일 (PUBLISHED_DATE)을 출력`하는 SQL문을 작성해주세요. 결과는 `출판일을 기준으로 오름차순` 정렬해주세요.


<br><br>


### 풀이🔎  
#### `BOOK` 테이블 살펴보기
```sql
SELECT      *
FROM        BOOK
;
```
  - 책이 7권 밖에 없다

<br>

#### `2021년에 출판` 조회하기
```sql
SELECT      *
FROM        BOOK
WHERE       YEAR(PUBLISHED_DATE) = 2021
;
```

<br>

#### `'인문' 카테고리` 조회하기
```sql
SELECT      *
FROM        BOOK
WHERE       YEAR(PUBLISHED_DATE) = 2021
      AND   CATEGORY = '인문'
;
```

<br>

#### `도서 ID(BOOK_ID), 출판일 (PUBLISHED_DATE)` 출력하기
```sql
SELECT      BOOK_ID, DATE_FORMAT(PUBLISHED_DATE, '%Y-%m-%d')
FROM        BOOK
WHERE       YEAR(PUBLISHED_DATE) = 2021
      AND   CATEGORY = '인문'
;
```

<br>

#### `출판일을 기준으로 오름차순` 정렬하기
```sql
SELECT      BOOK_ID, DATE_FORMAT(PUBLISHED_DATE, '%Y-%m-%d')
FROM        BOOK
WHERE       YEAR(PUBLISHED_DATE) = 2021
      AND   CATEGORY = '인문'
ORDER BY    PUBLISHED_DATE ASC
;
```
  - 주의사항
    - `PUBLISHED_DATE`의 데이트 포맷이 예시와 동일해야 정답처리
  - 통과🎉




<br><br><br><br>




## GROUP BY : 조건에 맞는 사용자와 총 거래금액 조회하기

### 문제 설명과 문제📜  

#### 문제 설명  
> 다음은 중고 거래 게시판 정보를 담은 `USED_GOODS_BOARD` 테이블과 중고 거래 게시판 첨부파일 정보를 담은 `USED_GOODS_FILE` 테이블입니다.
> `USED_GOODS_BOARD` 테이블은 다음과 같으며 `BOARD_ID, WRITER_ID, TITLE, CONTENTS, PRICE, CREATED_DATE, STATUS, VIEWS`는 게시글 ID, 작성자 ID, 게시글 제목, 게시글 내용, 가격, 작성일, 거래상태, 조회수를 의미합니다.

| Column name	 | Type	          | Nullable |
| :---:        | :---:          | :---:    |
| BOARD_ID     | VARCHAR(5)	    | FALSE    |
| WRITER_ID    | VARCHAR(50)	  | FALSE    |
| TITLE        | VARCHAR(100)	  | FALSE    |
| CONTENTS     | VARCHAR(1000)  | FALSE    |
| PRICE        | NUMBER	        | FALSE    |
| CREATED_DATE | DATE	          | FALSE    |
| STATUS       | VARCHAR(10)	  | FALSE    |
| VIEWS        | NUMBER	        | FALSE    |

> `USED_GOODS_USER` 테이블은 다음과 같으며 `USER_ID, NICKNAME, CITY, STREET_ADDRESS1, STREET_ADDRESS2, TLNO`는 각각 회원 ID, 닉네임, 시, 도로명 주소, 상세 주소, 전화번호를 를 의미합니다.

| Column name     |	Type	        | Nullable  |
| :---:           | :---:         | :---:     |
| USER_ID         |	VARCHAR(50)	  | FALSE     |
| NICKANME        |	VARCHAR(100)  | FALSE     |
| CITY            |	VARCHAR(100)	| FALSE     |
| STREET_ADDRESS1 |	VARCHAR(100)	| FALSE     |
| STREET_ADDRESS2 |	VARCHAR(100)	| TRUE      |
| TLNO            |	VARCHAR(20)	  | FALSE     |

<br> 

#### 문제  
> `USED_GOODS_BOARD`와 `USED_GOODS_USER` 테이블에서 `완료된 중고 거래`의 `총금액이 70만 원 이상`인 사람의 `회원 ID, 닉네임, 총거래금액`을 조회하는 SQL문을 작성해주세요. 결과는 `총거래금액을 기준으로 오름차순` 정렬해주세요.


<br><br>


### 풀이🔎  
#### `USED_GOODS_BOARD` 테이블 살펴보기
```sql
SELECT      *
FROM        USED_GOODS_BOARD
;
```
  - `반려견 배변패드` 같은 것을 파는구나
  - 거래완료는 `STATUS` 칼럼이 `DONE` 이라고 되어있음
  - 등록날짜(`CREATED_DATE`)는 `DATE` 타입이기 때문에 포멧지정 필요할 것 같음
    - 정답과는 상관 없음

<br>

#### `USED_GOODS_USER` 테이블 살펴보기
```sql
SELECT      *
FROM        USED_GOODS_USER
;
```
  - 주소가 모두 `성남` 임
  - 전화번호가 진짜일까?
  - `WRITER_ID` 와 `USER_ID` 를 `JOIN`하면 좋을 것 같음

<br>

#### 테이블 합치기
```sql
SELECT      *
FROM        USED_GOODS_BOARD B
JOIN        USED_GOODS_USER U
      ON    B.WRITER_ID = U.USER_ID
;
```

<br>

#### `완료된 중고 거래` 조회하기
```sql
SELECT      *
FROM        USED_GOODS_BOARD B
JOIN        USED_GOODS_USER U
      ON    B.WRITER_ID = U.USER_ID
WHERE       STATUS = 'DONE'
;
```

<br>

#### 작성자ID 별 `총금액` 조회하기
```sql
SELECT      *, SUM(PRICE) AS TOTAL_SALES
FROM        USED_GOODS_BOARD B
JOIN        USED_GOODS_USER U
      ON    B.WRITER_ID = U.USER_ID
WHERE       STATUS = 'DONE'
GROUP BY    WRITER_ID
;
```

<br>

#### `총금액이 70만원 이상인 사람` 조회하기
```sql
SELECT      *, SUM(PRICE) AS TOTAL_SALES
FROM        USED_GOODS_BOARD B
JOIN        USED_GOODS_USER U
      ON    B.WRITER_ID = U.USER_ID
WHERE       STATUS = 'DONE'
GROUP BY    WRITER_ID
HAVING      TOTAL_SALES >= 700000
;
```

<br>

#### `회원 ID, 닉네임, 총거래금액을 총거래금액 기준으로 오름차순` 정렬하기
```sql
SELECT      USER_ID, NICKNAME, SUM(PRICE) AS TOTAL_SALES
FROM        USED_GOODS_BOARD B
JOIN        USED_GOODS_USER U
      ON    B.WRITER_ID = U.USER_ID
WHERE       STATUS = 'DONE'
GROUP BY    WRITER_ID
HAVING      TOTAL_SALES >= 700000
ORDER BY    TOTAL_SALES ASC
;
```
  - 통과🎉




<br><br><br><br>




## JOIN : 있었는데요 없었습니다

### 문제 설명과 문제📜  

#### 문제 설명  
> `ANIMAL_INS` 테이블은 동물 보호소에 들어온 동물의 정보를 담은 테이블입니다. `ANIMAL_INS` 테이블 구조는 다음과 같으며, `ANIMAL_ID, ANIMAL_TYPE, DATETIME, INTAKE_CONDITION, NAME, SEX_UPON_INTAKE`는 각각 동물의 아이디, 생물 종, 보호 시작일, 보호 시작 시 상태, 이름, 성별 및 중성화 여부를 나타냅니다.

| NAME              |	TYPE	      | NULLABLE  |
| :---:             | :---:       | :---:     |
| ANIMAL_ID         |	VARCHAR(N)	| FALSE     |
| ANIMAL_TYPE       |	VARCHAR(N)	| FALSE     |
| DATETIME          |	DATETIME	  | FALSE     |
| INTAKE_CONDITION  |	VARCHAR(N)	| FALSE     |
| NAME              |	VARCHAR(N)	| TRUE      |
| SEX_UPON_INTAKE   |	VARCHAR(N)	| FALSE     |

> `ANIMAL_OUTS` 테이블은 동물 보호소에서 입양 보낸 동물의 정보를 담은 테이블입니다. `ANIMAL_OUTS` 테이블 구조는 다음과 같으며, `ANIMAL_ID, ANIMAL_TYPE, DATETIME, NAME, SEX_UPON_OUTCOME`는 각각 동물의 아이디, 생물 종, 입양일, 이름, 성별 및 중성화 여부를 나타냅니다. `ANIMAL_OUTS` 테이블의 `ANIMAL_ID`는 `ANIMAL_INS`의 `ANIMAL_ID`의 외래 키입니다.

| NAME              |	TYPE	      | NULLABLE  |
| :---:             | :---:       | :---:     |
| ANIMAL_ID         |	VARCHAR(N)	| FALSE     |
| ANIMAL_TYPE       |	VARCHAR(N)	| FALSE     |
| DATETIME          |	DATETIME	  | FALSE     |
| NAME              |	VARCHAR(N)	| TRUE      |
| SEX_UPON_OUTCOME  |	VARCHAR(N)	| FALSE     |

<br> 

#### 문제  
> 관리자의 실수로 일부 동물의 `입양일이 잘못 입력`되었습니다. `보호 시작일보다 입양일이 더 빠른 동물`의 `아이디와 이름을 조회`하는 SQL문을 작성해주세요. 이때 결과는 `보호 시작일이 빠른 순으로 조회`해야합니다.


<br><br>


### 풀이🔎  
#### `ANIMAL_INS` 테이블 살펴보기
```sql
SELECT      *
FROM        ANIMAL_INS
;
```

<br>

#### `ANIMAL_OUTS` 테이블 살펴보기
```sql
SELECT      *
FROM        ANIMAL_OUTS
;
```

<br>

#### 테이블 합치기
```sql
SELECT      OUTS.ANIMAL_ID, OUTS.NAME
FROM        ANIMAL_OUTS OUTS
JOIN        ANIMAL_INS INS
      ON    OUTS.ANIMAL_ID = INS.ANIMAL_ID
;
```

<br>

#### `보호 시작일보다 입양일이 더 빠른 동물` 조회하기
```sql
SELECT      OUTS.ANIMAL_ID, OUTS.NAME
FROM        ANIMAL_OUTS OUTS
JOIN        ANIMAL_INS INS
      ON    OUTS.ANIMAL_ID = INS.ANIMAL_ID
WHERE       OUTS.DATETIME < INS.DATETIME
;
```

<br>

#### `보호 시작일이 빠른 순으로` 조회하기
```sql
SELECT      OUTS.ANIMAL_ID, OUTS.NAME
FROM        ANIMAL_OUTS OUTS
JOIN        ANIMAL_INS INS
      ON    OUTS.ANIMAL_ID = INS.ANIMAL_ID
WHERE       OUTS.DATETIME < INS.DATETIME
ORDER BY    INS.DATETIME ASC
;
```
  - 통과🎉








<br><br><br><br>  
<center>  
<h1>끝까지 읽어주셔서 감사합니다😉</h1>  
</center>  
<br><br><br><br>  


