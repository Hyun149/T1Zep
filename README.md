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

===========================================================================

📅 2025년 5월 1일 작업 로그 (개발 리드미)

✅ 주요 기능 구현 및 리팩토링 내역

🎯 UI 분리 및 점수 관리 리팩토링 (SOLID 원칙 적용)
- MiniGameManager에서 UI 제어 및 점수 계산 책임 분리
- MiniGameUIController, ScoreManager로 역할 분담
- 점수 업데이트 로직 캡슐화 및 GameSequence 흐름 개선

🛫 미니게임(T1Plane) 종료 및 재시작/메인 씬 전환 기능 통합
- 게임 오버 후 재시작 또는 MainScene으로 복귀 기능 구현
- 미니게임 시작/종료/이동 기능 일원화 처리

📸 최고 점수 저장 및 카메라 추적 기능 구현
- 플레이어 위치에 따라 카메라 자동 추적
- 최고 점수 저장 및 관리 기능 ScoreManager에 통합

🌊 파도 텍스처 기반 바다 스크롤 배경 연출
- 2D 파도 텍스처를 활용한 바다 배경 움직임 구현
- 스크롤 속도 제어 및 시각적 몰입감 개선

===========================================================================

📅 2025년 5월 2일 (금) 개발 리드미

✨ 기본 개발 활동
-  feat(stack): 블록 겹침 처리 및 잘림 구현
- feat(stack): 블록 스폰 및 대각 이동 로직 구현
- refactor(stack): 큐브 이동 로직 단순화 및 이동 제어 인터페이스 개선

🧱 타일맵 작업
- feat(tilemap): 신규 T1 타일셋 적용 및 Tile Palette 구조 재구성

🛠️ 예외/버그 수정
- fix: Plane 충돌 시 NullReferenceException 발생 문제 수정

♻️ 리팩토링 & 롤백
- refactor: PlaneController 로직 분리 및 SOLID 기반 구조 개선
- revert: PlaneController 리팩토링 롤백 처리
- reapply: 위 리팩토링 내용 재적용

📦 기타 변경사항
- README 업데이트
- SilverArrow.prefab 추가 및 관련 스크립트 연동
- InputHandler.cs, ArrowShooter.cs 신규 작성 및 구성 정리
- CubeSpawner, StackManager 자동화 구조 반영 및 커밋 정리 완료

===========================================================================

📅 2025년 5월 3일 개발 리드미

✅ 주요 작업 내역
*베인 캐릭터 슈팅 시스템 구현
ArrowShooter: firePoint 기준 방향으로 화살 발사 기능 구현
SilverArrow 프리팹: Rigidbody2D + BoxCollider2D 적용, 발사체로서 구성 완료
InputHandler: Space 키 입력 시 화살 발사 및 쿨타임 처리 로직 구현

*점수 및 UI 시스템 연동
ArrowProjectile: OnTriggerEnter2D로 큐브 충돌 감지 후 점수 +1 처리
StackScoreManager: 싱글톤 점수 관리자 구현 (점수 증가 / 초기화 / 조회)
ScoreUIController: 점수 텍스트 UI에 실시간 반영

*시각적 개선
Veyne: Quad + MeshRenderer 구성, 흰 배경 제거를 위한 Unlit/Transparent 머티리얼 적용
2D Sprite 기반 캐릭터를 3D 환경에서 자연스럽게 표현

🛠 기술적 개선 사항
Rigidbody → Rigidbody2D, BoxCollider → BoxCollider2D로 전환하여 2D 물리 일관성 확보
firePoint.right 방향으로 정확한 발사 방향 제어
OnTriggerEnter2D() 기반 충돌 감지를 통해 점수 판정 안정화

🧠 오늘의 회고
2D와 3D가 혼재된 환경에서의 충돌 처리 및 방향 벡터 정리는 필수
UI 및 게임 매니저 분리로 구조적 안정성 확보
단순 발사체 시스템도 구성요소가 많으므로 철저한 분업과 책임 분리가 효과적임을 실감

===========================================================================

📅 2025년 5월 4일 작업 로그 (개발 리드미)

✅ 주요 작업 내역 feat(plane):

비행기 좌우 이동 기능 구현
넉백 강도 증가로 충돌 반응 개선
feat(animation):

PlayerAnimator 클래스 분리
이동 상태(isRunning)에 따른 애니메이션 전이 설정 및 연동 완료
feat(assets):

던전 타일셋, 프리팹 이미지 에셋 교체 및 .meta 정리
===========================================================================

🛠️ 2025년 5월 6일 작업 로그 (개발 리드미)

✅ 오늘의 작업 내역 🎮 VeyneMove 클래스 구현 ↳ 방향키(←↑↓→) 입력 기반 이동 시스템 구현 ↳ Y축 고정 처리로 일관된 수평 이동 제공

🧱 Stack 게임 구조 개선 ↳ StackScoreManager 싱글턴 구조로 전환 ↳ 점수 UI 연동 로직 정비 및 캔버스 동기화 해결

🌌 배경 구성 및 시각 연출 추가 ↳ Visual 오브젝트에 Quad 기반 배경 이미지 적용 ↳ QuadAnimator를 활용한 Material 텍스처 애니메이션 처리

===========================================================================
