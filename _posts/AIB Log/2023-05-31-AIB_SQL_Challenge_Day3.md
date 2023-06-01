---

title: "AI 부트캠프 : SQL Challenge Day3"

excerpt: "코드스테이츠와 함께하는 'SQL Challenge' 3일차 회고"

categories:
    - AIB Log

tags:
    - 개발일지
    - 코딩
    - AI 부트캠프
    - 코드스테이츠

header:
    teaser: /assets/images/aib/codestates-ci.png

last_modified_at: 2023-05-31

---


<br><br><br><br>


![image](../../assets/images/etc/sql.png){: .align-center width="70%"}  


<br><br><br><br>




# 코드스테이츠와 함께하는 'SQL Challenge' 3일차  
> 코드스테이츠에서 5월 연휴기간동안 `방학`을 줬다.
> 방학에는 `방학숙제`가 있다.
> 방학숙제는 프로그래머스 스쿨 "`SQL 고득점 Kit`" 하루에 3문제씩 풀기




<br><br><br><br>




## Daily Reflection : 3L 회고
### 배운 것(Learned)
aa
{: .notice--success}

<br>

### 아쉬웠던 점(Lacked)
풀
{: .notice--danger}

<br>

### 좋았던 점(Liked)
S
{: .notice--warning}




<br><br><br><br>




## SELECT : 서울에 위치한 식당 목록 출력하기

### 문제 설명과 문제📜  

#### 문제 설명  
> 다음은 식당의 정보를 담은 `REST_INFO` 테이블과 식당의 리뷰 정보를 담은 `REST_REVIEW` 테이블입니다. `REST_INFO` 테이블은 다음과 같으며 `REST_ID, REST_NAME, FOOD_TYPE, VIEWS, FAVORITES, PARKING_LOT, ADDRESS, TEL`은 식당 ID, 식당 이름, 음식 종류, 조회수, 즐겨찾기수, 주차장 유무, 주소, 전화번호를 의미합니다.

| Column name	| Type	        | Nullable  |
| :---:       | :---:         | :---:     |
| REST_ID     | VARCHAR(5)	  | FALSE     |
| REST_NAME   | VARCHAR(50)	  | FALSE     |
| FOOD_TYPE   | VARCHAR(20)	  | TRUE      |
| VIEWS       | NUMBER	      | TRUE      |
| FAVORITES   | NUMBER	      | TRUE      |
| PARKING_LOT | VARCHAR(1)	  | TRUE      |
| ADDRESS     | VARCHAR(100)	| TRUE      |
| TEL         | VARCHAR(100)	| TRUE      |

> `REST_REVIEW` 테이블은 다음과 같으며 `REVIEW_ID, REST_ID, MEMBER_ID, REVIEW_SCORE, REVIEW_TEXT,REVIEW_DATE`는 각각 리뷰 ID, 식당 ID, 회원 ID, 점수, 리뷰 텍스트, 리뷰 작성일을 의미합니다.

| Column name   | Type	        | Nullable  |
| :---:         | :---:         | :---:     |
| REVIEW_ID	    | VARCHAR(10)	  | FALSE     |
| REST_ID	      | VARCHAR(10)	  | TRUE      |
| MEMBER_ID	    | VARCHAR(100)	| TRUE      |
| REVIEW_SCORE	| NUMBER	      | TRUE      |
| REVIEW_TEXT	  | VARCHAR(1000)	| TRUE      |
| REVIEW_DATE	  | DATE	        | TRUE      |


<br> 

#### 문제  
> `REST_INFO`와 `REST_REVIEW` 테이블에서 서울에 위치한 식당들의 식당 ID, 식당 이름, 음식 종류, 즐겨찾기수, 주소, 리뷰 평균 점수를 조회하는 SQL문을 작성해주세요. 이때 리뷰 평균점수는 소수점 세 번째 자리에서 반올림 해주시고 결과는 평균점수를 기준으로 내림차순 정렬해주시고, 평균점수가 같다면 즐겨찾기수를 기준으로 내림차순 정렬해주세요.


