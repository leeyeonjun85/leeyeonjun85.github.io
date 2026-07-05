---
title: "Open Weather API를 이용한 날씨정보 웹어플 만들기"
excerpt: "OpenWeather API, MongoDB, Django 활용"

categories:
  - python
redirect_from:
  - "/dev log/openweather/"

tags:
  - 개발일지
  - 코딩
  - API
  - mongoDB
  - Django

use_math: true

header:
  teaser: /assets/images/etc/rainbow-4047523_1920.jpg

last_modified_at: 2023-03-30
---
 

<br><br>


![image]({{ site.url }}{{ site.baseurl }}/assets/images/etc/rainbow-4047523_1920.jpg){: .align-center width="70%"}  


<br><br>


# Open Weather API를 이용하여 나만의 날씨정보 웹 어플리케이션 만들기


<br><br>


## 완성된 '나만의 날씨정보 어플'

- ['나만의 날씨정보 어플' 바로가기](http://15.164.244.197/etc/openweather/){:target="_blank"}  

<div style="width : 80%; margin : auto;">
  <a href="http://15.164.244.197/etc/openweather/" target="_blank">
    <img src="{{ site.url }}{{ site.baseurl }}/assets/images/coding/openweather/20230330_213332.png">
  </a>
</div>  


<br><br>  


## 도입  
>Open Weather API 와 MongoDB 를 이용하여 나만의 날씨정보 어플리케이션을 만들어보자  
무료로 제공되는 수많은 API 가운데 API 입문자료로 사용 될 수 있는 것이 Open Weather API이다.  
Open Weather API 는 전세계의 날씨정보를 무료로 제공한다.  
그 정보를 이용하여 나만의 날씨정보를 보여주는 어플리케이션을 만들어보자.  

- 필요한 기술
  - 날씨 데이터 : Open Weather API
  - 사용 언어 : Python
  - 웹 프레임 워크 : Django
  - 데이터베이스 : MongoDB  
{: .notice--danger}


<br><br>  
 

## Open Weather API 의 도시데이터 가져오기
- [Open Weather API 홈페이지](https://openweathermap.org/)에서 날씨정보를 받기 위해서는 먼저 홈페이지에 가입하고 API Key를 발급 받아야 한다.
- 그리고 Open Weather API 의 날씨정보를 검색하는 방법은 크게 두 가지가 있는데, `도시이름(영어)`으로 검색하는 방법, `도시ID(숫자)`로 검색하는 방법이 있다.
- 먼저 [여기](http://bulk.openweathermap.org/sample/){:target="_blank"}에서 Open Weather API에서 사용하는 도시정보를 JSON 파일 형태로 받을 수 있다.


<div style="width : 80%; margin : auto;">
  <a href="http://bulk.openweathermap.org/sample/" target="_blank">
    <img src="{{ site.url }}{{ site.baseurl }}/assets/images/coding/openweather/20230330_205832.png">
  </a>
</div>  


- 도시정보 파일을 불러오면 다음과 같이 도시id, 이름, 국가, 위도, 경도 정보를 얻을 수 있다.  
```json
[{
		"id": 1835848,
		"name": "Seoul",
		"state": "",
		"country": "KR",
		"coord": {
			"lon": 126.977829,
			"lat": 37.56826
		}
	},
	{
		"id": 1835895,
		"name": "Seosan",
		"state": "",
		"country": "KR",
		"coord": {
			"lon": 126.452217,
			"lat": 36.78167
		}
	},
...]
```

- 도시정보를 다음과 같은 형태로 수정하였다.  
```json
[{
  "coord_lat": 37.56826,
  "coord_lon": 126.977829,
  "country": "KR",
  "id": 1835848,
  "name": "Seoul",
  "state": ""
},
{
  "coord_lat": 36.78167,
  "coord_lon": 126.452217,
  "country": "KR",
  "id": 1835895,
  "name": "Seosan",
  "state": ""
},
...]
```

- 이렇게 정리 된 전세계 209,579개 도시의 도시정보를 MongoDB로 입력하였다.  
![image]({{ site.url }}{{ site.baseurl }}/assets/images/coding/openweather/20230330_213105.png){: .align-center width="80%"}  


<br><br>


## 날시 정보 클래스 만들기

### 도시이름에서 도시id를 반환하는 함수
- 도시이름을 입력하면 Open Weather API의 도시id를 반환하는 함수를 만들자
- 이미 MongoDB에 도시정보를 입력하였으니 몽고DB에서 도시id만 가져오면 된다.

```python
def get_city_id(self, CITY_NAME):
    DATABASE_NAME   = "openweather"
    COLLECTION_NAME = "city_list"
    MONGO_URI       = "몽고DB URI가 들어가는 자리"
    CLIENT          = MongoClient(MONGO_URI)
    DB              = CLIENT[DATABASE_NAME]
    COLLECTION      = DB[COLLECTION_NAME]
    CITY_INFO = COLLECTION.find_one({"name": CITY_NAME})
    CLIENT.close()

    return CITY_INFO, CITY_INFO["id"]
```

- 혹시 필요할지 몰라서 도시정보 객체와 id를 반환하게 하였다.

<br><br>

### 도시id로 날씨 API를 받아오는 함수
- 도시id로 Open Weather API의 날씨 정보를 받아오는 함수

```python
def get_weather(self, CITY_NAME):
    _, ID   = self.get_city_id(CITY_NAME)
    KEY     = "Open Weather API의 KEY가 들어가는 자리"
    URL     = f"https://api.openweathermap.org/data/2.5/weather?id={ID}&appid={KEY}&lang=kr&units=metric"

    try:
        response = requests.get(URL)
        response.raise_for_status()
    except Exception:
        print(f"⛔ 에러가 발생했습니다.\n{response}")
    else:
        print(f"✅ Requests 응답 성공\n{response}")
        WEATHER_DATA = json.loads(response.text)
    return WEATHER_DATA
```

- 최종적으로는 두 함수를 연결하여 클래스로 만들었다.

<br><br>

## 장고 프레임워크를 이용하여 웹페이지 만들기

### '나만의 날씨정보' 페이지 만들기  
- 장고 프레임워크에서 사용할 html페이지를 만들었다.  
- 클래스에서 알 수 있듯이 부트스트랩을 이용하였다.  

```html
<div id="page_{{ pagename }}" class="container-fluid">
    <div class="contents container text-center mb-3">
        <h1 id="">🌞이연준의 날씨정보⛅</h1>
    </div>
    <div class="container text-center p-2">
        <select name='city_box' size='15'>
            <option value='' selected>-- 선택 --</option>
            {% for city_info in city_list %}
            <option value='{{ city_info.name }}'>{{ city_info.name }} / ({{ city_info.id }})</option>
            {% endfor %}
        </select>
    </div>
    <div class="text-center p-2">
        <button onclick="get_ow_data()" type="button" class="btn btn-outline-primary">
        날씨 보기🌦
        </button>
    </div>
    
    <div id="weather_data"></div> 
</div>
```

<br>

![image]({{ site.url }}{{ site.baseurl }}/assets/images/coding/openweather/20230330_213332.png){: .align-center width="80%"}  

<br>

- 위의 페이지에서 먼저 도시를 선택하고 날씨 보기🌦를 선택하면 `get_ow_data()`함수를 호출한다.
- `get_ow_data()` 함수는 Select 상자의 값인 도시이름을 jQuery로 받아와 미리 만들어놓은 `날씨정보 파이선 클래스`로 전달하고, `날씨정보 파이선 클래스`에서 받아온 날씨정보는 페이지에 추가해준다.

```js
function get_ow_data()  {
    let city_name = $('select[name=city_box]').val()
    $.ajax({
        type: "GET",
        url: "/etc/openweather/get/",
        data: {city_name:city_name},
        success: function (response) {
            $('#weather_data').empty()
            $('#weather_data').append(response['template'])
        }
    });
}
```


<br><br>


## `이연준의 날씨정보` 어플리케이션 사용해보기

### 사용 방법  
1. ['이연준의 날씨정보' 바로가기](http://leeyj85.shop/etc/openweather/){:target="_blank"}  
2. `도시를 선택`한다.  
3. `날씨 보기`를 클릭한다.  
4. 해당 도시의 날씨를 확인한다.  
5. 다른 도시를 보고싶으면 `도시를 선택`하고 다시 `날씨 보기`를 클릭한다.  




<br>
<br>
<br>
<br>


<center>
<h1>끝까지 읽어주셔서 감사합니다😉</h1>
</center>


<br>
<br>
<br>
<br>






