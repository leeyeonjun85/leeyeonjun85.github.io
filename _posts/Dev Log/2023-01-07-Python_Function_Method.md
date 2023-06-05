---
title: "파이썬의 함수와 메서드"

categories:
  - Dev Log

tags:
  - 개발일지
  - 코딩
  - Python
toc	: "Menu"
toc_label	:
toc_icon :
toc_sticky: true

header:
  teaser: https://upload.wikimedia.org/wikipedia/commons/f/f8/Python_logo_and_wordmark.svg

last_modified_at: 2023-01-07
---

<div style="display:block; margin:auto; width:70%">
  <img alt="image"
  src="https://upload.wikimedia.org/wikipedia/commons/f/f8/Python_logo_and_wordmark.svg">  
</div>  





## pandas

### 기본함수
#### 데이터 조작
- pd.melt()
  - 와이드타입에서 롱타입으로 재구조화

- pd.pivot()
  - 인덱스와 컬럼으로 구조화된 피봇테이블 데이터프레임 반환

- pivot_table()
  - 스프레드시트형태의 피봇테이블을 데이터프레임으로 반환

- crosstab()
  - 두요인이상의 빈도표 계산


#### .read_csv()
- [`.read_csv()` 공식 문서](https://pandas.pydata.org/docs/reference/api/pandas.read_csv.html)  

- pandas.read_csv(filepath_or_buffer, *, sep=_NoDefault.no_default, delimiter=None, header='infer', names=_NoDefault.no_default, index_col=None, usecols=None, squeeze=None, prefix=_NoDefault.no_default, mangle_dupe_cols=True, dtype=None, engine=None, converters=None, true_values=None, false_values=None, skipinitialspace=False, skiprows=None, skipfooter=0, nrows=None, na_values=None, keep_default_na=True, na_filter=True, verbose=False, skip_blank_lines=True, parse_dates=None, infer_datetime_format=False, keep_date_col=False, date_parser=None, dayfirst=False, cache_dates=True, iterator=False, chunksize=None, compression='infer', thousands=None, decimal='.', lineterminator=None, quotechar='"', quoting=0, doublequote=True, escapechar=None, comment=None, encoding=None, encoding_errors='strict', dialect=None, error_bad_lines=None, warn_bad_lines=None, on_bad_lines=None, delim_whitespace=False, low_memory=True, memory_map=False, float_precision=None, storage_options=None)  

#### pandas.to_csv()
##### 파라미터
- index=False
  - 인덱스를 추가칼럼으로 저장하는 것을 방지("Unnamed : 0"을 생성하지 않음)

#### pandas.DataFrame.info()

#### .describe()

#### .duplicated()

#### .reset_index()
- [`.reset_index()` 공식문서](https://pandas.pydata.org/docs/reference/api/pandas.DataFrame.reset_index.html)

#### .append()
- [`.append()` 공식문서](https://pandas.pydata.org/pandas-docs/stable/reference/api/pandas.DataFrame.append.html)

#### .groupby()
- [`.groupby()` 공식문서](https://pandas.pydata.org/pandas-docs/stable/user_guide/groupby.html)
##### 파라미터
- sort=False
  - 그룹인덱스 정렬 안함(기본은 오름차순 정렬)
- as_index=False
  - 인덱스를 재설정
  - 기본은 그룹 유니크값들

##### .mean()

#### .value_counts()
- normalize=True

#### .query()


#### pd.cut()

<br><br>
<hr>
<br><br>

## numpy

#### .repeat()