<br><br>


### 풀이🔎  
#### `REST_INFO` 테이블 살펴보기
```sql
SELECT      *
FROM        REST_INFO;
```
  - 주소(ADDRESS)가 `서울`로 시작하는 케이스로 조건 출력하면 될 것 같음

<br>

#### `REST_REVIEW` 테이블 살펴보기
```sql
SELECT      *
FROM        REST_REVIEW;
```

<br>

#### 테이블 `JOIN`
```sql
SELECT      *
FROM        REST_INFO AS INFO
JOIN        REST_REVIEW AS REVIEW
        ON  INFO.REST_ID = REVIEW.REST_ID
;
```

<br>

#### `서울에 위치한 식당` 출력하기
```sql
SELECT      *
FROM        REST_INFO AS INFO
JOIN        REST_REVIEW AS REVIEW
    ON      INFO.REST_ID = REVIEW.REST_ID
GROUP BY    INFO.REST_ID
HAVING      INFO.ADDRESS LIKE '서울%'
;
```

<br>

#### `식당 ID, 식당 이름, 음식 종류, 즐겨찾기수, 주소, 리뷰 평균 점수` 출력하기
```sql
SELECT      INFO.REST_ID, INFO.REST_NAME, INFO.FOOD_TYPE, INFO.FAVORITES, INFO.ADDRESS,
            ROUND(AVG(REVIEW.REVIEW_SCORE), 2) AS SCORE
FROM        REST_INFO AS INFO
JOIN        REST_REVIEW AS REVIEW
        ON  INFO.REST_ID = REVIEW.REST_ID
GROUP BY    REST_ID
HAVING      INFO.ADDRESS LIKE '서울%'
;
```

<br>

#### 출력형식에 맞춰 출력하기
```sql
SELECT      INFO.REST_ID, INFO.REST_NAME, INFO.FOOD_TYPE, INFO.FAVORITES, INFO.ADDRESS,
            ROUND(AVG(REVIEW.REVIEW_SCORE), 2) AS SCORE
FROM        REST_INFO AS INFO
JOIN        REST_REVIEW AS REVIEW
        ON  INFO.REST_ID = REVIEW.REST_ID
GROUP BY    REST_ID
HAVING      INFO.ADDRESS LIKE '서울%'
ORDER BY    SCORE DESC, INFO.FAVORITES DESC
;
```




<br><br><br><br>




## GROUP BY : 자동차 종류 별 특정 옵션이 포함된 자동차 수 구하기  

### 문제 설명과 문제📜  

#### 문제 설명  
> 다음은 어느 자동차 대여 회사에서 대여중인 자동차들의 정보를 담은 `CAR_RENTAL_COMPANY_CAR` 테이블입니다. `CAR_RENTAL_COMPANY_CAR` 테이블은 아래와 같은 구조로 되어있으며, `CAR_ID, CAR_TYPE, DAILY_FEE, OPTIONS` 는 각각 자동차 ID, 자동차 종류, 일일 대여 요금(원), 자동차 옵션 리스트를 나타냅니다.

| Column name	| Type	        | Nullable  |
| :---:       | :---:         | :---:     |
| CAR_ID      | INTEGER	      | FALSE     |
| CAR_TYPE    | VARCHAR(255)	| FALSE     |
| DAILY_FEE   | INTEGER	      | FALSE     |
| OPTIONS     | VARCHAR(255)	| FALSE     |

> 자동차 종류는 '세단', 'SUV', '승합차', '트럭', '리무진' 이 있습니다. 자동차 옵션 리스트는 콤마(',')로 구분된 키워드 리스트(옵션 리스트 값 예시: '열선시트', '스마트키', '주차감지센서')로 되어있으며, 키워드 종류는 '주차감지센서', '스마트키', '네비게이션', '통풍시트', '열선시트', '후방카메라', '가죽시트' 가 있습니다.

