---
title: "정보관리기술사"
excerpt: "정보관리기술사 대비 도메인별 개념 정리 인덱스"
permalink: /pe/
layout: single
author_profile: true
sidebar:
  nav: "topics"
toc: true
toc_label: "도메인"
toc_sticky: true
---

정보관리기술사 취득을 위해 **개념 하나당 글 하나**(단권화 노트)로 정리하는 학습 인덱스입니다. 각 도메인의 개념을 하나씩 채워 나갑니다.

{% assign total = 0 %}{% for d in site.data.pe_domains %}{% assign cp = site.categories[d.slug] %}{% if cp %}{% assign total = total | plus: cp.size %}{% endif %}{% endfor %}
📝 **작성한 글: 총 {{ total }}편** · 도메인 {{ site.data.pe_domains | size }}개
{: .notice--info}

{% for d in site.data.pe_domains %}
## {{ d.label }}{% if d.stars > 0 %} ({% for i in (1..d.stars) %}★{% endfor %}){% endif %}
{: #{{ d.slug }}}
{% assign cp = site.categories[d.slug] %}{% if cp and cp.size > 0 %}
✅ 작성 {{ cp.size }}편
{% for p in cp %}- [{{ p.title }}]({{ p.url }}) <sub>{{ p.date | date: "%Y-%m-%d" }}</sub>
{% endfor %}{% else %}
_아직 작성된 글이 없습니다._
{% endif %}
<details><summary>📚 학습 목록 ({{ d.topics | size }})</summary><p>{{ d.topics | join: " · " }}</p></details>

{% endfor %}
