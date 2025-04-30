# T1Zep
[개인 과제] 스파르타 메타버스 만들기 과제

📅 2025년 4월 29일 작업 로그 (개발 리드미)

🔨 주요 기능 구현 및 리팩토링
- feat: 벽 타일 추가 및 플레이어 충돌 처리 구현
- 플레이어가 벽 타일에 막히도록 TilemapCollider2D와 Rigidbody2D 활용
- 충돌 후 이동 제한 확인 완료
- refactor: 입력 처리 및 이동 로직 메서드 분리
- PlayerMovement 스크립트 내 HandleInput() / Move() 메서드 구조화
- SOLID - SRP 원칙 기반으로 코드 가독성과 유지보수성 개선
- feat: 플레이어 점프 시스템 구현
- Ground Collider 없이 점프 구현
- flapForce만큼 상승 후 원래 Y값까지 낙하 → 위치 보정 후 착지 처리
- 물리 안정화를 위해 Start() 내 지연 초기화 적용 (WaitForSeconds)
- feat: 타일 팔레트 및 타일 아트 추가, SampleScene 수정
- Hill, Wall 등 새로운 타일 이미지 추가 및 TilePalette 구성
- 씬 내 테스트 맵 디자인 구성

🧹 환경 설정 및 기타 정리
- chore: .gitignore 설정
- ShaderCompiler 로그 및 Unity 관련 캐시 파일 무시 설정 추가
- chore: unnecessary files 제거 및 프로젝트 폴더 정리
- 초기 생성된 불필요 리소스 정리
- Scripts, Scenes, Settings 등 폴더 구조 통일

  
===========================================================================
📅 2025년 4월 30일 작업 로그 (개발 리드미)

🎮 주요 목표
- 미니게임 시스템의 UI 흐름 설계 및 Scene 연동
- 이벤트 존 트리거 기능 구현 및 사용자 반응 연출
- FlappyPlane 기반 장애물 회피 미니게임 구조 설계 시작
- 전반적인 입력/점프/컨트롤러 구조 리팩토링

🧩 작업 내역
✅ 컨트롤러 및 입력 리팩토링
- PlayerController, PlayerMovement, PlayerJump, PlayerInputHandler 구조 통합 및 책임 분리
- 점프/중력/입력 처리 로직 통일, 외부 제어 방식으로 확장

✅ 이벤트 존 시스템 구축
- InteractionTrigger.cs 작성
- 이벤트 존 진입 시 텍스트 표시, 퇴장 시 자동 숨김 처리
- UI 텍스트와 버튼 연동 및 전환 기능 적용

✅ UI 시스템 확장
- 미니게임 전용 UI 리소스 60종 추가 (TappyPlane 스타일)
- Canvas에 연결하고 각 상황에 맞는 텍스트/버튼 구성 준비

✅ 씬 전환 및 흐름 제어
- SceneLoader와 SceneType enum 기반 구조 도입
- FlappyPlaneButtonHandler에서 버튼 클릭 → 씬 전환 가능하게 처리
- MiniGameManager 통해 시작 타이밍 및 UI 연출 분리

✈️ 오늘의 주요 성과
- 비행기 움직임 로직을 FixedUpdate 기반 물리 제어로 리팩토링 → 떨림 완전 제거
- IsGameStarted 조건 도입으로 UI/컨트롤 흐름 안정화
- Gen.G 비행기 프리팹 장애물 생성 + 이동 구현 시작
- Y축 이동 제한으로 플레이어가 화면 밖으로 벗어나는 문제 방지
