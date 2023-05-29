---

title: "AI 부트캠프 : SQL Challenge Day1"

excerpt: "코드스테이츠와 함께하는 'SQL Challenge' 1일차 회고"

categories:
    - AIB Log

tags:
    - 개발일지
    - 코딩
    - AI 부트캠프
    - 코드스테이츠

header:
    teaser: /assets/images/aib/codestates-ci.png

last_modified_at: 2023-05-29

---


<br><br><br><br>


![image](../../assets/images/etc/sql.png){: .align-center width="70%"}  


<br><br><br><br>




# 코드스테이츠와 함께하는 'SQL Challenge' 1일차  
> 코드스테이츠에서 5월 연휴기간동안 `방학`을 줬다.
> 방학에는 `방학숙제`가 있다.
> 방학숙제는 프로그래머스 스쿨 "`SQL 고득점 Kit`" 하루에 9문제씩 풀기




<br><br><br><br>




## Daily Reflection : 3L 회고
### 배운 것(Learned)
프로젝트 기간 적절히 시간을 분배하여 단게를 넘겨야 프로젝트를 완성할 수 있다.   
{: .notice--success}

<br>

### 아쉬웠던 점(Lacked)
조금 더 데이터를 분석하면, 조금 더 모델을 실험해보면 성능을 올릴 수 있을 것 같은데 다음 단계로 넘어가야 하니깐 아쉬웠다.  
{: .notice--danger}

<br>

### 좋았던 점(Liked)
팀장님이 팀을 잘 이끌어주는 것 같다.  
{: .notice--warning}


<br><br>


## SELECT : 3월에 태어난 여성 회원 목록 출력하기

### 문제 설명과 문제📜  
- 문제 설명  
> 다음은 식당 리뷰 사이트의 회원 정보를 담은 `MEMBER_PROFILE` 테이블입니다. `MEMBER_PROFILE` 테이블은 다음과 같으며 `MEMBER_ID`, `MEMBER_NAME`, `TLNO, GENDER`, `DATE_OF_BIRTH`는 회원 ID, 회원 이름, 회원 연락처, 성별, 생년월일을 의미합니다.

|   Column name	    |   Type	        |   Nullable    |
|   :---:           |   :---:           |   :---:       |
|   MEMBER_ID       |	VARCHAR(100)    |	FALSE       |
|   MEMBER_NAME     |	VARCHAR(50)     |	FALSE       |
|   TLNO            |	VARCHAR(50)     |	TRUE        |
|   GENDER          |	VARCHAR(1)      |	TRUE        |
|   DATE_OF_BIRTH   |	DATE            |	TRUE        |

- 문제  
> `MEMBER_PROFILE` 테이블에서 생일이 3월인 여성 회원의 ID, 이름, 성별, 생년월일을 조회하는 SQL문을 작성해주세요. 이때 전화번호가 NULL인 경우는 출력대상에서 제외시켜 주시고, 결과는 회원ID를 기준으로 오름차순 정렬해주세요.

<br>

### 풀이🔎  
- 문제 접근  
  - `DATE_OF_BIRTH`는 `DATE` 타입이기 때문에 날짜와 관련된 함수들을 사용할 수 있음
  - 생일이 3월 : WHERE 이용
  - 여성 회원 : WHERE 이용
  - 전화번호가 NULL인 경우는 출력대상에서 제외 : WHERE 이용
  - 결과는 회원ID를 기준으로 오름차순 정렬 : ORDER BY 이용

- 나의 답  
```sql
SELECT      MEMBER_ID, MEMBER_NAME, GENDER,
            DATE_FORMAT(DATE_OF_BIRTH, '%Y-%m-%d') AS DATE_OF_BIRTH
FROM        MEMBER_PROFILE
WHERE       MONTH(DATE_OF_BIRTH)=3
    AND     GENDER ='W'
    AND     TLNO IS NOT NULL  
ORDER BY    MEMBER_ID;
```

- 배운 것  
  - 날짜와 관련된 함수
    - DATE_FORMAT(date, format) : 포멧에 따라 날짜와 시간을 출력
    - MONTH(date) : 01~12 사이의 월 출력
    - DAYNAME(date) : Monday 등의 요일을 출력
  - DATE_FORMAT 함수에서 `YYYY-MM-DD`에 해당하는 `'%Y-%m-%d'` 포멧 형식 주의
  - ORDER BY에서 `ORDER BY MEMBER_ID ASC` 처럼 오름차순(ASC), 내림차순(DECS) 지정을 안해도 기본값이 오름차순이기 때문에 생략 가능




<br><br><br><br>




## SELECT : 인기있는 아이스크림

### 문제 설명과 문제📜  
- 문제 설명  
> `FIRST_HALF` 테이블은 아이스크림 가게의 상반기 주문 정보를 담은 테이블입니다. `FIRST_HALF` 테이블 구조는 다음과 같으며, `SHIPMENT_ID`, `FLAVOR`, `TOTAL_ORDER`는 각각 아이스크림 공장에서 아이스크림 가게까지의 출하 번호, 아이스크림 맛, 상반기 아이스크림 총주문량을 나타냅니다.