<br>

#### 문제  
> `CAR_RENTAL_COMPANY_CAR` 테이블에서 '통풍시트', '열선시트', '가죽시트' 중 하나 이상의 옵션이 포함된 자동차가 자동차 종류 별로 몇 대인지 출력하는 SQL문을 작성해주세요. 이때 자동차 수에 대한 컬럼명은 `CARS`로 지정하고, 결과는 자동차 종류를 기준으로 오름차순 정렬해주세요.


<br><br>


### 풀이🔎  

#### 식품의 분류, 가격, 이름을 식품 가격을 기준으로 내림차순 정렬
```sql
SELECT      CAR_TYPE, COUNT(CAR_TYPE) AS CARS
FROM        CAR_RENTAL_COMPANY_CAR
WHERE       OPTIONS LIKE '%열선시트%'
    OR      OPTIONS LIKE '%통풍시트%'
    OR      OPTIONS LIKE '%가죽시트%'
GROUP BY    CAR_TYPE
ORDER BY    CAR_TYPE ASC
;
```
  - 통과🎉




<br><br><br><br>




## JOIN : 특정 기간동안 대여 가능한 자동차들의 대여비용 구하기  

### 문제 설명과 문제📜  

#### 문제 설명  
> 다음은 어느 자동차 대여 회사에서 대여 중인 자동차들의 정보를 담은 `CAR_RENTAL_COMPANY_CAR` 테이블과 자동차 대여 기록 정보를 담은 `CAR_RENTAL_COMPANY_RENTAL_HISTORY` 테이블과 자동차 종류 별 대여 기간 종류 별 할인 정책 정보를 담은 `CAR_RENTAL_COMPANY_DISCOUNT_PLAN` 테이블 입니다.
> `CAR_RENTAL_COMPANY_CAR` 테이블은 아래와 같은 구조로 되어있으며, `CAR_ID, CAR_TYPE, DAILY_FEE, OPTIONS` 는 각각 자동차 ID, 자동차 종류, 일일 대여 요금(원), 자동차 옵션 리스트를 나타냅니다.

| Column name	| Type	        | Nullable  |
| :---:       | :---:         | :---:     |
| CAR_ID      | INTEGER	      | FALSE     |
| CAR_TYPE    | VARCHAR(255)	| FALSE     |
| DAILY_FEE   | INTEGER	      | FALSE     |
| OPTIONS     | VARCHAR(255)	| FALSE     |

> 자동차 종류는 '세단', 'SUV', '승합차', '트럭', '리무진' 이 있습니다. 자동차 옵션 리스트는 콤마(',')로 구분된 키워드 리스트(예: ''열선시트,스마트키,주차감지센서'')로 되어있으며, 키워드 종류는 '주차감지센서', '스마트키', '네비게이션', '통풍시트', '열선시트', '후방카메라', '가죽시트' 가 있습니다.

> `CAR_RENTAL_COMPANY_RENTAL_HISTORY` 테이블은 아래와 같은 구조로 되어있으며, `HISTORY_ID, CAR_ID, START_DATE, END_DATE` 는 각각 자동차 대여 기록 ID, 자동차 ID, 대여 시작일, 대여 종료일을 나타냅니다.

| Column name	| Type	    | Nullable  |
| :---:       | :---:     | :---:     |
| HISTORY_ID  | INTEGER   | FALSE     |
| CAR_ID      | INTEGER   | FALSE     |
| START_DATE  | DATE      | FALSE     |
| END_DATE    | DATE      | FALSE     |

> `CAR_RENTAL_COMPANY_DISCOUNT_PLAN` 테이블은 아래와 같은 구조로 되어있으며, `PLAN_ID, CAR_TYPE, DURATION_TYPE, DISCOUNT_RATE` 는 각각 요금 할인 정책 ID, 자동차 종류, 대여 기간 종류, 할인율(%)을 나타냅니다.

