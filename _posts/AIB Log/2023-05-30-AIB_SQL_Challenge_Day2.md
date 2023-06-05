---

title: "AI 부트캠프 : SQL Challenge Day2"

excerpt: "코드스테이츠와 함께하는 'SQL Challenge' 2일차 회고"

categories:
    - AIB Log

tags:
    - 개발일지
    - 코딩
    - AI 부트캠프
    - 코드스테이츠

header:
    teaser: /assets/images/aib/codestates-ci.png

last_modified_at: 2023-05-30

---


<br><br><br><br>


![image](../../assets/images/etc/sql.png){: .align-center width="70%"}  


<br><br><br><br>




# 코드스테이츠와 함께하는 'SQL Challenge' 2일차  
> 코드스테이츠에서 5월 연휴기간동안 `방학`을 줬다.
> 방학에는 `방학숙제`가 있다.
> 방학숙제는 프로그래머스 스쿨 "`SQL 고득점 Kit`" 하루에 3문제씩 풀기




<br><br><br><br>




## Daily Reflection : 3L 회고
### 배운 것(Learned)
CASE WHEN THEN 구문에 대하여 학습하였다.
{: .notice--success}

<br>

### 아쉬웠던 점(Lacked)
풀이 속도가 느려서 다른 공부를 많이 못했다.
{: .notice--danger}

<br>

### 좋았던 점(Liked)
SQL에 점점 자신감이 생긴다.
{: .notice--warning}




<br><br><br><br>




## SELECT : 강원도에 위치한 생산공장 목록 출력하기

### 문제 설명과 문제📜  

#### 문제 설명  
> 다음은 식품공장의 정보를 담은 `FOOD_FACTORY` 테이블입니다. `FOOD_FACTORY` 테이블은 다음과 같으며 `FACTORY_ID, FACTORY_NAME, ADDRESS, TLNO`는 각각 공장 ID, 공장 이름, 주소, 전화번호를 의미합니다.

| Column name	| Type	        | Nullable  |
| :---:         | :---:         | :---:     |
| FACTORY_ID    | VARCHAR(10)	| FALSE     |
| FACTORY_NAME  | VARCHAR(50)	| FALSE     |
| ADDRESS       | VARCHAR(100)	| FALSE     |
| TLNO          | VARCHAR(20)	| TRUE      |

<br> 

#### 문제  
> `FOOD_FACTORY` 테이블에서 강원도에 위치한 식품공장의 공장 ID, 공장 이름, 주소를 조회하는 SQL문을 작성해주세요. 이때 결과는 공장 ID를 기준으로 오름차순 정렬해주세요.


<br><br>


### 풀이🔎  
#### `FOOD_FACTORY` 테이블 살펴보기
```sql
SELECT      *
FROM        FOOD_FACTORY;
```
  - `강원도에 위치한 식품공장`을 출력하기 위해서는 두가지 방법이 있을 것 같음
    1. `주소(ADDRESS)` 특성에서 `강원도` 문자가 포함된 케이스 추출
    2. `전화번호(TLNO)` 특성에서 `강원도 지역번호(033)`으로 시작하는 케이스 추출
  - `전화번호(TLNO)` 특성에는 결측치가 있기 때문에, 1번 방식으로 강원도를 추출하자

<br>

#### `강원도에 위치한 식품공장` 출력하기
```sql
SELECT      *
FROM        FOOD_FACTORY
WHERE       ADDRESS LIKE '%강원_%'
;
```
  - `WHERE LIKE + % , _` 으로 문자열 매칭 조건 검색하기
    - `WHERE ADDRESS LIKE '강원도%'` : `강원도`로 시작하는 케이스
    - `WHERE ADDRESS LIKE '%강원도'` : `강원도`로 끝나는 케이스
    - `WHERE ADDRESS LIKE '%강원도%'` : `강원도`가 포함되는 케이스
    - `WHERE ADDRESS LIKE '%강__'` : `강`으로 시작하고 아무문자2개가 따라오는 케이스
    - `WHERE ADDRESS NOT LIKE '%강원도%'` : `강원도`가 포함되지 않은 케이스

<br>