|   NAME        |	TYPE        |	NULLABLE    |
|   :---:       |   :---:       |   :---:       |
|   SHIPMENT_ID |	INT(N)      |	FALSE       |
|   FLAVOR      |	VARCHAR(N)  |	FALSE       |
|   TOTAL_ORDER |	INT(N)      |	FALSE       |

- 문제  
> 상반기에 판매된 아이스크림의 맛을 총주문량을 기준으로 내림차순 정렬하고 총주문량이 같다면 출하 번호를 기준으로 오름차순 정렬하여 조회하는 SQL 문을 작성해주세요.

<br>

### 풀이🔎  
- 문제 접근  
  - 총주문량을 기준으로 내림차순 정렬 : ORDER BY
  - 총주문량이 같다면 출하 번호를 기준으로 오름차순 정렬 : ORDER BY

- 나의 답  
```sql
SELECT      FLAVOR
FROM        FIRST_HALF
ORDER BY    TOTAL_ORDER DESC, SHIPMENT_ID ASC;
```

- 배운 것  
  - `ORDER BY` 의 중첩 정렬은 순서대로 작동
  - `ORDER BY TOTAL_ORDER DESC, SHIPMENT_ID ASC` 에서 ASC는 기본값이기 때문에 생략 가능
    - `ORDER BY TOTAL_ORDER DESC, SHIPMENT_ID`




<br><br><br><br>




## SELECT : 조건에 부합하는 중고거래 댓글 조회하기

### 문제 설명과 문제📜  
- 문제 설명  
> 다음은 중고거래 게시판 정보를 담은 `USED_GOODS_BOARD` 테이블과 중고거래 게시판 첨부파일 정보를 담은 `USED_GOODS_REPLY` 테이블입니다. `USED_GOODS_BOARD` 테이블은 다음과 같으며 `BOARD_ID, WRITER_ID, TITLE, CONTENTS, PRICE, CREATED_DATE, STATUS, VIEWS`은 게시글 ID, 작성자 ID, 게시글 제목, 게시글 내용, 가격, 작성일, 거래상태, 조회수를 의미합니다.

|   Column name	    |   Type	        |   Nullable    |
|   :---:           |   :---:           |   :---:       |
|   BOARD_ID        |	VARCHAR(5)	    |   FALSE       |
|   WRITER_ID       |	VARCHAR(50)	    |   FALSE       |
|   TITLE           |	VARCHAR(100)	|   FALSE       |
|   CONTENTS        |	VARCHAR(1000)	|   FALSE       |
|   PRICE           |	NUMBER	        |   FALSE       |
|   CREATED_DATE    |	DATE	        |   FALSE       |
|   STATUS          |	VARCHAR(10)	    |   FALSE       |
|   VIEWS           |	NUMBER	        |   FALSE       |

> `USED_GOODS_REPLY` 테이블은 다음과 같으며 `REPLY_ID, BOARD_ID, WRITER_ID, CONTENTS, CREATED_DATE`는 각각 댓글 ID, 게시글 ID, 작성자 ID, 댓글 내용, 작성일을 의미합니다.

|   Column name	    |   Type	        |   Nullable    |
|   :---:           |   :---:           |   :---:       |
|   REPLY_ID	    |   VARCHAR(10)	    |   FALSE       |
|   BOARD_ID	    |   VARCHAR(5)	    |   FALSE       |
|   WRITER_ID	    |   VARCHAR(50)	    |   FALSE       |
|   CONTENTS	    |   VARCHAR(1000)	|   TRUE        |
|   CREATED_DATE	|   DATE	        |   FALSE       |


- 문제  
> `USED_GOODS_BOARD`와 `USED_GOODS_REPLY` 테이블에서 2022년 10월에 작성된 게시글 제목, 게시글 ID, 댓글 ID, 댓글 작성자 ID, 댓글 내용, 댓글 작성일을 조회하는 SQL문을 작성해주세요. 결과는 댓글 작성일을 기준으로 오름차순 정렬해주시고, 댓글 작성일이 같다면 게시글 제목을 기준으로 오름차순 정렬해주세요.

<br>

### 풀이🔎  
- 문제 접근  
  - `BOARD_ID`를 기준으로 `USED_GOODS_BOARD`를 `USED_GOODS_REPLY`에 `JOIN`
  - 총주문량이 같다면 출하 번호를 기준으로 오름차순 정렬 : ORDER BY

- 나의 답  
```sql
SELECT      TITLE, BOARD.BOARD_ID, REPLY.REPLY_ID, 
            REPLY.WRITER_ID, REPLY.CONTENTS,
            DATE_FORMAT(REPLY.CREATED_DATE, '%Y-%m-%d') AS CREATED_DATE
FROM        USED_GOODS_REPLY AS REPLY
JOIN        USED_GOODS_BOARD AS BOARD
        ON  REPLY.BOARD_ID = BOARD.BOARD_ID
WHERE       DATE_FORMAT(BOARD.CREATED_DATE, '%Y-%m') = '2022-10'
ORDER BY    REPLY.CREATED_DATE ASC, BOARD.TITLE ASC
```