| Column name	  | Type	        | Nullable  |
| :---:         | :---:         | :---:     |
| PLAN_ID       | INTEGER	      | FALSE     |
| CAR_TYPE      | VARCHAR(255)	| FALSE     |
| DURATION_TYPE | VARCHAR(255)	| FALSE     |
| DISCOUNT_RATE | INTEGER	      | FALSE     |

> 할인율이 적용되는 대여 기간 종류로는 '7일 이상' (대여 기간이 7일 이상 30일 미만인 경우), '30일 이상' (대여 기간이 30일 이상 90일 미만인 경우), '90일 이상' (대여 기간이 90일 이상인 경우) 이 있습니다. 대여 기간이 7일 미만인 경우 할인정책이 없습니다.

<br>

#### 문제  
> `CAR_RENTAL_COMPANY_CAR` 테이블과 `CAR_RENTAL_COMPANY_RENTAL_HISTORY` 테이블과 `CAR_RENTAL_COMPANY_DISCOUNT_PLAN` 테이블에서 자동차 종류가 '세단' 또는 'SUV' 인 자동차 중 2022년 11월 1일부터 2022년 11월 30일까지 대여 가능하고 30일간의 대여 금액이 50만원 이상 200만원 미만인 자동차에 대해서 자동차 ID, 자동차 종류, 대여 금액(컬럼명: FEE) 리스트를 출력하는 SQL문을 작성해주세요. 결과는 대여 금액을 기준으로 내림차순 정렬하고, 대여 금액이 같은 경우 자동차 종류를 기준으로 오름차순 정렬, 자동차 종류까지 같은 경우 자동차 ID를 기준으로 내림차순 정렬해주세요.


<br><br>


### 풀이🔎  


#### `CAR_RENTAL_COMPANY_CAR` 테이블 살펴보기
```sql
SELECT      *
FROM        CAR_RENTAL_COMPANY_CAR
;
```

<br>

#### `CAR_RENTAL_COMPANY_RENTAL_HISTORY` 테이블 살펴보기
```sql
SELECT      *
FROM        CAR_RENTAL_COMPANY_RENTAL_HISTORY
;
```

<br>

#### `CAR_RENTAL_COMPANY_DISCOUNT_PLAN` 테이블 살펴보기
```sql
SELECT      *
FROM        CAR_RENTAL_COMPANY_DISCOUNT_PLAN
;
```

<br>

#### 세 테이블 합치기
```sql
SELECT      *
FROM        CAR_RENTAL_COMPANY_CAR AS C
JOIN        CAR_RENTAL_COMPANY_RENTAL_HISTORY AS H
      ON    C.CAR_ID = H.CAR_ID
JOIN        CAR_RENTAL_COMPANY_DISCOUNT_PLAN AS P
      ON    C.CAR_TYPE = P.CAR_TYPE
;
```

<br>

#### `2022년 11월 1일부터 2022년 11월 30일까지 대여 가능`한 자동차 조회하기
```sql
SELECT      *
FROM        CAR_RENTAL_COMPANY_CAR AS C
JOIN        CAR_RENTAL_COMPANY_RENTAL_HISTORY AS H
      ON    C.CAR_ID = H.CAR_ID
JOIN        CAR_RENTAL_COMPANY_DISCOUNT_PLAN AS P
      ON    C.CAR_TYPE = P.CAR_TYPE
WHERE       C.CAR_ID NOT IN (
                            SELECT CAR_ID
                            FROM CAR_RENTAL_COMPANY_RENTAL_HISTORY
                            WHERE END_DATE > '2022-11-01' AND START_DATE < '2022-12-01'
                            )
;
```

<br>