#### 추가 : `전화번호가 033으로 시작`하는 케이스 출력하기
```sql
SELECT      *
FROM        FOOD_FACTORY
WHERE       TLNO LIKE '033%'
;
```
  - `전화번호가 033으로 시작`하는 케이스로 조회해도 위랑 똑같은 결과를 얻음

<br>

#### 출력형식에 맞춰 출력하기
```sql
SELECT      FACTORY_ID, FACTORY_NAME, ADDRESS
FROM        FOOD_FACTORY
WHERE       TLNO LIKE '033%'
ORDER   BY  FACTORY_ID ASC
;
```
  - `ORDER BY FACTORY_ID ASC`에서 ASC는 기본값이기 때문에 생략 가능
    - `ORDER BY FACTORY_ID`
  - `WHERE TLNO LIKE '033%'`대신 `WHERE ADDRESS LIKE '강원도%'`처럼 `강원도`로 시작하는 주소로 출력해도 똑같음




<br><br><br><br>




## SUM, MAX, MIN : 가격이 제일 비싼 식품의 정보 출력하기  

### 문제 설명과 문제📜  

#### 문제 설명  
> 다음은 식품의 정보를 담은 `FOOD_PRODUCT` 테이블입니다. `FOOD_PRODUCT` 테이블은 다음과 같으며 `PRODUCT_ID, PRODUCT_NAME, PRODUCT_CD, CATEGORY, PRICE`는 식품 ID, 식품 이름, 식품 코드, 식품분류, 식품 가격을 의미합니다.

| Column name	| Type	        | Nullable  |
| :---:         | :---:         | :---:     |
| PRODUCT_ID    | VARCHAR(10)	| FALSE     |
| PRODUCT_NAME  | VARCHAR(50)	| FALSE     |
| PRODUCT_CD    | VARCHAR(10)	| TRUE      |
| CATEGORY      | VARCHAR(10)	| TRUE      |
| PRICE         | NUMBER	    | TRUE      |

<br>

#### 문제  
> `FOOD_PRODUCT` 테이블에서 가격이 제일 비싼 식품의 식품 ID, 식품 이름, 식품 코드, 식품분류, 식품 가격을 조회하는 SQL문을 작성해주세요.


<br><br>


### 풀이🔎  

#### `FOOD_PRODUCT` 테이블 `PRICE`으로 내림차순 정렬하여 살펴보기
```sql
SELECT      *
FROM        FOOD_PRODUCT
ORDER   BY  PRICE DESC
;
```
  - `PRICE`으로 내림차순 정렬하여 살펴보면
    -`P0051	맛있는배추김치	CD_KC00001	김치	19000`이 가장 비싼 식품
  - `LIMIT 1`만 추가해도 될 것 같음

<br>

#### `LIMIT 1`로 가격이 제일 비싼 식품 출력하기
```sql
SELECT      *
FROM        FOOD_PRODUCT
ORDER   BY  PRICE DESC
LIMIT       1
;
```
  - 통과🎉

<br>

#### 추가 : `MAX()`함수 이용하여 가격이 제일 비싼 식품 출력하기
```sql
SELECT      PRODUCT_ID, PRODUCT_NAME, PRODUCT_CD, CATEGORY, MAX(PRICE)
FROM        FOOD_PRODUCT
;
```
  - 이렇게 하면, `MAX(PRICE)`는 최대값이 나오는데, 나머지 칼럼은 1번 인덱스의 값들이 표시됨

<br>

#### 추가 : `MAX()`함수 + `WHERE 서브쿼리`
```sql
SELECT      *
FROM        FOOD_PRODUCT
WHERE       PRICE = (
                    SELECT      MAX(PRICE)
                    FROM        FOOD_PRODUCT
                    )
;
```
  - 통과🎉
  - 출제자의 의도는 `MAX(PRICE)`를 사용하는 것이 맞을 것 같음




<br><br><br><br>




## GROUP BY : 식품분류별 가장 비싼 식품의 정보 조회하기  

### 문제 설명과 문제📜  

