---
title: "JavaScript"

categories:
  - Dev Log

tags:
  - 개발일지
  - 코딩
toc	: "Menu"
toc_label	:
toc_icon :
toc_sticky: true
last_modified_at: 2022-10-18
---


# JavaScript

## 목차
- [JavaScript의 기본 특징](#javascript의-기본-특징)
- ["Hello world" 예시](#hello-world-예시)
- [변수와 상수](#변수와-상수)
- [연산자](#연산자)
- [조건문](#조건문)
- [함수](#함수)
- [이벤트](#이벤트)
___
## JavaScript의 기본 특징
- JavaScript (줄여서 "JS")는 웹사이트상에서 동적 상호작용성을 제공할 수 있는 완전한 동적 프로그래밍 언어(dynamic programming language)이다.
- 브라우저 응용 프로그래밍 인터페이스([APIs](https://developer.mozilla.org/ko/docs/Glossary/API))
  - 브라우저에 내장된 API로 HTML을 동적으로 생성하고 CSS 스타일을 설정하거나, 사용자의 웹캠으로부터 비디오 스트림을 수집하거나 조작하는 것, 또는 3D 그래픽이나 오디오 샘플을 생성하는 것과 같은 다양한 기능을 제공
  - API 가운데 [Web Animations API](https://developer.mozilla.org/en-US/docs/Web/API/Web_Animations_API) (en-US)는 이미지를 여기저기 움직이거나 회전시키는 등, 웹 페이지 일부를 움직이도록 하는 데에 쓸 수 있음(나중에 더 공부해보자!😻)
- 제3자 (third-party) API를 활용해 개발자는 트위터나 페이스북 같은 다른 컨텐츠 공급사부터 제공되는 기능을 자신의 사이트에 통합할 수 있음
- 써드파티 프레임워크와 라이브러리를 HTML에 적용함으로써 사이트와 어플리케이션을 빠르게 구축할 수 있음
- 자바스크립트는 대소문자를 구분 함

## "Hello world" 예시
- scripts라는 폴더를 만들고, 폴더 안에 `main.js` 파일 생성 저장
- index.html 파일로 가서 닫는 `</body>` 태그의 바로 앞에 새로운 줄을 추가하고 다음 요소(`<script...></script>`)를 입력
```html
<body>
...
...
<script src="scripts/main.js"></script>
</body>
```
- `main.js`에 다음 코드를 추가
```js
let myHeading = document.querySelector('h1');
myHeading.textContent = 'Hello world!';
```

## 변수와 상수
- 변수와 상수는 모두 정보를 저장하는 '저장소'로 쓰임
- 변수(variable)는 저장하는 값이 변화할 수 있는 저장소
- 상수(constant)는 저장하는 값이 변화하지 않는 저장소

### 변수(Variables)
- 변수(Variables)는 어떤 값을 저장할 수 있는 컨테이너 역할
- 변수를 선언할 때는 `var` 또는 `let` 을 사용
  - `var`는 오래된 코딩 방식
- `let`으로 변수 'message'를 생성(선언)하고, 변수 meassage 안에 'Hello'라는 값을 할당
```js
let message;
message = 'Hello'; // 문자열을 저장합니다.
```

- 변수의 자료형
  - String : 문자열
  - Number : 숫자
  - Boolean : true/false
  - Array : 배열
  - Object : 객체

- 변수 명명 규칙
  - 변수명에 `$`, `_` 사용 가능
  - 변수명은 숫자로 시작 불가능
  - 하이픈(`-`)은 변수명에 사용 불가능
  - 대소문자는 구별 됨
  - 한문, 히브리어 등 사용 가능
  - 변수명에 '예약어(reserved name)' 사용 불가능
    - 예약어 : let, class, return, function
  - 엄격모드(use strict)에서는 `let`으로 변수를 선언해야 하지만, 비엄격모드에서는 `let`을 생략 가능
    - 엄격모드를 고려해서 일반적으로 `let`을 생략하지 않음

### 상수(Constants)
- 상수(Constants)는 변화하지 않는 변수
- 변수는 `let`으로 선언하고, 상수는 `const`로 선언
- 관습적으로 기억하기 힘든 값을 대문자상수로 할당해 사용함
```js
const COLOR_RED = "#F00";
const COLOR_GREEN = "#0F0";
const COLOR_BLUE = "#00F";
const COLOR_ORANGE = "#FF7F00";

// 색상을 고르고 싶을 때 별칭을 사용할 수 있게 되었습니다.
let color = COLOR_ORANGE;
alert(color); // #FF7F00
```
- 대문자상수의 장점
  - COLOR_ORANGE는 "#FF7F00"보다 기억하기가 훨씬 쉽습니다.
  - COLOR_ORANGE를 사용하면 "#FF7F00"를 사용하는 것보다 오타를 낼 확률이 낮습니다.
  - COLOR_ORANGE가 #FF7F00보다 훨씬 유의미하므로, 코드 가독성이 증가합니다.

## 연산자
- 더하기(`+`) : 두 수를 합치거나, 또는 두 문자열을 하나로 붙일 때 사용
- 사칙연산 : 더하기, 빼기, 곱하기, 나누기 (`+, -, *, /`)
- 할당(`=`) : 값을 어떤 변수에 할당
- 동등(`===`) : 두 값이 서로 같은지 테스트하여 `true/false`(불리언) 결과를 반환
- 부정, 다름(`!, !==`) : 연산자 뒤쪽의 값에 대해 논리적으로 반대인 값을 반환

### 연산자 우선순위[(출처 : MDN)](https://developer.mozilla.org/ko/docs/Web/JavaScript/Reference/Operators/Operator_Precedence)
- 우선순위 숫자가 클 수록 우선 순위가 높음(먼저 실행 됨)
<table class="fullwidth-table">
  <tbody>
    <tr>
      <th>우선순위</th>
      <th>연산자 유형</th>
      <th>결합성</th>
      <th>연산자</th>
    </tr>
    <tr>
      <td>19</td>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Grouping">그룹</a></td>
      <td>없음</td>
      <td><code>( … )</code></td>
    </tr>
    <tr>
      <td rowspan="5">18</td>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Property_Accessors#%EC%A0%90_%ED%91%9C%EA%B8%B0%EB%B2%95">멤버 접근</a></td>
      <td>좌결합성</td>
      <td><code>… . …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Property_Accessors#%EA%B4%84%ED%98%B8_%ED%91%9C%EA%B8%B0%EB%B2%95">계산된 멤버 접근</a></td>
      <td>좌결합성</td>
      <td><code>… [ … ]</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/new"><code>new</code></a> (인자 리스트 제공)</td>
      <td>없음</td>
      <td><code>new … ( … )</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Guide/Functions">함수 호출</a></td>
      <td>좌결합성</td>
      <td><code>… ( <var>… </var>)</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Optional_chaining">옵셔널 체이닝</a></td>
      <td>좌결합성</td>
      <td><code>?.</code></td>
    </tr>
    <tr>
      <td>17</td>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/new"><code>new</code></a> (인자 리스트 생략)</td>
      <td>우결합성</td>
      <td><code>new …</code></td>
    </tr>
    <tr>
      <td rowspan="2">16</td>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Increment" class="only-in-en-us" title="Currently only available in English (US)">후위 증가 (en-US)</a></td>
      <td rowspan="2">없음</td>
      <td><code>… ++</code></td>
    </tr>
    <tr>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Decrement" class="only-in-en-us" title="Currently only available in English (US)">후위 감소 (en-US)</a></td>
      <td><code>… --</code></td>
    </tr>
    <tr>
      <td rowspan="10">15</td>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Logical_NOT" class="only-in-en-us" title="Currently only available in English (US)">논리 NOT (en-US)</a></td>
      <td rowspan="10">우결합성</td>
      <td><code>! …</code></td>
    </tr>
    <tr>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Bitwise_NOT" class="only-in-en-us" title="Currently only available in English (US)">비트 NOT (en-US)</a></td>
      <td><code>~ …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Unary_plus">단항 양부호</a></td>
      <td><code>+ …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Unary_negation">단항 부정</a></td>
      <td><code>- …</code></td>
    </tr>
    <tr>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Increment" class="only-in-en-us" title="Currently only available in English (US)">전위 증가 (en-US)</a></td>
      <td><code>++ …</code></td>
    </tr>
    <tr>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Decrement" class="only-in-en-us" title="Currently only available in English (US)">전위 감소 (en-US)</a></td>
      <td><code>-- …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/typeof"><code>typeof</code></a></td>
      <td><code>typeof …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/void"><code>void</code></a></td>
      <td><code>void …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/delete"><code>delete</code></a></td>
      <td><code>delete …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/await"><code>await</code></a></td>
      <td><code>await …</code></td>
    </tr>
    <tr>
      <td>14</td>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Exponentiation">거듭제곱</a></td>
      <td>우결합성</td>
      <td><code>… ** …</code></td>
    </tr>
    <tr>
      <td rowspan="3">13</td>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Multiplication">곱하기</a></td>
      <td colspan="1" rowspan="3">좌결합성</td>
      <td><code>… * …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Division">나누기</a></td>
      <td><code>… / …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Remainder">나머지</a></td>
      <td><code>… % …</code></td>
    </tr>
    <tr>
      <td rowspan="2">12</td>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Addition">더하기</a></td>
      <td rowspan="2">좌결합성</td>
      <td><code>… + …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Subtraction">빼기</a></td>
      <td><code>… - …</code></td>
    </tr>
    <tr>
      <td rowspan="3">11</td>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Left_shift" class="only-in-en-us" title="Currently only available in English (US)">비트 왼쪽 시프트 (en-US)</a></td>
      <td rowspan="3">좌결합성</td>
      <td><code>… &lt;&lt; …</code></td>
    </tr>
    <tr>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Right_shift" class="only-in-en-us" title="Currently only available in English (US)">비트 오른쪽 시프트 (en-US)</a></td>
      <td><code>… &gt;&gt; …</code></td>
    </tr>
    <tr>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Unsigned_right_shift" class="only-in-en-us" title="Currently only available in English (US)">비트 부호 없는 오른쪽 시프트 (en-US)</a></td>
      <td><code>… &gt;&gt;&gt; …</code></td>
    </tr>
    <tr>
      <td rowspan="6">10</td>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Less_than" class="only-in-en-us" title="Currently only available in English (US)">미만 (en-US)</a></td>
      <td rowspan="6">좌결합성</td>
      <td><code>… &lt; …</code></td>
    </tr>
    <tr>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Less_than_or_equal" class="only-in-en-us" title="Currently only available in English (US)">이하 (en-US)</a></td>
      <td><code>… &lt;= …</code></td>
    </tr>
    <tr>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Greater_than" class="only-in-en-us" title="Currently only available in English (US)">초과 (en-US)</a></td>
      <td><code>… &gt; …</code></td>
    </tr>
    <tr>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Greater_than_or_equal" class="only-in-en-us" title="Currently only available in English (US)">이상 (en-US)</a></td>
      <td><code>… &gt;= …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/in"><code>in</code></a></td>
      <td><code>… in …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/instanceof"><code>instanceof</code></a></td>
      <td><code>… instanceof …</code></td>
    </tr>
    <tr>
      <td rowspan="4">9</td>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Equality">동등</a></td>
      <td rowspan="4">좌결합성</td>
      <td><code>… == …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Inequality">부등</a></td>
      <td><code>… != …</code></td>
    </tr>
    <tr>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Strict_equality" class="only-in-en-us" title="Currently only available in English (US)">일치 (en-US)</a></td>
      <td><code>… === …</code></td>
    </tr>
    <tr>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Strict_inequality" class="only-in-en-us" title="Currently only available in English (US)">불일치 (en-US)</a></td>
      <td><code>… !== …</code></td>
    </tr>
    <tr>
      <td>7</td>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Bitwise_AND">비트 AND</a></td>
      <td>좌결합성</td>
      <td><code>… &amp; …</code></td>
    </tr>
    <tr>
      <td>7</td>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Bitwise_XOR" class="only-in-en-us" title="Currently only available in English (US)">비트 XOR (en-US)</a></td>
      <td>좌결합성</td>
      <td><code>… ^ …</code></td>
    </tr>
    <tr>
      <td>6</td>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Bitwise_OR" class="only-in-en-us" title="Currently only available in English (US)">비트 OR (en-US)</a></td>
      <td>좌결합성</td>
      <td><code>… | …</code></td>
    </tr>
    <tr>
      <td>5</td>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Logical_AND" class="only-in-en-us" title="Currently only available in English (US)">논리 AND (en-US)</a></td>
      <td>좌결합성</td>
      <td><code>… &amp;&amp; …</code></td>
    </tr>
    <tr>
      <td rowspan="2">4</td>
      <td><a href="/en-US/docs/Web/JavaScript/Reference/Operators/Logical_OR" class="only-in-en-us" title="Currently only available in English (US)">논리 OR (en-US)</a></td>
      <td>좌결합성</td>
      <td><code>… || …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Nullish_coalescing_operator">널 병합 연산자</a></td>
      <td>좌결합성</td>
      <td><code>… ?? …</code></td>
    </tr>
    <tr>
      <td>3</td>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Conditional_Operator">조건 (삼항)</a></td>
      <td>우결합성</td>
      <td><code>… ? … : …</code></td>
    </tr>
    <tr>
      <td rowspan="18">2</td>
      <td rowspan="16"><a href="/en-US/docs/Web/JavaScript/Reference/Operators#Assignment_operators" class="only-in-en-us" title="Currently only available in English (US)">할당 (en-US)</a></td>
      <td rowspan="16">우결합성</td>
      <td><code>… = …</code></td>
    </tr>
    <tr>
      <td><code>… += …</code></td>
    </tr>
    <tr>
      <td><code>… -= …</code></td>
    </tr>
    <tr>
      <td><code>… **= …</code></td>
    </tr>
    <tr>
      <td><code>… *= …</code></td>
    </tr>
    <tr>
      <td><code>… /= …</code></td>
    </tr>
    <tr>
      <td><code>… %= …</code></td>
    </tr>
    <tr>
      <td><code>… &lt;&lt;= …</code></td>
    </tr>
    <tr>
      <td><code>… &gt;&gt;= …</code></td>
    </tr>
    <tr>
      <td><code>… &gt;&gt;&gt;= …</code></td>
    </tr>
    <tr>
      <td><code>… &amp;= …</code></td>
    </tr>
    <tr>
      <td><code>… ^= …</code></td>
    </tr>
    <tr>
      <td><code>… |= …</code></td>
    </tr>
    <tr>
      <td><code>… &amp;&amp;= …</code></td>
    </tr>
    <tr>
      <td><code>… ||= …</code></td>
    </tr>
    <tr>
      <td><code>… ??= …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/yield"><code>yield</code></a></td>
      <td rowspan="2">우결합성</td>
      <td><code>yield …</code></td>
    </tr>
    <tr>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/yield*"><code>yield*</code></a></td>
      <td><code>yield* …</code></td>
    </tr>
    <tr>
      <td>1</td>
      <td><a href="/ko/docs/Web/JavaScript/Reference/Operators/Comma_Operator">쉼표 / 시퀀스</a></td>
      <td>좌결합성</td>
      <td><code>… , …</code></td>
    </tr>
  </tbody>
</table>

## 조건문
### if ... else 조건문
```js
let iceCream = 'chocolate';
if (iceCream === 'chocolate') {
  alert('Yay, I love chocolate ice cream!');
} else {
  alert('Awwww, but chocolate is my favorite...');
}
```
- `숫자 0, 빈 문자열"", null, undefined, NaN`은 불린형으로 변환 시 모두 `false`가 되는데, 이런 값들은 `‘falsy(거짓 같은)’` 값이라고 불림
- 이 외의 값은 불린형으로 변환시 `true`가 되므로 `‘truthy(참 같은)’` 값이라고 부름

### 논리연산자
- 논리연산자에는 `OR:||, AND:&&, NOT:!` 이 있음

#### OR : `||`
  - 전통적인 프로그래밍에서 OR 연산자는 불린값을 조작하는 데 쓰임
- OR연산자는 첫 번째 truthy를 찾는 용도로 쓰임
```js
alert( 1 || 0 ); // 1 (1은 truthy임)

alert( null || 1 ); // 1 (1은 truthy임)
alert( null || 0 || 1 ); // 1 (1은 truthy임)

alert( undefined || null || 0 ); // 0 (모두 falsy이므로, 마지막 값을 반환함)
```
```js
let firstName = "";
let lastName = "";
let nickName = "바이올렛";

alert( firstName || lastName || nickName || "익명"); // 바이올렛
```
- 위에서는 비어있지 않은 `nickName`의 값이 출력 됨
- 단락평가
  - `OR : ||`은 왼쪽부터 시작해서 오른쪽으로 평가를 진행하고, truthy를 만나면 나머지 값들은 건드리지 않은 채 평가를 멈추는데, 이를 **'단락 평가'** 라고 함
```js
true || alert("not printed");
false || alert("printed");
```
- 위 예시에서 첫 번째 줄의 `||` 연산자는 `true`를 만나자마자 평가를 멈추기 때문에 alert가 실행되지 않음
  - 두 번째 줄에서 `false`는 `falsy`한 값이기 때문에 지나가고, `alert("printed")`가 실행 됨

#### AND : `&&`
- 두 개의 [앰퍼샌드(ampersand : &, 앤드 기호)](https://ko.wikipedia.org/wiki/%EC%95%B0%ED%8D%BC%EC%83%8C%EB%93%9C)를 연달아 쓰면 `AND 연산자(&&)`를 만들 수 있음
- 전통적인 프로그래밍에서 AND 연산자는 두 피연산자가 모두가 참일 때 true를 반환
- 첫 번째 falsy를 찾는 AND 연산자 ‘&&’
```js
alert( 1 && 2 && null && 3 ); // 첫번째 falsy, null
alert( 1 && 2 && 3 ); // 마지막 값, 3
```

#### NOT : `!`
- 논리 연산자 NOT은 느낌표 !를 써서 만들 수 있음
```js
alert( !true ); // false
alert( !0 ); // true
```
- NOT을 두 개 연달아 사용(!!)하면 값을 불린형으로 변환
```js
alert( !!"non-empty string" ); // true
alert( !!null ); // false
```
- 내장 함수 Boolean을 사용하면 !!을 사용한 것과 같은 결과를 도출할 수 있음
```js
alert( Boolean("non-empty string") ); // true
alert( Boolean(null) ); // false
```

### nullish 변합 연산자 : `??`
- nullish 병합 연산자(nullish coalescing operator) `??`를 사용하면 짧은 문법으로 여러 피연산자 중 그 값이 ‘확정되어있는’ 변수를 찾을 수 있음
- `x = (a !== null && a !== undefined) ? a : b;`의 코드는 `a ?? b;`로 나타낼 수 있음
- ??는 &&나 ||와 함께 사용하지 못함
- ??의 연산자 우선순위는 5로 꽤 낮기 때문에, 괄호를 사용하여 우선순위를 조정해줘야 함

### switch 문법
- 복수의 `if` 조건문은 `switch` 문으로 바꿀 수 있음
```js
let a = 2 + 2;

switch (a) {
  case 3:
    alert( '비교하려는 값보다 작습니다.' );
    break;
  case 4:
    alert( '비교하려는 값과 일치합니다.' );
    break;
  case 5:
    alert( '비교하려는 값보다 큽니다.' );
    break;
  default:
    alert( "어떤 값인지 파악이 되지 않습니다." );
}
```
- switch문은 `일치연산자(===)`로 조건을 확인하기 때문에 자료형도 일치해야 함
```js
let arg = prompt("값을 입력해주세요.");
switch (arg) {
  case '0':
  case '1':
    alert( '0이나 1을 입력하셨습니다.' );
    break;

  case '2':
    alert( '2를 입력하셨습니다.' );
    break;

  case 3:
    alert( '이 코드는 절대 실행되지 않습니다!' );
    break;
  default:
    alert( '알 수 없는 값을 입력하셨습니다.' );
}
```
- 위 예시에서 `prompt`함수는 사용자가 입력필드에 기재한 값을 **문자열**로 반환하기 때문에 `case 3:` (숫자 3)을 입력하면 falsy로 인식하여 default로 넘어감

## 반복문(loop)
### while 반복문
```js
let i = 0;
while (i < 3) { // 0, 1, 2가 출력됩니다.
  alert( i );
  i++;
}
```
- 반복문이 한 번 실행되느 것을 `이터레이션(iteration: 반복)`이라고 함
- 위 예시에서 반복문이 세 번의 이터레이션을 만듬
```js
let i = 3;
while (i) { // i가 0이 되면 조건이 falsy가 되므로 반복문이 멈춥니다.
  alert( i );
  i--;
}
```
- 반복문 본문이 한 줄짜리 문이라면 중괄호 {…}를 생략할 수 있음
```js
let i = 3;
while (i) alert(i--);
```
### do... while 반복문
- `o..while` 문법을 사용하면 condition을 반복문 본문 아래로 옮길 수 있음
```js
let i = 0;
do {
  alert( i );
  i++;
} while (i < 3);
```
- `do..while` 문법은 조건이 truthy 인지 아닌지에 상관없이, 본문을 최소한 한 번이라도 실행하고 싶을 때만 사용

### for 반복문
```js
for (let i = 0; i < 3; i++) { 
  alert(i);
}
// 0, 1, 2가 출력됩니다.
```
- 반복문의 조건이 falsy가 되면 반복문이 종료
- 특별한 지시자인 break를 사용하면 언제든 원하는 때에 반복문을 빠져나올 수 있음
```js
let sum = 0;

while (true) {
  let value = +prompt("숫자를 입력하세요.", '');

  if (!value) break; // (*)

  sum += value;
}
alert( '합계: ' + sum );
```
- continue는 전체 반복문을 멈추지 않고, 대신에 현재 실행 중인 이터레이션을 멈추고 반복문이 다음 이터레이션을 강제로 실행함
```js
for (let i = 0; i < 10; i++) {

  // 조건이 참이라면 남아있는 본문은 실행되지 않습니다.
  if (i % 2 == 0) continue;

  alert(i); // 1, 3, 5, 7, 9가 차례대로 출력됨
}
```
- `?` 오른쪽엔 `break`나 `continue`가 올 수 없음

### 레이블을 이용하여 break, continue 작성하기
- 레이블을 이용하여 여러 개의 중첩 반복문을 한 번에 빠져나오기
```js
outer: for (let i = 0; i < 3; i++) {

  for (let j = 0; j < 3; j++) {

    let input = prompt(`(${i},${j})의 값`, '');

    // 사용자가 아무것도 입력하지 않거나 Cancel 버튼을 누르면 두 반복문 모두를 빠져나옵니다.
    if (!input) break outer; // (*)

    // 입력받은 값을 가지고 무언가를 함
  }
}
alert('완료!');
```
- break와 continue는 **반복문 안**에서만 사용할 수 있고, 레이블은 반드시 break이나 continue 지시자 위에 있어야 함


## 함수
- 함수(Functions)는 재사용하기를 원하는 기능을 담는 방법
```js
alert('hello!');
```
- `alert`함수는 언제든지 사용할 수 있게 브라우저에 내장
- 함수 정의
```js
function multiply(num1,num2) {
  let result = num1 * num2;
  return result;
}
```
### 인수와 매개변수
```js
function showMessage(from, text) { // 인자: from, text
  alert(from + ': ' + text);
}

showMessage('Ann', 'Hello!'); // Ann: Hello! (*)
showMessage('Ann', "What's up?"); // Ann: What's up? (**)
```
- 위 예시에서 (*), (**)에서 쓰인 'Ann', 'Hello!', 'Ann', "What's up?"은 `인수(argument)`
- `finction showMessage(from, text) {`에서 쓰인 from, text는 `인자(parameter: 매개변수)`

### 반환 값
- 함수를 호출했을 때 함수를 호출한 그곳에 특정 값을 반환하게 할 수 있는데, 이때 이 특정 값을 **반환 값(return value)**이라고 부름
```js
function sum(a, b) {
  return a + b;
}

let result = sum(1, 2);
alert( result ); // 3
```
- 여러 개의 return이 올 수 있음
```js
function checkAge(age) {
  if (age >= 18) {
    return true;
  } else {
    return confirm('보호자의 동의를 받으셨나요?');
  }
}

let age = prompt('나이를 알려주세요', 18);

if ( checkAge(age) ) {
  alert( '접속 허용' );
} else {
  alert( '접속 차단' );
}
```
- 소수(prime number) 찾기 함수
```js
function showPrimes(n) {

  for (let i = 2; i < n; i++) {
    if (!isPrime(i)) continue;

    console.log(i);  // a prime
  }
}

function isPrime(n) {
  for (let i = 2; i < n; i++) {
    if ( n % i == 0) return false;
  }
  return true;
}
showPrimes(99)
```

### 함수 표현식과 함수 선언
- 함수 선언(Function Declaration)
```js
function sayHi() {
  alert( "Hello" );
}
```
- 함수 표현식(Function Expression)
```js
let sayHi = function() {
  alert( "Hello" );
};
```
- 세미 콜론(`;`)
  - 함수 선언문에서는 생략해도 되지만, 함수 표현식에서는 붙여줘야 함
  - 함수 선언문은 `if { ... }, for { }, function f { }` 같이 중괄호로 만든 코드 블록 끝이기 때문에 `;`이 없어도 됨
  - 함수 표현식은 **'코드 블록'** 이 아니고 값처럼 취급되어 변수에 할당되는 **'구문'** 이기 때문에 구문의 끝을 의미하는 `;`을 붙여야 함

### 콜백 함수
```js
function ask(question, yes, no) {
  if (confirm(question)) yes()
  else no();
}

function showOk() {
  alert( "동의하셨습니다." );
}

function showCancel() {
  alert( "취소 버튼을 누르셨습니다." );
}

// 사용법: 함수 showOk와 showCancel가 ask 함수의 인수로 전달됨
ask("동의하십니까?", showOk, showCancel);
```
- 함수 ask의 인수, `showOk`와 `showCancel`은 콜백 함수 또는 콜백이라고 불림

### 화살표 함수
```js
let func = (arg1, arg2, ...argN) => expression
```
```js
let func = function(arg1, arg2, ...argN) {
  return expression;
};
```
- 위의 두 예시는 같은 내용임
```js
let sum = (a, b) => a + b;

/* 위 화살표 함수는 아래 함수의 축약 버전입니다.

let sum = function(a, b) {
  return a + b;
};
*/

alert( sum(1, 2) ); // 3
```
- 본문이 여러 줄인 화살표 함수
```js
let sum = (a, b) => {  // 중괄호는 본문 여러 줄로 구성되어 있음을 알려줍니다.
  let result = a + b;
  return result; // 중괄호를 사용했다면, return 지시자로 결괏값을 반환해주어야 합니다.
};

alert( sum(1, 2) ); // 3
```



## 심볼형
- 심볼(symbol)은 유일한 식별자(unique identifier)를 만들고 싶을 때 사용
```js
let id1 = Symbol("id");
let id2 = Symbol("id");

alert(id1 == id2); // false
```



## 이벤트
### 클릭이벤트
```js
document.querySelector('html').onclick = function() {
    alert('Ouch! Stop poking me!');
}
```