#### `자동차 종류가 '세단' 또는 'SUV' 인 자동차` 조회하기
```sql
SELECT      *
FROM        CAR_RENTAL_COMPANY_CAR AS C
JOIN        CAR_RENTAL_COMPANY_RENTAL_HISTORY AS H
      ON    C.CAR_ID = H.CAR_ID
JOIN        CAR_RENTAL_COMPANY_DISCOUNT_PLAN AS P
      ON    C.CAR_TYPE = P.CAR_TYPE
WHERE       C.CAR_ID NOT IN (
                            SELECT CAR_ID
                            FROM CAR_RENTAL_COMPANY_RENTAL_HISTORY
                            WHERE END_DATE > '2022-11-01' AND START_DATE < '2022-12-01'
                            )
GROUP BY    C.CAR_ID
HAVING      C.CAR_TYPE IN ('세단', 'SUV')
;
```

<br>

#### `30일 이상 대여가능한 자동차` 조회하기
```sql
SELECT      *
FROM        CAR_RENTAL_COMPANY_CAR AS C
JOIN        CAR_RENTAL_COMPANY_RENTAL_HISTORY AS H
      ON    C.CAR_ID = H.CAR_ID
JOIN        CAR_RENTAL_COMPANY_DISCOUNT_PLAN AS P
      ON    C.CAR_TYPE = P.CAR_TYPE
WHERE       C.CAR_ID NOT IN (
                            SELECT CAR_ID
                            FROM CAR_RENTAL_COMPANY_RENTAL_HISTORY
                            WHERE END_DATE > '2022-11-01' AND START_DATE < '2022-12-01'
                            )
      AND   P.DURATION_TYPE='30일 이상'
GROUP BY    C.CAR_ID
HAVING      C.CAR_TYPE IN ('세단', 'SUV')
;
```

<br>

#### `대여 금액이 50만원 이상 200만원 미만인 자동차` 조회하기
```sql
SELECT      *,
            ROUND(DAILY_FEE*30*(100-DISCOUNT_RATE)/100) AS FEE
FROM        CAR_RENTAL_COMPANY_CAR AS C
JOIN        CAR_RENTAL_COMPANY_RENTAL_HISTORY AS H
      ON    C.CAR_ID = H.CAR_ID
JOIN        CAR_RENTAL_COMPANY_DISCOUNT_PLAN AS P
      ON    C.CAR_TYPE = P.CAR_TYPE
WHERE       C.CAR_ID NOT IN (
                            SELECT CAR_ID
                            FROM CAR_RENTAL_COMPANY_RENTAL_HISTORY
                            WHERE END_DATE > '2022-11-01' AND START_DATE < '2022-12-01'
                            )
      AND   P.DURATION_TYPE='30일 이상'
GROUP BY    C.CAR_ID
HAVING      C.CAR_TYPE IN ('세단', 'SUV')
      AND   (FEE>=500000 AND FEE<2000000)
;
```

<br>

#### `자동차 ID, 자동차 종류, 대여 금액`을 정렬조건에 맞게 조회하기
```sql
SELECT      C.CAR_ID, C.CAR_TYPE,
            ROUND(DAILY_FEE*30*(100-DISCOUNT_RATE)/100) AS FEE
FROM        CAR_RENTAL_COMPANY_CAR AS C
JOIN        CAR_RENTAL_COMPANY_RENTAL_HISTORY AS H
      ON    C.CAR_ID = H.CAR_ID
JOIN        CAR_RENTAL_COMPANY_DISCOUNT_PLAN AS P
      ON    C.CAR_TYPE = P.CAR_TYPE
WHERE       C.CAR_ID NOT IN (
                            SELECT CAR_ID
                            FROM CAR_RENTAL_COMPANY_RENTAL_HISTORY
                            WHERE END_DATE > '2022-11-01' AND START_DATE < '2022-12-01'
                            )
      AND   P.DURATION_TYPE='30일 이상'
GROUP BY    C.CAR_ID
HAVING      C.CAR_TYPE IN ('세단', 'SUV')
      AND   (FEE>=500000 AND FEE<2000000)
ORDER BY    FEE DESC, CAR_TYPE, CAR_ID DESC
;
```
  - 통과🎉