- 배운 것  
  - `REPLY.CREATED_DATE ASC, BOARD.TITLE ASC` 에서 ASC는 기본값이기 때문에 생략 가능
    - `REPLY.CREATED_DATE, BOARD.TITLE`




<br><br><br><br>




## JOIN : 그룹별 조건에 맞는 식당 목록 출력하기

### 문제 설명과 문제📜  
- 문제 설명  
> 다음은 고객의 정보를 담은 `MEMBER_PROFILE`테이블과 식당의 리뷰 정보를 담은 `REST_REVIEW` 테이블입니다. `MEMBER_PROFILE` 테이블은 다음과 같으며 `MEMBER_ID, MEMBER_NAME, TLNO, GENDER, DATE_OF_BIRTH`는 회원 ID, 회원 이름, 회원 연락처, 성별, 생년월일을 의미합니다.

| Column name	| Type	        | Nullable  |
| :---:         | :---:         | :---:     |
| MEMBER_ID     | VARCHAR(100)	| FALSE     |
| MEMBER_NAME   | VARCHAR(50)	| FALSE     |
| TLNO          | VARCHAR(50)	| TRUE      |
| GENDER        | VARCHAR(1)	| TRUE      |
| DATE_OF_BIRTH | DATE	        | TRUE      |

> `REST_REVIEW` 테이블은 다음과 같으며 `REVIEW_ID, REST_ID, MEMBER_ID, REVIEW_SCORE, REVIEW_TEXT,REVIEW_DATE`는 각각 리뷰 ID, 식당 ID, 회원 ID, 점수, 리뷰 텍스트, 리뷰 작성일을 의미합니다.

| Column name	| Type          | Nullable |
| :---:         | :---:         | :---:     |
| REVIEW_ID     | VARCHAR(10)   | FALSE     |
| REST_ID       | VARCHAR(10)   | TRUE      |
| MEMBER_ID     | VARCHAR(100)  | TRUE      |
| REVIEW_SCORE  | NUMBER        | TRUE      |
| REVIEW_TEXT   | VARCHAR(1000) | TRUE      |
| REVIEW_DATE   | DATE          | TRUE      |


- 문제  
> `MEMBER_PROFILE`와 `REST_REVIEW` 테이블에서 리뷰를 가장 많이 작성한 회원의 리뷰들을 조회하는 SQL문을 작성해주세요. 회원 이름, 리뷰 텍스트, 리뷰 작성일이 출력되도록 작성해주시고, 결과는 리뷰 작성일을 기준으로 오름차순, 리뷰 작성일이 같다면 리뷰 텍스트를 기준으로 오름차순 정렬해주세요.

<br>

### 풀이🔎  
- MEMBER_PROFILE 테이블 살펴보기
```sql
SELECT      MEMBER.MEMBER_ID, MEMBER.MEMBER_NAME
FROM        MEMBER_PROFILE AS MEMBER;
```

- REST_REVIEW 테이블 살펴보기
```sql
SELECT      REVIEW.MEMBER_ID, REVIEW.REVIEW_TEXT,
            COUNT(REVIEW_TEXT) AS REVIEW_COUNT
FROM        REST_REVIEW AS REVIEW
GROUP BY    MEMBER_ID
ORDER BY    REVIEW_COUNT DESC;
```

- 리뷰개수 최대값 찾기
```sql
SELECT      COUNT(REVIEW_TEXT) AS MAX_REVIEW_COUNT
FROM        REST_REVIEW AS REVIEW
GROUP BY    MEMBER_ID
ORDER BY    MAX_REVIEW_COUNT DESC
LIMIT       1;
```

- 리뷰개수가 최대값과 같은 멤버아이디 찾기
```sql
SELECT      MEMBER_ID,
            COUNT(REVIEW_TEXT) AS REVIEW_COUNT
FROM        REST_REVIEW
GROUP BY    MEMBER_ID
HAVING      REVIEW_COUNT = (
                            SELECT      COUNT(REVIEW_TEXT) AS MAX_REVIEW_COUNT
                            FROM        REST_REVIEW
                            GROUP BY    MEMBER_ID
                            ORDER BY    MAX_REVIEW_COUNT DESC
                            LIMIT       1
                            )
;
```

- 리뷰개수가 최대값과 같은 멤버아이디 찾아서 아이디만 표시하기
```sql
SELECT      MEMBER_ID
FROM        (
            SELECT      MEMBER_ID,
                        COUNT(REVIEW_TEXT) AS REVIEW_COUNT
            FROM        REST_REVIEW
            GROUP BY    MEMBER_ID
            HAVING      REVIEW_COUNT = (
                                        SELECT      COUNT(REVIEW_TEXT) AS MAX_REVIEW_COUNT
                                        FROM        REST_REVIEW
                                        GROUP BY    MEMBER_ID
                                        ORDER BY    MAX_REVIEW_COUNT DESC
                                        LIMIT       1
                                        )
            ) AS MAX_REVIEWER
;
```

