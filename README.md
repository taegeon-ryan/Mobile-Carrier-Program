# Mobile-Carrier-Program
[![Author](https://img.shields.io/badge/author-taegeon-red?style=flat-square)]( https://github.com/taegeon-ryan ) [![Language](https://img.shields.io/badge/language-C%23-green?style=flat-square)]() [![Visual Studio](https://img.shields.io/badge/tools-Visual%20Studio,%20MySQL-green?style=flat-square)]() [![MIT License](https://img.shields.io/badge/license-MIT%20License-blue?style=flat-square)]( https://opensource.org/licenses/MIT )

C# 윈폼으로 만든 통신사 지점용 개통업무 프로그램 (MySQL 연동)

## 메인 화면


## 기능
- 계정, 요금제, 기종 데이터의 **생성/읽기/수정/삭제**
- 개통 신청 : 할인유형, 할부개월, 가입유형에 따라 달라지는 월 통신요금과 단말요금, 납부요금을 보여주고 개통이력 데이터 생성
- 요금제 변경, 명의 변경, 가입 해지, 요금 납부

## 개선할 점
- 계정이 없거나 개통이력이 존재하지 않는 경우 업무 처리 불가능
- 성명, 생년월일 등 데이터에 유효성 검사 필요 **(정규표현식)**
- 데이터를 수정할 때 기존과 다른 값만 비교하여 보여주는 기능 필요
- 기존과 같은 데이터로 수정하는 경우 막기
- 요금제를 변경할 때 4G기기에서 5G 요금제를 사용하는 경우 막기