<br><br><br><br>




## IS NULL : 경기도에 위치한 식품창고 목록 출력하기  

### 문제 설명과 문제📜  

#### 문제 설명  
> 다음은 식품창고의 정보를 담은 `FOOD_WAREHOUSE` 테이블입니다. `FOOD_WAREHOUSE` 테이블은 다음과 같으며 `WAREHOUSE_ID, WAREHOUSE_NAME, ADDRESS, TLNO, FREEZER_YN`는 창고 ID, 창고 이름, 창고 주소, 전화번호, 냉동시설 여부를 의미합니다.  

| Column name	    | Type          | Nullable  |
| :---:           | :---:         | :---:     |
| WAREHOUSE_ID    |	VARCHAR(10)	  | FALSE     |
| WAREHOUSE_NAME  |	VARCHAR(20)	  | FALSE     |
| ADDRESS         |	VARCHAR(100)	| TRUE      |
| TLNO            |	VARCHAR(20)	  | TRUE      |
| FREEZER_YN      |	VARCHAR(1)	  | TRUE      |

<br>

#### 문제  
> `FOOD_WAREHOUSE` 테이블에서 경기도에 위치한 창고의 ID, 이름, 주소, 냉동시설 여부를 조회하는 SQL문을 작성해주세요. 이때 냉동시설 여부가 NULL인 경우, 'N'으로 출력시켜 주시고 결과는 창고 ID를 기준으로 오름차순 정렬해주세요.


<br><br>


### 풀이🔎  

#### `FOOD_WAREHOUSE` 테이블 살펴보기
```sql
SELECT      *
FROM        FOOD_WAREHOUSE
;
```
  - 경기도에 위치한 창고의 위치를 찾는 방법은 3가지가 있을 것 같음
    1. `WAREHOUSE_NAME`에서 `경기`로 조회하는 방법
    2. `ADDRESS`에서 `경기도`로 조회하는 방법
    3. `TLNO`에서 `031`로 조회하는 방법
  - `WAREHOUSE_NAME`에는 결측치가 없지만, `ADDRESS`, `TLNO`에는 결측치가 있을 수 있기 때문에, `WAREHOUSE_NAME`를 사용하는 것이 좋을것 같음

<br>

#### `WAREHOUSE_NAME`에서 `경기` 포함 조회하기
```sql
SELECT      *
FROM        FOOD_WAREHOUSE
WHERE       WAREHOUSE_NAME LIKE '%경기%'
;
```

<br>

#### 창고의 ID, 이름, 주소, 냉동시설 여부를 출력하는데, 냉동시설 여부가 NULL인 경우, 'N'으로 출력시키기
```sql
SELECT      WAREHOUSE_ID, WAREHOUSE_NAME,
            ADDRESS, IF(FREEZER_YN IS NULL, 'N', FREEZER_YN)
FROM        FOOD_WAREHOUSE
WHERE       WAREHOUSE_NAME LIKE '%경기%'
;
```
  - IF(특성 IS NULL, 결측이면 수행, 아니면 수행)

<br>

#### 오름차순 정렬
```sql
SELECT      WAREHOUSE_ID, WAREHOUSE_NAME,
            ADDRESS, IF(FREEZER_YN IS NULL, 'N', FREEZER_YN)
FROM        FOOD_WAREHOUSE
WHERE       WAREHOUSE_NAME LIKE '%경기%'
ORDER BY    WAREHOUSE_ID
;
```
  - 통과🎉




<br><br><br><br>




## String, Date : 조건에 부합하는 중고거래 상태 조회하기  

### 문제 설명과 문제📜  