- 지정된 포멧에 따라서 출력
```sql
SELECT      MEMBER.MEMBER_NAME, REVIEW.REVIEW_TEXT,
            DATE_FORMAT(REVIEW.REVIEW_DATE, '%Y-%m-%d') AS REVIEW_DATE
FROM        REST_REVIEW AS REVIEW
JOIN        MEMBER_PROFILE AS MEMBER
        ON  REVIEW.MEMBER_ID = MEMBER.MEMBER_ID
WHERE       REVIEW.MEMBER_ID in (
                                SELECT      MEMBER_ID
                                FROM        (
                                            SELECT      MEMBER_ID,
                                                        COUNT(REVIEW_TEXT) AS REVIEW_COUNT
                                            FROM        REST_REVIEW
                                            GROUP BY    MEMBER_ID
                                            HAVING      REVIEW_COUNT = (
                                                                        SELECT      COUNT(REVIEW_TEXT) AS MAX_REVIEW_COUNT
                                                                        FROM        REST_REVIEW
                                                                        GROUP BY    MEMBER_ID
                                                                        ORDER BY    MAX_REVIEW_COUNT DESC
                                                                        LIMIT       1
                                                                        )
                                            ) AS MAX_REVIEWER
                                )
ORDER BY    REVIEW.REVIEW_DATE ASC, REVIEW.REVIEW_TEXT ASC
;
```


- 배운 것  
  - 서브쿼리를 이용하면 논리적으로 모든 테이블의 표현이 가능하지만, 쿼리가 길어진다




<br><br><br><br>




## JOIN : 조건에 맞는 도서와 저자 리스트 출력하기

### 문제 설명과 문제📜  
- 문제 설명  
> 다음은 어느 한 서점에서 판매중인 도서들의 도서 정보(BOOK), 저자 정보(AUTHOR) 테이블입니다.
> `BOOK` 테이블은 각 도서의 정보를 담은 테이블로 아래와 같은 구조로 되어있습니다.

| Column name       | Type          | Nullable  | Description                           |
| :---:             | :---:         | :---:     | :---:                                 |
| BOOK_ID           | INTEGER       | 	FALSE	| 도서 ID                               |
| CATEGORY          | VARCHAR(N)    | 	FALSE	| 카테고리 (경제, 인문, 소설, 생활, 기술)  |
| AUTHOR_ID         | INTEGER       | 	FALSE	| 저자 ID                               |
| PRICE             | INTEGER       | 	FALSE	| 판매가 (원)                           |
| PUBLISHED_DATE    | DATE          | 	FALSE	| 출판일                                |

> `AUTHOR` 테이블은 도서의 저자의 정보를 담은 테이블로 아래와 같은 구조로 되어있습니다.

| Column name   | Type	        | Nullable	| Description   |
| :---:         | :---:         | :---:     | :---:         |
| AUTHOR_ID	    | INTEGER	    | FALSE	    | 저자 ID       |
| AUTHOR_NAME   | VARCHAR(N)    | FALSE	    | 저자명         |


- 문제  
> '`경제`' 카테고리에 속하는 도서들의 도서 ID(BOOK_ID), 저자명(AUTHOR_NAME), 출판일(PUBLISHED_DATE) 리스트를 출력하는 SQL문을 작성해주세요.
> 결과는 출판일을 기준으로 오름차순 정렬해주세요.

<br>

### 풀이🔎  
- `BOOK` 테이블 살펴보기
```sql
SELECT      *
FROM        BOOK;
```

- `AUTHOR` 테이블 살펴보기
```sql
SELECT      *
FROM        AUTHOR;
```

- `BOOK`, `AUTHOR` 합치기
```sql
SELECT      *
FROM        AUTHOR AS A
JOIN        BOOK AS B
        ON  A.AUTHOR_ID = B.AUTHOR_ID
;
```

- `경제` 카테고리에 속하는 도서 출력하기
```sql
SELECT      *
FROM        AUTHOR AS A
JOIN        BOOK AS B
        ON  A.AUTHOR_ID = B.AUTHOR_ID
WHERE       B.category = '경제'
;
```

- 출력형식에 맞춰 출력하기
```sql
SELECT      B.BOOK_ID, A.AUTHOR_NAME, 
            DATE_FORMAT(B.PUBLISHED_DATE, '%Y-%m-%d') AS PUBLISHED_DATE
FROM        AUTHOR AS A
JOIN        BOOK AS B
        ON  A.AUTHOR_ID = B.AUTHOR_ID
WHERE       B.category = '경제'
ORDER   BY  B.PUBLISHED_DATE ASC
;
```

- 배운 것  
  - 전체 테이블의 스키마를 살펴보고, 조건에 맞춰 하나씩 구현해 나가면서 점점 더 복잡하게 구현하는 것이 좋은 것 같다.




