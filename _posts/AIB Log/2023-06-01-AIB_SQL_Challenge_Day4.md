---

title: "AI 부트캠프 : SQL Challenge Day4"

excerpt: "코드스테이츠와 함께하는 'SQL Challenge' 4일차 회고"

categories:
    - AIB Log

tags:
    - 개발일지
    - 코딩
    - AI 부트캠프
    - 코드스테이츠

header:
    teaser: /assets/images/aib/codestates-ci.png

last_modified_at: 2023-06-01

---


<br><br><br><br>


![image](../../assets/images/etc/sql.png){: .align-center width="70%"}  


<br><br><br><br>




# 코드스테이츠와 함께하는 'SQL Challenge' 4일차  
> 코드스테이츠에서 5~6월 연휴기간동안 `방학`을 줬다.
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




## SELECT : 흉부외과 또는 일반외과 의사 목록 출력하기

### 문제 설명과 문제📜  

#### 문제 설명  
> 다음은 종합병원에 속한 의사 정보를 담은 `DOCTOR` 테이블입니다. `DOCTOR` 테이블은 다음과 같으며 `DR_NAME, DR_ID, LCNS_NO, HIRE_YMD, MCDP_CD, TLNO` 는 각각 의사이름, 의사ID, 면허번호, 고용일자, 진료과코드, 전화번호를 나타냅니다.

| Column name | Type	      | Nullable  |
| :---:       | :---:       | :---:     |
| DR_NAME     |	VARCHAR(20)	| FALSE     |
| DR_ID       |	VARCHAR(10)	| FALSE     |
| LCNS_NO     |	VARCHAR(30)	| FALSE     |
| HIRE_YMD    |	DATE	      | FALSE     |
| MCDP_CD     |	VARCHAR(6)	| TRUE      |
| TLNO        |	VARCHAR(50)	| TRUE      |


<br> 

#### 문제  
> `DOCTOR` 테이블에서 진료과가 `흉부외과(CS)`이거나 `일반외과(GS)`인 의사의 `이름, 의사ID, 진료과, 고용일자`를 조회하는 SQL문을 작성해주세요. 이때 결과는 `고용일자를 기준으로 내림차순 정렬`하고, 고용일자가 같다면 `이름을 기준으로 오름차순 정렬`해주세요.


<br><br>


### 풀이🔎  
#### `DOCTOR` 테이블 살펴보기
```sql
SELECT      *
FROM        DOCTOR
;
```
  - 의사 이름이 `깨미, 니모, 띠띠, 루피, 베지 ...`😂

<br>

#### `의사의 이름, 의사ID, 진료과, 고용일자` 출력하기
```sql
SELECT      DR_NAME, DR_ID, MCDP_CD, HIRE_YMD
FROM        DOCTOR
;
```

<br>

#### 진료과가 `흉부외과(CS)`이거나 `일반외과(GS)` 경우 출력하기
```sql
SELECT      DR_NAME, DR_ID, MCDP_CD, HIRE_YMD
FROM        DOCTOR
WHERE       MCDP_CD = 'CS'
      OR    MCDP_CD = 'GS'
;
```

<br>

#### 정렬조건에 따라서 출력하기
```sql
SELECT      DR_NAME, DR_ID, MCDP_CD, HIRE_YMD
FROM        DOCTOR
WHERE       MCDP_CD = 'CS'
      OR    MCDP_CD = 'GS'
ORDER BY    HIRE_YMD DESC, DR_NAME ASC
;
```
  - 실패😢
  - 문제 조건에는 없는데, 아래 예시를 보니깐 `날짜 포멧`을 맞춰서 출력해야 함

<br>

#### 날짜 포멧 맞춰서 출력하기
```sql
SELECT      DR_NAME, DR_ID, MCDP_CD,
            DATE_FORMAT(HIRE_YMD, '%Y-%m-%d') AS HIRE_YMD
FROM        DOCTOR
WHERE       MCDP_CD = 'CS'
      OR    MCDP_CD = 'GS'
ORDER BY    HIRE_YMD DESC, DR_NAME ASC
;
```
  - 통과🎉




<br><br><br><br>




## GROUP BY : 즐겨찾기가 가장 많은 식당 정보 출력하기

### 문제 설명과 문제📜  

