# VR·MR 기반 핵심 간호술 실습을 위한 가상병실 콘텐츠 (2D 근육주사 실습)

근육주사 과정을 **손 씻기 → 물품 준비 → 약물 주입** 순서로 연습하는 2D 실습 콘텐츠입니다.
2024 콘텐츠원캠퍼스 구축운영 사업에서 SW 개발을 맡아 만들었습니다.

- 시기: 2024년 5월~12월
- 엔진: Unity 2022.3.31f1, C#
- 인원: 2인 (개발·사운드 1명, 그림 1명)
- 플레이 영상: [포트폴리오 사이트](https://rkdwlals.github.io/#nursing)

## 역할

| 담당 | 내용 |
|---|---|
| 강지민 | 그림 외 개발 전부(손 씻기·물품 준비·약물 주입 단계, 대화창, 씬 전환), 효과음 배치 |
| 그림 파트너 | 화면 전환 그림 2장, 오브젝트 도트 그림 (`Assets/Image_SY`) |

## 구성

씬은 `Start → Load1 → Second → Load2 → Third → 5TH` 순서로 빌드에 등록되어 있습니다.

| 스크립트 (`Assets/Scenes/script`) | 하는 일 |
|---|---|
| `GameStart.cs` | 시작 화면 배경음 재생, Enter로 시작 |
| `DialogueManager.cs` | 대화창 대사 넘김과 효과음 |
| `HandWashing.cs`, `Countdown.cs` | 손 씻기: 마우스 왼쪽·오른쪽 클릭으로 손을 움직이고 정해진 횟수를 세어 다음 단계로 이동 |
| `DragAndDrop.cs`, `GameManager.cs`, `NonCountZone.cs`, `ResetButton.cs`, `CardCheck.cs` | 물품 준비: 물품을 카트로 끌어다 놓기, 필요한 물품(Good)과 함정 물품(Fake) 판정, 초기화 버튼, R키로 투약카드 창 열고 닫기 |
| `Drag.cs`, `SpriteChanger.cs` | 약물 주입: 오브젝트 드래그와 충돌 효과음, 클릭하면 스프라이트 교체 |
| `LoadingScene.cs`, `SceneController.cs`, `Owari.cs`, `Text.cs` | 로딩 화면(5초 후 다음 씬), 씬 전환, 종료, 깜빡이는 안내 문구 |

## 포함하지 않은 파일

아래 파일은 저작권 또는 용량 때문에 올리지 않았습니다. 그래서 이 저장소를 그대로 열면 일부 그림·폰트·소리가 비어 보입니다.

- `TopDown 2D RPG BE3`: 에셋 스토어 에셋 (UI 스프라이트로 사용)
- `Image_JM`: 디자이너와 분위기를 맞추려고 가져온 참고 사진 (시작 화면 배경, 병실 배경, 의료용 카트에 사용)
- `Scenes/Audio`의 효과음 파일: 외부 효과음 소스 (오디오 믹서 설정만 포함)
- `Scenes/TextMesh Pro`: TextMesh Pro 기본 리소스와 Pretendard 폰트 SDF 파일(각 약 39MB). Unity에서 TMP Essentials를 가져오고 Pretendard 폰트로 SDF를 다시 만들면 됩니다.

---

스크립트의 한글 주석은 GitHub에서 읽을 수 있도록 CP949에서 UTF-8로만 변환했고, 코드는 바꾸지 않았습니다. README·.gitignore 정리는 Claude(AI)의 도움을 받았습니다.