<br><br><br><br>




## JOIN : 5월 식품들의 총매출 조회하기

### 문제 설명과 문제📜  
- 문제 설명  
> 다음은 식품의 정보를 담은 `FOOD_PRODUCT` 테이블과 식품의 주문 정보를 담은 `FOOD_ORDER` 테이블입니다. `FOOD_PRODUCT` 테이블은 다음과 같으며 `PRODUCT_ID, PRODUCT_NAME, PRODUCT_CD, CATEGORY, PRICE`는 식품 ID, 식품 이름, 식품코드, 식품분류, 식품 가격을 의미합니다.

| Column name	| Type          | Nullable  |
| :---:         | :---:         | :---:     |
| PRODUCT_ID    | VARCHAR(10)	| FALSE     |
| PRODUCT_NAME  | VARCHAR(50)	| FALSE     |
| PRODUCT_CD    | VARCHAR(10)	| TRUE      |
| CATEGORY      | VARCHAR(10)	| TRUE      |
| PRICE         | NUMBER	    | TRUE      |

> `FOOD_ORDER` 테이블은 다음과 같으며 `ORDER_ID, PRODUCT_ID, AMOUNT, PRODUCE_DATE, IN_DATE, OUT_DATE, FACTORY_ID, WAREHOUSE_ID`는 각각 주문 ID, 제품 ID, 주문량, 생산일자, 입고일자, 출고일자, 공장 ID, 창고 ID를 의미합니다.

| Column name	| Type          | Nullable  |
| :---:         | :---:         | :---:     |
| ORDER_ID      | VARCHAR(10)	| FALSE     |
| PRODUCT_ID    | VARCHAR(5)	| FALSE     |
| AMOUNT        | NUMBER	    | FALSE     |
| PRODUCE_DATE  | DATE	        | TRUE      |
| IN_DATE       | DATE	        | TRUE      |
| OUT_DATE      | DATE	        | TRUE      |
| FACTORY_ID    | VARCHAR(10)	| FALSE     |
| WAREHOUSE_ID  | VARCHAR(10)	| FALSE     |


- 문제  
> `FOOD_PRODUCT`와 `FOOD_ORDER` 테이블에서 생산일자가 2022년 5월인 식품들의 식품 ID, 식품 이름, 총매출을 조회하는 SQL문을 작성해주세요.
> 이때 결과는 총매출을 기준으로 내림차순 정렬해주시고 총매출이 같다면 식품 ID를 기준으로 오름차순 정렬해주세요.

<br>

### 풀이🔎  
- `FOOD_PRODUCT` 테이블 살펴보기
```sql
SELECT      *
FROM        FOOD_PRODUCT;
```

- `FOOD_ORDER` 테이블 살펴보기
```sql
SELECT      *
FROM        FOOD_ORDER;
```

- `FOOD_PRODUCT`, `FOOD_ORDER` 합치기
```sql
SELECT      *
FROM        FOOD_PRODUCT AS P
JOIN        FOOD_ORDER AS O
        ON  P.PRODUCT_ID = O.PRODUCT_ID
;
```

- `생산일자가 2022년 5월인 식품` 출력하기
```sql
SELECT      *
FROM        FOOD_PRODUCT AS P
JOIN        FOOD_ORDER AS O
        ON  P.PRODUCT_ID = O.PRODUCT_ID
WHERE       YEAR(O.PRODUCE_DATE) = 2022
        AND MONTH(O.PRODUCE_DATE) = 05
;
```

- 제품별 총판매량(`TOTAL_AMOUNT`) 출력하기
```sql
SELECT      P.PRODUCT_ID, P.PRODUCT_NAME, P.PRICE,
            SUM(O.AMOUNT) AS TOTAL_AMOUNT
FROM        FOOD_PRODUCT AS P
JOIN        FOOD_ORDER AS O
        ON  P.PRODUCT_ID = O.PRODUCT_ID
WHERE       YEAR(O.PRODUCE_DATE) = 2022
        AND MONTH(O.PRODUCE_DATE) = 05
GROUP   BY  P.PRODUCT_ID
;
```


- 총매출(`TOTAL_SALES`) 출력하기
```sql
SELECT      SALE.PRODUCT_ID, SALE.PRODUCT_NAME,
            SALE.PRICE*SALE.TOTAL_AMOUNT AS TOTAL_SALES
FROM        (
            SELECT      P.PRODUCT_ID, P.PRODUCT_NAME, P.PRICE,
                        SUM(O.AMOUNT) AS TOTAL_AMOUNT
            FROM        FOOD_PRODUCT AS P
            JOIN        FOOD_ORDER AS O
                    ON  P.PRODUCT_ID = O.PRODUCT_ID
            WHERE       YEAR(O.PRODUCE_DATE) = 2022
                    AND MONTH(O.PRODUCE_DATE) = 05
            GROUP   BY  P.PRODUCT_ID
            ) AS SALE
;
```