#### 문제 설명  
> 다음은 중고거래 게시판 정보를 담은 `USED_GOODS_BOARD` 테이블입니다. `USED_GOODS_BOARD` 테이블은 다음과 같으며 `BOARD_ID, WRITER_ID, TITLE, CONTENTS, PRICE, CREATED_DATE, STATUS, VIEWS`은 게시글 ID, 작성자 ID, 게시글 제목, 게시글 내용, 가격, 작성일, 거래상태, 조회수를 의미합니다.

| Column name	  | Type	        | Nullable  |
| :---:         | :---:         | :---:     |
| BOARD_ID      |	VARCHAR(5)	  | FALSE     |
| WRITER_ID     |	VARCHAR(50)	  | FALSE     |
| TITLE         |	VARCHAR(100)	| FALSE     |
| CONTENTS      |	VARCHAR(1000) | FALSE     |
| PRICE         |	NUMBER	      | FALSE     |
| CREATED_DATE  |	DATE	        | FALSE     |
| STATUS        |	VARCHAR(10)	  | FALSE     |
| VIEWS         |	NUMBER	      | FALSE     |

<br>

#### 문제  
> `USED_GOODS_BOARD` 테이블에서 2022년 10월 5일에 등록된 중고거래 게시물의 게시글 ID, 작성자 ID, 게시글 제목, 가격, 거래상태를 조회하는 SQL문을 작성해주세요. 거래상태가 SALE 이면 판매중, RESERVED이면 예약중, DONE이면 거래완료 분류하여 출력해주시고, 결과는 게시글 ID를 기준으로 내림차순 정렬해주세요.


<br><br>


### 풀이🔎  

#### `USED_GOODS_BOARD` 테이블 살펴보기
```sql
SELECT      *
FROM        USED_GOODS_BOARD
;
```
  - `CREATED_DATE` 특성은 `DATE` 형식이기 때문에 관련 메소드 사용하여 `2022년 10월 5일에 등록` 된 중고거래 조회 가능

<br>

#### 2022년 10월 5일에 등록된 중고거래 조회하기
```sql
SELECT      *
FROM        USED_GOODS_BOARD
WHERE       DATE_FORMAT(CREATED_DATE, '%Y-%m-%d') = '2022-10-05'
;
```
  - 5개 케이스 조회 됨

<br>

#### 게시글 ID, 작성자 ID, 게시글 제목, 가격, 거래상태거래상태가 SALE 이면 판매중, RESERVED이면 예약중, DONE이면 거래완료 분류하여 출력시키기
```sql
SELECT      BOARD_ID, WRITER_ID, TITLE, PRICE,
            CASE  WHEN STATUS = 'SALE' THEN '판매중'
                  WHEN STATUS = 'RESERVED' THEN '예약중'
                  WHEN STATUS = 'DONE' THEN '거래완료'
                  END STATUS
FROM        USED_GOODS_BOARD
WHERE       DATE_FORMAT(CREATED_DATE, '%Y-%m-%d') = '2022-10-05'
;
```

<br>

#### 게시글 ID를 기준으로 내림차순 정렬
```sql
SELECT      BOARD_ID, WRITER_ID, TITLE, PRICE,
            CASE  WHEN STATUS = 'SALE' THEN '판매중'
                  WHEN STATUS = 'RESERVED' THEN '예약중'
                  WHEN STATUS = 'DONE' THEN '거래완료'
                  END AS STATUS
FROM        USED_GOODS_BOARD
WHERE       DATE_FORMAT(CREATED_DATE, '%Y-%m-%d') = '2022-10-05'
ORDER BY    BOARD_ID DESC
;
```
  - 통과🎉
  - `CASE WHEN THEN` 이용하기
    ```sql
    CASE
        WHEN 조건1 THEN 값1
        WHEN 조건2 THEN 값2
        WHEN 조건3 THEN 값3
        ELSE 값4
    END AS alias
    ```






<br><br><br><br>  
<center>  
<h1>끝까지 읽어주셔서 감사합니다😉</h1>  
</center>  
<br><br><br><br>  