#### 문제 설명  
> 다음은 식당의 정보를 담은 `REST_INFO` 테이블입니다. `REST_INFO` 테이블은 다음과 같으며 `REST_ID, REST_NAME, FOOD_TYPE, VIEWS, FAVORITES, PARKING_LOT, ADDRESS, TEL`은 식당 ID, 식당 이름, 음식 종류, 조회수, 즐겨찾기수, 주차장 유무, 주소, 전화번호를 의미합니다.

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

<br> 

#### 문제  
> `REST_INFO` 테이블에서 음식종류별로 즐겨찾기수가 가장 많은 식당의 음식 종류, ID, 식당 이름, 즐겨찾기수를 조회하는 SQL문을 작성해주세요. 이때 결과는 음식 종류를 기준으로 내림차순 정렬해주세요.


<br><br>


### 풀이🔎  
#### `REST_INFO` 테이블 살펴보기
```sql
SELECT      *
FROM        REST_INFO
;
```
  - 음식 종류에는 `한식, 일식, 양식` 등이 있음

<br>

#### `음식종류별로 즐겨찾기수가 가장 많은 식당의 즐겨찾기 수` 출력하기
```sql
SELECT      FOOD_TYPE, MAX(FAVORITES)
FROM        REST_INFO
GROUP BY    FOOD_TYPE
;
```
  - 음식 종류별 가장 많은 즐겨찾기 수는 다음과 같음
    - 한식	734
    - 일식	230
    - 양식	102
    - 분식	151
    - 중식	20

<br>

#### `음식종류별로 즐겨찾기수가 가장 많은 식당의 즐겨찾기 수`와 같은 식당의 `음식 종류, ID, 식당 이름, 즐겨찾기수` 출력하기
```sql
SELECT      FOOD_TYPE, REST_ID, REST_NAME, FAVORITES
FROM        REST_INFO
WHERE       (FOOD_TYPE, FAVORITES) IN (
                          SELECT      FOOD_TYPE, MAX(FAVORITES)
                          FROM        REST_INFO
                          GROUP BY    FOOD_TYPE
                          )
;
```

<br>

#### `음식 종류를 기준으로 내림차순 정렬` 출력하기
```sql
SELECT      FOOD_TYPE, REST_ID, REST_NAME, FAVORITES
FROM        REST_INFO
WHERE       (FOOD_TYPE, FAVORITES) IN (
                          SELECT      FOOD_TYPE, MAX(FAVORITES)
                          FROM        REST_INFO
                          GROUP BY    FOOD_TYPE
                          )
ORDER BY    FOOD_TYPE DESC
;
```
  - 통과🎉




<br><br><br><br>




## JOIN : 없어진 기록 찾기

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
> 천재지변으로 인해 일부 데이터가 유실되었습니다. 입양을 간 기록은 있는데, 보호소에 들어온 기록이 없는 동물의 ID와 이름을 ID 순으로 조회하는 SQL문을 작성해주세요.


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

#### `ANIMAL_OUTS`을 기준으로 `LEFT JOIN`으로 테이블 합치기
```sql
SELECT      *
FROM        ANIMAL_OUTS OUTS
LEFT JOIN   ANIMAL_INS INS
      ON    OUTS.ANIMAL_ID = INS.ANIMAL_ID
;
```

<br>

#### `입양을 간 기록은 있는데, 보호소에 들어온 기록이 없는 동물` 조회하기
```sql
SELECT      *
FROM        ANIMAL_OUTS OUTS
LEFT JOIN   ANIMAL_INS INS
      ON    OUTS.ANIMAL_ID = INS.ANIMAL_ID
WHERE       INS.ANIMAL_ID IS NULL
;
```

<br>

#### `동물의 ID와 이름을 ID 순으로` 조회하기
```sql
SELECT      OUTS.ANIMAL_ID, OUTS.NAME
FROM        ANIMAL_OUTS OUTS
LEFT JOIN   ANIMAL_INS INS
      ON    OUTS.ANIMAL_ID = INS.ANIMAL_ID
WHERE       INS.ANIMAL_ID IS NULL
ORDER BY    OUTS.ANIMAL_ID
;
```
  - 통과🎉
  - 레프트 아웃터 조인  
![image](../../assets/images/etc/Visual_SQL_JOINS_V2.png){: .align-center width="70%"}  








<br><br><br><br>  
<center>  
<h1>끝까지 읽어주셔서 감사합니다😉</h1>  
</center>  
<br><br><br><br>  