- 출력형식에 맞춰 출력하기
```sql
SELECT      SALE.PRODUCT_ID, SALE.PRODUCT_NAME,
            SALE.PRICE*SALE.TOTAL_AMOUNT AS TOTAL_SALES
FROM        (
            SELECT      P.PRODUCT_ID, P.PRODUCT_NAME, P.PRICE,
                        SUM(O.AMOUNT) AS TOTAL_AMOUNT
            FROM        FOOD_PRODUCT AS P
            JOIN        FOOD_ORDER AS O
                    ON  P.PRODUCT_ID = O.PRODUCT_ID
            WHERE       YEAR(O.PRODUCE_DATE) = 2022
                    AND MONTH(O.PRODUCE_DATE) = 05
            GROUP   BY  P.PRODUCT_ID
            ) AS SALE
ORDER   BY  TOTAL_SALES DESC, SALE.PRODUCT_ID ASC
;
```

- 배운 것  
  - 전체 판매량 컬럼을 먼저 만든다음 전체 매출액 컬럼을 만들어야 한다.




<br><br><br><br>




## GROUP BY : 저자 별 카테고리 별 매출액 집계하기


### 문제 설명과 문제📜  
- 문제 설명  
> 다음은 어느 한 서점에서 판매중인 도서들의 도서 정보(BOOK), 저자 정보(AUTHOR) 테이블입니다.
> `BOOK` 테이블은 각 도서의 정보를 담은 테이블로 아래와 같은 구조로 되어있습니다.

| Column name       | Type          | Nullable  | Description                           |
| :---:             | :---:         | :---:     | :---:                                 |
| BOOK_ID           | INTEGER       | 	FALSE	| 도서 ID                               |
| CATEGORY          | VARCHAR(N)    | 	FALSE	| 카테고리 (경제, 인문, 소설, 생활, 기술)  |
| AUTHOR_ID         | INTEGER       | 	FALSE	| 저자 ID                               |
| PRICE             | INTEGER       | 	FALSE	| 판매가 (원)                           |
| PUBLISHED_DATE    | DATE          | 	FALSE	| 출판일                                |

> `AUTHOR` 테이블은 도서의 저자의 정보를 담은 테이블로 아래와 같은 구조로 되어있습니다.

| Column name   | Type	        | Nullable	| Description   |
| :---:         | :---:         | :---:     | :---:         |
| AUTHOR_ID	    | INTEGER	    | FALSE	    | 저자 ID       |
| AUTHOR_NAME   | VARCHAR(N)    | FALSE	    | 저자명         |

> `BOOK_SALES` 테이블은 각 도서의 날짜 별 판매량 정보를 담은 테이블로 아래와 같은 구조로 되어있습니다.

| Column name   | Type	    | Nullable	| Description   |
| :---:         | :---:     | :---:     | :---:         |
| BOOK_ID       | INTEGER	| FALSE	    | 도서 ID       |
| SALES_DATE    | DATE	    | FALSE	    | 판매일        |
| SALES         | INTEGER	| FALSE	    | 판매량        |


- 문제  
> `2022년 1월`의 도서 판매 데이터를 기준으로 저자 별, 카테고리 별 매출액(`TOTAL_SALES = 판매량 * 판매가`) 을 구하여, 저자 ID(AUTHOR_ID), 저자명(AUTHOR_NAME), 카테고리(CATEGORY), 매출액(SALES) 리스트를 출력하는 SQL문을 작성해주세요.
> 결과는 저자 ID를 오름차순으로, 저자 ID가 같다면 카테고리를 내림차순 정렬해주세요.

<br>

### 풀이🔎  
- `BOOK` 테이블 살펴보기
```sql
SELECT      *
FROM        BOOK;
```

- `AUTHOR` 테이블 살펴보기
```sql
SELECT      *
FROM        AUTHOR;
```

- `BOOK_SALES` 테이블 살펴보기
```sql
SELECT      *
FROM        BOOK_SALES;
```

- `BOOK`, `AUTHOR`, `BOOK_SALES` 합치기
```sql
SELECT      *
FROM        AUTHOR AS A
JOIN        BOOK AS B
        ON  A.AUTHOR_ID = B.AUTHOR_ID
JOIN        BOOK_SALES AS S
        ON  B.BOOK_ID = S.BOOK_ID
;
```

- `2022년 1월의 도서 판매 데이터` 출력하기
```sql
SELECT      *
FROM        AUTHOR AS A
JOIN        BOOK AS B
        ON  A.AUTHOR_ID = B.AUTHOR_ID
JOIN        BOOK_SALES AS S
        ON  B.BOOK_ID = S.BOOK_ID
WHERE       YEAR(S.SALES_DATE) = 2022
        AND MONTH(S.SALES_DATE) = 01
;
```

