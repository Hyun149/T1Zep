# T1Zep
[개인 과제] 스파르타 메타버스 만들기 과제

📅 2024년 4월 29일 작업 로그 (개발 리드미)
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