#### 문제 설명  
> 다음은 식품의 정보를 담은 `FOOD_PRODUCT` 테이블입니다. `FOOD_PRODUCT` 테이블은 다음과 같으며 `PRODUCT_ID, PRODUCT_NAME, PRODUCT_CD, CATEGORY, PRICE`는 식품 ID, 식품 이름, 식품코드, 식품분류, 식품 가격을 의미합니다.

| Column name	| Type	        | Nullable  |
| :---:         | :---:         | :---:     |
| PRODUCT_ID    | VARCHAR(10)	| FALSE     |
| PRODUCT_NAME  | VARCHAR(50)	| FALSE     |
| PRODUCT_CD    | VARCHAR(10)	| TRUE      |
| CATEGORY      | VARCHAR(10)	| TRUE      |
| PRICE         | NUMBER	    | TRUE      |

<br>

#### 문제  
> `FOOD_PRODUCT` 테이블에서 식품분류별로 가격이 제일 비싼 식품의 분류, 가격, 이름을 조회하는 SQL문을 작성해주세요. 이때 식품분류가 '과자', '국', '김치', '식용유'인 경우만 출력시켜 주시고 결과는 식품 가격을 기준으로 내림차순 정렬해주세요.


<br><br>


### 풀이🔎  

#### `FOOD_PRODUCT` 테이블 살펴보기
```sql
SELECT      *
FROM        FOOD_PRODUCT
;
```
  - `CATEGORY` 에는 면, 식용유 등이 있음

<br>

#### 식품분류별 가격이 제일 비싼 식품의 가격 출력하기
```sql
SELECT      MAX(PRICE)
FROM        FOOD_PRODUCT
GROUP   BY  CATEGORY
;
```
  - 가장 비싼 식용유 `P0012 맛있는올리브유 CD_OL00002 식용유 7200`
  - 가장 비싼 김치 `P0051 맛있는배추김치 CD_KC00001 김치 19000`

<br>

#### `WHERE 서브쿼리 + MAX()` 사용하여 식품분류별 가격이 제일 비싼 식품의 가격 출력하기
```sql
SELECT      *
FROM        FOOD_PRODUCT
WHERE       PRICE IN (
                    SELECT      MAX(PRICE)
                    FROM        FOOD_PRODUCT
                    GROUP   BY  CATEGORY
                    )
;
```

<br>

#### `식품분류가 '과자', '국', '김치', '식용유'인 경우`만 출력하기
```sql
SELECT      *
FROM        FOOD_PRODUCT
WHERE       PRICE IN (
                    SELECT      MAX(PRICE)
                    FROM        FOOD_PRODUCT
                    GROUP   BY  CATEGORY
                    )
        AND CATEGORY IN ('과자', '국', '김치', '식용유')
;
```

<br>

#### 식품의 분류, 가격, 이름을 식품 가격을 기준으로 내림차순 정렬
```sql
SELECT      CATEGORY, PRICE, PRODUCT_NAME
FROM        FOOD_PRODUCT
WHERE       PRICE IN (
                    SELECT      MAX(PRICE)
                    FROM        FOOD_PRODUCT
                    GROUP   BY  CATEGORY
                    )
        AND CATEGORY IN ('과자', '국', '김치', '식용유')
ORDER   BY  PRICE DESC
;
```
  - 통과🎉
  - 예시에는 `MAX_PRICE`라고 쓰라고 되어있는데, 그냥 `PRICE`를 사용해도 통과된다
  - `MAX_PRICE`로 바꿔도 통과 된다




<br><br><br><br>




## JOIN : 주문량이 많은 아이스크림들 조회하기  

### 문제 설명과 문제📜  

#### 문제 설명  
> 다음은 아이스크림 가게의 상반기 주문 정보를 담은 `FIRST_HALF` 테이블과 7월의 아이스크림 주문 정보를 담은 `JULY` 테이블입니다.
> `FIRST_HALF` 테이블 구조는 다음과 같으며, `SHIPMENT_ID, FLAVOR, TOTAL_ORDER`는 각각 아이스크림 공장에서 아이스크림 가게까지의 출하 번호, 아이스크림 맛, 상반기 아이스크림 총주문량을 나타냅니다.
> `FIRST_HALF` 테이블의 기본 키는 `FLAVOR`입니다. `FIRST_HALF`테이블의 `SHIPMENT_ID`는 `JULY`테이블의 `SHIPMENT_ID`의 외래 키입니다.