- `책아이디별 판매량` 출력하기
```sql
SELECT      A.AUTHOR_ID, A.AUTHOR_NAME, B.BOOK_ID, B.CATEGORY, B.PRICE,
            SUM(S.SALES) AS BOOK_AMOUNT
FROM        AUTHOR AS A
JOIN        BOOK AS B
        ON  A.AUTHOR_ID = B.AUTHOR_ID
JOIN        BOOK_SALES AS S
        ON  B.BOOK_ID = S.BOOK_ID
WHERE       YEAR(S.SALES_DATE) = 2022
        AND MONTH(S.SALES_DATE) = 01
GROUP   BY  B.BOOK_ID
;
```

- `책아이디별 매출액(TOTAL_SALES)` 출력하기
```sql
SELECT      SALE1.AUTHOR_ID, SALE1.AUTHOR_NAME, SALE1.CATEGORY,
            SALE1.PRICE*SALE1.BOOK_AMOUNT AS BOOK_SALES
FROM        (
            SELECT      A.AUTHOR_ID, A.AUTHOR_NAME, B.BOOK_ID, B.CATEGORY, B.PRICE,
                        SUM(S.SALES) AS BOOK_AMOUNT
            FROM        AUTHOR AS A
            JOIN        BOOK AS B
                    ON  A.AUTHOR_ID = B.AUTHOR_ID
            JOIN        BOOK_SALES AS S
                    ON  B.BOOK_ID = S.BOOK_ID
            WHERE       YEAR(S.SALES_DATE) = 2022
                    AND MONTH(S.SALES_DATE) = 01
            GROUP   BY  B.BOOK_ID
            ) AS SALE1
;
```

- 출력조건에 맞게 `저자 별, 카테고리 별 매출액` 출력하기
```sql
SELECT      SALE2.AUTHOR_ID, SALE2.AUTHOR_NAME, SALE2.CATEGORY,
            SUM(SALE2.BOOK_SALES) AS TOTAL_SALES
FROM        (
            SELECT      SALE1.AUTHOR_ID, SALE1.AUTHOR_NAME, SALE1.CATEGORY,
                        SALE1.PRICE*SALE1.BOOK_AMOUNT AS BOOK_SALES
            FROM        (
                        SELECT      A.AUTHOR_ID, A.AUTHOR_NAME, B.BOOK_ID, B.CATEGORY, B.PRICE,
                                    SUM(S.SALES) AS BOOK_AMOUNT
                        FROM        AUTHOR AS A
                        JOIN        BOOK AS B
                                ON  A.AUTHOR_ID = B.AUTHOR_ID
                        JOIN        BOOK_SALES AS S
                                ON  B.BOOK_ID = S.BOOK_ID
                        WHERE       YEAR(S.SALES_DATE) = 2022
                                AND MONTH(S.SALES_DATE) = 01
                        GROUP   BY  B.BOOK_ID
                        ) AS SALE1
            ) AS SALE2
GROUP   BY  SALE2.AUTHOR_ID, SALE2.CATEGORY
ORDER   BY  SALE2.AUTHOR_ID ASC, SALE2.CATEGORY DESC
;
```

- 배운 것  
  - `GROUP BY` 할때 책으로 그룹핑을 하는지, 카테고리로 그룹핑을 하는지 정해야 한다.




<br><br><br><br>




## GROUP BY : 성분으로 구분한 아이스크림 총 주문량

### 문제 설명과 문제📜  
- 문제 설명  
> 다음은 아이스크림 가게의 상반기 주문 정보를 담은 `FIRST_HALF` 테이블과 아이스크림 성분에 대한 정보를 담은 `ICECREAM_INFO` 테이블입니다.
> `FIRST_HALF` 테이블 구조는 다음과 같으며, `SHIPMENT_ID, FLAVOR, TOTAL_ORDER` 는 각각 아이스크림 공장에서 아이스크림 가게까지의 출하 번호, 아이스크림 맛, 상반기 아이스크림 총주문량을 나타냅니다. `FIRST_HALF` 테이블의 기본 키는 `FLAVOR`입니다.


| NAME          | TYPE	        | NULLABLE  |
| :---:         | :---:         | :---:     |
|SHIPMENT_ID    | INT(N)	    | FALSE     |
|FLAVOR         | VARCHAR(N)    | FALSE     |
|TOTAL_ORDER    | INT(N)	    | FALSE     |

> `ICECREAM_INFO` 테이블 구조는 다음과 같으며, `FLAVOR, INGREDITENT_TYPE` 은 각각 아이스크림 맛, 아이스크림의 성분 타입을 나타냅니다.
> `INGREDIENT_TYPE`에는 아이스크림의 주 성분이 설탕이면 `sugar_based`라고 입력되고, 아이스크림의 주 성분이 과일이면 `fruit_based`라고 입력됩니다.
> `ICECREAM_INFO`의 기본 키는 `FLAVOR`입니다.
> `ICECREAM_INFO`테이블의 `FLAVOR`는 `FIRST_HALF` 테이블의 `FLAVOR`의 외래 키입니다.

| NAME              | TYPE	        | NULLABLE  |
| :---:             | :---:         | :---:     |
| FLAVOR	        | VARCHAR(N)	| FALSE     |
| INGREDIENT_TYPE	| VARCHAR(N)	| FALSE     |


