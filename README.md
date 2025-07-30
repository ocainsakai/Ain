# 🎮 AinCore Framework

**AinCore** là một bộ các hệ thống cốt lõi (modular systems) do tôi tự phát triển để dùng lại trong nhiều game Unity của tôi.

Repo này chứa các module như:
- Input System
- Turn System
- State Machine
- Object Pooling
- Core Utilities

Mục tiêu: **Tái sử dụng, mở rộng dễ dàng, độc lập tối đa giữa các hệ thống**.

## 📦 Installation
Add this package to your Unity project using Git URL:
```text
https://github.com/ocainsakai/Ain.git
```

## 🧩 Yêu cầu

- **Unity 6 trở lên** (tập trung hỗ trợ và test chính trên **Unity 6000.0.50f**)
- **C# 8.0+**
- **Input System package** (Unity official)
- Tối ưu sử dụng với URP (Universal Render Pipeline)

## ⚙️ Dependencies

Repo này phụ thuộc vào các package sau:

- [**UniTask**](https://github.com/Cysharp/UniTask) — xử lý bất đồng bộ hiệu quả, thay thế cho `Coroutine`
- [**UniRx**](https://github.com/neuecc/UniRx) — Reactive Extensions cho Unity, dùng trong Input và EventSystem
- [**DOTween**](http://dotween.demigiant.com/) — tweening engine mạnh mẽ dùng cho animation UI/logic nội bộ