| NAME        | TYPE	      | NULLABLE  |
| :---:       | :---:       | :---:     |
| SHIPMENT_ID | INT(N)	    | FALSE     |
| FLAVOR      | VARCHAR(N)  | FALSE     |
| TOTAL_ORDER | INT(N)	    | FALSE     |

> `JULY` 테이블 구조는 다음과 같으며, `SHIPMENT_ID, FLAVOR, TOTAL_ORDER` 은 각각 아이스크림 공장에서 아이스크림 가게까지의 출하 번호, 아이스크림 맛, 7월 아이스크림 총주문량을 나타냅니다.
> `JULY` 테이블의 기본 키는 `SHIPMENT_ID`입니다. `JULY`테이블의 `FLAVOR`는 `FIRST_HALF` 테이블의 `FLAVOR`의 외래 키입니다.
> 7월에는 아이스크림 주문량이 많아 같은 아이스크림에 대하여 서로 다른 두 공장에서 아이스크림 가게로 출하를 진행하는 경우가 있습니다. 이 경우 같은 맛의 아이스크림이라도 다른 출하 번호를 갖게 됩니다.

| NAME        | TYPE	      | NULLABLE  |
| :---:       | :---:       | :---:     |
| SHIPMENT_ID | INT(N)	    | FALSE     |
| FLAVOR      | VARCHAR(N)  | FALSE     |
| TOTAL_ORDER | INT(N)	    | FALSE     |

<br>

#### 문제  
> 7월 아이스크림 총 주문량과 상반기의 아이스크림 총 주문량을 더한 값이 큰 순서대로 상위 3개의 맛을 조회하는 SQL 문을 작성해주세요.


<br><br>


### 풀이🔎  

#### `FIRST_HALF` 테이블 살펴보기
```sql
SELECT      *
FROM        FIRST_HALF
;
```
  - 7개 케이스

<br>

#### `JULY` 테이블 살펴보기
```sql
SELECT      *
FROM        JULY
;
```
  - 8개 케이스
  - `strawberry` 맛의 `SHIPMENT_ID`가 109, 209 두 개임

<br>

#### `UNION` 으로 두 테이블 세로로 합치기
```sql
SELECT      *
FROM        FIRST_HALF
UNION
SELECT      *
FROM        JULY
;
```
  - 15개 케이스의 `UNION 된 테이블`이 생성 되었음

<br>

#### 맛(FLAVOR) 별 TOTAL_ORDER 합계 출력하기
```sql
SELECT      *, SUM(TOTAL_ORDER) AS SUM_ORDER
FROM        (
            SELECT      *
            FROM        FIRST_HALF
            UNION
            SELECT      *
            FROM        JULY
            ) AS UNION_TABLE
GROUP BY    FLAVOR
;
```

<br>

#### 내림차순 정렬하고 상위 3개만 출력하기
```sql
SELECT      *, SUM(TOTAL_ORDER) AS SUM_ORDER
FROM        (
            SELECT      *
            FROM        FIRST_HALF
            UNION
            SELECT      *
            FROM        JULY
            ) AS UNION_TABLE
GROUP BY    FLAVOR
ORDER BY    SUM_ORDER DESC
LIMIT       3
;
```

<br>

#### 이름만 출력하기
```sql
SELECT      FLAVOR
FROM        (
            SELECT      *, SUM(TOTAL_ORDER) AS SUM_ORDER
            FROM        (
                        SELECT      *
                        FROM        FIRST_HALF
                        UNION
                        SELECT      *
                        FROM        JULY
                        ) AS UNION_TABLE
            GROUP BY    FLAVOR
            ORDER BY    SUM_ORDER DESC
            LIMIT       3
            ) AS FINAL_TABLE
;
```
  - 통과🎉
  - 다른 사람들의 풀이에서는 `JOIN에 서브쿼리`를 사용하였던데, 그것보다 이렇게 `UNION`을 사용하는 것이 더 직관적인 것 같음
  - 출제자의 의도는 JOIN을 사용하라는 것 같은데...🤫




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