- 문제  
> 상반기 동안 각 아이스크림 성분 타입과 성분 타입에 대한 아이스크림의 총주문량을 총주문량이 작은 순서대로 조회하는 SQL 문을 작성해주세요.
> 이때 총주문량을 나타내는 컬럼명은 `TOTAL_ORDER`로 지정해주세요.

<br>

### 풀이🔎  
- `FIRST_HALF` 테이블 살펴보기
```sql
SELECT      *
FROM        FIRST_HALF;
```

- `ICECREAM_INFO` 테이블 살펴보기
```sql
SELECT      *
FROM        ICECREAM_INFO;
```

- `FIRST_HALF`, `ICECREAM_INFO` 테이블 합치기
```sql
SELECT      *
FROM        ICECREAM_INFO AS I
JOIN        FIRST_HALF AS F
        ON  I.FLAVOR = F.FLAVOR
;
```

- 주성분타입(`INGREDIENT_TYPE`)에 따른 총주문량 출력하기
```sql
SELECT      *, SUM(F.TOTAL_ORDER)
FROM        ICECREAM_INFO AS I
JOIN        FIRST_HALF AS F
        ON  I.FLAVOR = F.FLAVOR
GROUP   BY  I.INGREDIENT_TYPE
;
```

- 출력조건에 맞게 출력하기
```sql
SELECT      I.INGREDIENT_TYPE, SUM(F.TOTAL_ORDER) AS TOTAL_ORDER
FROM        ICECREAM_INFO AS I
JOIN        FIRST_HALF AS F
        ON  I.FLAVOR = F.FLAVOR
GROUP   BY  I.INGREDIENT_TYPE
ORDER   BY  TOTAL_ORDER ASC
;
```




<br><br><br><br>




## GROUP BY : 진료과별 총 예약 횟수 출력하기

### 문제 설명과 문제📜  
- 문제 설명  
> 다음은 종합병원의 진료 예약정보를 담은 `APPOINTMENT` 테이블 입니다.
> `APPOINTMENT` 테이블은 다음과 같으며 `APNT_YMD, APNT_NO, PT_NO, MCDP_CD, MDDR_ID, APNT_CNCL_YN, APNT_CNCL_YMD`는 각각 진료예약일시, 진료예약번호, 환자번호, 진료과코드, 의사ID, 예약취소여부, 예약취소날짜를 나타냅니다.

| Column name   | Type	        | Nullable  |
| :---:         | :---:         | :---:     |
| APNT_YMD      | TIMESTAMP	    | FALSE     |
| APNT_NO       | NUMBER(5)	    | FALSE     |
| PT_NO         | VARCHAR(10)   | FALSE     |
| MCDP_CD       | VARCHAR(6)	| FALSE     |
| MDDR_ID       | VARCHAR(10)	| FALSE     |
| APNT_CNCL_YN  | VARCHAR(1)	| TRUE      |
| APNT_CNCL_YMD | DATE	        | TRUE      |

- 문제  
> `APPOINTMENT` 테이블에서 2022년 5월에 예약한 환자 수를 진료과코드 별로 조회하는 SQL문을 작성해주세요.
> 이때, 컬럼명은 '진료과 코드', '5월예약건수'로 지정해주시고 결과는 진료과별 예약한 환자 수를 기준으로 오름차순 정렬하고, 예약한 환자 수가 같다면 진료과 코드를 기준으로 오름차순 정렬해주세요.

<br>

### 풀이🔎  
- `APPOINTMENT` 테이블 살펴보기
```sql
SELECT      *
FROM        APPOINTMENT;
```

- `2022년 5월에 예약한 환자` 만 출력하기
```sql
SELECT      *
FROM        APPOINTMENT AS A
WHERE       YEAR(A.APNT_YMD) = 2022
        AND MONTH(A.APNT_YMD) = 05
;
```

- 진료과코드(`MCDP_CD`) 별로 환자 수 합계 출력하기
```sql
SELECT      A.MCDP_CD AS '진료과코드',
            COUNT(*) AS '5월예약건수'
FROM        APPOINTMENT AS A
WHERE       YEAR(A.APNT_YMD) = 2022
        AND MONTH(A.APNT_YMD) = 05
GROUP   BY  A.MCDP_CD
;
```

- 출력조건에 맞게 출력하기
```sql
SELECT      A.MCDP_CD AS '진료과 코드',
            COUNT(*) AS '5월예약건수'
FROM        APPOINTMENT AS A
WHERE       YEAR(A.APNT_YMD) = 2022
        AND MONTH(A.APNT_YMD) = 05
GROUP   BY  A.MCDP_CD
ORDER   BY  COUNT(*), A.MCDP_CD
;
```

- 배운 것  
  - `ORDER   BY`에서 `'진료과 코드'` 라고 지정하니깐 통과가 안된다.












<br><br><br><br>  
<center>  
<h1>끝까지 읽어주셔서 감사합니다😉</h1>  
</center>  
<br><br><br><br>  


